using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using RJCP.IO.Ports;
using GtkApp;

namespace GtkApp
{
    class MainWindow : Window
    {
        [UI] private Entry _Entrada_Puerto = null ;
        [UI] private Button button_1 = null;
       
        [UI] private Button _Boton_Conecta = null;

        private DialogWindow dialogo = null;
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
            _puertoarduino.Close();
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            
            if(_puertoarduino.IsOpen==true)
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
            else
            {
                if (dialogo != null)
                {
                
                    dialogo.ShowAll();
                }
                else
                {
                    dialogo = new DialogWindow();
                    dialogo.Label_Error.Text=("Puerto "+_puertoarduino.PortName+" no Disponible");
                    dialogo.ShowAll();
                }
                
            }

        }
        private void BotonConecta_Clicked(object sender , EventArgs a)
        {   
          _puertoarduino.BaudRate = 9600;
          try
          {  
          _puertoarduino.PortName = _Entrada_Puerto.Text;
          }catch (System.ArgumentException)
          {
              _puertoarduino.PortName="BUSY";
          }
          catch (System.InvalidOperationException )
            {
               _puertoarduino.Close();
                _puertoarduino.PortName = _Entrada_Puerto.Text;
            }
               
          

         if (_puertoarduino.IsOpen == false)
         {
            try
            { 
                _puertoarduino.Open();
            }catch (System.IO.IOException e)
            {
                Console.WriteLine("Puerto no esta abierto "+ e.Message);
                if(dialogo !=null)
                {
                    dialogo.Label_Error.Text = ("Puerto " + _puertoarduino.PortName + " no Disponible");
                    dialogo.ShowAll();
                }
                else 
                {
                    dialogo = new DialogWindow();
                    dialogo.Label_Error.Text = ("Puerto " + _puertoarduino.PortName + " no Disponible");
                    dialogo.ShowAll();
                }
            
            }
         }

         


         

        }
        private void Entry_Chaged(object sender ,EventArgs a )
        {
            
                    Entry _Entrada_Puerto = (Entry) sender;
                   
               
        }
        public  void PuertoArduino(SerialPortStream __serial) { 
            _puertoarduino = __serial;
            _puertoarduino.PortName = "BUSY";
            }

    }
}
