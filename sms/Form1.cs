using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace sms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SerialPort myport = new SerialPort();

        private void button1_Click(object sender, EventArgs e)
        {
            myport.PortName = "COM12";
            myport.ReadTimeout = 2000;
            myport.DataBits = 8;
            myport.Open();
            myport.Write("AT\r");
            myport.Write("AT+CMGF=1\r");
            System.Threading.Thread.Sleep(1500);

            myport.Write("AT+CMGS=\"" + textBox1.Text + "\"\r\n");
            System.Threading.Thread.Sleep(1500);
            myport.Write(textBox2.Text + "\x1A");
            MessageBox.Show("Message Send Sucessfully!", "Meassage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            myport.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myport.Write("AT+CIMI \r");
            
            

        }
    }
}