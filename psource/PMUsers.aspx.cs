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
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

using System.Windows;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

using System.Net;






namespace JECRC_PMall
{
    public partial class PMUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IGTMAIN.cmdtextAll = "Select * from User_Details ";
            if (!IsPostBack)
            {
                bindDetailsToListView();
                ddl_Status.Items.Add("ACTIVE");
                ddl_Status.Items.Add("INACTIVE");
                
                  //  txt_User_pass.PasswordChar = '*';
                string selcectstatementNC = "SELECT * FROM User_Type ORDER BY User_Type_Code desc";

                SqlDataAdapter daNC = new SqlDataAdapter(selcectstatementNC, IGTMAIN.CS);
                DataTable dtNC = new DataTable();
                daNC.Fill(dtNC);
                ddl_User_Type.DataSource = dtNC;
                ddl_User_Type.DataTextField = "User_Type_Name";
                ddl_User_Type.DataValueField = "User_Type_Code";
                ddl_User_Type.DataBind();



            }

            IGTMAIN.filename = "PM_User_Details";

            IGTMAIN.cmdtextlp = "Select  User_Type as Type , User_Status, User_Code as Code, User_Name as Name, User_pass as Password,User_Email as Email,User_Phno as Phno from User_Details order by User_Type,User_Name ";
            IGTMAIN.cmdtextAll = "Select * from User_Details order by User_Type,User_Name";
            IGTMAIN.Title2 = "User  Details";
            IGTMAIN.Title3 = "List View";
            IGTMAIN.Title = IGTMAIN.Title1 + "<br/>" + IGTMAIN.Title2 + "<br/>" + IGTMAIN.Title3;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (lbl_Message.Text == "Edit Data")
            {
                using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                   {
                       string cmdText = "UPDATE User_Details SET User_Type=@User_Type, User_Status = @User_Status, User_pass = @User_pass ,User_Name=@User_Name, User_Email=@User_Email,User_Phno=@User_Phno WHERE User_ID=@Id";

                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    cmd.Parameters.AddWithValue("@User_Type", ddl_User_Type.Text);
                    cmd.Parameters.AddWithValue("@User_Status", ddl_Status.Text);
                    cmd.Parameters.AddWithValue("@User_Code", txt_User_Code.Text);
                    cmd.Parameters.AddWithValue("@User_pass", IGTMAIN.Encryptdata(txt_User_pass.Text));
                    cmd.Parameters.AddWithValue("@User_Name", txt_User_Name.Text);
                    cmd.Parameters.AddWithValue("@User_Email", txt_User_Email.Text);
                    cmd.Parameters.AddWithValue("@User_Phno", txt_User_Phno.Text);                 
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(hfSelectedRecord.Value));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                clearInputControls();
                bindDetailsToListView();
                hfSelectedRecord.Value = string.Empty;
                lbl_Message.Text = "Record is Updated Successfully.";

            }
            else
            {
                DataRow[] dr = IGTMAIN.dtlp.Select("User_Code = '" + txt_User_Code.Text + "'");
                if (dr.Length == 0)
                {
                    using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                    {
                        string cmdText = "INSERT INTO User_Details (User_Type, User_Status, User_Code,User_Name,User_pass,User_Email,User_Phno) VALUES (@User_Type, @User_Status, @User_Code,@User_Name,@User_pass,@User_Email,@User_Phno)";
                        SqlCommand cmd = new SqlCommand(cmdText, con);
                        cmd.Parameters.AddWithValue("@User_Type", ddl_User_Type.Text);
                        cmd.Parameters.AddWithValue("@User_Status", ddl_Status.Text);
                        cmd.Parameters.AddWithValue("@User_Code", txt_User_Email.Text);
                        cmd.Parameters.AddWithValue("@User_pass", IGTMAIN.Encryptdata(txt_User_pass.Text)); 
                        cmd.Parameters.AddWithValue("@User_Name", txt_User_Name.Text);
                        cmd.Parameters.AddWithValue("@User_Email", txt_User_Email.Text);
                        cmd.Parameters.AddWithValue("@User_Phno", txt_User_Phno.Text);
                        con.Open(); 
                        cmd.ExecuteNonQuery();
                    }
                    clearInputControls();
                    bindDetailsToListView();
                    lbl_Message.Text = "New Record is Added Successfully.";
                }
                else
                {
                    string  script = "alert(\"User Already Exist.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }       
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

            ddl_User_Type.SelectedIndex = 0;
ddl_Status.SelectedIndex = 0;
txt_User_Code.Text= string.Empty;
txt_User_Name.Text= string.Empty;
txt_User_pass.Text= string.Empty;
txt_User_Email.Text= string.Empty;
txt_User_Phno.Text= string.Empty;

        }

        void deleteData(int id)
        {
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string cmdText = "update User_Details set User_Status='INACTIVE', User_Remarks1 ='DELETED' where User_ID =@Id ";
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
                string cmdText = "SELECT * FROM User_Details where  User_ID=@Id";
               SqlCommand cmd = new SqlCommand(cmdText, con);
               cmd.Parameters.AddWithValue("@Id", id);
               con.Open();
               SqlDataReader dr = cmd.ExecuteReader();

               if (dr.HasRows)
               {
                   dr.Read();
                  

                   ddl_User_Type.Text = dr["User_Type"].ToString();
                   ddl_Status.Text = dr["User_Status"].ToString();
                   txt_User_Code.Text = dr["User_Code"].ToString();
                  txt_User_pass.Attributes.Add("value", IGTMAIN.Decryptdata(dr["User_pass"].ToString()));
                   txt_User_Name.Text = dr["User_Name"].ToString();
                   txt_User_Email.Text = dr["User_Email"].ToString();
                   txt_User_Phno.Text = dr["User_Phno"].ToString();

              
                 
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
      


    }
}