using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;


/// <summary>
/// Summary description for BindDropdown
/// </summary>
public class BindDropdown
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    public BindDropdown()
    {

    }
    public void binddlpatient(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT CONCAT(First_Name, ' ', Last_Name) AS FullName, Paitent_Id FROM [dbo].[Paitents_Registration]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "FullName"; // Use the concatenated FullName field
                drop.DataValueField = "Paitent_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("---Select---", "-1"));
            }
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
    public void binddldoctors(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT CONCAT(First_Name, ' ', Last_Name) AS FullName, Doctor_Id FROM [dbo].[Doctors]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "FullName"; // Use the concatenated FullName field
                drop.DataValueField = "Doctor_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("---Select---", ""));
            }
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
    public void bindproducttype(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Product_Type]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "Product_Type"; // Use the concatenated FullName field
                drop.DataValueField = "Type_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("---Select---", "-1"));
            }
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
    public void bindproductsubtype(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Product_Sub_Type]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "Product_Sub_Type"; // Use the concatenated FullName field
                drop.DataValueField = "Sub_Type_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("---Select---", "-1"));
            }
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

    public void bindproduct(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Product_Type]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "Product_Type"; // Use the concatenated FullName field
                drop.DataValueField = "Type_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("Select Type", "-1"));
            }
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
    public void bindRole(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Staff_Role]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "Role_Name"; // Use the concatenated FullName field
                drop.DataValueField = "Role_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("Select Role", ""));
            }
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
    public void binDepartment(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Department]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "Department_Name"; // Use the concatenated FullName field
                drop.DataValueField = "Department_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("Select Department", "-1"));
            }
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
    public void bindstaff(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT CONCAT(First_Name, ' ', Last_Name) AS FullName, Staff_Id FROM [dbo].[Staff]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "FullName"; // Use the concatenated FullName field
                drop.DataValueField = "Staff_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("Select Staff", "-1"));
            }
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
    public void bindUnit(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Unit]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "Unit_Name"; // Use the concatenated FullName field
                drop.DataValueField = "Unit_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("Select Units", "-1"));
            }
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
    public void bindProducts(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Add_Products]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "Product_Name"; // Use the concatenated FullName field
                drop.DataValueField = "Product_Id";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("---Select---", "-1"));
            }
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

    public void bindSupplier(DropDownList drop)
    {
        cmd = new SqlCommand("SELECT * FROM [doctorapp].[Supplier]", con);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                drop.DataSource = reader;
                drop.DataTextField = "Name"; // Use the concatenated FullName field
                drop.DataValueField = "Suplier_ID";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("---Select---", ""));
            }
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