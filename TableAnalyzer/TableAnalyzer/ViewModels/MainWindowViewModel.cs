using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAnalyzer.Utilities;

namespace TableAnalyzer.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Analyze.Subscribe(analyze);
            InputFile.Value = @"C:\crud\テーブル設計書.xlsm";
            OutputFile.Value = @"C:\crud\output.xlsx";
            loader = new FileLoader();
        }

        private FileLoader loader;

        private void analyze()
        {
            loader.Load(InputFile.Value);
        }

        /// <summary>
        /// Excelを指定
        /// </summary>
        public ReactiveProperty<string> InputFile { get; } = new ReactiveProperty<string>();

        /// <summary>
        /// 出力場所
        /// </summary>
        public ReactiveProperty<string> OutputFile { get; } = new ReactiveProperty<string>();

        public ReactiveCommand Analyze { get; } = new ReactiveCommand();


        #region

        /// <summary>
        /// 基本的にReactivePropertyだけで行けるのだが、C#の使用上メモリリーク対策として必要
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string parameter)
         => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));


        #endregion
    }
}
