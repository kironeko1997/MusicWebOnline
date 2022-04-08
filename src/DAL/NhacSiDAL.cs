using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicWebOnline
{
    public class NhacSiDAL : DAL
    {
        DataConnection dc = new DataConnection();

        public List<NhacSi> GetAllNhacsi()
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetAllNhacsi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<NhacSi> list = new List<NhacSi>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    NhacSi nhacsi = new NhacSi();
                    nhacsi.MaNhacSi = Convert.ToInt32(dr["MaNhacSi"].ToString());
                    nhacsi.TenNhacSi = dr["TenNhacSi"].ToString();
                    nhacsi.NgaySinh = dr["NgaySinh"].ToString() != "" ? Convert.ToDateTime(dr["NgaySinh"].ToString()) : (dynamic)null;
                    nhacsi.QuocTich = dr["QuocTich"].ToString();
                    nhacsi.HinhAnh = dr["HinhAnh"].ToString();
                    nhacsi.GioiThieu = dr["GioiThieu"].ToString();
                    list.Add(nhacsi);
                }
            }
            dc.closeDB();

            return list;
        }

        public NhacSi GetNhacsiByMaNhacSi(int maNhacSi)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetNhacsiByMaNhacSi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaNhacSi;
            paramMaNhacSi = new SqlParameter()
            {
                ParameterName = "@MaNhacSi",
                DbType = DbType.Int32,
                Value = maNhacSi
            };
            cmd.Parameters.AddRange(new[] { paramMaNhacSi });
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            NhacSi nhacsi = new NhacSi();
            if (ds.Tables[0].Rows.Count > 0)
            {
                nhacsi.MaNhacSi = Convert.ToInt32(ds.Tables[0].Rows[0]["MaNhacSi"].ToString());
                nhacsi.TenNhacSi = ds.Tables[0].Rows[0]["TenNhacSi"].ToString();
                nhacsi.NgaySinh = ds.Tables[0].Rows[0]["NgaySinh"].ToString() != "" ? Convert.ToDateTime(ds.Tables[0].Rows[0]["NgaySinh"].ToString()) : (dynamic)null;
                nhacsi.QuocTich = ds.Tables[0].Rows[0]["QuocTich"].ToString();
                nhacsi.HinhAnh = ds.Tables[0].Rows[0]["HinhAnh"].ToString();
                nhacsi.GioiThieu = ds.Tables[0].Rows[0]["GioiThieu"].ToString();
            }
            dc.closeDB();

            return nhacsi;
        }

        public void InsertNhacsi(NhacSi nhacsi)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("InsertNhacsi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramTenNhacSi, paramNgaySinh, paramQuocTich, paramHinhAnh, paramGioiThieu;
            paramTenNhacSi = new SqlParameter()
            {
                ParameterName = "@TenNhacSi",
                DbType = DbType.String,
                Value = ToDBNull(nhacsi.TenNhacSi)
            };
            paramNgaySinh = new SqlParameter()
            {
                ParameterName = "@NgaySinh",
                DbType = DbType.DateTime,
                Value = ToDBNull(nhacsi.NgaySinh)
            };
            paramQuocTich = new SqlParameter()
            {
                ParameterName = "@QuocTich",
                DbType = DbType.String,
                Value = ToDBNull(nhacsi.QuocTich)
            };
            paramHinhAnh = new SqlParameter()
            {
                ParameterName = "@HinhAnh",
                DbType = DbType.String,
                Value = ToDBNull(nhacsi.HinhAnh)
            };
            paramGioiThieu = new SqlParameter()
            {
                ParameterName = "@GioiThieu",
                DbType = DbType.String,
                Value = ToDBNull(nhacsi.GioiThieu)
            };
            cmd.Parameters.AddRange(new[] { paramTenNhacSi, paramNgaySinh, paramQuocTich, paramHinhAnh, paramGioiThieu });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void UpdateNhacsi(NhacSi nhacsi)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("UpdateNhacsi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaNhacSi, paramTenNhacSi, paramNgaySinh, paramQuocTich, paramHinhAnh, paramGioiThieu;
            paramMaNhacSi = new SqlParameter()
            {
                ParameterName = "@MaNhacSi",
                DbType = DbType.Int32,
                Value = nhacsi.MaNhacSi
            };
            paramTenNhacSi = new SqlParameter()
            {
                ParameterName = "@TenNhacSi",
                DbType = DbType.String,
                Value = ToDBNull(nhacsi.TenNhacSi)
            };
            paramNgaySinh = new SqlParameter()
            {
                ParameterName = "@NgaySinh",
                DbType = DbType.DateTime,
                Value = ToDBNull(nhacsi.NgaySinh)
            };
            paramQuocTich = new SqlParameter()
            {
                ParameterName = "@QuocTich",
                DbType = DbType.String,
                Value = ToDBNull(nhacsi.QuocTich)
            };
            paramHinhAnh = new SqlParameter()
            {
                ParameterName = "@HinhAnh",
                DbType = DbType.String,
                Value = ToDBNull(nhacsi.HinhAnh)
            };
            paramGioiThieu = new SqlParameter()
            {
                ParameterName = "@GioiThieu",
                DbType = DbType.String,
                Value = ToDBNull(nhacsi.GioiThieu)
            };
            cmd.Parameters.AddRange(new[] { paramMaNhacSi, paramTenNhacSi, paramNgaySinh, paramQuocTich, paramHinhAnh, paramGioiThieu });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void DeleteNhacsi(NhacSi nhacsi)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("DeleteNhacsi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaNhacSi;
            paramMaNhacSi = new SqlParameter()
            {
                ParameterName = "@MaNhacSi",
                DbType = DbType.Int32,
                Value = nhacsi.MaNhacSi
            };
            cmd.Parameters.AddRange(new[] { paramMaNhacSi });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }
    }
}