using System.Windows;


namespace TaskDPColorPicker.View
{
    public partial class ColorPickerDialog : Window
    {
        public string SelectedColor { get; private set; }

        public ColorPickerDialog()
        {
            InitializeComponent();
            SelectedColor = "#FFFFFF"; 

        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedColor = TextBoxColor.Text;
            DialogResult = true;
        }

    }
}
