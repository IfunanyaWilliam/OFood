using OFood.Data.Models;
using System.Linq;

namespace OFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Willy's Pizza", Cuisine = CuisineType.French },
                new Restaurant { Id = 2, Name = "Domino View", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Gaztby Home", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 4, Name = "DonBilly Palace", Cuisine = CuisineType.French }
            };
        }

        public Restaurant Get(int id)
        {
           return restaurants.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
        } 

        public void Update(Restaurant restaurant)
        {
            var updatedRestaurant = restaurants.Where(r => r.Id == restaurant.Id).FirstOrDefault();
            updatedRestaurant.Id = restaurant.Id;
            updatedRestaurant.Name = restaurant.Name;
            updatedRestaurant.Cuisine = restaurant.Cuisine;

            //Another implementation
            //var existingRestaurant = Get(restaurant.Id);
            //if (existingRestaurant is not null)
            //{
            //    existingRestaurant.Name = restaurant.Name;
            //    existingRestaurant.Cuisine = restaurant.Cuisine;
            //}
        }

        public void Delete(int id)
        {
            var restaurant = restaurants.Where(r => r.Id == id).FirstOrDefault(); ;
            if (restaurant is not null)
            {
                restaurants.Remove(restaurant);
            }
        }

    }
}
