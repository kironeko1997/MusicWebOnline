using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MusicWebOnline.Control
{
    public partial class Casi : System.Web.UI.UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=KIRO\SQLEXPRESS;Initial Catalog=Musicweb2;User ID=sa;Password=6253362");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadDSCaSi();
            }
        }

        public void loadDSCaSi()
        {
            string sql = "Select * FROM Casi ORDER BY TenCaSi DESC ";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            CaSi__.DataSource = ds;
            CaSi__.DataBind();
            con.Close();
        }
    }
}