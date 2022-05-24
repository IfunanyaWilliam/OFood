using Microsoft.EntityFrameworkCore;
using OFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFood.Data.Services
{
    
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly AppDbContext _db;
        public SqlRestaurantData(AppDbContext db)
        {
            _db = db;
        }
        public void Add(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _db.Restaurants.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _db.Restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            //for Optimistic concurrency
            var entry = _db.Entry(restaurant);  
            entry.State = EntityState.Modified; //Check if entity is modified
            _db.SaveChanges();
        }

       
        public void Delete(int id)
        {
            var restaurant = _db.Restaurants.Find(id);
            if(restaurant is not null)
            {
                _db.Remove(restaurant);
                _db.SaveChanges();
            }
        }
    }
}
