using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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


        private async void ButtonGenerate_OnClick(object sender, RoutedEventArgs e)
        {
            const int lineCount = 100_000;

            for (int i = 0; i < 100; i++)
            {
                var dates = await DataGenerator.DateGenerate(lineCount);
                var enStr = await DataGenerator.StrGenerate("en", 10, lineCount);
                var ruStr = await DataGenerator.StrGenerate("ru", 10, lineCount);
                var ints = await DataGenerator.IntGenerate(1, 100_000_000, lineCount);
                var doubles = await DataGenerator.DoubleGenerate(1, 20, 8, lineCount);
                
                using (var writer = new StreamWriter($"files/file{i}.txt"))
                {
                    for (int j = 0; j < lineCount; j++)
                    {
                        await writer.WriteLineAsync($"{dates[j].ToString("dd/MM/yyyy")}||{enStr[j]}||{ruStr[j]}||{ints[j]}||{doubles[j]}");
                    }
                }
            }

            MessageBox.Show("Completed!");
        }

        private async void ButtonCombine_OnClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int filesCount) == false || filesCount > 100 || filesCount < 2)
            {
                MessageBox.Show("Wrong count! Try again!");
                return;
            }

            if (Directory.GetFiles("files").Length == 0)
            {
                MessageBox.Show("You dont have generated files!");
                return;
            }

            var sb = new StringBuilder();
            int countDropLines = 0;
            for (int i = 0; i < filesCount; i++)
            {
                var allLines = await File.ReadAllLinesAsync($"files/file{i}.txt");
                var linesWithoutSubstring = allLines.Where(x => x.Contains(textBox2.Text) == false).ToArray();
                countDropLines += allLines.Length - linesWithoutSubstring.Length;

                foreach (var line in linesWithoutSubstring)
                {
                    sb.Append(line + Environment.NewLine);
                }
            }
            var combineText = sb.ToString();

            var lenght = Directory.GetFiles("filesCombine").Length;
            using (var writer = new StreamWriter($"filesCombine/filesCombine{lenght+1}.txt"))
            {
                await writer.WriteAsync(combineText);
            }

            MessageBox.Show($"Combined! Drop lines count: {countDropLines}");
        }
    }
}