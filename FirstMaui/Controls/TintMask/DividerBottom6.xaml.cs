namespace FirstMaui.Controls.TintMask;

public partial class DividerBottom6 : Grid
{
    public static BindableProperty MaskColorProperty =
            BindableProperty.Create(
                nameof(MaskColor),
                typeof(Color),
                typeof(DividerBottom6),
                defaultValue: Color.FromArgb("#00FFFFFF"),
                propertyChanged: OnMaskColorChanged
            );

    public Color MaskColor
    {
        get { return (Color)GetValue(MaskColorProperty); }
        set { SetValue(MaskColorProperty, value); }
    }

    public DividerBottom6()
    {
        InitializeComponent();
    }

    private static void OnMaskColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((DividerBottom6)bindable).Update();
    }

    private void Update()
    {
        if(root.Children != null)
        {
            root.Children.Clear();
        }

        if (MaskColor != Color.FromArgb("#00FFFFFF"))
        {
            var image = new TintColorMask
            {
                Style = Resources["MaskImageStyle"] as Style
            };
            root.Children.Add(image);
        }
    }
}