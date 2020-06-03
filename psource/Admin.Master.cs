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
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace JECRC_PMall
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{
            //    string cmdText = "select  COUNT(News_Code) as thit from News_Details where PDate='" + DateTime.Now.ToString("yyyyMMdd") + "' and Created_By='" + HttpContext.Current.Session["User_ID"] + "'"; ;
            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            lbl_login_Details.Text =  HttpContext.Current.Session["User_ID"].ToString() + "  News Uploaded: " + dr["thit"].ToString();
            //            lbl_login_Details.Visible = true;
                      
            //        }
            //    }
            //    con.Close();
            //}

            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{
            //    string cmdText = "select  count(page_name) as CountPage from [Visit_Details] where  Visit_Date like '" + DateTime.Now.ToString("yyyyMMdd") + "%'  "; 
            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            lbl_login_Details.Text = lbl_login_Details.Text + "  Visit Today: " + dr["CountPage"].ToString();
                      
            //        }
            //    }
            //    con.Close();
            //}

            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{
            //    string cmdText = "select  count(page_name) as CountPage from [Visit_Details] where  Visit_Date like '" +DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "%'  ";
            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            lbl_login_Details.Text = lbl_login_Details.Text + "  Yesterday: " + dr["CountPage"].ToString();

            //        }
            //    }
            //    con.Close();
            //}


            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{
            //    string cmdText = "select  count(page_name) as CountPage from [Visit_Details] ";
            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            lbl_login_Details.Text = lbl_login_Details.Text + " Total: " + dr["CountPage"].ToString();

            //        }
            //    }
            //    con.Close();
            //}



       /*      <li><a href="NewsDetails.aspx" style="padding-left:30px;padding-right:30px"><span>News</span></a>
          
                <ul>
                          <li><a href="NewsDetails.aspx">News Entry</a> </li>     
                     <li><a href="NewsDetailsApproval.aspx">News Approval</a> </li>  
                     <li><a href="NewsUploading.aspx"> Uploading Summary</a> </li>   
                     <li><a href="NewsUploadingDetails.aspx"> Uploading Details</a> </li> 
                      <li><a href="Pagewise_Visit_Report.aspx">Page Visit</a> </li> 

                                               
                </ul>         
            </li>   */

          
            
            Session["Status"] = "ACTIVE";

            if (HttpContext.Current.Session["User_ID"] == null)
                {
                    Response.Redirect("Login.aspx");

                }

            else
            {

                Session["LActive_Time"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");



            }
          
        }

        protected void change_password_Click(object sender, EventArgs e)
        {



        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["User_ID"] = null;

            Response.Redirect("Login.aspx");

        }
    }
}