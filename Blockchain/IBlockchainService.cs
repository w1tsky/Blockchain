using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Blockchain
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IBlockchainService" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IBlockchainServerCallback)]
    public interface IBlockchainService
    {
        [OperationContract]
        int Connect();
        [OperationContract]
        void Disconnect(int id);
        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg);
    }

    public interface IBlockchainServerCallback
    {
        [OperationContract]
        void MsgCallback(string msg);
    }
}
