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
        SqlCommand cmdPT = new SqlCommand("SELECT tblUserBalance.ID, tblUserBalance.TotalAmount,tblUserBalance.TotalSpent,tblUserBalance.Balance, [dbo].[aspnet_Users].UserName From tblUserBalance Inner Join [dbo].[aspnet_Users] On tblUserBalance.UserId = [dbo].[aspnet_Users].UserId order by [dbo].[aspnet_Users].UserName", conn);
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
        SqlCommand cmdAdd = new SqlCommand("Insert Into tblUserBalance(UserId,AmountFirst,SpentFirst,AmountAdd,SpentAdd) Values(@UserId, @AmountFirst, @SpentFirst, @AmountAdd, @SpentAdd )", conn);
        cmdAdd.Parameters.Add("@UserId", System.Data.SqlDbType.NVarChar);
        cmdAdd.Parameters["@UserId"].Value = txtUser.SelectedValue.ToString();
        cmdAdd.Parameters.Add("@AmountFirst", System.Data.SqlDbType.Decimal);
        cmdAdd.Parameters["@AmountFirst"].Value = txtAmountFirst.Text;
        cmdAdd.Parameters.Add("@SpentFirst", System.Data.SqlDbType.Decimal);
        cmdAdd.Parameters["@SpentFirst"].Value = txtSpentFirst.Text;
        cmdAdd.Parameters.Add("@AmountAdd", System.Data.SqlDbType.Decimal);
        cmdAdd.Parameters["@AmountAdd"].Value = txtAmountAdd.Text;
        cmdAdd.Parameters.Add("@SpentAdd", System.Data.SqlDbType.Decimal);
        cmdAdd.Parameters["@SpentAdd"].Value = txtSpentAdd.Text;
        conn.Open();       
        cmdAdd.ExecuteNonQuery();
        conn.Close();
        reset();
        Response.Redirect("AddAmount.aspx");
        lblMes.Text = "You Have Added a New Row Successfully!";
    }
    private void reset()
    {
        txtAmountFirst.Text = "";
        txtSpentFirst.Text = "";
        chkgr.Checked = false;
    }

    protected void lview1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        TextBox bId = (TextBox)e.Item.FindControl("txtID");
        if (e.CommandName == "Edit")
            Response.Redirect("EditUserBalance.aspx?bId=" + bId.Text);
        else if (e.CommandName == "Delete")
            Response.Redirect("DeleteUserBalance.aspx?bId=" + bId.Text);
        else if (e.CommandName == "Topup")
            Response.Redirect("TopUp.aspx?bId=" + bId.Text);
    }



    protected void btnlist_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("SELECT tblUserBalance.ID, tblUserBalance.TotalAmount,tblUserBalance.TotalSpent,tblUserBalance.Balance, [dbo].[aspnet_Users].UserName From tblUserBalance Inner Join [dbo].[aspnet_Users] On tblUserBalance.UserId = [dbo].[aspnet_Users].UserId where tblUserBalance.UserId=@UserId", conn);
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