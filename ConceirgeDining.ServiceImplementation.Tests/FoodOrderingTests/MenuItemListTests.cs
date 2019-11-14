using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConceirgeDinning.ServicesImplementation.FoodOrdering;
using ConceirgeDinning.Contracts.Models;

namespace ConceirgeDining.ServiceImplementation.Tests.FoodOrderingTests
{
    public class MenuItemListTests
    {
       private MenuItemList menuItemList = new MenuItemList(); 
        [Fact]
        public void Get_Restaurant_Menu_Details_By_RestaurantId_For_Valid_Id()
        {
            var itemList = menuItemList.GetMenus("1234","Zomato");
            bool actual = itemList is List<Category>;
            Assert.True(actual);
        }
        [Fact]
        public void Get_Restaurant_Menu_Details_By_RestaurantId_For_Invalid_Id()
        {
            var itemList = menuItemList.GetMenus("1234", "UsRestaurant");
            bool actual = itemList is null;
            Assert.True(actual);
        }
    }
}
