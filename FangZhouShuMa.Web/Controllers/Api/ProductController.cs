using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Models;
using FangZhouShuMa.Web.Models.ApiModels.Product;
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
        public IEnumerable<ProductDetail> GetAllProducts()
        {
            List<ProductDetail> students = new List<ProductDetail>
            {
                new ProductDetail{
                    CreateDateUTC =  DateTime.UtcNow,
                    Id = 1,
                    LastUpdateDateUTC = DateTime.UtcNow,
                    Name = "数码单张",
                    Price = 100,
                    ProductCustomFieldGroups = new List<ProductCustomFieldGroup>()
                    {
                        new ProductCustomFieldGroup()
                        {
                            Id = 1,
                            Name = "基本参数",
                            ProductCustomFields = new List<ProductCustomField>()
                            {
                                new ProductCustomField()
                                {
                                    Name = "自带纸",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                    ProductCustomFieldOptions = new List<ProductCustomFieldOption>()
                                    {
                                        new ProductCustomFieldOption()
                                        {}
                                    }
                                },
                                new ProductCustomField()
                                {
                                    Name = "成品尺寸",
                                    Id = 2,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.DropDown,
                                    ProductCustomFieldOptions = new List<ProductCustomFieldOption>()
                                    {
                                        new ProductCustomFieldOption()
                                        {
                                            Name = "大4开",
                                            Price = 2,
                                            Sequence = 1
                                        },
                                        new ProductCustomFieldOption()
                                        {
                                            Name = "大8开",
                                            Price = 3,
                                            Sequence = 2
                                        }
                                    }
                                },
                                new ProductCustomField()
                                {
                                    Name = "单双面",
                                    Id = 3,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.DropDown,
                                    ProductCustomFieldOptions = new List<ProductCustomFieldOption>()
                                    {
                                        new ProductCustomFieldOption()
                                        {
                                            Name = "双面",
                                            Price = 2,
                                            Sequence = 1
                                        },
                                        new ProductCustomFieldOption()
                                        {
                                            Name = "单面",
                                            Price = 1,
                                            Sequence = 2
                                        }
                                    }
                                }
                            }
                        },
                        new ProductCustomFieldGroup()
                        {
                            Id = 1,
                            Name = "后道设置",
                            ProductCustomFields = new List<ProductCustomField>()
                            {
                                new ProductCustomField()
                                {
                                    Name = "毛品交货",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomField()
                                {
                                    Name = "单面光膜",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomField()
                                {
                                    Name = "双面光膜",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomField()
                                {
                                    Name = "双面哑膜",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomField()
                                {
                                    Name = "异形模切",
                                    Id = 1,
                                    Price = 0,
                                    FieldTypeId = (int)ProductCustomFieldType.Boolean,
                                },
                                new ProductCustomField()
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