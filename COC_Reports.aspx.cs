using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Default2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RBS_Conn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoaddeputedCountry();
            pnlcountry.Visible = false;
            grvreport.Visible = false;
            PanelLog.Visible = false;

        }

        panelApplication.Visible = false;
        panelStxt.Visible = false;
        
    }
    public void LoaddeputedCountry()
    {
        try
        {
            string query = "select [CountryID],[Deputed_Country] FROM [RBS_EPS_Portal].[dbo].[Deputed_Country]";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable Cdt = new DataTable();
            sda.Fill(Cdt);
            ddlSearchCountry.DataSource = Cdt;
            ddlSearchCountry.DataBind();
            ddlSearchCountry.DataTextField = "Deputed_Country";
            ddlSearchCountry.DataValueField = "CountryID";
            ddlSearchCountry.DataBind();
            ddlSearchCountry.Items.Insert(0, "Select Country");

        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void ddlsearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsearch.SelectedValue == "0")
        {

        }
        else if (ddlsearch.SelectedValue == "1")
        {
            pnlcountry.Visible = true;
        }
        else if (ddlsearch.SelectedValue == "2")
        {
            pnlcountry.Visible = false;
            panelApplication.Visible = true;
        }
        else if (ddlsearch.SelectedValue == "3")
        {

            getRPFCData();
            //panelApplication.Visible = true;
        }
        else if (ddlsearch.SelectedValue == "4")
        {

            getRejectionData();
            //panelApplication.Visible = true;
        }
        else if (ddlsearch.SelectedValue == "5")
        {
            panelStxt.Visible = true;
        }
        else if (ddlsearch.SelectedValue == "6")
        {
            PanelLog.Visible = true;
        }
    }
    protected void ddlSearchCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SP_RBS_COC_Report", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statement", "Country");
            cmd.Parameters.AddWithValue("@Country", ddlSearchCountry.SelectedItem.ToString());
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                grvpanel.Visible = true;
                grvreport.DataSource = dt;
                grvreport.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "GrvData();", true);
                grvpanel.Visible = false;

            }


        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void gtnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SP_RBS_COC_Report", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statement", "AppRecevied");
            cmd.Parameters.AddWithValue("@fromdate", txtFrom.Text.ToString());
            cmd.Parameters.AddWithValue("@Todate", txtTO.Text.ToString());
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                grvpanel.Visible = true;
                grvreport.DataSource = dt;
                grvreport.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "GrvData();", true);
                grvpanel.Visible = false;

            }


        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void txtPSNO_TextChanged(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SP_RBS_COC_Report", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statement", "PSNO");
            cmd.Parameters.AddWithValue("@PSNO", txtPSNO.Text.ToString().Trim());
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                grvreport.DataSource = dt;
                grvreport.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "GrvData();", true);

            }


        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    public void getRPFCData()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SP_RBS_COC_Report", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statement", "RPFC");
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                grvreport.DataSource = dt;
                grvreport.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "GrvData();", true);


            }


        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }

    public void getRejectionData()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SP_RBS_COC_Report", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statement", "Rejection");
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                grvreport.DataSource = dt;
                grvreport.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "GrvData();", true);


            }


        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void txtlog_TextChanged(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SP_RBS_COC_Report", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@statement", "LOG");
            cmd.Parameters.AddWithValue("@PSNO", txtlog.Text.ToString().Trim());
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                GrvLog.DataSource = dt;
                GrvLog.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "GrvData();", true);


            }


        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
}