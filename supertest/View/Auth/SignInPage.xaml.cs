using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using supertest.View.Pages;

namespace supertest.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {

        UserControllercs userController = new UserControllercs();

        public SignInPage()
        {
            InitializeComponent();
        }

        private void HLinkRegistrationClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignUpPage());
        }

      

        private void BtEntryClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TBoxUsername.Text) && !String.IsNullOrEmpty(PBoxPassword.Password))
                {
                    var user = userController.SignIn(TBoxUsername.Text.Trim().ToLower(), PBoxPassword.Password.Trim().ToLower());
                    App.currentUser = user;
                    this.NavigationService.Navigate(new HomePage());
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!", "Системная ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Пользователь с текущими данными не найден!", "Системная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
