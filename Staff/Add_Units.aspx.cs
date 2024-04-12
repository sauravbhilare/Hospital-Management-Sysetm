using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Add_Units : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindProduct();
    }
    public void btnsubmit_OnClick(object sender, EventArgs e)
    {

        try
        {
            con.Open();
            cmd = new SqlCommand("Insert Into [dbo].[Unit] ([Unit_Name]) values (@Unit_Name)", con);
            cmd.Parameters.AddWithValue("@Unit_Name", txtunit.Text);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Unit Added successfully...!');", true);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
            BindProduct();
            txtunit.Text = "";
        }
    }

    protected void BindProduct()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "select * from [dbo].[Unit] order by Unit_Id desc";
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvProductType.DataSource = ds;
            gvProductType.DataBind();
            gvProductType.Visible = true;
            if (ds.Rows.Count > 0)
            {

                gvProductType.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvProductType.FooterRow.TableSection = TableRowSection.TableFooter;
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
    protected void gvProductType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvProductType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //if (e.CommandName == "Update")
        //{

        //}
        if (e.CommandName == "Delete1")
        {
            string id1 = e.CommandArgument.ToString();
            try
            {
                con.Open();
                cmd = new SqlCommand("Delete From [dbo].[Unit] where Unit_Id=@Unit_Id", con);
                cmd.Parameters.AddWithValue("@Department_Id", id1);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Unit Deleted successfully...!');", true);
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
    protected void gvProductType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}