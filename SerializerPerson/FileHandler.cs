using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SerializerPerson
{
    class FileHandler
    {


        public static string[] ListFromDirectory(string path)
        {
            string[] fileArray = Directory.GetFiles(path, "*.dat");
            return fileArray;
        }
    }
}
