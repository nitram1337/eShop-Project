using DataLayer;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.Dto;
using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //InitializeDb();

            using (var context = new EshopContext())
            {
                // Tuples for DropDownControl i webclient
                //var blogFilterDropdownService = new BlogFilterDropdownService(context);
                //var dropdownItems = blogFilterDropdownService.GetFilterDropDownValues(BlogsFilterBy.ByOwner).ToList();

                //foreach (var item in dropdownItems)
                //{
                //    Console.WriteLine("{0} - {1}", item.Value, item.Text);
                //}




                var blogService = new ListProductService(context);
                var blogs = blogService.SortFilterPage(new SortFilterPageOptions
                {
                    OrderByOptions = OrderByOptions.ByBrand,
                    //FilterBy = ProductsFilterBy.ByBrand,
                    //FilterValue = "Mercedes",

                    PageNum = 1,
                    PageSize = 5
                }).ToList();

                foreach (ProductListDto blog in blogs)
                {
                    Console.WriteLine("\nBrand: {0} \nModel: {1} \nPhoto: {2} \nPrice {3}",
                        blog.BrandName,
                        blog.ModelName,
                        blog.PhotoPath,
                        blog.Price
                        );
                }
            }
        }

        //private static void InitializeDb()
        //{
        //    using (var context = new EshopContext())
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();
        //        Console.WriteLine("Database recreated");
        //    }
        //}
    }
}
