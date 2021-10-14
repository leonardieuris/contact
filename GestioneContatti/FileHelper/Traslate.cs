﻿using GestioneContatti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelper
{
    public class Traslate : ITraslate
    {
        public List<Persona> GetPersone(List<string> rows)
        {
            var persone = new List<Persona>();

            foreach (var item in rows)
            {
                var cells = item.Split(";");
                var persona = new Persona
                {
                    Id = Convert.ToInt32(cells[0]),
                    Email = cells[4],
                    Name = cells[1],
                    Phone = cells[3],
                    BirthDate =Convert.ToDateTime(cells[5]),
                    SurName = cells[2]
                };

                persone.Add(persona);
            }
            return persone;
        }



        public List<string> PutPersona(List<Persona> persone)
        {

            var listaString = new List<String>();

            foreach(var ppp in persone)
            {
                String tutta = $"{ppp.Id};{ppp.Name};{ppp.SurName};{ppp.Phone};{ppp.Email};{ppp.BirthDate}";
                listaString.Add(tutta);
            }

            return listaString;
        }
    }
}
