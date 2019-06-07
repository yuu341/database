using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableAnalyzer.Models
{
    class Table
    {

        public Table(string name, string japaneseName)
        {
            this.Name = name;
            this.JapaneseName = japaneseName;
        }

        /// <summary>
        /// 英語名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 日本語名
        /// </summary>
        public string JapaneseName { get; private set; }

        /// <summary>
        /// 列名
        /// </summary>
        public IList<Column> Columns { get; private set; } = new List<Column>();

        public override string ToString()
        {
            return $"{JapaneseName}[{Name}]";
        }
    }
}
