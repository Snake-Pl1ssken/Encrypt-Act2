using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.IO;
using System.Security.Cryptography;

namespace CifradoSimetrico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer player;

        public MainWindow()
        {
            InitializeComponent();

            MemoryStream music = new MemoryStream(Properties.Resources.Music);
            player = new SoundPlayer(music);
            player.Load();
            player.PlayLooping();
        }

        private void InputFileButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                InputFileText.Text = dialog.FileName;
            }
        }

        private void OutputFileButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.CheckFileExists = false;
            dialog.OverwritePrompt = false;
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                OutputFileText.Text = dialog.FileName;
            }
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtenemos información de la interfaz

                bool encrypt = OperationEncrypt.IsChecked ?? false;
                int algorithm = AlgorithmCombobox.SelectedIndex;
                string inputPath = InputFileText.Text;
                string outputPath = OutputFileText.Text;
                string key = KeyText.Text;

                // Convertimos la clave a bytes

                byte[] keyBytes = Encoding.ASCII.GetBytes(key);

                // Comprobamos que exista el fichero de entrada y pedimos confirmación si vamos a machacar el fichero de salida

                if (!File.Exists(inputPath))
                {
                    MessageBox.Show("El fichero de entrada no existe.", "Error", MessageBoxButton.OK);
                    return;
                }

                if (File.Exists(outputPath))
                {
                    if(MessageBox.Show("¿Estás seguro? El fichero de salida ya existe.", "Confirmación", MessageBoxButton.YesNo) != MessageBoxResult.Yes) { return; }
                }

                // Abrimos los ficheros

                FileStream inputFile = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
                FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

                byte[] buffer = new byte[1024];

                // Obtenemos el transform que corresponda a la operación y el algoritmo que vayamos a usar

                ICryptoTransform transform = null;

                if (algorithm == 0)
                {
                    // Algoritmo DES (en modo CBC)

                    DES des = DES.Create();
                    des.Mode = CipherMode.CBC;
                    des.Key = keyBytes;

                    if (encrypt)
                    {
                        des.GenerateIV();
                        outputFile.Write(des.IV);

                        transform = des.CreateEncryptor();

                    }
                    else
                    {
                        byte[] inputVector = new byte[8];
                        inputFile.Read(inputVector);

                        des.IV = inputVector;

                        transform = des.CreateDecryptor();

                    }

                }
                else if (algorithm == 1)
                {
                    // Algoritmo AES - 128

                    Aes aes = Aes.Create();
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;

                    if (keyBytes.Length == 16)
                    {
                        aes.Key = keyBytes;

                        if (encrypt)
                        {
                            transform = aes.CreateEncryptor();
                            //aes.Padding = PaddingMode.PKCS7;
                        }
                        else
                        {
                            transform = aes.CreateDecryptor();
                            //aes.Padding = PaddingMode.PKCS7;
                            //Console.WriteLine("Saliendo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR tu clave a de ser exactamente de 16 caracteres", "Retry", MessageBoxButton.OK);
                        return;
                    }


                }
                else if (algorithm == 2)
                {
                    // Algoritmo AES - 192
                    Aes aes = Aes.Create();
                    aes.Mode = CipherMode.ECB;

                    if (keyBytes.Length == 24)
                    {
                        aes.Key = keyBytes;
                        aes.Padding = PaddingMode.PKCS7;

                        if (encrypt)
                        {
                            transform = aes.CreateEncryptor();
                            aes.Padding = PaddingMode.PKCS7;
                        }
                        else
                        {
                            transform = aes.CreateDecryptor();
                            aes.Padding = PaddingMode.PKCS7;
                            Console.WriteLine("Saliendo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR tu clave a de ser exactamente de 24 caracteres", "Retry", MessageBoxButton.OK);
                        return;
                    }
                }
                else if (algorithm == 3)
                {
                    // Algoritmo AES - 256
                    Aes aes = Aes.Create();
                    aes.Mode = CipherMode.ECB;

                    if (keyBytes.Length == 32)
                    {
                        aes.Key = keyBytes;
                        aes.Padding = PaddingMode.PKCS7;

                        if (encrypt)
                        {
                            transform = aes.CreateEncryptor();
                            aes.Padding = PaddingMode.PKCS7;
                        }
                        else
                        {
                            transform = aes.CreateDecryptor();
                            aes.Padding = PaddingMode.PKCS7;
                            Console.WriteLine("Saliendo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR tu clave a de ser exactamente de 32 caracteres", "Retry", MessageBoxButton.OK);
                        return;
                    }
                }
                else
                {
                    // Algoritmo custom

                    if (encrypt)
                    {
                        transform = new MyEncryptor(keyBytes);
                    }
                    else
                    {
                        transform = new MyDecryptor(keyBytes);
                    }
                }

                // Aplicamos el transform usando un CryptoStream

                if(encrypt)
                {
                    var cryptoStream = new CryptoStream(outputFile, transform, CryptoStreamMode.Write);

                    int readed = inputFile.Read(buffer);
                    while (readed != 0)
                    {
                        cryptoStream.Write(buffer, 0, readed);
                        readed = inputFile.Read(buffer);
                    }

                    cryptoStream.Close();

                }
                else
                {
                    var cryptoStream = new CryptoStream(inputFile, transform, CryptoStreamMode.Read);

                    int readed = cryptoStream.Read(buffer);
                    while (readed != 0)
                    {
                        outputFile.Write(buffer, 0, readed);
                        readed = cryptoStream.Read(buffer);
                    }

                    cryptoStream.Close();
                }

                inputFile.Close();
                outputFile.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void AlgorithmCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}