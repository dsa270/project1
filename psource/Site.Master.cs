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
using System.Web.Script.Serialization;



namespace JECRC_PMall
{

    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public string[] breakingnews = new string[9];
        public int breakingnewsno = -1;
        public string _livenews = "";

        public string[] _artrendingnews = new string[10];

        protected void Page_Load(object sender, EventArgs e)
        {

            //string _innerhtmlB = string.Empty;


            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{

            //    string cmdText = "INSERT INTO Web_Portal (Device_Type ,Page_Name ,Visit_Date,Visit_IP,Visit_MAC ,Remarks) VALUES (@Device_Type ,@Page_Name ,@Visit_Date ,@Visit_IP ,@Visit_MAC,@Remarks)";
            //    SqlCommand cmd = new SqlCommand(cmdText, con);

            //    cmd.Parameters.AddWithValue("@Device_Type", IGTMAIN.IsMobileBrowser().ToString());
            //    cmd.Parameters.AddWithValue("@Page_Name", Page.AppRelativeVirtualPath.ToString());
            //    cmd.Parameters.AddWithValue("@Visit_Date", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //    cmd.Parameters.AddWithValue("@Visit_IP", IGTMAIN.GetIpAddress().ToString());
            //    cmd.Parameters.AddWithValue("@Visit_MAC", IGTMAIN.GetMacAddress().ToString());
            //    cmd.Parameters.AddWithValue("@Remarks", "OK");
            //     con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //}

            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{

            //    int i = 0;

            //    string cmdText = "SELECT TOP 9  * FROM News_Details where Status='ACTIVE' and Is_Breaking ='YES'  order by  PDate DESC,Priority, Modified_Date desc";;
            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            string title = dr["Title"].ToString().Replace("<br/>", "");

            //            breakingnews[i] = " <a href=\"" + dr["link_name"].ToString() + ".aspx\" title =\"" + title + "\" target=\"_blank\"   style=\"color:white;padding-left: 10px; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; \">" + dr["Title"].ToString() + " </a>";
            //            i++;
            //        }

            //    }
            //    con.Close();
            //}


            //div_breaking.InnerHtml = breakingnews[0];
            //breakingnewsno = 0;
            ////8b0101
            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{

            //    _innerhtmlB = " <p style=\"color:white; line-height:120%;font-size:24px; font-weight: bold;font-family: Mangal; text-align:center;\">  LIVE NEWS</p><hr style=\"height: 0; margin-top: 0px; margin-bottom: 0px; border: 0; border-top: 3px solid #ffffff;\"/> <marquee  direction=\"up\" scrollamount=\"3\"  onmouseover=\"this.stop();\" onmouseout=\"this.start();\"  style=\" height: 300px; margin-top: 0px; \" > ";
            //    int i = 0;

            //    string cmdText = "SELECT TOP 20 * FROM News_Details where Status='ACTIVE' and Is_Breaking ='YES'  order by  PDate DESC,Priority, Modified_Date desc";;
            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            string title = dr["Title"].ToString().Replace("<br/>", "");

            //            _innerhtmlB = _innerhtmlB + " <a href=\"" + dr["link_name"].ToString() + ".aspx\" title =\"" + title + "\" target=\"_blank\"   style=\"color:white;font-size:14px; font-weight: bold;font-family: \"Mangal\";  \">" + dr["Title"].ToString() + " </a> <hr style=\"height: 0; margin-top: 5px; margin-bottom: 5px; border: 0; border-top: 1px solid #333333;\"/>";
            //            i++;
            //        }

            //    }
            //    con.Close();
            //}

            //_innerhtmlB = _innerhtmlB + "</marquee>";
            //LiveNews.InnerHtml = _innerhtmlB;


            //////getting trending news
            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{
            //    string cmdText = "select  distinct page_name, count(page_name) as CountPage from [Visit_Details] where page_name like '%-%' group by page_name order by CountPage desc";

            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    int tnno = 0;
            //    while (dr.Read())
            //    {
            //        _artrendingnews[tnno] = dr["page_name"].ToString();
            //        tnno++;
            //        if (tnno == 10) break;

            //    }
            //    con.Close();
            //}


            //_innerhtmlB = " <p style=\"color:white; line-height:120%;font-size:24px; font-weight: bold;font-family: Mangal; text-align:center;\">  Trending News</p><hr style=\"height: 0; margin-top: 0px; margin-bottom: 0px; border: 0; border-top: 3px solid #ffffff;\"/> <marquee  direction=\"up\" scrollamount=\"3\"  onmouseover=\"this.stop();\" onmouseout=\"this.start();\"  style=\" height: 300px; margin-top: 0px; \" > ";
            //string s = "";
            //for (int i = 0; i < _artrendingnews.Length; i++)
            //{
            //    s = s + _artrendingnews[i];

            //    ////  if (j == null) break;
            //    string lj = _artrendingnews[i].ToString();

            //    string[] topic_name = lj.Split('/');
            //    string _topic_name = topic_name[topic_name.Length - 1];
            //    _topic_name = _topic_name.Substring(0, _topic_name.Length - 5);

            //    using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //    {

            //        string cmdText = "SELECT  *  FROM News_Details where  link_name like '%" + _topic_name + "'"; ;
            //        SqlCommand cmd = new SqlCommand(cmdText, con);
            //        con.Open();
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            string title = dr["Title"].ToString().Replace("<br/>", "");
            //            string linkM = "~/" + dr["link_name"].ToString() + ".aspx";

            //            //search the destination ID
            //            if (lj == linkM)
            //            {
            //                _innerhtmlB = _innerhtmlB + " <a href=\"" + dr["link_name"].ToString() + ".aspx\" title =\"" + title + "\" target=\"_blank\"   style=\"color:white;font-size:14px; font-weight: bold;font-family: \"Mangal\";  \">" + dr["Title"].ToString() + " </a> <hr style=\"height: 0; margin-top: 5px; margin-bottom: 5px; border: 0; border-top: 1px solid #333333;\"/>";
            //                // i++;
            //            }
            //        }
            //        con.Close();
            //    }
                


            //}
            //_innerhtmlB = _innerhtmlB + "</marquee>";
            //TrendingNews.InnerHtml = _innerhtmlB;

            //using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            //{
            //    _innerhtmlB = "";
            //    string cmdText = "  SELECT top 1  Video_News_URL FROM Video_News order by Video_News_ID desc"; ;
            //    SqlCommand cmd = new SqlCommand(cmdText, con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {

            //        string vurl = dr["Video_News_URL"].ToString();
            //        string[] _avurl = vurl.Split('/');
            //        vurl = _avurl[_avurl.Length - 1];

            //        _innerhtmlB = "<div class=\"video-responsive\" style=\"border: 5px solid black;background-color:black; color:black; \"> <iframe src=\"https://www.youtube.com/embed/" + vurl + "\" frameborder=\"0\" ></iframe>  </div>";
            //    }
            //    con.Close();
            //}
            //ipyttv.InnerHtml = _innerhtmlB;


        }


    }

}



















