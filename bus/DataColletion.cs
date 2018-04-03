using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace Project_ITSoft_V1._0.bus
{
    public class DataCollection
    {
        private List<Employee> empList;

        public List<Employee> getEmpList()
        {
            return empList;
        }
        public void setEmpList(List<Employee> empList)
        {
            this.empList = empList;
        }

        public DataCollection()
        {
            this.empList = new List<Employee>();
        }
        public DataCollection(Employee emp)
        {
            this.empList.Add(emp);
        }

        //****************** Methods *********************
        // For use of Comparator
        public List<Employee> ReturnList()
        {
            return this.empList;
        }
        // Add Methods
        public void add(Employee emp)
        {
            this.empList.Add(emp);
        }

        //Remove Methods
        public void remove(Employee emp) //Current element
        {
            this.empList.Remove(emp);
        }

        public int remove(String nas) //By Social Security
        {
            foreach (Employee curr in this.empList)
            {
                if (curr.getSocial_security()== nas)
                {
                    this.empList.Remove(curr);
                    return this.empList.Capacity;
                }
            }

            return -1;

        }

        public int remove(int id) //By ID
        {
            foreach (Employee curr in this.empList)
            {
                if (curr.getId() == id)
                {
                    this.empList.Remove(curr);
                    return this.empList.Capacity;
                }
            }

            return -1;

        }

        // Search Methods
        // Search by NAS	
        public Employee search(String nas)
        {

            foreach (Employee curr in empList)
            {
                if (curr.getSocial_security() == nas)
                    return curr;
            }
            return null;
        }

        // Search by Contract	
        public Employee searchC(String contract)
        {

            foreach (Employee curr in empList)
            {
                if (curr.getContract() == contract)
                    return curr;
            }
            return null;
        }

        // Search by ID	
        public Employee search(int id)
        {

            foreach (Employee curr in empList)
            {
                if (curr.getId() == id)
                    return curr;
            }
            return null;
        }

        // Search by Name	
        public DataCollection search(String name, int type)
        {
            DataCollection templist = new DataCollection();
            switch (type)
            {
                case 1:
                    foreach (Employee curr in empList)
                    {
                        if (curr.getFname() == name)
                            templist.add(curr);
                    }

                    break;

                case 2:
                    foreach (Employee curr in empList)
                    {
                        if (curr.getLname() == name)
                            templist.add(curr);
                    }

                    break;

            }
            if (templist.getSize() == 0)
                return null;
            else
                return templist;
        }

        // Search by Department
        public DataCollection search(EnumDepartment dept)
        {
            DataCollection templist = new DataCollection();

            foreach (Employee curr in empList)
            {
                if (curr.getDepartment() == dept)
                    templist.add(curr);
            }

            if (templist.getSize() == 0)
                return null;
            else
                return templist;

        }

        // Sort Methods
        // By SIN
        public void SortBySIN()
        {
            this.empList.Sort(new SinComparator());
        }
        // By Name
        public void SortByName()
        {
            this.empList.Sort(new NameComparator());
        }

        // Modify List
        public void modify(Employee emp, String sin)
        {
            int index = this.getIndex(sin);

            this.empList[index]= emp;
        }

        // Get index
        public int getIndex(String sin)
        {
            int index = 0;

            foreach (Employee emp in this.empList)
            {
                if (emp.getSocial_security() == sin )
                    return index;
                index++;
            }
            return -1;
        }
        // Get Size of list
        public int getSize()
        {
            return empList.Capacity;
        }

        // Check Unique SIN
        public bool isUnique(String sin)
        {
            if (this.search(sin) == null)
                return true;
            else
                return false;
        }

        // Only to show in a listbox
        public String ShowListInBox(Employee emp)
        {
            //ListBox lbox = new ListBox();
            string[] columns;
            string strshow = "";

            //foreach (Employee emp in this.empList)
            //{
            strshow = "";
            columns = emp.ToString().Split('|');

            for (int i = 0; i < columns.Length; i++)
            {
                strshow += columns[i] + "\t";
            }
            //lbox.Items.Add(strshow);                
            // }
            return strshow;
        }

        // ToString
        public String toString()
        {
            String state = "";

            foreach (Employee curr in empList)
            {
                state += curr + "\n";
            }

            return state;
        }

    }
}
