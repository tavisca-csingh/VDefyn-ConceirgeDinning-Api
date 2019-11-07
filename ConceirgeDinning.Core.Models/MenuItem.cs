using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Contracts.Models
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
    public class Category
    {
        public string category { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}
