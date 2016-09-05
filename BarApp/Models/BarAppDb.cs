using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BarApp.Models
{
    public class BarAppDb : DbContext
    {

        public BarAppDb() : base("name=DefaultConnection")
        {

        }


        public DbSet<DrinkMenu> Drinks { get; set; }

        public DbSet<OrderQueue> Orders { get; set; }


    }
}