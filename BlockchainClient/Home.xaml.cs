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
using Microsoft.EntityFrameworkCore;



namespace BlockchainClient
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    /// 

    public partial class Home : UserControl
    {

        public Blockchain Chain { get; set; }
        public string BlockData { get; set; }
        public ObservableCollection<Blockchain> blockchains;
        public ObservableCollection<BlockchainClient.Models.Block> blocks;

        public Home()
        {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {      
                db.Blockchains.Load();
                db.Blocks.Load();
                blockchains = db.Blockchains.Local.ToObservableCollection();
                ChainsList.ItemsSource = blockchains;
            }
        }



        private void ChainsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {


                var b = (Blockchain)ChainsList.SelectedItem;
                if (b != null)
                {
                    var blocks = (from block in db.Blocks.Include(p => p.Blockchain)
                                  where block.BlockchainID == b.BlockchainID
                                  select block).ToList();


                    BlocksList.ItemsSource = blocks;
                }
            }


        }
    }
}
