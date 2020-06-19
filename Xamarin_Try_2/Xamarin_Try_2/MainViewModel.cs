using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin_Try_2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LeftPlus { get; }
        public ICommand LeftMinus { get; }
        public ICommand RightPlus { get; }
        public ICommand RightMinus { get; }
        public ICommand AllReset { get; }

        public int LeftPoint { get; set; } = 0;
        public int RightPoint { get; set; } = 0;
        public MainViewModel()
        {
            LeftPlus = new Command(LeftIncrease);
            LeftMinus = new Command(LeftDecrease);
            RightPlus = new Command(RightIncrease);
            RightMinus = new Command(RightDecrease);
            AllReset = new Command(Reset);
        }
        void LeftIncrease()
        {
            LeftPoint++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LeftPoint)));
        }
        void LeftDecrease()
        {
            LeftPoint--;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LeftPoint)));

        }
        void RightIncrease()
        {
            RightPoint++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RightPoint)));

        }
        void RightDecrease()
        {

            RightPoint--;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RightPoint)));
        }
        async void Reset()
        {
            var check = await Application.Current.MainPage.DisplayAlert("確認", "リセットしてもよろしいですか？", "はい", "キャンセル");
            if (check)
            {
                LeftPoint = 0;
                RightPoint = 0;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LeftPoint)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RightPoint)));

            }
            else
            {

            }
        }
    }
}
