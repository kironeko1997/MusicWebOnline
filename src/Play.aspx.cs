using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace MusicWebOnline
{
    public partial class Play : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        MusicDAL musicDAL = new MusicDAL();
        CasiDAL casiDAL = new CasiDAL();
        TheLoaiDAL theLoaiDAL = new TheLoaiDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                playnhac();
                Tenbaihat();
            }
        }

        public void playnhac()
        {
            string M = "";
            if (Request.QueryString.HasKeys())
            {
                M = Request.QueryString["M"].ToString();
                var music = musicDAL.GetMusicByMaBaiHat(Convert.ToInt32(M));
                music.LuotXem++;
                musicDAL.UpdateMusic(music);
                string tencakhuc = music.TenFile;
                string song_url = "/AudioPlayer/audio/" + tencakhuc;
                data.closeDB();
                Play__.InnerHtml = "<audio preload='auto' controls><source src='" + song_url + "'></audio>	";
                Play__.InnerHtml += "<script src='/AudioPlayer/js/jquery.js'></script>";
                Play__.InnerHtml += "<script src='/AudioPlayer/js/audioplayer.js'></script>";
                Play__.InnerHtml += "<script>$(function () { $('audio').audioPlayer(); });</script>";
            }
        }

        public void Tenbaihat()
        {
            string M = null;
            if (Request.QueryString.HasKeys())
            {
                M = Request.QueryString["M"].ToString();
                var music = musicDAL.GetMusicByMaBaiHat(Convert.ToInt32(M));
                var casi = casiDAL.GetCasiByMaCasi(music.MaCaSi.Value);
                var theLoai = theLoaiDAL.GetTheLoaiByMaTheLoai(music.MaTheLoai.Value);
                lblTenCaKhuc.Text = music.TenBaiHat;
                lblCasy.Text = casi.TenCaSi;
                lblTheLoai.Text = theLoai.TenTheLoai;
                Lab_casi.Text = casi.TenCaSi;                
                baihatlienquan(casi.MaCasi.ToString());
            }
        }
        public void baihatlienquan(string macasi)
        {
            string sql = "select * from Music,Casi,TheLoai where Casi.MaCaSi=Music.MaCaSi and Music.MaTheLoai=TheLoai.MaTheLoai and Casi.MaCaSi ='" + macasi + "' order by LuotXem desc";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Music__.DataSource = ds;
            Music__.DataBind();
            data.closeDB();
        }

    }
}