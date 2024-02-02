using ProyectoAPP.Modelos;
using System.Net;

namespace ProyectoAPP.Views;

public partial class UpdateDelete : ContentPage
{
	public UpdateDelete(Productos producto)
	{
		InitializeComponent();
        
        //txtCodigo.Text = producto.IdProducto.ToString();
        txtNombre.Text = producto.NameProducto;
        //txtStock.Text = producto.StockProducto.ToString();
        txtPrecio.Text = producto.PrecioProducto.ToString();
        

        lblCodigo.Text = producto.IdProducto.ToString();
        lblNombre.Text = producto.NameProducto;
        lblStock.Text = producto.StockProducto.ToString();
        lblPrecio.Text = "$"+producto.PrecioProducto.ToString();

    }

    

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        
            try
        {
            string codigo = lblCodigo.Text;
            string url = "http://192.168.100.243/moviles/postProducto.php?codigo=" + codigo;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "DELETE", parametros);
            Navigation.PushAsync(new Views.MainPageProducto());
        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }

    private void btnActualizarIngreso_Clicked(object sender, EventArgs e)
    {
        try
        {
            int codigo = int.Parse(lblCodigo.Text);
            string nombre = txtNombre.Text;
            int stockIngreso = int.Parse(txtStock.Text);
            int stockAct = int.Parse(lblStock.Text);
            int stockTotal = stockAct + stockIngreso;
            double precio = double.Parse(txtPrecio.Text);

            string url = "http://192.168.100.243/moviles/postProducto.php?IdProducto=" + codigo + "&NameProducto=" + nombre + "&StockProducto=" + stockTotal + "&PrecioProducto=" + precio;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "PUT", parametros);
            Navigation.PushAsync(new Views.MainPageProducto());

        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }

    private void btnActualizarDespacho_Clicked(object sender, EventArgs e)
    {
        try
        {
            int codigo = int.Parse(lblCodigo.Text);
            string nombre = txtNombre.Text;
            int stockIngreso = int.Parse(txtStock.Text);
            int stockAct = int.Parse(lblStock.Text);
            int stockTotal = stockAct - stockIngreso;
            double precio = double.Parse(txtPrecio.Text);

            string url = "http://192.168.100.243/moviles/postProducto.php?IdProducto=" + codigo + "&NameProducto=" + nombre + "&StockProducto=" + stockTotal + "&PrecioProducto=" + precio;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "PUT", parametros);
            Navigation.PushAsync(new Views.MainPageProducto());

        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }

    }
}