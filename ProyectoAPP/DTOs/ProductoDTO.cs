using CommunityToolkit.Mvvm.ComponentModel;

namespace ProyectoAPP.DTOs
{
    public partial class ProductoDTO : ObservableObject
    {
        [ObservableProperty]
        public int idProducto;
        [ObservableProperty]
        public string nameProducto;
        [ObservableProperty]
        public string descripcionProducto;
        [ObservableProperty]
        public int stockProducto;
        [ObservableProperty]
        public double precioProducto;
        [ObservableProperty]
        public DateTime fechaContableProduto;
    }
}
