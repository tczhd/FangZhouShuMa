using FangZhouShuMa.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;

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
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<FangZhouShuMaContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(fangZhouShuMaContext, loggerFactory, retryForAvailability);
                }
            }
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
    }
}
