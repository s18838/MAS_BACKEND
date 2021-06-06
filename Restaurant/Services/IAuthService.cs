using System;
using Restaurant.DTO;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IAuthService
    {
        public Person CreateAccount(AccountDTO accountDTO);
        public TokenDTO Login(AccountDTO accountDTO);
    }
}
