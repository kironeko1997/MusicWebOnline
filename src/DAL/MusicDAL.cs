using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicWebOnline
{
    public class MusicDAL : DAL
    {
        DataConnection dc = new DataConnection();

        public List<Music> GetAllMusic()
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetAllMusic", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Music> list = new List<Music>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Music music = new Music();
                    music.MaBaiHat = Convert.ToInt32(dr["MaBaiHat"].ToString());
                    music.MaTheLoai = dr["MaTheLoai"].ToString() != "" ? Convert.ToInt32(dr["MaTheLoai"].ToString()) : (dynamic)null;
                    music.MaNhacSi = dr["MaNhacSi"].ToString() != "" ? Convert.ToInt32(dr["MaNhacSi"].ToString()) : (dynamic)null;
                    music.MaCaSi = dr["MaCaSi"].ToString() != "" ? Convert.ToInt32(dr["MaCaSi"].ToString()) : (dynamic)null;
                    music.MaAlbum = dr["MaAlbum"].ToString() != "" ? Convert.ToInt32(dr["MaAlbum"].ToString()) : (dynamic)null;
                    music.TenBaiHat = dr["TenBaiHat"].ToString();
                    music.TenKhongDau = dr["TenKhongDau"].ToString();
                    music.TenFile = dr["TenFile"].ToString();
                    music.NoiDung = dr["NoiDung"].ToString();
                    music.NgayDang = dr["NgayDang"].ToString() != "" ? Convert.ToDateTime(dr["NgayDang"].ToString()) : (dynamic)null;
                    music.LuotXem = dr["LuotXem"].ToString() != "" ? Convert.ToInt32(dr["LuotXem"].ToString()) : (dynamic)null;
                    list.Add(music);
                }
            }
            dc.closeDB();

            return list;
        }

        public Music GetMusicByMaBaiHat(int maBaiHat)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetMusicByMaBaiHat", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaBaiHat;
            paramMaBaiHat = new SqlParameter()
            {
                ParameterName = "@MaBaiHat",
                DbType = DbType.Int32,
                Value = maBaiHat
            };
            cmd.Parameters.AddRange(new[] { paramMaBaiHat });
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Music music = new Music();
            if (ds.Tables[0].Rows.Count > 0)
            {
                music.MaBaiHat = Convert.ToInt32(ds.Tables[0].Rows[0]["MaBaiHat"].ToString());
                music.MaTheLoai = ds.Tables[0].Rows[0]["MaTheLoai"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaTheLoai"].ToString()) : (dynamic)null;
                music.MaNhacSi = ds.Tables[0].Rows[0]["MaNhacSi"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaNhacSi"].ToString()) : (dynamic)null;
                music.MaCaSi = ds.Tables[0].Rows[0]["MaCaSi"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaCaSi"].ToString()) : (dynamic)null;
                music.MaAlbum = ds.Tables[0].Rows[0]["MaAlbum"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaAlbum"].ToString()) : (dynamic)null;
                music.TenBaiHat = ds.Tables[0].Rows[0]["TenBaiHat"].ToString();
                music.TenKhongDau = ds.Tables[0].Rows[0]["TenKhongDau"].ToString();
                music.TenFile = ds.Tables[0].Rows[0]["TenFile"].ToString();
                music.NoiDung = ds.Tables[0].Rows[0]["NoiDung"].ToString();
                music.NgayDang = ds.Tables[0].Rows[0]["NgayDang"].ToString() != "" ? Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayDang"].ToString()) : (dynamic)null;
                music.LuotXem = ds.Tables[0].Rows[0]["LuotXem"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["LuotXem"].ToString()) : (dynamic)null;
            }
            dc.closeDB();

            return music;
        }

        public void InsertMusic(Music music)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("InsertMusic", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaTheLoai, paramMaNhacSi, paramMaCaSi, paramMaAlbum, paramTenBaiHat, paramTenKhongDau, paramTenFile, paramNoiDung, paramNgayDang, paramLuotXem;
            paramMaTheLoai = new SqlParameter()
            {
                ParameterName = "@MaTheLoai",
                DbType = DbType.Int32,
                Value = music.MaTheLoai
            };
            paramMaNhacSi = new SqlParameter()
            {
                ParameterName = "@MaNhacSi",
                DbType = DbType.Int32,
                Value = ToDBNull(music.MaNhacSi)
            };
            paramMaCaSi = new SqlParameter()
            {
                ParameterName = "@MaCaSi",
                DbType = DbType.Int32,
                Value = ToDBNull(music.MaCaSi)
            };
            paramMaAlbum = new SqlParameter()
            {
                ParameterName = "@MaAlbum",
                DbType = DbType.Int32,
                Value = ToDBNull(music.MaAlbum)
            };
            paramTenBaiHat = new SqlParameter()
            {
                ParameterName = "@TenBaiHat",
                DbType = DbType.String,
                Value = ToDBNull(music.TenBaiHat)
            };
            paramTenKhongDau = new SqlParameter()
            {
                ParameterName = "@TenKhongDau",
                DbType = DbType.String,
                Value = ToDBNull(music.TenKhongDau)
            };
            paramTenFile = new SqlParameter()
            {
                ParameterName = "@TenFile",
                DbType = DbType.String,
                Value = ToDBNull(music.TenFile)
            };
            paramNoiDung = new SqlParameter()
            {
                ParameterName = "@NoiDung",
                DbType = DbType.String,
                Value = ToDBNull(music.NoiDung)
            };
            paramNgayDang = new SqlParameter()
            {
                ParameterName = "@NgayDang",
                DbType = DbType.DateTime,
                Value = ToDBNull(music.NgayDang)
            };
            paramLuotXem = new SqlParameter()
            {
                ParameterName = "@LuotXem",
                DbType = DbType.Int32,
                Value = ToDBNull(music.LuotXem)
            };
            cmd.Parameters.AddRange(new[] { paramMaTheLoai, paramMaNhacSi, paramMaCaSi, paramMaAlbum, paramTenBaiHat, paramTenKhongDau, paramTenFile, paramNoiDung, paramNgayDang, paramLuotXem });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void UpdateMusic(Music music)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("UpdateMusic", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaBaiHat, paramMaTheLoai, paramMaNhacSi, paramMaCaSi, paramMaAlbum, paramTenBaiHat, paramTenKhongDau, paramTenFile, paramNoiDung, paramNgayDang, paramLuotXem;
            paramMaBaiHat = new SqlParameter()
            {
                ParameterName = "@MaBaiHat",
                DbType = DbType.Int32,
                Value = music.MaBaiHat
            };
            paramMaTheLoai = new SqlParameter()
            {
                ParameterName = "@MaTheLoai",
                DbType = DbType.Int32,
                Value = music.MaTheLoai
            };
            paramMaNhacSi = new SqlParameter()
            {
                ParameterName = "@MaNhacSi",
                DbType = DbType.Int32,
                Value = ToDBNull(music.MaNhacSi)
            };
            paramMaCaSi = new SqlParameter()
            {
                ParameterName = "@MaCaSi",
                DbType = DbType.Int32,
                Value = ToDBNull(music.MaCaSi)
            };
            paramMaAlbum = new SqlParameter()
            {
                ParameterName = "@MaAlbum",
                DbType = DbType.Int32,
                Value = ToDBNull(music.MaAlbum)
            };
            paramTenBaiHat = new SqlParameter()
            {
                ParameterName = "@TenBaiHat",
                DbType = DbType.String,
                Value = ToDBNull(music.TenBaiHat)
            };
            paramTenKhongDau = new SqlParameter()
            {
                ParameterName = "@TenKhongDau",
                DbType = DbType.String,
                Value = ToDBNull(music.TenKhongDau)
            };
            paramTenFile = new SqlParameter()
            {
                ParameterName = "@TenFile",
                DbType = DbType.String,
                Value = ToDBNull(music.TenFile)
            };
            paramNoiDung = new SqlParameter()
            {
                ParameterName = "@NoiDung",
                DbType = DbType.String,
                Value = ToDBNull(music.NoiDung)
            };
            paramNgayDang = new SqlParameter()
            {
                ParameterName = "@NgayDang",
                DbType = DbType.DateTime,
                Value = ToDBNull(music.NgayDang)
            };
            paramLuotXem = new SqlParameter()
            {
                ParameterName = "@LuotXem",
                DbType = DbType.Int32,
                Value = ToDBNull(music.LuotXem)
            };
            cmd.Parameters.AddRange(new[] { paramMaBaiHat, paramMaTheLoai, paramMaNhacSi, paramMaCaSi, paramMaAlbum, paramTenBaiHat, paramTenKhongDau, paramTenFile, paramNoiDung, paramNgayDang, paramLuotXem });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void DeleteMusic(Music music)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("DeleteMusic", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaBaiHat;
            paramMaBaiHat = new SqlParameter()
            {
                ParameterName = "@MaBaiHat",
                DbType = DbType.Int32,
                Value = music.MaBaiHat
            };
            cmd.Parameters.AddRange(new[] { paramMaBaiHat });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }
    }
}