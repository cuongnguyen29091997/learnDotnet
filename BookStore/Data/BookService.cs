using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookStore.Data
{
    public class BookService
    {
        public static int PageSize = 4;
        private AppDataContext appDataContext;

        public BookService(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        public ICollection<Book> ListAllBooks()
        {
            return appDataContext.Book.ToList();
        }

        public List<Category> getAllCategories()
        {
            return appDataContext.Category.Include(cat => cat.Categorybook).ToList();
        }

        public List<Book> getBookByCategoryAndPage(int catId, int page = 1)
        {
            int skip = (page - 1) * PageSize;
            var catbooks = appDataContext.Categorybook.Include(cb => cb.Book).Where(cb => cb.CategoryId == catId).Skip(skip).Take(PageSize).ToList();
            Console.WriteLine(catbooks.Count.ToString());
            List<Book> lists = new List<Book>();
            foreach(var cb in catbooks)
            {
                lists.Add(cb.Book);
            }
            Console.WriteLine(lists.Count.ToString());
            return lists;
        }

        public int countBooksByCategory(int catId)
        {
            return appDataContext.Categorybook
                                    .Include(cb => cb.Book)
                                    .Where(cb => cb.CategoryId == catId)
                                    .Count();
        }
        public Dictionary<Book, int> FindAll(Dictionary<int, int> bookIds)
        {
            var query = from kv in bookIds
                select new KeyValuePair<Book, int>(appDataContext.Book.Find(kv.Key), kv.Value);
            return query.ToDictionary(v => v.Key, v => v.Value);
        }

        public Book GetById(int id)
        {
            return appDataContext.Book.Find(id);
        }
    }
}
