using System;

namespace GestioneContatti
{
    public class Persona
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Persona()
        {

        }


        public Persona(int id, string name, string surname, string phone, string email, DateTime data)
        {
            Id = id;
            Name = name;
            SurName = surname;
            Phone = phone;
            Email = email;
            BirthDate = data; 
        }

    }
}
