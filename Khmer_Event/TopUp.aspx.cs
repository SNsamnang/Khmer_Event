using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TopUp : System.Web.UI.Page
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            string eId = Request.QueryString.Get("bId");
            SqlCommand cmdPT = new SqlCommand("SELECT * FROM tblUserBalance Where ID=@ID", conn);
            cmdPT.Parameters.Add("@ID", System.Data.SqlDbType.Int);
            cmdPT.Parameters["@ID"].Value = eId;
            SqlDataReader rd;
            conn.Open();
            rd = cmdPT.ExecuteReader();
            if (rd.Read() == true)
            {
                txtID.Text = rd[0].ToString();
                txtTotalAmount.Text = rd[7].ToString();

            }
            rd.Close();
            conn.Close();
        }
    }

    protected void btnTopup_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("Update tblUserBalance set AmountFirst=@AmountFirst, AmountAdd=@AmountAdd where ID=@ID", conn);
        cmdPT.Parameters.Add("@ID", System.Data.SqlDbType.Int);
        cmdPT.Parameters["@ID"].Value = txtID.Text;
        cmdPT.Parameters.Add("@AmountFirst", System.Data.SqlDbType.Decimal);
        cmdPT.Parameters["@AmountFirst"].Value = txtTotalAmount.Text;
        cmdPT.Parameters.Add("@AmountAdd", System.Data.SqlDbType.Decimal);
        cmdPT.Parameters["@AmountAdd"].Value = txtAmountAdd.Text;
        conn.Open();
        cmdPT.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("AddAmount.aspx");
    }
}