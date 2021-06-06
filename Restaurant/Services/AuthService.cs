using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using Restaurant.DTO;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class AuthService : IAuthService
    {
        private readonly RestaurantContext _restaurantContext;

        public AuthService(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public TokenDTO Login(AccountDTO accountDTO)
        {
            Person person = _restaurantContext.Clients
                .Where(e => e.Email == accountDTO.Email
                && e.Password == GetPassword(accountDTO.Password))
                .SingleOrDefault();

            if (person == null)
            {
                throw new Exception("Account doesn`t exist");
            }

            string token = CreateJwtToken(person);
            return new TokenDTO() {
                Token = token,
                Name = person.Name,
                Surname = person.Surname
            };
        }

        public Person CreateAccount(AccountDTO accountDTO)
        {
            Person isExist = _restaurantContext.People
                .Where(e => e.Email == accountDTO.Email)
                .SingleOrDefault();

            if (isExist != null)
            {
                throw new Exception("Client already exists");
            }

            Client client = new Client()
            {
                Email = accountDTO.Email,
                Password = GetPassword(accountDTO.Password),
                Name = accountDTO.Name,
                Surname = accountDTO.Surname
            };

            _restaurantContext.Clients.Add(client);
            _restaurantContext.SaveChanges();

            client.Password = null;
            return client;
        }

        private string GetPassword(string password)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                password,
                                Encoding.UTF8.GetBytes("TEST"),
                                KeyDerivationPrf.HMACSHA512,
                                1000,
                                256 / 8
                            );
            return Convert.ToBase64String(valueBytes);
        }

        private string CreateJwtToken(Person person)
        {
            var claims = new[]
               {
                    new Claim(ClaimTypes.Name, person.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Client")
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mknjbiuyvtcr56768hj897654sd6f7gtyh"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
            (
                issuer: "Restaurant",
                audience: "Users",
                claims: claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
