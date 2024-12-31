using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Tesseract;
using WpfApp6;

namespace WpfApp6
{
    public partial class AddPatiens : Window
    {
        public Patient NewPatient { get; private set; } // Store the new patient

        public AddPatiens()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = PatientNameTextBox.Text;
            string ageText = AgeTextBox.Text;
            string details = DetailsTextBox.Text;
            string gender = (GenderComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            string ID = IDTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
                



            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ageText) || !int.TryParse(ageText, out int age))
            {
                MessageBox.Show("Please enter valid data.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a new Patient object
            

            NewPatient = new Patient(name, age, details,ID ,gender, phoneNumber)
            {
                Name = name,
                Age = age,
                Details = details,
                Gender = gender, 
                IDs = ID,
                Phone_Number = phoneNumber


        };

            this.DialogResult = true; // Indicate successful data entry
            this.Close();
        }
        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; // Indicate cancellation
            this.Close();
        }
    }
}

                
                
