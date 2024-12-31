using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp6
{
    public partial class Patients : UserControl
    {
        public ObservableCollection<Patient> Patientss { get; set; }

        public Patients()
        {
            InitializeComponent();

            // Initialize the patient list
            Patientss = new ObservableCollection<Patient>();
            PatientListView.ItemsSource = Patientss; // Bind the ListView to the patient list
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            AddPatiens addPatientWindow = new AddPatiens();
            if (addPatientWindow.ShowDialog() == true) // Show Add Patient Window
            {
                // Add new patient to the list
                if (addPatientWindow.NewPatient != null)
                {
                    Patientss.Add(addPatientWindow.NewPatient);
                }
            }
        }
        private void ViewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the patient bound to the clicked button
            if (sender is Button button && button.Tag is Patient patient)
            {
                // Open the PatientDetailsWindow with the selected patient's details
                PatientDetailsWindow detailsWindow = new PatientDetailsWindow(patient);
                detailsWindow.ShowDialog();
            }
        }

    }

    // Patient class to hold patient information
    public class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Details { get; set; }
        public string IDs { get; set; }
        public string Gender {  get; set; } 
        public string Phone_Number {  get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? BMI { get; set; } // Optionally calculated from Weight and Height
        public string AdditionalNotes { get; set; }

        public Patient(string name, int age, string details, string iD, string gender, string phoneNumber)
        {
            Name = name;
            Age = age;
            Details = details;
            IDs = iD;
            Gender = gender;
            Phone_Number = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}";
        }
    }

}
