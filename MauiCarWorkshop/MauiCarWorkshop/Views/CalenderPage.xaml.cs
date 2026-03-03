using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MauiCarWorkshop.ViewModels;
namespace MauiCarWorkshop.Views;

public partial class CalenderPage : ContentPage
{
    private CancellationTokenSource _cts;
    public CalenderPage(CalenderViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CalenderViewModel viewModel)
        {
            _ = SafeLoadOrders(viewModel);
        }
    }

    private async Task SafeLoadOrders(CalenderViewModel viewModel)
    {
        try
        {
            await viewModel.LoadOrdersAsync();
        }
        catch (Exception ex)
        {
        }
    }
}