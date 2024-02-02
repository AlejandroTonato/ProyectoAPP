namespace ProyectoAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.Login());
            //MainPage = new NavigationPage(new Views.MainPageProducto());
        }
    }
}
