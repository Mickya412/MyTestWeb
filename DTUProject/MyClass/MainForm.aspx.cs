using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Data;

namespace DTUProject.MyClass
{
    public partial class MainForm : System.Web.UI.Page
    {
        MySqlConnection conn = CreateConn();

        protected void Page_Load(object sender, EventArgs e)
        {

            //添加新的记录
            //AddNewRecord("34", "68", DateTime.Now.ToString());

            if (!IsPostBack)
            {
                GetDataBind();
            }

            
        }

        //创建与数据库的连接
        public static MySqlConnection CreateConn()
        {
            string _conn = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(_conn);
            return conn;
        }

        //将数据绑定到网页上
        void GetDataBind()
        {
            conn.Open();
            DataSet ds = QueryDataSet("select * from temp");
            GradView1.DataSource = ds;
            GradView1.DataBind();
            conn.Close();
        }

        public DataSet QueryDataSet(string sqlyj)
        {
            //安全处理，拒绝对数据库操作危险的语句，只处理查询操作
            Regex delete = new Regex("delete");
            //转换为小写
            Match deletemat = delete.Match(sqlyj.ToLower());
            if (deletemat.Success)
            {
                sqlyj = "";
            }

            Regex update = new Regex("update");
            Match updatemat = update.Match(sqlyj.ToLower());
            if (updatemat.Success)
            {
                sqlyj = "";
            }

            Regex insert = new Regex("insert");
            Match insertmat = insert.Match(sqlyj.ToLower());
            if (insertmat.Success)
            {
                sqlyj = "";
            }

            Regex database = new Regex("database");
            Match databasemat = database.Match(sqlyj.ToLower());
            if (databasemat.Success)
            {
                sqlyj = "";
            }

            Regex table = new Regex("table");
            Match tablemat = table.Match(sqlyj.ToLower());
            if (tablemat.Success)
            {
                sqlyj = "";
            }

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlyj, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "a6");
            dataAdapter.Dispose();
            return ds;
        }

        void AddNewRecord(string temp, string humidity, string addtime)
        {
            conn.Open();
            string sql = string.Format("insert into temp(temp,humidity,addtime) values ({0},{1},' {2} ');", temp, humidity, addtime);
            MySqlCommand sqlcmd = new MySqlCommand(sql, conn);
            try
            {
                sqlcmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            conn.Close();
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            
            Response.Write(Request.QueryString);
        }
    }
}