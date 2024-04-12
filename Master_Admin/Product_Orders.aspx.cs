using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_Product_Oorder : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    BindDropdown B = new BindDropdown();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            B.bindproducttype(ddlproducttype);
            B.bindproductsubtype(ddlproductsubtype);
            B.bindProducts(ddlproductname);
            //BindProduct();

            Session["MedicineTable"] = new DataTable();
            ((DataTable)Session["MedicineTable"]).Columns.Add("ProductType", typeof(string));
            ((DataTable)Session["MedicineTable"]).Columns.Add("ProductSubType", typeof(string));
            ((DataTable)Session["MedicineTable"]).Columns.Add("ProductName", typeof(string));
            ((DataTable)Session["MedicineTable"]).Columns.Add("Quantity", typeof(int));
            ((DataTable)Session["MedicineTable"]).Columns.Add("Price", typeof(decimal));
            ((DataTable)Session["MedicineTable"]).Columns.Add("Total", typeof(decimal));
        }
    }
    protected void btnadd_Onclick(object sender, EventArgs e)
    {
        string productType = ddlproducttype.SelectedItem.Text;
        string productSubType = ddlproductsubtype.SelectedItem.Text;
        string productName = ddlproductname.SelectedItem.Text;
        int quantity = int.Parse(txtquantity.Text);
        decimal price = decimal.Parse(txtproprice.Text);
        decimal total = quantity * price;

        // Create a new row for the GridView
        DataRow newRow = ((DataTable)Session["MedicineTable"]).NewRow();
        newRow["ProductType"] = productType;
        newRow["ProductSubType"] = productSubType;
        newRow["ProductName"] = productName;
        newRow["Quantity"] = quantity;
        newRow["Price"] = price;
        newRow["Total"] = total;

        // Add the new row to the GridView's data source
        ((DataTable)Session["MedicineTable"]).Rows.Add(newRow);

        BindGridView();
    }
    private void BindGridView()
    {
        DataTable dt = (DataTable)Session["MedicineTable"];

        // Add SrNo column if not already present
        if (!dt.Columns.Contains("SrNo"))
        {
            dt.Columns.Add("SrNo", typeof(int));
        }

        // Set SrNo for each row
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["SrNo"] = i + 1;
        }

        GridMedicine.DataSource = dt;
        GridMedicine.DataBind();

        ddlproducttype.ClearSelection();
        ddlproductsubtype.ClearSelection();
        ddlproductname.ClearSelection();
        txtquantity.Text = "";
        txtproprice.Text = "";
        txttotal.Text = "";
    }
    protected void DeleteRow_Click(object sender, EventArgs e)
    {
        LinkButton lnkDelete = (LinkButton)sender;
        int rowIndex = Convert.ToInt32(lnkDelete.CommandArgument);

        DataTable dt = (DataTable)Session["MedicineTable"];
        dt.Rows.RemoveAt(rowIndex);

        // Update SrNo
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["SrNo"] = i + 1;
        }

        // Re-bind the GridView
        BindGridView1();
    }

    // Method to bind GridView
    private void BindGridView1()
    {
        DataTable dt = (DataTable)Session["MedicineTable"];
        GridMedicine.DataSource = dt;
        GridMedicine.DataBind();
    }
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Product_Sub_Type] where [Type_Id]=@Type_Id", con);
        cmd.Parameters.AddWithValue("@Type_Id", ddlproducttype.SelectedValue);
        try
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlproductsubtype.DataSource = dt;
            ddlproductsubtype.DataTextField = "Product_Sub_Type"; // Set the display text
            ddlproductsubtype.DataValueField = "Sub_Type_Id"; // Set the value

            ddlproductsubtype.DataBind();
            ddlproductsubtype.Items.Insert(0, new ListItem("Select Sub-Type", "-1"));
        }
        catch (Exception ex)
        {
            // Handle exception
        }
        finally
        {
            con.Close();
        }
    }
    protected void OnSelectedIndexChanged_SubType(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Add_Products] where [Sub_Type_Id]=@Sub_Type_Id", con);
        cmd.Parameters.AddWithValue("@Sub_Type_Id", ddlproductsubtype.SelectedValue);
        try
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlproductname.DataSource = dt;
            ddlproductname.DataTextField = "Product_Name"; // Set the display text
            ddlproductname.DataValueField = "Product_Id"; // Set the value

            ddlproductname.DataBind();
            ddlproductname.Items.Insert(0, new ListItem("Select Product", "-1"));
        }
        catch (Exception ex)
        {
            // Handle exception
        }
        finally
        {
            con.Close();
        }
    }
}