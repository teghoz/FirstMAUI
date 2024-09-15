using IImage = Microsoft.Maui.IImage;

namespace FirstMaui.Controls.TintMask;
public interface ITintColorMask : IImage
{
    /// <summary>
    /// Tint color of an image.
    /// </summary>
    Color TintColor { get; set; }
}
