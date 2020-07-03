using BlockchainClient.Models;
using System;
using System.Collections.Generic;

public class Blockchain
{
    public string ChainName { get; set; }
    public IList<Block> Chain { set; get; }
    public string ChainDesription { get; set; }


  

    public Blockchain(string chainName, string chainDescription)
    {
        ChainName = chainName;
        ChainDesription = chainDescription;
        InitializeChain();
        AddGenesisBlock();
    }


    public void InitializeChain()
    {
        Chain = new List<Block>();
    }

    public Block CreateGenesisBlock()
    {
        return new Block("None", "Genesis Block");
    }

    public void AddGenesisBlock()
    {
        Chain.Add(CreateGenesisBlock());
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
}