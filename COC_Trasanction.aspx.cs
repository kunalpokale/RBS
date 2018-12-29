using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RBS_Conn"].ConnectionString);
    DataTable dtexcel = new DataTable();

    string FName = "";
    string LName = "";
    string UANNO = "";
    string EPSNO = "";
    string Entity = "";
    string Location = "";
    string DOB = " ";
    string DOJ = " ";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RbsPanel.Visible = false;
            panelEmail.Visible = false;
            panelReason.Visible = false;
            LoaddeputedCountry();
            ddlUserID.Items.Insert(0, "Select User Transaction");
         
        }
        Session["USer"] = "10650099";
       
        Enabled();
        
       
        
    }
    public void Enabled()
    {
        txtname.Enabled = false;

        txtuan.Enabled = false;
        txteps.Enabled = false;
        txtentity.Enabled = false;
        txtlocation.Enabled = false;
        txtdob.Enabled = false;
        txtdoj.Enabled = false;

    }

    public void getdata()
    {

        try
        {
            string SqlQuery = "select [COCID] FROM [RBS_EPS_Portal].[dbo].[COC_TrackingDeatils] where [PSNO]='"+txtpsno.Text.ToString().Trim()+"'";
            SqlDataAdapter sdar = new SqlDataAdapter(SqlQuery, conn);
            DataTable Cdtl = new DataTable();
            sdar.Fill(Cdtl);
            if (Cdtl.Rows.Count > 0)
            {

                ddlUserID.DataSource = Cdtl;
                ddlUserID.DataBind();
                ddlUserID.DataTextField = "COCID";
                ddlUserID.DataValueField = "COCID";
                ddlUserID.DataBind();
                ddlUserID.Items.Insert(0, "Select User Transaction");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "failedalert();", true);
                txtpsno.Enabled = true;
                ddlUserID.ClearSelection();
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {

        }

    }
    protected void ddlUserID_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Check = ddlUserID.SelectedIndex.ToString();
        if (Check == "0")
        {
            RbsPanel.Visible = false;
            txtpsno.Enabled = true;
         
        }
        else
        {
            try
            {
                string SqlQuery = "select [Name],[UAN_NO],[EPS_NO],[Entity],[Location],[DOB],[DOJ],[Country_Deputed],[Deputation_From],[Deputation_TO],[App_ReceivedDate],[Submision_RFC_Date],[Application_No],[COC_No],[COC_Sent_To],[COC_Sent_Date],[Reason_For_Rejection],[Comment] FROM [RBS_EPS_Portal].[dbo].[COC_TrackingDeatils] where [COCID]='" + ddlUserID.SelectedValue.ToString() + "'";
                SqlDataAdapter sdar = new SqlDataAdapter(SqlQuery, conn);
                DataTable dt = new DataTable();
                sdar.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    txtname.Text = dt.Rows[0]["Name"].ToString().Trim();
                    txtuan.Text = dt.Rows[0]["UAN_NO"].ToString().Trim();
                    txteps.Text = dt.Rows[0]["EPS_NO"].ToString().Trim();
                    txtentity.Text = dt.Rows[0]["Entity"].ToString().Trim();
                    txtlocation.Text = dt.Rows[0]["Location"].ToString().Trim();
                    txtdob.Text = dt.Rows[0]["DOB"].ToString().Trim();
                    txtdoj.Text = dt.Rows[0]["DOJ"].ToString().Trim();
                    String value = dt.Rows[0]["Country_Deputed"].ToString().Trim();
                    ddlDeputedCountry.SelectedValue = value.ToString().Trim();
                    txtFrom.Text = dt.Rows[0]["Deputation_From"].ToString().Trim();
                    txtToDate.Text = dt.Rows[0]["Deputation_TO"].ToString().Trim();
                    txtRcvdDate.Text = dt.Rows[0]["App_ReceivedDate"].ToString().Trim();
                    txtRPFC.Text = dt.Rows[0]["Submision_RFC_Date"].ToString().Trim();
                    txtAppNo.Text = dt.Rows[0]["Application_No"].ToString().Trim();
                    txtCOCNo.Text = dt.Rows[0]["COC_No"].ToString().Trim();
                    txtORGCOCSent.Text = dt.Rows[0]["COC_Sent_To"].ToString().Trim();
                    txtSentDate.Text = dt.Rows[0]["COC_Sent_Date"].ToString().Trim();
                    txtReason.Text = dt.Rows[0]["Reason_For_Rejection"].ToString().Trim();
                    txtcmt.Text = dt.Rows[0]["Comment"].ToString().Trim();
                  
                }
              }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            RbsPanel.Visible = true;
        }
    }
    public void LoaddeputedCountry()
    {
        try
       {
            string query="select [CountryID],[Deputed_Country] FROM [RBS_EPS_Portal].[dbo].[Deputed_Country]";
            SqlDataAdapter sda = new SqlDataAdapter(query,conn);
            DataTable Cdt = new DataTable();
            sda.Fill(Cdt);
            ddlDeputedCountry.DataSource = Cdt;
            ddlDeputedCountry.DataBind();
            ddlDeputedCountry.DataTextField = "Deputed_Country";
            ddlDeputedCountry.DataValueField = "CountryID";
            ddlDeputedCountry.DataBind();
            ddlDeputedCountry.Items.Insert(0,"Select Country");
            
       }
        catch(Exception ex)
        {
          
        }
        finally
        {

        }
    }
    protected void txtpsno_TextChanged(object sender, EventArgs e)
    {
        
        txtpsno.Enabled = false;
        getdata();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SP_RBS_COC", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@statement","RBSUpdate");
        cmd.Parameters.AddWithValue("@Country_Deputed",ddlDeputedCountry.SelectedItem.Value.ToString().Trim());
        cmd.Parameters.AddWithValue("@Deputation_From",txtFrom.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@Deputation_TO",txtToDate.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@App_ReceivedDate",txtRcvdDate.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@Submision_RFC_Date",txtRPFC.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@Application_No",txtAppNo.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@COC_No",txtCC.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@COC_Sent_To",txtCOCNo.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@COC_Sent_Date",txtORGCOCSent.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@Reason_For_Rejection",txtReason.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@PDF_file","test");
        cmd.Parameters.AddWithValue("@PDF_Sent_to_Email",txtEmail.Text.ToString().Trim());
        conn.Open();
        int rowaffected = cmd.ExecuteNonQuery();
        conn.Close();
        if (rowaffected > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "failedError();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "failedError();", true);
        }




    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clearData();
    }

    public void clearData()
    {
        ddlDeputedCountry.ClearSelection();
        txtFrom.Text = " ";
        txtToDate.Text = " ";
        txtRcvdDate.Text="";
        txtRPFC.Text = "";
        txtAppNo.Text = "";
        txtCC.Text = "";
        txtCOCNo.Text = "";
        txtORGCOCSent.Text = "";
        txtReason.Text = "";
        txtEmail.Text = "";
        txtSentDate.Text = "";
    }
    protected void CheckBoxEmail_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBoxEmail.Checked == true)
        {
            panelEmail.Visible = true;
        }
        else
        {
            panelEmail.Visible = false;
        }
    }
    protected void CheckBoxReason_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBoxReason.Checked == true)
        {
            panelReason.Visible = true;
        }
        else
        {
            panelReason.Visible = false;
        }
    }
  
    protected void btnuplaod_Click(object sender, EventArgs e)
    {

        try
        {
            ReadExcel();
        
           
            foreach (DataRow dr in dtexcel.Rows)
            {
                PRMWebService(dr["PSNO"].ToString().Trim());

                string Name=FName +' '+LName;

                SqlCommand cmd = new SqlCommand("SP_RBS_COC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@statement", "RBSInsert");
                cmd.Parameters.AddWithValue("@PSNO",dr["PSNO"].ToString().Trim());
                 cmd.Parameters.AddWithValue("@Name",Name.ToString().Trim());
                 cmd.Parameters.AddWithValue("@UAN_NO",UANNO.ToString().Trim());
                 cmd.Parameters.AddWithValue("@EPS_NO",EPSNO.ToString().Trim());
                 cmd.Parameters.AddWithValue("@Entity",Entity.ToString().Trim());
                 cmd.Parameters.AddWithValue("@Location",Location.ToString().Trim());
                 cmd.Parameters.AddWithValue("@DOB",DOB.ToString().Trim());
                 cmd.Parameters.AddWithValue("@DOJ",DOJ.ToString().Trim());
                 cmd.Parameters.AddWithValue("@Country_Deputed", dr["Country of deputation"].ToString().Trim());
                 cmd.Parameters.AddWithValue("@Deputation_From", dr["Effective date"].ToString().Trim());
                 cmd.Parameters.AddWithValue("@Deputation_TO", dr["Expiry date"].ToString().Trim());
                 cmd.Parameters.AddWithValue("@Application_No", dr["COC Application Ref NO"].ToString().Trim());
                 cmd.Parameters.AddWithValue("@userid",Session["USer"].ToString().Trim());
                 conn.Open();                
                int rowaffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (rowaffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "ExcelJS();", true);
                }


            }
           
        }
        catch
        {
 
        }
        finally
        {

        }
      
    }
    public void PRMWebService(string PSNO)
    {

        try
        {

            PRMWebServices.PRMEMDATASoapClient PRWeb = new PRMWebServices.PRMEMDATASoapClient();
            DataSet ds = new DataSet();
            ds = PRWeb.getPersonalDetails(PSNO);
           if (ds.Tables[0].Rows.Count> 0)
            {

                FName = (String)ds.Tables[0].Rows[0]["FIRSTNAME"].ToString().Trim();
                LName = (String)ds.Tables[0].Rows[0]["LASTNAME"].ToString().Trim();
                UANNO = (String)ds.Tables[0].Rows[0]["UAN"].ToString().Trim();
                EPSNO = (String)ds.Tables[0].Rows[0]["EPS"].ToString().Trim();
                Entity = (String)ds.Tables[0].Rows[0]["ENTITY"].ToString().Trim();
                Location = (String)ds.Tables[0].Rows[0]["LOCATION"].ToString().Trim();
                DOB = (String)ds.Tables[0].Rows[0]["DOB"].ToString().Trim();
                DOJ = (String)ds.Tables[0].Rows[0]["DATEOFJOINING"].ToString().Trim();

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CheckPS();", true);
            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CheckPS();", true);
        }
    }
    private void ReadExcel()
    {
        try
        {
            string connString = "";
            string fileName = Path.GetFileName(rbsuplaod.PostedFile.FileName);
            string strFileType = Path.GetExtension(rbsuplaod.PostedFile.FileName);
            string path = string.Concat((Server.MapPath("~/UploadFiles/" + rbsuplaod.FileName)));
            rbsuplaod.PostedFile.SaveAs(path);

            //Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            string query = "SELECT * FROM [Sheet1$]";
            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtexcel = ds.Tables[0];
            da.Dispose();
            conn.Close();
            conn.Dispose();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "ExcelJS();", true);

        }
        finally
        {
 
        }



    }
   
}