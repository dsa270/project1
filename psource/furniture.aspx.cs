using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace JECRC_PMall
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ELECTRONICS
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string _innerhtml = "";

                _innerhtml = "<a style =\"color: black;padding-top:5px; padding-bottom:0px;padding-left:10px;line-height:140%; line-height:140%;font-size:24px; font-weight: bold;\" href=\"#\">CHAIR</a> <hr style=\"height: 0;	margin-top: 0;	margin-bottom: 5px;	border: 0;	border-top: 5px solid #000000;;\"/>";
                string cmdText = "SELECT TOP 8  * FROM product where product_status='ACTIVE' and product_Sub_category_code ='CHAIR'  order by  product_id DESC";

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

                        _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;min-height: 250px;border: 5px solid white; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["product_code"].ToString() + ".aspx\" title =\"" + dr["product_code"].ToString() + "\" target=\"_blank\"> <img src=\"pimages/" + ImageName + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["product_name"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["product_name"].ToString() + " </h4> </a></div> </div>";
                    }
                }

                CHAIR.InnerHtml = _innerhtml;
            }
            //END OF ELECTRONICS






            //ELECTRONICS
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string _innerhtml = "";

                _innerhtml = "<a style =\"color: black;padding-top:5px; padding-bottom:0px;padding-left:10px;line-height:140%; line-height:140%;font-size:24px; font-weight: bold;\" href=\"#\">SOFA SET</a> <hr style=\"height: 0;	margin-top: 0;	margin-bottom: 5px;	border: 0;	border-top: 5px solid #000000;;\"/>";
                string cmdText = "SELECT TOP 8  * FROM product where product_status='ACTIVE' and product_Sub_category_code ='SOFA-SET'  order by  product_id DESC";

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

                        _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;max-height: 400px; min-height:400px;max-width100%;border: 5px solid white; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["product_code"].ToString() + ".aspx\" title =\"" + dr["product_code"].ToString() + "\" target=\"_blank\"> <img src=\"pimages/" + ImageName + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["product_name"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["product_name"].ToString() + " </h4> </a></div> </div>";
                    }
                }

                SOFA_SET.InnerHtml = _innerhtml;
            }
            //END OF ELECTRONICS





            //ELECTRONICS
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string _innerhtml = "";

                _innerhtml = "<a style =\"color: black;padding-top:5px; padding-bottom:0px;padding-left:10px;line-height:140%; line-height:140%;font-size:24px; font-weight: bold;\" href=\"#\">WARDROBE</a> <hr style=\"height: 0;	margin-top: 0;	margin-bottom: 5px;	border: 0;	border-top: 5px solid #000000;;\"/>";
                string cmdText = "SELECT TOP 8  * FROM product where product_status='ACTIVE' and product_Sub_category_code ='WARDROBE'  order by  product_id DESC";

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

                        _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;max-height: 400px; min-height:400px;max-width100%;border: 5px solid white; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["product_code"].ToString() + ".aspx\" title =\"" + dr["product_code"].ToString() + "\" target=\"_blank\"> <img src=\"pimages/" + ImageName + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["product_name"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["product_name"].ToString() + " </h4> </a></div> </div>";
                    }
                }

                WARDROBE.InnerHtml = _innerhtml;
            }
            //END OF ELECTRONICS














            //ELECTRONICS
            using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
            {
                string _innerhtml = "";

                _innerhtml = "<a style =\"color: black;padding-top:5px; padding-bottom:0px;padding-left:10px;line-height:140%; line-height:140%;font-size:24px; font-weight: bold;\" href=\"#\">BED</a> <hr style=\"height: 0;	margin-top: 0;	margin-bottom: 5px;	border: 0;	border-top: 5px solid #000000;;\"/>";
                string cmdText = "SELECT TOP 8  * FROM product where product_status='ACTIVE' and product_Sub_category_code ='BED'  order by  product_id DESC";

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

                        _innerhtml = _innerhtml + "<div class=\"col-sm-3\" style=\"line-height:140%;max-height: 400px; min-height:400px;max-width100%;border: 5px solid white; background-color:white;\"> <div style=\"vertical-align:top; margin-top:0px; \"> <a href=\"" + dr["product_code"].ToString() + ".aspx\" title =\"" + dr["product_code"].ToString() + "\" target=\"_blank\"> <img src=\"pimages/" + ImageName + "\"CssClass=\"img-responsive\" style =\"max-width:300px; max-height:250px; text-align:center;vertical-align:top; \" alt=\"" + dr["product_name"].ToString() + "\"> <br/>  <h4 style=\"color:black; line-height:140%;font-size:16px; font-weight: bold;font-family: \"Mangal\"; display:inline-block; padding:0px; left-padding:5px;\"> " + dr["product_name"].ToString() + " </h4> </a></div> </div>";
                    }
                }

                BED.InnerHtml = _innerhtml;
            }
            //END OF ELECTRONICS

        }
    }
}