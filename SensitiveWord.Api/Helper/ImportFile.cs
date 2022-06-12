using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveWord.Api.Helper
{
    public class ImportFile
    {
        public static string[] ReadFile()
        {
            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream(@"C:\Repo\SensitiveWord.Api\SensitiveWord.Api\Files\sql_sensitive_list.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();
            return lines;
        }
    }
}
