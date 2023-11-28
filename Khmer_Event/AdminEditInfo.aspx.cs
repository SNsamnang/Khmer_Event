using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEditInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            string eId = Request.QueryString.Get("eid");
            SqlCommand cmdPT = new SqlCommand("Select * From tblKhmerEvent Where EventID=@eventId", conn);
            cmdPT.Parameters.Add("@eventId", System.Data.SqlDbType.Int);
            cmdPT.Parameters["@eventId"].Value = eId;
            SqlDataReader rd;
            conn.Open();
            rd = cmdPT.ExecuteReader();
            if (rd.Read() == true)
            {
                txtEventID.Text = rd[0].ToString();
                txtEventName.Text = rd[1].ToString();
                txtDouration.Text = rd[2].ToString();
                txtDateStart.Text = rd[3].ToString();
                txtDateEnd.Text = rd[4].ToString();
                txtPrice.Text = rd[5].ToString();
                txtPlace.Text = rd[6].ToString();
                txtDescription.Text = rd[7].ToString();
                txtContact.Text = rd[8].ToString();
                txtLink.Text = rd[9].ToString();
            }
            rd.Close();
            conn.Close();
            txtEventID.Text = eId;
            txtEventID.Enabled = false;
            chkAgr.Checked = false;
            cmdUpdate.Enabled = true;
        }
    }

    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("UPDATE [dbo].[tblKhmerEvent]" +
        "SET [EventName] = @EventName, [Douration] = @Douration, [DateStart] = @DateStart" +
        ",[DateEnd] = @DateEnd, [Price] = @Price, [Place] = @Place, [Description] = @Description" +
        ",[Contace] = @Contace, [Link] = @Link WHERE[EventID] = @eventId", conn);
        cmdPT.Parameters.Add("@eventId", System.Data.SqlDbType.Int);
        cmdPT.Parameters["@eventId"].Value = txtEventID.Text;
        cmdPT.Parameters.Add("@EventName", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@EventName"].Value = txtEventName.Text;
        cmdPT.Parameters.Add("@Douration", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@Douration"].Value = txtDouration.Text;
        cmdPT.Parameters.Add("@DateStart", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@DateStart"].Value = txtDateStart.Text;
        cmdPT.Parameters.Add("@DateEnd", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@DateEnd"].Value = txtDateEnd.Text;
        cmdPT.Parameters.Add("@Price", System.Data.SqlDbType.Decimal);
        cmdPT.Parameters["@Price"].Value = txtPrice.Text;
        cmdPT.Parameters.Add("@Place", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@Place"].Value = txtPlace.Text;
        cmdPT.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@Description"].Value = txtDescription.Text;
        cmdPT.Parameters.Add("@Contace", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@Contace"].Value = txtContact.Text;
        cmdPT.Parameters.Add("@Link", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@Link"].Value = txtLink.Text;

        conn.Open();
        cmdPT.ExecuteNonQuery();
        lblMessage.Text = "You Have Updated Successfully!";
        conn.Close();
        Response.Redirect("ListAllEvent.aspx");

    }
}