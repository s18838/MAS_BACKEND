using System;
using System.Collections.Generic;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IMenuDbService
    {
        public ICollection<Dish> GetMenu();
    }
}
