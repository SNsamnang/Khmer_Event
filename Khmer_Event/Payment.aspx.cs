using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment : System.Web.UI.Page
{
    string uName;
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        MembershipUser currentUser = Membership.GetUser();
        if (!IsPostBack)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            string eId = Request.QueryString.Get("eid");
            SqlCommand cmdPT = new SqlCommand("SELECT * FROM tblTicket Where TicketID=@TicketID", conn);
            cmdPT.Parameters.Add("@TicketID", System.Data.SqlDbType.Int);
            cmdPT.Parameters["@TicketID"].Value = eId;
            SqlDataReader rd;
            conn.Open();
            rd = cmdPT.ExecuteReader();
            if (rd.Read() == true)
            {
                txtID.Text = rd[0].ToString();
                txtPayMent.Text = rd[12].ToString();
                txtStatus.Text = rd[13].ToString();

            }
            rd.Close();
            conn.Close();
            txtID.Text = eId;
            txtPayMent.Enabled=false;
            ShowDataFromBalance();
        }
    }
    private void ShowDataFromBalance(){
        MembershipUser currentUser = Membership.GetUser();
        if (currentUser != null)
        {
            uName = currentUser.UserName;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            SqlCommand cmdPT = new SqlCommand("SELECT * From tblUserBalance Inner Join [dbo].[aspnet_Users] On tblUserBalance.UserId = [dbo].[aspnet_Users].UserId where [dbo].[aspnet_Users].UserName=@UserId", conn);
            cmdPT.Parameters.Add("@UserId", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@UserId"].Value = uName;
            SqlDataReader rd;
            conn.Open();
            rd = cmdPT.ExecuteReader();
            if (rd.Read() == true)
            {
                txtTotalSpent.Text = rd[8].ToString();
                txtBalance.Text = rd[6].ToString();
            }
            
            rd.Close();
            conn.Close();

        }
    }


    protected void btnPay_Click(object sender, EventArgs e)
    {
        MembershipUser currentUser = Membership.GetUser();
        if (currentUser != null)
        {
            string status =txtStatus.Text;
            float balance = float.Parse(txtBalance.Text);
            float payment = float.Parse(txtPayMent.Text);
            if (status != "DONE")
            {
                if (balance >= payment)
                {
                    uName = currentUser.UserName;
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
                    SqlCommand cmdPT = new SqlCommand("Update tblUserBalance set tblUserBalance.SpentFirst=@SpentFirst, tblUserBalance.SpentAdd=@SpentAdd From tblUserBalance Inner Join [dbo].[aspnet_Users] On tblUserBalance.UserId = [dbo].[aspnet_Users].UserId where [dbo].[aspnet_Users].UserName=@UserId", conn);
                    cmdPT.Parameters.Add("@SpentFirst", System.Data.SqlDbType.Decimal);
                    cmdPT.Parameters["@SpentFirst"].Value = txtTotalSpent.Text;
                    cmdPT.Parameters.Add("@SpentAdd", System.Data.SqlDbType.Decimal);
                    cmdPT.Parameters["@SpentAdd"].Value = txtPayMent.Text;
                    cmdPT.Parameters.Add("@UserId", System.Data.SqlDbType.NVarChar);
                    cmdPT.Parameters["@UserId"].Value = uName;
                    conn.Open();
                    cmdPT.ExecuteNonQuery();
                    conn.Close();
                    UdateStatus();
                    Response.Redirect("MyTicket.aspx");
                }
                else
                {
                    lblMes.Text = "លុយមិនគ្រប់ទេ​ ហែងទិញច្រើនមេះ!!!";
                }
            }
            else
            {
                lblMes.Text = "ហែងមានមេះ Ticket មួយ Pay ពីរដង!!!";
            }
        }
        
    }
    private void UdateStatus()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("Update tblTicket set Status='DONE' where TicketID=@TicketID", conn);
        cmdPT.Parameters.Add("@TicketID", System.Data.SqlDbType.Decimal);
        cmdPT.Parameters["@TicketID"].Value = txtID.Text;
        conn.Open();
        cmdPT.ExecuteNonQuery();
        conn.Close();
    }
}