using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SerialPort port;

        public Form1()
        {
            InitializeComponent();

            String[] ports = SerialPort.GetPortNames();
            foreach (String s in ports)
            {
                portsBox.Items.Add(s);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text != "Disconnect")
            {
                string selectedPort = portsBox.SelectedItem.ToString();
                port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                port.DataReceived += SerialPortDataReceived;
                port.Open();
                port.Write("!25\n");
                connectButton.Text = "Disconnect";
            } else
            {
                port.Write("?\n");
                port.Close();
                connectButton.Text = "Connect";
            }
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort p = (SerialPort)sender;
            //numberLabel.Text = p.ReadExisting();
        }
    }


}
