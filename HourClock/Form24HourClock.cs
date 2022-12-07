using System;
using System.IO;
using System.Windows.Forms;

namespace HourClock
{
    public partial class Form24HourClock : Form
    {
        public Form24HourClock()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\clock.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    TxtResult.Text += ConvertTo12HourClock(line) + Environment.NewLine;
                }
            }
        }

        private string ConvertTo12HourClock(string time)
        {
            string hour = time.Substring(0, time.IndexOf(':'));
            string min = time.Substring(time.IndexOf(':') + 1);

            string result = "";

            int h = Convert.ToInt32(hour);

            if (h >= 13)
            {
                for (int i = 12; i <= 24; i++)
                {
                    if (h == i)
                    {
                        h = h - 12;
                        result = "0" + h + ":" + min + " PM";
                    }
                }
            }
            else if (h == 12)
            {
                result = time + " PM";
            }
            else
            {
                result =  time + " AM";
            }

            return result;
        }
    }
}
