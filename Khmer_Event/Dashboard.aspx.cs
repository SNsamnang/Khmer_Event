using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowDashboardEvent();
            ShowDashboardUser();
            ShowDashboardTicket();
        }

    }
    private void ShowDashboardEvent()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("SELECT COUNT(EventID) From tblKhmerEvent ", conn);
        conn.Open();
        dashboardevent.Text = Convert.ToString(cmdPT.ExecuteScalar());
        conn.Close();
    }
    private void ShowDashboardUser()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("SELECT COUNT(UserName) From [dbo].[aspnet_Users] ", conn);
        conn.Open();
        dashboarduser.Text = Convert.ToString(cmdPT.ExecuteScalar());
        conn.Close();
    }
    private void ShowDashboardTicket() 
    { 
    
    }
}