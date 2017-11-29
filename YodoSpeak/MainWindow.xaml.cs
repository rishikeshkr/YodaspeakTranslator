using System;
using System.Collections.Generic;
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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using YodoSpeak.Model;
using YodoSpeak.Entity;
using API.YodaSpeak;


namespace YodoSpeak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TranslateViewModel tranVmodel;// = new TranslateViewModel();
        //public string txtInput { get; set; }
        MainWindowEntity ent = new MainWindowEntity();
        public MainWindow()
        {
            InitializeComponent();
            TranslateViewModel Vmodel=new TranslateViewModel ();
            this.tranVmodel = Vmodel;
            this.DataContext = this.tranVmodel;
            txtOutput.IsEnabled = false;
            lblInstruction.Visibility = Visibility.Hidden;
        }

        private void TranslateInYodo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(tranVmodel.inputString.ToString()))
                {
                    btnTranslate.Content = "wait";
                    var result = YodaTranslator.YodaSpeak(tranVmodel.inputString.ToString()); 
                    if (result!="")
                    {
                        tranVmodel.outputString = result;
                        ent.OutputValue = result;
                        txtOutput.Text = tranVmodel.outputString;                        
                        txtOutput.IsEnabled = true;                        
                        btnTranslate.Content = "Translate";
                    }
                    else
                    {
                        btnTranslate.Content = "Translate";
                        MessageBox.Show("API(https://market.mashape.com/ismaelc/yoda-speak) is not responding."+"\n"+"Change key value of MarketMashpeKey in App.config file");
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        public void ClearFields()
        {
            tranVmodel.outputString = "";
            txtOutput.Text = "";
            tranVmodel.inputString = "";
            TB.Text = "";
            txtOutput.IsEnabled = false;
        }
    }
}
