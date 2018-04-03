using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    abstract public class Employee
    {
        private int id = SequenceID.getEmployee_id();                       //POS 0
        private String fname;                                               //POS 1
        private String lname;                                               //POS 2
        private String social_security;                                     //POS 3
        private EnumDepartment department = EnumDepartment.Undefined;       //POS 4
        private EnumCategory category;                                      //POS 5
        private Date hire_date;                                             //POS 6 - 7 - 8
        private Date birthday;                                              //POS 9 - 10 - 11
        private Address address;                                            //POS 12 - 13 - 14 - 15 - 16 - 17 - 18
        private Phone home_ph;                                              //POS 19 - 20 - 21 - 22
        private Phone cel_ph;                                               //POS 23 - 24 - 25 - 26
        private String email;                                               //POS 27
        private Double twoWeeks_salary;                                     //POS 28
        private String contract;                                            //POS 29

        public string getContract()
        {
            return this.contract;
        }
        public void setContract(String value)
        {
            contract = value + "-" + this.id.ToString() + "-" + this.social_security;
        }
       
        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public String getFname()
        {
            return fname;
        }
        public void setFname(String fname)
        {
            this.fname = fname;
        }
        public String getLname()
        {
            return lname;
        }
        public void setLname(String lname)
        {
            this.lname = lname;
        }
        public String getSocial_security()
        {
            return social_security;
        }
        public void setSocial_security(String social_security)
        {
            this.social_security = social_security;
        }
        public EnumDepartment getDepartment()
        {
            return department;
        }
        public void setDepartment(EnumDepartment department)
        {
            this.department = department;
        }
        public EnumCategory getCategory()
        {
            return category;
        }
        public void setCategory(EnumCategory category)
        {
            this.category = category;
        }
        public Date getHire_date()
        {
            return hire_date;
        }
        public void setHire_date(Date hire_date)
        {
            this.hire_date = hire_date;
        }
        public Date getBirthday()
        {
            return birthday;
        }
        public void setBirthday(Date birthday)
        {
            this.birthday = birthday;
        }
        public Address getAddress()
        {
            return address;
        }
        public void setAddress(Address address)
        {
            this.address = address;
        }
        public Phone getHome_ph()
        {
            return home_ph;
        }
        public void setHome_ph(Phone home_ph)
        {
            this.home_ph = home_ph;
        }
        public Phone getCel_ph()
        {
            return cel_ph;
        }
        public void setCel_ph(Phone cel_ph)
        {
            this.cel_ph = cel_ph;
        }
        public String getEmail()
        {
            return email;
        }
        public void setEmail(String email)
        {
            this.email = email;
        }
        public Double getTwoWeeks_salary()
        {
            this.setTwoWeeks_salary();
            return twoWeeks_salary;
        }

        public void setTwoWeeks_salary()
        {
            this.twoWeeks_salary = CalculPayment();
        }

        public Employee() { }
        public Employee(Employee emp)
        {
            this.fname = emp.fname;
            this.lname = emp.lname;
            this.social_security = emp.social_security;
            this.department = emp.department;
            this.category = emp.category;
            this.hire_date = emp.hire_date;
            this.birthday = emp.birthday;
            this.address = emp.address;
            this.home_ph = emp.home_ph;
            this.cel_ph = emp.cel_ph;
            this.email = emp.email;
        }
        public Employee(String fname, String lname, String social_security, EnumDepartment department,
                        EnumCategory category, Date hire_date, Date birthday, Address address,
                        Phone home_ph, Phone cel_ph, String email)
        {
            this.fname = fname;
            this.lname = lname;
            this.social_security = social_security;
            this.department = department;
            this.category = category;
            this.hire_date = hire_date;
            this.birthday = birthday;
            this.address = address;
            this.home_ph = home_ph;
            this.cel_ph = cel_ph;
            this.email = email;
        }
        public Employee(int id, String fname, String lname, String social_security, EnumDepartment department,
                        EnumCategory category, Date hire_date, Date birthday, Address address,
                        Phone home_ph, Phone cel_ph, String email)
        {
            this.id = id;
            this.fname = fname;
            this.lname = lname;
            this.social_security = social_security;
            this.department = department;
            this.category = category;
            this.hire_date = hire_date;
            this.birthday = birthday;
            this.address = address;
            this.home_ph = home_ph;
            this.cel_ph = cel_ph;
            this.email = email;
        }
        // This constructor is made for FileHandler purposes
        public Employee(String id, String fname, String lname, String social_security, String department,
                        String category, Date hire_date, Date birthday, Address address, Phone home_ph,
                        Phone cel_ph, String email , String contract)
        {

            this.id = Convert.ToInt16(id);
            this.fname = fname;
            this.lname = lname;
            this.social_security = social_security;
            this.department = (EnumDepartment)Enum.Parse( typeof(EnumDepartment) , department);  
            this.category = (EnumCategory)Enum.Parse(typeof(EnumCategory) , category);
            this.hire_date = hire_date;
            this.birthday = birthday;
            this.address = address;
            this.home_ph = home_ph;
            this.cel_ph = cel_ph;
            this.email = email;
            this.contract = contract;
        }


        public void InitEmployeeID(int id)
        {
            SequenceID.setEmployee_id(id);
        }       

        public override String ToString()
        {
            return this.id + "|" + fname + "|" + lname + "|" + social_security + "|" + department + "|" +
                   category + "|" + hire_date + "|" + birthday + "|" + address + "|" + home_ph + "|" + cel_ph + "|" +
                   email + "|" + this.getTwoWeeks_salary().ToString("#.##") + "|" + this.contract;


        }

        abstract public double CalculPayment();        

    }
}
