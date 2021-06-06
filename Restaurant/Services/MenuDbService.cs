using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class MenuDbService : IMenuDbService
    {
        private readonly RestaurantContext _restaurantContext;

        public MenuDbService(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public ICollection<Dish> GetMenu()
        {
            return _restaurantContext.Dishes.ToList();
        }
    }
}
