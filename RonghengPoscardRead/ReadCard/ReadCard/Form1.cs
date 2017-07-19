using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ReadCard
{
    public partial class Form1 : Form
    {
        public int icdev; // 通讯设备标识符
        public Int16 st;
        [DllImport("mwrf32.dll", EntryPoint = "rf_init", SetLastError = true,
         CharSet = CharSet.Auto, ExactSpelling = false,
         CallingConvention = CallingConvention.StdCall)]
        //说明：初始化通讯接口
        public static extern int rf_init(Int16 port, int baud);

        [DllImport("mwrf32.dll", EntryPoint = "rf_exit", SetLastError = true,
         CharSet = CharSet.Auto, ExactSpelling = false,
         CallingConvention = CallingConvention.StdCall)]
        //说明：    关闭通讯口
        public static extern Int16 rf_exit(int icdev);

        [DllImport("mwrf32.dll", EntryPoint = "rf_beep", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        //说明：     返回设备当前状态
        public static extern Int16 rf_beep(int icdev, int msec);

        [DllImport("mwrf32.dll", EntryPoint = "rf_card", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        //说明：     返回设备当前状态
        public static extern Int16 rf_card(int icdev, int bcnt, out uint snr);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            icdev = rf_init(2, 115200);
            if (icdev > 0)
            {
                listBox1.Items.Add("打开成功:" + Convert.ToString(icdev));
            }
            else
            {
                listBox1.Items.Add("打开失败:" + Convert.ToString(icdev));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint snr = 0;
            st = rf_card(icdev, 0, out snr);
            if (st != 0)
            {
                listBox1.Items.Add("读卡失败:" + Convert.ToString(st));
                return;
            }
            string scardcode = snr.ToString();
            scardcode = scardcode.PadLeft(10, '0');
            listBox1.Items.Add("读卡成功:" + scardcode);            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rf_exit(icdev);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rf_beep(icdev, 10);
        }
    }
}
