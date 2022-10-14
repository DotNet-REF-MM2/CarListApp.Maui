using CarListApp.Maui.ViewModels;

namespace CarListApp.Maui;

public partial class CarDetailsPage : ContentPage
{
    private readonly CarDetailsViewModel _carDetailsViewModel;
    public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = carDetailsViewModel;
        _carDetailsViewModel = carDetailsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _carDetailsViewModel.GetCarData();
    }
}