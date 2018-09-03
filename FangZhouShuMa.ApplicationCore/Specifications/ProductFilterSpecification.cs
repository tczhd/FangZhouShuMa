using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Specifications
{
    public class ProductFilterSpecification : BaseSpecification<Product>
    {
        public ProductFilterSpecification(int? categoryId, int? groupId)
            : base(i => (!categoryId.HasValue || i.Group.CategoryId == categoryId) &&
                (!groupId.HasValue || i.GroupId == groupId))
        {
        }
    }
}
