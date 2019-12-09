using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace learnHL72
{
    class Assertion
    {
        private List<string> cdms = new List<string>();
        private int i = 0;
        private string provider = ConfigurationManager.AppSettings
        ["provider"];
        private string connectionString = ConfigurationManager.AppSettings
        ["connectionString"];
        private string fieldsToValidateQuery = "select distinct Segment, Field, Subfield from dbo.CMMCodes order by Segment, Field, Subfield";
        private string validCMMCodesQuery = "select Segment, Field, Subfield, CMMValue from dbo.CMMCodes";
        private string segmentInScope = "select distinct Segment from dbo.CMMCodes where Segment = ";
        //        private DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

        private List<CDMCode> fieldsToValidateList;
        private List<CDMCode> validCMMCodesList;

        //Constructor
        public Assertion(HL7Message msg, AllCDMCodes acs)
        {

            MessageBox.Show("assertions");//-------------------debug

            //get list of codes

                foreach (Segment s in msg)
                {
                    //TODO: loop through the segment and get the field from the list of CDM codes
                    //---------------------------

                    foreach (Field f in s)
                    {

                        string segName = s.value.Substring(0, 3);

                    //get this segment name then see if it exists in the database
                    


                    //retrieve the cdmCodes where = segName
                    foreach (CDMCode c in acs)
                        //get a list of fields and subfields for the current segment
                        {
                            if (c.Segment == segName)
                            {
                                if (!cdms.Contains(c.Field))
                                {
                                    cdms.Add(c.Field);
                                }
                            }
                        }

                        //foreach(CDMCode in )

                        /*if (cdmCodes.Contains(segName))

                            try
                            {
                                //need to 
                                //--get the segment in question for this segment
                                //--get the fields in question for this segment
                                //--get the subfields in question for this segment
                                //in a OneOf() method compare Assert.HL7Message.component.OneOf(); 
                                string wah = allCDMCodes.CDMCodes[i].Segment;//this is the name of the CDM segment in the codelist, not the message segment. So on for the rest of them.
                                string rah = allCDMCodes.CDMCodes[i].Field;
                                string gah = allCDMCodes.CDMCodes[i].Component;
                                string vah = allCDMCodes.CDMCodes[i].CodeValue;
                                i++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("there has been an exception in Form2.cs:" + ex.Message);
                            }
                        i++;*/
                        //--------------------------------------------
                    }
                }
        }

        public void GetFieldList()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())

            {
                if (connection == null)
                {
                    Console.WriteLine("Faily connection.");
                    Console.ReadLine();
                    return;
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Faily command.");
                    Console.ReadLine();
                    return;
                }

                command.Connection = connection;

                if (validCMMCodesQuery != "x")
                {
                    command.CommandText = validCMMCodesQuery;
                }
                else
                {
                    command.CommandText = fieldsToValidateQuery;
                }

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    try
                    {
                        while (dataReader.Read() == !false)
                        {
                            //--------------fill a list with the codes to validate
                            CDMCode x = new CDMCode();
                            x.Segment = dataReader["Segment"].ToString();
                            x.Field = dataReader["Field"].ToString();
                            x.Component = dataReader["Subfield"].ToString();
                            //x.CodeValue = dataReader["CMMValue"].ToString();
                            fieldsToValidateList.Add(x);
                        };
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message.ToString());
                        Console.WriteLine("catch");
                    }
                    finally
                    {
                        //call this if exception occurs or not
                        //in this example, dispose the WebClient
                        Console.WriteLine("Finally.");
                    }
                }
                Console.ReadLine();

            }
        }
    }

    
}
