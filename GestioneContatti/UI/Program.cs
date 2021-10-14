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

            /* Console.WriteLine("inserisci il nome da modificare:");
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
             } */

            //NuovoContatto();


            DeleteContatto();
            Rub.Save();
           Console.ReadLine();


        }

        public static void DeleteContatto()
        {
            Console.WriteLine("Inserisci dati contatti da eliminare");
            var dateToLook = Console.ReadLine();
            var listaTrovati = Rub.Cerca(dateToLook);
            if( listaTrovati != null)
            {
                foreach(var tmp in listaTrovati)
                {
                    Console.WriteLine($"{tmp.Name} {tmp.SurName} ID => {tmp.Id}");
                }
                Console.WriteLine("Inserisci l'ID del contatto che si vuole eliminare");
                int idToMod = Convert.ToInt32(Console.ReadLine());
                if (Rub.Delete(idToMod))
                    Console.WriteLine("Eliminazione avvenuta con successo");
                else
                    Console.WriteLine("Errore in eliminazione");
                
            }
        }

        public static void NuovoContatto()
        {
            Console.WriteLine("Inserisci il nome del nuovo contatto: ");
            var nome = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome del nuovo contatto: ");
            var cognome = Console.ReadLine();

            Console.WriteLine("Inserisci il numero del nuovo contatto: ");
            var numero = Console.ReadLine();

            Console.WriteLine("Inserisci l'email del nuovo contatto: ");
            var email = Console.ReadLine();

            Console.WriteLine("Inserisci la data di nascita (gg-mm-aaaa) del nuovo contatto: ");
            DateTime dataNascita = Convert.ToDateTime(Console.ReadLine());

            Persona nuovo = new Persona
            {
                Name= nome,
                SurName = cognome,
                Phone = numero,
                Email = email,
                BirthDate = dataNascita                            
            };

            Rub.Update(nuovo);

        }


    }
}
