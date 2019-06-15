using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace GtkApp
{
    public class DialogWindow : Dialog
    {
        [UI] private Label _label_Error = null;
        [UI] private Button _Boton_Error = null;

        public Label Label_Error { get => _label_Error; set => _label_Error = value; }

        public DialogWindow() : this(new Builder("MainWindow.glade")) { }

        private DialogWindow(Builder builder) : base(builder.GetObject("Dialog_Puerto_Error").Handle)
        {
            builder.Autoconnect(this);
            _Boton_Error.Clicked += _BotonClickedError;
            
        }
        private void _BotonClickedError(object sender , EventArgs e)
        {
            this.HideOnDelete();
        }
       
    }
}