using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant>GetReataurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name="Scott's Pizza", Location = "Maryland", Cuisine=Restaurant.CuisineType.Italian},
                new Restaurant {Id=2, Name="Cinamon Club", Location="London", Cuisine=Restaurant.CuisineType.None},
                new Restaurant {Id=3, Name="La Costa", Location="California", Cuisine=Restaurant.CuisineType.Mexican}
            };
        }

        public Restaurant GetById(int id )
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetReataurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
