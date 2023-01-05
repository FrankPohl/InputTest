using System;
using System.Globalization;

namespace InputTest;

public partial class MainPage : ContentPage
{

    private void ShowInfo()
    {
        CultureLabel.Text = CultureInfo.CurrentCulture.DisplayName;
        UiCultureLabel.Text = CultureInfo.CurrentUICulture.DisplayName;
        DecimalSeparator.Text = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
        TimeInput.Format = "g";
        TimeInCultureFormat.Text = DateTime.Now.TimeOfDay.ToString("g");
    }

    private void SetCulture(string CultureString)
    {
        CultureInfo ci = new CultureInfo(CultureString);
        CultureInfo.DefaultThreadCurrentCulture = ci;
        CultureInfo.DefaultThreadCurrentUICulture = ci;

    }

    public MainPage()
	{
		InitializeComponent();
        TimeInput.Time = DateTime.Now.TimeOfDay;
        ShowInfo();
    }

    private void OnTimeClicked(object sender, EventArgs e)
	{
        TimeInput.Time = DateTime.Now.TimeOfDay;
        ShowInfo();
    }

    private void OnSetGermanClicked(object sender, EventArgs e)
    {
        SetCulture("de-DE");
        ShowInfo();
    }


    private void OnSetFranceClicked(object sender, EventArgs e)
    {
        SetCulture("fr-FR");
        ShowInfo();
    }

    private void OnSetUsClicked(object sender, EventArgs e)
    {
        SetCulture("en-US");
        ShowInfo();
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        double dbl;
        var isDouble = Double.TryParse(DoubleInput.Text, out dbl);
        if (isDouble)
        {
            IsADouble.Text = $"True with {dbl - Math.Floor(dbl)}";
        }
        else
        {
            IsADouble.Text = $"False";
        }
    }

}

