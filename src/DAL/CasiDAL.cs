using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicWebOnline
{
    public class CasiDAL : DAL
    {
        DataConnection dc = new DataConnection();

        public List<CaSi> GetAllCasi()
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetAllCasi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<CaSi> list = new List<CaSi>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    CaSi casi = new CaSi();
                    casi.MaCasi = Convert.ToInt32(dr["MaCaSi"].ToString());
                    casi.TenCaSi = dr["TenCaSi"].ToString();
                    casi.TenThat = dr["TenThat"].ToString();
                    casi.NgaySinh = dr["NgaySinh"].ToString() != "" ? Convert.ToDateTime(dr["NgaySinh"].ToString()) : (dynamic)null;
                    casi.QuocTich = dr["QuocTich"].ToString();
                    casi.HinhAnh = dr["HinhAnh"].ToString();
                    casi.GioiThieu = dr["GioiThieu"].ToString();
                    casi.YeuThich = dr["YeuThich"].ToString() != "" ? Convert.ToInt32(dr["YeuThich"].ToString()) : (dynamic)null;
                    list.Add(casi);
                }
            }
            dc.closeDB();

            return list;
        }

        public CaSi GetCasiByMaCasi(int maCasi)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetCasiByMaCasi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaCaSi;
            paramMaCaSi = new SqlParameter()
            {
                ParameterName = "@MaCasi",
                DbType = DbType.Int32,
                Value = maCasi
            };
            cmd.Parameters.AddRange(new[] { paramMaCaSi });
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            CaSi casi = new CaSi();
            if (ds.Tables[0].Rows.Count > 0)
            {
                casi.MaCasi = Convert.ToInt32(ds.Tables[0].Rows[0]["MaCaSi"].ToString());
                casi.TenCaSi = ds.Tables[0].Rows[0]["TenCaSi"].ToString();
                casi.TenThat = ds.Tables[0].Rows[0]["TenThat"].ToString();
                casi.NgaySinh = ds.Tables[0].Rows[0]["NgaySinh"].ToString() != "" ? Convert.ToDateTime(ds.Tables[0].Rows[0]["NgaySinh"].ToString()) : (dynamic)null;
                casi.QuocTich = ds.Tables[0].Rows[0]["QuocTich"].ToString();
                casi.HinhAnh = ds.Tables[0].Rows[0]["HinhAnh"].ToString();
                casi.GioiThieu = ds.Tables[0].Rows[0]["GioiThieu"].ToString();
                casi.YeuThich = ds.Tables[0].Rows[0]["YeuThich"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["YeuThich"].ToString()) : (dynamic)null;
            }
            dc.closeDB();

            return casi;
        }

        public void InsertCasi(CaSi casi)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("InsertCasi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramTenCaSi, paramTenThat, paramNgaySinh, paramQuocTich, paramHinhAnh, paramGioiThieu, paramYeuThich;
            paramTenCaSi = new SqlParameter()
            {
                ParameterName = "@TenCasi",
                DbType = DbType.String,
                Value = ToDBNull(casi.TenCaSi)
            };
            paramTenThat = new SqlParameter()
            {
                ParameterName = "@TenThat",
                DbType = DbType.String,
                Value = ToDBNull(casi.TenThat)
            };
            paramNgaySinh = new SqlParameter()
            {
                ParameterName = "@NgaySinh",
                DbType = DbType.DateTime,
                Value = ToDBNull(casi.NgaySinh)
            };
            paramQuocTich = new SqlParameter()
            {
                ParameterName = "@QuocTich",
                DbType = DbType.String,
                Value = ToDBNull(casi.QuocTich)
            };
            paramHinhAnh = new SqlParameter()
            {
                ParameterName = "@HinhAnh",
                DbType = DbType.String,
                Value = ToDBNull(casi.HinhAnh)
            };
            paramGioiThieu = new SqlParameter()
            {
                ParameterName = "@GioiThieu",
                DbType = DbType.String,
                Value = ToDBNull(casi.GioiThieu)
            };
            paramYeuThich = new SqlParameter()
            {
                ParameterName = "@YeuThich",
                DbType = DbType.Int32,
                Value = ToDBNull(casi.YeuThich)
            };
            cmd.Parameters.AddRange(new[] { paramTenCaSi, paramTenThat, paramNgaySinh, paramQuocTich, paramHinhAnh, paramGioiThieu, paramYeuThich });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void UpdateCasi(CaSi casi)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("UpdateCasi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaCasi, paramTenCaSi, paramTenThat, paramNgaySinh, paramQuocTich, paramHinhAnh, paramGioiThieu, paramYeuThich;
            paramMaCasi = new SqlParameter()
            {
                ParameterName = "@MaCasi",
                DbType = DbType.Int32,
                Value = ToDBNull(casi.MaCasi)
            };
            paramTenCaSi = new SqlParameter()
            {
                ParameterName = "@TenCasi",
                DbType = DbType.String,
                Value = ToDBNull(casi.TenCaSi)
            };
            paramTenThat = new SqlParameter()
            {
                ParameterName = "@TenThat",
                DbType = DbType.String,
                Value = ToDBNull(casi.TenThat)
            };
            paramNgaySinh = new SqlParameter()
            {
                ParameterName = "@NgaySinh",
                DbType = DbType.DateTime,
                Value = ToDBNull(casi.NgaySinh)
            };
            paramQuocTich = new SqlParameter()
            {
                ParameterName = "@QuocTich",
                DbType = DbType.String,
                Value = ToDBNull(casi.QuocTich)
            };
            paramHinhAnh = new SqlParameter()
            {
                ParameterName = "@HinhAnh",
                DbType = DbType.String,
                Value = ToDBNull(casi.HinhAnh)
            };
            paramGioiThieu = new SqlParameter()
            {
                ParameterName = "@GioiThieu",
                DbType = DbType.String,
                Value = ToDBNull(casi.GioiThieu)
            };
            paramYeuThich = new SqlParameter()
            {
                ParameterName = "@YeuThich",
                DbType = DbType.Int32,
                Value = ToDBNull(casi.YeuThich)
            };
            cmd.Parameters.AddRange(new[] { paramMaCasi, paramTenCaSi, paramTenThat, paramNgaySinh, paramQuocTich, paramHinhAnh, paramGioiThieu, paramYeuThich });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void DeleteCasi(CaSi casi)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("DeleteCasi", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaCasi;
            paramMaCasi = new SqlParameter()
            {
                ParameterName = "@MaCasi",
                DbType = DbType.Int32,
                Value = ToDBNull(casi.MaCasi)
            };
            cmd.Parameters.Add(new[] { paramMaCasi });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }
    }
}