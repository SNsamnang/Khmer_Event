using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListAllUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateData();
        }
    }

    private void PopulateData()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("SELECT UserName FROM [dbo].[aspnet_Users] ", conn);
        using (SqlDataAdapter sda = new SqlDataAdapter(cmdPT))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lview1.DataSource = dt;
            lview1.DataBind();
        }
    }

    protected void lview1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lview1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.PopulateData();
    }
}