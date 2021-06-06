using System;
namespace Restaurant.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }

        public Person() { }

        public Person(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Password = person.Password;
            Email = person.Email;
            Phone = person.Phone;
            Birthday = person.Birthday;
        }
    }
}
