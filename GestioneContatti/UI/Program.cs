using Handler;
using System;

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
          
            //Rub.Save();



            Console.ReadLine();
        }
    }
}
