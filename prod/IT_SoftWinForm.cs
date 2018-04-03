using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using Project_ITSoft_V1._0.bus;

namespace Project_ITSoft_V1._0.prod
{
    public partial class IT_SoftWinForm : Form
    {
        DataCollection employees = new DataCollection();
        int update_index = -1;
        bool save_flag = false;
        //int tempkey;
        //int index = 0; //index of the listBox
        string tempsin = ""; // Temporal SIN to mofidy option
        int temp_id;
        public IT_SoftWinForm()
        {
            InitializeComponent();
            // Loading Categories into combobox
            foreach (EnumCategory temp in Enum.GetValues(typeof(EnumCategory)))
            {
                cmbCategory.Items.Add(temp);
            }

            cmbCategory.SelectedItem = "Undefined";
            cmbCategory.Text = "Undefined";
            
            // Loading Departments into combobox
            foreach (EnumDepartment temp in Enum.GetValues(typeof(EnumDepartment)))
            {
                cmbDept.Items.Add(temp);
            }

            cmbDept.SelectedItem = "Undefined";
            cmbDept.Text = "Undefined";

            // Loading Contract's Types into combobox
            foreach (EnumContractType temp in Enum.GetValues(typeof(EnumContractType)))
            {
                cmbPTContractType.Items.Add(temp);
            }

            cmbPTContractType.SelectedItem = "Undefined";
            cmbPTContractType.Text = "Undefined";

            // Loading Full Time positions into combobox
            foreach (EnumPosition temp in Enum.GetValues(typeof(EnumPosition)))
            {
                cmbFTPosition.Items.Add(temp);
            }

            cmbFTPosition.SelectedItem = "Undefined";
            cmbFTPosition.Text = "Undefined";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string resp;
            resp = MessageBox.Show("Do you want to Exit?",
                                   "Close App", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question).ToString();

            if (resp == "Yes")
            {
                if (save_flag == true)
                {
                    resp = MessageBox.Show("There are unsaved data. Do you want to save it?",
                                    "Warning", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning).ToString();
                    if (resp == "Yes")
                    {
                        btnWriteFile.PerformClick();
                    }
                }
                this.Close();
            }
        }

        private void IT_SoftWinForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.Text == "FullTime")
            {
                // Show Corresponding Full Time Options
                cmbFTPosition.Show();
                FTAnualSallabel.Show();
                txtFTAnnualSalary.Show();
                FTPOSlabel.Show();

                FTlab01.Show();

                // Hide Others
                PTContractMlabel.Hide();
                cmbPTContractType.Hide();
                PTContTypelabel.Hide();
                PTCTHourlySallabel.Hide();
                PTCTWeekHlabel.Hide();
                PTInternTrimlabel.Hide();
                txtPTContractMonth.Hide();
                txtPTCTWeekHours.Hide();
                txtPTInternSal.Hide();
                txtPTTCHourlySal.Hide();

                PTTClab01.Hide();
                PTINlab01.Hide();
                
            }
            else if (cmbCategory.Text == "PartTime")
            {
                // Hide Corresponding Full Time Options
                cmbFTPosition.Hide();
                FTAnualSallabel.Hide();
                txtFTAnnualSalary.Hide();
                FTPOSlabel.Hide();

                FTlab01.Show();

                // Show Part Time Options
                cmbPTContractType.Show();
                PTContTypelabel.Show();

                // Wait for selection of Contract Type combo
                PTContractMlabel.Hide();
                PTCTHourlySallabel.Hide();
                PTCTWeekHlabel.Hide();
                PTInternTrimlabel.Hide();
                txtPTContractMonth.Hide();
                txtPTCTWeekHours.Hide();
                txtPTInternSal.Hide();
                txtPTTCHourlySal.Hide();
                PTTClab01.Hide();
                PTINlab01.Hide();

            }
            else if (cmbCategory.Text == "Undefined")
            {
                // Hide all
                cmbFTPosition.Hide();
                FTAnualSallabel.Hide();
                txtFTAnnualSalary.Hide();
                FTPOSlabel.Hide();
                FTlab01.Hide();

                PTContractMlabel.Hide();
                cmbPTContractType.Hide();
                PTContTypelabel.Hide();
                PTCTHourlySallabel.Hide();
                PTCTWeekHlabel.Hide();
                PTInternTrimlabel.Hide();
                txtPTContractMonth.Hide();
                txtPTCTWeekHours.Hide();
                txtPTInternSal.Hide();
                txtPTTCHourlySal.Hide();
                PTTClab01.Hide();
                PTINlab01.Hide();

            }

        }

        private void cmbPTContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPTContractType.Text == "Consultant_Trainers")
            {
                // Hide Corresponding Full Time Options
                cmbFTPosition.Hide();
                FTAnualSallabel.Hide();
                txtFTAnnualSalary.Hide();
                FTPOSlabel.Hide();
                FTlab01.Hide();

                // Show Part Time Options
                cmbPTContractType.Show();
                PTContTypelabel.Show();

                // Show Consultant_Trainers Options
                PTContractMlabel.Show();
                PTCTHourlySallabel.Show();
                PTCTWeekHlabel.Show();
                txtPTContractMonth.Show();
                txtPTContractMonth.Text = "";
                txtPTContractMonth.ReadOnly = false;
                txtPTCTWeekHours.Show();
                txtPTTCHourlySal.Show();
                PTTClab01.Show();
                
                // Hide Internship Options
                txtPTInternSal.Hide();
                PTInternTrimlabel.Hide();
                PTINlab01.Hide();

            }
            else if (cmbPTContractType.Text == "Internship_Student")
            {
                // Hide Corresponding Full Time Options
                cmbFTPosition.Hide();
                FTAnualSallabel.Hide();
                txtFTAnnualSalary.Hide();
                FTPOSlabel.Hide();
                FTlab01.Hide();

                // Show Part Time Options
                cmbPTContractType.Show();
                PTContTypelabel.Show();

                // Hide Consultant_Trainers Options
                PTCTHourlySallabel.Hide();
                PTCTWeekHlabel.Hide();
                txtPTCTWeekHours.Hide();
                txtPTTCHourlySal.Hide();
                PTTClab01.Hide();

                // Show a Fixed Contract Internship Month
                txtPTContractMonth.Show();
                txtPTContractMonth.Text = "3";
                txtPTContractMonth.ReadOnly = true;
                PTContractMlabel.Show();

                // Show Internship Options
                txtPTInternSal.Show();
                PTInternTrimlabel.Show();
                PTINlab01.Show();

            }
            else if (cmbPTContractType.Text == "Undefined")
            {
                // Hide Corresponding Full Time Options
                cmbFTPosition.Hide();
                FTAnualSallabel.Hide();
                txtFTAnnualSalary.Hide();
                FTPOSlabel.Hide();

                // Hide Consultant_Trainers Options
                PTCTHourlySallabel.Hide();
                PTCTWeekHlabel.Hide();
                txtPTCTWeekHours.Hide();
                txtPTTCHourlySal.Hide();

                // Hide a Fixed Contract Internship Month
                txtPTContractMonth.Hide();
                PTContractMlabel.Hide();

                // Hide Internship Options
                txtPTInternSal.Hide();
                PTInternTrimlabel.Hide();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee emp = null;
            string ccode = null;
            int temp_seq = 0;

            
            if (!employees.isUnique(txtSIN.Text))
            {
                MessageBox.Show("There is another employee with this SIN...",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (cmbCategory.Text == "FullTime")
            {
                ccode = "FT";
                if (!DataValidator.verifyData(txtFTAnnualSalary.Text, new Regex(DataValidator.patternMoney)))
                {
                    MessageBox.Show("Annual Salary must be a numeric value", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                emp = new FullTime((EnumPosition)cmbFTPosition.SelectedItem , 
                          Convert.ToDouble(txtFTAnnualSalary.Text));
                temp_seq = emp.getId(); //Store last sequence

            }
            else if (cmbCategory.Text == "PartTime")
            {
                ccode = "PT-";
                if (cmbPTContractType.Text == "Consultant_Trainers")
                {
                    ccode += "CON";
                    if (!DataValidator.verifyData(txtPTContractMonth.Text, new Regex(DataValidator.patternNumber)))
                    {
                        MessageBox.Show("Contract Month must be a number", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        
                    }
                    if (!DataValidator.verifyData(txtPTTCHourlySal.Text,  new Regex(DataValidator.patternHours)))
                    {
                        MessageBox.Show("Week hours must be a numeric value", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    if (!DataValidator.verifyData(txtPTCTWeekHours.Text, new Regex(DataValidator.patternHours)))
                    {
                        MessageBox.Show("Hours must be a numeric value", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    emp = new ConsultantTrainer((EnumContractType)cmbPTContractType.SelectedItem,
                                                Convert.ToInt16(txtPTContractMonth.Text) ,
                                                Convert.ToDouble(txtPTTCHourlySal.Text),
                                                Convert.ToDouble(txtPTCTWeekHours.Text));
                    temp_seq = emp.getId(); //Store last sequence


                }
                else if (cmbPTContractType.Text == "Internship_Student")
                {
                    ccode += "INT";
                    if (!DataValidator.verifyData(txtPTInternSal.Text, new Regex(DataValidator.patternMoney)))
                    {
                        MessageBox.Show("Internship Salary must be a numeric value", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    emp = new Internship(Convert.ToDouble(txtPTInternSal.Text), 
                                        (EnumContractType)cmbPTContractType.SelectedItem,
                                        Convert.ToInt16(txtPTContractMonth.Text) );
                    temp_seq = emp.getId(); //Store last sequence

                }
                else
                    MessageBox.Show("Must be selected a Contract Type...", "Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Must be selected an Employee's Category...", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);

            try
            {                               
                emp.setFname(txtFirstName.Text);
                emp.setLname(txtLastName.Text);
                if (!DataValidator.verifyData(txtSIN.Text, new Regex(DataValidator.patternSIN)))
                {
                    MessageBox.Show("Social Security must be a code like this ###-###-###", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                emp.setSocial_security(txtSIN.Text);
                emp.setDepartment((EnumDepartment)cmbDept.SelectedItem);
                emp.setCategory((EnumCategory)cmbCategory.SelectedItem);
                if (!DataValidator.verifyData(txtHDay.Text, new Regex(DataValidator.patternDay)))
                {
                    MessageBox.Show("Wrong day...Must be between 1 and 31", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtHMonth.Text, new Regex(DataValidator.patternMonth)))
                {
                    MessageBox.Show("Wrong month...Must be between 1 and 12", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtHYear.Text, new Regex(DataValidator.patternYear)))
                {
                    MessageBox.Show("Wrong year...Must be between 1900 and 2099", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                emp.setHire_date(new Date(txtHDay.Text, txtHMonth.Text, txtHYear.Text));
                if (!DataValidator.verifyData(txtBDay.Text, new Regex(DataValidator.patternDay)))
                {
                    MessageBox.Show("Wrong day...Must be between 1 and 31", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtBMonth.Text, new Regex(DataValidator.patternMonth)))
                {
                    MessageBox.Show("Wrong month...Must be between 1 and 12", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtBYear.Text, new Regex(DataValidator.patternYear)))
                {
                    MessageBox.Show("Wrong year...Must be between 1900 and 2099", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                emp.setBirthday(new Date(txtBDay.Text, txtBMonth.Text, txtBYear.Text));

                if (!DataValidator.verifyData(txtAddStrNo.Text, new Regex(DataValidator.patternNumber)))
                {
                    MessageBox.Show("Wrong Street No... Must be a number", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtAddApt.Text, new Regex(DataValidator.patternApt)))
                {
                    MessageBox.Show("Wrong Appartment/House No... Must be a number", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtAddApt.Text, new Regex(DataValidator.patternApt)))
                {
                    MessageBox.Show("Wrong Zip Code... Must be like this X#X-#X#", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                emp.setAddress(new Address(txtAddStrNo.Text, txtAddStrName.Text,
                                txtAddApt.Text, txtAddCity.Text, txtAddState.Text,
                                txtAddCountry.Text, txtAddZipCode.Text));

                if (!DataValidator.verifyData(txtHCountCode.Text, new Regex(DataValidator.patternCountcode)))
                {
                    MessageBox.Show("Wrong Phone Country Code", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtHCityCode.Text, new Regex(DataValidator.patternCitycode)))
                {
                    MessageBox.Show("Wrong Phone City Code...Must be a 3 digits number", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtHLocalCode.Text, new Regex(DataValidator.patternLocalcode)))
                {
                    MessageBox.Show("Wrong Phone Local...Must be a 7 digits number", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                emp.setHome_ph(new Phone(txtHCountCode.Text, txtHCityCode.Text,
                                txtHLocalCode.Text));

                if (!DataValidator.verifyData(txtCCountCode.Text, new Regex(DataValidator.patternCountcode)))
                {
                    MessageBox.Show("Wrong Phone Country Code", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtCCityCode.Text, new Regex(DataValidator.patternCitycode)))
                {
                    MessageBox.Show("Wrong Phone City Code...Must be a 3 digits number", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                if (!DataValidator.verifyData(txtCLocalCode.Text, new Regex(DataValidator.patternLocalcode)))
                {
                    MessageBox.Show("Wrong Phone Local...Must be a 7 digits number", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                emp.setCel_ph(new Phone(txtCCountCode.Text, txtCCityCode.Text,
                                txtCLocalCode.Text));

                if (!DataValidator.verifyData(txtEmail.Text, new Regex(DataValidator.patternEmail)))
                {
                    MessageBox.Show("Wrong email address", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                    return;

                }
                emp.setEmail(txtEmail.Text);

                txtTwoWeeksSal.Text = emp.getTwoWeeks_salary().ToString("#.##")+" $";
                emp.setContract(ccode);
                txtKey.Text = emp.getContract();

                employees.add(emp);
                                
                this.listBoxEmployees.Items.Add(employees.ShowListInBox(emp));
                btnReset.PerformClick();

                MessageBox.Show("Employee Added", "Confirmation",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                save_flag = true;
            }
            catch
            {
                MessageBox.Show("Missing or incorrects values to enter...Check and Try again",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string[] disp_list = null;
            try
            {
                disp_list = listBoxEmployees.SelectedItem.ToString().Split('\t');
                update_index = listBoxEmployees.SelectedIndex;

                // Fill the fields
                txtFirstName.Text = disp_list[1];
                txtLastName.Text = disp_list[2];
                txtSIN.Text = disp_list[3];
                tempsin = disp_list[3]; // Saving in case of choice modify option
                temp_id = Convert.ToInt16(disp_list[0]); // Saving ID in case of choice modify option
                cmbDept.Text = disp_list[4];
                cmbCategory.Text = disp_list[5];
                txtHDay.Text = disp_list[6];
                txtHMonth.Text = disp_list[7];
                txtHYear.Text = disp_list[8];
                txtBDay.Text = disp_list[9];
                txtBMonth.Text = disp_list[10];
                txtBYear.Text = disp_list[11];
                txtAddStrNo.Text = disp_list[12];
                txtAddStrName.Text = disp_list[13];
                txtAddApt.Text = disp_list[14];
                txtAddCity.Text = disp_list[15];
                txtAddState.Text = disp_list[16];
                txtAddCountry.Text = disp_list[17];
                txtAddZipCode.Text = disp_list[18];
                txtHCountCode.Text = disp_list[19];
                txtHCityCode.Text = disp_list[20];
                txtHLocalCode.Text = disp_list[21];
                txtCCountCode.Text = disp_list[23];
                txtCCityCode.Text = disp_list[24];
                txtCLocalCode.Text = disp_list[25];
                txtEmail.Text = disp_list[27];
                txtTwoWeeksSal.Text = disp_list[28];
                txtKey.Text = disp_list[29];
                
                if(cmbCategory.Text == "FullTime" )
                {
                    cmbFTPosition.Text = disp_list[30];
                    txtFTAnnualSalary.Text = disp_list[31];
                } 
                else if (cmbCategory.Text == "PartTime")
                {
                    // Show Part Time Options
                    cmbPTContractType.Show();
                    PTContTypelabel.Show();
                    txtPTContractMonth.Show();
                    PTContractMlabel.Show();

                    cmbPTContractType.Text = disp_list[30];
                    txtPTContractMonth.Text = disp_list[31];

                    if (cmbPTContractType.Text == "Consultant_Trainers")
                    {
                        // Show Consultant_Trainers Options
                        txtPTContractMonth.ReadOnly = false;
                        PTCTHourlySallabel.Show();
                        PTCTWeekHlabel.Show();                        
                        txtPTCTWeekHours.Show();
                        txtPTTCHourlySal.Show();

                        txtPTTCHourlySal.Text = disp_list[32];
                        txtPTCTWeekHours.Text = disp_list[33];
                    }
                    else if (cmbPTContractType.Text == "Internship_Student")
                    {
                        // Show a Fixed Contract Internship Month
                        txtPTContractMonth.ReadOnly = true;
                        PTInternTrimlabel.Show();
                        txtPTInternSal.Show();

                        txtPTInternSal.Text = disp_list[32];
                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("It must to add or select an item and display it, use Display Option",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            FileHandler txtwrite = new FileHandler();

            txtwrite.writeFile(employees);

            save_flag = false;

            MessageBox.Show("Employees were saved in the filepath: " + txtwrite.getMyfile(),
                    "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            FileHandler txtload = new FileHandler();
            SequenceID.setEmployee_id(1); // Initialize the Sequence Id
            employees.ReturnList().Clear();
            employees = txtload.readFile();

            // Clean the List Box
            listBoxEmployees.Items.Clear();

            foreach (Employee emp in employees.ReturnList())
            {
                listBoxEmployees.Items.Add(employees.ShowListInBox(emp));
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            /******************************* Ver 1.1 ***********************/
            Employee emp = null;
            String[] str;
            try 
            {
                str = listBoxEmployees.SelectedItem.ToString().Split('\t');

                emp = employees.search(Convert.ToInt16(str[0]));
                employees.remove(emp.getSocial_security());
                listBoxEmployees.Items.RemoveAt(listBoxEmployees.SelectedIndex);
                save_flag = true;
            }
            catch
            {
                MessageBox.Show("It must to add or select an item to erase",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKey.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtSIN.Text = "";
            txtHDay.Text = "";
            txtHMonth.Text = "";
            txtHYear.Text = "";
            txtBDay.Text = "";
            txtBMonth.Text = "";
            txtBYear.Text = "";
            txtHCountCode.Text = "";
            txtHCityCode.Text = "";
            txtHLocalCode.Text = "";
            txtCCountCode.Text = "";
            txtCCityCode.Text = "";
            txtCLocalCode.Text = "";
            txtAddStrNo.Text = "";
            txtAddStrName.Text = "";
            txtAddApt.Text = "";
            txtAddCity.Text = "";
            txtAddState.Text = "";
            txtAddCountry.Text = "";
            txtAddZipCode.Text = "";
            txtEmail.Text = "";
            txtTwoWeeksSal.Text = "";

            cmbDept.Text = EnumDepartment.Undefined.ToString();
            cmbCategory.Text = EnumCategory.Undefined.ToString();

            cmbFTPosition.Text = EnumPosition.Undefined.ToString();
            txtFTAnnualSalary.Text = "";

            cmbPTContractType.Text = EnumContractType.Undefined.ToString();

            txtPTContractMonth.Text = "";
            txtPTCTWeekHours.Text = "";
            txtPTInternSal.Text = "";
            txtPTTCHourlySal.Text = "";            

        }

        private void btnSearchByKey_Click(object sender, EventArgs e)
        {
            Employee emp = null;
            if (radbtnBySIN.Checked)
            {
                emp = employees.search(txtSearch.Text);

                if (emp != null)
                {
                    listBoxEmployees.SelectedIndex = emp.getId() - 1;

                    btnDisplay.PerformClick();
                }
                else
                    MessageBox.Show("SIN not found!", "Not Finded", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

            }
            if (radbtnByContract.Checked)
            {
                emp = employees.searchC(txtSearch.Text);

                if (emp != null)
                {
                    listBoxEmployees.SelectedIndex = emp.getId() - 1;

                    btnDisplay.PerformClick();
                }
                else
                    MessageBox.Show("Contract not found!", "Not Finded", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Employee emp = null;
            string ccode = "";
            int temp_seq = 0;
            try
            {

                if (cmbCategory.Text == "FullTime")
                {
                    ccode = "FT";
                    if (!DataValidator.verifyData(txtFTAnnualSalary.Text, new Regex(DataValidator.patternMoney)))
                    {
                        MessageBox.Show("Annual Salary must be a numeric value", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    emp = new FullTime((EnumPosition)cmbFTPosition.SelectedItem,
                              Convert.ToDouble(txtFTAnnualSalary.Text));
                    temp_seq = emp.getId(); //Store last sequence

                }
                else if (cmbCategory.Text == "PartTime")
                {
                    ccode = "PT-";
                    if (cmbPTContractType.Text == "Consultant_Trainers")
                    {
                        ccode += "CON";
                        if (!DataValidator.verifyData(txtPTContractMonth.Text, new Regex(DataValidator.patternNumber)))
                        {
                            MessageBox.Show("Contract Month must be a number", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        if (!DataValidator.verifyData(txtPTTCHourlySal.Text, new Regex(DataValidator.patternHours)))
                        {
                            MessageBox.Show("Week hours must be a numeric value", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        if (!DataValidator.verifyData(txtPTCTWeekHours.Text, new Regex(DataValidator.patternHours)))
                        {
                            MessageBox.Show("Hours must be a numeric value", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        emp = new ConsultantTrainer((EnumContractType)cmbPTContractType.SelectedItem,
                                                    Convert.ToInt16(txtPTContractMonth.Text),
                                                    Convert.ToDouble(txtPTTCHourlySal.Text),
                                                    Convert.ToDouble(txtPTCTWeekHours.Text));
                        temp_seq = emp.getId(); //Store last sequence


                    }
                    else if (cmbPTContractType.Text == "Internship_Student")
                    {
                        ccode += "INT";
                        if (!DataValidator.verifyData(txtPTInternSal.Text, new Regex(DataValidator.patternMoney)))
                        {
                            MessageBox.Show("Internship Salary must be a numeric value", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        emp = new Internship(Convert.ToDouble(txtPTInternSal.Text),
                                            (EnumContractType)cmbPTContractType.SelectedItem,
                                            Convert.ToInt16(txtPTContractMonth.Text));
                        temp_seq = emp.getId(); //Store last sequence

                    }
                    else
                        MessageBox.Show("Must be selected a Contract Type...", "Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("Must be selected an Employee's Category...", "Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                try
                {
                    emp.setFname(txtFirstName.Text);
                    emp.setLname(txtLastName.Text);
                    if (!DataValidator.verifyData(txtSIN.Text, new Regex(DataValidator.patternSIN)))
                    {
                        MessageBox.Show("Social Security must be a code like this ###-###-###", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    emp.setDepartment((EnumDepartment)cmbDept.SelectedItem);
                    emp.setCategory((EnumCategory)cmbCategory.SelectedItem);
                    if (!DataValidator.verifyData(txtHDay.Text, new Regex(DataValidator.patternDay)))
                    {
                        MessageBox.Show("Wrong day...Must be between 1 and 31", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtHMonth.Text, new Regex(DataValidator.patternMonth)))
                    {
                        MessageBox.Show("Wrong month...Must be between 1 and 12", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtHYear.Text, new Regex(DataValidator.patternYear)))
                    {
                        MessageBox.Show("Wrong year...Must be between 1900 and 2099", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    emp.setHire_date(new Date(txtHDay.Text, txtHMonth.Text, txtHYear.Text));
                    if (!DataValidator.verifyData(txtBDay.Text, new Regex(DataValidator.patternDay)))
                    {
                        MessageBox.Show("Wrong day...Must be between 1 and 31", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtBMonth.Text, new Regex(DataValidator.patternMonth)))
                    {
                        MessageBox.Show("Wrong month...Must be between 1 and 12", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtBYear.Text, new Regex(DataValidator.patternYear)))
                    {
                        MessageBox.Show("Wrong year...Must be between 1900 and 2099", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    emp.setBirthday(new Date(txtBDay.Text, txtBMonth.Text, txtBYear.Text));

                    if (!DataValidator.verifyData(txtAddStrNo.Text, new Regex(DataValidator.patternNumber)))
                    {
                        MessageBox.Show("Wrong Street No... Must be a number", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtAddApt.Text, new Regex(DataValidator.patternApt)))
                    {
                        MessageBox.Show("Wrong Appartment/House No... Must be a number", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtAddApt.Text, new Regex(DataValidator.patternApt)))
                    {
                        MessageBox.Show("Wrong Zip Code... Must be like this X#X-#X#", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    emp.setAddress(new Address(txtAddStrNo.Text, txtAddStrName.Text,
                                    txtAddApt.Text, txtAddCity.Text, txtAddState.Text,
                                    txtAddCountry.Text, txtAddZipCode.Text));

                    if (!DataValidator.verifyData(txtHCountCode.Text, new Regex(DataValidator.patternCountcode)))
                    {
                        MessageBox.Show("Wrong Phone Country Code", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtHCityCode.Text, new Regex(DataValidator.patternCitycode)))
                    {
                        MessageBox.Show("Wrong Phone City Code...Must be a 3 digits number", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtHLocalCode.Text, new Regex(DataValidator.patternLocalcode)))
                    {
                        MessageBox.Show("Wrong Phone Local...Must be a 7 digits number", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    emp.setHome_ph(new Phone(txtHCountCode.Text, txtHCityCode.Text,
                                    txtHLocalCode.Text));

                    if (!DataValidator.verifyData(txtCCountCode.Text, new Regex(DataValidator.patternCountcode)))
                    {
                        MessageBox.Show("Wrong Phone Country Code", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtCCityCode.Text, new Regex(DataValidator.patternCitycode)))
                    {
                        MessageBox.Show("Wrong Phone City Code...Must be a 3 digits number", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    if (!DataValidator.verifyData(txtCLocalCode.Text, new Regex(DataValidator.patternLocalcode)))
                    {
                        MessageBox.Show("Wrong Phone Local...Must be a 7 digits number", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    emp.setCel_ph(new Phone(txtCCountCode.Text, txtCCityCode.Text,
                                    txtCLocalCode.Text));

                    if (!DataValidator.verifyData(txtEmail.Text, new Regex(DataValidator.patternEmail)))
                    {
                        MessageBox.Show("Wrong email address", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SequenceID.setEmployee_id(temp_seq); // Decrease the sequence
                        return;

                    }
                    emp.setEmail(txtEmail.Text);
                    emp.setSocial_security(tempsin); //Assign last displayed SIN
                    txtTwoWeeksSal.Text = emp.getTwoWeeks_salary().ToString("#.##") + " $";

                    emp.setId(temp_id);
                    emp.setContract(ccode);
                    txtKey.Text = emp.getContract();                                     
                    
                    if (txtSIN.Text != emp.getSocial_security())
                    {
                        MessageBox.Show("Can't to modify the SIN in the Modify option.  It should use Add button",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                    

                    if (update_index > -1)
                    {
                        // Update list Box and list of employees
                        //listBoxEmployees.Items.Insert(update_index, emp);
                        employees.modify(emp, emp.getSocial_security());
                        listBoxEmployees.Items.Clear();
                        foreach (Employee temp in employees.ReturnList())
                        {
                            this.listBoxEmployees.Items.Add(employees.ShowListInBox(temp));
                        }

                        btnReset.PerformClick();

                        update_index = -1;

                        save_flag = true;

                        MessageBox.Show("Employee Mofified", "Confirmation",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                        
                    }
                    else
                        MessageBox.Show("It must to select an item and display it.  Use Display Option",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        
                }
                catch 
                {
                    MessageBox.Show("Missing or incorrects values to enter...Check and Try again",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch
            {
                MessageBox.Show("2222222222222Missing or incorrects values to enter...Check and Try again",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
