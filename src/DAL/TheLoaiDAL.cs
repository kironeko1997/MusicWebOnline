using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicWebOnline
{
    public class TheLoaiDAL : DAL
    {
        DataConnection dc = new DataConnection();

        public List<TheLoai> GetAllTheLoai()
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetAllTheLoai", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<TheLoai> list = new List<TheLoai>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TheLoai theLoai = new TheLoai();
                    theLoai.MaTheLoai = Convert.ToInt32(dr["MaTheLoai"].ToString());
                    theLoai.TenTheLoai = dr["TenTheLoai"].ToString();
                    list.Add(theLoai);
                }
            }
            dc.closeDB();

            return list;
        }

        public TheLoai GetTheLoaiByMaTheLoai(int maTheLoai)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("GetTheLoaiByMaTheLoai", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaTheLoai;
            paramMaTheLoai = new SqlParameter()
            {
                ParameterName = "@MaTheLoai",
                DbType = DbType.Int32,
                Value = maTheLoai
            };
            cmd.Parameters.AddRange(new[] { paramMaTheLoai });
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            TheLoai theLoai = new TheLoai();
            if (ds.Tables[0].Rows.Count > 0)
            {
                theLoai.MaTheLoai = Convert.ToInt32(ds.Tables[0].Rows[0]["MaTheLoai"].ToString());
                theLoai.TenTheLoai = ds.Tables[0].Rows[0]["TenTheLoai"].ToString();
            }
            dc.closeDB();

            return theLoai;
        }

        public void InsertTheLoai(TheLoai theLoai)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("InsertTheLoai", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramTenTheLoai;
            
            paramTenTheLoai = new SqlParameter()
            {
                ParameterName = "@TenTheLoai",
                DbType = DbType.String,
                Value = ToDBNull(theLoai.TenTheLoai)
            };
            cmd.Parameters.AddRange(new[] { paramTenTheLoai });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void UpdateTheLoai(TheLoai theLoai)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("UpdateTheLoai", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaTheLoai, paramTenTheLoai;
            paramMaTheLoai = new SqlParameter()
            {
                ParameterName = "@MaTheLoai",
                DbType = DbType.Int32,
                Value = theLoai.MaTheLoai
            };
            paramTenTheLoai = new SqlParameter()
            {
                ParameterName = "@TenTheLoai",
                DbType = DbType.String,
                Value = ToDBNull(theLoai.TenTheLoai)
            };
            cmd.Parameters.AddRange(new[] { paramMaTheLoai, paramTenTheLoai });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }

        public void DeleteTheLoai(TheLoai theLoai)
        {
            dc.connDB();
            SqlCommand cmd = new SqlCommand("UpdateTheLoai", dc.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramMaTheLoai;
            paramMaTheLoai = new SqlParameter()
            {
                ParameterName = "@MaTheLoai",
                DbType = DbType.Int32,
                Value = theLoai.MaTheLoai
            };
            cmd.Parameters.AddRange(new[] { paramMaTheLoai });
            cmd.ExecuteNonQuery();
            dc.closeDB();
        }
    }
}