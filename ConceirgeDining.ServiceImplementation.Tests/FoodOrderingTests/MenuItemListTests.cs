using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConceirgeDinning.ServicesImplementation.FoodOrdering;
using ConceirgeDinning.Contracts.Models;
using Microsoft.Extensions.Options;

namespace ConceirgeDining.ServiceImplementation.Tests.FoodOrderingTests
{
    public class MenuItemListTests
    {
        
        [Fact]
        public void Get_Restaurant_Menu_Details_By_RestaurantId_For_Valid_Id()
        {
            AppSettingsModel appSettings = new AppSettingsModel() { ZomatoMenuItemUrl= "http://demo9372501.mockable.io/menuitem" };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            MenuItemList menuItemList = new MenuItemList();
            var itemList = menuItemList.GetMenus("1234","Zomato",options);
            bool actual = itemList is List<Category>;
            Assert.True(actual);
        }
        [Fact]
        public void Get_Restaurant_Menu_Details_By_RestaurantId_For_Invalid_Id()
        {
            AppSettingsModel appSettings = new AppSettingsModel() { ZomatoMenuItemUrl = "http://demo9372501.mockable.io/menuitem" };
            IOptions<AppSettingsModel> options = Options.Create(appSettings);
            MenuItemList menuItemList = new MenuItemList();
            var itemList = menuItemList.GetMenus("1234","UsRestaurant",options);
            bool actual = itemList is null;
            Assert.True(actual);
        }
    }
}
