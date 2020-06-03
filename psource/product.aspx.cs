using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace JECRC_PMall
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_P_Status.Items.Add("ACTIVE");
                ddl_P_Status.Items.Add("INACTIVE");

                string selcectProduct_Category = "SELECT   product_category_code FROM PRODUCT_category where product_category_status='ACTIVE' order by product_category_code";

                SqlDataAdapter daPC_Code = new SqlDataAdapter(selcectProduct_Category, Ritika.CS);
                DataTable dtPC_Code = new DataTable();
                daPC_Code.Fill(dtPC_Code);

                ddl_pc_code.DataSource = dtPC_Code;
                ddl_pc_code.DataTextField = "product_category_code";
                ddl_pc_code.DataValueField = "product_category_code";
                ddl_pc_code.DataBind();

                //ddl_pc_code.SelectedIndex = 0;
               // ddl_pc_code_SelectedIndexChanged(sender, e);
                //  txt_PC_Code.Visible = false;

            //    string selcectsubProduct_Category = "SELECT   product_Sub_category_code FROM PRODUCT_Sub_CATEGORY where product_category_code ='" + ddl_pc_code.Text + "' and product_Sub_category_status='ACTIVE' order by product_Sub_category_code";

            // SqlDataAdapter daPsC_Code = new SqlDataAdapter(selcectsubProduct_Category, Ritika.CS);
            //DataTable dtPsC_Code = new DataTable();
            //daPsC_Code.Fill(dtPsC_Code);
           
            //ddl_PsC_code.DataSource = dtPsC_Code;
            //ddl_PsC_code.DataTextField = "product_Sub_category_code";
            //ddl_PsC_code.DataValueField = "product_Sub_category_code";
            //ddl_PsC_code.DataBind();

            ddl_pc_code.SelectedIndex = 0;
           

                
                
                
            }
        }



        protected void clearscreen()
        {
            txt_P_Code.Enabled = true;
            txt_P_Code.Text = "";
            txt_P_description.Text = "";
            txt_P_EDate.Text = "";
            txt_P_highlights.Text = "";
            txt_P_Name.Text = "";
            txt_P_offer.Text = "";
            txt_P_price.Text = "";
            txt_P_SDate.Text = "";
            txt_P_warranty.Text = "";

            btn_Upload.Enabled = true;
            fileuploadimages.Enabled = true;
            fileuploadTitle.Enabled = true;
             

        }
        //protected void btn_add_Click(object sender, EventArgs e)
        //{
        //    //loop of connection
        //    using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
        //    {
        //        //Command to be executed on Sql Server 
        //        //values will be in the form of variable
        //        string cmdText = "INSERT INTO product (product_code,product_name,product_price,product_offer,product_highlights,product_description,product_warranty,product_start_date,product_end_date ,product_status) VALUES (@product_code,@product_name,@product_price,@product_offer,@product_highlights,@product_description,@product_warranty,@product_start_date,@product_end_date ,@product_status)";
        //        //establish connection with DB
        //        SqlCommand cmd = new SqlCommand(cmdText, con);
        //        //taking Argument value of cmdText from different tools like textbox, ddl etc

        //        cmd.Parameters.AddWithValue("@product_code", txt_P_Code.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@product_name", txt_P_Name.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@product_price", Convert.ToInt16(txt_P_price.Text));
        //        cmd.Parameters.AddWithValue("@product_offer", Convert.ToInt16(txt_P_offer.Text));

        //        cmd.Parameters.AddWithValue("@product_highlights", txt_P_highlights.Text.ToUpper());

        //        cmd.Parameters.AddWithValue("@product_description", txt_P_description.Text.ToUpper());

        //        cmd.Parameters.AddWithValue("@product_warranty", txt_P_warranty.Text.ToUpper());
        //        cmd.Parameters.AddWithValue("@product_start_date", txt_P_SDate.Text.ToUpper());

        //        cmd.Parameters.AddWithValue("@product_end_date", txt_P_EDate.Text.ToUpper());

        //        cmd.Parameters.AddWithValue("@product_status", ddl_P_Status.Text.ToUpper());




        //        //it will open the connection 
        //        con.Open();
        //        //it will execute the cmd 
        //        cmd.ExecuteNonQuery();

        //    }
        //}
        

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            lbl_message.Text = "";
            string selcectsubProduct_Category = "SELECT   product_code FROM PRODUCT order by product_id";

            SqlDataAdapter dap_Code = new SqlDataAdapter(selcectsubProduct_Category, Ritika.CS);
            DataTable dtp_Code = new DataTable();
            dap_Code.Fill(dtp_Code);

            ddl_P_code.DataSource = dtp_Code;
            ddl_P_code.DataTextField = "product_code";
            ddl_P_code.DataValueField = "product_code";
            ddl_P_code.DataBind();

            ddl_P_code.SelectedIndex = 0;
            txt_P_Code.Visible = false;
            ddl_P_code.Visible = true;
            //to show first data on the screen
            ddl_P_code_SelectedIndexChanged(sender, e);
            Ritika.ctype = "edit";

        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {

            lbl_message.Text = "";

            //loop of connection
            using (SqlConnection con = new SqlConnection(Ritika.CS))
            {
                //Command to be executed on Sql Server 
                //values will be in the form of variable
                string cmdText = "UPDATE product SET product_status ='INACTIVE' WHERE product_code=@product_code";
                //establish connection with DB
                SqlCommand cmd = new SqlCommand(cmdText, con);
                //taking Argument value of cmdText from different tools like textbox, ddl etc
                cmd.Parameters.AddWithValue("@product_code", ddl_P_code.Text.ToUpper());
                //it will open the connection 
                con.Open();
                //it will execute the cmd 
                cmd.ExecuteNonQuery();
            }
            Ritika.ctype = "";
            ddl_P_code.Visible = true;
            txt_P_Code.Visible = false;
            ddl_P_code.Items.Clear();

            lbl_message.Text = "data is inactive";
            clearscreen();
        }
    
        

        protected void btn_submit_Click(object sender, EventArgs e)
        {
                lbl_message.Text = "";
                if (Ritika.ctype == "edit")
                {
            //loop of connection
            using (SqlConnection con = new SqlConnection(Ritika.CS))
            {
                //Command to be executed on Sql Server 
                //values will be in the form of variable
                string cmdText = "UPDATE  product set product_category_code = @product_category_code,product_Sub_category_code=@product_Sub_category_code,product_name=@product_name,product_price=@product_price,product_offer=@product_offer,product_highlights=@product_highlights,product_description=@product_description,product_warranty=@product_warranty,product_start_date=@product_start_date,product_end_date=@product_end_date, product_status=@product_status  where product_code=@product_code";
                //establish connection with DB
                SqlCommand cmd = new SqlCommand(cmdText, con);
                //taking Argument value of cmdText from different tools like textbox, ddl etc
                cmd.Parameters.AddWithValue("@product_code", ddl_P_code.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_category_code", ddl_pc_code.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_Sub_category_code", ddl_PsC_code.Text.ToUpper());

                cmd.Parameters.AddWithValue("@product_name", txt_P_Name.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_price", txt_P_price.Text.ToUpper());

                cmd.Parameters.AddWithValue("@product_offer", txt_P_offer.Text.ToUpper());

                cmd.Parameters.AddWithValue("@product_highlights", txt_P_highlights.Text.ToUpper());

                cmd.Parameters.AddWithValue("@product_description", txt_P_description.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_warranty", txt_P_warranty.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_start_date", txt_P_SDate.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_end_date", txt_P_EDate.Text.ToUpper());
                cmd.Parameters.AddWithValue("@product_status", ddl_P_Status.Text.ToUpper());


                //it will open the connection 
                con.Open();
                //it will execute the cmd 
                cmd.ExecuteNonQuery();

                 }
                lbl_message.Text = "data is updated";
              
             lbl_message.Text = "data and Images are  updated";

            }

             else
            
    {
                string codeavailable = "N";
                using (SqlConnection con = new SqlConnection(Ritika.CS))
                {
                    string cmdText = "SELECT product_code FROM product where product_code= @product_code";
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    cmd.Parameters.AddWithValue("@product_code", txt_P_Code.Text);
        con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        string script = "alert(\"product category Already Exist.\");";
                        ScriptManager.RegisterStartupScript (this, GetType(),"ServerControlScript", script, true);
                        codeavailable = "Y";
                        lbl_message.Text = "data Already Exist!!!";
                    }
                }
                  if (codeavailable == "N")
                {
                    using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                    {
                        //Command to be executed on Sql Server 
                        //values will be in the form of variable
                        string cmdText = "INSERT INTO product (product_code,product_category_code,product_Sub_category_code, product_name,product_price,product_offer,product_highlights,product_description,product_warranty,product_start_date,product_end_date,product_status) VALUES (@product_code,@product_category_code,@product_Sub_category_code,@product_name,@product_price,@product_offer,@product_highlights,@product_description,@product_warranty,@product_start_date,@product_end_date,@product_status)";
                        //establish connection with DB
                        SqlCommand cmd = new SqlCommand(cmdText, con);
                        //taking Argument value of cmdText from different tools like textbox, ddl etc

                        cmd.Parameters.AddWithValue("@product_code", txt_P_Code.Text.ToUpper().Trim());
                        cmd.Parameters.AddWithValue("@product_category_code", ddl_pc_code.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_Sub_category_code", ddl_PsC_code.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@product_name", txt_P_Name.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@product_price", Convert.ToInt16(txt_P_price.Text));
                        cmd.Parameters.AddWithValue("@product_offer", Convert.ToInt16(txt_P_offer.Text));

                        cmd.Parameters.AddWithValue("@product_highlights", txt_P_highlights.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@product_description", txt_P_description.Text.ToUpper());

                        cmd.Parameters.AddWithValue("@product_warranty", txt_P_warranty.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_start_date", txt_P_SDate.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@product_end_date", txt_P_EDate.Text.ToUpper());
                     

                        cmd.Parameters.AddWithValue("@product_status", ddl_P_Status.Text.ToUpper());




                        //it will open the connection 
                        con.Open();
                        //it will execute the cmd 
                        cmd.ExecuteNonQuery();

                    }
                    lbl_message.Text = "data entered";


            }
        }
               Ritika.ctype = "";
            ddl_P_code.Visible = false;
            txt_P_Code.Visible = true;
            ddl_P_code.Items.Clear();
            clearscreen();
          }

        protected void ddl_pc_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selcectsubProduct_Category = "SELECT   product_sub_category_code FROM product_sub_category where product_category_code ='" + ddl_pc_code.Text + "' and product_sub_category_status='ACTIVE' order by product_sub_category_code";

            SqlDataAdapter daPsC_Code = new SqlDataAdapter(selcectsubProduct_Category, Ritika.CS);
            DataTable dtPsC_Code = new DataTable();
            daPsC_Code.Fill(dtPsC_Code);

            ddl_PsC_code.DataSource = dtPsC_Code;
            ddl_PsC_code.DataTextField = "product_Sub_category_code";
            ddl_PsC_code.DataValueField = "product_Sub_category_code";
            ddl_PsC_code.DataBind();

            ddl_PsC_code.SelectedIndex = 0;
           
        }

        protected void ddl_P_code_SelectedIndexChanged(object sender, EventArgs e)
        {
               using (SqlConnection con = new SqlConnection(Ritika.CS))
            {
                string cmdText = "SELECT Product_Category_code,product_Sub_category_code,product_code,product_name,product_price,product_offer,product_highlights,product_description,product_warranty,product_start_date,product_end_date ,product_status  FROM PRODUCT where product_code= @product_code";


                SqlCommand cmd = new SqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@product_code", ddl_P_code.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                      ddl_pc_code.Text = dr["Product_Category_code"].ToString();
                      ddl_pc_code_SelectedIndexChanged(sender, e);
                     

                      txt_P_Code.Text = dr["product_code"].ToString();
                    txt_P_Name.Text = dr["product_name"].ToString();
                    txt_P_price.Text = dr["product_price"].ToString();
                    txt_P_offer.Text = dr["product_offer"].ToString();
                    txt_P_highlights.Text = dr["product_highlights"].ToString();
                     txt_P_description.Text = dr["product_description"].ToString();
                     txt_P_warranty.Text = dr["product_warranty"].ToString();
                     txt_P_SDate.Text = dr["product_start_date"].ToString();
                     txt_P_EDate.Text = dr["product_end_date"].ToString();
                     ddl_P_Status.Text = dr["product_status"].ToString();
                     ddl_PsC_code.Text = dr["product_Sub_category_code"].ToString();




                }


            }
               btn_Upload.Enabled = true;
               fileuploadimages.Enabled = true;
               fileuploadTitle.Enabled = true;
        }


        protected void ImageUpload()
        {
            int imageno = 1;
            string ImageCode = "";
                   

            if (!string.IsNullOrEmpty(txt_P_Code.Text) )
            {
                lblImageMes.Text = "";
                if (fileuploadTitle.HasFile == false)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('No File Uploaded.')</script>", false);
                    lblImageMes.Text = "No Title Images  are available to Upload. ";
                }
                else
                {
                   
                    foreach (var file in fileuploadTitle.PostedFiles)
                    {
                        ImageCode = txt_P_Code.Text.ToUpper() + imageno.ToString();
                        string[] imagename = ImageCode.Split('/');
                        string imagename1 = imagename[0].ToString();
                        imagename1.Replace(' ', '-');
                        string filename = Path.GetFileName(file.FileName);
                        string[] fileex = filename.Split('.');

                        // ImageCode = (DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
                        ImageCode = "pimages";
                        ImageCode = ImageCode + "/" + imagename1 + "." + fileex[fileex.Length - 1];

                        //Code Saving only File
                        file.SaveAs(Server.MapPath("/" + ImageCode));

                        imageno++;
                    }

                }


                foreach (var file in fileuploadimages.PostedFiles)
                {
                    ImageCode = txt_P_Code.Text.ToUpper() + imageno.ToString();
                    string[] imagename = ImageCode.Split('/');
                    string imagename1 = imagename[0].ToString();
                    imagename1.Replace(' ', '-');
                    string filename = Path.GetFileName(file.FileName);
                    string[] fileex = filename.Split('.');

                    // ImageCode = (DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
                    ImageCode = "pimages";
                    ImageCode = ImageCode + "/" + imagename1 + "." + fileex[fileex.Length - 1];

                    //Code Saving only File
                    file.SaveAs(Server.MapPath("/" + ImageCode));

                    imageno++;
                }
                lblImageMes.Text = "Images are uploaded Successfully.";
                btn_Upload.Enabled = false;
                fileuploadimages.Enabled = false;
                fileuploadTitle.Enabled = false;
             
            }
            else
            {
                string script = "alert(\"Enter All Fields.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            ImageUpload();
        }

        }
    }

