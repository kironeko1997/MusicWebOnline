using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicWebOnline
{
    public class VideoDAL : DAL
    {
        DataConnection dc = new DataConnection();

        public List<Video> GetAllVideo()
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetAllVideo", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Video> list = new List<Video>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Video video = new Video();
                    video.MaVideo = Convert.ToInt32(dr["MaVideo"].ToString());
                    video.TenVideo = dr["TenVideo"].ToString();
                    video.TenKhongDau = dr["TenKhongDau"].ToString();
                    video.MaCaSi = dr["MaCaSi"].ToString() != "" ? Convert.ToInt32(dr["MaCaSi"].ToString()) : (dynamic)null;
                    video.MaTheLoai = dr["MaTheLoai"].ToString() != "" ? Convert.ToInt32(dr["MaTheLoai"].ToString()) : (dynamic)null;
                    video.TenFile = dr["TenFile"].ToString();
                    video.NgayDang = dr["NgayDang"].ToString() != "" ? Convert.ToInt32(dr["NgayDang"].ToString()) : (dynamic)null;
                    video.Hinh = dr["Hinh"].ToString();
                    video.LuotXem = Convert.ToInt32(dr["LuotXem"].ToString());
                    list.Add(video);
                }
            }
            dc.closeDB();

            return list;
        }

        public Video GetVideoByMaVideo(int maVideo)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetVideoByMaVideo", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaVideo;
            paramMaVideo = new SqlParameter()
            {
                ParameterName = "@MaVideo",
                DbType = DbType.Int32,
                Value = maVideo
            };
            cmd.Parameters.AddRange(new[] { paramMaVideo });
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Video video = new Video();
            if (ds.Tables[0].Rows.Count > 0)
            {
                video.MaVideo = Convert.ToInt32(ds.Tables[0].Rows[0]["MaVideo"].ToString());
                video.TenVideo = ds.Tables[0].Rows[0]["TenVideo"].ToString();
                video.TenKhongDau = ds.Tables[0].Rows[0]["TenKhongDau"].ToString();
                video.MaCaSi = ds.Tables[0].Rows[0]["MaCaSi"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaCaSi"].ToString()) : (dynamic)null;
                video.MaTheLoai = ds.Tables[0].Rows[0]["MaTheLoai"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaTheLoai"].ToString()) : (dynamic)null;
                video.TenFile = ds.Tables[0].Rows[0]["TenFile"].ToString();
                video.NgayDang = ds.Tables[0].Rows[0]["NgayDang"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["NgayDang"].ToString()) : (dynamic)null;
                video.Hinh = ds.Tables[0].Rows[0]["Hinh"].ToString();
                video.LuotXem = Convert.ToInt32(ds.Tables[0].Rows[0]["LuotXem"].ToString());
            }
            dc.closeDB();

            return video;
        }

        public void InsertVideo(Video video)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("InsertVideo", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaVideo, paramTenVideo, paramTenKhongDau, paramMaCaSi, paramMaTheLoai, paramTenFile, paramNgayDang, paramHinh, paramLuotXem;
            paramTenVideo = new SqlParameter()
            {
                ParameterName = "@TenVideo",
                DbType = DbType.String,
                Value = ToDBNull(video.TenVideo)
            };
            paramTenKhongDau = new SqlParameter()
            {
                ParameterName = "@TenKhongDau",
                DbType = DbType.String,
                Value = ToDBNull(video.TenKhongDau)
            };
            paramMaCaSi = new SqlParameter()
            {
                ParameterName = "@MaCaSi",
                DbType = DbType.Int32,
                Value = ToDBNull(video.MaCaSi)
            };
            paramMaTheLoai = new SqlParameter()
            {
                ParameterName = "@MaTheLoai",
                DbType = DbType.Int32,
                Value = ToDBNull(video.MaTheLoai)
            };
            paramTenFile = new SqlParameter()
            {
                ParameterName = "@TenFile",
                DbType = DbType.String,
                Value = ToDBNull(video.TenFile)
            };
            paramNgayDang = new SqlParameter()
            {
                ParameterName = "@NgayDang",
                DbType = DbType.DateTime,
                Value = ToDBNull(video.NgayDang)
            };
            paramHinh = new SqlParameter()
            {
                ParameterName = "@Hinh",
                DbType = DbType.String,
                Value = ToDBNull(video.Hinh)
            };
            paramLuotXem = new SqlParameter()
            {
                ParameterName = "@LuotXem",
                DbType = DbType.Int32,
                Value = video.LuotXem
            };
            cmd.Parameters.AddRange(new[] { paramTenVideo, paramTenKhongDau, paramMaCaSi, paramMaTheLoai, paramTenFile, paramNgayDang, paramHinh, paramLuotXem });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void UpdateVideo(Video video)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("UpdateVideo", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaVideo, paramTenVideo, paramTenKhongDau, paramMaCaSi, paramMaTheLoai, paramTenFile, paramNgayDang, paramHinh, paramLuotXem;
            paramMaVideo = new SqlParameter()
            {
                ParameterName = "@MaVideo",
                DbType = DbType.Int32,
                Value = video.MaVideo
            };
            paramTenVideo = new SqlParameter()
            {
                ParameterName = "@TenVideo",
                DbType = DbType.String,
                Value = ToDBNull(video.TenVideo)
            };
            paramTenKhongDau = new SqlParameter()
            {
                ParameterName = "@TenKhongDau",
                DbType = DbType.String,
                Value = ToDBNull(video.TenKhongDau)
            };
            paramMaCaSi = new SqlParameter()
            {
                ParameterName = "@MaCaSi",
                DbType = DbType.Int32,
                Value = ToDBNull(video.MaCaSi)
            };
            paramMaTheLoai = new SqlParameter()
            {
                ParameterName = "@MaTheLoai",
                DbType = DbType.Int32,
                Value = ToDBNull(video.MaTheLoai)
            };
            paramTenFile = new SqlParameter()
            {
                ParameterName = "@TenFile",
                DbType = DbType.String,
                Value = ToDBNull(video.TenFile)
            };
            paramNgayDang = new SqlParameter()
            {
                ParameterName = "@NgayDang",
                DbType = DbType.DateTime,
                Value = ToDBNull(video.NgayDang)
            };
            paramHinh = new SqlParameter()
            {
                ParameterName = "@Hinh",
                DbType = DbType.String,
                Value = ToDBNull(video.Hinh)
            };
            paramLuotXem = new SqlParameter()
            {
                ParameterName = "@LuotXem",
                DbType = DbType.Int32,
                Value = video.LuotXem
            };
            cmd.Parameters.AddRange(new[] { paramMaVideo, paramTenVideo, paramTenKhongDau, paramMaCaSi, paramMaTheLoai, paramTenFile, paramNgayDang, paramHinh, paramLuotXem });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void DeleteVideo(Video video)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("UpdateVideo", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaVideo;
            paramMaVideo = new SqlParameter()
            {
                ParameterName = "@MaVideo",
                DbType = DbType.Int32,
                Value = video.MaVideo
            };
            cmd.Parameters.AddRange(new[] { paramMaVideo });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }
    }
}