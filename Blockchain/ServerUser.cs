using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel;

namespace Blockchain
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServerUser" в коде и файле конфигурации.
    public class ServerUser : IServerUser
    {
       
        public int ID { get; set; }
        public string Username { get; set; }
        public OperationContext operationContext { get; set; }
    }
}
