using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;


using System.Text;
using System.Windows;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

using System.Net;


namespace JECRC_PMall
{
    public partial class Video_News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IGTMAIN.cmdtextAll = "Select * from Video_News order by Video_News_ID DESC";
            if (!IsPostBack)
            {
                bindDetailsToListView();
                ddl_Status.Items.Add("ACTIVE");
                ddl_Status.Items.Add("INACTIVE");

                
                ddl_IPYTTV.Items.Add("YES");
                ddl_IPYTTV.Items.Add("NO");
                ddl_Viral_Video.Items.Add("NO");
                ddl_Viral_Video.Items.Add("YES");
               



            }

            IGTMAIN.filename = "PM_Video_News_Details";

            IGTMAIN.cmdtextlp = "SELECT  Video_News_URL  as VURL  ,Video_News as News  ,Status  as  Status ,Remarks as  Remarks  FROM Video_News order by Video_News_ID desc";
            IGTMAIN.cmdtextAll = "Select * from Video_News order by Video_News_ID desc";
            IGTMAIN.Title2 = "Video News  Details";
            IGTMAIN.Title3 = "List View";
            IGTMAIN.Title = IGTMAIN.Title1 + "<br/>" + IGTMAIN.Title2 + "<br/>" + IGTMAIN.Title3;



        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (lbl_Message.Text == "Edit Data")
            {


                using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                {

                    string cmdText = "UPDATE Video_News SET Video_News_URL=@Video_News_URL, Video_News_Title = @Video_News_Title,  Video_News_Desc = @Video_News_Desc,  IPYTTV = @IPYTTV, Viral_Video= @Viral_Video, Status=@Status,Remarks=@Remarks WHERE Video_News_ID=@Id";
                    SqlCommand cmd = new SqlCommand(cmdText, con);

                    cmd.Parameters.AddWithValue("@Video_News_URL", txt_Video_News_URL.Text);
                    cmd.Parameters.AddWithValue("@Video_News_Title", txt_Video_News_Title.Text);
                    cmd.Parameters.AddWithValue("@Video_News_Desc", txt_Video_News_Desc.Text);
                    cmd.Parameters.AddWithValue("@IPYTTV", ddl_IPYTTV.Text);
                    cmd.Parameters.AddWithValue("@Viral_Video", ddl_Viral_Video.Text);
                    cmd.Parameters.AddWithValue("@Status", ddl_Status.Text);
                    cmd.Parameters.AddWithValue("@Remarks", txt_Remarks.Text);

                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(hfSelectedRecord.Value));

                    string hostName = Dns.GetHostName(); // Retrive the Name of HOST  

                    string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();


                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                
                upload_images();


                clearInputControls();
                bindDetailsToListView();
                hfSelectedRecord.Value = string.Empty;

                lbl_Message.Text = "Record is Updated Successfully.";

            }
            else
            {
                DataRow[] dr = IGTMAIN.dtlp.Select("Video_News_URL = '" + txt_Video_News_URL.Text + "'"); 
                if (dr.Length == 0)
                {
                    using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                    {

                        string cmdText = "INSERT INTO Video_News (Video_News_URL,Video_News_Title,Video_News_Desc,IPYTTV, Viral_Video, Status,Remarks) VALUES (@Video_News_URL,@Video_News_Title,@Video_News_Desc,@IPYTTV, @Viral_Video, @Status,@Remarks)";
                        SqlCommand cmd = new SqlCommand(cmdText, con);

                        cmd.Parameters.AddWithValue("@Video_News_URL", txt_Video_News_URL.Text);
                        cmd.Parameters.AddWithValue("@Video_News_Title", txt_Video_News_Title.Text);
                        cmd.Parameters.AddWithValue("@Video_News_Desc", txt_Video_News_Desc.Text);
                        cmd.Parameters.AddWithValue("@IPYTTV", ddl_IPYTTV.Text);
                        cmd.Parameters.AddWithValue("@Viral_Video", ddl_Viral_Video.Text);
                        cmd.Parameters.AddWithValue("@Status", ddl_Status.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txt_Remarks.Text);


                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                    clearInputControls();
                    bindDetailsToListView();
                    upload_images();
                    lbl_Message.Text = "New Record is Added Successfully.";
                }
                else
                {

                    string script = "alert(\"Video URL Already Exist.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);


                }
            }

            txt_Video_News_URL.Enabled = true;
           

            btn_Submit.Text = "Submit";



        }

        protected void bindDetailsToListView()
        {
            IGTMAIN.cmdtext = IGTMAIN.cmdtextAll;

            IGTMAIN.GetDataLP();

            lstViewDetails.DataSource = IGTMAIN.dtlp;

            lstViewDetails.DataBind();

        }
        void clearInputControls()
        {
           
            txt_Video_News_URL.Text = string.Empty;
            txt_Video_News_Title.Text = string.Empty;
            txt_Video_News_Desc.Text = string.Empty;
           
            ddl_Status.SelectedIndex = 0;
            txt_Remarks.Text = string.Empty;
        }

        void deleteData(int id)
        {
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string cmdText = "update Video_News set status='INACTIVE', Remarks ='DELETED' where Video_News_ID =@Id ";
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            clearInputControls();
            bindDetailsToListView();
        }
        public void bindDetailToEdit(int id)
        {

            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string cmdText = "SELECT * FROM Video_News where  Video_News_ID=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    

                    txt_Video_News_URL.Text = dr["Video_News_URL"].ToString();
                    txt_Video_News_Title.Text = dr["Video_News_Title"].ToString();
                    txt_Video_News_Desc.Text = dr["Video_News_Desc"].ToString();
                  
                    ddl_IPYTTV.Text = dr["IPYTTV"].ToString();
                    ddl_Viral_Video.Text = dr["Viral_Video"].ToString();



                    ddl_Status.Text = dr["Status"].ToString();
                    txt_Remarks.Text = dr["Remarks"].ToString();
                    txt_Video_News_URL.Enabled = false;
                   

                }
            }
        }
        protected void lstViewDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case ("Del"):
                    int id = Convert.ToInt32(e.CommandArgument);
                    deleteData(id);
                    break;
                case ("Edt"):
                    lbl_Message.Text = "Edit Data";
                    btn_Submit.Text = "Update";
                    id = Convert.ToInt32(e.CommandArgument);
                    bindDetailToEdit(id);
                    hfSelectedRecord.Value = id.ToString();
                    break;
            }
        }
        protected void btn_excel_Click(object sender, ImageClickEventArgs e)
        {
            IGTMAIN.cmdtext = IGTMAIN.cmdtextlp;

            IGTMAIN.GetDataLP();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=" + IGTMAIN.filename + ".xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();

            System.Web.UI.WebControls.GridView dg = new System.Web.UI.WebControls.GridView();
            dg.Caption = IGTMAIN.Title;


            dg.DataSource = IGTMAIN.dtlp;
            dg.DataBind();

            dg.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();




        }

        protected void btn_csv_Click(object sender, ImageClickEventArgs e)
        {
            IGTMAIN.cmdtext = IGTMAIN.cmdtextlp;

            IGTMAIN.GetDataLP();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + IGTMAIN.filename + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";



            StringBuilder sb = new StringBuilder();

            sb.Append(IGTMAIN.Title1);
            sb.Append("\r\n");
            sb.Append(IGTMAIN.Title2);
            sb.Append("\r\n");
            sb.Append(IGTMAIN.Title3);
            sb.Append("\r\n");
            for (int k = 0; k < IGTMAIN.dtlp.Columns.Count; k++)
            {
                //add separator
                sb.Append(IGTMAIN.dtlp.Columns[k].ColumnName + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < IGTMAIN.dtlp.Rows.Count; i++)
            {
                for (int k = 0; k < IGTMAIN.dtlp.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(IGTMAIN.dtlp.Rows[i][k].ToString().Replace(",", ";") + ',');
                }
                //append new line
                sb.Append("\r\n");
            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btn_word_Click(object sender, ImageClickEventArgs e)
        {
            IGTMAIN.cmdtext = IGTMAIN.cmdtextlp;

            IGTMAIN.GetDataLP();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + IGTMAIN.filename + ".doc");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.word";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            System.Web.UI.WebControls.GridView dg = new System.Web.UI.WebControls.GridView();
            dg.Caption = IGTMAIN.Title;
            dg.DataSource = IGTMAIN.dtlp;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }

        protected void btn_adobe_Click(object sender, ImageClickEventArgs e)
        {
            //IGTMAIN.cmdtext = IGTMAIN.cmdtextlp;

            //IGTMAIN.GetDataLP();


            ////Create a dummy GridView
            //System.Web.UI.WebControls.GridView dg = new System.Web.UI.WebControls.GridView();

            //System.Web.UI.WebControls.GridView dg = new System.Web.UI.WebControls.GridView();
            //dg.Caption = IGTMAIN.Title;


            //dg.DataSource = IGTMAIN.dtlp;
            //dg.DataBind();


            //dg.AllowPaging = false;


            //lbl_Message.Text = dg.Rows.Count.ToString();


            //Page.Response.ContentType = "application/pdf";
            //Page.Response.AddHeader("content-disposition", "attachment;filename=" + IGTMAIN.filename + ".pdf");


            //Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //StringWriter sw = new StringWriter();

            //HtmlTextWriter hw = new HtmlTextWriter(sw);

            //dg.AllowPaging = false;

            //HtmlForm frm = new HtmlForm();

            //dg.Parent.Controls.Add(frm);

            //frm.Attributes["runat"] = "server";

            //frm.Controls.Add(dg);

            //frm.RenderControl(hw);

            //dg.DataBind();

            //StringReader sr = new StringReader(sw.ToString());

            //iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 0f);

            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            //PdfWriter.GetInstance(pdfDoc, Page.Response.OutputStream);

            //pdfDoc.Open();

            //htmlparser.Parse(sr);

            //pdfDoc.Close();

            //Page.Response.Write(pdfDoc);

            //Page.Response.End(); 

        }

         protected void upload_images(){
             if (fileuploadTitle.HasFile == false)
             {
                 ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('No File Uploaded.')</script>", false);
                 lbl_Message.Text = "No Title Images  are available to Upload. ";
             }
             else
             {

                 string ext = System.IO.Path.GetExtension(fileuploadTitle.PostedFile.FileName);

                 if (ext==".jpg")
                 { 

                 string vurl = txt_Video_News_URL.Text;
                 string[] _avurl = vurl.Split('/');
                 vurl = _avurl[_avurl.Length - 1];

                 var fileName = fileuploadTitle.PostedFile.FileName;
             
                string ImageCode = "";

                ImageCode = vurl;
                    string[] imagename = ImageCode.Split('/');
                    string filename = Path.GetFileName(fileName);
                    string[] fileex = filename.Split('.');
                    ImageCode = ImageCode + "." + fileex[fileex.Length - 1];
                 
                    //Code Saving only File
                    fileuploadTitle.SaveAs(Server.MapPath("/VImages/" + ImageCode));

                 }

                 else
                 {
                     ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('Upload Only .jpg file for  Title Images. Pls Upload Again in .jpg format.')</script>", false);
                     lbl_Message.Text = "Upload Only .jpg file for  Title Images.  Pls Upload Again in .jpg format. ";
                 }



             }
         }
    }

}