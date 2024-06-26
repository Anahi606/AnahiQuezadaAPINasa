using AnahiQuezadaAPINasa.ViewModels;

namespace AnahiQuezadaAPINasa.Views;

public partial class AQApodPage : ContentPage
{
	public AQApodPage()
    {
		InitializeComponent();
        BindingContext = new AQApodViewModel();

    }
}