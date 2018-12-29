using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;


public partial class RBS : System.Web.UI.MasterPage
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RBS_Conn"].ConnectionString);
    DataTable dtMainMenu = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Role"] = "RBS";
            Session["BranchID"] = "15";
            GetMenuData();
     }

    }
    private void GetMenuData()
    {
        DataTable table = new DataTable();
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["RBS_Conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(strCon);
        string sql = "SELECT [MENUID],[MENUNAME],[PARENTMENUID],PAGENAME FROM [RBS_EPS_Portal].[dbo].[SSC_MENUNEW]  where [PARENTMENUID]=0 and status=1  AND [SSC_MENUNEW].MENUOWNERROLE= '" + Session["Role"].ToString() + "' and BranchId='" + Session["BranchID"].ToString() + "' ORDER BY [seqorder]";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(table);
        foreach (DataRow row in table.Rows)
        {
            MenuItem menuItem = new MenuItem(row["MENUNAME"].ToString(), row["MENUID"].ToString());
            menuItem.NavigateUrl = row["PAGENAME"].ToString();
            menuBar.Items.Add(menuItem);
            AddChildItems(table, menuItem);
        }
    }
    private void AddChildItems(DataTable table, MenuItem menuItem)
    {
        DataTable table1 = new DataTable();
        string menuid = menuItem.Value;
        string sql = "SELECT [MENUID],[MENUNAME],[PARENTMENUID],PAGENAME FROM [RBS_EPS_Portal].[dbo].[SSC_MENUNEW] where [PARENTMENUID]='" + Convert.ToInt32(menuid) + "'and status=1  AND [SSC_MENUNEW].MENUOWNERROLE= '" + Session["Role"].ToString() + "' and BranchId='" + Session["BranchID"].ToString() + "' order by  [seqorder] ";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(table1);
        foreach (DataRow childView in table1.Rows)
        {
            MenuItem childItem = new MenuItem(childView["MENUNAME"].ToString(), childView["MENUID"].ToString());
            childItem.NavigateUrl = childView["PAGENAME"].ToString();
            menuItem.ChildItems.Add(childItem);
            AddChildItems(table, childItem);
        }
    }
}
