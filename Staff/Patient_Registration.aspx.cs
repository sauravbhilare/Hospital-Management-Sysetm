using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Patient_Registration : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblstaffid.Text = ((Label)Master.FindControl("lblstaffid")).Text;
        lblname.Text = ((Label)Master.FindControl("lblstaffname")).Text;
        if (!IsPostBack)
        {
            if (Request.QueryString["PaitentId"] != null && Request.QueryString["PaitentId"] != String.Empty)
            {
                lblpatientid.Text = Request.QueryString["PaitentId"];
                Bind();
                btnsubmit.Text = "Update";

            }
        }
    }
    public void btnsubmit_OnClick(object sender, EventArgs e)
    {
        string f1 = "", f2 = "";
        string fileName = string.Empty;
        Random r = new Random();
        bool IsValidFile = false;

        if (btnsubmit.Text == "Submit")
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO[dbo].[Paitents_Registration]([Staff_Id],[First_Name],[Middle_Name],[Last_Name],[Gender],[DOB],[Age],[Mobile],[Alternate_Mobile],[Gmail],[Address],[Username],[Password],[Emergency_First_Name],[Emergency_Last_Name],[Relationship],[Emergency_Mobile],[Family_Doctor_Name],[Family_Doctor_Mobile],[Health_Issue],[Medical_History],[Prescriptions],[Reports],[Current_Medicine],[List_Medicine],[Insurance_Company],[Insurance_Id],[Insurance_type],[Insurance_Details],[Added_By_Id],[Added_By_Name],[Added_On]) VALUES(@Staff_Id, @First_Name, @Middle_Name, @Last_Name, @Gender, @DOB, @Age, @Mobile, @Alternate_Mobile, @Gmail, @Address,@Username,@Password, @Emergency_First_Name, @Emergency_Last_Name, @Relationship, @Emergency_Mobile, @Family_Doctor_Name, @Family_Doctor_Mobile, @Health_Issue, @Medical_History, @Prescriptions, @Reports, @Current_Medicine, @List_Medicine, @Insurance_Company, @Insurance_Id, @Insurance_type, @Insurance_Details, @Added_By_Id, @Added_By_Name,@Added_On)", con);
                cmd.Parameters.AddWithValue("@Staff_Id", lblstaffid.Text);
                cmd.Parameters.AddWithValue("@First_Name", txtfname.Text);
                cmd.Parameters.AddWithValue("@Middle_Name", txtmname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlname.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                if (!txtdob.Text.Equals(""))
                {
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtdob.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Alternate_Mobile", txtaltmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Username", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Password", "patient@123");
                cmd.Parameters.AddWithValue("@Emergency_First_Name", txtefname.Text);
                cmd.Parameters.AddWithValue("@Emergency_Last_Name", txtelname.Text);
                cmd.Parameters.AddWithValue("@Relationship", txtrelationship.Text);
                cmd.Parameters.AddWithValue("@Emergency_Mobile", txtemobile.Text);
                cmd.Parameters.AddWithValue("@Family_Doctor_Name", txtfamilydoc.Text);
                cmd.Parameters.AddWithValue("@Family_Doctor_Mobile", txtdocmobile.Text);
                cmd.Parameters.AddWithValue("@Health_Issue", txtreason.Text);
                cmd.Parameters.AddWithValue("@Medical_History", txtmedicalhistory.Text);


                if (prescriptfile.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(prescriptfile.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = prescriptfile.FileName;
                    //f1 = ID + fileName;
                    f1 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        prescriptfile.SaveAs(Server.MapPath("/Documents/Patient/Prescriptions/" + f1));
                        cmd.Parameters.AddWithValue("@Prescriptions", f1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Prescriptions File not valid');", true);
                        cmd.Parameters.AddWithValue("@Prescriptions", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Prescriptions", "");
                }

                if (filereports.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(filereports.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = filereports.FileName;
                    //f1 = ID + fileName;
                    f2 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        filereports.SaveAs(Server.MapPath("/Documents/Patient/Reports/" + f2));
                        cmd.Parameters.AddWithValue("@Reports", f2);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Pan_Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Reports", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Reports", "");
                }

                string medicationValue = rdoyes.Checked ? rdoyes.Text : rdono.Text;
                cmd.Parameters.AddWithValue("@Current_Medicine", medicationValue);
                cmd.Parameters.AddWithValue("@List_Medicine", txtmediciitems.Text);
                cmd.Parameters.AddWithValue("@Insurance_Company", txtinsurancecompany.Text);
                cmd.Parameters.AddWithValue("@Insurance_Id", txtinsuranceid.Text);
                cmd.Parameters.AddWithValue("@Insurance_type", ddlinsutype.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Insurance_Details", txtinsudetails.Text);
                cmd.Parameters.AddWithValue("@Added_By_Id", lblstaffid.Text);
                cmd.Parameters.AddWithValue("@Added_By_Name", lblname.Text);
                cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Patient Registration successfully...!');", true);
                Clear();
            }
            catch (Exception ex)
            {
                ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }
            finally
            {
                con.Close();
            }
        }
        else if (btnsubmit.Text == "Update")
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE [dbo].[Paitents_Registration]SET [First_Name] = @First_Name ,[Middle_Name] = @Middle_Name ,[Last_Name] = @Last_Name ,[Gender] = @Gender ,[DOB] = @DOB ,[Age] = @Age ,[Mobile] = @Mobile ,[Alternate_Mobile] = @Alternate_Mobile ,[Gmail] = @Gmail ,[Address] = @Address ,[Emergency_First_Name] = @Emergency_First_Name ,[Emergency_Last_Name] = @Emergency_Last_Name ,[Relationship] = @Relationship ,[Emergency_Mobile] = @Emergency_Mobile ,[Family_Doctor_Name] = @Family_Doctor_Name ,[Family_Doctor_Mobile] = @Family_Doctor_Mobile ,[Health_Issue] = @Health_Issue ,[Medical_History] = @Medical_History ,[Prescriptions] = @Prescriptions ,[Reports] = @Reports ,[Current_Medicine] = @Current_Medicine ,[List_Medicine] = @List_Medicine ,[Insurance_Company] = @Insurance_Company ,[Insurance_Id] = @Insurance_Id ,[Insurance_type] = @Insurance_type ,[Insurance_Details] = @Insurance_Details  WHERE Paitent_Id=@Paitent_Id", con);
                cmd.Parameters.AddWithValue("@Paitent_Id", lblpatientid.Text);
                cmd.Parameters.AddWithValue("@First_Name", txtfname.Text);
                cmd.Parameters.AddWithValue("@Middle_Name", txtmname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlname.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                if (!txtdob.Text.Equals(""))
                {
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtdob.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Alternate_Mobile", txtaltmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Emergency_First_Name", txtefname.Text);
                cmd.Parameters.AddWithValue("@Emergency_Last_Name", txtelname.Text);
                cmd.Parameters.AddWithValue("@Relationship", txtrelationship.Text);
                cmd.Parameters.AddWithValue("@Emergency_Mobile", txtemobile.Text);
                cmd.Parameters.AddWithValue("@Family_Doctor_Name", txtfamilydoc.Text);
                cmd.Parameters.AddWithValue("@Family_Doctor_Mobile", txtdocmobile.Text);
                cmd.Parameters.AddWithValue("@Health_Issue", txtreason.Text);
                cmd.Parameters.AddWithValue("@Medical_History", txtmedicalhistory.Text);


                if (prescriptfile.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(prescriptfile.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = prescriptfile.FileName;
                    //f1 = ID + fileName;
                    f1 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        prescriptfile.SaveAs(Server.MapPath("/Staff/Patient/Prescriptions/" + f1));
                        cmd.Parameters.AddWithValue("@Prescriptions", f1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Prescriptions File not valid');", true);
                        cmd.Parameters.AddWithValue("@Prescriptions", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Prescriptions",lblprecript.Text);
                }

                if (filereports.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(filereports.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = filereports.FileName;
                    //f1 = ID + fileName;
                    f2 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        filereports.SaveAs(Server.MapPath("/Staff/Patient/Reports/" + f2));
                        cmd.Parameters.AddWithValue("@Reports", f2);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Pan_Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Reports", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Reports", lblreport.Text);
                }

                string medicationValue = rdoyes.Checked ? rdoyes.Text : rdono.Text;
                cmd.Parameters.AddWithValue("@Current_Medicine", medicationValue);
                cmd.Parameters.AddWithValue("@List_Medicine", txtmediciitems.Text);
                cmd.Parameters.AddWithValue("@Insurance_Company", txtinsurancecompany.Text);
                cmd.Parameters.AddWithValue("@Insurance_Id", txtinsuranceid.Text);
                cmd.Parameters.AddWithValue("@Insurance_type", ddlinsutype.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Insurance_Details", txtinsudetails.Text);
                //cmd.Parameters.AddWithValue("@Added_By_Id", lblstaffid.Text);
                //cmd.Parameters.AddWithValue("@Added_By_Name", lblname.Text);
                //cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "var confirmation = confirm('Paitent Updated successfully...!'); if (confirmation) { window.location.href = 'View_Patients.aspx'; }", true); Clear();
                Clear();
            }
            catch (Exception ex)
            {
                ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void Clear()
    {
        // Clear TextBoxes
        txtfname.Text = "";
        txtmname.Text = "";
        txtlname.Text = "";
        txtdob.Text = "";
        txtmobile.Text = "";
        txtaltmobile.Text = "";
        txtgmail.Text = "";
        txtage.Text = "";
        txtreason.Text = "";
        txtmedicalhistory.Text = "";
        txtmediciitems.Text = "";
        txtinsurancecompany.Text = "";
        txtinsuranceid.Text = "";
        txtinsudetails.Text = "";
        txtefname.Text = "";
        txtelname.Text = "";
        txtrelationship.Text = "";
        txtfamilydoc.Text = "";
        txtdocmobile.Text = "";

        // Clear DropDownLists
        ddlgender.ClearSelection();
        ddlinsutype.ClearSelection();

        // Clear RadioButtons
        rdoyes.Checked = false;
        rdono.Checked = false;

        // Clear FileUploads
        prescriptfile.FileContent.Dispose(); // Assuming it's required to clear the file content
        filereports.FileContent.Dispose(); // Assuming it's required to clear the file content
    }
    protected void Bind()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Paitents_Registration] where Paitent_Id='" + lblpatientid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtfname.Text = dr["First_Name"].ToString();
            txtmname.Text = dr["Middle_Name"].ToString();
            txtlname.Text = dr["Last_Name"].ToString();
            ddlgender.SelectedValue = dr["Gender"].ToString();
            object dobObj = dr["DOB"];
            if (dobObj != DBNull.Value)
            {
                txtdob.Text = Convert.ToDateTime(dobObj).ToString("yyyy/MM/dd");
            }
            else
            {
                // If DOB is null, set the textbox to be empty
                txtdob.Text = string.Empty;
            }
            txtage.Text = dr["Age"].ToString();
            txtmobile.Text = dr["Mobile"].ToString();
            txtaltmobile.Text = dr["Alternate_Mobile"].ToString();
            txtgmail.Text = dr["Gmail"].ToString();
            txtaddress.Text = dr["Address"].ToString();

            txtefname.Text = dr["Emergency_First_Name"].ToString();
            txtelname.Text = dr["Emergency_Last_Name"].ToString();
            txtrelationship.Text = dr["Relationship"].ToString();
            txtemobile.Text = dr["Emergency_Mobile"].ToString();
            txtfamilydoc.Text = dr["Family_Doctor_Name"].ToString();
            txtdocmobile.Text = dr["Family_Doctor_Mobile"].ToString();

            txtreason.Text = dr["Health_Issue"].ToString();
            txtmedicalhistory.Text = dr["Medical_History"].ToString();
            lblprecript.Text = dr["Prescriptions"].ToString();
            lblreport.Text = dr["Reports"].ToString();
            rdoyes.Checked = (dr["Current_Medicine"].ToString() == "Yes");
            rdono.Checked = (dr["Current_Medicine"].ToString() == "No");
            txtmediciitems.Text = dr["List_Medicine"].ToString();

            txtinsurancecompany.Text = dr["Insurance_Company"].ToString();
            txtinsuranceid.Text = dr["Insurance_Id"].ToString();
            ddlinsutype.Text = dr["Insurance_type"].ToString();
            txtinsudetails.Text = dr["Insurance_Details"].ToString();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
}