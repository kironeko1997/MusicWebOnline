using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebOnline
{
    public partial class master_Home : System.Web.UI.MasterPage
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DangNhap"] == null)
            {
                HyperLink login1 = new HyperLink();
                login1.Text = "Đăng nhập";
                login1.NavigateUrl = "Login.aspx";
                login1.ToolTip = "Đăng nhập";

                HyperLink regester = new HyperLink();
                regester.Text = "Đăng ký";
                regester.NavigateUrl = "Regirter.aspx";
                regester.ToolTip = "Đăng ký";

                Hello.Controls.Add(login1);
                Hello.Controls.Add(regester);
            }
            else
            {
                string Ten = null;
                string select = "select * from UserDaTa where TenDangNhap='" + Session["DangNhap"] + "'";
                data.connDB();
                SqlCommand cmd = new SqlCommand(select, data.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ten = dr["HoTen"].ToString();
                }
                data.closeDB();

                HyperLink Chao = new HyperLink();
                Chao.Text = "Chào : " + Ten;
                Chao.NavigateUrl = "User.aspx";
                Hello.Controls.Add(Chao);


                HyperLink logout = new HyperLink();
                logout.Text = "Đăng Xuất";
                logout.NavigateUrl = "Logout.aspx";
                logout.ToolTip = "Đăng Xuất";
                Hello.Controls.Add(logout);
            }
        }

        public static string ConvertToUnSign(string text)
        {

            for (int i = 32; i < 48; i++)
            {

                text = text.Replace(((char)i).ToString(), " ");

            }
            text = text.Replace(" ", "-");
            text = text.Replace(",", "-");
            text = text.Replace(";", "-");

            text = text.Replace(":", "-");

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        protected void btn_tim_Click(object sender, EventArgs e)
        {
            Session["txtname"] = txt_tim.Text;
            Response.Redirect("Search.aspx?key=" + ConvertToUnSign(txt_tim.Text));
        }
    }
}