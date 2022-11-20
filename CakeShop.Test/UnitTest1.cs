using CakeShop.Controllers;
using CakeShop.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using CakeShop.Persistence;
using CakeShop.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CakeShop.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            AccountController accountController = new AccountController(null, null );

            ViewResult viewResult = accountController.Login(" ") as ViewResult;
            Assert.IsType<LoginViewModel>(viewResult.Model);

        }
        [Fact]
        public async Task Test2()
        {
            var host = WebHost.CreateDefaultBuilder(null)
                .UseStartup<Startup>()
                .Build();
            var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CakeShopDbContext>();

            CakeRepository cakeRepository = new CakeRepository(context);

            Cake cake = await cakeRepository.GetCakeById(1) as Cake;

            Assert.Equal("Strawberry Cake", cake.Name);

            //RegisterViewModel registerViewModel = new RegisterViewModel();
            ////AccountController accountController = new AccountController(null, null);

            ////ViewResult viewResult = accountController.Register(" ") as ViewResult;
            ////Assert.IsNotType<LoginViewModel>(viewResult.Model);

        }
        [Fact]
        public async Task Test3() {
            var host = WebHost.CreateDefaultBuilder(null)
                .UseStartup<Startup>()
                .Build();
            var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CakeShopDbContext>();

            CategoryRepository categoryRepository = new CategoryRepository(context);

            List<Category> category = await categoryRepository.GetCategories() as List<Category>;

            Assert.Equal(3, category.ToArray().Length);
        }
    }
}
