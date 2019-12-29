using System.Windows;
using System.Windows.Controls;

namespace FNZ.Bomb
{
    public class Extensions
    {
        public static CornerRadius GetCornerRadius(DependencyObject obj) => (CornerRadius)obj.GetValue(CornerRadiusProperty);

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value) => obj.SetValue(CornerRadiusProperty, value);

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached(nameof(Border.CornerRadius), typeof(CornerRadius),
                typeof(Extensions), new UIPropertyMetadata(new CornerRadius()));

    }
}
