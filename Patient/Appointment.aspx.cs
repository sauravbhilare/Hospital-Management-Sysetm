using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_Appointment : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    BindDropdown B = new BindDropdown();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblpatient.Text = ((Label)Master.FindControl("lblPatientid")).Text;
        lblpname.Text = ((Label)Master.FindControl("lblPatientname")).Text;

        if (!IsPostBack)
        {

            if (Request.QueryString["Appointment_Id"] != null && Request.QueryString["Appointment_Id"] != String.Empty)
            {
                lblappid.Text = Request.QueryString["Appointment_Id"];
                Bind1();
                btnshedule.Text = "Update";

            }
            Bind();
        }
    }

    public void btnshedule_OnClick(object sender, EventArgs e)
    {
        if (btnshedule.Text == "Schedule")
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO [dbo].[Appointment]([Paitent_Id],[Name],[DOB],[Age],[Gender],[Mobile],[Alternate_Mobile],[Gmail],[Address],[Appointment_Reason],[Appointment_Type],[Appoitment_Date],[Time_Slot],[Contact_Preferance],[Appoint_To_Id],[Appoint_To_Name],[Status],[Added_By_Id],[Added_By_Name],[Added_On]) VALUES(@Paitent_Id,@Name,@DOB,@Age,@Gender,@Mobile,@Alternate_Mobile,@Gmail,@Address,@Appointment_Reason,@Appointment_Type,@Appoitment_Date,@Time_Slot,@Contact_Preferance,@Appoint_To_Id,@Appoint_To_Name,@Status,@Added_By_Id,@Added_By_Name,@Added_On)", con);
                cmd.Parameters.AddWithValue("@Paitent_Id", lblpatient.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                if (!txtdob.Text.Equals(""))
                {
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtdob.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Alternate_Mobile", txtaltmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Appointment_Reason", txtappreason.Text);
                cmd.Parameters.AddWithValue("@Appointment_Type", ddlaptype.SelectedValue);
                cmd.Parameters.AddWithValue("@Appoitment_Date", txtappointdate.Text);
                cmd.Parameters.AddWithValue("@Time_Slot", ddltimeslot.SelectedValue);
                string contact = rdbgmail.Checked ? rdbgmail.Text : rdbmobile.Text;
                cmd.Parameters.AddWithValue("@Contact_Preferance", contact);
                cmd.Parameters.AddWithValue("@Appoint_To_Id", "");
                cmd.Parameters.AddWithValue("@Appoint_To_Name", "");

                cmd.Parameters.AddWithValue("@Status", "Pending");

                cmd.Parameters.AddWithValue("@Added_By_Id", lblpatient.Text);
                cmd.Parameters.AddWithValue("@Added_By_Name", lblpname.Text);
                cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Appointment Registration successfully...!');", true);
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
        else if (btnshedule.Text == "Update")
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE [dbo].[Appointment]SET [Paitent_Id] = @Paitent_Id ,[Name] = @Name ,[DOB] = @DOB ,[Age] = @Age ,[Gender] = @Gender ,[Mobile] = @Mobile ,[Alternate_Mobile] = @Alternate_Mobile ,[Gmail] = @Gmail ,[Address] = @Address ,[Appointment_Reason] = @Appointment_Reason ,[Appointment_Type] = @Appointment_Type ,[Appoitment_Date] = @Appoitment_Date ,[Time_Slot] = @Time_Slot ,[Contact_Preferance] = @Contact_Preferance,[Appoint_To_Id]=@Appoint_To_Id,[Appoint_To_Name]=@Appoint_To_Name WHERE Appointment_Id = @Appointment_Id", con);
                cmd.Parameters.AddWithValue("@Appointment_Id", lblappid.Text);
                cmd.Parameters.AddWithValue("@Paitent_Id", lblpatient.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                if (!txtdob.Text.Equals(""))
                {
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtdob.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Alternate_Mobile", txtaltmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Appointment_Reason", txtappreason.Text);
                cmd.Parameters.AddWithValue("@Appointment_Type", ddlaptype.SelectedValue);
                cmd.Parameters.AddWithValue("@Appoitment_Date", txtappointdate.Text);
                cmd.Parameters.AddWithValue("@Time_Slot", ddltimeslot.SelectedValue);
                string contact = rdbgmail.Checked ? rdbgmail.Text : rdbmobile.Text;
                cmd.Parameters.AddWithValue("@Contact_Preferance", contact);
                cmd.Parameters.AddWithValue("@Appoint_To_Id", "");
                cmd.Parameters.AddWithValue("@Appoint_To_Name", "");

                //if (ddlappoint.SelectedValue != "")
                //{
                //    cmd.Parameters.AddWithValue("@Status", "Confirmed");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@Status", "Pending");
                //}
                //cmd.Parameters.AddWithValue("@Added_By_Id", lblstaffid.Text);
                //cmd.Parameters.AddWithValue("@Added_By_Name", lblname.Text);
                //cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "var confirmation = confirm('Appointment Updated successfully...!');", true);
                Clear();
                Bind();
                Bind1();
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


        txtappreason.Text = "";

        txtappointdate.Text = "";


        // Clear DropDownLists

        ddltimeslot.ClearSelection();
        ddlaptype.ClearSelection();

        // Clear RadioButtons
        rdbmobile.Checked = false;
        rdbgmail.Checked = false;


    }
    protected void Bind()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Paitents_Registration] where [Paitent_Id]='" + lblpatient.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string firstName = dr["First_Name"].ToString();
            string lastName = dr["Last_Name"].ToString();
            string fullName = firstName+" "+lastName;
            txtname.Text = fullName;
            txtname.Enabled = false;
            txtname.CssClass += " form-control";

            ddlgender.SelectedValue = dr["Gender"].ToString();
            ddlgender.Enabled = false;
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
            txtdob.CssClass += " form-control"; // Assuming "form-control" is a Bootstrap class
            txtdob.Enabled = false;

            txtage.Text = dr["Age"].ToString();
            txtage.CssClass += " form-control"; // Assuming "form-control" is a Bootstrap class
            txtage.Enabled = false;

            txtmobile.Text = dr["Mobile"].ToString();
            txtmobile.CssClass += " form-control"; // Assuming "form-control" is a Bootstrap class
            txtmobile.Enabled = false;

            txtaltmobile.Text = dr["Alternate_Mobile"].ToString();
            txtaltmobile.CssClass += " form-control"; // Assuming "form-control" is a Bootstrap class
            txtaltmobile.Enabled = false;

            txtgmail.Text = dr["Gmail"].ToString();
            txtgmail.CssClass += " form-control"; // Assuming "form-control" is a Bootstrap class
            txtgmail.Enabled = false;

            txtaddress.Text = dr["Address"].ToString();
            txtaddress.CssClass += " form-control"; // Assuming "form-control" is a Bootstrap class
            txtaddress.Enabled = false;


        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

    }

    protected void Bind1()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Appointment] where Appointment_Id='" + lblappid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtappreason.Text = dr["Appointment_Reason"].ToString();
                ddlaptype.SelectedValue = dr["Appointment_Type"].ToString();
                object dobObj1 = dr["Appoitment_Date"];
                if (dobObj1 != DBNull.Value)
                {
                    DateTime appointmentDate = Convert.ToDateTime(dobObj1);
                    txtappointdate.Text = appointmentDate.ToString("yyyy/MM/dd");

                    // Check if the appointment date is today
                    if (appointmentDate.Date == DateTime.Today)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your appointment is today. Please call the hospital for any updates.'); window.location='View_Appointments.aspx';", true);
                    }
                    else if (appointmentDate.Date < DateTime.Today)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You cannot update this appointment; Because this is Complete Or Past Date Appointment.'); window.location='View_Appointments.aspx';", true);
                        return; // Stop further execution
                    }
                }
                else
                {
                    // If DOB is null, set the textbox to be empty
                    txtappointdate.Text = string.Empty;
                }
                ddltimeslot.SelectedValue = dr["Time_Slot"].ToString();

                rdbgmail.Checked = (dr["Contact_Preferance"].ToString() == "Gmail");
                rdbmobile.Checked = (dr["Contact_Preferance"].ToString() == "Mobile");
            }
            else
            {
                // Handle case where no records are found for the given Appointment_Id
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
        }
        finally
        {
            con.Close();
        }
    }

    //protected void ddlpaitentname_OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        con.Open();
    //        cmd = new SqlCommand("Select * from [dbo].[Paitents_Registration] where Paitent_Id=@Paitent_Id", con);
    //        cmd.Parameters.AddWithValue("@Paitent_Id", ddlpaitentname.SelectedValue);
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        dr.Read();
    //        object dobObj = dr["DOB"];
    //        if (dobObj != DBNull.Value)
    //        {
    //            txtdob.Text = Convert.ToDateTime(dobObj).ToString("yyyy/MM/dd");
    //        }
    //        else
    //        {
    //            // If DOB is null, set the textbox to be empty
    //            txtdob.Text = string.Empty;
    //        }
    //        txtage.Text = dr["Age"].ToString();
    //        txtmobile.Text = dr["Mobile"].ToString();
    //        txtaltmobile.Text = dr["Alternate_Mobile"].ToString();
    //        txtgmail.Text = dr["Gmail"].ToString();
    //        txtaddress.Text = dr["Address"].ToString();
    //        ddlgender.SelectedValue = dr["Gender"].ToString();
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}
}