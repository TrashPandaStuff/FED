using MauiCarWorkshop.ViewModels;

namespace MauiCarWorkshop;

public partial class CreateInvoicePage : ContentPage
{
    public CreateInvoicePage(CreateInvoiceViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}