using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    //Has a generic placeholder: <T>
    //We need a base class referenced that has an Id property so our generic class understands what '.Id' is.
        //BaseEntity fixes this:

    public class InMemoryRepository<T> where T: BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            //Will get the name of whatever class we are trying to pass in:
            className = typeof(T).Name;

            //Get a reference to our in our in computer cache if it exist.
            items = cache[className] as List<T>;

            //Create a new cache if one does not exist already under that name
            if (items == null)
            {
                items = new List<T>();
            }
        }

        //Save our data to the in computer cache
        public void Commit()
        {
            cache[className] = items;
        }

        //CRUD FUNCTIONS:
        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);

            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + " Not found");
            }
        }

        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " Not found");
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);

            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + " Not found");
            }
        }
    }
}
