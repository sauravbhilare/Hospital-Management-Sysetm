using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_Bill_Entry : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd, cmd1;
    BindDropdown B = new BindDropdown();
    SqlTransaction t;
    protected void Page_Load(object sender, EventArgs e)
    {
        id.Text = ((Label)Master.FindControl("masterid")).Text;
        mastername.Text = ((Label)Master.FindControl("name")).Text;
        if (!IsPostBack)
        {
            B.bindproducttype(ddlcategory);
            B.bindSupplier(ddlsupplier);

        }
    }
    public void btnsubmit_Onclick(object sender, EventArgs e)
    {

        Int32 ID123 = 0;
        string f1 = "";
        string fileName = string.Empty;
        Random r = new Random();
        bool IsValidFile = false;
        try
        {
            con.Open();
            t = con.BeginTransaction();
            cmd = new SqlCommand("INSERT INTO [doctorapp].[Bill_Entry]([Bill_No],[Bill_Date],[Title],[Category_Id],[Category],[Supplier_Id],[Suplier],[Attachment],[Description],[Status],[Pament_Amount],[Paid_Amount],[Balance_Amount],[Addedby_Id],[Addedby_Name],[Added_On]) VALUES(@Bill_No,@Bill_Date,@Title,@Category_Id,@Category,@Supplier_Id,@Suplier,@Attachment,@Description,@Status,@Pament_Amount,@Paid_Amount,@Balance_Amount,@Addedby_Id,@Addedby_Name,@Added_On);SELECT SCOPE_IDENTITY();", con, t);
            cmd.Parameters.AddWithValue("@Bill_No", txtbillno.Text);
            cmd.Parameters.AddWithValue("@Bill_Date", txtbilldate.Text);
            cmd.Parameters.AddWithValue("@Title", txttitle.Text);
            cmd.Parameters.AddWithValue("@Category_Id", ddlcategory.SelectedValue);
            cmd.Parameters.AddWithValue("@Category", ddlcategory.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Supplier_Id", ddlsupplier.SelectedValue);
            cmd.Parameters.AddWithValue("@Suplier", ddlsupplier.SelectedItem.Text);

            if (fileAttach.HasFile)
            {
                string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                string extension = System.IO.Path.GetExtension(fileAttach.PostedFile.FileName);

                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (extension == validFileTypes[i])
                    {
                        IsValidFile = true;
                        break;
                    }
                }
                fileName = fileAttach.FileName;
                //f1 = ID + fileName;
                f1 = r.Next(1, 10000) + fileName;
                if (IsValidFile)
                {
                    fileAttach.SaveAs(Server.MapPath("/Bills/" + f1));
                    cmd.Parameters.AddWithValue("@Attachment", f1);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Bill File not valid');", true);
                    cmd.Parameters.AddWithValue("@Attachment", "");
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("@Attachment", "");
            }

            cmd.Parameters.AddWithValue("@Description", txtdescription.Text);

            cmd.Parameters.AddWithValue("@Status", ddlpaystatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Pament_Amount", txtpayamt.Text);
            if (txtpaidamt.Text == "")
            {
                cmd.Parameters.AddWithValue("@Paid_Amount", "0.00");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Paid_Amount", txtpaidamt.Text);

            }
            cmd.Parameters.AddWithValue("@Balance_Amount", txtbalanceamt.Text);
            cmd.Parameters.AddWithValue("@Addedby_Id", id.Text);
            cmd.Parameters.AddWithValue("@Addedby_Name", mastername.Text);
            cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
            ID123 = Convert.ToInt32(cmd.ExecuteScalar());


            cmd1 = new SqlCommand("INSERT INTO [doctorapp].[Bill_Pay_Log]([Bill_Id],[Payment_Amount],[Paid_Amount],[Balance_Amount],[Payment_Date],[AddedBy_Id],[AddedBy_Name]) VALUES(@Bill_Id,@Payment_Amount,@Paid_Amount,@Balance_Amount,@Payment_Date,@AddedBy_Id,@AddedBy_Name)", con, t);
            cmd1.Parameters.AddWithValue("@Bill_Id", ID123);
            cmd1.Parameters.AddWithValue("@Payment_Amount", txtpayamt.Text);
            if (txtpaidamt.Text == "")
            {
                cmd1.Parameters.AddWithValue("@Paid_Amount", "0.00");
            }
            else
            {
                cmd1.Parameters.AddWithValue("@Paid_Amount", txtpaidamt.Text);

            }
            cmd1.Parameters.AddWithValue("@Balance_Amount", txtbalanceamt.Text);
            cmd1.Parameters.AddWithValue("@Payment_Date", DateTime.Now);
            cmd1.Parameters.AddWithValue("@AddedBy_Id", id.Text);
            cmd1.Parameters.AddWithValue("@AddedBy_Name", mastername.Text);
            cmd1.ExecuteNonQuery();

            t.Commit();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Added successfully...!');", true);
            Clear();

        }
        catch (Exception ex)
        {
            t.Rollback();
            ex.ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
        }
        finally
        {
            con.Close();

        }
    }
    protected void Clear()
    {
        ddlcategory.ClearSelection();
        ddlsupplier.ClearSelection();
        ddlpaystatus.ClearSelection();
        txtbillno.Text = "";
        txtbilldate.Text = "";
        txttitle.Text = "";
        txtdescription.Text = "";
        txtpayamt.Text = "";
        txtpaidamt.Text = "";
        txtbalanceamt.Text = "";
    }

}