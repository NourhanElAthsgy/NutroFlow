using System.Collections.Generic;
using System.Windows;
using WpfApp6;

namespace WpfApp6
{
    public partial class PrescriptionWindow : Window
    {
        private List<Prescription> _prescriptions;

        public PrescriptionWindow()
        {
            InitializeComponent();
            _prescriptions = new List<Prescription>();
            PrescriptionList.ItemsSource = _prescriptions; // Bind the list to the ListView
        }

        private void AddPrescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Add Prescription Modal
            AddPrescriptionWindow addPrescriptionWindow = new AddPrescriptionWindow();
            if (addPrescriptionWindow.ShowDialog() == true)
            {
                // Get the new prescription from the modal
                Prescription newPrescription = addPrescriptionWindow.NewPrescription;
                _prescriptions.Add(newPrescription); // Add to the list
                PrescriptionList.Items.Refresh(); // Refresh the ListView
            }
        }
    }
}
