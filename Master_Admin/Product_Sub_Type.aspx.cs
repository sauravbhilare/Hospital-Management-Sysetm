using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_Product_Sub_Type : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    BindDropdown B = new BindDropdown();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            B.bindproducttype(ddlproducttype);
            BindProduct();
        }
    }
    public void btnsubmit_OnClick(object sender, EventArgs e)
    {

        try
        {
            con.Open();
            cmd = new SqlCommand("Insert Into [dbo].[Product_Sub_Type] ([Type_Id],[Product_Type],[Product_Sub_Type]) values (@Type_Id,@Product_Type,@Product_Sub_Type)", con);
            cmd.Parameters.AddWithValue("@Type_Id", ddlproducttype.SelectedValue);
            cmd.Parameters.AddWithValue("@Product_Type", ddlproducttype.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Product_Sub_Type", txtprosubname.Text);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Added successfully...!');", true);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
            txtprosubname.Text = "";
            ddlproducttype.ClearSelection();
            BindProduct();
        }
    }
    protected void BindProduct()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "select * from [dbo].[Product_Sub_Type] order by Sub_Type_Id desc";
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvProductSubType.DataSource = ds;
            gvProductSubType.DataBind();
            gvProductSubType.Visible = true;
            if (ds.Rows.Count > 0)
            {

                gvProductSubType.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvProductSubType.FooterRow.TableSection = TableRowSection.TableFooter;
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
    protected void gvProductSubType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvProductSubType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string id = e.CommandArgument.ToString();
        //if (e.CommandName == "Update")
        //{

        //}
        if (e.CommandName == "Delete1")
        {
            string id1 = e.CommandArgument.ToString();
            try
            {
                con.Open();
                cmd = new SqlCommand("Delete From [Product_Sub_Type] where Sub_Type_Id=@Sub_Type_Id", con);
                cmd.Parameters.AddWithValue("@Sub_Type_Id", id1);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Sub-Type Deleted successfully...!');", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }
            finally
            {
                con.Close();
                BindProduct();

            }
        }
    }
    protected void gvProductSubType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}