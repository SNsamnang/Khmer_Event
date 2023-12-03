using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyTicket : System.Web.UI.Page
{
    string CurrentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        MembershipUser currentUser = Membership.GetUser();
        CurrentUser = currentUser.UserName;
        if (!IsPostBack)
        {
            PopulateData();
        }
    }

    protected void lview1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lview1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.PopulateData();
    }

    protected void lview1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        TextBox tId = (TextBox)e.Item.FindControl("txtID");
        if (e.CommandName == "lPay")
            Response.Redirect("Payment.aspx?eid=" + tId.Text);
        else if (e.CommandName == "lView")
            Response.Redirect("View.aspx?eid=" + tId.Text);
    }
    private void PopulateData()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("SELECT TicketID, EventName, Place, Price, QTY, TotalPrice, Status from tblTicket where CurrentUser=@CurrentUser", conn);
        cmdPT.Parameters.Add("@CurrentUser", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@CurrentUser"].Value = CurrentUser;

        using (SqlDataAdapter sda = new SqlDataAdapter(cmdPT))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lview1.DataSource = dt;
            lview1.DataBind();
        }
    }
}