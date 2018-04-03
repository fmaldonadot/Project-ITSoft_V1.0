using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    public class SequenceID
    {
        private static int employee_id = 1;

        public static int getEmployee_id()
        {
            return SequenceID.employee_id++;
        }
        public static void setEmployee_id(int employee_id)
        {
            SequenceID.employee_id = employee_id;
        }
    }
}
