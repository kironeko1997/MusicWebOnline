using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicWebOnline
{
    public class AlbumDAL : DAL
    {
        DataConnection dc = new DataConnection();

        public List<Album> GetAllAlbum()
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetAllAlbum", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Album> list = new List<Album>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Album album = new Album();
                    album.MaAlbum = Convert.ToInt32(dr["MaAlbum"].ToString());
                    album.TenAlbum = dr["TenAlbum"].ToString();
                    album.Hinh = dr["Hinh"].ToString();
                    album.MaCasi = dr["MaCaSi"].ToString() != "" ? Convert.ToInt32(dr["MaCaSi"].ToString()) : (dynamic)null;
                    list.Add(album);
                }
            }
            dc.closeDB();

            return list;
        }

        public Album GetAlbumByMaAlbum(int maAlbum)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetAlbumByMaAlbum", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaAlbum;
            paramMaAlbum = new SqlParameter()
            {
                ParameterName = "@MaAlbum",
                DbType = DbType.Int32,
                Value = maAlbum
            };
            cmd.Parameters.AddRange(new[] { paramMaAlbum });
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);           
            Album album = new Album();
            if(ds.Tables[0].Rows.Count > 0)
            {
                album.MaAlbum = Convert.ToInt32(ds.Tables[0].Rows[0]["MaAlbum"].ToString());
                album.TenAlbum = ds.Tables[0].Rows[0]["TenAlbum"].ToString();
                album.Hinh = ds.Tables[0].Rows[0]["Hinh"].ToString();
                album.MaCasi = ds.Tables[0].Rows[0]["MaCaSi"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaCaSi"].ToString()) : (dynamic)null;
            }
            dc.closeDB();

            return album;
        }

        public void InsertAlbum(Album album)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("InsertAlbum", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramTenAlbum, paramHinh, paramMaCasi, paramNgayDang, paramLuotNghe;
            paramTenAlbum = new SqlParameter()
            {
                ParameterName = "@TenAlbum",
                DbType = DbType.String,
                Value = ToDBNull(album.TenAlbum),
            };
            paramHinh = new SqlParameter()
            {
                ParameterName = "@Hinh",
                DbType = DbType.String,
                Value = ToDBNull(album.Hinh),
            };
            paramMaCasi = new SqlParameter()
            {
                ParameterName = "@MaCaSi",
                DbType = DbType.Int32,
                Value = ToDBNull(album.MaCasi),
            };
            paramNgayDang = new SqlParameter()
            {
                ParameterName = "@NgayDang",
                DbType = DbType.DateTime,
                Value = ToDBNull(album.NgayDang),
            };
            paramLuotNghe = new SqlParameter()
            {
                ParameterName = "@LuotNghe",
                DbType = DbType.Int32,
                Value = ToDBNull(album.LuotNghe),
            };
            cmd.Parameters.Add(new[] { paramTenAlbum, paramHinh, paramMaCasi, paramNgayDang, paramLuotNghe });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void UpdateAlbum(Album album)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("UpdateAlbum", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaAlbum, paramTenAlbum, paramHinh, paramMaCasi, paramNgayDang, paramLuotNghe;
            paramMaAlbum = new SqlParameter()
            {
                ParameterName = "@MaAlbum",
                DbType = DbType.Int32,
                Value = album.MaAlbum
            };
            paramTenAlbum = new SqlParameter()
            {
                ParameterName = "@TenAlbum",
                DbType = DbType.String,
                Value = ToDBNull(album.TenAlbum),
            };
            paramHinh = new SqlParameter()
            {
                ParameterName = "@Hinh",
                DbType = DbType.String,
                Value = ToDBNull(album.Hinh),
            };
            paramMaCasi = new SqlParameter()
            {
                ParameterName = "@MaCaSi",
                DbType = DbType.Int32,
                Value = ToDBNull(album.MaCasi),
            };
            paramNgayDang = new SqlParameter()
            {
                ParameterName = "@NgayDang",
                DbType = DbType.DateTime,
                Value = ToDBNull(album.NgayDang),
            };
            paramLuotNghe = new SqlParameter()
            {
                ParameterName = "@LuotNghe",
                DbType = DbType.Int32,
                Value = ToDBNull(album.LuotNghe),
            };
            cmd.Parameters.Add(new[] { paramMaAlbum, paramTenAlbum, paramHinh, paramMaCasi, paramNgayDang, paramLuotNghe });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void DeleteAlbum(Album album)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("DeleteAlbum", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaAlbum;
            paramMaAlbum = new SqlParameter()
            {
                ParameterName = "@MaAlbum",
                DbType = DbType.Int32,
                Value = album.MaAlbum
            };
            cmd.Parameters.Add(new[] { paramMaAlbum });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }
    }
}