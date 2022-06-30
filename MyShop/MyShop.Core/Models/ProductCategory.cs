using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Models
{
    //Must inherit from BaseEntity if we are to use it to make instances from InMemoryRepository class which expects a BaseEntity to be passed to it.
    public class ProductCategory : BaseEntity
    {
        //Base entity already has a public string Id, we will not override it.
        //public string Id { get; set; }

        
        [DisplayName("Category Name")]
        public string Category { get; set; }

        //Constructor not neccessary as BaseEntity already does it.
        //public ProductCategory()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
