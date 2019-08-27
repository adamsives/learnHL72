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
                AllCDMCodes allCDMCodes = new AllCDMCodes();
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

            //string x = "debug";
            //HL7Message h = new HL7Message(x);//---------------------------------------------debug

            /*string wah = h.Segments[0].Fields[0].Subfields[0].SubSubfields[0].ToString();
            string boo = h.Segments[0].Fields[0].Subfields[0].ToString();
            string res = h.Segments[0].Fields[0].ToString();
            string bla = h.Segments[0].ToString();
            string pez = h.Segments[0].*/

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
            //if txtCDM and txtHL7Codes contain valid files
            string cdmFilename = txtCDMCodeFile.Text;
            string HL7FileName = txtHL7MessageFile.Text;
            string f = File.ReadAllText(HL7FileName);
            MessageSample messageSample = new MessageSample(f);

            //MessageBox.Show(messageSample.HL7Messages[0].Segments[0].

            foreach (HL7Message ms in messageSample) {
                MessageBox.Show("wah");
                MessageBox.Show(ms.Segments[0].ToString());
            }

            #region Call the validation processes here
            foreach (string message in messageSample)
            {
                //HL7Message hl7msg = new HL7Message(message) { Segments = new List<Segment>};
                Console.WriteLine("debug");
                //---------------------------SO answer
/*
                var myMessage = new HL7Message(message)
                {
                    Segments = new List<Segment>()
                {
                   new Segment()
                   {
                      Name = "PID",
                      Fields = new List<Field>()
                         {
                            new Field()
                            {
                               Name = "SomeField",
                               Fields = new List<Field>()
                                  {
                                     new Field()
                                     {
                                        Name = "SomeSubField",
                                        Fields = new List<Field>()
                                           {
                                              new Field()
                                              {
                                                 Name = "SomeSubSubField",
                                              }
                                           }
                                     }
                                  }
                            }
                         }
                   }
                }
                };*/
                //--------------------------


                try
                {
                    /*foreach (string segment in message)
                    {
                        string segmentType = segment.ToString().Substring(0, 3);
                        //gererate HL7Validator.validate(segment,segment.Substring(0, 3),cdmFilename,HL7FileName)
                        //todo: construct message header to include in report
                        //todo: supply names and ID as well for human readability of the report
                        HL7Validator v = new HL7Validator();//todo:pass a HL7 message
                        v.Validate(segment, segmentType, cdmFilename);
                    }*/
                }
                catch (Exception ex)
                {

                    Console.WriteLine("there has been an exception in Form2.cs:" + ex.Message);
                }
            }
            #endregion
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
