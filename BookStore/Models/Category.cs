using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Category
    {
        public Category()
        {
            Categorybook = new HashSet<Categorybook>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public int? ParentID {get;set;}
        public Category Parent {get;set;}

        public virtual ICollection<Category> childCategories {get;set;}
        public virtual ICollection<Categorybook> Categorybook { get; set; }
    }
}
