﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using FangZhouShuMa.ApplicationCore.Entities.BasketAggregate;
using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.ApplicationCore.Models;
using FangZhouShuMa.ApplicationCore.Specifications;
using FArdalis.GuardClauses;

namespace FangZhouShuMa.ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        //private readonly IUriComposer _uriComposer;
        private readonly IAppLogger<BasketService> _logger;
        private readonly IRepository<Product> _itemRepository;

        public BasketService(IAsyncRepository<Basket> basketRepository,
            IRepository<Product> itemRepository,
            //IUriComposer uriComposer,
            IAppLogger<BasketService> logger)
        {
            _basketRepository = basketRepository;
            //_uriComposer = uriComposer;
            this._logger = logger;
            _itemRepository = itemRepository;
        }

        public async Task AddItemToBasket(int basketId, int productId, decimal price, List<BasketItemDetailModel> itemDetailModels, decimal quantity)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);

            var basketItemDetails = itemDetailModels.Select(p => new BasketItemDetail() {
                ProductCustomFieldData = p.ProductCustomFieldData,
                ProductCustomFieldDataDescription = p.ProductCustomFieldDataDescription,
                ProductCustomFieldGroupId = p.ProductCustomFieldGroupId,
                ProductCustomFieldGroupName = p.ProductCustomFieldGroupName,
                ProductCustomFieldId = p.ProductCustomFieldId,
                ProductCustomFieldName = p.ProductCustomFieldName,
                ProductCustomFieldOptionId = p.ProductCustomFieldOptionId,
                ProductCustomFieldTypeId = p.ProductCustomFieldTypeId
            }).ToList();

            basket.AddItem(productId, price, basketItemDetails, quantity);

            await _basketRepository.UpdateAsync(basket);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);

            await _basketRepository.DeleteAsync(basket);
        }

        public async Task<decimal> GetBasketItemCountAsync(string userName)
        {
            Guard.Against.NullOrEmpty(userName, nameof(userName));
            var basketSpec = new BasketWithItemsSpecification(userName);
            var basket = (await _basketRepository.ListAsync(basketSpec)).FirstOrDefault();
            if (basket == null)
            {
                _logger.LogInformation($"No basket found for {userName}");
                return 0;
            }
            var count = basket.Items.Sum(i => i.Quantity);
            _logger.LogInformation($"Basket for {userName} has {count} items.");
            return count;
        }

        public async Task SetQuantities(int basketId, Dictionary<string, int> quantities)
        {
            Guard.Against.Null(quantities, nameof(quantities));
            var basket = await _basketRepository.GetByIdAsync(basketId);
            Guard.Against.NullBasket(basketId, basket);
            foreach (var item in basket.Items)
            {
                if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                {
                    _logger.LogInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
                    item.Quantity = quantity;
                }
            }
            await _basketRepository.UpdateAsync(basket);
        }

        public async Task TransferBasketAsync(string anonymousId, string userName)
        {
            Guard.Against.NullOrEmpty(anonymousId, nameof(anonymousId));
            Guard.Against.NullOrEmpty(userName, nameof(userName));
            var basketSpec = new BasketWithItemsSpecification(anonymousId);
            var basket = (await _basketRepository.ListAsync(basketSpec)).FirstOrDefault();
            if (basket == null) return;
            basket.BuyerId = userName;
            await _basketRepository.UpdateAsync(basket);
        }
    }
}
