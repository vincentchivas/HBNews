using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace addressCheck
{
    class sqlhelper
    {
        //声明数据库连接字符串
        public static readonly string connection = ConfigurationManager.AppSettings["connstring"].ToString();
        private static System.Collections.Hashtable paraCache = Hashtable.Synchronized(new Hashtable());

        //将参数数组放入哈希表
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            paraCache[cacheKey] = commandParameters;
        }

        //根据键名复制出哈希表中对应的参数数组
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParas = (SqlParameter[])paraCache[cacheKey];
            if (cachedParas == null)
                return null;
            SqlParameter[] clonedParas = new SqlParameter[cachedParas.Length];
            for (int i = 0, j = cachedParas.Length; i < j; i++)
                clonedParas[i] = (SqlParameter)((ICloneable)cachedParas[i]).Clone();
            return clonedParas;
        }

        //命令前准备工作
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParas)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParas != null)
            {
                foreach (SqlParameter para in cmdParas)
                {
                    cmd.Parameters.Add(para);
                }
            }
        }

        //返回DataReader对象
        #region

        public static SqlDataReader DataReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader odr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return odr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static SqlDataReader DataReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return DataReader(connection, cmdType, cmdText, commandParameters);
        }

        public static SqlDataReader DataReader(string sql, params SqlParameter[] commandParameters)
        {
            return DataReader(connection, CommandType.Text, sql, commandParameters);
        }

        public static SqlDataReader DataReader(string sql)
        {
            return DataReader(connection, CommandType.Text, sql, null);
        }

        public static SqlDataReader ExecuteReaderProc(string StoredProcedureName, params SqlParameter[] commandParameters)
        {
            return DataReader(connection, CommandType.StoredProcedure, StoredProcedureName, commandParameters);
        }

        #endregion

        //执行非查询语句，返回受影响条数int
        #region

        public static int ExeNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExeNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExeNonQuery(connection, cmdType, cmdText, commandParameters);
        }

        public static int ExeNonQuery(string sql, params SqlParameter[] commandParameters)
        {
            return ExeNonQuery(connection, CommandType.Text, sql, commandParameters);
        }

        public static int ExeNonQuery(string sql)
        {
            return ExeNonQuery(connection, CommandType.Text, sql, null);
        }

        public static int ExecuteNonQueryProc(string StoredProcedureName, params SqlParameter[] commandParameters)
        {
            return ExeNonQuery(connection, CommandType.StoredProcedure, StoredProcedureName, commandParameters);
        }

        #endregion

        //返回表的第一个元素object
        #region

        public static object ExeScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExeScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExeScalar(connection, cmdType, cmdText, commandParameters);
        }

        public static object ExeScalar(string sql, params SqlParameter[] commandParameters)
        {
            return ExeScalar(connection, CommandType.Text, sql, commandParameters);
        }

        public static object ExeScalar(string sql)
        {
            return ExeScalar(connection, CommandType.Text, sql, null);
        }

        public static object ExecuteScalarProc(string StoredProcedureName, params SqlParameter[] commandParameters)
        {
            return ExeScalar(connection, CommandType.StoredProcedure, StoredProcedureName, commandParameters);
        }

        #endregion

        //返回DataTable

        public static DataTable ReadTable(SqlTransaction transaction, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, cmdType, cmdText, commandParameters);
            SqlDataAdapter oda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            DataTable dt = ds.Tables[0];
            cmd.Parameters.Clear();
            return dt;
        }

        public static DataTable ReadTable(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                DataTable dt = ds.Tables[0];
                cmd.Parameters.Clear();
                return dt;
            }
        }

        public static DataTable ReadTable(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ReadTable(connection, cmdType, cmdText, commandParameters);
        }

        public static DataTable ReadTable(string sql, params SqlParameter[] commandParameters)
        {
            return ReadTable(connection, CommandType.Text, sql, commandParameters);
        }

        public static DataTable ReadTable(string sql)
        {
            return ReadTable(connection, CommandType.Text, sql, null);
        }

        public static DataTable ReadTableProc(string StoredProcedureName, params SqlParameter[] commandParameters)
        {
            return ReadTable(connection, CommandType.StoredProcedure, StoredProcedureName, commandParameters);
        }

        public static DataTable ReadTableProc(out int RecordCount, int StartIndex, int PageSize, string StoredProcedureName, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, StoredProcedureName, commandParameters);
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                RecordCount = dt.Rows.Count;
                dt.Clear();
                oda.Fill(StartIndex, PageSize, dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }








    }
}