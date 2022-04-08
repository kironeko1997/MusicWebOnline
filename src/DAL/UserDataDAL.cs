using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicWebOnline
{
    public class UserDataDAL : DAL
    {
        DataConnection dc = new DataConnection();

        public List<UserData> GetAllUserData()
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetAllUserData", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<UserData> list = new List<UserData>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    UserData userData = new UserData();
                    userData.MaUser = Convert.ToInt32(dr["MaUser"].ToString());
                    userData.TenDangNhap = dr["TenDangNhap"].ToString();
                    list.Add(userData);
                }
            }
            dc.closeDB();

            return list;
        }

        public UserData Login(string tenDangNhap, string matKhau)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("dbo.Login", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramTenDangNhap, paramMatKhau;
            paramTenDangNhap = new SqlParameter()
            {
                ParameterName = "@TenDangNhap",
                DbType = DbType.String,
                Value = tenDangNhap
            };
            paramMatKhau = new SqlParameter()
            {
                ParameterName = "@MatKhau",
                DbType = DbType.String,
                Value = matKhau
            };
            cmd.Parameters.AddRange(new[] { paramTenDangNhap, paramMatKhau });
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            UserData userData = new UserData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                userData.MaUser = Convert.ToInt32(ds.Tables[0].Rows[0]["MaUser"].ToString());
                userData.TenDangNhap = ds.Tables[0].Rows[0]["TenDangNhap"].ToString();
                userData.MatKhau = ds.Tables[0].Rows[0]["MatKhau"].ToString();
                userData.MaQuyen = ds.Tables[0].Rows[0]["MaQuyen"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["MaQuyen"].ToString()) : (dynamic)null;
                userData.HoTen = ds.Tables[0].Rows[0]["HoTen"].ToString();
                userData.CMT = ds.Tables[0].Rows[0]["CMT"].ToString() != "" ? Convert.ToInt32(ds.Tables[0].Rows[0]["CMT"].ToString()) : (dynamic)null;
                userData.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                userData.Hinh = ds.Tables[0].Rows[0]["Hinh"].ToString();
                userData.GioiTinh = ds.Tables[0].Rows[0]["GioiTinh"].ToString();
                userData.NamSinh = ds.Tables[0].Rows[0]["NamSinh"].ToString();
            }
            dc.closeDB();

            return userData;
        }

        public void Register(UserData userData)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("dbo.Login", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramTenDangNhap, paramMatKhau, paramMaQuyen, paramHoTen, paramCMT, paramEmail, paramHinh, paramGioiTinh, paramNamSinh;
            paramTenDangNhap = new SqlParameter()
            {
                ParameterName = "@TenDangNhap",
                DbType = DbType.String,
                Value = userData.TenDangNhap
            };
            paramMatKhau = new SqlParameter()
            {
                ParameterName = "@MatKhau",
                DbType = DbType.String,
                Value = userData.MatKhau
            };
            paramMaQuyen = new SqlParameter()
            {
                ParameterName = "@MaQuyen",
                DbType = DbType.Int32,
                Value = ToDBNull(userData.MaQuyen)
            };
            paramHoTen = new SqlParameter()
            {
                ParameterName = "@HoTen",
                DbType = DbType.String,
                Value = ToDBNull(userData.HoTen)
            };
            paramCMT = new SqlParameter()
            {
                ParameterName = "@CMT",
                DbType = DbType.Int32,
                Value = ToDBNull(userData.CMT)
            };
            paramEmail = new SqlParameter()
            {
                ParameterName = "@Email",
                DbType = DbType.String,
                Value = ToDBNull(userData.Email)
            };
            paramHinh = new SqlParameter()
            {
                ParameterName = "@Hinh",
                DbType = DbType.String,
                Value = ToDBNull(userData.Hinh)
            };
            paramGioiTinh = new SqlParameter()
            {
                ParameterName = "@GioiTinh",
                DbType = DbType.String,
                Value = ToDBNull(userData.GioiTinh)
            };
            paramNamSinh = new SqlParameter()
            {
                ParameterName = "@NamSinh",
                DbType = DbType.String,
                Value = ToDBNull(userData.NamSinh)
            };
        }
    }
}