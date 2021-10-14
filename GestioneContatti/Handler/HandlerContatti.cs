using ContactManager;
using FileHelper;
using GestioneContatti;
using System;
using System.Collections.Generic;

namespace Handler
{
    public class HandlerContatti
    {
        private Manager _manager;
        private readonly string Path;
       
        private readonly Traslate Traslate;
        private readonly MyFile MyFile;
       
        public HandlerContatti(string path)
        {
            Traslate = new Traslate();
            MyFile = new MyFile();
            Path = path;
        }

        public void Save()
        {
            var listaPersone = _manager.GetAll();
            var listaStringhe = Traslate.PutPersona(listaPersone);
            MyFile.Put(Path, listaStringhe);
        }

        public void Load()
        {
           var listaStringhe =  MyFile.GetRows(Path);
           var  _miaRub = Traslate.GetPersone(listaStringhe);
            _manager = new Manager(_miaRub);
        }

        public void Add(string nome, string cognome,
            string telefono, string email, DateTime datanascita)
        {
            var persona = new Persona
            {
                BirthDate = datanascita,
                Email = email,
                Name = nome,
                Phone = telefono,
                SurName = cognome
            };

            _manager.Add(persona);
            
        }

        public List<Persona> Cerca(string str)
        {
           return _manager.Find(str);
        }
    }
}
