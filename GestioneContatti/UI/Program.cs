using GestioneContatti;
using Handler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UI
{
    class Program
    {
        private static HandlerContatti Rub;
        static void Main(string[] args)
        {
            Rub = new HandlerContatti(@"C:\DATA\miaRub.csv");
            Rub.Load();
            /*var personacercata = Rub.Cerca("g");
            Console.WriteLine("I contatti che rispecchiano la tua ricerca sono: ");
            foreach (var item in personacercata)
            {
                Console.WriteLine($"Nome: {item.Name} | Cognome: {item.SurName} | Telefono: {item.Phone}");
            }
            
            Rub.Add("Paolo", "Martedì", "08055145", "bianchi@tin.com", new DateTime(1984, 03, 01));
            
            Console.WriteLine("Inserisci un Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci un Cognome: ");
            string cognome = Console.ReadLine();

            List<Persona> miaLista = Rub.CercaDaNomeCognome(nome, cognome);

            foreach(var tmp in miaLista)
            {
        
                Console.WriteLine($"Ho trovato: {tmp.Name} {tmp.SurName}");
            }
            */

            Console.WriteLine("inserisci il nome da modificare:");
            string trova = Console.ReadLine(); 

            List<Persona> trovate = Rub.Cerca(trova);



            if (trovate != null)
            {
                Console.WriteLine("questi sono i risultati trovati");

                foreach (var tmp in trovate)
                {
                    Console.WriteLine($"{tmp.Id} {tmp.Name} {tmp.SurName}");
                }

                Console.WriteLine("inserisci la persona da modificare : ");
                int questoID = Convert.ToInt32(Console.ReadLine());
                

                var change = trovate.Where(x => x.Id.Equals(questoID)).Single();
                Console.WriteLine("inserire nuovo nome: ");
                string nuovoNome = Console.ReadLine();

                change.Name = nuovoNome;

                Rub.Update(change);

                change = Rub.Cerca(change.Id);

                Console.WriteLine($"{change.Id} {change.Name} {change.SurName}");
            }
            




            Rub.Save();
            Console.ReadLine();
        }


    }
}
