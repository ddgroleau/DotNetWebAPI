using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebAPI.Models
{
    public class InventoryItem
    {
        public InventoryItem(string id, string item, decimal cost, bool inStock)
        {
            Id = id;
            Item = item;
            Cost = cost;
            InStock = inStock;
        }
        public string Id { get; set; }
        public string Item { get; set;  }
        public decimal Cost { get; set; }
        public bool InStock { get; set; }
    }

    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<InventoryItem> Inventory { get; set; }
    }
}
