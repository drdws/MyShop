using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
   public abstract class baseEntity
    {
        public string Id { get; set; }
        public DateTime CreateAt { get; set; }

        public baseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreateAt = DateTime.Now;

        }

    }
}
