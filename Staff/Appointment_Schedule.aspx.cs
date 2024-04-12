using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Appointment_Schedule : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    BindDropdown B = new BindDropdown();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblstaffid.Text = ((Label)Master.FindControl("lblstaffid")).Text;
        lblname.Text = ((Label)Master.FindControl("lblstaffname")).Text;

        if (!IsPostBack)
        {
            B.binddlpatient(ddlpaitentname);
            B.binddldoctors(ddlappoint);
            if (Request.QueryString["AppointmentId"] != null && Request.QueryString["AppointmentId"] != String.Empty)
            {
                lblappid.Text = Request.QueryString["AppointmentId"];
                Bind();
                btnshedule.Text = "Update";

            }
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
                cmd.Parameters.AddWithValue("@Paitent_Id", ddlpaitentname.SelectedValue);
                cmd.Parameters.AddWithValue("@Name", ddlpaitentname.SelectedItem.Text);
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
                cmd.Parameters.AddWithValue("@Appoint_To_Id", ddlappoint.SelectedValue);
                cmd.Parameters.AddWithValue("@Appoint_To_Name", ddlappoint.SelectedItem.Text);
                if (ddlappoint.SelectedValue != "")
                {
                    cmd.Parameters.AddWithValue("@Status", "Confirmed");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Status", "Pending");
                }
                cmd.Parameters.AddWithValue("@Added_By_Id", lblstaffid.Text);
                cmd.Parameters.AddWithValue("@Added_By_Name", lblname.Text);
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
                cmd = new SqlCommand("UPDATE [dbo].[Appointment]SET [Paitent_Id] = @Paitent_Id ,[Name] = @Name ,[DOB] = @DOB ,[Age] = @Age ,[Gender] = @Gender ,[Mobile] = @Mobile ,[Alternate_Mobile] = @Alternate_Mobile ,[Gmail] = @Gmail ,[Address] = @Address ,[Appointment_Reason] = @Appointment_Reason ,[Appointment_Type] = @Appointment_Type ,[Appoitment_Date] = @Appoitment_Date ,[Time_Slot] = @Time_Slot ,[Contact_Preferance] = @Contact_Preferance,[Appoint_To_Id]=@Appoint_To_Id,[Appoint_To_Name]=@Appoint_To_Name,[Status]=@Status WHERE Appointment_Id = @Appointment_Id", con);
                cmd.Parameters.AddWithValue("@Appointment_Id", lblappid.Text);
                cmd.Parameters.AddWithValue("@Paitent_Id", ddlpaitentname.SelectedValue);
                cmd.Parameters.AddWithValue("@Name", ddlpaitentname.SelectedItem.Text);
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
                cmd.Parameters.AddWithValue("@Appoint_To_Id", ddlappoint.SelectedValue);
                cmd.Parameters.AddWithValue("@Appoint_To_Name", ddlappoint.SelectedItem.Text);

                if (ddlappoint.SelectedValue != "")
                {
                    cmd.Parameters.AddWithValue("@Status", "Confirmed");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Status", "Pending");
                }
                //cmd.Parameters.AddWithValue("@Added_By_Id", lblstaffid.Text);
                //cmd.Parameters.AddWithValue("@Added_By_Name", lblname.Text);
                //cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "var confirmation = confirm('Appointment Updated successfully...!'); if (confirmation) { window.location.href = 'View_Appointment.aspx'; }", true); Clear();
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

        txtdob.Text = "";
        txtmobile.Text = "";
        txtaltmobile.Text = "";
        txtgmail.Text = "";
        txtage.Text = "";
        txtappreason.Text = "";
        txtaddress.Text = "";
        txtappointdate.Text = "";


        // Clear DropDownLists
        ddlgender.ClearSelection();
        ddlpaitentname.ClearSelection();
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
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Appointment] where Appointment_Id='" + lblappid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            ddlpaitentname.SelectedValue = dr["Paitent_Id"].ToString();
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

            txtappreason.Text = dr["Appointment_Reason"].ToString();
            ddlaptype.SelectedValue = dr["Appointment_Type"].ToString();
            object dobObj1 = dr["Appoitment_Date"];
            if (dobObj1 != DBNull.Value)
            {
                txtappointdate.Text = Convert.ToDateTime(dobObj1).ToString("yyyy/MM/dd");
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
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

    }
    protected void ddlpaitentname_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand("Select * from [dbo].[Paitents_Registration] where Paitent_Id=@Paitent_Id", con);
            cmd.Parameters.AddWithValue("@Paitent_Id", ddlpaitentname.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
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
            ddlgender.SelectedValue = dr["Gender"].ToString();
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