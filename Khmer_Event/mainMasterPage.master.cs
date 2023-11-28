using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class mainMasterPage : System.Web.UI.MasterPage
{
    String uName;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            PopulateData();
        }
    }

    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.PopulateData();
    }
    private void PopulateData()
    {
            MembershipUser currentUser = Membership.GetUser();
        if (currentUser != null)
        {
            uName = currentUser.UserName;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            SqlCommand cmdPT = new SqlCommand("SELECT tblBalance.Balance, [dbo].[aspnet_Users].UserName From tblBalance Inner Join [dbo].[aspnet_Users] On tblBalance.UserId = [dbo].[aspnet_Users].UserId where [dbo].[aspnet_Users].UserName=@UserId", conn);
            cmdPT.Parameters.Add("@UserId", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@UserId"].Value = uName;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmdPT))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListView1.DataSource = dt;
                ListView1.DataBind();
            }

        }
    }
}
