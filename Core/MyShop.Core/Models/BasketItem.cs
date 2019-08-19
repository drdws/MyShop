using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
  public  class BasketItem : baseEntity
    {

        public string BasketID { get; set; }
        public string ProductID { get; set; }
        public int Quanity { get; set; }


    }
}
