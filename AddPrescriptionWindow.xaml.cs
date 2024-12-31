using System;
using System.Windows;

namespace WpfApp6
{
    public partial class AddPrescriptionWindow : Window
    {
        public Prescription NewPrescription { get; private set; }

        public AddPrescriptionWindow()
        {
            InitializeComponent();
            PrescriptionDatePicker.DisplayDateStart = DateTime.Today; // Disable past dates
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (PrescriptionDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a valid date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(NotesInput.Text))
            {
                MessageBox.Show("Please enter notes.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a new prescription
            NewPrescription = new Prescription
            {
                PrescriptionDate = PrescriptionDatePicker.SelectedDate.Value,
                Notes = NotesInput.Text.Trim()
            };

            DialogResult = true; // Close the window and return success
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Close the window without saving
            Close();
        }

        private void PrescriptionDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Ensure no past date can be manually selected
            if (PrescriptionDatePicker.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("You cannot select a past date.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                PrescriptionDatePicker.SelectedDate = null;
            }
        }
    }

    public class Prescription
    {
        public DateTime PrescriptionDate { get; set; }
        public string Notes { get; set; }
    }
}
