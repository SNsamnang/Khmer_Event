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
        string eId = Request.QueryString.Get("eid");
        SqlCommand cmd = new SqlCommand("DELETE FROM tblKhmerEvent where EventID=@eventId", conn);
        cmd.Parameters.Add("@eventId", System.Data.SqlDbType.Int);
        cmd.Parameters["@eventId"].Value = eId;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("ListAllEvent.aspx");
    }
}