using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Contracts
{
    public interface IItemRepository
    {
        Item getByID(int id);
        Item getByItemLoockupCode(string itemLoockupCode);
    }
}
