using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace BlockchainClient.Models
{

    public class Data 
    {
                  
        public string Content { get; private set; }  
        public string Hash { get; private set; } 
        public DataType Type { get; private set; }
     
        public Data(string content, DataType type)
        {       
            Content = content;
            Type = type;
            Hash = Hash;
        }

             
        public string GetStringForHash()
        {
            var text = Content;
            text += (int)Type;
            return text;
        }

     
        public override string ToString()
        {
            return Content;
        }
    }
}
