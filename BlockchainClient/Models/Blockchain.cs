using BlockchainClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockchainClient.Models
{

  

    public class Blockchain
    {
        public int BlockchainID { get; set; }
        public string BlockchainName { get; set; }
        [NotMapped]
        public IList<Block> Chain { set; get; }
        public List<Block> Blocks { get; set; }

        public Blockchain(string blockchainName)
        {
            BlockchainName = blockchainName;
            InitializeChain();
            AddGenesisBlock();
        }


        public void InitializeChain()
        {
            Chain = new ObservableCollection<Block>();
        }


        public Block CreateGenesisBlock(int chainID)
        {
            Data GenesisBlock = new Data("Genesis Block",DataType.Content);
            User u = new User("admin", "admin", UserRole.Admin,"Admin User");
            return new Block("None",GenesisBlock, u, chainID);
        }

        public void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock(this.BlockchainID));
        }


        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.CalculateHash();
            Chain.Add(block);
        }


        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }

}

