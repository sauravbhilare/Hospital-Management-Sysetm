using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_Check_Up : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    BindDropdown B = new BindDropdown();
    SqlTransaction t;
    protected void Page_Load(object sender, EventArgs e)
    {
        doctorid.Text = ((Label)Master.FindControl("lbldoctid")).Text;
        doctorname.Text = ((Label)Master.FindControl("lbldoctname")).Text;

        if (!IsPostBack)
        {
            if (Request.QueryString["Appointment_Id"] != null && Request.QueryString["Appointment_Id"] != String.Empty)
            {
                lblappointmentid.Text = Request.QueryString["Appointment_Id"];
                Bind();



            }
            B.bindproduct(ddlprotype);
        }

    }
    public void btnsubmit_OnClick(object sender, EventArgs e)
    {
        Int32 ID123 = 0;
        con.Open();
        SqlTransaction t = con.BeginTransaction();
        try
        {

            cmd = new SqlCommand("INSERT INTO [dbo].[Check_Up]([Apointment_Id],[Patient_Id],[Patient_Name],[Check_Up_Details],[Prescribe_Test],[Checked_On],[Checked_By_Id],[Checked_By_Name],[Remarks],[Fees],[Status])VALUES(@Apointment_Id,@Patient_Id,@Patient_Name,@Check_Up_Details,@Prescribe_Test,@Checked_On,@Checked_By_Id,@Checked_By_Name,@Remarks,@Fees,@Status);SELECT SCOPE_IDENTITY();", con, t);
            cmd.Parameters.AddWithValue("@Apointment_Id", lblappointmentid.Text);
            cmd.Parameters.AddWithValue("@Patient_Id", lblpatientid.Text);
            cmd.Parameters.AddWithValue("@Patient_Name", lblname.Text);
            cmd.Parameters.AddWithValue("@Check_Up_Details", txtchkdetails.Text);
            cmd.Parameters.AddWithValue("@Prescribe_Test", txttest.Text);
            cmd.Parameters.AddWithValue("@Checked_On", DateTime.Now);
            cmd.Parameters.AddWithValue("@Checked_By_Id", doctorid.Text);
            cmd.Parameters.AddWithValue("@Checked_By_Name", doctorname.Text);
            cmd.Parameters.AddWithValue("@Remarks", txtremark.Text);
            cmd.Parameters.AddWithValue("@Fees", txtdoctorfee.Text);
            if (txtdoctorfee.Text != "")
            {
                cmd.Parameters.AddWithValue("@Status", "Paid");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", "Unpaid");
            }



            ID123 = Convert.ToInt32(cmd.ExecuteScalar());
            lblcheckid.Text = ID123.ToString();
            t.Commit();
            
            if (ViewState["MedicineTable"] != null)
            {
                DataTable dt = ViewState["MedicineTable"] as DataTable;
                if (!dt.Columns.Contains("Check_Id"))
                    dt.Columns.Add("Check_Id", typeof(int));
                foreach (DataRow row in dt.Rows)
                {
                   
                    row["Check_Id"] = ID123; // Assuming ID123 is the value from some source
                   
                }
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                objbulk.DestinationTableName = "[dbo].[Medicine_Master]";

                objbulk.ColumnMappings.Add("Check_Id", "Check_Id");
                objbulk.ColumnMappings.Add("Appointment_Id", "Appointment_Id");
                objbulk.ColumnMappings.Add("Patient_Id", "Patient_Id");
                objbulk.ColumnMappings.Add("Product_Type", "Product_Type");
                objbulk.ColumnMappings.Add("Sub_Type", "Sub_Type");
                objbulk.ColumnMappings.Add("Medicine_Name", "Medicine_Name");
                objbulk.ColumnMappings.Add("Medication_Time", "Medication_Time");
                objbulk.ColumnMappings.Add("Medication_Taking", "Medication_Taking");
                objbulk.ColumnMappings.Add("Medication_Dosage", "Medication_Dosage");
                objbulk.ColumnMappings.Add("Added_On", "Added_On");
                objbulk.ColumnMappings.Add("Added_By_Id", "Added_By_Id");
                objbulk.ColumnMappings.Add("Added_By_Name", "Added_By_Name");
                objbulk.WriteToServer(dt);
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "[dbo].[Medicine_Master]";

                    if (dt.Rows.Count > 0)
                    {
                        sqlBulkCopy.WriteToServer(dt);
                    }
                }
                //DataTable dt = (DataTable)ViewState["MedicineTable"];
                //foreach (DataRow row in dt.Rows)
                //{
                //    cmd = new SqlCommand("INSERT INTO [dbo].[Medicine_Master] " +
                //        "([Check_Id],[Appointment_Id],[Patient_Id],[Product_Type],[Sub_Type],[Medicine_Name]," +
                //        "[Medication_Time],[Medication_Taking],[Medication_Dosage],[Added_On],[Added_By_Id],[Added_By_Name]) " +
                //        "VALUES(@Check_Id,@Appointment_Id,@Patient_Id,@Product_Type,@Sub_Type,@Medicine_Name," +
                //        "@Medication_Time,@Medication_Taking,@Medication_Dosage,@Added_On,@Added_By_Id,@Added_By_Name)", con, t);

                //    // Assuming the parameters match your data types in the database
                //    cmd.Parameters.AddWithValue("@Check_Id", ID123);
                //    cmd.Parameters.AddWithValue("@Appointment_Id", lblappointmentid.Text);
                //    cmd.Parameters.AddWithValue("@Patient_Id", lblpatientid.Text);
                //    cmd.Parameters.AddWithValue("@Product_Type", row["ProductType"]);
                //    cmd.Parameters.AddWithValue("@Sub_Type", row["MedicineType"]);
                //    cmd.Parameters.AddWithValue("@Medicine_Name", row["MedicineName"]);
                //    cmd.Parameters.AddWithValue("@Medication_Time", row["MedicationTime"]);
                //    cmd.Parameters.AddWithValue("@Medication_Taking", row["MedicationTaking"]);
                //    cmd.Parameters.AddWithValue("@Medication_Dosage", row["MedicationDosage"]);
                //    cmd.Parameters.AddWithValue("@Added_On", DateTime.Now); // Assuming current date/time
                //    cmd.Parameters.AddWithValue("@Added_By_Id", doctorid.Text);
                //    cmd.Parameters.AddWithValue("@Added_By_Name", doctorname.Text);

                //    cmd.ExecuteNonQuery();

                //}
                //dt.Rows.Clear();

                //ViewState["MedicineTable"] = null;

                //GridMedicine.DataSource = null;
                //GridMedicine.DataBind();
                cmd = new SqlCommand("Update [dbo].[Appointment] set Status=@Status where Appointment_Id=@Appointment_Id", con, t);
                cmd.Parameters.AddWithValue("@Status", "Complete");
                cmd.Parameters.AddWithValue("@Appointment_Id", lblappointmentid.Text);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Update [dbo].[Paitents_Registration] set Visit_Date=@Visit_Date where Paitent_Id=@Paitent_Id", con, t);
                cmd.Parameters.AddWithValue("@Paitent_Id", lblpatientid.Text);
                cmd.Parameters.AddWithValue("@Visit_Date", DateTime.Now);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO [dbo].[Doctor_Fees]([Doctor_Id],[Doctor_Name],[Patient_Id],[Patient_Name],[Appointment_Id],[Fees],[Payment_Type],[Transaction_ID],[Payment_Status],[Payment_Date],[Problem],[Visited_Date])VALUES(@Doctor_Id,@Doctor_Name,@Patient_Id,@Patient_Name,@Appointment_Id,@Fees,@Payment_Type,@Transaction_ID,@Payment_Status,@Payment_Date,@Problem,@Visited_Date)", con, t);
                cmd.Parameters.AddWithValue("@Doctor_Id", doctorid.Text);
                cmd.Parameters.AddWithValue("@Doctor_Name", lblname.Text);
                cmd.Parameters.AddWithValue("@Patient_Id", lblpatientid.Text);
                cmd.Parameters.AddWithValue("@Patient_Name", lblname.Text);
                cmd.Parameters.AddWithValue("@Appointment_Id", lblappointmentid.Text);
                cmd.Parameters.AddWithValue("@Fees", txtdoctorfee.Text);
                cmd.Parameters.AddWithValue("@Payment_Type", drpmethod.SelectedValue);
                cmd.Parameters.AddWithValue("@Transaction_ID", txttransaction.Text);
                if (drpmethod.SelectedValue != "" && txtdoctorfee.Text != "")
                {
                    cmd.Parameters.AddWithValue("@Payment_Status", "Paid");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Payment_Status", "Unpaid");
                }

                cmd.Parameters.AddWithValue("@Payment_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Problem", lblappointmentreason.Text);
                cmd.Parameters.AddWithValue("@Visited_Date", DateTime.Now);
                cmd.ExecuteNonQuery();

             
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "var confirmation = confirm('Medicine Updated successfully...!');", true);
                btnsubmit.Visible = false;
                pay.Visible = false;
                Clear();

            }
            else
            {

                if (t != null)
                {
                    t.Rollback();
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }


        }
        catch (Exception ex)
        {

            if (t != null)
            {
                t.Rollback();
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);

        }
        finally
        {
            con.Close();
        }
    }
    protected void Clear()
    {

        txtchkdetails.Text = "";
        txttest.Text = "";
        txtdoctorfee.Text = "";
        drpmethod.ClearSelection();
        chkbox.Checked = false;


    }
    protected void Bind()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Appointment] where Appointment_Id='" + lblappointmentid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            lblname.Text = dr["Name"].ToString();
            object dobObj = dr["DOB"];
            if (dobObj != DBNull.Value)
            {
                lbldob.Text = Convert.ToDateTime(dobObj).ToString("dd/MM/yyyy");
            }
            else
            {
                // If DOB is null, set the textbox to be empty
                lbldob.Text = string.Empty;
            }
            lblage.Text = dr["Age"].ToString();
            lblgender.Text = dr["Gender"].ToString();
            lblmobile.Text = dr["Mobile"].ToString();
            //txtaltmobile.Text = dr["Alternate_Mobile"].ToString();
            //txtgmail.Text = dr["Gmail"].ToString();
            lbladdress.Text = dr["Address"].ToString();
            lblappointmentreason.Text = dr["Appointment_Reason"].ToString();
            lblappointmenttype.Text = dr["Appointment_Type"].ToString();
            lblstatus.Text = dr["Status"].ToString();
            lbltimeslot.Text = dr["Time_Slot"].ToString();
            DateTime dateTime = Convert.ToDateTime(dr["Appoitment_Date"]);

            // Extracting date and month separately
            string date = dateTime.ToString("dd"); // Gets the day as a two-digit number
            string monthName = dateTime.ToString("MMM"); // Gets the abbreviated month name (e.g., Jan, Feb)

            // Set the label text with the extracted date and month name
            lbldate.Text = date;
            lblmonth.Text = monthName;

            lblpatientid.Text = dr["Paitent_Id"].ToString();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Paitents_Registration] where Paitent_Id='" + lblpatientid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lblhealthissue.Text = dr["Health_Issue"].ToString();
            lblmedicalhistory.Text = dr["Medical_History"].ToString();
            lblpriscription.Text = dr["Prescriptions"].ToString(); ; // Replace with actual file name
            lblreports.Text = dr["Reports"].ToString(); ; // Replace with actual file name

            lblmedicins.Text = dr["List_Medicine"].ToString();

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
    }
    protected void DownloadPrescription_Click(object sender, EventArgs e)
    {
        string prescriptionFileName = lblpriscription.Text; // Replace with actual file name
        string prescriptionFilePath = Server.MapPath("/Staff/Patient/Prescriptions/" + prescriptionFileName); // Update path accordingly

        // Check if the file exists at the specified path
        if (File.Exists(prescriptionFilePath))
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + prescriptionFileName);
            Response.TransmitFile(prescriptionFilePath);
            Response.Flush(); // Send all content output to the client immediately
            Response.End(); // End the response, stopping any further processing
        }
        else
        {
            // Handle the case where the file doesn't exist
            // Display an error message or take appropriate action
        }
    }

    protected void DownloadReports_Click(object sender, EventArgs e)
    {
        string reportFileName = lblreports.Text; // Replace with actual file name
        string reportFilePath = Server.MapPath("/Staff/Patient/Reports/" + reportFileName); // Update path accordingly

        // Check if the file exists at the specified path
        if (File.Exists(reportFilePath))
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + reportFileName);
            Response.TransmitFile(reportFilePath);
            Response.Flush(); // Send all content output to the client immediately
            Response.End(); // End the response, stopping any further processing
        }
        else
        {
            // Handle the case where the file doesn't exist
            // Display an error message or take appropriate action
        }
    }




    protected void btnadd_OnClick(object sender, EventArgs e)
    {
        BindGridView();
    }

    private DataTable AddRowNumbers(DataTable originalDataTable)
    {
        DataTable newDataTable = originalDataTable.Clone();
        newDataTable.Columns["SrNo"].DataType = typeof(int);

        int rowNumber = 1;
        foreach (DataRow originalRow in originalDataTable.Rows)
        {
            DataRow newRow = newDataTable.NewRow();
            newRow.ItemArray = originalRow.ItemArray;
            newRow["SrNo"] = rowNumber;
            newDataTable.Rows.Add(newRow);
            rowNumber++;
        }

        return newDataTable;
    }
    protected void DeleteRow(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        int rowIndex = Convert.ToInt32(btnDelete.CommandArgument);

        DataTable dt = ViewState["MedicineTable"] as DataTable;
        if (dt != null)
        {
            try
            {
                dt.Rows.RemoveAt(rowIndex);

                // Re-number the SrNo column after deletion
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["SrNo"] = i + 1;
                }

                ViewState["MedicineTable"] = dt;

                // Rebind the GridView after deletion
                GridMedicine.DataSource = dt;
                GridMedicine.DataBind();
                btnsubmit.Visible = GridMedicine.Rows.Count > 0;
                pay.Visible = GridMedicine.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                // Log any exception to identify potential errors
                // Replace this with your preferred logging mechanism (e.g., Debug, Trace, Console, etc.)
                Console.WriteLine("Error deleting row: " + ex.Message);
            }
        }
    }

    private void BindGridView()
    {
        // Get selected values from dropdown lists
        string productType = ddlprotype.SelectedItem.Text;
        string medicineType = ddlmedtype.SelectedItem.Text;
        string medicineName = ddlmediname.SelectedItem.Text;

        // Get selected values from radio button lists
        string medicationTaking = rdlmediintake.SelectedValue;
        string medicationDosage = rdlmedidose.SelectedValue;

        // Get selected values from checkbox list
        List<string> selectedMedicationTimes = new List<string>();
        foreach (ListItem item in cbxMedicationTime.Items)
        {
            if (item.Selected)
            {
                selectedMedicationTimes.Add(item.Value);
            }
        }

        // Concatenate selected values into a single string
        string medicationTimes = string.Join("/", selectedMedicationTimes);

        // Create a DataTable if it doesn't exist in ViewState
        DataTable dt;
        if (ViewState["MedicineTable"] == null)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[13] {
            new DataColumn("SrNo", typeof(int)),
            new DataColumn("Check_Id", typeof(int)),
            new DataColumn("Appointment_Id", typeof(int)),
            new DataColumn("Patient_Id", typeof(int)),
            new DataColumn("Product_Type", typeof(string)),
            new DataColumn("Sub_Type", typeof(string)),
            new DataColumn("Medicine_Name", typeof(string)),
            new DataColumn("Medication_Time", typeof(string)),
            new DataColumn("Medication_Taking", typeof(string)),
            new DataColumn("Medication_Dosage", typeof(string)),
              new DataColumn("Added_On", typeof(string)),
            new DataColumn("Added_By_Id", typeof(string)),
            new DataColumn("Added_By_Name", typeof(string))

        });
        }
        else
        {
            // Retrieve DataTable from ViewState if it already exists
            dt = (DataTable)ViewState["MedicineTable"];
        }

        // Create a DataRow and add data to it
        DataRow dr = dt.NewRow();
        dr["SrNo"] = dt.Rows.Count + 1;
        int checkId;
        if (int.TryParse(lblcheckid.Text, out checkId))
        {
            dr["Check_Id"] = checkId;
        } // Assuming ID123 is the value from some source
        dr["Appointment_Id"] = Convert.ToInt32(lblappointmentid.Text); // Assuming lblappointmentid.Text contains integer value
        dr["Patient_Id"] = Convert.ToInt32(lblpatientid.Text); // Assuming lblpatientid.Text contains integer value
        dr["Product_Type"] = productType;
        dr["Sub_Type"] = medicineType;
        dr["Medicine_Name"] = medicineName;
        dr["Medication_Time"] = medicationTimes; // Assign concatenated string
        dr["Medication_Taking"] = medicationTaking;
        dr["Medication_Dosage"] = medicationDosage;
        dr["Added_On"] = DateTime.Now;
        dr["Added_By_Id"] = doctorid.Text;
        dr["Added_By_Name"] = doctorname.Text;


        // Add the DataRow to the DataTable
        dt.Rows.Add(dr);

        // Bind the DataTable to the GridView
        GridMedicine.DataSource = AddRowNumbers(dt);
        GridMedicine.DataBind();

        // Save the DataTable in ViewState for persistence across postbacks
        ViewState["MedicineTable"] = dt;

        // Clear the dropdown lists and radio buttons for the next entry
        ddlprotype.SelectedIndex = 0;
        ddlmedtype.SelectedIndex = 0;
        ddlmediname.SelectedIndex = 0;
        cbxMedicationTime.ClearSelection();
        rdlmediintake.ClearSelection();
        rdlmedidose.ClearSelection();
        btnsubmit.Visible = GridMedicine.Rows.Count > 0;
        pay.Visible = GridMedicine.Rows.Count > 0;
    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        cmd = new SqlCommand("SELECT * FROM [dbo].[Product_Sub_Type] where [Type_Id]=@Type_Id", con);
        cmd.Parameters.AddWithValue("@Type_Id", ddlprotype.SelectedValue);
        try
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlmedtype.DataSource = dt;
            ddlmedtype.DataTextField = "Product_Sub_Type"; // Set the display text
            ddlmedtype.DataValueField = "Sub_Type_Id"; // Set the value

            ddlmedtype.DataBind();
            ddlmedtype.Items.Insert(0, new ListItem("Select Sub-Type", "-1"));
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
        cmd.Parameters.AddWithValue("@Sub_Type_Id", ddlmedtype.SelectedValue);
        try
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlmediname.DataSource = dt;
            ddlmediname.DataTextField = "Product_Name"; // Set the display text
            ddlmediname.DataValueField = "Product_Id"; // Set the value

            ddlmediname.DataBind();
            ddlmediname.Items.Insert(0, new ListItem("Select Product", "-1"));
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
    protected void chkbox_CheckedChanged(object sender, EventArgs e)
    {
        if (chkbox.Checked == true)
        {
            droptest.Visible = true;
            testbox.Visible = true;
        }
        else
        {
            droptest.Visible = false;
            testbox.Visible = false;
        }
    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "showModel1", "showModel1();", true);
    }
    protected void drpmethodchanged(object sender, EventArgs e)
    {
        if (drpmethod.SelectedValue == "Online")
        {
            transaction.Visible = true;
        }
        else
        {
            transaction.Visible = false;
        }
    }
}