using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookStore.Data
{
    
    public class CategoryService
    {
        private AppDataContext appDataContext;
        public CategoryService(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        public List<Category> getAllBookByCategory(int id)
        {
            Category cat = appDataContext.Category.Include(cat => cat.Categorybook).FirstOrDefault();
            List<Book> books = new List<Book>();
            // for(Categorybook catbook in cat.Categorybook) (

            // )
            return null;
        }
    }
}
