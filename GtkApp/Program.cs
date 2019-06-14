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
            SerialPortStream __pSerie = new SerialPortStream();
           /*  __pSerie.PortName ="COM3 ";
            __pSerie.BaudRate = 9600;
            __pSerie.Open();*/
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
