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
using System.Windows.Shapes;

namespace ClothingStore.WPF.PopUpWindows
{
    /// <summary>
    /// Interaction logic for QRCode.xaml
    /// </summary>
    public partial class QRCode : Window
    {
        public QRCode(double amount)
        {
            InitializeComponent();
            LoadImageFromUrl($"https://img.vietqr.io/image/970423-00000113464-print.png?amount={amount}&addInfo=thanh%20toan%20clothing%20store&accountName=Nguyen%20Viet%20Dung");
        }

        private void LoadImageFromUrl(string imageUrl)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imageUrl, UriKind.Absolute);
            bitmap.EndInit();
            QRCodeImage.Source = bitmap;
        }
    }
}
