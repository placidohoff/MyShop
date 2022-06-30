using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    //Our generic InMemoryRepository class expects a BaseEntity so this class must inherit from that if we are to make instances of these as InMemoryRepository:

    public class Product : BaseEntity
    {
        //BaseEntity already has public string Id so this would cause issues to override it.
        //public string Id { get; set; }

        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        public string Description { get; set; }
        
        [Range(0, 1000)]
        public string Price { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        //No constructor neccessary since the BaseEntity has a constructor already:
        //public Product()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
