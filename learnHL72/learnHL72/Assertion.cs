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
        private string CMMFieldsQuery = "select distinct Segment, Field, Subfield, CMMValue from dbo.CMMCodes order by Segment, Field, Subfield, CMMValue";
        private string CMMSegmentsQuery = "select distinct Segment from dbo.CMMCodes";
         
        //Constructor
        public Assertion(HL7Message msg, AllCDMCodes acs)
        {
            DataTable t = GetCMM();

            foreach (Segment s in msg)
            {
                string segName = s.value.Substring(0, 3);
                Console.WriteLine(segName + " segName");//---------------------------debug
                DataRow[] r = t.Select("Segment = '" + segName + "'");

                if (string.IsNullOrEmpty(r.ToString()))
                {
                    Console.WriteLine("empty");
                }
                else
                {
                    DataRow[] fieldAndSubfields = t.Select("Segment like '" + segName + "'");

                    foreach (DataRow item in fieldAndSubfields)
                    {
                        //get CMM field\subfield values

                        try
                        {
                            if (!string.IsNullOrEmpty(s.Fields[3].value))
                            {//if this field has a value...
                                Console.WriteLine(s.Fields[3].value + " 1 is clearly not null");
                                if (!string.IsNullOrEmpty(s.Fields[3].SubFields[0].value))
                                {
                                    Console.WriteLine(s.Fields[3].SubFields[0].value + " 2 is clearly not null");
                                    if (!string.IsNullOrEmpty(s.Fields[3].SubFields[0].SubSubFields[0].value))
                                    {
                                        Console.WriteLine(s.Fields[3].SubFields[0].SubSubFields[0].value + " 3 is clearly not null");
                                    }
                                }

                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine("ArgumentOutOfRangeException ex");
                        }
                    }
                }
            }
        }

        private DataTable GetCMM()
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(CMMFieldsQuery, conn);
            SqlCommand segmentCmd = new SqlCommand(CMMSegmentsQuery, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            return dataTable;
        }
    }
}
