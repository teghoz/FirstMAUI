using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;

namespace FirstMaui.Pages;

public partial class OldMainPage : ContentPage
{
    int count = 0;
    public OldMainPage()
    {
        InitializeComponent();
    }
    
    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}