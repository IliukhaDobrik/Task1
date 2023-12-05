using System;
using System.Windows;
using Helpers;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ButtonGenerate_OnClick(object sender, RoutedEventArgs e)
        {
            var dates = DataGenerator.DateGenerate(100);
            var enStr = DataGenerator.StrGenerate("en", 10, 100);
            var ruStr = DataGenerator.StrGenerate("ru", 10, 100);
            var ints = DataGenerator.IntGenerate(1, 100_000_000, 100);
            var doubles = DataGenerator.DoubleGenerate(1, 20, 8, 100);

            for (int i = 0; i < 100; i++)
            {
                
                // using (StreamWriter writer = new StreamWriter($"file{i}.txt"))
                // {
                //     
                // }
            }
        }
    }
}