﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ReadCard
{
    public partial class Form1 : Form
    {
        private bool isCorrectEmployee;
        private string scardTemp;

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

        #region Database Connection
        //数据连接最基本需要的两个对象
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        //private SqlDataAdapter adapter = null;
        //为了方便，设为全局对象的sql语句
        private string sql = null;
        //公用 打开数据库的方法
        private const string ConnString = "Data Source=192.168.20.3;Initial Catalog=PostekDB;UID=Bostonhsu;Password=sa";

        public void openDatabase()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConnString;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                //Response.Write("<script>alert('Connected!');</script>");
            }
        }
        //默认加载页面的方法 找到年龄最大的加载
        //有些问题，年龄不能相同，加载中前台的textbox里只能显示一条记录，数据拿到之后有多条只显示一条
        public void load()
        {
            //openDatabase();
            //cmd = new SqlCommand("select * from users where age=(select max(age) from users)", conn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    tbName.Text = (String)dr[1].ToString().Trim();
            //    tbAge.Text = (String)dr[2].ToString().Trim();
            //}
            //conn.Close();
        }
        //根据sql语句加载信息，重载两个textbox
        public void load(String sql)
        {
            //openDatabase();
            //cmd = new SqlCommand(sql, conn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    tbName.Text = (String)dr[1].ToString().Trim();
            //    tbAge.Text = (String)dr[2].ToString().Trim();
            //}
            //conn.Close();
        }
        //封装的数据库语句执行的方法
        public void execute(String sql)
        {
            openDatabase();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
#endregion

        public Form1()
        {
            InitializeComponent();
            isCorrectEmployee = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;
            btnRecard.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)  // open serial port
        {
            icdev = rf_init(2, 115200);
            if (icdev > 0)
            {
                listBox1.Items.Add("打开成功:" + Convert.ToString(icdev));
                rf_beep(icdev, 3);
                button1.Enabled = false;
                button2.Enabled = true;
                button4.Enabled = true;
                btnRecard.Enabled = true;
            }
            else
            {
                listBox1.Items.Add("打开失败:" + Convert.ToString(icdev));
            }
        }

        private void button2_Click(object sender, EventArgs e)      // Read Poscard
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
            scardTemp = scardcode;
            listBox1.Items.Add("读卡成功:" + scardcode);
            confirmEmployee(scardcode);
            listBox1.TopIndex = listBox1.Items.Count - (int)(listBox1.Height / listBox1.ItemHeight);
            rf_beep(icdev, 15);
            DateTime searchDateTime = DateTime.Now;
            int searchBanCi = getBanCi(searchDateTime);
            //MessageBox.Show("1. " + searchDateTime.ToString("d") + "\n2. " + searchBanCi.ToString());
            ClearLstPersonalTaskContents();
            SearchPersonalTask(searchDateTime, searchBanCi);
        }

        private void SearchPersonalTask(DateTime searchDateTime, int searchBanCi)
        {
            
        }

        private void ClearLstPersonalTaskContents()
        {
            lstPersonalTask.Items.Clear();
        }

        private int getBanCi(DateTime searchDateTime)
        {
            return 1;
        }

        private void confirmEmployee(string scardcode)
        {
            // 把种类描述列在这里。
            //初始化一个数据集 
            DataSet DataTemp = new DataSet();
            //初始化一个连接集 
            SqlConnection _objCon = new SqlConnection(ConnString);
            //打开连接 
            _objCon.Open();
            //做一个连接器 
            SqlDataAdapter _myAdapter;
            scardcode = "0072512388";
            scardTemp = scardcode;
            string queryStr = "SELECT BS_ACCO_INFO.ACCO_STUD_CODE, BS_ACCO_INFO.ACCO_NAME FROM BS_ACCO_INFO inner join BS_ACCO_CARD ON BS_ACCO_INFO.ACCO_ID = BS_ACCO_CARD.CARD_ACCO_ID WHERE(CARD_CODE = '" + scardcode + "' and CARD_STATE=1)";
            _myAdapter = new SqlDataAdapter(queryStr, _objCon);
            //创建增删改查command对象 
            SqlCommandBuilder sqlCommand = new SqlCommandBuilder(_myAdapter);
            //将数据库中的数据填充到数据集的表中,设置表名 
            _myAdapter.Fill(DataTemp, "temp");

            try
            {
                if (DataTemp.Tables[0].Rows.Count > 0)
                {
                    isCorrectEmployee = true;
                    txtName.Text = DataTemp.Tables[0].Rows[0][1].ToString();
                    txtMenjin.Text = DataTemp.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
            }

            sqlCommand.Dispose();
            _myAdapter.Dispose();
            _objCon.Close();
            _objCon.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)      // Close serial port
        {
            rf_exit(icdev);
            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;
            btnRecard.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rf_beep(icdev, 10);
        }

        private void btnRecard_Click(object sender, EventArgs e)
        {
            if (isCorrectEmployee)
            {
                saveEmployeeToDB();
                isCorrectEmployee = false;
                MessageBox.Show("添加员工：" + txtName.Text.Trim() + "， 成功。");
                clearTextBoxContent();
            }
        }

        private void clearTextBoxContent()
        {
            txtName.Text = "";
            txtMenjin.Text = "";
        }

        private void saveEmployeeToDB()
        {
            //初始化一个数据集 
            DataSet DataTemp = new DataSet();
            //初始化一个连接集 
            SqlConnection _objCon = new SqlConnection(ConnString);
            //打开连接 
            _objCon.Open();
            //做一个连接器 
            SqlDataAdapter _myAdapter;
            string temp = "insert into Temp_BostonHsu (Name, ScardCode, MenjinCode) values ('" + txtName.Text.Trim() + "', '" + scardTemp + "', '" + txtMenjin.Text.Trim() + "')";
            _myAdapter = new SqlDataAdapter(temp, _objCon);
            //创建增删改查command对象 
            SqlCommandBuilder sqlCommand = new SqlCommandBuilder(_myAdapter);
            //将数据库中的数据填充到数据集的表中,设置表名 
            _myAdapter.Fill(DataTemp, "temp");

            sqlCommand.Dispose();
            _myAdapter.Dispose();
            _objCon.Close();
            _objCon.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isCorrectEmployee = true;
            confirmEmployee("");
            btnRecard_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 把种类描述列在这里。
            //初始化一个数据集 
            DataSet DataTemp = new DataSet();
            DataSet DataTemp1 = new DataSet();
            DataSet DataTemp2 = new DataSet();
            //初始化一个连接集 
            SqlConnection _objCon = new SqlConnection(ConnString);
            //打开连接 
            _objCon.Open();
            //做一个连接器 
            SqlDataAdapter _myAdapter;
            SqlDataAdapter _myAdapter1;
            //scardcode = "1210875902";
            //scardTemp = scardcode;
            string tempString = "select CARD_CODE from BS_ACCO_CARD where CARD_STATE=1";
            _myAdapter1 = new SqlDataAdapter(tempString, _objCon);
            SqlCommandBuilder sqlCommand1 = new SqlCommandBuilder(_myAdapter1);
            _myAdapter1.Fill(DataTemp1, "temp");

            for (int i = 0; i < DataTemp1.Tables[0].Rows.Count; i++)
            {
                string queryStr = "SELECT BS_ACCO_INFO.ACCO_STUD_CODE, BS_ACCO_INFO.ACCO_NAME, BS_ACCO_CARD.CARD_CODE FROM BS_ACCO_INFO inner join BS_ACCO_CARD ON BS_ACCO_INFO.ACCO_ID = BS_ACCO_CARD.CARD_ACCO_ID WHERE(CARD_CODE = '" + DataTemp1.Tables[0].Rows[i][0].ToString() + "' and CARD_STATE=1)";
                _myAdapter = new SqlDataAdapter(queryStr, _objCon);
                SqlCommandBuilder sqlCommand = new SqlCommandBuilder(_myAdapter);
                SqlCommandBuilder sqlCommandTemp;
                _myAdapter.Fill(DataTemp, "temp");
                if (DataTemp.Tables[0].Rows.Count > 1)
                {
                    for (int j = 0; j < DataTemp.Tables[0].Rows.Count; j++)
                    {
                        string insertStr = "insert into Temp_Chongfu (Name, ScardCode, MenjinCode) values ('" + DataTemp.Tables[0].Rows[j][1].ToString() + "', '" + DataTemp.Tables[0].Rows[j][2].ToString() + "', '" + DataTemp.Tables[0].Rows[j][0].ToString() + "')";
                        _myAdapter = new SqlDataAdapter(insertStr, _objCon);
                        sqlCommandTemp = new SqlCommandBuilder(_myAdapter);
                        _myAdapter.Fill(DataTemp2, "temp");
                        DataTemp2.Clear();
                    }
                    
                }
                DataTemp.Clear();
            }

            _objCon.Close();
            _objCon.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmYangYouGang aFrmYangYouGang = new FrmYangYouGang();
            aFrmYangYouGang.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitCombo();
        }

        private void InitCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            DataRow dr1 = dt.NewRow();
            DataRow dr2 = dt.NewRow();
            DataRow dr3 = dt.NewRow();
            dr1["Text"] = "1-白班";
            dr1["Value"] = "1";
            dr2["Text"] = "2-夜班";
            dr2["Value"] = "2";
            dr3["Text"] = "3-早班";
            dr3["Value"] = "3";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            cbBanCi.DataSource = dt;
            cbBanCi.DisplayMember = "Text";
            cbBanCi.ValueMember = "Value";
            cbBanCi.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmXiuMu aFrmXiuMu = new FrmXiuMu();
            aFrmXiuMu.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmLaJian aFrmLaJian = new FrmLaJian();
            aFrmLaJian.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmZhiGao aFrmLaJian = new FrmZhiGao();
            aFrmLaJian.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmHanJingLiPaiChan aFrmHanJingLiPaiChan = new FrmHanJingLiPaiChan();
            aFrmHanJingLiPaiChan.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            temp aTemp = new temp();
            aTemp.Show();
        }
    }
}
