using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAnalyzer.Models;

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

            loadTableList(book);

            foreach(var table in Tables){
                loadTableSheet(book, table);
            }
        }

        private void loadTableList(IWorkbook book)
        {
            var sheet = book.GetSheet("テーブル一覧");

            int i = 4;
            var row = sheet.GetRow(i++);

            while (true)
            {
                if (row == null)
                    break;
                var japaneseName = row.GetCell(2).StringCellValue;
                var name = row.GetCell(3).StringCellValue;

                if (string.IsNullOrEmpty(name))
                    break;
                Tables.Add(new Table(name, japaneseName));
                row = sheet.GetRow(i++);
            }
        }

        private void loadTableSheet(IWorkbook book,Table table)
        {
            var sheet = book.GetSheet(table.JapaneseName);
            if(sheet == null)
            {
                return;
            }

            for(int i=14; ; i++)
            {
                var row = sheet.GetRow(i);
                if (row == null)
                    break;

                var japaneseName = row.GetCell(1).StringCellValue;
                var name = row.GetCell(2).StringCellValue;
                var dataType = row.GetCell(3).StringCellValue;
                var isNotNull = row.GetCell(4).StringCellValue;
                var defaultValue = row.GetCell(5).StringCellValue;
                var comment = row.GetCell(6).StringCellValue;

                if (string.IsNullOrEmpty(japaneseName))
                    break;

                table.Columns.Add(new Column(name,japaneseName,dataType,isNotNull,defaultValue, comment));

            }

        }
        IList<Table> Tables { get; } = new List<Table>();
    }
}
