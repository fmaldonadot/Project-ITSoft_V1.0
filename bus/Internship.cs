using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    public class Internship : PartTime
    {
        private Double trimester_salary;                            //POS 32

        public Double getTrimester_salary()
        {
            return trimester_salary;
        }
        public void setTrimester_salary(Double trimester_salary)
        {
            this.trimester_salary = trimester_salary;
        }

        public Internship() { }
        public Internship(Employee emp) : base(emp) { }
    
        public Internship(Double trimester_salary)
        {
            this.trimester_salary = trimester_salary;
        }

        public Internship(Double trimester_salary , EnumContractType temp_position, 
                          int contract_months ):
            base(temp_position, contract_months)

        {
            this.trimester_salary = trimester_salary;
        }

        public Internship(String fname, String lname, String social_security, EnumDepartment department,
                          EnumCategory category, Date hire_date, Date birthday, Address address, Phone home_ph,
                          Phone cel_ph, String email, EnumContractType temp_position, int contract_months, 
                          Double trimester_salary):
                base(fname, lname, social_security, department, category, hire_date, birthday, 
                     address, home_ph, cel_ph, email, temp_position, contract_months)
        {

        
            this.trimester_salary = trimester_salary;
        }

        // This constructor is made for FileHandler purposes
        public Internship(String id, String fname, String lname, String social_security, String department,
                          String category, Date hire_date, Date birthday, Address address,
                          Phone home_ph, Phone cel_ph, String email, String contract , String temp_position, String contract_months,
                          String trimester_salary):
                base(id, fname, lname, social_security, department, category, hire_date, birthday, address, home_ph,
                     cel_ph, email, contract , temp_position, contract_months)
        
        {
            this.trimester_salary = Convert.ToDouble(trimester_salary);
        }

   
        public override String ToString()
        {
            return base.ToString() + "|" + trimester_salary;
        }

   
        public override double CalculPayment()
        {

            return (this.trimester_salary / 12) * 2;
        }

    }
}
