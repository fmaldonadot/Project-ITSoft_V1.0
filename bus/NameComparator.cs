using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    public class NameComparator : Comparer <Employee>
    {

        public override int Compare(Employee e1, Employee e2)
        {
            String name1 = e1.getFname() + e1.getLname();
            String name2 = e2.getFname() + e1.getLname();

            if (name1.CompareTo(name2) > 0)
                return 1;
            else if (name1.CompareTo(name2) < 0)
                return -1;

            return 0;
        }

    }
}
