using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableAnalyzer.Models
{
    class Column
    {
        /// <summary>
        /// 英語名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 日本語名
        /// </summary>
        public string JapaneseName { get; private set; }

        /// <summary>
        /// 外部参照
        /// </summary>
        public Table Relation { get; private set; }
    }
}
