using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDPColorPicker.Commands;

namespace TaskDPColorPicker.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            ChangedButtonColor = new RelayCommand(ChangeColor, CanChangeColor);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #region Property
        private string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }

        #endregion


        #region Commands
        public RelayCommand ChangedButtonColor { get; set; }
        private bool CanChangeColor(object arg)
        {
            return !string.IsNullOrEmpty(Text);
        }

        private void ChangeColor(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
