using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ResumeBuilder.connectors
{
    public class CLOVA
    {

        public static string DBErrorLog(string errorMsg, string errorTrace, string method, string errorcode, string loginID, string page)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployersErrorLogsAdd";
            cmd.Parameters.Add("@PErrorCode", SqlDbType.VarChar, 100).Value = errorcode;
            cmd.Parameters.Add("@PMethod", SqlDbType.VarChar, 250).Value = method;
            cmd.Parameters.Add("@PErrorMessage", SqlDbType.VarChar, 4000).Value = errorMsg;
            cmd.Parameters.Add("@PErrorTrace", SqlDbType.VarChar, 4000).Value = errorTrace;
            cmd.Parameters.Add("@PPageName", SqlDbType.VarChar, 20).Value = page;
            cmd.Parameters.Add("@PLoginID", SqlDbType.Int).Value = loginID;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);

        }

        public static string RegisterUser(string email,string password, string name, string contactNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerUserAdd";
            cmd.Parameters.Add("@PEmailID", SqlDbType.VarChar, 50).Value = email;
            cmd.Parameters.Add("@PPassword", SqlDbType.VarChar, 20).Value = password;
            cmd.Parameters.Add("@PName", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@PContactNo", SqlDbType.VarChar, 20).Value = contactNo;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }


        public static string UserAuth(string email, string password,string sessionID,out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerUserAuth";
            cmd.Parameters.Add("@PEmailID", SqlDbType.VarChar, 50).Value = email;
            cmd.Parameters.Add("@PPassword", SqlDbType.VarChar, 20).Value = password; 
            cmd.Parameters.Add("@PSessionID", SqlDbType.VarChar, 30).Value = sessionID;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText,out dt);
        }

        public static string GetConnectionString(string guid, out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetConnectionStringByGuid";
            cmd.Parameters.Add("@PCareerGuid", SqlDbType.VarChar, 150).Value = guid;

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
                using (SqlConnection conn = new SqlConnection(connections.ConnectionStringCLOVA))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    cmd.Connection = conn;
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dt= dataTable;
                }
                sCode = cmd.Parameters["@PCode"].Value.ToString();
                sDesc = cmd.Parameters["@PDesc"].Value.ToString();
                sMsg = cmd.Parameters["@PMsg"].Value.ToString();
            }
            catch (Exception ex)
            {
                dt = null;
                Log.FileLogError(ex.Message, ex.StackTrace, "GetConnectionString", "9999", userID, "db");
                return "9999 - Other Vendor Software related Error on Server.";
            }
            finally
            {

                cmd.Dispose();
                cmd = null;

            }

            if (sMsg != "Y")
            {
                Log.FileLogError(sCode, sDesc, "usp_GetConnectionStringByIP", "2036", userID, "db");
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

        public static string ValidateUserSession(int userID, string sessionID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerUserValidateSession";
            cmd.Parameters.Add("@PUserID", SqlDbType.Int).Value = userID;
            cmd.Parameters.Add("@PSessionID", SqlDbType.VarChar, 30).Value = sessionID;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string UserChangePassword(int userID, string password, string newPassword)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerUserChangePassword";
            cmd.Parameters.Add("@PUserID", SqlDbType.Int).Value = userID;
            cmd.Parameters.Add("@PPassword", SqlDbType.VarChar, 20).Value = password;
            cmd.Parameters.Add("@PNewPasword", SqlDbType.VarChar, 20).Value = newPassword;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string GetEmployerLovs(string lovType,out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerLovsGet";
            cmd.Parameters.Add("@PLovType", SqlDbType.VarChar, 20).Value = lovType;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText, out dt);
        }

        public static string GetEmployerData(int userID, out DataSet ds)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerDataGet";
            cmd.Parameters.Add("@PUserID", SqlDbType.Int).Value = userID;

            return db.FillDataSetWithExpHndlng(cmd, cmd.CommandText, out ds);
        }

        public static string AddUpdateEmployerInfo(int ID,int userID,string nameFirst, string nameMiddle, string nameLast, string arabicName,
            string fatherName,int genderID,int maritialStatus,DateTime dob, string email,string mobile,string city,string country,
            string presentAddress,string permanentAddress, string cv,string Specilization , string Objective,int createdBy,int lastModified,out string employerID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerInfoAdd";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@PUserID", SqlDbType.Int).Value = userID;
            cmd.Parameters.Add("@PNameFirst", SqlDbType.NVarChar, 255).Value = nameFirst;
            cmd.Parameters.Add("@PNameMiddle", SqlDbType.NVarChar, 255).Value = nameMiddle;
            cmd.Parameters.Add("@PNameLast", SqlDbType.NVarChar, 255).Value = nameLast;
            cmd.Parameters.Add("@PArabicName", SqlDbType.NVarChar, 255).Value = arabicName;
            cmd.Parameters.Add("@PFathersName", SqlDbType.NVarChar, 20).Value = fatherName;
            cmd.Parameters.Add("@PGenderID", SqlDbType.Int).Value = genderID;
            cmd.Parameters.Add("@PMaritialStatus", SqlDbType.Int).Value = maritialStatus;
            cmd.Parameters.Add("@PDateOfBirth", SqlDbType.Date).Value = dob.Date;
            cmd.Parameters.Add("@PEmail", SqlDbType.NVarChar, 30).Value = email;
            cmd.Parameters.Add("@PMobile", SqlDbType.NVarChar, 25).Value = mobile;
            cmd.Parameters.Add("@PCity", SqlDbType.NVarChar, 50).Value = city;
            cmd.Parameters.Add("@PCountry", SqlDbType.NVarChar, 50).Value = country;
            cmd.Parameters.Add("@PPresentAddress", SqlDbType.NVarChar, 1000).Value = presentAddress;
            cmd.Parameters.Add("@PPermanentAddress", SqlDbType.NVarChar, 1000).Value = permanentAddress;
            cmd.Parameters.Add("@PCV", SqlDbType.NVarChar, 150).Value = cv;
            cmd.Parameters.Add("@PSpecilization", SqlDbType.NVarChar, 50).Value = Specilization;
            cmd.Parameters.Add("@PObjective", SqlDbType.NVarChar, 1000).Value = Objective;
            cmd.Parameters.Add("@PCreatedBy", SqlDbType.Int).Value = createdBy;
            cmd.Parameters.Add("@PLastModifiedBy", SqlDbType.Int).Value = lastModified;
            cmd.Parameters.Add("@PEmployerID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@PCode", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PDesc", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PMsg", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;

            string sCode = "";
            string sDesc = "";
            string sMsg = "";

            string uID = string.Empty;
            try { uID = HttpContext.Current.Session["UserID"].ToString(); } catch (Exception) { }

            try
            {
                using (SqlConnection conn = new SqlConnection(connections.ConnectionStringCLOVA))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    sCode = cmd.Parameters["@PCode"].Value.ToString();
                    sDesc = cmd.Parameters["@PDesc"].Value.ToString();
                    sMsg = cmd.Parameters["@PMsg"].Value.ToString();
                    employerID = cmd.Parameters["@PEmployerID"].Value.ToString();
                }
                
            }
            catch (Exception ex)
            {
                employerID = "";
                Log.LogError(ex.Message, ex.StackTrace, "AddUpdateEmployerInfo", "9999", uID, "db");
                return "9999 - Other Vendor Software related Error on Server.";
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
            if (sMsg != "Y")
            {
                Log.LogError(sCode, sDesc, "usp_EmployerInfoAdd", "2036", uID, "db");
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

        public static string AddUpdateEmployerPhoto(int ID, int userID,string photo,int createdBy, int lastModified, out string employerID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerPhotoAdd";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@PUserID", SqlDbType.Int).Value = userID;
            cmd.Parameters.Add("@PPhoto", SqlDbType.NVarChar).Value = photo;
            cmd.Parameters.Add("@PCreatedBy", SqlDbType.Int).Value = createdBy;
            cmd.Parameters.Add("@PLastModifiedBy", SqlDbType.Int).Value = lastModified;
            cmd.Parameters.Add("@PEmployerID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@PCode", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PDesc", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PMsg", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;

            string sCode = "";
            string sDesc = "";
            string sMsg = "";

            string uID = string.Empty;
            try { uID = HttpContext.Current.Session["UserID"].ToString(); } catch (Exception) { }

            try
            {
                using (SqlConnection conn = new SqlConnection(connections.ConnectionStringCLOVA))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    sCode = cmd.Parameters["@PCode"].Value.ToString();
                    sDesc = cmd.Parameters["@PDesc"].Value.ToString();
                    sMsg = cmd.Parameters["@PMsg"].Value.ToString();
                    employerID = cmd.Parameters["@PEmployerID"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                employerID = "";
                Log.LogError(ex.Message, ex.StackTrace, "AddUpdateEmployerPhoto", "9999", uID, "db");
                return "9999 - Other Vendor Software related Error on Server.";
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
            }
            if (sMsg != "Y")
            {
                Log.LogError(sCode, sDesc, "usp_EmployerPhotoAdd", "2036", uID, "db");
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

        public static string GetEmployerPhoto(int userID, out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerPhotoGet";
            cmd.Parameters.Add("@PUserID", SqlDbType.Int).Value = userID;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText,out dt);
        }

        public static string AddUpdateEmployerEdu(int ID, int employerID, string institute, int degree, string subjects, string year,
            string city, string country,int obtainedMarks, int totalMarks,double percentage, int createdBy, int lastModified)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerEduAdd";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@PEmployerID", SqlDbType.Int).Value = employerID;
            cmd.Parameters.Add("@PInstitute", SqlDbType.NVarChar, 250).Value = institute;
            cmd.Parameters.Add("@PDegree", SqlDbType.Int).Value = degree;
            cmd.Parameters.Add("@PMajorSubjects", SqlDbType.NVarChar, 250).Value = subjects;
            cmd.Parameters.Add("@PCompletionYear", SqlDbType.NVarChar, 50).Value = year;
            cmd.Parameters.Add("@PCity", SqlDbType.NVarChar, 50).Value = city;
            cmd.Parameters.Add("@PCountry", SqlDbType.NVarChar, 50).Value = country;
            cmd.Parameters.Add("@PObtainMarks", SqlDbType.Int).Value = obtainedMarks;
            cmd.Parameters.Add("@PTotalMarks", SqlDbType.Int).Value = totalMarks;
            cmd.Parameters.Add("@PPercentage", SqlDbType.Float).Value = percentage;
            cmd.Parameters.Add("@PCreatedBy", SqlDbType.Int).Value = createdBy;
            cmd.Parameters.Add("@PLastModifiedBy", SqlDbType.Int).Value = lastModified;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string AddUpdateEmployerExp(int ID, int employerID, string companyName, int companyType, string country,int role,
            DateTime startDate,DateTime endDate,int isPresent, string desc, string leavingReason, int createdBy, int lastModified)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerExpAdd";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@PEmployerID", SqlDbType.Int).Value = employerID;
            cmd.Parameters.Add("@PCompanyName", SqlDbType.NVarChar, 50).Value = companyName;
            cmd.Parameters.Add("@PCompanyType", SqlDbType.Int).Value = companyType;
            cmd.Parameters.Add("@PCountry", SqlDbType.NVarChar, 50).Value = country;
            cmd.Parameters.Add("@PJobRole", SqlDbType.Int).Value = role;
            cmd.Parameters.Add("@PStartDate", SqlDbType.Date).Value = startDate.Date;
            cmd.Parameters.Add("@PEndDate", SqlDbType.Date).Value = endDate.Date;
            cmd.Parameters.Add("@PPresent", SqlDbType.Bit).Value = isPresent;
            cmd.Parameters.Add("@PWorkDescription", SqlDbType.NVarChar, 250).Value = desc;
            cmd.Parameters.Add("@PLeavingReason", SqlDbType.NVarChar, 250).Value = leavingReason;
            cmd.Parameters.Add("@PCreatedBy", SqlDbType.Int).Value = createdBy;
            cmd.Parameters.Add("@PLastModifiedBy", SqlDbType.Int).Value = lastModified;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string AddUpdateEmployerLng(int ID,int employerID,string language, int proficiency,int createdBy,int lastModified)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerLngAdd";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@PEmployerID", SqlDbType.Int).Value = employerID;
            cmd.Parameters.Add("@PLanguage", SqlDbType.NVarChar, 50).Value = language;
            cmd.Parameters.Add("@PProficiency", SqlDbType.Int).Value = proficiency;
            cmd.Parameters.Add("@PCreatedBy", SqlDbType.Int).Value = createdBy;
            cmd.Parameters.Add("@PLastModifiedBy", SqlDbType.Int).Value = lastModified;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string AddUpdateEmployerSkl(int ID, int employerID, string skill, int proficiency, int createdBy, int lastModified)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerSklAdd";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@PEmployerID", SqlDbType.Int).Value = employerID;
            cmd.Parameters.Add("@PSkill", SqlDbType.NVarChar, 50).Value = skill;
            cmd.Parameters.Add("@PProficiency", SqlDbType.Int).Value = proficiency;
            cmd.Parameters.Add("@PCreatedBy", SqlDbType.Int).Value = createdBy;
            cmd.Parameters.Add("@PLastModifiedBy", SqlDbType.Int).Value = lastModified;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string AddUpdateEmployerRef(int ID, int employerID, string refName, string jobTitle, string companyName,
            string contactNo,string email, int createdBy, int lastModified)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerRefAdd";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@PEmployerID", SqlDbType.Int).Value = employerID;
            cmd.Parameters.Add("@PRefName", SqlDbType.NVarChar, 50).Value = refName;
            cmd.Parameters.Add("@PJobTitle", SqlDbType.NVarChar, 50).Value = jobTitle;
            cmd.Parameters.Add("@PCompanyName", SqlDbType.NVarChar, 50).Value = companyName;
            cmd.Parameters.Add("@PContactNo", SqlDbType.NVarChar, 20).Value = contactNo;
            cmd.Parameters.Add("@PEmail", SqlDbType.NVarChar, 50).Value = email;
            cmd.Parameters.Add("@PCreatedBy", SqlDbType.Int).Value = createdBy;
            cmd.Parameters.Add("@PLastModifiedBy", SqlDbType.Int).Value = lastModified;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string DeleteEmployerEducation(int eduID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerEduDelete";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = eduID;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string GetEmployerEducation(int employerID, out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerEduGet";
            cmd.Parameters.Add("@PEmployerID", SqlDbType.VarChar, 20).Value = employerID;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText, out dt);
        }

        public static string GetEmployerExperience(int employerID, out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerExpGet";
            cmd.Parameters.Add("@PEmployerID", SqlDbType.VarChar, 20).Value = employerID;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText, out dt);
        }

        public static string DeleteEmployerExperience(int expID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerExpDelete";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = expID;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string GetEmployerLanguage(int employerID, out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerLngGet";
            cmd.Parameters.Add("@PEmployerID", SqlDbType.VarChar, 20).Value = employerID;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText, out dt);
        }

        public static string DeleteEmployerLanguage(int lngID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerLngDelete";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = lngID;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string GetEmployerSkills(int employerID, out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerSklGet";
            cmd.Parameters.Add("@PEmployerID", SqlDbType.VarChar, 20).Value = employerID;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText, out dt);
        }

        public static string DeleteEmployerSkills(int sklID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerSklDelete";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = sklID;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string GetEmployerReferences(int employerID, out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerRefGet";
            cmd.Parameters.Add("@PEmployerID", SqlDbType.VarChar, 20).Value = employerID;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText, out dt);
        }

        public static string DeleteEmployerReferences(int refID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerRefDelete";
            cmd.Parameters.Add("@PID", SqlDbType.Int).Value = refID;

            return db.ExecuteNonQueryWithExpHndlng(cmd, cmd.CommandText);
        }

        public static string EmployerForgotPassword(string emailID, out DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EmployerForgotPassword";
            cmd.Parameters.Add("@PEmailID", SqlDbType.VarChar, 50).Value = emailID;

            return db.FillDataTableWithExpHndlng(cmd, cmd.CommandText, out dt);
        }

    }
}
