﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyEvent : System.Web.UI.Page
{
    String uName;
    protected void Page_Load(object sender, EventArgs e)
    {
        MembershipUser currentUser = Membership.GetUser();
        uName = currentUser.UserName;

        if (!IsPostBack)
        {
            PopulateData();
        }
    }

    protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lview1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.PopulateData();
    }

    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        TextBox tId = (TextBox)e.Item.FindControl("txtId");
        //Response.Redirect("proDetail.aspx?pid=" + tId.Text);
        if (e.CommandName == "Details")
            Response.Redirect("Detail.aspx?eid=" + tId.Text);
        else if (e.CommandName == "Buy")
            Response.Redirect("Buy.aspx?eid=" + tId.Text);
        else if (e.CommandName == "editImage")
            Response.Redirect("EditImageUser.aspx?eid=" + tId.Text);
        else
            Response.Redirect("EditInfoUser.aspx?eid=" + tId.Text);
    }

    private void PopulateData()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        SqlCommand cmdPT = new SqlCommand("SELECT [EventID],[EventName],[Douration],[DateStart],[DateEnd],[Price],[Place],[ImageURL] FROM [dbo].[tblKhmerEvent] where userName=@cUser and QTY>0", conn);
        cmdPT.Parameters.Add("@cUser", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@cUser"].Value = uName;

        //conn.Open();

        using (SqlDataAdapter sda = new SqlDataAdapter(cmdPT))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lview1.DataSource = dt;
            lview1.DataBind();
        }

        //conn.Close();
    }
}