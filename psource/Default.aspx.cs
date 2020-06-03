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
    public partial class _Default : System.Web.UI.Page
    {
        string templatetype = string.Empty;
        string[] mainnews = new string[6];
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //ELECTRONICS
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string _innerhtml ="";

                _innerhtml = "<a style =\"color: black;padding-top:5px; padding-bottom:0px;padding-left:10px;line-height:140%; line-height:140%;font-size:24px; font-weight: bold;\" href=\"electronics.aspx\">ELECTRONICS</a> <hr style=\"height: 0;	margin-top: 0;	margin-bottom: 5px;	border: 0;	border-top: 5px solid #000000;;\"/>";
                string cmdText = "SELECT TOP 8  * FROM product where product_status='ACTIVE' and product_category_code ='ELECTRONICS'  order by  product_id DESC";

                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();
             

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        string productcode = dr["product_code"].ToString();
                        string ImageName = productcode.Trim() +"1.jpeg";
                        string price = dr["product_price"].ToString();
                        string offer = dr["product_offer"].ToString();

                    
             //       _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;min-height: 250px;border: 5px solid white; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["link_name"].ToString() + ".aspx\" title =\"" + dr["Title"].ToString() + "\" target=\"_blank\"> <img src=\"newsImages/" + fimage + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["Title"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["Title"].ToString() + " </h4> </a></div> </div>";

                        _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;max-height: 400px; min-height:400px;max-width100%;border: 5px solid #f2f2f2; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["product_code"].ToString() + ".aspx\" title =\"" + dr["product_code"].ToString() + "\" target=\"_blank\"> <img src=\"pimages/" + ImageName + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["product_name"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["product_name"].ToString() + " </h4> </a></div> </div>";
                    }
                }
                
                ELECTRONICS.InnerHtml = _innerhtml;
            }
            //END OF ELECTRONICS

            //CLOTHES
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string _innerhtml = "";

                _innerhtml = "<a style =\"color: black;padding-top:5px; padding-bottom:0px;padding-left:10px;line-height:140%; line-height:140%;font-size:24px; font-weight: bold;\" href=\"clothes.aspx\">CLOTHES</a> <hr style=\"height: 0;	margin-top: 0;	margin-bottom: 5px;	border: 0;	border-top: 5px solid #000000;;\"/>";
                string cmdText = "SELECT TOP 8  * FROM product where product_status='ACTIVE' and product_category_code ='CLOTHES'  order by  product_id DESC";

                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        string productcode = dr["product_code"].ToString();
                        string ImageName = productcode.Trim() + "1.jpeg";
                        string price = dr["product_price"].ToString();
                        string offer = dr["product_offer"].ToString();


                        //       _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;min-height: 250px;border: 5px solid white; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["link_name"].ToString() + ".aspx\" title =\"" + dr["Title"].ToString() + "\" target=\"_blank\"> <img src=\"newsImages/" + fimage + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["Title"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["Title"].ToString() + " </h4> </a></div> </div>";

                        _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;max-height: 400px; min-height:400px;max-width100%;border: 5px solid #f2f2f2; background-color:white;\"><div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["product_code"].ToString() + ".aspx\" title =\"" + dr["product_code"].ToString() + "\" target=\"_blank\"> <img src=\"pimages/" + ImageName + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["product_name"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["product_name"].ToString() + " </h4> </a></div> </div>";
                    }
                }

                CLOTHES.InnerHtml = _innerhtml;
            }
            //END OF CLOTHES






            //BOOKS
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string _innerhtml = "";

                _innerhtml = "<a style =\"color: black;padding-top:5px; padding-bottom:0px;padding-left:10px;line-height:140%; line-height:140%;font-size:24px; font-weight: bold;\" href=\"books.aspx\">BOOKS</a> <hr style=\"height: 0;	margin-top: 0;	margin-bottom: 5px;	border: 0;	border-top: 5px solid #000000;;\"/>";
                string cmdText = "SELECT TOP 8  * FROM product where product_status='ACTIVE' and product_category_code ='BOOKS'  order by  product_id DESC";

                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        string productcode = dr["product_code"].ToString();
                        string ImageName = productcode.Trim() + "1.jpeg";
                        string price = dr["product_price"].ToString();
                        string offer = dr["product_offer"].ToString();


                        //       _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;min-height: 250px;border: 5px solid white; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["link_name"].ToString() + ".aspx\" title =\"" + dr["Title"].ToString() + "\" target=\"_blank\"> <img src=\"newsImages/" + fimage + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["Title"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["Title"].ToString() + " </h4> </a></div> </div>";

                        _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;max-height: 400px; min-height:400px;max-width100%;border: 5px solid #f2f2f2; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["product_code"].ToString() + ".aspx\" title =\"" + dr["product_code"].ToString() + "\" target=\"_blank\"> <img src=\"pimages/" + ImageName + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["product_name"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["product_name"].ToString() + " </h4> </a></div> </div>";
                    }
                }

                BOOKS.InnerHtml = _innerhtml;
            }
            //END OF BOOKS







            //FURNITURE
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string _innerhtml = "";

                _innerhtml = "<a style =\"color: black;padding-top:5px; padding-bottom:0px;padding-left:10px;line-height:140%; line-height:140%;font-size:24px; font-weight: bold;\" href=\"furniture.aspx\">FURNITURE</a> <hr style=\"height: 0;	margin-top: 0;	margin-bottom: 5px;	border: 0;	border-top: 5px solid #000000;;\"/>";
                string cmdText = "SELECT TOP 8  * FROM product where product_status='ACTIVE' and product_category_code ='FURNITURE'  order by  product_id DESC";

                SqlCommand cmd = new SqlCommand(cmdText, con);
                con.Open();


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        string productcode = dr["product_code"].ToString();
                        string ImageName = productcode.Trim() + "1.jpeg";
                        string price = dr["product_price"].ToString();
                        string offer = dr["product_offer"].ToString();


                        //       _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;min-height: 250px;border: 5px solid white; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["link_name"].ToString() + ".aspx\" title =\"" + dr["Title"].ToString() + "\" target=\"_blank\"> <img src=\"newsImages/" + fimage + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["Title"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["Title"].ToString() + " </h4> </a></div> </div>";

                        _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;max-height: 400px; min-height:400px;max-width100%;border: 5px solid #f2f2f2; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["product_code"].ToString() + ".aspx\" title =\"" + dr["product_code"].ToString() + "\" target=\"_blank\"> <img src=\"pimages/" + ImageName + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["product_name"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["product_name"].ToString() + " </h4> </a></div> </div>";
                    }
                }

                FURNITURE.InnerHtml = _innerhtml;
            }
            //END OF FURNITURE
       
                }


                //lowerblock

            }
        }


    


