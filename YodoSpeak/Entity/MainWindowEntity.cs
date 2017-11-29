using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YodoSpeak.Entity
{
    public class MainWindowEntity: INotifyPropertyChanged
    {
        private string output;
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowEntity()
        {
        }

        public MainWindowEntity(string value)
        {
            this.output = value;
        }

        public string OutputValue
        {
            get { return output; }
            set
            {
                output = value;                
                OnPropertyChanged("outputString");
            }
        }       
        protected void OnPropertyChanged(string output)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(output));
            }
        }

    }
}
