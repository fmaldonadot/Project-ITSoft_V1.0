using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    public class SinComparator : Comparer <Employee>
    {

        public override int Compare(Employee e1, Employee e2)
        {
            if (e1.getSocial_security().CompareTo(e2.getSocial_security()) > 0)
                return 1;
            else if (e1.getSocial_security().CompareTo(e2.getSocial_security()) < 0)
                return -1;

            return 0;
        }
    }
}
