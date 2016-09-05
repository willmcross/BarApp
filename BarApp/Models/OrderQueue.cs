using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarApp.Models
{
    public class OrderQueue
    {
        [Key]
        public int OrderId { get; set; }

        public int DrinkId { get; set; }

        public string DrinkName { get; set; }

    }
}