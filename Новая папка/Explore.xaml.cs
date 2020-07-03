using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using BlockchainClient.Models;


namespace BlockchainClient
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    /// 


    public partial class Explore : UserControl
    {
        public Blockchain Chain { get; set; }
        public string BlockData { get; set; }
        public static ObservableCollection<Blockchain> Chains;
        public static ObservableCollection<BlockchainClient.Models.Block> Blocks;
        


        public Explore()
        {
            InitializeComponent();                    
            Chains = new ObservableCollection<Blockchain>();
            Blocks = new ObservableCollection<BlockchainClient.Models.Block>();
        }

        private void addChainButton_Click(object sender, RoutedEventArgs e)
        {
                       
            CreateChainWindow createChainWindow = new CreateChainWindow();
            createChainWindow.DataContext = this;           
            if (createChainWindow.ShowDialog() == true)
            {              
                string chainName = createChainWindow.ChainName;
                string chainDesc = createChainWindow.ChainDescriprion;
                Chain = new Blockchain(chainName, chainDesc);  
                Chains.Add(Chain);
            }
            ChainsList.ItemsSource = Chains;
        
        }

        private void ChainsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var b = (Blockchain)ChainsList.SelectedItem;

            if (b != null)
            {              
                BlocksList.ItemsSource = b.Chain;               
            }
                   
        }

        private void removeChainButton_Click(object sender, RoutedEventArgs e)
        {
            var b = (Blockchain)ChainsList.SelectedItem;


            if (b != null)
            {
                Chains.Remove(b);

                BlocksList.ItemsSource = null;
                ChainsList.ItemsSource = Chains;
                MessageBox.Show("Цепочка удалена");
            }
            else
            {
                MessageBox.Show("Добавьте цепочку");
            }
           
        }

        private void addBlockButton_Click(object sender, RoutedEventArgs e)
        {
            
            var b = (Blockchain)ChainsList.SelectedItem;
            BlockData = blockDataBox.Text;
            BlockchainClient.Models.Block block = new BlockchainClient.Models.Block(null, BlockData);
            b.AddBlock(block);           
            Blocks.Add(block);
            BlocksList.ItemsSource = b.Chain;
        }
    }  
    
}
