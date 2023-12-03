using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class deleteTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            string eId = Request.QueryString.Get("eid");
            SqlCommand cmdPT = new SqlCommand("Delete from tblTicket where TicketID=@TicketID", conn);
            cmdPT.Parameters.Add("@TicketID", System.Data.SqlDbType.Int);
            cmdPT.Parameters["@TicketID"].Value = eId;
            conn.Open();
            cmdPT.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Ticket.aspx");
        }
    }
}