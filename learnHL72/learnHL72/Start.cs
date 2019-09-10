using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace learnHL72
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "Excel Files| *.xls; *.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCDMCodeFile.Text = openFileDialog1.FileName;//todo: redact text with elipsis
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "Excel Files| *.xls; *.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtHL7MessageFile.Text = openFileDialog1.FileName;//todo: redact text with elipsis
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            string cdmFilename = txtCDMCodeFile.Text;
            string HL7FileName = txtHL7MessageFile.Text;
            string f = File.ReadAllText(HL7FileName);
            MessageSample messageSample = new MessageSample(f);
            
            string[] c = File.ReadAllLines(cdmFilename);
            AllCDMCodes allCDMCodes = new AllCDMCodes(c);
            List<string> cdmCodes = allCDMCodes.SegmentsInCDM();//TODO: refactor as a member variable

            #region Call the validation processes here
            foreach (HL7Message message in messageSample)

                foreach (Segment s in message)
                {
                    string segName = s.value.Substring(0, 3);
                    int i = 0;
                    if (cdmCodes.Contains(segName))

                        try
                        {
                            //The message segment in question is under review
                            string wah = s.Fields[i].value;//debug
                            i++;//debug
                            string rah = s.Fields[i].value;//debug
                            i++;//debug
                            string fee = s.Fields[i].value;//debug
                            i++;//debug
                            string boo = s.Fields[i].SubFields[0].value;//debug
                            i++;//debug
                            string bru = s.Fields[i].value;//debug
                            i++;//debug
                            string wan = s.Fields[i].value;//debug
                            i++;//debug
                            string gak = s.Fields[i].value;//debug
                            i++;//debug
                            string wak = s.Fields[i].value;//debug
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("there has been an exception in Form2.cs:" + ex.Message);
                        }
                    i++;
                    } 
            #endregion
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
