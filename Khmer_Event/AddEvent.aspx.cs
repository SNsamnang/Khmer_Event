using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddEvent : System.Web.UI.Page
{
    string uName;
    protected void Page_Load(object sender, EventArgs e)
    {

        MembershipUser currentUser = Membership.GetUser();
        uName = currentUser.UserName;
    }



    protected void cmdAdd_Click(object sender, EventArgs e)
    {
        if (imgUpload.HasFile)
        {
            String imgName = imgUpload.FileName;
            imgUpload.SaveAs(Server.MapPath("~\\Image") + "/" + imgUpload.FileName);

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            SqlCommand cmdAdd = new SqlCommand("Insert Into tblKhmerEvent Values(@EventName, @Douration, @DateStart, @DateEnd, @Price, @Place, @Description, @Contact, @Link, @ImageURL, @Username)", conn);
            cmdAdd.Parameters.Add("@EventName", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@EventName"].Value = txtEventName.Text;
            cmdAdd.Parameters.Add("@Douration", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@Douration"].Value = txtDoutration.Text;
            cmdAdd.Parameters.Add("@DateStart", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@DateStart"].Value = txtDateStart.Text;
            cmdAdd.Parameters.Add("@DateEnd", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@DateEnd"].Value = txtDateEnd.Text;
            cmdAdd.Parameters.Add("@Price", System.Data.SqlDbType.Decimal);
            cmdAdd.Parameters["@Price"].Value = txtPrice.Text;
            cmdAdd.Parameters.Add("@Place", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@Place"].Value = txtPlace.Text;
            cmdAdd.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@Description"].Value = txtDescription.Text;
            cmdAdd.Parameters.Add("@Contact", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@Contact"].Value = txtContact.Text;
            cmdAdd.Parameters.Add("@Link", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@Link"].Value = txtLink.Text;
            cmdAdd.Parameters.Add("@ImageURL", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@ImageURL"].Value = "Image/" + imgName;
            cmdAdd.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar);
            cmdAdd.Parameters["@Username"].Value = uName;
            conn.Open();
            cmdAdd.ExecuteNonQuery();
            conn.Close();
            resets();
            lblMessage.Text = "You Have Added a New Row Successfully!";
            Response.Redirect("AddEvent.aspx");
        }
        else lblMessage.Text = "Make Sure You Have Complete All Field Properly!";
    }
    private void resets()
    {
        txtEventName.Text = "";
        txtDoutration.Text = "";
        txtDateStart.Text = "";
        txtDateEnd.Text = "";
        txtPlace.Text = "";
        txtPrice.Text = "";
        txtDescription.Text = "";
        txtContact.Text = "";
        txtLink.Text = "";
        cmdAdd.Enabled = true;
    }
}