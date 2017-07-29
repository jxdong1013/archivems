using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContractMvcWeb.Models.Beans;

namespace ContractMvcWeb.Models
{
    public class BorrowDateComperater : IComparer<InventoryBoxLabel>
    {
        public int Compare(InventoryBoxLabel x, InventoryBoxLabel y)
        {
            if (x.inventoryStatus == (int)Constant.InventoryBoxStatusEnum.在库 && y.inventoryStatus ==(int)Constant.InventoryBoxStatusEnum.在库 )
            {
                return x.id.CompareTo(y.id);
            }
            else if (x.inventoryStatus == (int)Constant.InventoryBoxStatusEnum.在库 && y.inventoryStatus != (int)Constant.InventoryBoxStatusEnum.在库)
            {
                return -1;
            }
            else if (x.inventoryStatus != (int)Constant.InventoryBoxStatusEnum.在库 && y.inventoryStatus == (int)Constant.InventoryBoxStatusEnum.在库)
            {
                return 1;
            }
            else
            {
                return x.borrowDate.CompareTo(y.borrowDate);
            }
        }
    }
}