using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableAnalyzer.Models
{
    class Column
    {
        public Column(string name,string japaneseName,string dataType,string isNotNull,string defaultValue,string comment)
        {
            this.Name = name;
            this.JapaneseName = japaneseName;
            this.DataType = dataType;
            this.IsNotNull = isNotNull;
            this.DefaultValue = defaultValue;
            this.Comment = comment;
        }

        /// <summary>
        /// PKフラグ
        /// </summary>
        public bool isPK
        {
            get
            {
                return Name == "id";
            }
        }

        /// <summary>
        /// 外部キー(確実ではない)
        /// </summary>
        public bool isForeignKey
        {
            get
            {
                return JapaneseName.EndsWith("ID");
            }
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
        /// データ型
        /// </summary>
        public string DataType { get; private set; }

        /// <summary>
        /// NotNull
        /// </summary>
        public string IsNotNull { get; private set; }

        /// <summary>
        /// デフォルト値
        /// </summary>
        public string DefaultValue { get; private set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string Comment { get; private set; }


        /// <summary>
        /// 外部参照
        /// </summary>
        public Table Relation { get; private set; }

        public override string ToString()
        {
            return $"{JapaneseName}[{Name}]";
        }
    }
}
