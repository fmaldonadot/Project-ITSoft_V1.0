using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Project_ITSoft_V1._0.bus
{
    public class FileHandler
    {
        private String myfile = @"../../data/employees.txt";
        private String myfolder = @"../../data";

        public String getMyfolder()
        {
            return myfolder;
        }
        public void setMyfolder(String myfolder)
        {
            this.myfolder = myfolder;
        }
        public String getMyfile()
        {
            return myfile;
        }
        public void setMyfile(String myfile)
        {
            this.myfile = myfile;
        }

        public FileHandler() { }
        public FileHandler(String myfile)
        {
            this.myfile = myfile;
        }

        public DataCollection readFile()
        {
            DataCollection list = new DataCollection();
            String str = null;
            StreamReader  myscan = null;
            String[] token = null;
            	
		    try
		    {
			    myscan = new StreamReader(this.myfile);

            }
		    catch
		    {
			    return null;
		    }
		
		    while( (str = myscan.ReadLine() ) != null )
		    {
			    token = str.Split('|');
                if (token[5].Contains("FullTime"))
			    {
				    FullTime emp = new FullTime(token[0], token[1], token[2], token[3],
                                            token[4], token[5],
                                            new Date ( token[6] , token[7] ,  token[8] ),
                                            new Date( token[9] , token[10] , token[11] ),
                                            new Address( token[12] , token[13] , token[14] ,
                                            token[15] , token[16] , token[17] , token[18] ),
                                            new Phone( token[19] , token[20] , token[21] , token[22] ),
                                            new Phone( token[23] , token[24] , token[25] , token[26] ),
                                            token[27], token[29], token[30] , token[31]);
                    list.add(emp);
			    }
			    else if (token[5].Contains("PartTime"))
			    {
                   
                    if (token[30].Contains("Consultant_Trainers"))
                    { 
					    ConsultantTrainer emp = new ConsultantTrainer( token[0], token[1], token[2], token[3],
                                                        token[4], token[5],
                                                        new Date( token[6] , token[7], token[8] ),
                                                        new Date( token[9] , token[10] , token[11] ),
                                                        new Address( token[12], token[13] , token[14] ,
                                                        token[15] , token[16] , token[17] , token[18] ),
                                                        new Phone( token[19] , token[20] , token[21] , token[22] ),
                                                        new Phone( token[23] , token[24] , token[25] , token[26] ),
                                                        token[27], token[29], token[30], token[31], token[32] , token[33]);
                        list.add(emp);
				    }
				    else if (token[30].Contains("Internship_Student"))
				    {
					    Internship emp = new Internship(token[0], token[1], token[2], token[3],
                            token[4], token[5],
                            new Date( token[6] , token[7] , token[8] ),
                            new Date( token[9] , token[10] , token[11] ),
                            new Address( token[12] , token[13] , token[14] ,
                            token[15] , token[16] , token[17] , token[18] ),
                            new Phone( token[19] , token[20] , token[21] , token[22] ),
                            new Phone( token[23] , token[24] , token[25] , token[26] ),
                            token[27], token[29], token[30], token[31] , token[32]);
                        list.add(emp);
				    }
			    }
				
		    }
            myscan.Close(); ;
		    return list;
	    }


	    public void writeFile(DataCollection list)
        {
            using (StreamWriter txtstream = File.CreateText(this.myfile))
            {
                foreach (Employee emp in list.ReturnList())
                {
                    txtstream.WriteLine(emp);
                }
            }                
            
	    }
		
    }
}
