using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
        private string CMMFieldsQuery = "select distinct Segment, Field, Subfield from dbo.CMMCodes order by Segment, Field, Subfield";
        private List<CDMCode> fieldsToValidateList;
        private List<CDMCode> validCMMCodesList;

        //Constructor
        public Assertion(HL7Message msg, AllCDMCodes acs)
        {
            DataSet wah = GetCMM();
            foreach (Segment s in msg)
            {
                //TODO: loop through the segment and get the field from the list of CDM codes
                foreach (Field f in s)
                {
                    string segName = s.value.Substring(0, 3);

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
                }
            }
        }

        public DataSet GetCMM()
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(CMMFieldsQuery, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // this will query your database and return the result to your datatable
            DataSet CMMdataSet = new DataSet();
            da.Fill(CMMdataSet);
            conn.Close();
            da.Dispose();
            Console.WriteLine(CMMdataSet.GetXml());
            return CMMdataSet;
        }
    }
}
