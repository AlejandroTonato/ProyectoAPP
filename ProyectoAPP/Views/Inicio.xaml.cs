using Newtonsoft.Json;
using ProyectoAPP.Modelos;
using System.Collections.ObjectModel;

namespace ProyectoAPP.Views;

public partial class Inicio : ContentPage
{
    private const string Url = "http://192.168.100.243/moviles/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiantes> estud;

    public Inicio(string usuario)
	{
		InitializeComponent();
        lblUsuario.Text = "Usuario Conectado: " + usuario;
        Obtener();
    }


    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Estudiantes> mostrarEstu = JsonConvert.DeserializeObject<List<Estudiantes>>(content);
        estud = new ObservableCollection<Estudiantes>(mostrarEstu);
        ListaEstudiantes.ItemsSource = estud;
    }

    private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objetoEstudiante = (Estudiantes)e.SelectedItem;
        Navigation.PushAsync(new ActualizarEliminar(objetoEstudiante));
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarEstudiante());
    }
}