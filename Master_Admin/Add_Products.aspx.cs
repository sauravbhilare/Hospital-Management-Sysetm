using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_Add_Products : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    BindDropdown B = new BindDropdown();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            B.bindproducttype(ddlprotype);
            B.bindproductsubtype(ddlprosubtype);
            BindProduct();
        }
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string f1 = "", f2 = "";
        string fileName = string.Empty;
        Random r = new Random();
        bool IsValidFile = false;
        if (btnsubmit.Text == "Submit")
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO [dbo].[Add_Products]([Type_Id],[Product_Type],[Sub_Type_Id],[Product_Sub_Type],[Product_Name],[Price],[Quantity],[Image],[Multiple_Image],[Product_Details])VALUES(@Type_Id,@Product_Type,@Sub_Type_Id,@Product_Sub_Type,@Product_Name,@Price,@Quantity,@Image,@Multiple_Image,@Product_Details)", con);
                cmd.Parameters.AddWithValue("@Type_Id", ddlprotype.SelectedValue);
                cmd.Parameters.AddWithValue("@Product_Type", ddlprotype.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Sub_Type_Id", ddlprosubtype.SelectedValue);
                cmd.Parameters.AddWithValue("@Product_Sub_Type", ddlprosubtype.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Product_Name", txtproductname.Text);
                cmd.Parameters.AddWithValue("@Price", txtproprice.Text);

                cmd.Parameters.AddWithValue("@Quantity", txtquantity.Text);
                if (fileimage.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(fileimage.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = fileimage.FileName;
                    //f1 = ID + fileName;
                    f1 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        fileimage.SaveAs(Server.MapPath("/Product_Image/" + f1));
                        cmd.Parameters.AddWithValue("@Image", f1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Certificate1 File not valid');", true);
                        cmd.Parameters.AddWithValue("@Image", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Image", "");
                }

                if (filemimage.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(filemimage.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = filemimage.FileName;
                    //f1 = ID + fileName;
                    f2 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        filemimage.SaveAs(Server.MapPath("/Product_Image/" + f2));
                        cmd.Parameters.AddWithValue("@Multiple_Image", f2);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Certificate2 File not valid');", true);
                        cmd.Parameters.AddWithValue("@Multiple_Image", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Multiple_Image", "");
                }
                cmd.Parameters.AddWithValue("@Product_Details", txtdetails.Text);
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
                BindProduct();
            }
        }
        else if (btnsubmit.Text == "Update")
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE [dbo].[Add_Products] SET [Type_Id] = @Type_Id,[Product_Type] = @Product_Type,[Sub_Type_Id] = @Sub_Type_Id,[Product_Sub_Type] = @Product_Sub_Type,[Product_Name] = @Product_Name,[Price] = @Price,[Quantity] = @Quantity, [Image] = @Image,[Multiple_Image] = @Multiple_Image,[Product_Details] = @Product_Details WHERE [Product_Id]=@Product_Id", con);
                cmd.Parameters.AddWithValue("@Product_Id", lblid.Text);
                cmd.Parameters.AddWithValue("@Type_Id", ddlprotype.SelectedValue);
                cmd.Parameters.AddWithValue("@Product_Type", ddlprotype.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Sub_Type_Id", ddlprosubtype.SelectedValue);
                cmd.Parameters.AddWithValue("@Product_Sub_Type", ddlprosubtype.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Product_Name", txtproductname.Text);
                cmd.Parameters.AddWithValue("@Price", txtproprice.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtquantity.Text);
                if (fileimage.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(fileimage.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = fileimage.FileName;
                    //f1 = ID + fileName;
                    f1 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        fileimage.SaveAs(Server.MapPath("/Product_Image/" + f1));
                        cmd.Parameters.AddWithValue("@Image", f1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Image File not valid');", true);
                        cmd.Parameters.AddWithValue("@Image", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Image", lblimg.Text);
                }

                if (filemimage.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(filemimage.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = filemimage.FileName;
                    //f1 = ID + fileName;
                    f2 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        filemimage.SaveAs(Server.MapPath("/Product_Image/" + f2));
                        cmd.Parameters.AddWithValue("@Multiple_Image", f2);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Multiple Image Files not valid');", true);
                        cmd.Parameters.AddWithValue("@Multiple_Image", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Multiple_Image", lblimg.Text);
                }

                cmd.Parameters.AddWithValue("@Product_Details", txtdetails.Text);





                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Updated successfully...!');", true);
                Clear();
                btnsubmit.Text = "Submit";
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
    protected void Clear()
    {
        ddlprotype.ClearSelection();
        ddlprosubtype.ClearSelection();
        txtproductname.Text = "";
        txtproprice.Text = "";
        txtquantity.Text = "";
        txtdetails.Text = "";
    }
    protected void BindProduct()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "select * from [dbo].[Add_Products] order by Product_Id desc";
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvProduct.DataSource = ds;
            gvProduct.DataBind();
            gvProduct.Visible = true;
            if (ds.Rows.Count > 0)
            {

                gvProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvProduct.FooterRow.TableSection = TableRowSection.TableFooter;
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
    protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        lblid.Text = id;
        if (e.CommandName == "Update")
        {

            SqlConnection con = new SqlConnection(strcon);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From [dbo].[Add_Products] where Product_Id='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                ddlprotype.SelectedValue = dr["Type_Id"].ToString();
                ddlprosubtype.SelectedValue = dr["Sub_Type_Id"].ToString();
                txtproductname.Text = dr["Product_Name"].ToString();
                txtproprice.Text = dr["Price"].ToString();
                txtquantity.Text = dr["Quantity"].ToString();
                lblimg.Text = dr["Image"].ToString();
                lblmimg.Text = dr["Multiple_Image"].ToString();
                txtdetails.Text = dr["Product_Details"].ToString();
                btnsubmit.Text = "Update";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
        else if (e.CommandName == "Delete1")
        {
            string id1 = e.CommandArgument.ToString();
            try
            {
                con.Open();
                cmd = new SqlCommand("Delete From [dbo].[Add_Products] where Product_Id=@Product_Id", con);
                cmd.Parameters.AddWithValue("@Product_Id", id1);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Product Deleted successfully...!');", true);
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
    protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}