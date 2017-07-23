using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReadCard
{
    public partial class temp : Form
    {
        #region Database Connection
        //数据连接最基本需要的两个对象
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        //private SqlDataAdapter adapter = null;
        //为了方便，设为全局对象的sql语句
        private string sql = null;
        //公用 打开数据库的方法
        private const string ConnString = "Data Source=192.168.1.6;Initial Catalog=Test123;UID=Bostonhsu;Password=sa";

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

        public temp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet DataTemp = new DataSet();
            //初始化一个连接集 
            SqlConnection _objCon = new SqlConnection(ConnString);
            //打开连接 
            _objCon.Open();
            //做一个连接器 
            SqlDataAdapter _myAdapter;
            string queryStr = "select * from person where Sex = 2";
            _myAdapter = new SqlDataAdapter(queryStr, _objCon);
            //创建增删改查command对象 
            SqlCommandBuilder sqlCommand = new SqlCommandBuilder(_myAdapter);
            //将数据库中的数据填充到数据集的表中,设置表名 
            _myAdapter.Fill(DataTemp, "temp");

            try
            {
                if (DataTemp.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < DataTemp.Tables[0].Rows.Count; i++)
                    {
                        listBox1.Items.Add(DataTemp.Tables[0].Rows[i][1].ToString());
                    }
















                    
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
    }
}
