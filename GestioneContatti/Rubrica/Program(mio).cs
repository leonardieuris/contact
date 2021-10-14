using ContactManager;
using FileHelper;
using GestioneContatti;
using System;
using System.Collections.Generic;

namespace Rubrica
{
    class Program
    {
        static void Main(string[] args)
        {

            Persona persona1 = new Persona
            {
                Id = Convert.ToInt32(0),
                Email = "gigigigigig@gmail.com",
                Name = "Gianluca",
                SurName = "Fontana",
                Phone = "333 33 33 333",
                BirthDate = new DateTime(1991, 6, 2),
            };

            Persona persona2 = new Persona
            {
                Id = Convert.ToInt32(1),
                Email = "fifififi@gmail.com",
                Name = "Carmelita",
                SurName = "Rodriguez Pizarro Navidad",
                Phone = "360 60 60 606",
                BirthDate = new DateTime(1992, 2, 6),
            };

            Persona persona1Updated = new Persona
            {
                Id = Convert.ToInt32(0),
                Email = "gigigigigig@gmail.com",
                Name = "Gianluca Ban",
                SurName = "Fontana Meliodas",
                Phone = "333 33 33 333",
                BirthDate = new DateTime(1991, 6, 2),
            };



            List<Persona> elencoContatti = new List<Persona>();

            Manager rubrica = new Manager(elencoContatti);

            //Blocco TEST ADD E FIND
            rubrica.Add(persona1);
            Console.WriteLine($"Ho aggiunto una persona: {persona1.Name} {persona1.SurName}");
            Console.Write("Trova per nome e cognome: ");
            scriviLista(rubrica.Find("Gianluca", "Fontana"));
            Console.Write("Trova solo per nome o per cognome:");
            scriviLista(rubrica.Find("Gianluca"));
            Console.Write("Trova usando un oggetto:");
            scriviPersona(rubrica.Find(persona1));
            Console.Write("Trova usando un ID:");
            scriviPersona(rubrica.Find(persona1.Id));

            //Blocco TEST DELETE
            rubrica.Add(persona2);
            Console.WriteLine($"La cancellazione per ID ha avuto esito? {rubrica.Delete(1)}");
            rubrica.Add(persona2);
            Console.WriteLine($"La cancellazione per oggetto ha avuto esito? {rubrica.Delete(persona2)}");
            Console.WriteLine($"La cancellazione per un ID inesistente ha avuto esito? {rubrica.Delete(3)}");

            //Blocco TEST UPDATE
            Console.WriteLine($"Modifico la persona: {persona1.Name} {persona1.SurName}");
            Console.WriteLine($"L'aggiornamento di un contatto ha avuto esito? {rubrica.Update(persona1Updated)}");
            Console.Write($"La persona di prima ora si chiama: ");
            scriviPersona(rubrica.Find(persona1Updated.Id));







            MyFile fileCSV = new MyFile();
            


        }

        public static void scriviLista (List<Persona> lista){
            foreach (var item in lista)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.SurName} {item.Email}");
            }
        }

        public static void scriviPersona (Persona persona)
        {
            Console.WriteLine($"{persona.Id} {persona.Name} {persona.SurName} {persona.Email}");
        }

}
}
