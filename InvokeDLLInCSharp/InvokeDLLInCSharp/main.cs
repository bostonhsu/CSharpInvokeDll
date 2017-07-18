using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvokeDLLInCSharp
{
    public partial class main : Form
    {
        private int icdev;

        public main()
        {
            InitializeComponent();
        }

        private void btnDoTest_Click(object sender, EventArgs e)
        {
            InvokeDLL();
        }

        private void InvokeDLL()
        {
            int result = CppDll.Add(1, 3);
            int x = 4;
            double y = 2;
            CppDll.Pow(ref x, y);
            Console.WriteLine("The result: " + result + ", " + x);
        }

        private void btnInitialReader_Click(object sender, EventArgs e)
        {
            icdev = PoscardReader.rf_init(2, 115200);
            //MessageBox.Show(icdev.ToString());
            //short serialNumber = short.Parse(txtSerialNumber.Text.Trim());
            //long baud = long.Parse("9600");
            //icdev = PoscardReader.rf_init(Int16.Parse("3"), baud);
            //MessageBox.Show("icdev: " + icdev);
            MessageBox.Show(icdev.ToString());
        }

        private void btnReading_Click(object sender, EventArgs e)
        {
            //ulong serialNumberResult = 0;
            //var status = PoscardReader.rf_card(icdev, byte.Parse("0"), ref serialNumberResult);
            //MessageBox.Show("The Serial No. is: " + serialNumberResult + ", status: " + status);
            //status = PoscardReader.rf_halt(icdev);

            //int result = PoscardReader.rf_beep(icdev, uint.Parse("200"));
            UInt32 kahao;
            PoscardReader.rf_card(icdev, 1, out kahao);
            MessageBox.Show(kahao.ToString());

            //UInt16 TagType = 0;
            //byte st = byte.MinValue;
            //st = PoscardReader.rf_request(icdev, 1, ref TagType);
            //MessageBox.Show(st.ToString());
            //if (st != 0)
            //{
            //    MessageBox.Show("寻卡失败");
            //    return;
            //}

        }

        private void btnCloseReader_Click(object sender, EventArgs e)
        {
            PoscardReader.rf_exit(icdev);
        }
    }
}
