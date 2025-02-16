using System.Windows;
using System.Windows.Controls;


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
                new PropertyMetadata("#00FF00"));

        private void ButtonPickColor_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new ColorPickerDialog();
            if (colorDialog.ShowDialog() == true)
            {
                SelectedColor = colorDialog.SelectedColor;
            }
        }
        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ColorPicker)d;
            control.TextBoxColor.Text = (string)e.NewValue;
        }

    }
}
