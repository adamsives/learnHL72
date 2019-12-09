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
        private int i = 0;//this will take you to the cdm code value (seg,field,subfield,value)
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
                txtCDMCodeFile.Text = openFileDialog1.FileName;//todo: redact text display with elipsis
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
            foreach (HL7Message message in messageSample) {

                Assertion a = new Assertion(message, allCDMCodes);

            }
                //in a OneOf() method compare Assert.HL7Message.component.OneOf();


            #endregion
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
