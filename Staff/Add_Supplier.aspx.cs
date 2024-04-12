using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Add_Supplier : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    BindDropdown B = new BindDropdown();
    protected void Page_Load(object sender, EventArgs e)
    {
        id.Text = ((Label)Master.FindControl("lblstaffid")).Text;
        mastername.Text = ((Label)Master.FindControl("lblstaffname")).Text;
        if (!IsPostBack)
        {
            if (Request.QueryString["SupplierId"] != null && Request.QueryString["SupplierId"] != String.Empty)
            {
                lblid.Text = Request.QueryString["SupplierId"];
                Bind();
                btnsubmit.Text = "Update";


            }
        }
    }
    public void btnsubmit_OnClick(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        if (btnsubmit.Text == "Submit")
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [doctorapp].[Supplier]([Name],[Gender],[Mobile],[Alt_Mobile],[Gmail],[GST_No],[Address],[Bank_Name],[IFSC_Code],[Branch],[Account_No],[Addedby_ID],[Addedby_Name],[Added_On])VALUES(@Name, @Gender, @Mobile, @Alt_Mobile,@Gmail, @GST_No, @Address, @Bank_Name, @IFSC_Code, @Branch, @Account_No, @Addedby_ID, @Addedby_Name, @Added_On)", con);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Alt_Mobile", txtaltmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@GST_No", txtgstno.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Bank_Name", txtbankname.Text);
                cmd.Parameters.AddWithValue("@IFSC_Code", txtifsc.Text);
                cmd.Parameters.AddWithValue("@Branch", txtbranch.Text);
                cmd.Parameters.AddWithValue("@Account_No", txtaccno.Text);
                cmd.Parameters.AddWithValue("@Addedby_ID", id.Text);
                cmd.Parameters.AddWithValue("@Addedby_Name", mastername.Text);
                cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Supplier Added successfully...!');", true);
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
                SqlCommand cmd = new SqlCommand("UPDATE [doctorapp].[Supplier] SET [Name] = @Name ,[Gender] = @Gender ,[Mobile] = @Mobile ,[Alt_Mobile] = @Alt_Mobile ,[Gmail] = @Gmail,[GST_No] = @GST_No,[Address] = @Address,[Bank_Name] = @Bank_Name,[IFSC_Code] = @IFSC_Code,[Branch] = @Branch,[Account_No] = @Account_No,[Addedby_ID] = @Addedby_ID,[Addedby_Name] = @Addedby_Name,[Added_On] = @Added_On WHERE [Suplier_ID]=@Suplier_ID", con);
                cmd.Parameters.AddWithValue("@Suplier_ID", lblid.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Alt_Mobile", txtaltmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@GST_No", txtgstno.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Bank_Name", txtbankname.Text);
                cmd.Parameters.AddWithValue("@IFSC_Code", txtifsc.Text);
                cmd.Parameters.AddWithValue("@Branch", txtbranch.Text);
                cmd.Parameters.AddWithValue("@Account_No", txtaccno.Text);
                cmd.Parameters.AddWithValue("@Addedby_ID", txtbranch.Text);
                cmd.Parameters.AddWithValue("@Addedby_Name", txtaccno.Text);
                cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);

                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "var confirmation = confirm('Supplier Details Updated successfully...!'); if (confirmation) { window.location.href = 'View_Supplier.aspx'; }", true); Clear();
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
        txtname.Text = "";
        ddlgender.ClearSelection();
        txtmobile.Text = "";
        txtaltmobile.Text = "";
        txtgmail.Text = "";
        txtaddress.Text = "";
        txtgstno.Text = "";
        txtbankname.Text = "";
        txtifsc.Text = "";
        txtbranch.Text = "";
        txtaccno.Text = "";
    }
    protected void Bind()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [doctorapp].[Supplier] where Suplier_ID='" + lblid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtname.Text = dr["Name"].ToString();
            ddlgender.SelectedValue = dr["Gender"].ToString();
            txtmobile.Text = dr["Mobile"].ToString();
            txtaltmobile.Text = dr["Alt_Mobile"].ToString();
            txtgmail.Text = dr["Gmail"].ToString();
            txtgstno.Text = dr["GST_No"].ToString();
            txtaddress.Text = dr["Address"].ToString();
            txtbankname.Text = dr["Bank_Name"].ToString();
            txtifsc.Text = dr["IFSC_Code"].ToString();
            txtbranch.Text = dr["Branch"].ToString();
            txtaccno.Text = dr["Account_No"].ToString();
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