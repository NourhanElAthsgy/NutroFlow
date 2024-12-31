using System;
using System.Windows;
using WpfApp6;

namespace WpfApp6
{
    public partial class PatientDetailsWindow : Window
    {
        private Patient _patient;

        public PatientDetailsWindow(Patient patient)
        {
            InitializeComponent();
            PatientNameTextBlock.Text = patient.Name;
            PatientAgeTextBlock.Text = patient.Age.ToString();
            PatientGenderTextBlock.Text = patient.Gender;
            PatientIDTextBlock.Text = patient.IDs;
            PatientPhoneNumberTextBlock.Text = patient.Phone_Number;
            PatientDetailsTextBlock.Text = patient.Details;
            _patient = patient;
            DataContext = _patient; // Bind the patient object to the window's DataContext
        }
        private void PrescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the PrescriptionWindow for the current patient
            PrescriptionWindow prescriptionWindow = new PrescriptionWindow();
            prescriptionWindow.ShowDialog();
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(WeightInput.Text) || string.IsNullOrWhiteSpace(HeightInput.Text))
            {
                MessageBox.Show("Please fill in all required fields (Weight, Height).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Try parsing weight and height as numbers
            if (!double.TryParse(WeightInput.Text, out double weight) || !double.TryParse(HeightInput.Text, out double height))
            {
                MessageBox.Show("Please enter valid numbers for Weight and Height.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Save validated data
            _patient.Weight = weight;
            _patient.Height = height;

            // Optionally calculate BMI
            _patient.BMI = weight / Math.Pow(height / 100, 2);

            MessageBox.Show("Patient details saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
