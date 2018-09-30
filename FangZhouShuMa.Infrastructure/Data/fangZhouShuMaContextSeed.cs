using FangZhouShuMa.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using FangZhouShuMa.Framework.Enums;
using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;

namespace FangZhouShuMa.Infrastructure.Data
{
    public class FangZhouShuMaContextSeed
    {
        public static async Task SeedAsync(FangZhouShuMaContext fangZhouShuMaContext,
           ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();
                if (!fangZhouShuMaContext.SalesChannels.Any())
                {
                    fangZhouShuMaContext.SalesChannels.AddRange(
                        GetPreconfiguredSalesChannels());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }

                if (!fangZhouShuMaContext.AccountGroups.Any())
                {
                    fangZhouShuMaContext.AccountGroups.AddRange(
                        GetPreconfiguredAccountGroups());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }

                if (!fangZhouShuMaContext.Categories.Any())
                {
                    fangZhouShuMaContext.Categories.AddRange(
                        GetPreconfiguredCategories());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }

                if (!fangZhouShuMaContext.Groups.Any())
                {
                    fangZhouShuMaContext.Groups.AddRange(
                        GetPreconfiguredGroups());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }

                if (!fangZhouShuMaContext.Products.Any())
                {
                    fangZhouShuMaContext.Products.AddRange(
                        GetPreconfiguredItems());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }


                if (!fangZhouShuMaContext.ProductCustomFieldGroups.Any())
                {
                    fangZhouShuMaContext.ProductCustomFieldGroups.AddRange(
                        GetPreconfiguredProductCustomFieldGroups());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }

                if (!fangZhouShuMaContext.ProductCustomFields.Any())
                {
                    fangZhouShuMaContext.ProductCustomFields.AddRange(GetPreconfiguredProductCustomFields());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }

                if (!fangZhouShuMaContext.ProductCustomFieldDatas.Any())
                {
                    fangZhouShuMaContext.ProductCustomFieldDatas.AddRange(GetPreconfiguredProductCustomFieldData());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }

                if (!fangZhouShuMaContext.ProductCustomFieldOptions.Any())
                {
                    fangZhouShuMaContext.ProductCustomFieldOptions.AddRange(GetPreconfiguredProductCustomFieldOptions());

                    await fangZhouShuMaContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<FangZhouShuMaContextSeed>();
                    log.LogError(ex.Message);
                    // await SeedAsync(fangZhouShuMaContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<SalesChannel> GetPreconfiguredSalesChannels()
        {
            return new List<SalesChannel>()
            {
                new SalesChannel() { Name = "零售"},
                new SalesChannel() { Name = "批发"},
            };
        }

        static IEnumerable<AccountGroup> GetPreconfiguredAccountGroups()
        {
            return new List<AccountGroup>()
            {
                new AccountGroup() {SalesChannelId= 1,  Name = "默认组",Active = true},
                new AccountGroup() {SalesChannelId = 2, Name = "默认组",Active = true}
            };
        }

        static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category() { Name = "数码报价",Active = true, Sequence = 1},
                new Category() { Name = "传统报价",Active = true, Sequence = 2}
            };
        }

        static IEnumerable<Group> GetPreconfiguredGroups()
        {
            return new List<Group>()
            {
                new Group() {Name = "默认组", Active = true, Sequence = 1, CategoryId = 1},
                new Group() {Name = "默认组", Active = true, Sequence = 1, CategoryId = 2},
            };
        }

        static IEnumerable<Product> GetPreconfiguredItems()
        {
            return new List<Product>()
            {
                new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "宣传页/折页/海报...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "数码单张", Price = 500, Sequence = 1,  UpdatedBy =1 ,PictureUri = "bg66_1"

                },

               new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "书籍/画册/样本...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "简单画册", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_3"

                },
               new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "硬壳精装/纪念画册...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "精装画册", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_4"

                },
               new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "封套/卡套/信封...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "数码封套", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_6"

                },
               new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "手提袋包装盒...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "数码手提袋", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_5"

                },
               new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "铜扳/书写/透明...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "数码不干胶", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_2"

                },
               new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "台历/周历/日历...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "台历", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_7"

                },
               new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "挂历/月历/日历...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "挂历", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_8"

                },
                 new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "专业级写真打印...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "艺术微喷", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_11"

                },
                   new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "X型展架...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "X型展架", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_10"

                },
                     new Product() {
                    Active =true,Cost= 10, CreateDateUTC = DateTime.UtcNow, Description = "铝合金易拉宝转架...",GroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,
                    MinumumQuantity = 10,MultipleMinumumQuantity = true, Name= "易拉宝", Price = 500, Sequence = 1,  UpdatedBy =1,PictureUri = "bg66_19"

                },
            };
        }

        static IEnumerable<ProductCustomFieldGroup> GetPreconfiguredProductCustomFieldGroups()
        {
            return new List<ProductCustomFieldGroup>()
            {
                new ProductCustomFieldGroup() {Name="基本参数"},
                new ProductCustomFieldGroup() {Name="封面设置"},
                new ProductCustomFieldGroup() {Name="内页设置"},
                new ProductCustomFieldGroup() {Name="底座设置"},
                new ProductCustomFieldGroup() {Name="后道设置"}
            };
        }

        static IEnumerable<ProductCustomField> GetPreconfiguredProductCustomFields()
        {
            return new List<ProductCustomField>()
            {
                #region 数码单张报价
                //#region 基本参数
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,Name = "自带纸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "成品尺寸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "单双面", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "纸张", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "颜色", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "品种", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Numerical,MaxLength = 100, Price = 10,Sequence = 1},
                //#endregion

                //  #region 后道设置
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "毛品交货", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "单面光膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "双面光膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "单面哑膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //  new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "双面哑膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "打孔", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "异形模切", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "画刀版文件", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "单面局部UV", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "双面局部UV", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "过塑", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //  new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "压痕", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //   new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "折页", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //    new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "压齿线", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "打号码", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码单张报价",  ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "烫印", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "击凸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码单张报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "凹凸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //#endregion
                  #endregion

                #region 简单画册报价
                //#region 基本参数
                //new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,Name = "成品尺寸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,Name = "装订方式", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                // #endregion

                // #region 封面设置
                //new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 2, LastUpdateDateUTC = DateTime.UtcNow,Name = "自带纸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 2, LastUpdateDateUTC = DateTime.UtcNow,Name = "封面颜色", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 2, LastUpdateDateUTC = DateTime.UtcNow,Name = "封面单双面", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //  new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 2, LastUpdateDateUTC = DateTime.UtcNow,Name = "特殊封面设置", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //   new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 2, LastUpdateDateUTC = DateTime.UtcNow,Name = "封面纸张", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //    new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId =2, LastUpdateDateUTC = DateTime.UtcNow,Name = "封面P数", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //         new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId =2, LastUpdateDateUTC = DateTime.UtcNow,Name = "封面覆膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //#endregion

                //  #region 内页设置
                //new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 3, LastUpdateDateUTC = DateTime.UtcNow,Name = "自带纸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 3, LastUpdateDateUTC = DateTime.UtcNow,Name = "内页颜色", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 3, LastUpdateDateUTC = DateTime.UtcNow,Name = "内页单双面", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //  new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 3, LastUpdateDateUTC = DateTime.UtcNow,Name = "内页纸张", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //   new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 3 , LastUpdateDateUTC = DateTime.UtcNow,Name = "内页P数", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //    new ProductCustomField() {Description= "简单画册报价", ProductCustomFieldGroupId = 3, LastUpdateDateUTC = DateTime.UtcNow,Name = "内页覆膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //#endregion
                  #endregion

                #region 数码手提袋报价
                //#region 基本参数
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 1, LastUpdateDateUTC = DateTime.UtcNow,Name = "自带纸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "成品尺寸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "单双面", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "纸张", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 1,LastUpdateDateUTC = DateTime.UtcNow,Name = "颜色", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.DropDown,MaxLength = 100, Price = 10,Sequence = 1},
                //#endregion

                //  #region 后道设置
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "毛品交货", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "单面光膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "双面光膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "单面哑膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //  new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "双面哑膜", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "异形模切", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "画刀版文件", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "单面局部UV", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "双面局部UV", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "手工粘贴", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //  new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "放垫片", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //   new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "手袋手工", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //new ProductCustomField() {Description= "数码手提袋报价",  ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "烫印", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "击凸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                // new ProductCustomField() {Description= "数码手提袋报价", ProductCustomFieldGroupId = 5, LastUpdateDateUTC = DateTime.UtcNow,Name = "凹凸", Active = true
                //,FieldTypeId = (int)ProductCustomFieldType.Boolean,MaxLength = 100, Price = 10,Sequence = 1},
                //#endregion
                  #endregion
            };
        }

        static IEnumerable<ProductCustomFieldData> GetPreconfiguredProductCustomFieldData()
        {
            return new List<ProductCustomFieldData>()
            {
                #region 数码单张报价
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 1, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 2, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 3, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 4, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 9, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 20, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 21, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 22, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 23, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 24, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 25, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 26, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 27, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 28, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 29, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 30, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 31, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 32, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 33, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 34, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 35, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 36, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 37, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 1, ProductCustomFieldId = 38, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                #endregion

                #region 简单画册报价
                //    new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 5, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 6, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 7, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 8, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 10, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 11, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 12, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 13, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 14, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 15, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 16, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 17, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 18, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 19, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 2, ProductCustomFieldId = 39, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow}

                #endregion

                #region 数码手提袋报价
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 40, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 41, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 42, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 43, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 44, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 45, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 46, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 47, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 48, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 49, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 50, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 51, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 52, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 53, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 54, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 55, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 56, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 57, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 58, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                //new ProductCustomFieldData(){  ProductId = 5, ProductCustomFieldId = 59, FieldData = "", LastUpdateDateUtc = DateTime.UtcNow},
                  #endregion
            };
        }

        static IEnumerable<ProductCustomFieldOption> GetPreconfiguredProductCustomFieldOptions()
        {
            return new List<ProductCustomFieldOption>()
            {
                #region 数码单张报价
                //#region 基本参数
                //new ProductCustomFieldOption(){  DisplayByRelationship = false, Active= true,Name = "大4开", Price = 5, ProductCustomFieldId = 22, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "大8开", Price = 5, ProductCustomFieldId = 22, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "大16开", Price = 5, ProductCustomFieldId = 22, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "大32开", Price = 5, ProductCustomFieldId = 22, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单面", Price = 5, ProductCustomFieldId = 23, Sequence = 1},
                //  new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "双面", Price = 5, ProductCustomFieldId = 23, Sequence = 1},

                //    new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "轻质纸", Price = 5, ProductCustomFieldId = 24, Sequence = 1},
                //      new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "道林纸", Price = 5, ProductCustomFieldId = 24, Sequence = 1},
                //        new ProductCustomFieldOption(){ DisplayByRelationship = false, Active= true,Name = "铜版纸", Price = 5, ProductCustomFieldId = 24, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单色", Price = 5, ProductCustomFieldId = 25, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "彩色", Price = 5, ProductCustomFieldId = 25, Sequence = 1},

                //#endregion

                //#region 后道设置

                //#endregion
                #endregion

                #region 简单画册报价
                //#region 基本参数

                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "大8开", Price = 5, ProductCustomFieldId = 5, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "大16开", Price = 5, ProductCustomFieldId = 5, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "大32开", Price = 5, ProductCustomFieldId = 5, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "A4", Price = 5, ProductCustomFieldId = 5, Sequence = 1},

                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "不装订", Price = 5, ProductCustomFieldId = 6, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "无线装", Price = 5, ProductCustomFieldId = 6, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "铁丝装", Price = 5, ProductCustomFieldId = 6, Sequence = 1},
                // #endregion

                // #region 封面设置
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单色", Price = 5, ProductCustomFieldId = 8, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "彩色", Price = 5, ProductCustomFieldId = 8, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单面", Price = 5, ProductCustomFieldId = 10, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "双面", Price = 5, ProductCustomFieldId = 10, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "增加勒口", Price = 5, ProductCustomFieldId = 18, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "增加拉页", Price = 5, ProductCustomFieldId = 18, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "轻质纸", Price = 5, ProductCustomFieldId = 11, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "道林纸", Price = 5, ProductCustomFieldId = 11, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "铜版纸", Price = 5, ProductCustomFieldId = 11, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "4P", Price = 5, ProductCustomFieldId = 12, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "不覆膜", Price = 5, ProductCustomFieldId = 13, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单面光膜", Price = 5, ProductCustomFieldId = 13, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "双面光膜", Price = 5, ProductCustomFieldId = 13, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单面亚膜", Price = 5, ProductCustomFieldId = 13, Sequence = 1},
                //#endregion

                //  #region 内页设置
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单色", Price = 5, ProductCustomFieldId = 15, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "彩色", Price = 5, ProductCustomFieldId = 15, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单面", Price = 5, ProductCustomFieldId = 16, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "双面", Price = 5, ProductCustomFieldId = 16, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "轻质纸", Price = 5, ProductCustomFieldId = 17, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "道林纸", Price = 5, ProductCustomFieldId = 17, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "铜版纸", Price = 5, ProductCustomFieldId = 17, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "不覆膜", Price = 5, ProductCustomFieldId = 39, Sequence = 1},
                // new ProductCustomFieldOption(){ DisplayByRelationship = false, Active= true,Name = "单面光膜", Price = 5, ProductCustomFieldId = 39, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "双面光膜", Price = 5, ProductCustomFieldId = 39, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单面亚膜", Price = 5, ProductCustomFieldId = 39, Sequence = 1},
                //#endregion
                #endregion

                #region 数码手提袋报价
                //#region 基本参数
                //new ProductCustomFieldOption(){  DisplayByRelationship = false, Active= true,Name = "360*280*80", Price = 15, ProductCustomFieldId = 57, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "400*280*80", Price = 15, ProductCustomFieldId = 57, Sequence = 1},
                //new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "400*260*100", Price = 15, ProductCustomFieldId = 57, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单面", Price = 25, ProductCustomFieldId = 56, Sequence = 1},
                //  new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "双面", Price = 25, ProductCustomFieldId = 56, Sequence = 1},

                //    new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "宣纸", Price = 5, ProductCustomFieldId = 55, Sequence = 1},
                //      new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "哑粉纸", Price = 5, ProductCustomFieldId = 55, Sequence = 1},
                //        new ProductCustomFieldOption(){ DisplayByRelationship = false, Active= true,Name = "铜版纸", Price = 5, ProductCustomFieldId = 55, Sequence = 1},

                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "单色", Price = 5, ProductCustomFieldId = 54, Sequence = 1},
                // new ProductCustomFieldOption(){  DisplayByRelationship = false,Active= true,Name = "彩色", Price = 5, ProductCustomFieldId = 54, Sequence = 1},

                //#endregion
                #endregion
            };
        }
    }
}
