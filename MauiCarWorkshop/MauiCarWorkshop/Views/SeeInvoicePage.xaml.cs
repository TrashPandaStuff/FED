using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiCarWorkshop.ViewModels;

namespace MauiCarWorkshop.Views;

public partial class SeeInvoicePage : ContentPage
{
    public SeeInvoicePage(SeeInvoiceViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}