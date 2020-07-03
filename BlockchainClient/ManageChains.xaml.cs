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
using Microsoft.EntityFrameworkCore.Internal;
using Block = BlockchainClient.Models.Block;

namespace BlockchainClient
{
 
    public partial class ManageChains : UserControl
    {
        public UserRole UserRole;
        public User User;
        public Blockchain Chain { get; set; }
        public string BlockData { get; set; }
        public List<Blockchain> Blockchains { get; set; }
        public List<Block> Blocks { get; set; }
        public string Login;

        public ManageChains(string login, UserRole role)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                InitializeComponent();                       
                db.Blockchains.Load();
                db.Blocks.Load();
                Blockchains = db.Blockchains.Local.ToList();
                ChainsList.ItemsSource = Blockchains;
            }
            UserRole = role;
            Login = login;
        }

        private void addChainButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (UserRole == UserRole.Admin)
                {
                    CreateChainWindow createChainWindow = new CreateChainWindow();
                    createChainWindow.DataContext = this;
                    var b = (Blockchain)ChainsList.SelectedItem;
                    if (createChainWindow.ShowDialog() == true)
                    {
                        string chainName = createChainWindow.ChainName;

                        Chain = new Blockchain(chainName);

                        db.Blockchains.Add(Chain);
                        db.Blockchains.Load();
                        db.SaveChanges();
                        db.Blocks.Add(Chain.CreateGenesisBlock(Chain.BlockchainID));

                        db.SaveChanges();

                        Blockchains = db.Blockchains.Local.ToList();

                        Blocks = db.Blocks.ToList();
                        ChainsList.ItemsSource = Blockchains;
                        BlocksList.ItemsSource = Blocks;
                    }

                }
                else
                {
                    MessageBox.Show("Вы не администратор");
                }

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

        private void removeChainButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserRole == UserRole.Admin)
            {
                using (ApplicationContext db = new ApplicationContext())
                {

                    var b = (Blockchain)ChainsList.SelectedItem;

                    if (b != null)
                    {
                        db.Blockchains.Remove(b);
                        db.Blockchains.Load();
                        Blockchains = db.Blockchains.Local.ToList();
                        ChainsList.ItemsSource = Blockchains;
                        db.SaveChanges();
                        BlocksList.ItemsSource = null;
                        MessageBox.Show("Цепочка удалена");
                    }
                    else
                    {
                        MessageBox.Show("Добавьте цепочку");
                    }
                }     
            }
            else
            {
                MessageBox.Show("Вы не администратор");
            }
        }

        private void addBlockButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var b = (Blockchain)ChainsList.SelectedItem;
               

                if (b != null)
                {
                    var blocks = (from block in db.Blocks.Include(p => p.Blockchain)
                                  where block.BlockchainID == b.BlockchainID
                                  select block).ToList();
                    b.Chain = blocks;


                    Data BlockData = new Data(blockDataBox.Text, DataType.Content);
                    User u = new User(Login, "admin",UserRole.Admin, "AdminUser");
                 
                    Block Block = new Block(null, BlockData, u, b.BlockchainID);
                        
                    b.AddBlock(Block);
                    db.Blocks.Add(Block);                  
                    db.SaveChanges();
                  
                    BlocksList.ItemsSource = blocks;

                }
                else
                {
                    MessageBox.Show("Добавьте цепочку");
                }
    
            }
        }

        private void CheckChainButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var b = (Blockchain)ChainsList.SelectedItem;
              

                if (b != null)
                {

                    var blocks = (from block in db.Blocks.Include(p => p.Blockchain)
                                  where block.BlockchainID == b.BlockchainID
                                  select block).ToList();
                    b.Chain = blocks;

                    if (b.IsValid())
                    {
                        MessageBox.Show("Цепочка прошла валидацию");
                    }
                    else
                    {
                        MessageBox.Show("Цепочка не валидна");
                    }
                }
                else
                {
                    MessageBox.Show("Добавьте цепочку");
                }
            }
        }

    }
}   

