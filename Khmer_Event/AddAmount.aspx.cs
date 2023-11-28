using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddAmount : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateData();
        }
    }
    private void PopulateData()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("SELECT tblBalance.ID, tblBalance.Amount,tblBalance.Spent,tblBalance.Balance, [dbo].[aspnet_Users].UserName From tblBalance Inner Join [dbo].[aspnet_Users] On tblBalance.UserId = [dbo].[aspnet_Users].UserId", conn);
        using (SqlDataAdapter sda = new SqlDataAdapter(cmdPT))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            view1.DataSource = dt;
            view1.DataBind();
        }
    }
    protected void view1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (view1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.PopulateData();
    }


    protected void btnBalance_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdAdd = new SqlCommand("Insert Into tblBalance Values(@Amount, @Spent, @UserId,@Balance)", conn);
        cmdAdd.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal);
        cmdAdd.Parameters["@Amount"].Value = txtAmount.Text;
        cmdAdd.Parameters.Add("@Spent", System.Data.SqlDbType.Decimal);
        cmdAdd.Parameters["@Spent"].Value = txtSpent.Text;
        cmdAdd.Parameters.Add("@UserId", System.Data.SqlDbType.NVarChar);
        cmdAdd.Parameters["@UserId"].Value = txtUser.SelectedValue.ToString();
        cmdAdd.Parameters.Add("@Balance", System.Data.SqlDbType.Decimal);
        cmdAdd.Parameters["@Balance"].Value = txtBalance.Text;
        conn.Open();
        cmdAdd.ExecuteNonQuery();
        conn.Close();
        reset();
        Response.Redirect("AddAmount.aspx");
        lblMes.Text = "You Have Added a New Row Successfully!";
    }
    private void reset()
    {
        txtAmount.Text = "";
        txtSpent.Text = "";
        txtBalance.Text = "";
        chkgr.Checked = false;
    }

    protected void lview1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        TextBox bId = (TextBox)e.Item.FindControl("txtID");
        if (e.CommandName == "Edit")
            Response.Redirect("EditUserBalance.aspx?bId=" + bId.Text);
        else if (e.CommandName == "Delete")
            Response.Redirect("DeleteUserBalance.aspx?bId=" + bId.Text);
    }



    protected void btnlist_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("SELECT tblBalance.ID, tblBalance.Amount,tblBalance.Spent,tblBalance.Balance, [dbo].[aspnet_Users].UserName From tblBalance Inner Join [dbo].[aspnet_Users] On tblBalance.UserId = [dbo].[aspnet_Users].UserId where tblBalance.UserId=@UserId", conn);
        cmdPT.Parameters.Add("@UserId", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@UserId"].Value = DropDownList1.SelectedValue.ToString();
        using (SqlDataAdapter sda = new SqlDataAdapter(cmdPT))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            view1.DataSource = dt;
            view1.DataBind();
        }
    }



    protected void txtRefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddAmount.aspx");
    }
}