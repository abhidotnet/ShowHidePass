using System.Windows.Input;
using ShowHidePass.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Android.Content.Res;

namespace ShowHidePass.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool HidePassword { get; set; }
        public string EyeIcon
        {
            get
            {
                return HidePassword ? "eye.png" : "eyehidden.png";
            }
            set
            {
                EyeIcon = value;
                OnPropertyChanged(nameof(EyeIcon));
            }
        }
        public ICommand ShowPasswordCommand =>
            new Command(HidePasswordChange);
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            
            HidePassword = true;
            LoginCommand = new Command(OnLoginClicked);
        }

        private void HidePasswordChange()
        {
            HidePassword = !HidePassword;
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new AboutPage()));
        }
    }
}
