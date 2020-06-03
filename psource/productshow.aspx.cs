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
    public partial class productshow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string product_code = "APPLE IPHONE 7 (SILVER, 32 GB)";



            using (SqlConnection con = new SqlConnection(Ritika.CS))
            {


                string cmdText = "SELECT Product_Category_code,product_Sub_category_code,product_code,product_name,product_price,product_offer,product_highlights,product_description,product_warranty,product_status  FROM PRODUCT where product_code= @product_code";


                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@product_code", product_code);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    txt_pc_code.Text = dr["Product_Category_code"].ToString();


                    txt_P_Code.Text = dr["product_code"].ToString();
                    txt_P_Name.Text = dr["product_name"].ToString();
                    txt_P_price.Text = dr["product_price"].ToString();
                    txt_P_offer.Text = dr["product_offer"].ToString();
                    txt_P_highlights.Text = dr["product_highlights"].ToString();
                    txt_P_description.Text = dr["product_description"].ToString();
                    txt_P_warranty.Text = dr["product_warranty"].ToString();
                  
                    txt_P_Status.Text = dr["product_status"].ToString();
                    txt_PsC_code.Text = dr["product_Sub_category_code"].ToString();




                }


            }
        }
    }
}