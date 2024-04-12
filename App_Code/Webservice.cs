using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class StaffLogin : System.Web.Services.WebService
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    string MID, SID, DID, SUPID;
    decimal totalbal, totalpaid;

    public StaffLogin()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //Master Admin/Admin/Staff Login
    [WebMethod]
    public void CheckLoginUser(string Username, string Password, string role)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        VerificationStatus status = new VerificationStatus();
        status.status = 0;

        try
        {
            if (role == "Master Admin")
            {
                //ADMIN LOGIN
                con.Open();
                cmd = new SqlCommand("SELECT Master_Id,First_Name,Last_Name FROM [dbo].[Master_Admin] where [Username]=@Username and [Password]=@Password", con);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);


                DataTable dt1 = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    status.status = 1;
                }
            }
            else if (role == "Admin" || role == "Staff")
            {
                //SALES PERSON LOGIN
                cmd = new SqlCommand(@"SELECT Staff_Id,First_Name,Last_Name FROM [dbo].[Staff] where Username=@Username and Password=@Password", con);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    status.status = 1;

                }

            }
        }

        catch (Exception ex)
        {
            string e = ex.ToString();
        }
        finally
        {
            con.Close();
        }



        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Master Admin Add/Update
    [WebMethod]
    public void MasterAdminCRUD(string Type, string Master_Id, string MID, string FirstNane, string MiddleName, string LastName, string Gender, string Mobile, string Gmail, string Address
        , string Username, string Password)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            if (Type == "Insert")
            {
                //AutoGenrateMaster();
                cmd = new SqlCommand(@"INSERT INTO [dbo].[Master_Admin]([ID],[First_Name],[Middle_Name],[Last_Name],[Gender],[Mobile],[Gmail],[Address],[Username],[Password],
                [Role],[Added_On])VALUES(@ID,@First_Name,@Middle_Name,@Last_Name,@Gender,@Mobile,@Gmail,@Address,@Username,@Password,@Role,@Added_On)", con);

            }
            else if (Type == "Update")
            {
                cmd = new SqlCommand(@"UPDATE [dbo].[Master_Admin]SET [ID] = @ID ,[First_Name] = @First_Name ,[Middle_Name] = @Middle_Name ,[Last_Name] = @Last_Name ,
                [Gender] = @Gender ,[Mobile] = @Mobile ,[Gmail] = @Gmail ,[Address] = @Address ,[Username] = @Username ,[Password] = @Password ,
                [Role] = @Role ,[Added_On] = @Added_On WHERE [Master_Id]=@Master_Id", con);

            }
            //else if (Type == "Delete")
            //{
            //    cmd = new SqlCommand(@"Delete from [unifoods].[Office_Staff_Master] where Id=@Id", con);

            //}
            else
            {
                cmd = new SqlCommand(@"", con);
            }
            cmd.Parameters.AddWithValue("@Master_Id", Master_Id);
            cmd.Parameters.AddWithValue("@ID", MID);
            cmd.Parameters.AddWithValue("@First_Name", FirstNane);
            cmd.Parameters.AddWithValue("@Middle_Name", MiddleName);
            cmd.Parameters.AddWithValue("@Last_Name", LastName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Gmail", Gmail);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Role", "Master Admin");
            cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Master Admin Prefix Id
    //protected void AutoGenrateMaster()
    //{
    //    SqlConnection con = new SqlConnection(strcon);
    //    try
    //    {
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM [dbo].[Master_Admin] ORDER BY ID DESC", con);
    //        SqlDataReader reader = cmd.ExecuteReader();
    //        int latestNumericPart = 0001;

    //        // Check if there is a result
    //        if (reader.Read())
    //        {
    //            string latestId = reader["ID"].ToString();

    //            // Extract the numeric part from the ID
    //            string numericPart = latestId.Substring(2); // Assuming the prefix length is fixed at 2 characters
    //            latestNumericPart = int.Parse(numericPart);
    //        }

    //        reader.Close();

    //        // Increment the latest numeric part
    //        int newNumericPart = latestNumericPart + 1;

    //        // Format the new ID with the prefix M- followed by the incremented numeric part
    //        string formattedId = string.Format("M-{0:D4}", newNumericPart);
    //        MID = formattedId;


    //    }
    //    catch (Exception ex)
    //    {
    //        ex.ToString();
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}

    //Delete Master Admin
    [WebMethod]
    public void DeleteMasterAdmin(string MasterId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete from [dbo].[Master_Admin] where Master_Id=@Master_Id", con, t);
            cmd.Parameters.AddWithValue("@Master_Id", MasterId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Master Admin
    [WebMethod]
    public void GetMasterAdmin()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT *,convert(varchar, [Added_On], 103) as [Date_Convert] FROM [dbo].[Master_Admin]", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception e) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    // Staff Add/Upate
    [WebMethod]
    public void AddStaffCRUD(string Type, string Staff_Id, string SID, string Master_Id, string FirstNane, string MiddleName, string LastName, string Gender, string DOB, string Mobile, string AlterMobile, string Gmail, string RoleId, string Role,
         string DeptId, string Department, string Qualification, string Address, string PanNo, String PanCard, String Photo, string Username, string Password, string AddedById, string AddedByName)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            if (Type == "Insert")
            {
                //AutoGenrateStaff();

                cmd = new SqlCommand(@"INSERT INTO [dbo].[Staff]([ID],[Master_Id],[First_Name],[Middle_Name],[Last_Name],[Gender],[DOB],[Mobile],[Alternate_Mobile],[Gmail],[Role_Id],[Role],[Department_Id],[Department_Name],[Qualification],[Address],[Pan_No],[Pan_Card],[Photo],[Username],[Password],[Added_On],[Added_by_Id],[Added_By_Name])
                VALUES(@ID,@Master_Id,@First_Name,@Middle_Name,@Last_Name,@Gender,@DOB,@Mobile,@Alternate_Mobile,@Gmail,@Role_Id,@Role,@Department_Id,@Department_Name,@Qualification,@Address,@Pan_No,@Pan_Card,@Photo,@Username,@Password,@Added_On,@Added_by_Id,@Added_By_Name)", con);

            }
            else if (Type == "Update")
            {
                cmd = new SqlCommand(@"UPDATE [dbo].[Staff] SET [ID] = @ID,[Master_Id] = @Master_Id,[First_Name] = @First_Name,[Middle_Name] = @Middle_Name,[Last_Name] = @Last_Name,[Gender] = @Gender,
                [DOB] = @DOB,[Mobile] = @Mobile,[Alternate_Mobile] = @Alternate_Mobile,[Gmail] = @Gmail,[Role_Id] = @Role_Id,[Role] = @Role,[Department_Id] = @Department_Id,
                [Department_Name] = @Department_Name,[Qualification] = @Qualification,[Address] = @Address,[Pan_No] = @Pan_No,[Pan_Card] = @Pan_Card,[Photo] = @Photo,
                [Username] = @Username,[Password] = @Password,[Added_On] = @Added_On,[Added_by_Id] = @Added_by_Id,[Added_By_Name] = @Added_By_Name WHERE [Staff_Id]=@Staff_Id", con);

            }
            //else if (Type == "Delete")
            //{
            //    cmd = new SqlCommand(@"Delete from [unifoods].[Office_Staff_Master] where Id=@Id", con);

            //}
            else
            {
                cmd = new SqlCommand(@"", con);
            }
            cmd.Parameters.AddWithValue("@ID", SID);
            cmd.Parameters.AddWithValue("@Staff_Id", Staff_Id);
            cmd.Parameters.AddWithValue("@Master_Id", Master_Id);
            cmd.Parameters.AddWithValue("@First_Name", FirstNane);
            cmd.Parameters.AddWithValue("@Middle_Name", MiddleName);
            cmd.Parameters.AddWithValue("@Last_Name", LastName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Alternate_Mobile", AlterMobile);
            cmd.Parameters.AddWithValue("@Gmail", Gmail);
            cmd.Parameters.AddWithValue("@Role_Id", RoleId);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@Department_Id", DeptId);
            cmd.Parameters.AddWithValue("@Department_Name", Department);
            cmd.Parameters.AddWithValue("@Qualification", Qualification);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Pan_No", PanNo);
            cmd.Parameters.AddWithValue("@Pan_Card", PanCard);
            cmd.Parameters.AddWithValue("@Photo", Photo);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
            cmd.Parameters.AddWithValue("@Added_by_Id", AddedById);
            cmd.Parameters.AddWithValue("@Added_By_Name", AddedByName);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Staff PanrCard Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendStaffPanAttachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Documents/Staff/PanCard/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Staff Photo Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendStaffPhotoAttachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Documents/Staff/Photo/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Staff Id With Prefix
    //protected void AutoGenrateStaff()
    //{
    //    SqlConnection con = new SqlConnection(strcon);
    //    try
    //    {
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM [dbo].[Staff] ORDER BY ID DESC", con);
    //        SqlDataReader reader = cmd.ExecuteReader();
    //        int latestNumericPart = 0001;

    //        // Check if there is a result
    //        if (reader.Read())
    //        {
    //            string latestId = reader["ID"].ToString();

    //            // Extract the numeric part from the ID
    //            string numericPart = latestId.Substring(2); // Assuming the prefix length is fixed at 2 characters
    //            latestNumericPart = int.Parse(numericPart);
    //        }

    //        reader.Close();

    //        // Increment the latest numeric part
    //        int newNumericPart = latestNumericPart + 1;

    //        // Format the new ID with the prefix M- followed by the incremented numeric part
    //        string formattedId = string.Format("S-{0:D4}", newNumericPart);
    //        SID = formattedId;


    //    }
    //    catch (Exception ex)
    //    {
    //        ex.ToString();
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}


    //Delete Staff
    [WebMethod]
    public void DeleteStaff(string StaffId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete from  [dbo].[Staff] where Staff_Id=@Staff_Id", con, t);
            cmd.Parameters.AddWithValue("@Staff_Id", StaffId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Staff
    [WebMethod]
    public void GetStaff()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT *,convert(varchar, [Added_On], 103) as [Date_Convert] FROM [dbo].[Staff]", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception e) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    // Doctor Add/Update
    [WebMethod]
    public void AddDoctorCRUD(string Type, string Doctor_Id, string DID, string Master_Id, string Staff_Id, string FirstNane, string MiddleName, string LastName, string Gender, string DOB, string Mobile, string AlterMobile, string Gmail, string Address,
       string Qualification, String Certificate1, String Certificate2, String Certificate3, string Specilization, string Experiance, string PanNo, String PanCard
        , string AadharNo, String AadharCard, String Photo, string Username, string Password, string AddedById, string AddedByName)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            if (Type == "Insert")
            {
                //AutoGenrateDoctor();

                cmd = new SqlCommand(@"INSERT INTO [dbo].[Doctors]([ID],[Master_Id],[Staff_Id],[First_Name],[Middle_Name],[Last_Name],[Gender],[DOB],[Mobile],[Alternate_Mobile],[Gmail],[Address],
                [Qualification],[Certificate1],[Certificate2],[Certificate3],[Specilization],[Experiance],[Pan_No],[Pan_Card],[Aadhar_No],[Aadhar_Card],[Photo],[Username],
                [Password],[Added_By_Id],[Added_By_Name],[Added_On])VALUES(@ID,@Master_Id,@Staff_Id,@First_Name,@Middle_Name,@Last_Name,@Gender,@DOB,@Mobile,@Alternate_Mobile,
                @Gmail,@Address,@Qualification,@Certificate1,@Certificate2,@Certificate3,@Specilization,@Experiance,@Pan_No,@Pan_Card,@Aadhar_No,@Aadhar_Card,@Photo,@Username,
                @Password,@Added_By_Id,@Added_By_Name,@Added_On)", con);

            }
            else if (Type == "Update")
            {
                cmd = new SqlCommand(@"UPDATE [dbo].[Doctors]SET [ID] = @ID,[Master_Id] = @Master_Id,[Staff_Id] = @Staff_Id,[First_Name] = @First_Name,[Middle_Name] = @Middle_Name,
                [Last_Name] = @Last_Name,[Gender] = @Gender,[DOB] = @DOB,[Mobile] = @Mobile,[Alternate_Mobile] = @Alternate_Mobile,[Gmail] = @Gmail,[Address] = @Address,
                [Qualification] = @Qualification,[Certificate1] = @Certificate1,[Certificate2] = @Certificate2,[Certificate3] = @Certificate3,[Specilization] = @Specilization,
                [Experiance] = @Experiance,[Pan_No] = @Pan_No,[Pan_Card] = @Pan_Card,[Aadhar_No] = @Aadhar_No,[Aadhar_Card] = @Aadhar_Card,[Photo] = @Photo,[Username] = @Username,
                [Password] = @Password,[Added_By_Id] = @Added_By_Id,[Added_By_Name] = @Added_By_Name,[Added_On] = @Added_On WHERE [Doctor_Id]=@Doctor_Id", con);

            }
            //else if (Type == "Delete")
            //{
            //    cmd = new SqlCommand(@"Delete from [unifoods].[Office_Staff_Master] where Id=@Id", con);

            //}
            else
            {
                cmd = new SqlCommand(@"", con);
            }
            cmd.Parameters.AddWithValue("@ID", DID);
            cmd.Parameters.AddWithValue("@Doctor_Id", Doctor_Id);
            cmd.Parameters.AddWithValue("@Master_Id", Master_Id);
            cmd.Parameters.AddWithValue("@Staff_Id", Staff_Id);
            cmd.Parameters.AddWithValue("@First_Name", FirstNane);
            cmd.Parameters.AddWithValue("@Middle_Name", MiddleName);
            cmd.Parameters.AddWithValue("@Last_Name", LastName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Alternate_Mobile", AlterMobile);
            cmd.Parameters.AddWithValue("@Gmail", Gmail);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Qualification", Qualification);
            cmd.Parameters.AddWithValue("@Certificate1", Certificate1);
            cmd.Parameters.AddWithValue("@Certificate2", Certificate2);
            cmd.Parameters.AddWithValue("@Certificate3", Certificate3);
            cmd.Parameters.AddWithValue("@Specilization", Specilization);
            cmd.Parameters.AddWithValue("@Experiance", Experiance);
            cmd.Parameters.AddWithValue("@Pan_No", PanNo);
            cmd.Parameters.AddWithValue("@Pan_Card", PanCard);
            cmd.Parameters.AddWithValue("@Aadhar_No", AadharNo);
            cmd.Parameters.AddWithValue("@Aadhar_Card", AadharCard);
            cmd.Parameters.AddWithValue("@Photo", Photo);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Added_by_Id", AddedById);
            cmd.Parameters.AddWithValue("@Added_By_Name", AddedByName);
            cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Doctor Certificate1 Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendCertificate1Attachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Documents/Doctor/Certificate1/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Doctor Certificate2 Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendCertificate2Attachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Documents/Doctor/Certificate2/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Doctor Certificate3 Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendCertificate3Attachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Documents/Doctor/Certificate3/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Doctor PanCard Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendPanCardAttachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Documents/Doctor/PanCard/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Doctor AadharCard Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendAadharCardAttachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Documents/Doctor/AadharCard/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Doctor Photo Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendPhotoAttachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Documents/Doctor/Photo/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Doctor Id With Prefix
    //protected void AutoGenrateDoctor()
    //{
    //    SqlConnection con = new SqlConnection(strcon);
    //    try
    //    {
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM [dbo].[Doctors] ORDER BY ID DESC", con);
    //        SqlDataReader reader = cmd.ExecuteReader();
    //        int latestNumericPart = 0000;

    //        // Check if there is a result
    //        if (reader.Read())
    //        {
    //            string latestId = reader["ID"].ToString();

    //            // Extract the numeric part from the ID
    //            string numericPart = latestId.Substring(2); // Assuming the prefix length is fixed at 2 characters
    //            latestNumericPart = int.Parse(numericPart);
    //        }

    //        reader.Close();

    //        // Increment the latest numeric part
    //        int newNumericPart = latestNumericPart + 1;

    //        // Format the new ID with the prefix M- followed by the incremented numeric part
    //        string formattedId = string.Format("D-{0:D4}", newNumericPart);
    //        DID = formattedId;


    //    }
    //    catch (Exception ex)
    //    {
    //        ex.ToString();
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}


    //Delete Doctors
    [WebMethod]
    public void DeleteDoctor(string DoctorId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete from  [dbo].[Doctors] where Doctor_Id=@Doctor_Id", con, t);
            cmd.Parameters.AddWithValue("@Doctor_Id", DoctorId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Doctors
    [WebMethod]
    public void GetDoctors()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT *,convert(varchar, [Added_On], 103) as [Date_Convert] FROM [dbo].[Doctors]", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception e) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    // Add/Update Suppliers
    [WebMethod]
    public void AddSupplierCRUD(string Type, string Suplier_ID, string Name, string Gender, string Mobile, string AlterMobile, string Gmail, string GST, string Address,
      string BankName, string IFSCCode, string Branch, string AccountNo, string AddedById, string AddedByName)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            if (Type == "Insert")
            {
                //AutoGenrateDoctor();

                cmd = new SqlCommand(@"INSERT INTO [doctorapp].[Supplier]([Name],[Gender],[Mobile],[Alt_Mobile],
                [Gmail],[GST_No],[Address],[Bank_Name],[IFSC_Code],[Branch],[Account_No],[Addedby_ID],[Addedby_Name],
                [Added_On])VALUES(@Name, @Gender, @Mobile, @Alt_Mobile,@Gmail, @GST_No, @Address, @Bank_Name, 
                @IFSC_Code, @Branch, @Account_No, @Addedby_ID, @Addedby_Name, @Added_On)", con);

            }
            else if (Type == "Update")
            {
                cmd = new SqlCommand(@"UPDATE [doctorapp].[Supplier] SET [Name] = @Name ,[Gender] = @Gender ,
                [Mobile] = @Mobile ,[Alt_Mobile] = @Alt_Mobile ,[Gmail] = @Gmail,[GST_No] = @GST_No,
                [Address] = @Address,[Bank_Name] = @Bank_Name,[IFSC_Code] = @IFSC_Code,[Branch] = @Branch,
                [Account_No] = @Account_No,[Addedby_ID] = @Addedby_ID,[Addedby_Name] = @Addedby_Name,
                [Added_On] = @Added_On WHERE [Suplier_ID]=@Suplier_ID", con);

            }
            //else if (Type == "Delete")
            //{
            //    cmd = new SqlCommand(@"Delete from [unifoods].[Office_Staff_Master] where Id=@Id", con);

            //}
            else
            {
                cmd = new SqlCommand(@"", con);
            }

            cmd.Parameters.AddWithValue("@Suplier_ID", Suplier_ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Alt_Mobile", AlterMobile);
            cmd.Parameters.AddWithValue("@Gmail", Gmail);
            cmd.Parameters.AddWithValue("@GST_No", GST);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Bank_Name", BankName);
            cmd.Parameters.AddWithValue("@IFSC_Code", IFSCCode);
            cmd.Parameters.AddWithValue("@Branch", Branch);
            cmd.Parameters.AddWithValue("@Account_No", AccountNo);
            cmd.Parameters.AddWithValue("@Addedby_ID", AddedById);
            cmd.Parameters.AddWithValue("@Addedby_Name", AddedByName);
            cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Delete Suppliers
    [WebMethod]
    public void DeleteSupplier(string SuplierID)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete from  [doctorapp].[Supplier] where Suplier_ID=@Suplier_ID", con, t);
            cmd.Parameters.AddWithValue("@Suplier_ID", SuplierID);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Suppliers
    [WebMethod]
    public void GetSuppliers()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT *,convert(varchar, [Added_On], 103) as [Date_Convert] FROM [doctorapp].[Supplier]", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception e) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Add Expense(Bill Entry)
    [WebMethod]
    public void BillEntry(string BillNo, string BillDate, string Title, string CategoryId, string Category, string Supplier_Id, string Suplier,
        String Attachment, string Description, string Status, string PamentAmount, string PaidAmount, string BalanceAmount, string AddedById, string AddedByName)
    {
        Int32 ID123 = 0;
        SqlTransaction t;
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        con.Open();
        t = con.BeginTransaction();
        try
        {

            //AutoGenrateDoctor();

            cmd = new SqlCommand(@"INSERT INTO [doctorapp].[Bill_Entry]([Bill_No],[Bill_Date],[Title],[Category_Id],
                [Category],[Supplier_Id],[Suplier],[Attachment],[Description],[Status],[Pament_Amount],[Paid_Amount],
                [Balance_Amount],[Addedby_Id],[Addedby_Name],[Added_On]) VALUES(@Bill_No,@Bill_Date,@Title,@Category_Id,@Category,
                @Supplier_Id,@Suplier,@Attachment,@Description,@Status,@Pament_Amount,@Paid_Amount,@Balance_Amount,@Addedby_Id,
                @Addedby_Name,@Added_On);SELECT SCOPE_IDENTITY();", con, t);

            cmd.Parameters.AddWithValue("@Bill_No", BillNo);
            cmd.Parameters.AddWithValue("@Bill_Date", BillDate);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Category_Id", CategoryId);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id);
            cmd.Parameters.AddWithValue("@Suplier", Suplier);
            cmd.Parameters.AddWithValue("@Attachment", Attachment);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Pament_Amount", PamentAmount);
            if (PaidAmount == "")
            {
                cmd.Parameters.AddWithValue("@Paid_Amount", "0.00");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Paid_Amount", PaidAmount);

            }
            cmd.Parameters.AddWithValue("@Balance_Amount", BalanceAmount);
            cmd.Parameters.AddWithValue("@Addedby_Id", AddedById);
            cmd.Parameters.AddWithValue("@Addedby_Name", AddedByName);
            cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
            ID123 = Convert.ToInt32(cmd.ExecuteScalar());

            //Insert Pay Log
            cmd = new SqlCommand(@"INSERT INTO [doctorapp].[Bill_Pay_Log]([Bill_Id],[Payment_Amount],[Paid_Amount],
            [Balance_Amount],[Payment_Date],[AddedBy_Id],[AddedBy_Name]) VALUES(@Bill_Id,@Payment_Amount,
            @Paid_Amount,@Balance_Amount,@Payment_Date,@AddedBy_Id,@AddedBy_Name)", con, t);
            cmd.Parameters.AddWithValue("@Bill_Id", ID123);
            cmd.Parameters.AddWithValue("@Payment_Amount", PamentAmount);
            if (PaidAmount == "")
            {
                cmd.Parameters.AddWithValue("@Paid_Amount", "0.00");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Paid_Amount", PaidAmount);

            }
            cmd.Parameters.AddWithValue("@Balance_Amount", BalanceAmount);
            cmd.Parameters.AddWithValue("@Payment_Date", DateTime.Now);
            cmd.Parameters.AddWithValue("@AddedBy_Id", AddedById);
            cmd.Parameters.AddWithValue("@AddedBy_Name", AddedByName);
            res = cmd.ExecuteNonQuery();
            t.Commit();
            if (res == 1) status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
        }
        catch (Exception ex)
        {

            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Bills Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendBillAttachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Bills/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Get Bill Entry

    [WebMethod]
    public void GetBillEntry()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT * FROM [doctorapp].[Bill_Entry] Order By Bill_Id", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception e) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Delete Bills
    [WebMethod]
    public void DeleteBillsEntry(string BillId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete from  [doctorapp].[Bill_Entry] where Bill_Id=@Bill_Id", con, t);
            cmd.Parameters.AddWithValue("@Bill_Id", BillId);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand(@"Delete from  [doctorapp].[Bill_Pay_Log] where Bill_Id=@Bill_Id", con, t);
            cmd.Parameters.AddWithValue("@Bill_Id", BillId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //PayBillAmounts
    [WebMethod]
    public void BillsPay(string BillId, string PaymentAmount, string PaidAmount, string BalanceAmount, string AddedById, string AddedByName)
    {

        SqlTransaction t;
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        con.Open();
        t = con.BeginTransaction();
        try
        {

            //AutoGenrateDoctor();

            cmd = new SqlCommand(@"INSERT INTO [doctorapp].[Bill_Pay_Log]([Bill_Id],[Payment_Amount],[Paid_Amount],
                                 [Balance_Amount],[Payment_Date],[AddedBy_Id],[AddedBy_Name]) VALUES(@Bill_Id,@Payment_Amount,@Paid_Amount,
                                 @Balance_Amount,@Payment_Date,@AddedBy_Id,@AddedBy_Name)", con, t);

            cmd.Parameters.AddWithValue("@Bill_Id", BillId);
            cmd.Parameters.AddWithValue("@Payment_Amount", PaymentAmount);
            cmd.Parameters.AddWithValue("@Paid_Amount", PaidAmount);
            cmd.Parameters.AddWithValue("@Balance_Amount", BalanceAmount);
            cmd.Parameters.AddWithValue("@Payment_Date", DateTime.Now);
            cmd.Parameters.AddWithValue("@Addedby_Id", AddedById);
            cmd.Parameters.AddWithValue("@Addedby_Name", AddedByName);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("Select Paid_Amount,Balance_Amount From [doctorapp].[Bill_Entry] where [Bill_Id]=@Bill_Id ", con, t);
            cmd.Parameters.AddWithValue("@Bill_Id", BillId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                decimal paidAmount = reader.GetDecimal(0);
                decimal balanceAmount = reader.GetDecimal(1);

                // Convert txtbalance.Text and txtpay.Text to decimal values
                decimal additionalBalance = decimal.Parse(BalanceAmount);
                decimal additionalPaid = decimal.Parse(PaidAmount);

                // Update total balance and total paid amounts
                totalbal = balanceAmount - additionalPaid;
                totalpaid = paidAmount + additionalPaid;

                //// Assign the updated amounts to the respective labels
                //lblbalamt.Text = totalbal.ToString();
                //lblpaidamt.Text = totalpaid.ToString();
            }
            reader.Close();

            //Insert Pay Log
            cmd = new SqlCommand(@"Update [doctorapp].[Bill_Entry] Set [Status]=@Status, [Paid_Amount]=@Paid_Amount,
                    [Balance_Amount]=@Balance_Amount where [Bill_Id]=@Bill_Id", con, t);
            cmd.Parameters.AddWithValue("@Bill_Id", BillId);
            if (BalanceAmount == "0.00")
            {
                cmd.Parameters.AddWithValue("@Status", "Paid");
            }
            else if (BalanceAmount != "0.00")
            {
                cmd.Parameters.AddWithValue("@Status", "Partial Paid");
            }

            cmd.Parameters.AddWithValue("@Paid_Amount", totalpaid);
            cmd.Parameters.AddWithValue("@Balance_Amount", totalbal);
            cmd.ExecuteNonQuery();
            res = cmd.ExecuteNonQuery();
            t.Commit();
            if (res == 1) status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
        }
        catch (Exception ex)
        {

            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Setting
    //Add Role
    [WebMethod]
    public void AddRole(string Role)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            cmd = new SqlCommand(@"Insert Into [dbo].[Staff_Role] ([Role_Name]) values (@Role_Name)", con);
            cmd.Parameters.AddWithValue("@Role_Name", Role);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Delete Role
    [WebMethod]
    public void DeleteRoll(string RoleId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete from [dbo].[Staff_Role] where Role_Id=@Role_Id", con, t);
            cmd.Parameters.AddWithValue("@Role_Id", RoleId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Role
    [WebMethod]
    public void GetRole()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT * FROM [dbo].[Staff_Role] Order By Role_Id", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception e) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }


    //Add Department
    [WebMethod]
    public void AddDepartment(string DepartmentName)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            cmd = new SqlCommand(@"Insert Into [dbo].[Department] ([Department_Name]) values (@Department_Name)", con);
            cmd.Parameters.AddWithValue("@Department_Name", DepartmentName);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Delete Department
    [WebMethod]
    public void DeleteDepartment(string DepartmentId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete From [dbo].[Department] where Department_Id=@Department_Id", con, t);
            cmd.Parameters.AddWithValue("@Department_Id", DepartmentId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Department
    [WebMethod]
    public void GetDepartment()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Department] order by Department_Id", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception e) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }


    //Add Product Type
    [WebMethod]
    public void AddProductType(string ProductType)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            cmd = new SqlCommand(@"Insert Into [dbo].[Product_Type] ([Product_Type]) values (@Product_Type)", con);
            cmd.Parameters.AddWithValue("@Product_Type", ProductType);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Delete Product Type
    [WebMethod]
    public void DeleteProductType(string TypeId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete From [dbo].[Product_Type] where Type_Id=@Type_Id", con, t);
            cmd.Parameters.AddWithValue("@Type_Id", TypeId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Product Type
    [WebMethod]
    public void GetProductType()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Product_Type] order by Type_Id ", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception e) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }


    //Add Product Sub Type
    [WebMethod]
    public void AddProductSubType(string TypeId, string ProductType, string ProductSubType)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            cmd = new SqlCommand(@"Insert Into [dbo].[Product_Sub_Type] ([Type_Id],[Product_Type],[Product_Sub_Type]) values (@Type_Id,@Product_Type,@Product_Sub_Type)", con);
            cmd.Parameters.AddWithValue("@Type_Id", TypeId);
            cmd.Parameters.AddWithValue("@Product_Type", ProductType);
            cmd.Parameters.AddWithValue("@Product_Sub_Type", ProductSubType);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Delete Product Sub Type
    [WebMethod]
    public void DeleteProductSubType(string SubTypeId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete From [Product_Sub_Type] where Sub_Type_Id=@Sub_Type_Id", con, t);
            cmd.Parameters.AddWithValue("@Sub_Type_Id", SubTypeId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Product Sub Type
    [WebMethod]
    public void GetProductSubType()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Product_Sub_Type] order by Sub_Type_Id ", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Add Product
    [WebMethod]
    public void AddProduct(string Type, string ProductId, string TypeId, string ProductType, string ProductSubTypeId, string ProductSubType,
        string ProductName, string Price, string Quantity, String Image, String MultipleImage, string productDetails)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            if (Type == "Insert")
            {
                //AutoGenrateMaster();
                cmd = new SqlCommand(@"INSERT INTO [dbo].[Add_Products]([Type_Id],[Product_Type],[Sub_Type_Id],[Product_Sub_Type],[Product_Name],[Price],[Quantity],[Image],[Multiple_Image],[Product_Details])VALUES(@Type_Id,@Product_Type,@Sub_Type_Id,@Product_Sub_Type,@Product_Name,@Price,@Quantity,@Image,@Multiple_Image,@Product_Details)", con);

            }
            else if (Type == "Update")
            {
                cmd = new SqlCommand(@"UPDATE [dbo].[Add_Products] SET [Type_Id] = @Type_Id,[Product_Type] = @Product_Type,[Sub_Type_Id] = @Sub_Type_Id,[Product_Sub_Type] = @Product_Sub_Type,[Product_Name] = @Product_Name,[Price] = @Price,[Quantity] = @Quantity, [Image] = @Image,[Multiple_Image] = @Multiple_Image,[Product_Details] = @Product_Details WHERE [Product_Id]=@Product_Id", con);

            }
            //else if (Type == "Delete")
            //{
            //    cmd = new SqlCommand(@"Delete from [unifoods].[Office_Staff_Master] where Id=@Id", con);

            //}
            else
            {
                cmd = new SqlCommand(@"", con);
            }
            cmd.Parameters.AddWithValue("@Product_Id", ProductId);
            cmd.Parameters.AddWithValue("@Type_Id", TypeId);
            cmd.Parameters.AddWithValue("@Product_Type", ProductType);
            cmd.Parameters.AddWithValue("@Sub_Type_Id", ProductSubTypeId);
            cmd.Parameters.AddWithValue("@Product_Sub_Type", ProductSubType);
            cmd.Parameters.AddWithValue("@Product_Name", ProductName);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Image", Image);
            cmd.Parameters.AddWithValue("@Multiple_Image", MultipleImage);
            cmd.Parameters.AddWithValue("@Product_Details", productDetails);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Product Image Attachment
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SendImagesAttachment()
    {
        try
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["file"];
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Product_Image/" + file.FileName));

        }
        catch (Exception ex)
        {
            string e = ex.ToString();
        }
    }

    //Delete Product
    [WebMethod]
    public void DeleteProducts(string ProductId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete From [dbo].[Add_Products] where Product_Id=@Product_Id", con, t);
            cmd.Parameters.AddWithValue("@Product_Id", ProductId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Product
    [WebMethod]
    public void GetProduct()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Add_Products] order by Product_Id ", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Shift Shedule
    [WebMethod]
    public void AddShift(string Type, string ShiftId, string StaffId, string StaffName, string RoleId, string Role,
        string ShiftDate, string ShiftfromTime, string ShifttoTime, string ShiftType, string DepartmentId, string Departmet, string AddedById, string AddedByName)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            if (Type == "Insert")
            {
                //AutoGenrateMaster();
                cmd = new SqlCommand(@"INSERT INTO [dbo].[Shift_Master] ([Staff_Id], [Staff_Name], [Role_Id], [Role], [Shift_Date], [Shift_Time], [Shift_Type], [Department_Id], [Departmet], [Added_By_Id], [Added_By_Name]) VALUES (@Staff_Id, @Staff_Name, @Role_Id, @Role, @Shift_Date, @Shift_Time, @Shift_Type, @Department_Id, @Departmet, @Added_By_Id, @Added_By_Name)", con);

            }
            else if (Type == "Update")
            {
                cmd = new SqlCommand(@"UPDATE [dbo].[Shift_Master]SET [Staff_Id] = @Staff_Id ,[Staff_Name] = @Staff_Name ,[Role_Id] = @Role_Id ,[Role] = @Role ,[Shift_Date] = @Shift_Date ,[Shift_Time] = @Shift_Time ,[Shift_Type] = @Shift_Type ,[Department_Id] = @Department_Id ,[Departmet] = @Departmet ,[Added_By_Id] = @Added_By_Id ,[Added_By_Name] = @Added_By_Name WHERE [Shift_Id]=@Shift_Id", con);

            }
            //else if (Type == "Delete")
            //{
            //    cmd = new SqlCommand(@"Delete from [unifoods].[Office_Staff_Master] where Id=@Id", con);

            //}
            else
            {
                cmd = new SqlCommand(@"", con);
            }
            cmd.Parameters.AddWithValue("@Shift_Id", ShiftId);
            cmd.Parameters.AddWithValue("@Staff_Id", StaffId);
            cmd.Parameters.AddWithValue("@Staff_Name", StaffName);
            cmd.Parameters.AddWithValue("@Role_Id", RoleId);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@Shift_Date", ShiftDate);
            cmd.Parameters.AddWithValue("@Shift_Time", ShiftfromTime + " TO " + ShifttoTime);
            cmd.Parameters.AddWithValue("@Shift_Type", ShiftType);
            cmd.Parameters.AddWithValue("@Department_Id", DepartmentId);
            cmd.Parameters.AddWithValue("@Departmet", Departmet);
            //cmd.Parameters.AddWithValue("@Unit_Id", ddlunit.SelectedValue);
            //cmd.Parameters.AddWithValue("@Unit", ddlunit.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Added_By_Id", AddedById);
            cmd.Parameters.AddWithValue("@Added_By_Name", AddedByName);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Delete shift
    [WebMethod]
    public void DeleteShift(string ShiftId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete From [dbo].[Shift_Master] where Shift_Id=@Shift_Id", con, t);
            cmd.Parameters.AddWithValue("@Shift_Id", ShiftId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get shiftdetals
    [WebMethod]
    public void GetShift()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Shift_Master] order by Shift_Id ", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }



    //Add/Update Patients

    [WebMethod]
    public void AddPatientCRUD(string Type, string PaitentId, string StaffId, string FirstNane, string MiddleName, string LastName, string Gender, string DOB, string Age, string Mobile, string AlternateMobile, string Gmail, string Address,
  string Username, string EmergencyFirstName, string EmergencyLastName, string Relationship, string EmergencyMobile, string FamilyDoctorName, string FamilyDoctorMobile, string HealthIssue, string MedicalHistory, String Prescriptions,
  String Reports, string CurrentMedicine, string ListMedicine, string InsuranceCompany, string InsuranceId, string Insurancetype, string InsuranceDetails, string VisitDate, string AddedById, string AddedByName)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            if (Type == "Insert")
            {
                //AutoGenrateDoctor();

                cmd = new SqlCommand(@"INSERT INTO[dbo].[Paitents_Registration]([Staff_Id],[First_Name],[Middle_Name],
                [Last_Name],[Gender],[DOB],[Age],[Mobile],[Alternate_Mobile],[Gmail],[Address],[Username],[Password],
                [Emergency_First_Name],[Emergency_Last_Name],[Relationship],[Emergency_Mobile],[Family_Doctor_Name],
                [Family_Doctor_Mobile],[Health_Issue],[Medical_History],[Prescriptions],[Reports],[Current_Medicine],
                [List_Medicine],[Insurance_Company],[Insurance_Id],[Insurance_type],[Insurance_Details],[Added_By_Id],
                [Added_By_Name],[Added_On]) VALUES(@Staff_Id, @First_Name, @Middle_Name, @Last_Name, @Gender, @DOB, @Age,
                @Mobile, @Alternate_Mobile, @Gmail, @Address,@Username,@Password, @Emergency_First_Name, 
                @Emergency_Last_Name, @Relationship, @Emergency_Mobile, @Family_Doctor_Name, @Family_Doctor_Mobile,
                @Health_Issue, @Medical_History, @Prescriptions, @Reports, @Current_Medicine, @List_Medicine, 
                @Insurance_Company, @Insurance_Id, @Insurance_type, @Insurance_Details, @Added_By_Id, @Added_By_Name,
                @Added_On)", con);
            }
            else if (Type == "Update")
            {
                cmd = new SqlCommand(@"UPDATE [dbo].[Paitents_Registration]SET [First_Name] = @First_Name ,
                [Middle_Name] = @Middle_Name ,[Last_Name] = @Last_Name ,[Gender] = @Gender ,[DOB] = @DOB ,
                [Age] = @Age ,[Mobile] = @Mobile ,[Alternate_Mobile] = @Alternate_Mobile ,[Gmail] = @Gmail ,
                [Address] = @Address ,[Emergency_First_Name] = @Emergency_First_Name ,
                [Emergency_Last_Name] = @Emergency_Last_Name ,[Relationship] = @Relationship ,
                [Emergency_Mobile] = @Emergency_Mobile ,[Family_Doctor_Name] = @Family_Doctor_Name ,
                [Family_Doctor_Mobile] = @Family_Doctor_Mobile ,[Health_Issue] = @Health_Issue ,
                [Medical_History] = @Medical_History ,[Prescriptions] = @Prescriptions ,[Reports] = @Reports ,
                [Current_Medicine] = @Current_Medicine ,[List_Medicine] = @List_Medicine ,
                [Insurance_Company] = @Insurance_Company ,[Insurance_Id] = @Insurance_Id ,
                [Insurance_type] = @Insurance_type ,[Insurance_Details] = @Insurance_Details  WHERE Paitent_Id=@Paitent_Id", con);

            }
            //else if (Type == "Delete")
            //{
            //    cmd = new SqlCommand(@"Delete from [unifoods].[Office_Staff_Master] where Id=@Id", con);

            //}
            else
            {
                cmd = new SqlCommand(@"", con);
            }
            cmd.Parameters.AddWithValue("@Paitent_Id", PaitentId);
            cmd.Parameters.AddWithValue("@Staff_Id", StaffId);
            cmd.Parameters.AddWithValue("@First_Name", FirstNane);
            cmd.Parameters.AddWithValue("@Middle_Name", MiddleName);
            cmd.Parameters.AddWithValue("@Last_Name", LastName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Alternate_Mobile", AlternateMobile);
            cmd.Parameters.AddWithValue("@Gmail", Gmail);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", "patient@123");
            cmd.Parameters.AddWithValue("@Emergency_First_Name", EmergencyFirstName);
            cmd.Parameters.AddWithValue("@Emergency_Last_Name", EmergencyLastName);
            cmd.Parameters.AddWithValue("@Relationship", Relationship);
            cmd.Parameters.AddWithValue("@Emergency_Mobile", EmergencyMobile);
            cmd.Parameters.AddWithValue("@Family_Doctor_Name", FamilyDoctorName);
            cmd.Parameters.AddWithValue("@Family_Doctor_Mobile", FamilyDoctorMobile);
            cmd.Parameters.AddWithValue("@Health_Issue", HealthIssue);
            cmd.Parameters.AddWithValue("@Medical_History", MedicalHistory);
            cmd.Parameters.AddWithValue("@Prescriptions", Prescriptions);
            cmd.Parameters.AddWithValue("@Reports", Reports);
            cmd.Parameters.AddWithValue("@Current_Medicine", CurrentMedicine);
            cmd.Parameters.AddWithValue("@List_Medicine", ListMedicine);
            cmd.Parameters.AddWithValue("@Insurance_Company ", InsuranceCompany);
            cmd.Parameters.AddWithValue("@Insurance_Id", InsuranceId);
            cmd.Parameters.AddWithValue("@Insurance_type", Insurancetype);
            cmd.Parameters.AddWithValue("@Insurance_Details", InsuranceDetails);
            cmd.Parameters.AddWithValue("@Visit_Date", VisitDate);
            cmd.Parameters.AddWithValue("@Added_by_Id", AddedById);
            cmd.Parameters.AddWithValue("@Added_By_Name", AddedByName);
            cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }


    //Delete Patients
    [WebMethod]
    public void DeletePatients(string PaitentId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        SqlTransaction t;
        con.Open();
        t = con.BeginTransaction();

        try
        {
            cmd = new SqlCommand(@"Delete From [dbo].[Paitents_Registration] where Paitent_Id=@Paitent_Id", con, t);
            cmd.Parameters.AddWithValue("@Paitent_Id", PaitentId);
            cmd.ExecuteNonQuery();

            t.Commit();
            status.status = 1;

        }
        catch (SqlException sq)
        {
            t.Rollback();
            status.status = 0;
        }
        catch (Exception e)
        {
            String ex = e.ToString();
        }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get shiftdetals
    [WebMethod]
    public void GetPatients()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Paitents_Registration] order by Paitent_Id ", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }


    //Doctor Login
    [WebMethod]
    public void DoctorLogin(string Username, string Password)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        VerificationStatus status = new VerificationStatus();
        status.status = 0;

        try
        {

            con.Open();
            cmd = new SqlCommand("SELECT Doctor_Id,First_Name,Last_Name FROM [dbo].[Doctors] where [Username]=@Username and [Password]=@Password", con);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);


            DataTable dt1 = new DataTable();
            new SqlDataAdapter(cmd).Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                status.status = 1;

            }

        }

        catch (Exception ex)
        {
            string e = ex.ToString();
        }
        finally
        {
            con.Close();
        }



        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Get Doctors Assign Patients
    [WebMethod]
    public void GetAssignPatients(string AppointToId)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Appointment] where  Appoint_To_Id=@Appoint_To_Id order by Appointment_Id desc ", con);
        cmd.Parameters.AddWithValue("@Appoint_To_Id", AppointToId);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Patient Check Up




    //Patient Login

    [WebMethod]
    public void PatientLogin(string Username, string Password)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        VerificationStatus status = new VerificationStatus();
        status.status = 0;

        try
        {

            con.Open();
            cmd = new SqlCommand("SELECT Paitent_Id,First_Name,Last_Name FROM [dbo].[Paitents_Registration] where [Username]=@Username and [Password]=@Password", con);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);


            DataTable dt1 = new DataTable();
            new SqlDataAdapter(cmd).Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                status.status = 1;

            }

        }

        catch (Exception ex)
        {
            string e = ex.ToString();
        }
        finally
        {
            con.Close();
        }



        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Appoinment Schedule

    [WebMethod]
    public void AppointmentSchedule(string PaitentId, string Name, string DOB, string Age,
        string Gender, string Mobile, string AlternateMobile, string Gmail, string Address, string AppointmentReason,
        string AppointmentType, string AppoitmentDate, string TimeSlot, string ContactPreferance, string AppointToId,
        string AppointToName, string Status, string AddedById, string AddedByName)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();

            //AutoGenrateMaster();
            cmd = new SqlCommand(@"INSERT INTO [dbo].[Appointment]([Paitent_Id],[Name],[DOB],[Age],[Gender],[Mobile],[Alternate_Mobile],[Gmail],[Address],[Appointment_Reason],[Appointment_Type],[Appoitment_Date],[Time_Slot],[Contact_Preferance],[Appoint_To_Id],[Appoint_To_Name],[Status],[Added_By_Id],[Added_By_Name],[Added_On]) VALUES(@Paitent_Id,@Name,@DOB,@Age,@Gender,@Mobile,@Alternate_Mobile,@Gmail,@Address,@Appointment_Reason,@Appointment_Type,@Appoitment_Date,@Time_Slot,@Contact_Preferance,@Appoint_To_Id,@Appoint_To_Name,@Status,@Added_By_Id,@Added_By_Name,@Added_On)", con);

            //cmd.Parameters.AddWithValue("@Appointment_Id", AppointmentId);
            cmd.Parameters.AddWithValue("@Paitent_Id", PaitentId);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Alternate_Mobile", AlternateMobile);
            cmd.Parameters.AddWithValue("@Gmail", Gmail);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Appointment_Reason", AppointmentReason);
            cmd.Parameters.AddWithValue("@Appointment_Type", AppointmentType);
            cmd.Parameters.AddWithValue("@Appoitment_Date", AppoitmentDate);
            cmd.Parameters.AddWithValue("@Time_Slot", TimeSlot);
            cmd.Parameters.AddWithValue("@Contact_Preferance", ContactPreferance);
            cmd.Parameters.AddWithValue("@Appoint_To_Id", AppointToId);
            cmd.Parameters.AddWithValue("@Appoint_To_Name", AppointToName);

            cmd.Parameters.AddWithValue("@Status", "Pending");

            cmd.Parameters.AddWithValue("@Added_By_Id", AddedById);
            cmd.Parameters.AddWithValue("@Added_By_Name", AddedByName);
            cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //Appointment View
    [WebMethod]
    public void GetPatientAppointment(string PaitentId)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Appointment] where  [Paitent_Id]=@Paitent_Id order by Appointment_Id desc ", con);
        cmd.Parameters.AddWithValue("@Paitent_Id", PaitentId);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Cancle Appointment
    [WebMethod]
    public void CancleAppointment(string AppointmentId)
    {
        Status status = new Status();
        status.status = 0;
        int res = 0;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;

        try
        {
            con.Open();
            cmd = new SqlCommand(@"Update [dbo].[Appointment] set [Status]=@Status where Appointment_Id=@Appointment_Id", con);
            cmd.Parameters.AddWithValue("@Appointment_Id", AppointmentId);
            cmd.Parameters.AddWithValue("@Status", "Cancle");
            res = cmd.ExecuteNonQuery();
            if (res == 1) status.status = 1;

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
        Context.Response.Write(new JavaScriptSerializer().Serialize(status));
    }

    //View CheckUp Details
    [WebMethod]
    public void GetCheckUpDetails(string PaitentId)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Check_Up] where  [Patient_Id]=@Patient_Id  ", con);
        cmd.Parameters.AddWithValue("@Patient_Id", PaitentId);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }


    //Get Shift Staff
    [WebMethod]
    public void GetShiftStaff()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select [Staff_Id],[First_Name],[Last_Name] from [dbo].[Staff] where  [Role]!=@Role  ", con);
        cmd.Parameters.AddWithValue("@Role", "Admin");
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Get staff Count
    [WebMethod]
    public void GetStaffCount()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select count(*) from [dbo].[Staff]", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                row["StaffCount"] = dt.Rows[0][0];
                list.Add(row);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Get Doctors Count
    [WebMethod]
    public void GetDoctorsCount()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT COUNT(*) FROM [dbo].[Doctors]", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                row["DoctorsCount"] = dt.Rows[0][0];
                list.Add(row);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Get Patients Count
    [WebMethod]
    public void GetPatientsCount()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select count(*) from [dbo].[Paitents_Registration]", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                row["PatientsCount"] = dt.Rows[0][0];
                list.Add(row);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Get Total Collection
    [WebMethod]
    public void GetTotalCollection()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT SUM(Fees) FROM [dbo].[Check_Up]", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                row["TotalFees"] = dt.Rows[0][0];
                list.Add(row);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }


    //Get Todays Collection
    [WebMethod]
    public void GetTodayCollection()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT SUM(Fees) FROM [dbo].[Check_Up] WHERE CONVERT(date, Checked_On) = CONVERT(date, GETDATE()) ", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);

            // Add data from dt1 to list1
            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                row["TodayFees"] = dt.Rows[0][0];
                list.Add(row);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Get Todays Appointments
    [WebMethod]
    public void GetTodaysAppointment()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT COUNT(*) FROM [dbo].[Appointment] WHERE CONVERT(date, [Added_On]) = CONVERT(date, GETDATE())", con);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                row["TodaysAppointment"] = dt.Rows[0][0];
                list.Add(row);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Get Today Task Count
    [WebMethod]
    public void GetTodayTaskCount(string StaffId)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT COUNT(*) FROM [dbo].[Shift_Master] WHERE CONVERT(date, [Shift_Date]) = CONVERT(date, GETDATE()) and [Staff_Id]=@Staff_Id ", con);
        cmd.Parameters.AddWithValue("@Staff_Id", StaffId);

        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                row["TodaysTask"] = dt.Rows[0][0];
                list.Add(row);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //Get Today Task Count
    [WebMethod]
    public void GetTotalTaskCount(string StaffId)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"SELECT COUNT(*) FROM [dbo].[Shift_Master] where [Staff_Id]=@Staff_Id", con);
        cmd.Parameters.AddWithValue("@Staff_Id", StaffId);

        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                row["TotalTask"] = dt.Rows[0][0];
                list.Add(row);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    //View Task Details
    [WebMethod]
    public void GetTaskDetails(string StaffId)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        cmd = new SqlCommand(@"select * from [dbo].[Shift_Master] where  [Staff_Id]=@Staff_Id  ", con);
        cmd.Parameters.AddWithValue("@Staff_Id", StaffId);
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        try
        {
            con.Open();

            DataTable dt = new DataTable();

            new SqlDataAdapter(cmd).Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Dictionary<string, object> row;

                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    list.Add(row);
                }
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }

        Context.Response.Write(new JavaScriptSerializer().Serialize(list));

    }

    public class VerificationStatus
    {
        public int status { get; set; }

    }

    public class Status
    {
        public int status { get; set; }
    }
}
