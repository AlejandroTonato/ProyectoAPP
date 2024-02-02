namespace ProyectoAPP.Views;

public partial class Camara : ContentPage
{
	public Camara()
	{
		InitializeComponent();
	}

    private async void btnCapturar_Clicked(object sender, EventArgs e)
    {
        var foto = await MediaPicker.CapturePhotoAsync();

        if (foto != null)
        {
            var memoriaStream = await foto.OpenReadAsync();
            imgFoto.Source = ImageSource.FromStream(() => memoriaStream);
        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {        

        var foto = await MediaPicker.PickPhotoAsync();

        if (foto != null)
        {
            var memoriaStream = await foto.OpenReadAsync();
            imgFoto.Source = ImageSource.FromStream(() => memoriaStream);
        }
    }
}