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
    }
}
