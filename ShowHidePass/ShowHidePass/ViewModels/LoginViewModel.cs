using ShowHidePass.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShowHidePass.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        bool hidePassword;
        public bool HidePassword { 
            get { return hidePassword; }
            set {
                hidePassword = value;
                OnPropertyChanged(nameof(HidePassword));
            } 
        }

        bool showError;
        public bool ShowError
        {
            get { return showError; }
            set
            {
                showError = value;
                OnPropertyChanged(nameof(ShowError));
            }
        }

        string eyeIcon = "eyehidden.png";
        public string EyeIcon
        {
            get
            {
                return eyeIcon;
            }
            set
            {
                eyeIcon = value;
                OnPropertyChanged(nameof(EyeIcon));
            }
        }
        public ICommand ShowPasswordCommand { get; }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            
            HidePassword = true;
            ShowError = false; //IsVisible = false;
            LoginCommand = new Command(OnLoginClicked);

            ShowPasswordCommand = new Command(HidePasswordChange);
        }

        private void HidePasswordChange()
        {
            HidePassword = !HidePassword;
            if (HidePassword)
            {
                EyeIcon = "eyehidden.png";
            }
            else
            {
                EyeIcon = "eye.png";
            }
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if (Password == "opensesame")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new AboutPage()));
            }
            else
            {
                ErrorMessage = "Sorry! You have wrong Password!";
                ShowError = true;
            }
        }
    }
}
