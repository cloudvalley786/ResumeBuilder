using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ResumeBuilder.connectors
{
    public class db
    {
        public static string ExecuteNonQueryWithExpHndlng(SqlCommand cmd, string strMethodPkgPrc)
        {
            cmd.Parameters.Add("@PCode", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PDesc", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PMsg", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;

            string sCode = "";
            string sDesc = "";
            string sMsg = "";

            string userID = string.Empty;
            try { userID = HttpContext.Current.Session["UserID"].ToString(); } catch (Exception) { }

            try
            {
                ExecuteNonQuery(cmd);
                sCode = cmd.Parameters["@PCode"].Value.ToString();
                sDesc = cmd.Parameters["@PDesc"].Value.ToString();
                sMsg = cmd.Parameters["@PMsg"].Value.ToString();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace, strMethodPkgPrc, "9999", userID, "db");
                return "9999 - Other Vendor Software related Error on Server.";
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
            if (sMsg != "Y")
            {
                Log.LogError(sCode, sDesc, strMethodPkgPrc, "2036", userID, "db");
                return sCode + " - " + sDesc;
            }
            else
            {
                if (sCode != "00")
                {
                    return sCode + " - " + sDesc;
                }
                else
                {
                    return sDesc;
                }
            }
        }

        public static string ExecuteNonQueryWithExpHndlngErrorLog(SqlCommand cmd, string strMethodPkgPrc)
        {
            cmd.Parameters.Add("@PCode", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PDesc", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PMsg", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;

            string sCode = "";
            string sDesc = "";
            string sMsg = "";

            string userID = string.Empty;
            try { userID = HttpContext.Current.Session["UserID"].ToString(); } catch (Exception) { }

            try
            {
                ExecuteNonQuery(cmd);
                sCode = cmd.Parameters["@PCode"].Value.ToString();
                sDesc = cmd.Parameters["@PDesc"].Value.ToString();
                sMsg = cmd.Parameters["@PMsg"].Value.ToString();
            }
            catch (Exception ex)
            {
                Log.FileLogError(ex.Message, ex.StackTrace, strMethodPkgPrc, "9999", userID, "db");
                sDesc = "success";
                return "9999 - Other Vendor Software related Error on Server.";
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
            if (sMsg != "Y")
            {
                Log.LogError(sCode, sDesc, strMethodPkgPrc, "2036", userID, "db");
                return sCode + " - " + sDesc;
            }
            else
            {
                if (sCode != "00")
                {
                    return sCode + " - " + sDesc;
                }
                else
                {
                    return sDesc;
                }
            }
        }

        public static string FillDataTableWithExpHndlng(SqlCommand cmd, string strMethodPkgPrc, out DataTable dt)
        {
            cmd.Parameters.Add("@PCode", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PDesc", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PMsg", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;

            string sCode = "";
            string sDesc = "";
            string sMsg = "";
            string userID = string.Empty;
            
            try { userID = HttpContext.Current.Session["UserID"].ToString(); } catch (Exception) { }
            try
            {
                cmd.CommandTimeout = 600;
                dt = FillDataTable(cmd);
                sCode = cmd.Parameters["@PCode"].Value.ToString();
                sDesc = cmd.Parameters["@PDesc"].Value.ToString();
                sMsg = cmd.Parameters["@PMsg"].Value.ToString();
            }
            catch (Exception ex)
            {
                dt = null;
                Log.LogError(ex.Message, ex.StackTrace, strMethodPkgPrc, "9999", userID, "db");
                return "9999 - Other Vendor Software related Error on Server.";
            }
            finally
            {

                cmd.Dispose();
                cmd = null;

            }

            if (sMsg != "Y")
            {
                Log.LogError(sCode, sDesc, strMethodPkgPrc, "2036", userID, "db");
                return sCode + " - " + sDesc;
            }
            else
            {

                if (sCode != "00")
                {
                    return sCode + " - " + sDesc;
                }
                else
                {

                    return sDesc;
                }
            }
        }

        public static string FillDataSetWithExpHndlng(SqlCommand cmd, string strMethodPkgPrc, out DataSet ds)
        {
            cmd.Parameters.Add("@PCODE", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PDESC", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PMSG", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;

            string sCode = "";
            string sDesc = "";
            string sMsg = "";
            string userID = string.Empty;
            try { userID = HttpContext.Current.Session["UserID"].ToString(); } catch (Exception) { }
            try
            {
                cmd.CommandTimeout = 600;
                ds = FillDataSet(cmd);
                sCode = cmd.Parameters["@PCODE"].Value.ToString();
                sDesc = cmd.Parameters["@PDESC"].Value.ToString();
                sMsg = cmd.Parameters["@PMSG"].Value.ToString();
            }
            catch (Exception ex)
            {
                ds = null;
                Log.LogError(ex.Message, ex.StackTrace, strMethodPkgPrc, "9999", userID, "");
                return "9999 - Other Vendor Software related Error on Server.";
            }
            finally
            {

                cmd.Dispose();
                cmd = null;

            }

            if (sMsg != "Y")
            {
                Log.LogError(sCode, sDesc, strMethodPkgPrc, "2036", userID, "");
                throw new Exception(sCode + " - " + sDesc);
            }
            else
            {

                if (sCode != "00")
                {

                    return sCode + " - " + sDesc;
                }
                else
                {
                    return sDesc;
                }
            }
        }



        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connections.ConnectionStringCLOVA)) 
                {
                    conn.Open();
                    cmd.Connection = conn;
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable FillDataTable(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connections.ConnectionStringCLOVA))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    cmd.Connection = conn;
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet FillDataSet(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connections.ConnectionStringCLOVA))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    cmd.Connection = conn;
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}