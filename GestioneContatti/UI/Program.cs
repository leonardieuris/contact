using GestioneContatti;
using Handler;
using System;
using System.Collections.Generic;

namespace UI
{
    class Program
    {
        private static HandlerContatti Rub;
        static void Main(string[] args)
        {
            Rub = new HandlerContatti(@"C:\DATA\miaRub.csv");
            Rub.Load();
            var personacercata = Rub.Cerca("Gianluca");
            Console.WriteLine("I contatti che rispecchiano la tua ricerca sono:");
            foreach (var item in personacercata)
            {
                Console.WriteLine($"Nome: {item.Name} | Cognome: {item.SurName} | Telefono: {item.Phone}");
            }

            Rub.Add("Paolo", "Bianchi", "0515105050","email@mail.it",new DateTime(1991,6,2)) ;

            Rub.Save(); //Da fixare, così cancella tutto e riscrive solo la riga sopra

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

            //Blocco TEST ADD E FIND
            Rub.Add(persona1);
            Console.WriteLine($"Ho aggiunto una persona: {persona1.Name} {persona1.SurName}");
            Console.Write("Trova per nome e cognome: ");
            scriviLista(Rub.Cerca("Gianluca", "Fontana"));
            Console.Write("Trova solo per nome o per cognome:");
            scriviLista(Rub.Cerca("Gianluca"));
            Console.Write("Trova usando un oggetto:");
            scriviPersona(Rub.CercaPersona(persona1));
            Console.Write("Trova usando un ID:");
            scriviPersona(Rub.CercaPersona(persona1.Id));

            //Blocco TEST DELETE
            Rub.Add(persona2);
            Console.WriteLine($"La cancellazione per ID ha avuto esito? {Rub.CancellaPersona(1)}");
            Rub.Add(persona2);
            Console.WriteLine($"La cancellazione per oggetto ha avuto esito? {Rub.CancellaPersona(persona2)}");
            Console.WriteLine($"La cancellazione per un ID inesistente ha avuto esito? {Rub.CancellaPersona(3)}");

            //Blocco TEST UPDATE
            Console.WriteLine($"Modifico la persona: {persona1.Name} {persona1.SurName}");
            Console.WriteLine($"L'aggiornamento di un contatto ha avuto esito? {Rub.Aggiorna(persona1Updated)}");
            Console.Write($"La persona di prima ora si chiama: ");
            scriviPersona(Rub.CercaPersona(persona1Updated.Id));





            Console.ReadLine();
        }

        public static void scriviLista(List<Persona> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.SurName} {item.Email}");
            }
        }

        public static void scriviPersona(Persona persona)
        {
            Console.WriteLine($"{persona.Id} {persona.Name} {persona.SurName} {persona.Email}");
        }



    }
}
