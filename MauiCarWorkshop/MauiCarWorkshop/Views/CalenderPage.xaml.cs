
using MauiCarWorkshop.ViewModels;
namespace MauiCarWorkshop.Views;

public partial class CalenderPage : ContentPage
{ 
    public CalenderPage(CalenderViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}