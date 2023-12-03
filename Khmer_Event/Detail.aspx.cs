using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Detail : System.Web.UI.Page
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            string eId = Request.QueryString.Get("eid");
            SqlCommand cmdPT = new SqlCommand("SELECT * FROM [dbo].[tblKhmerEvent] Where EventID=@eventId", conn);
            cmdPT.Parameters.Add("@eventId", System.Data.SqlDbType.Int);
            cmdPT.Parameters["@eventId"].Value = eId;
            SqlDataReader rd;
            conn.Open();
            rd = cmdPT.ExecuteReader();
            lview1.DataSource = rd;
            lview1.DataBind();
            rd.Close();
            conn.Close();
            

        }
    }

    protected void lview1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        TextBox tId = (TextBox)e.Item.FindControl("txtId");
        if (e.CommandName == "Buy")
            Response.Redirect("Buy.aspx?eid=" + tId.Text);
    }
}