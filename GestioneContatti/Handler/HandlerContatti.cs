using ContactManager;
using FileHelper;
using GestioneContatti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var _miaRub = new List<Persona>();
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

        //public void SaveNew()
        //{
        //    var listaPersone = _manager.GetAll();
        //    var listaStringhe = Traslate.PutPersona(listaPersone);
        //    var listaStringhePreesistenti = MyFile.GetRows(Path);
        //    foreach (var item in listaStringhePreesistenti)
        //    {
        //        listaStringhe.Add(item);
        //    }
        //    MyFile.Put(Path, listaStringhe);
        //}

        public void Load()
        {
            var listaStringhe = MyFile.GetRows(Path);
            var _miaRub = Traslate.GetPersone(listaStringhe);
            _manager = new Manager(_miaRub);
        }

        public void Add(string nome, string cognome, string telefono, string email, DateTime datanascita)
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

        public void Add(Persona persona)
        {
            _manager.Add(persona);
        }

        public List<Persona> Cerca(string nome, string cognome)
        {
            return _manager.Find(nome, cognome);
        }
        public List<Persona> Cerca(string str)
        {
            return _manager.Find(str);
        }

        public Persona CercaPersona(Persona persona)
        {
            return _manager.Find(persona);
        }


        public Persona CercaPersona(int id)
        {
            return _manager.Find(id);
        }

        public bool CancellaPersona(Persona persona)
        {
            return _manager.Delete(persona);
        }
        public bool CancellaPersona(int id)
        {
            return _manager.Delete(id);
        }

        public bool Aggiorna(Persona persona)
        {
            return _manager.Update(persona);
        }

        public List<Persona> MostraRubrica ()
        {
            return _manager.GetAll();
        }


    }


}
