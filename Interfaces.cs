using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public interface IInit
    {
        void Init();
        void RandomInit();
        void Show();
    }

    public class SortByWeight : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if (obj1 is null || obj2 is null)
                return 1;

            Goods goods1 = (Goods)obj1;
            Goods goods2 = (Goods)obj2;

            if (goods1.Weight > goods2.Weight)
                return 1;
            if (goods1.Weight < goods2.Weight)
                return -1;
            else
                return 0;
        }
    }
}
