using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerForm
{
    class GetDataBaseDirectory
    {
        public static string Get()
        {
            string current = Directory.GetCurrentDirectory();
            DirectoryInfo df = new DirectoryInfo(current);
            while (df != null)
            {
                foreach (var dir in df.GetDirectories())
                {
                    if (dir.Name == "DataBase")
                    {
                        foreach (var file in dir.GetFiles())
                        {
                            if (file.Name == "ChatDB.mdf")
                                return file.FullName;
                        }
                    }
                }
                df = df.Parent;
            }
            
            return null;
        }
    }
}
