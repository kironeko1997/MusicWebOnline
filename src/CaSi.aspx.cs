using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebOnline
{
    public partial class Casi : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        CasiDAL casiDAL = new CasiDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            videomp4();
            HienDSNhacofCasy();
            casi();
        }

        public void videomp4()
        {
            if (Request.QueryString["L"] != null)
            {
                string macasi = Request.QueryString["L"].ToString();
                string sql = "select * from Video,Casi,TheLoai where Casi.MaCaSi=Video.MaCaSi and Video.MaTheLoai=TheLoai.MaTheLoai and Casi.MaCaSi='" + macasi + "'";
                data.connDB();
                SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Video__.DataSource = ds;
                Video__.DataBind();
                data.closeDB();
            }
        }
        public void HienDSNhacofCasy()
        {
            if (Request.QueryString["L"] != null)
            {
                string macasi = Request.QueryString["L"].ToString();
                string sql = "select * from Music,Casi,TheLoai where Casi.MaCaSi=Music.MaCaSi and Music.MaTheLoai=TheLoai.MaTheLoai and Casi.MaCaSi='" + macasi + "'";
                data.connDB();
                SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataList1.DataSource = ds;
                DataList1.DataBind();
                data.closeDB();
            }
        }
        public void casi()
        {
            if (Request.QueryString["L"] != null)
            {
                var casi = casiDAL.GetAllCasi().Where(x => x.MaCasi.ToString() == Request.QueryString["L"]);
                NgheSi__.DataSource = casi;
                NgheSi__.DataBind();
            }
        }
    }
}