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
    /// Interaction logic for EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        private int id;
        public EditCustomerWindow(int id)
        {
            InitializeComponent();
            this.id = id;
        }
    }
}
