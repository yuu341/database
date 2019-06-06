using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableAnalyzer.Utilities
{
    class FileLoader
    {
        public FileLoader()
        {

        }

        public void Load(string path)
        {
            FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IWorkbook book = WorkbookFactory.Create(inputStream);

            var sheet = book.GetSheet("list");
        }
    }
}
