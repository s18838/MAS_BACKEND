using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.DTO;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class HomeDbService : IHomeDbService
    {
        private readonly RestaurantContext _restaurantContext;

        public HomeDbService(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public ICollection<NewsDTO> GetNews()
        {
            return _restaurantContext.Dishes
                .OrderByDescending(e => e.Id)
                .Take(2)
                .OrderBy(e => e.Id)
                .Select(e => new NewsDTO() {
                    Title = $"New Dish - {e.Name}",
                    Image = e.Image,
                    DishId = e.Id
                }).ToList();
        }
    }
}
