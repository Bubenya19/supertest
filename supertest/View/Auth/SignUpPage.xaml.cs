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
using supertest.modelx;

namespace supertest.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        GenderController genderController = new GenderController();
        UserControllercs userControllercs = new UserControllercs();
        private int _gender = 0;
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void BtRegisterClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TBoxFirstName.Text) && !String.IsNullOrEmpty(TBoxLastName.Text) && !String.IsNullOrEmpty(TBoxPatronymic.Text) && !String.IsNullOrEmpty(DPickerDateBirth.Text) && !String.IsNullOrEmpty(TBoxUsername.Text) && _gender > 0)
                {
                    var user = userControllercs.CreateNewUser(TBoxFirstName.Text, TBoxLastName.Text, TBoxPatronymic.Text, DPickerDateBirth.SelectedDate.Value, TBoxUsername.Text, PBoxPassword.Password, _gender);
                    App.currentUser = user;
                    this.NavigationService.Navigate(new HomePage());
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}", "Системная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            var allGender = genderController.GetGenders();
            allGender.Insert(0, new modelx.Genders 
            { 
               GenderName =  "Выбор гендера"

            });
            
            CBoxGender.SelectedIndex = 0;
            
            CBoxGender.DisplayMemberPath = "GenderName";
            CBoxGender.SelectedValuePath = "IdGender";

            CBoxGender.ItemsSource = allGender;
            DPickerDateBirth.DisplayDateEnd = DateTime.Now.AddYears(-14);
        }

       

        private void CBoxGenderSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Genders gender = CBoxGender.SelectedItem as Genders;
            _gender = gender.GenderID; 
        }
    }
}
