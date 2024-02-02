using CommunityToolkit.Mvvm.ComponentModel;

using ProyectoAPP.DTOs;
using ProyectoAPP.Modelos;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using CommunityToolkit.Mvvm.Input;
using System.Net;

namespace ProyectoAPP.Views;

public partial class MainPageProducto : ContentPage
{
    private const string Url = "http://192.168.100.243/moviles/postProducto.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Productos> produ;
    
    public MainPageProducto()
	{
		InitializeComponent();
        BindingContext = this;
        Obtener();
    }

    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Productos> mostrarProdu = JsonConvert.DeserializeObject<List<Productos>>(content);
        produ = new ObservableCollection<Productos>(mostrarProdu);
        ListaProductos.ItemsSource = produ;
    }

    [RelayCommand]
    private async Task Eliminar()
    {
        string uri = $"{nameof(Views.AcercaDe)}";
        await Shell.Current.GoToAsync(uri);
        //await Shell.Current.DisplayAlert("Mensaje", "Desea eliminar el producto?", "Si", "No");
    }

    private void ListaProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objetoProducto = (Productos)e.SelectedItem;
        Navigation.PushAsync(new UpdateDelete(objetoProducto));
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarProducto());
    }

    private void btnCamara_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Camara());
    }

    private void btnApi_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ApiMaps());
    }
}