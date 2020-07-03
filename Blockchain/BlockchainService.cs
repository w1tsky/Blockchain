using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Blockchain
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class BlockchainService : IBlockchainService
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId;

        public int Connect(string username)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                Username = username,
                operationContext = OperationContext.Current
            };
            users.Add(user);
            return user.ID;
        }

        public int Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);

            }
        }

      

        public void SendMsg(string msg)
        {
            
        }
    }
}
