using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HashApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                // Obține algoritmul selectat
                ComboBoxItem selectedItem = AlgoBox.SelectedItem as ComboBoxItem;
                if (selectedItem == null) return;

                string algo = selectedItem.Content.ToString();

                // Calculează hash-ul asincron
                string hash = await ComputeHashAsync(dialog.FileName, algo);
                ResultBox.Text = hash;
            }
        }

        private Task<string> ComputeHashAsync(string path, string algo)
        {
            return Task.Run(() =>
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    HashAlgorithm hashAlgo = null;

                    // Alegerea algoritmului
                    switch (algo)
                    {
                        case "MD5": hashAlgo = MD5.Create(); break;
                        case "SHA1": hashAlgo = SHA1.Create(); break;
                        case "SHA256": hashAlgo = SHA256.Create(); break;
                        case "SHA384": hashAlgo = SHA384.Create(); break;
                        case "SHA512": hashAlgo = SHA512.Create(); break;
                        case "RIPEMD160": hashAlgo = RIPEMD160.Create(); break;
                        default: hashAlgo = SHA256.Create(); break;
                    }

                    using (hashAlgo)
                    {
                        byte[] hash = hashAlgo.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLower();
                    }
                }
            });
        }
    }
}