using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiCarWorkshop.ViewModels;

namespace MauiCarWorkshop.Views;

public partial class SeeInvoicePage : ContentPage
{
    public SeeInvoicePage()
    {
        InitializeComponent();
    }
    
    // vv Chat vv
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is SeeInvoiceViewModel vm)
            await vm.LoadInvoicesCommand.ExecuteAsync(null);
    }
}