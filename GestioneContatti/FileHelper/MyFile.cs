using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHelper
{
    public class MyFile : IMyfile
    {
        public List<string> GetRows(string path) => ReadFile(path);

        private List<string> ReadFile(string path)
        {
            using var stream = new StreamReader(path);
            stream.ReadLine();
            List<string> myList = new List<string>();
            while (!stream.EndOfStream)
            {
                var myRow = stream.ReadLine();

                myList.Add(myRow);

            }

            return myList;
        }

        
        public bool Put(string path, List<string> content)
        {

            try
            {
                using var stream = new StreamWriter(path);


                var header = "Id;Name;SurName;Phone;Email;BirthDate";

                stream.WriteLine(header);

                foreach (var item in content)
                    stream.WriteLine(item);

                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
    }
}
