namespace FirstMaui.Controls;

public partial class BrandingPortrait : ContentView
{
	public BrandingPortrait()
	{
		InitializeComponent();
    }

    public static BindableProperty LayoutPositionProperty =
       BindableProperty.Create(
           nameof(LayoutPosition),
           typeof(LayoutOptions),
           typeof(BrandingPortrait),
           defaultValue: LayoutOptions.Start
       );

    public LayoutOptions LayoutPosition
    {
        get { return (LayoutOptions)GetValue(LayoutPositionProperty); }
        set { SetValue(LayoutPositionProperty, value); }
    }
}