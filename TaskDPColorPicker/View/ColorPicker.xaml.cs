using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace TaskDPColorPicker.View
{
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        public string SelectedColor
        {
            get { return (string)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register(
                nameof(SelectedColor),
                typeof(string),
                typeof(ColorPicker),
                new PropertyMetadata("#00FF00", OnSelectedColorChanged));

        private void ButtonPickColor_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new ColorPickerDialog();
            if (colorDialog.ShowDialog() == true)
            {
                SelectedColor = 
                    $"#{colorDialog.SelectedColor.R:X2}" +
                    $"{colorDialog.SelectedColor.G:X2}" +
                    $"{colorDialog.SelectedColor.B:X2}";
            }
        }
        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ColorPicker)d;

            // Меняем цвет фона TextBox на выбранный цвет
            try
            {
                var color = (Color)ColorConverter.ConvertFromString((string)e.NewValue);
                control.TextBoxColor.Background = new SolidColorBrush(color);
            }
            catch
            {
                // Если цвет некорректен, оставляем фон по умолчанию
                control.TextBoxColor.Background = Brushes.White;
            }
        }

    }
}
