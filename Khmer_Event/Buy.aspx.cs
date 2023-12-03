using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Buy : System.Web.UI.Page
{
    string CurrentUser;
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        MembershipUser currentUser = Membership.GetUser();
        CurrentUser = currentUser.UserName;
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
            if (rd.Read() == true)
            {
                txtId.Text = rd[0].ToString();
                txtEventName.Text = rd[1].ToString();
                txtDouration.Text = rd[2].ToString();
                txtDateStart.Text = rd[3].ToString();
                txtDateEnd.Text = rd[4].ToString();
                txtPrice.Text = rd[5].ToString();
                txtPrice1.Text = "$ "+rd[5].ToString();
                txtPlace.Text = rd[6].ToString();
                txtTotalQTY.Text = rd[7].ToString();
                txtContact.Text = rd[9].ToString();
                txtUserName.Text = rd[12].ToString();
                            
            }
            rd.Close();
            conn.Close();
            txtId.Text = eId;
            txtId.Enabled = false;
            ShowImage();


        }
    }
    private void ShowImage()
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        string eId = Request.QueryString.Get("eid");
        SqlCommand cmdPT = new SqlCommand("Select EventID, ImageURL From tblKhmerEvent Where EventID=@eventId", conn);
        cmdPT.Parameters.Add("@eventId", System.Data.SqlDbType.Int);
        cmdPT.Parameters["@eventId"].Value = eId;

        SqlDataReader rd;
        conn.Open();
        rd = cmdPT.ExecuteReader();
        lview1.DataSource = rd;
        lview1.DataBind();
        rd.Close();
        conn.Close();
        txtId.Text = eId;
    }
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        int TotalQTY = int.Parse(txtTotalQTY.Text);
        int QTY = int.Parse(txtQTY.Text);
        if (TotalQTY >= QTY)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            SqlCommand cmdPT = new SqlCommand("Insert Into tblTicket(EventName, Douration, DateStart," +
                "DateEnd, Place, Contace, Username, Price, YourPhone, QTY, CurrentUser) " +
                "Values(@EventName, @Douration, @DateStart," +
                "@DateEnd, @Place, @Contact, @UserName, @Price, @YourPhone, @QTY, @CurrentUser)", conn);
            cmdPT.Parameters.Add("@EventName", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@EventName"].Value = txtEventName.Text;
            cmdPT.Parameters.Add("@Douration", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@Douration"].Value = txtDouration.Text;
            cmdPT.Parameters.Add("@DateStart", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@DateStart"].Value = txtDateStart.Text;
            cmdPT.Parameters.Add("@DateEnd", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@DateEnd"].Value = txtDateEnd.Text;
            cmdPT.Parameters.Add("@Place", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@Place"].Value = txtPlace.Text;
            cmdPT.Parameters.Add("@Contact", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@Contact"].Value = txtContact.Text;
            cmdPT.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@UserName"].Value = txtUserName.Text;
            cmdPT.Parameters.Add("@Price", System.Data.SqlDbType.Decimal);
            cmdPT.Parameters["@Price"].Value = txtPrice.Text;
            cmdPT.Parameters.Add("@YourPhone", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@YourPhone"].Value = txtPhone.Text;
            cmdPT.Parameters.Add("@QTY", System.Data.SqlDbType.Int);
            cmdPT.Parameters["@QTY"].Value = txtQTY.Text;
            cmdPT.Parameters.Add("@CurrentUser", System.Data.SqlDbType.NVarChar);
            cmdPT.Parameters["@CurrentUser"].Value = CurrentUser;
            conn.Open();
            cmdPT.ExecuteNonQuery();
            conn.Close();
            SoulTicket();
            Response.Redirect("MyTicket.aspx");
        }
        else
        {
            lblMes.Text = "Out Of Stock. Can Not Buy!!!";
        }
    }
    private void SoulTicket()
    {
        int TotalQTY = int.Parse(txtTotalQTY.Text);
        int QTY = int.Parse(txtQTY.Text);
        int QTYbefor = TotalQTY - QTY;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("Update tblKhmerEvent set QTY=@QTYbefor where EventID=@EventID", conn);
        cmdPT.Parameters.Add("@EventID", System.Data.SqlDbType.Int);
        cmdPT.Parameters["@EventID"].Value = txtId.Text;
        cmdPT.Parameters.Add("@QTYbefor", System.Data.SqlDbType.Int);
        cmdPT.Parameters["@QTYbefor"].Value = QTYbefor;
        conn.Open();
        cmdPT.ExecuteNonQuery();
        conn.Close();
    }
}