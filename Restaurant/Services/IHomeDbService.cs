using System;
using System.Collections.Generic;
using Restaurant.DTO;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IHomeDbService
    {
        public ICollection<NewsDTO> GetNews();
    }
}
