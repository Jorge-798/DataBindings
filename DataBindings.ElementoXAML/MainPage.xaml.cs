namespace DataBindings.ElementoXAML
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            TextLabel.Text = string.Empty;
        }

        
        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            TextLabel.Text = TextEntry.Text;
        }
    }

}
