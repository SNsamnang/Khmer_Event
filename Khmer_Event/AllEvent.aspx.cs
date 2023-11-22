using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AllEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        TextBox tId = (TextBox)e.Item.FindControl("txtId");
        //Response.Redirect("proDetail.aspx?pid=" + tId.Text);
        if (e.CommandName == "Details")
            Response.Redirect("Detail.aspx?eid=" + tId.Text);
    }
}