using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_View_Bills : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd, cmd1;
    string totalpaid, totalbal;
    protected void Page_Load(object sender, EventArgs e)
    {
        id.Text = ((Label)Master.FindControl("masterid")).Text;
        mastername.Text = ((Label)Master.FindControl("name")).Text;
        BinMasterAdmin();
        txtamount.Enabled = false;
        txtamount.CssClass = "form-control";

    }
    protected void BinMasterAdmin()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "select * from [doctorapp].[Bill_Entry] order by Bill_Id desc";
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvBills.DataSource = ds;
            gvBills.DataBind();
            gvBills.Visible = true;
            if (ds.Rows.Count > 0)
            {

                gvBills.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvBills.FooterRow.TableSection = TableRowSection.TableFooter;
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
    protected void gvBills_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvBills_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        lblid.Text = id;
        if (e.CommandName == "Delete1")
        {
            string id1 = e.CommandArgument.ToString();
            try
            {
                con.Open();
                cmd = new SqlCommand("Delete From [doctorapp].[Bill_Entry] where Bill_Id=@Bill_Id", con);
                cmd.Parameters.AddWithValue("@Bill_Id", id1);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Expense Deleted successfully...!');", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }
            finally
            {
                con.Close();
                BinMasterAdmin();

            }
        }
        else if (e.CommandName == "Pay")
        {
            BindView();
            ScriptManager.RegisterStartupScript(this, GetType(), "showModel1", "showModel1();", true);
            BinMasterAdmin();
        }
    }
    protected void BindView()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *  FROM [doctorapp].[Bill_Entry] where Bill_Id =@Bill_Id", con);
            cmd.Parameters.AddWithValue("@Bill_Id", lblid.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                lblname.Text = dr["Suplier"].ToString();
                lblbillno.Text = dr["Bill_No"].ToString();
                lbltile.Text = dr["Title"].ToString();
                lblBilldate.Text = dr["Bill_Date"].ToString();
                lblcat.Text = dr["Category"].ToString();
                lblattach.Text = dr["Attachment"].ToString();
                lbldesc.Text = dr["Description"].ToString();

                // Set status label text and CSS class dynamically
                string status = dr["Status"].ToString();
                lblstatus.Text = status;
                lblstatus.CssClass = GetBadgeClass(status);

                txtamount.Text = dr["Balance_Amount"].ToString();

                lblpaidamount.Text = dr["Paid_Amount"].ToString();
                lbltotalamount.Text = dr["Pament_Amount"].ToString();


                if (lblstatus.Text == "Paid")
                {
                    paydiv.Visible = false;
                }
                else
                {
                    paydiv.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
    }
    protected void gvBills_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    public void btnPay_Onclick(object sender, EventArgs e)
    {
        try
        {
            con.Open();

            cmd1 = new SqlCommand("INSERT INTO [doctorapp].[Bill_Pay_Log]([Bill_Id],[Payment_Amount],[Paid_Amount],[Balance_Amount],[Payment_Date],[AddedBy_Id],[AddedBy_Name]) VALUES(@Bill_Id,@Payment_Amount,@Paid_Amount,@Balance_Amount,@Payment_Date,@AddedBy_Id,@AddedBy_Name)", con);
            cmd1.Parameters.AddWithValue("@Bill_Id", lblid.Text);
            cmd1.Parameters.AddWithValue("@Payment_Amount", txtamount.Text);
            cmd1.Parameters.AddWithValue("@Paid_Amount", txtpay.Text);
            cmd1.Parameters.AddWithValue("@Balance_Amount", txtbalance.Text);
            cmd1.Parameters.AddWithValue("@Payment_Date", DateTime.Now);
            cmd1.Parameters.AddWithValue("@AddedBy_Id", id.Text);
            cmd1.Parameters.AddWithValue("@AddedBy_Name", mastername.Text);
            cmd1.ExecuteNonQuery();


            cmd = new SqlCommand("Select Paid_Amount,Balance_Amount From [doctorapp].[Bill_Entry] where [Bill_Id]=@Bill_Id ", con);
            cmd.Parameters.AddWithValue("@Bill_Id", lblid.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                decimal paidAmount = reader.GetDecimal(0);
                decimal balanceAmount = reader.GetDecimal(1);

                // Convert txtbalance.Text and txtpay.Text to decimal values
                decimal additionalBalance = decimal.Parse(txtbalance.Text);
                decimal additionalPaid = decimal.Parse(txtpay.Text);

                // Update total balance and total paid amounts
                decimal totalbal = balanceAmount - additionalPaid;
                decimal totalpaid = paidAmount + additionalPaid;

                // Assign the updated amounts to the respective labels
                lblbalamt.Text = totalbal.ToString();
                lblpaidamt.Text = totalpaid.ToString();
            }
            reader.Close();


            cmd = new SqlCommand("Update [doctorapp].[Bill_Entry] Set [Status]=@Status, [Paid_Amount]=@Paid_Amount,[Balance_Amount]=@Balance_Amount where [Bill_Id]=@Bill_Id", con);
            cmd.Parameters.AddWithValue("@Bill_Id", lblid.Text);
            if (txtbalance.Text == "0.00")
            {
                cmd.Parameters.AddWithValue("@Status", "Paid");
            }
            else if (lbltotalamount.Text != lblpaidamount.Text && txtbalance.Text != "0.00")
            {
                cmd.Parameters.AddWithValue("@Status", "Partial Paid");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", lblstatus.Text);
            }
            cmd.Parameters.AddWithValue("@Paid_Amount", lblpaidamt.Text);
            cmd.Parameters.AddWithValue("@Balance_Amount", lblbalamt.Text);
            cmd.ExecuteNonQuery();


            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Added successfully...!');", true);
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
            BinMasterAdmin();
        }
    }
    protected void Clear()
    {
        txtpay.Text = "";
        txtbalance.Text = "0.00";
    }
    protected string GetBadgeClass(object status)
    {
        string statusText = status.ToString();
        switch (statusText)
        {
            case "Unpaid":
                return "badge bg-danger";
            case "Partial Paid":
                return "badge bg-warning";
            case "Paid":
                return "badge bg-success";
            default:
                return "badge bg-secondary";
        }
    }

}