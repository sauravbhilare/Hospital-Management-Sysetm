using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_View_Doctors : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindStaff();
    }
    protected void BindStaff()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "select * from [dbo].[Doctors] order by Doctor_Id desc";
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvDoctor.DataSource = ds;
            gvDoctor.DataBind();
            gvDoctor.Visible = true;
            if (ds.Rows.Count > 0)
            {

                gvDoctor.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvDoctor.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
    protected void gvDoctor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvDoctor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        lblid.Text = id;
        if (e.CommandName == "Update")
        {
            Response.Redirect("Doctors_Registration.aspx?DoctorId=" + id);
        }
        else if (e.CommandName == "Delete1")
        {
            string id1 = e.CommandArgument.ToString();

            try
            {
                con.Open();
                cmd = new SqlCommand("Delete From [dbo].[Doctors] where Doctor_Id=@Doctor_Id", con);
                cmd.Parameters.AddWithValue("@Staff_Id", id1);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Deleted successfully...!');", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }
            finally
            {
                con.Close();
                BindStaff();

            }
        }
        else if (e.CommandName == "View")
        {
            BindView();
            ScriptManager.RegisterStartupScript(this, GetType(), "showModel1", "showModel1();", true);
            BindStaff();
        }
    }
    protected void gvDoctor_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void DownloadFile(object sender, EventArgs e)
    {
        // Retrieve the file name from the LinkButton's CommandArgument
        string fileName = (sender as LinkButton).CommandArgument;

        // Assuming the base folder path where files are stored in your application
        string basePath = Server.MapPath("/Documents/Staff/PanCard/"); // Adjust this path as per your folder structure

        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.TransmitFile(filePath);
            Response.End();
        }
        else
        {
            // Handle the case when the file doesn't exist or the path is invalid
            // Show an error message or perform any necessary action
        }
    }

    protected void BindView()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *  FROM [dbo].[Doctors]  where Doctor_Id=@Doctor_Id", con);
            cmd.Parameters.AddWithValue("@Doctor_Id", lblid.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                DateTime dateValue;
                lbldoctorname.Text = dr["First_Name"].ToString() + " " + dr["Last_Name"].ToString();
                lblspecil.Text = dr["Specilization"].ToString();
                lblexp.Text = dr["Experiance"].ToString();
                lblgender.Text = dr["Gender"].ToString();
                lblexp.Text = dr["Experiance"].ToString();
                lbladdress.Text = dr["Address"].ToString();
                lblmobile.Text = dr["Mobile"].ToString();
                if (DateTime.TryParse(dr["DOB"].ToString(), out dateValue))
                {
                    lblDOB.Text = dateValue.ToString("dd/MM/yyyy"); // Change the format as needed
                }
                lblemail.Text = dr["Gmail"].ToString();
                lblqualification.Text = dr["Qualification"].ToString();

                lblpancard.Text = dr["Pan_No"].ToString();
                lblpanfile.Text = dr["Pan_Card"].ToString();
                if (lblpanfile.Text != "")
                {
                    lnkpan.Visible = true;
                }
                else
                {
                    lnkpan.Visible = false;
                }
                lblaadharcard.Text = dr["Aadhar_No"].ToString();
                lblafile.Text = dr["Aadhar_Card"].ToString();
                if (lblafile.Text != "")
                {

                    lnkafile.Visible = true;
                }
                else
                {
                    lnkafile.Visible = false;
                }

                lblcer.Text= dr["Certificate1"].ToString();
                if(lblcer.Text!="")
                {
                    lblcer.Visible = true;
                    lnkcer.Visible = true;
                }
                else
                {
                    lblcer.Visible = false;
                    lnkcer.Visible = false;
                }
                lblcer1.Text = dr["Certificate2"].ToString();
                if (lblcer1.Text != "")
                {
                    lblcer1.Visible = true;
                    lnkcer1.Visible = true;
                }
                else
                {
                    lblcer1.Visible = false;
                    lnkcer1.Visible = false;
                }
                lblcer2.Text = dr["Certificate3"].ToString();
                if (lblcer2.Text != "")
                {
                    lblcer2.Visible = true;
                    lnkcer2.Visible = true;
                }
                else
                {
                    lblcer2.Visible = false;
                    lnkcer2.Visible = false;
                }

                lblphoto.Text= dr["Photo"].ToString();
                if (lblphoto.Text != "")
                {
                    imgDoctorPhoto.ImageUrl = ("~/Documents/Doctor/Photo/" + lblphoto.Text);

                }
                else
                {
                    imgDoctorPhoto.ImageUrl = "~/Documents/Doctor/Photo/user.jpg";
                }


            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }

    }
    protected void lnkafile_Click(object sender, EventArgs e)
    {
        string filePath1 = lblafile.Text;
        DownloadFile(filePath1);
    }

    private void DownloadFile(string filePath)
    {
        try
        {
            string fullPath = Server.MapPath("~/Documents/Doctor/AadharCard/" + filePath);


            if (File.Exists(fullPath))
            {
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(fullPath));
                Response.TransmitFile(fullPath);
                Response.End();
            }
            else
            {
                // Handle case when the file doesn't exist
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Not Found');", true);
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Response.Write("Error: " + ex.Message);
        }
    }

    protected void lnkpan_Click(object sender, EventArgs e)
    {
        string filePath1 = lblpanfile.Text;
        DownloadFile1(filePath1);
    }

    private void DownloadFile1(string fileName)
    {
        try
        {
            string folderPath = Server.MapPath("~/Documents/Doctor/PanCard/");
            string fullPath = Path.Combine(folderPath, fileName);

            if (File.Exists(fullPath))
            {
                string contentType = MimeMapping.GetMimeMapping(fullPath);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(fullPath);
                Response.End();
            }
            else
            {
                // Handle case when the file doesn't exist
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Not Found');", true);
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Response.Write("Error: " + ex.Message);
        }
    }

    protected void lnkcer_Click(object sender, EventArgs e)
    {
        string filePath1 = lblcer.Text;
        Downloadcer(filePath1);
    }
    private void Downloadcer(string fileName)
    {
        try
        {
            string folderPath = Server.MapPath("~/Documents/Doctor/Certificate1/");
            string fullPath = Path.Combine(folderPath, fileName);

            if (File.Exists(fullPath))
            {
                string contentType = MimeMapping.GetMimeMapping(fullPath);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(fullPath);
                Response.End();
            }
            else
            {
                // Handle case when the file doesn't exist
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Not Found');", true);
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Response.Write("Error: " + ex.Message);
        }
    }
    protected void lnkcer1_Click(object sender, EventArgs e)
    {
        string filePath1 = lblcer1.Text;
        Downloadcer1(filePath1);
    }
    private void Downloadcer1(string fileName)
    {
        try
        {
            string folderPath = Server.MapPath("~/Documents/Doctor/Certificate2/");
            string fullPath = Path.Combine(folderPath, fileName);

            if (File.Exists(fullPath))
            {
                string contentType = MimeMapping.GetMimeMapping(fullPath);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(fullPath);
                Response.End();
            }
            else
            {
                // Handle case when the file doesn't exist
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Not Found');", true);
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Response.Write("Error: " + ex.Message);
        }
    }
    protected void lnkcer2_Click(object sender, EventArgs e)
    {
        string filePath1 = lblcer2.Text;
        Downloadcer3(filePath1);
    }
    private void Downloadcer3(string fileName)
    {
        try
        {
            string folderPath = Server.MapPath("~/Documents/Doctor/Certificate3/");
            string fullPath = Path.Combine(folderPath, fileName);

            if (File.Exists(fullPath))
            {
                string contentType = MimeMapping.GetMimeMapping(fullPath);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(fullPath);
                Response.End();
            }
            else
            {
                // Handle case when the file doesn't exist
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('File Not Found');", true);
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Response.Write("Error: " + ex.Message);
        }
    }
}