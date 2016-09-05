using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarApp.Models
{
    public class DrinkMenu
    {
        [Key]
        public int DrinkId { get; set; }

        public string DrinkName { get; set; }
    }
}