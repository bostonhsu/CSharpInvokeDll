using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReadCard
{
    public partial class FrmYangYouGang : Form
    {
        private List<ListBox> listBoxes;

        #region Database Connection
        //数据连接最基本需要的两个对象
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        //private SqlDataAdapter adapter = null;
        //为了方便，设为全局对象的sql语句
        private string sql = null;
        //公用 打开数据库的方法
        private const string ConnString = "Data Source=192.168.15.5;Initial Catalog=PaiChan;UID=Bostonhsu;Password=sa";

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

        public FrmYangYouGang()
        {
            InitializeComponent();
        }

        private void FrmYangYouGang_Load(object sender, EventArgs e)
        {
            InitCombo();
            InitDateTimePicker();
            ComboDataGrids();
        }

        private void ComboDataGrids()
        {
            listBoxes = new List<ListBox>();
            for (int i = 0; i < 20; i++)
            {
                listBoxes.Add((ListBox)Controls.Find("listBox" + (i + 1), false)[0]);
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(listBoxes[i].Name);
            }
        }

        private void InitDateTimePicker()
        {
            dtpRiQi.Value = DateTime.Now;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime searchDateTime = new DateTime();
            int searchBanCi = 1;
            getSearchValue(ref searchDateTime, ref searchBanCi);
            //MessageBox.Show("1. " + searchDateTime.ToString("d") + "\n2. " + searchBanCi.ToString());
            ClearListBoxesContents();
            SearchTasksYaLa(searchDateTime, searchBanCi);
        }

        private void SearchTasksYaLa(DateTime searchDateTime, int searchBanCi)
        {
            DataSet DataTemp = new DataSet();
            SqlConnection _objCon = new SqlConnection(ConnString);
            _objCon.Open();
            SqlDataAdapter _myAdapter;
            for (int i = 0; i < 20; i++)
            {
                string queryStr = "select HeTongHao, GongDanHao, RiDanType, RiDanJianShu from RiDanDetail where RiDanRiQi = '" + searchDateTime.ToString("d") + "' and GongWeiHao = " + (i + 1) + " and RiDanBanCi = " + searchBanCi;
                _myAdapter = new SqlDataAdapter(queryStr, _objCon);
                SqlCommandBuilder sqlCommand = new SqlCommandBuilder(_myAdapter);
                _myAdapter.Fill(DataTemp, "temp" + i);

                try
                {
                    if (DataTemp.Tables["temp" + i].Rows.Count > 0)
                    {
                        int j = 0;
                        foreach (DataRow aRow in DataTemp.Tables["temp" + i].Rows)
                        {
                            listBoxes[i].Items.Add("任务" + (j + 1));
                            listBoxes[i].Items.Add("合同号：" + aRow[0].ToString());
                            listBoxes[i].Items.Add("工单号：" + aRow[1].ToString());
                            listBoxes[i].Items.Add("产品名称：" + aRow[2].ToString());
                            listBoxes[i].Items.Add("件数：" + aRow[3].ToString());
                            j++;
                        }
                    }
                    else
                    {
                        listBoxes[i].Items.Add("无任务");
                    }
                }
                catch (Exception)
                {
                }

            }
            _objCon.Close();
            _objCon.Dispose();
        }

        private void ClearListBoxesContents()
        {
            foreach (ListBox listBox in listBoxes)
            {
                listBox.Items.Clear();
            }
        }

        private void getSearchValue(ref DateTime searchDateTime, ref int searchBanCi)
        {
            searchDateTime = dtpRiQi.Value;
            searchBanCi = int.Parse(cbBanCi.SelectedValue.ToString());
        }

        private void listBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
