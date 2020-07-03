using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainClient.Models
{


    public class Block
    {

        
        public int BlockID { get; set; }
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }     
        public string User { get; set; }

        public int BlockchainID { get; set; }
        public Blockchain Blockchain { get; set; }

        public Block(string previousHash, Data data, User user, int blockchainID)
        {
            Index = 0;
            TimeStamp = DateTime.Now;
            PreviousHash = previousHash;
            Data = data.ToString();
            BlockchainID = blockchainID;
            Hash = CalculateHash();
            User = user.ToString();
        }


        public Block(string previousHash, string data, string user, int blockchainID)
        {
            Index = 0;
            TimeStamp = DateTime.Now;
            PreviousHash = previousHash;
            Data = data;
            BlockchainID = blockchainID;
            Hash = CalculateHash();
            User = user;
        }
   

        public  string GetStringForHash()
        {

            var data = "";
            data += TimeStamp;
            data += PreviousHash;
            data += Data;
            data += User;

            return data;
        }



        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            string data = GetStringForHash();

            byte[] inputBytes = Encoding.ASCII.GetBytes(data);
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

    }
}
