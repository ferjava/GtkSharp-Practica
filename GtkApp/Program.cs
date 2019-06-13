using System;
//using System.IO.Ports;
using Gtk;
using RJCP.IO.Ports;
namespace GtkApp
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            SerialPortStream __pSerie = new SerialPortStream("/dev/ttyACM0", 9600, 8, Parity.None, StopBits.One);
            //__pSerie.PortName ="/dev/ttyACM0";
            //__pSerie.BaudRate = 9600;
            __pSerie.Open();
            Application.Init();

            var app = new Application("org.GtkApp.GtkApp", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            win.PuertoArduino(__pSerie);
            app.AddWindow(win);

            win.Show();
            Application.Run();
        }
    }
}
