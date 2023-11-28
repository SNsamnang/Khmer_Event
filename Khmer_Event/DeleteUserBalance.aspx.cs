using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        string bId = Request.QueryString.Get("bId");
        SqlCommand cmd = new SqlCommand("DELETE FROM tblBalance where ID=@bId", conn);
        cmd.Parameters.Add("@bId", System.Data.SqlDbType.Int);
        cmd.Parameters["@bId"].Value = bId;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("AddAmount.aspx");
    }
}