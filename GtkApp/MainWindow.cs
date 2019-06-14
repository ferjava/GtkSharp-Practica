using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using RJCP.IO.Ports;
namespace GtkApp
{
    class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;
        private SerialPortStream _puertoarduino = null;

        private Boolean pulsado = false ;
        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _button1.Clicked += Button1_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            _counter++;
            _label1.Text = "Hello World! This button has been clicked " + _counter + " time(s).";
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
        public  void PuertoArduino(SerialPortStream __serial) { _puertoarduino = __serial;}
    }
}
