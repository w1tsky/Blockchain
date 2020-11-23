using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlockchainClient
{
    /// <summary>
    /// Логика взаимодействия для CreateChainWindow.xaml
    /// </summary>
    public partial class CreateChainWindow : Window
    {
        public CreateChainWindow()
        {
            InitializeComponent();
            
        }

        public string ChainName
        {
            get { return chainNameBox.Text; }
        }


        public string ChainDescriprion
        {
            get { return chaiDescBox.Text; }
        }


        private void AddChain_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
