using System.Net;

namespace ProyectoAPP.Views;

public partial class AgregarProducto : ContentPage
{
	public AgregarProducto()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("IdProducto", txtIdProducto.Text);
            parametros.Add("NameProducto", txtNombre.Text);
            parametros.Add("StockProducto", txtStock.Text);
            parametros.Add("PrecioProducto", txtPrecio.Text);
            cliente.UploadValues("http://192.168.100.243/moviles/postProducto.php", "POST", parametros);
            Navigation.PushAsync(new Views.MainPageProducto());

        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }
}