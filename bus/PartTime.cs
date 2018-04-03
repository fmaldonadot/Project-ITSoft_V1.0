using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    public abstract class PartTime : Employee
    {
        EnumContractType temp_position;							    //POS 30

        private int contract_months;								//POS 31

        public EnumContractType getTemp_position()
        {
            return temp_position;
        }
        public void setTemp_position(EnumContractType temp_position)
        {
            this.temp_position = temp_position;
        }
        public int getContract_months()
        {
            return contract_months;
        }
        public void setContract_months(int contract_months)
        {
            this.contract_months = contract_months;
        }

        public PartTime() { }
        public PartTime(Employee emp) : base(emp) { }
   
        public PartTime(EnumContractType temp_position, int contract_months)
        {
            this.temp_position = temp_position;
            this.contract_months = contract_months;
        }
        public PartTime(String fname, String lname, String social_security, EnumDepartment department,
                        EnumCategory category, Date hire_date, Date birthday, Address address, Phone home_ph, Phone cel_ph,
                        String email, EnumContractType temp_position, int contract_months):
                base(fname, lname, social_security, department, category, hire_date, birthday, address, home_ph,
                cel_ph, email)
        
        {
            this.temp_position = temp_position;
            this.contract_months = contract_months;
        }

        // This constructor is made for FileHandler purposes
        public PartTime(String id, String fname, String lname, String social_security, String department,
                        String category, Date hire_date, Date birthday, Address address,
                        Phone home_ph, Phone cel_ph, String email, String contract , String temp_position, String contract_months ) :
                base(id, fname, lname, social_security, department, category, hire_date, birthday, address, home_ph,
                     cel_ph, email , contract)
        
        {
            this.temp_position = (EnumContractType)Enum.Parse(typeof(EnumContractType),temp_position);
            this.contract_months = Convert.ToInt16(contract_months);
        }

        public override String ToString()
        {
            return base.ToString() + "|" + temp_position + "|" + contract_months;
        }

        public override double CalculPayment()
        {
            return 0;
        }
    }

}
