﻿namespace FirstMaui.Controls;

public partial class LoadingIndicator : ContentView
{
    public LoadingIndicator()
    {
        InitializeComponent();
    }

    //Bindable Properties

    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
        nameof(IsBusy),
        typeof(bool),
        typeof(LoadingIndicator),
        false,
        BindingMode.OneWay,
        null,
        SetIsBusy);

    public bool IsBusy
    {
        get => (bool)this.GetValue(IsBusyProperty);
        set => this.SetValue(IsBusyProperty, value);
    }

    private static void SetIsBusy(BindableObject bindable, object oldValue, object newValue)
    {
        LoadingIndicator control = bindable as LoadingIndicator;

        control.IsVisible = (bool)newValue;
        control.actIndicator.IsRunning = (bool)newValue;
    }

    public static BindableProperty BackgroundColorProperty =
        BindableProperty.Create(
            nameof(BackgroundColor),
            typeof(Color),
            typeof(LoadingIndicator),
            defaultValue: ResourceHelper.FindResource<Color>("White")
        );

    public Color BackgroundColor
    {
        get { return (Color)GetValue(BackgroundColorProperty); }
        set { SetValue(BackgroundColorProperty, value); }
    }

    public static BindableProperty IndicatorColorProperty =
       BindableProperty.Create(
           nameof(IndicatorColor),
           typeof(Color),
           typeof(LoadingIndicator),
           defaultValue: ResourceHelper.FindResource<Color>("PrimaryColor")
       );

    public Color IndicatorColor
    {
        get { return (Color)GetValue(IndicatorColorProperty); }
        set { SetValue(IndicatorColorProperty, value); }
    }


    public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(
        nameof(LoadingText),
        typeof(string),
        typeof(LoadingIndicator),
        string.Empty,
        BindingMode.OneWay,
        null,
        SetLoadingText);

    public string LoadingText
    {
        get => (string)this.GetValue(LoadingTextProperty);
        set => this.SetValue(LoadingTextProperty, value);
    }

    public static BindableProperty LoadingTextColorProperty =
        BindableProperty.Create(
            nameof(LoadingTextColor),
            typeof(Color),
            typeof(LoadingIndicator),
            defaultValue: Color.FromArgb("#000000")
        );

    public Color LoadingTextColor
    {
        get { return (Color)GetValue(LoadingTextColorProperty); }
        set { SetValue(LoadingTextColorProperty, value); }
    }

    private static void SetLoadingText(BindableObject bindable, object oldValue, object newValue) =>
        (bindable as LoadingIndicator).lblLoadingText.Text = (string)newValue;

}
