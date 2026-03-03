using MauiCarWorkshop.ViewModels;

namespace MauiCarWorkshop;

public partial class CreateOrderPage : ContentPage
{
    public CreateOrderPage(CreateOrderViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}