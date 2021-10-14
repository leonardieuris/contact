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
            var personacercata = Rub.Cerca("g");
            Console.WriteLine("I contatti che rispecchiano la tua ricerca sono: ");
            foreach (var item in personacercata)
            {
                Console.WriteLine($"Nome: {item.Name} | Cognome: {item.SurName} | Telefono: {item.Phone}");
            }

            Rub.Add("Paolo", "Martedì", "08055145", "bianchi@tin.com", new DateTime(1984, 03, 01));

            Console.ReadLine();

            Rub.Save();
        }


    }
}
