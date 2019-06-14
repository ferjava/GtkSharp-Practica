using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using RJCP.IO.Ports;
namespace GtkApp
{
    class MainWindow : Window
    {
        [UI] private Entry _Entrada_Puerto = null ;
        [UI] private Button button_1 = null;
       
        [UI] private Button _Boton_Conecta = null;
        private SerialPortStream _puertoarduino = null;

        private Boolean pulsado = false ;
       

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            button_1.Clicked += Button1_Clicked;
            _Boton_Conecta.Clicked += BotonConecta_Clicked;
            _Entrada_Puerto.Changed += Entry_Chaged;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            
            if(pulsado == false )
            {
            _puertoarduino.Write("H");
            pulsado = true;
            }
            else
            {
                _puertoarduino.Write("L");
                pulsado = false;
            }

        }
        private void BotonConecta_Clicked(object sender , EventArgs a)
        {   
          _puertoarduino.BaudRate = 9600;     
          _puertoarduino.Open();
         

        }
        private void Entry_Chaged(object sender ,EventArgs a )
        {
            Entry _Entrada_Puerto = (Entry) sender;
            _puertoarduino.PortName = _Entrada_Puerto.Text;
        }
        public  void PuertoArduino(SerialPortStream __serial) { _puertoarduino = __serial;}
    }
}
