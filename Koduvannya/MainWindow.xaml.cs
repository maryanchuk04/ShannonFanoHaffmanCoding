


using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Koduvannya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool isClac = false;
        public string stemp = String.Empty;
        private async void btnCoding_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                
                if (!isClac)
                {
                    decoder.Text = "";
                    stemp = txtInput.Text;
                    String inputText = txtInput.Text;
                    FunctionsClass.LoadFrequency(inputText);

                    List<CodeInformationCellFano> fanoCode = await Task.Factory.StartNew(FanoCoding.Code);

                    List<CodeInformationCell> haffmanCode = await Task.Factory.StartNew(HaffmanCoding.Code);

                    String allInformation = HaffmanCoding.InformationsCode(haffmanCode);

                    String Information = FanoCoding.Informations(fanoCode);

                    result1.Text = FanoCoding.ListToString(fanoCode);
                    result2.Text = HaffmanCoding.ListToString(haffmanCode);
                    string fanocodedstr = String.Empty;

                    foreach (var i in fanoCode)
                    {
                        inputText = inputText.Replace(i.Symbol.ToString(), i.CodeWord);
                    }
                    decoder.Text += inputText;

                    result3.Text = "Fano: \n" + Information + "\n" + "\nHaffman : \n" + allInformation;
                    isClac = true;
                    txtInput.Text = "";
                }               
                else
                {
                    txtInput.Text = "";
                    txtInput.Text = "" + stemp;
                    isClac = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Help: marianchuk.maksym.clg@chnu.edu.ua" + Environment.NewLine + ex.StackTrace, ex.Message);
            }
            
        }

        private void txtInput_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtInput.Text = "";
        }

        

        private void folder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // загрузка
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "txt files (*.txt)|*.txt)";
                if (openFileDialog.ShowDialog() == true)
                {
                    String path = openFileDialog.FileName;
                    String text = String.Empty;
                    using (StreamReader sr = new StreamReader(path, Encoding.Default))
                    {
                        text = sr.ReadToEnd();
                    }
                    txtInput.Text = text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Help: marianchuk.maksym.clg@chnu.edu.ua" + Environment.NewLine + ex.StackTrace, ex.Message);
            }
        }

      
    }
}

