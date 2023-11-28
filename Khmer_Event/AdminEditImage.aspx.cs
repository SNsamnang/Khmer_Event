using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminEditImage : System.Web.UI.Page
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

        if (!IsPostBack)
        {
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
            txtEventID.Text = eId;
        }
    }

    protected void cmdEditImg_Click(object sender, EventArgs e)
    {
        if (fmImg.HasFile)
        {
            String imgName = fmImg.FileName;
            fmImg.SaveAs(Server.MapPath("~\\Image") + "/" + fmImg.FileName);

            SqlCommand cmd = new SqlCommand("Update tblKhmerEvent Set ImageURL=@ImgUrl " +
                "Where EventID=@eventId", conn);

            cmd.Parameters.Add("@eventId", System.Data.SqlDbType.Int);
            cmd.Parameters["@eventId"].Value = txtEventID.Text;
            cmd.Parameters.Add("@ImgUrl", System.Data.SqlDbType.NVarChar);
            cmd.Parameters["@ImgUrl"].Value = "Image/" + imgName;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            imgUpdate();
        }
    }
    private void imgUpdate()
    {
        SqlCommand cmdPT = new SqlCommand("Select EventID, ImageURL From tblKhmerEvent Where EventID=@eventId", conn);
        cmdPT.Parameters.Add("@eventId", System.Data.SqlDbType.Int);
        cmdPT.Parameters["@eventId"].Value = txtEventID.Text;
        SqlDataReader rd;
        conn.Open();
        rd = cmdPT.ExecuteReader();
        lview1.DataSource = rd;
        lview1.DataBind();
        rd.Close();
        conn.Close();
    }
}