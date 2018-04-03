using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    public class ConsultantTrainer : PartTime
    {

        private double hourly_salary;                               //POS 32
        private double week_hours;                                  //POS 33

        public double getHourly_salary()
        {
            return hourly_salary;
        }
        public void setHourly_salary(double hourly_salary)
        {
            this.hourly_salary = hourly_salary;
        }
        public double getWeek_hours()
        {
            return week_hours;
        }
        public void setWeek_hours(double week_hours)
        {
            this.week_hours = week_hours;
        }

        public ConsultantTrainer() { }
        public ConsultantTrainer(Employee emp) : base(emp) { }
        public ConsultantTrainer(double hourly_salary, double week_hours)
        {
            this.hourly_salary = hourly_salary;
            this.week_hours = week_hours;
        }
        public ConsultantTrainer(EnumContractType temp_position, int contract_months, double hourly_salary, double week_hours):
               base(temp_position, contract_months)
        {
            
            this.hourly_salary = hourly_salary;
            this.week_hours = week_hours;
        }
        public ConsultantTrainer(String fname, String lname, String social_security, EnumDepartment department,
                             EnumCategory category, Date hire_date, Date birthday, Address address, Phone home_ph,
                             Phone cel_ph, String email, EnumContractType temp_position, int contract_months,
                             double hourly_salary, double week_hours):
               base(fname, lname, social_security, department, category, hire_date, birthday, address, home_ph,
                    cel_ph, email, temp_position, contract_months)
            
        {
            this.hourly_salary = hourly_salary;
            this.week_hours = week_hours;
        }

        // This constructor is made for FileHandler purposes
        public ConsultantTrainer(String id, String fname, String lname, String social_security, String department,
                String category, Date hire_date, Date birthday, Address address,
                Phone home_ph, Phone cel_ph, String email, String contract, String temp_position, String contract_months,
                String hourly_salary, String week_hours):
                base(id, fname, lname, social_security, department, category, hire_date, birthday, address, home_ph,
                  cel_ph, email, contract , temp_position, contract_months)
            
        {
            this.hourly_salary = Convert.ToDouble(hourly_salary);
            this.week_hours = Convert.ToDouble(week_hours);
        }

        public override String ToString()
        {
            return base.ToString() + "|" + hourly_salary + "|" + week_hours;
        }

        public override double CalculPayment()
        {
            return (this.hourly_salary * this.week_hours) * 2;
        }

    }

}
