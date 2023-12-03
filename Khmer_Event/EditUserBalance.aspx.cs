using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUserBalance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            string bId = Request.QueryString.Get("bId");
            SqlCommand cmdUpdate = new SqlCommand("Select * From tblUserBalance Where ID=@bId", conn);
            cmdUpdate.Parameters.Add("@bId", System.Data.SqlDbType.Int);
            cmdUpdate.Parameters["@bId"].Value = bId;
            SqlDataReader rd;
            conn.Open();
            rd = cmdUpdate.ExecuteReader();
            if (rd.Read() == true)
            {
                txtID.Text = rd[0].ToString();
                txtUser.Text = rd[1].ToString();
                txtAmountFirst.Text = rd[2].ToString();

            }
            rd.Close();
            conn.Close();
            txtID.Text = bId;
            txtID.Enabled = false;
            chkAgr.Checked = false;
            btnBalance.Enabled = false;
        }
    }

    protected void btnBalance_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("UPDATE tblUserBalance SET AmountFirst=@AmountFirst, UserId=@UserId WHERE ID=@Id", conn);
        cmdPT.Parameters.Add("@Id", System.Data.SqlDbType.Int);
        cmdPT.Parameters["@Id"].Value = txtID.Text;
        cmdPT.Parameters.Add("@AmountFirst", System.Data.SqlDbType.Decimal);
        cmdPT.Parameters["@AmountFirst"].Value = txtAmountFirst.Text;
        cmdPT.Parameters.Add("@UserId", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@UserId"].Value = txtUser.SelectedValue.ToString();
        conn.Open();
        cmdPT.ExecuteNonQuery();
        lblMes.Text = "You Have Updated Successfully!";
        conn.Close();
        Response.Redirect("AddAmount.aspx");
    }

    protected void chkAgr_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAgr.Checked == true)
            btnBalance.Enabled = true;
        else
            btnBalance.Enabled = false;
    }
}