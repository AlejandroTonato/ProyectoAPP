using System.Net;

namespace ProyectoAPP.Views;

public partial class AgregarEstudiante : ContentPage
{
	public AgregarEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://192.168.100.243/moviles/post.php", "POST", parametros);
            Navigation.PushAsync(new Views.Inicio(""));

        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}