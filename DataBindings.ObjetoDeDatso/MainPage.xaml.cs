using DataBindings.ObjetoDeDatso.Models;

namespace DataBindings.ObjetoDeDatso
{
    public partial class MainPage : ContentPage
    {

        private Contador _contador;

        public MainPage()
        {
            InitializeComponent();
            _contador = new Contador();
            ConteoLabel.Text = _contador.Conteo.ToString();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            _contador.Contar();
            ConteoLabel.Text = _contador.Conteo.ToString();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _contador.Reiniciar();
            ConteoLabel.Text = _contador.Conteo.ToString();
        }


    }

}
