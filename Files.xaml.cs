using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Tesseract;

namespace WpfApp6
{
    public partial class Files : UserControl
    {
        private List<string> savedTexts = new List<string>();

        public Files()
        {
            InitializeComponent();
        }

        private void ScanButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                // Display the selected image
                ImageDisplay.Source = new BitmapImage(new Uri(filePath));

                try
                {
                    // Perform OCR
                    string ocrResult = PerformOCR(filePath);
                    OCRTextBox.Text = ocrResult;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during OCR: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string PerformOCR(string imagePath)
        {
            // Path to tessdata folder containing trained data
            string tessDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");

            using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        return page.GetText();
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string textToSave = OCRTextBox.Text.Trim();

            if (string.IsNullOrEmpty(textToSave))
            {
                MessageBox.Show("No text to save. Please perform OCR first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Save the text and add to the list
            savedTexts.Add(textToSave);
            SavedTextsList.Items.Add(textToSave);

            // Clear the TextBox
            OCRTextBox.Clear();

            MessageBox.Show("Text saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
