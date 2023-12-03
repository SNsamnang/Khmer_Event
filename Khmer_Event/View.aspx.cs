using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.tool.xml;
using GemBox.Document;
using iTextSharp.text.html.simpleparser;
using System.Windows.Forms;
using System.Data;

public partial class View : System.Web.UI.Page
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateData();
            showImage();
        }
    }

    //protected void btnConvert_Click(object sender, EventArgs e)
    //{
    //     Response.ContentType = "application/pdf";
    //        Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
    //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        StringWriter sw = new StringWriter();
    //        HtmlTextWriter hw = new HtmlTextWriter(sw);
    //        this.Page.RenderControl(hw);
    //        StringReader sr = new StringReader(sw.ToString());
    //        Document pdfDoc = new Document(PageSize.A6);
    //        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //        pdfDoc.Open();
    //        htmlparser.Parse(sr);
    //        pdfDoc.Close();
    //        Response.Write(pdfDoc);
    //        Response.End();
    //}

    private void PopulateData()
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        string eId = Request.QueryString.Get("eid");
        SqlCommand cmdPT = new SqlCommand("SELECT * FROM tblTicket Where TicketID=@TicketID and Status='DONE'", conn);
        cmdPT.Parameters.Add("@TicketID", System.Data.SqlDbType.Int);
        cmdPT.Parameters["@TicketID"].Value = eId;
        SqlDataReader rd;
        conn.Open();
        rd = cmdPT.ExecuteReader();
        if (rd.Read() == true)
        {
            txtEventName.Text = rd[1].ToString();
            txtDouration.Text = rd[2].ToString();
            txtDateStart.Text = rd[3].ToString();
            txtDateEnd.Text = rd[4].ToString();
            txtPlace.Text = rd[5].ToString();
            txtUsername.Text = rd[7].ToString();
            txtContact.Text = rd[6].ToString();
            txtPrice.Text = rd[8].ToString();
            txtQTY.Text = rd[10].ToString();
            txtCurrentUser.Text = rd[11].ToString();
            txtContactUser.Text = rd[9].ToString();
            txtTotalPrice.Text = "$"+rd[12].ToString();
            
        }
        rd.Close();
        conn.Close();
    }
    private void showImage()
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        string eventname = txtEventName.Text;
        SqlCommand cmdPT = new SqlCommand("SELECT top 1 ImageURL FROM tblKhmerEvent Where EventName=@EventName", conn);
        cmdPT.Parameters.Add("@EventName", System.Data.SqlDbType.NVarChar);
        cmdPT.Parameters["@EventName"].Value = eventname;
        using (SqlDataAdapter sda = new SqlDataAdapter(cmdPT))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }

}