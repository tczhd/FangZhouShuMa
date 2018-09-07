using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Models;
using FangZhouShuMa.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FangZhouShuMa.Framework.Enums;

namespace FangZhouShuMa.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        // GET: api/GetAllProducts
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> students = new List<ProductViewModel>
            {
                new ProductViewModel{
                    CreateDateUTC =  DateTime.UtcNow,
                    Id = 1,
                    LastUpdateDateUTC = DateTime.UtcNow,
                    Name = "数码单张",
                    Price = 100,
                    ProductCustomFieldGroupViewModels = new List<ProductCustomFieldGroupViewModel>()
                    {
                        new ProductCustomFieldGroupViewModel()
                        {
                            Id = 1,
                            Name = "基本参数",
                            ProductCustomFieldViewModels = new List<ProductCustomFieldViewModel>()
                            {
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "自带纸",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                    ProductCustomFieldOptionViewModels = new List<ProductCustomFieldOptionViewModel>()
                                    {
                                        new ProductCustomFieldOptionViewModel()
                                        {}
                                    }
                                },
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "成品尺寸",
                                    Id = 2,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.DropDown,
                                    ProductCustomFieldOptionViewModels = new List<ProductCustomFieldOptionViewModel>()
                                    {
                                        new ProductCustomFieldOptionViewModel()
                                        {
                                            Name = "大4开",
                                            Price = 2,
                                            Sequence = 1
                                        },
                                        new ProductCustomFieldOptionViewModel()
                                        {
                                            Name = "大8开",
                                            Price = 3,
                                            Sequence = 2
                                        }
                                    }
                                },
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "单双面",
                                    Id = 3,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.DropDown,
                                    ProductCustomFieldOptionViewModels = new List<ProductCustomFieldOptionViewModel>()
                                    {
                                        new ProductCustomFieldOptionViewModel()
                                        {
                                            Name = "双面",
                                            Price = 2,
                                            Sequence = 1
                                        },
                                        new ProductCustomFieldOptionViewModel()
                                        {
                                            Name = "单面",
                                            Price = 1,
                                            Sequence = 2
                                        }
                                    }
                                }
                            }
                        },
                        new ProductCustomFieldGroupViewModel()
                        {
                            Id = 1,
                            Name = "后道设置",
                            ProductCustomFieldViewModels = new List<ProductCustomFieldViewModel>()
                            {
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "毛品交货",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "单面光膜",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "双面光膜",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "双面哑膜",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "异形模切",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomFieldViewModel()
                                {
                                    Name = "画刀版文件",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                            }
                        }
                    }
                }
            };
            return students;
        }
    }
}