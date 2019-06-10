using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.Core.Logger
{
    public class LoggingEvents
    {
        public const int GenerateItems = 1000;
        public const int ListItems = 1001;
        public const int GetItem = 1002;
        public const int InsertItem = 1003;
        public const int EditItem = 1004;
        public const int DeleteItem = 1005;
        public const int CreateItem = 1006;
        public const int InformationItem = 1007;


        public const int GetItemNotFound = 4000;
        public const int UpdateItemNotFound = 4001;
        public const int ListItemsNotFound = 4002;
        public const int CreateItemNotFound = 4003;
        public const int InformationItemNotFound = 4004;
        public const int EditItemNotFound = 4005;
        public const int DeleteItemNotFound = 4006;
    }
}
