using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
public  class Basket  : baseEntity
    {
        public virtual ICollection<BasketItem> BasketItemCollection { get; set; }
        public Basket()
        {
            this.BasketItemCollection = new List<BasketItem>();


        }


    }
}
