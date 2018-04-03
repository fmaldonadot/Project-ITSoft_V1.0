using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    public class FullTime : Employee
    {

        private EnumPosition position = EnumPosition.Undefined;				//POS 30
        private double annual_salary;                                       //POS 31

        public EnumPosition getPosition()
        {
            return position;
        }
        public void setPosition(EnumPosition position)
        {
            this.position = position;
        }
        public double getAnnual_salary()
        {
            return annual_salary;
        }
        public void setAnnual_salary(double annual_salary)
        {
            this.annual_salary = annual_salary;
        }

        public FullTime() { }
        public FullTime(Employee emp):base(emp){}
        public FullTime(EnumPosition position, double asalary)
        {
            this.position = position;
            this.annual_salary = asalary;
        }

        public FullTime(String fname, String lname, String social_security, EnumDepartment department,
                        EnumCategory category, Date hire_date, Date birthday, Address address,
                        Phone home_ph, Phone cel_ph, String email, EnumPosition position, double asalary ):
            base(fname, lname, social_security, department, category, hire_date, birthday, address, home_ph,
              cel_ph, email)
        {
        
            this.position = position;
            this.annual_salary = asalary;
        }

        // This constructor is made for FileHandler purposes
        public FullTime(String id, String fname, String lname, String social_security, String department,
                        String category, Date hire_date, Date birthday, Address address,
                        Phone home_ph, Phone cel_ph, String email, String contract , String position, String asalary ) :
            base(id, fname, lname, social_security, department, category, hire_date, birthday, address, home_ph,
                 cel_ph, email , contract)
        {
        
            this.position = (EnumPosition)Enum.Parse(typeof(EnumPosition),position);
            this.annual_salary = Convert.ToDouble(asalary);
        }

        public override String ToString()
        {
            String state = base.ToString() + "|" + position + "|" + annual_salary;

            return state;
        }

    
        public override double CalculPayment()
        {
            double payment = (this.annual_salary / 52) * 2;

            return payment;
        }
    }
}
