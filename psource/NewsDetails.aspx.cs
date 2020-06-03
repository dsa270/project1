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
    public partial class NewsDetails : System.Web.UI.Page
    {
        private string convert_from_unicode(string str, char c)
        {
            string rtstr = "";
            for (int i = 2; i < str.Length; i += 6)
            {
                string str1 = str.Substring(i, 4);
                c = (char)Int16.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                rtstr += c;
            }
            return rtstr;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // select CAST(House_Hold_ID as varchar(50)) + '---' + House_Hold_Name AS House_Hold_Name string selcectstatement = "SELECT News_Type_Code  AS News_Type_Code, Div_ID AS Div_ID FROM News_Type_Details WHERE STATUS='ACTIVE' ORDER BY News_Type_Code ";
                string selcectstatement = "SELECT News_Type_Code  + '---'+ Div_ID AS News_Type_Code FROM News_Type_Details WHERE STATUS='ACTIVE' ORDER BY News_Type_Code ";

                SqlDataAdapter da = new SqlDataAdapter(selcectstatement, IGTMAIN.CS);
                DataTable dt = new DataTable();
                da.Fill(dt);             
                ddl_News_Type.DataSource = dt;
                ddl_News_Type.DataTextField = "News_Type_Code";
                ddl_News_Type.DataValueField = "News_Type_Code";
                ddl_News_Type.DataBind();


                string selcectstatementSTATE = "SELECT State_Code, State_Name FROM State WHERE State_Staus='ACTIVE' ";

                SqlDataAdapter daSTATE = new SqlDataAdapter(selcectstatementSTATE, IGTMAIN.CS);
                DataTable dtSTATE = new DataTable();
                daSTATE.Fill(dtSTATE);
                ddl_State.DataSource = dtSTATE;
                ddl_State.DataTextField = "State_Name";
                ddl_State.DataValueField = "State_Code";
                ddl_State.DataBind();

                ddl_State.SelectedIndex = 0;

                string selcectstatementCITY = "SELECT City_Code, City_Name FROM City WHERE City_Status='ACTIVE'  and State_Code= '" + ddl_State.SelectedValue + "'";

                SqlDataAdapter daCITY = new SqlDataAdapter(selcectstatementCITY, IGTMAIN.CS);
                DataTable dtCITY = new DataTable();
                daCITY.Fill(dtCITY);
                ddl_City.DataSource = dtCITY;
                ddl_City.DataTextField = "City_Name";
                ddl_City.DataValueField = "City_Code";
                ddl_City.DataBind();

                ddl_Breaking.Items.Add("Yes");
                ddl_Breaking.Items.Add("NO");
                ddl_Breaking.SelectedIndex = 0;
                ddl_News_Type.SelectedIndex = 0;
                string[] fontMenuList = { "Time New Roman", "Georgia", "Arial", "Tahoma", "Wingdings" };
                string[] fontMenuName = { "Time", "Georgia", "Arial", "Tahoma", "Wingdings" };

                txt_Story_Details.FontFacesMenuList = fontMenuList;
                IGTMAIN.cmdtextAll = "Select * from News_Details order by News_Code";
                txt_Story_Details.FontFacesMenuNames = fontMenuName;          
                ddl_Status.Items.Add("INACTIVE");

               

            }      
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string[] delimiters = new string[] { "---" };
            string[] txtdiv = ddl_News_Type.Text.ToString().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);


      


            txt_News_Code.Text = txtdiv[1].ToString() + "--" + txt_Title.Text.Replace(' ', '-');




            if (!string.IsNullOrEmpty(txt_Title.Text) || !string.IsNullOrEmpty(txt_ETitle.Text) ||  !string.IsNullOrEmpty(txt_News_Code.Text) || !string.IsNullOrEmpty(txt_Story_Details.Text) || !string.IsNullOrEmpty(txt_link_name.Text))
            { 

            IGTMAIN.cmdtext = IGTMAIN.cmdtextAll;
           
            IGTMAIN.GetDataLP(); 
            DataRow[] dr = IGTMAIN.dtlp.Select("News_Code = '" + txt_News_Code.Text + "'");
                if (dr.Length == 0)
                {



                    using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                     {
                         string cmdText = "INSERT INTO News_Details (News_Type_Code,News_Code,Is_Breaking,Title,ETitle,Intro,MetaKey,MetaDesc,Story_Details,link_name,Posted_By" +
                                          ",Written_By,Covered_By,Photo_By,Status,Remarks,State,City,Created_Date,Created_IP,Created_MAC,Created_By)" +
                                          "VALUES"+
                                          "(@News_Type_Code,@News_Code,@Is_Breaking,@Title,@ETitle,@Intro,@MetaKey, @MetaDesc, @Story_Details,@link_name,@Posted_By" +
                                          ",@Written_By,@Covered_By,@Photo_By,@Status,@Remarks,@State,@City,@Created_Date,@Created_IP,@Created_MAC,@Created_By)";
                         SqlCommand cmd = new SqlCommand(cmdText, con);

                         cmd.Parameters.AddWithValue("@News_Type_Code", ddl_News_Type.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@News_Code", txt_News_Code.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@Is_Breaking", ddl_Breaking.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@Title", txt_Title.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@ETitle", txt_ETitle.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@Intro", txt_Intro.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@MetaKey", txt_Keyword.Text);                                        
                         cmd.Parameters.AddWithValue("@MetaDesc", txt_Desc.Text);
                         cmd.Parameters.AddWithValue("@Story_Details", txt_Story_Details.Text.ToString()); 
                         cmd.Parameters.AddWithValue("@link_name", txt_link_name.Text);
                         cmd.Parameters.AddWithValue("@Posted_By", HttpContext.Current.Session["User_ID"].ToString());
                         cmd.Parameters.AddWithValue("@Written_By", txt_Written_By.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@Covered_By", txt_Covered_By.Text);
                         cmd.Parameters.AddWithValue("@Photo_By", txt_Photo_By.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@Status", ddl_Status.Text.ToUpper());
                         cmd.Parameters.AddWithValue("@Remarks", txt_Remarks.Text);
                         cmd.Parameters.AddWithValue("@State", ddl_State.Text);
                         cmd.Parameters.AddWithValue("@City", ddl_City.Text);
                        
                         cmd.Parameters.AddWithValue("@Created_Date", DateTime.Now.ToString("yyyyMMddHHmmss"));      
                         cmd.Parameters.AddWithValue("@Created_IP", IGTMAIN.GetIpAddress().ToString());
                        cmd.Parameters.AddWithValue("@Created_MAC", IGTMAIN.GetMacAddress().ToString());
                        cmd.Parameters.AddWithValue("@Created_By", HttpContext.Current.Session["User_ID"].ToString());



                       


                         con.Open();
                     cmd.ExecuteNonQuery();

                     }

                    string script = "alert(\"New Record is Added Successfully.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);



                     lbl_Message.Text = "New Record is Added Successfully.";
                     txt_link_name.Enabled = true;
          
             //       ImageUpload();

                }
                else
                {
                    string script = "alert(\"News Already Exist.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);


                }

            }
            else
            {
                string script = "alert(\"Enter All Fields.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);


            }
                
            
        }


        protected void ImageUpload()


    {

        if (!string.IsNullOrEmpty(txt_Title.Text) || !string.IsNullOrEmpty(txt_ETitle.Text) || !string.IsNullOrEmpty(txt_News_Code.Text) || !string.IsNullOrEmpty(txt_Story_Details.Text) || !string.IsNullOrEmpty(txt_link_name.Text))
        {
            lblImageMes.Text = ""; 
            if (fileuploadTitle.HasFile == false)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('No File Uploaded.')</script>", false);
                lblImageMes.Text = "No Title Images  are available to Upload. ";
            }
            else
            {
                int imageno = 1;
                string ImageCode = "";
                string ImgDirectoryName = "";
                foreach (var file in fileuploadTitle.PostedFiles)
                {
                    ImageCode = txt_link_name.Text.ToUpper() + imageno.ToString();
                    string[] imagename = ImageCode.Split('/');
                    string filename = Path.GetFileName(file.FileName);
                    string[] fileex = filename.Split('.');

                    ImageCode = (DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
                    ImageCode =ImageCode+"/"+ imagename[1] + "." + fileex[fileex.Length - 1];
                 
                    //Code Saving only File
                    file.SaveAs(Server.MapPath("/newsImages/" + ImageCode));

            //        string selcectstatementimages = "select Image_Code from News_Images_Details  where Image_Code='" + ImageCode + "'";

            //SqlDataAdapter daImage = new SqlDataAdapter(selcectstatementimages, IGTMAIN.CS);
            //DataTable dtImage = new DataTable();
            //daImage.Fill(dtImage);

                    using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                    {

                        string cmdtext = "delete from  News_Images_Details where Image_Code='" + ImageCode + "'";
                        SqlCommand cmd = new SqlCommand(cmdtext, con);                    
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }



         

                using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO News_Images_Details(Image_Code,News_Code,Image_Name,Image_Title,Status,link_name,Remarks,Created_Date,Created_IP,Created_MAC,Created_By) VALUES(@Image_Code,@News_Code,@Image_Code,@Image_Title,@Status,@link_name,@Remarks,@Created_Date,@Created_IP,@Created_MAC,@Created_By)", con);

                    cmd.Parameters.AddWithValue("@Image_Code", ImageCode);
                    cmd.Parameters.AddWithValue("@News_Code", txt_News_Code.Text);
                    cmd.Parameters.AddWithValue("@Image_Title", "");
                    cmd.Parameters.AddWithValue("@Status", "ACTIVE");
                    cmd.Parameters.AddWithValue("@link_name", txt_link_name.Text);
                    cmd.Parameters.AddWithValue("@Remarks", "");
                    cmd.Parameters.AddWithValue("@Created_Date", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    cmd.Parameters.AddWithValue("@Created_IP", IGTMAIN.GetIpAddress().ToString());
                    cmd.Parameters.AddWithValue("@Created_MAC", IGTMAIN.GetMacAddress().ToString());
                    cmd.Parameters.AddWithValue("@Created_By", HttpContext.Current.Session["User_ID"].ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
           
                    imageno++;
                }
           



            if (fileuploadimages.HasFile == false)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('No File Uploaded.')</script>", false);
                lblImageMes.Text = "No Images are available to Upload. ";
            }
            else
            {
                 imageno = 2;
                 ImageCode = "";
                foreach (var file in fileuploadimages.PostedFiles)
                {
                    ImageCode = txt_link_name.Text.ToUpper() + imageno.ToString();
                    string[] imagename = ImageCode.Split('/');
                    string filename = Path.GetFileName(file.FileName);
                    string[] fileex = filename.Split('.');
                    ImageCode = (DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
                    ImageCode = ImageCode + "/" + imagename[1] + "." + fileex[fileex.Length - 1];
                 
                    //Code for changing Image Size Widht Height Quality ect
                    /*   file.SaveAs(Server.MapPath("/images/" + filename));
                       string urlImage = Server.MapPath("/images/" + filename);
                      Bitmap image1 = new Bitmap(@urlImage, true);
                       urlImage = Server.MapPath("/images/" + ImageCode);
                      ImagesChangeandSave(image1, 500, 400, 5, urlImage);
                     */
                    //Code Saving only File
                    file.SaveAs(Server.MapPath("/newsImages/" + ImageCode));

                     using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                        {

                            string cmdtext = "delete from  News_Images_Details where Image_Code='" + ImageCode + "'";
                            SqlCommand cmd = new SqlCommand(cmdtext, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                    }

                
                using (SqlConnection con = new SqlConnection(IGTMAIN.CS))
                {
                    //INSERT INTO #table1 (Id, guidd, TimeAdded, ExtraData) SELECT Id, guidd, TimeAdded, ExtraData FROM #table2 WHERE NOT EXISTS (Select Id, guidd From #table1 WHERE #table1.id = #table2.id)

                    SqlCommand cmd = new SqlCommand("INSERT INTO News_Images_Details(Image_Code,News_Code,Image_Name,Image_Title,Status,link_name,Remarks,Created_Date,Created_IP,Created_MAC,Created_By) VALUES(@Image_Code,@News_Code,@Image_Code,@Image_Title,@Status,@link_name,@Remarks,@Created_Date,@Created_IP,@Created_MAC,@Created_By)", con);

                    cmd.Parameters.AddWithValue("@Image_Code", ImageCode);
                    cmd.Parameters.AddWithValue("@News_Code", txt_News_Code.Text);
                    cmd.Parameters.AddWithValue("@Image_Title", "");
                    cmd.Parameters.AddWithValue("@Status", "ACTIVE");
                    cmd.Parameters.AddWithValue("@link_name", txt_link_name.Text);
                    cmd.Parameters.AddWithValue("@Remarks", "");
                    cmd.Parameters.AddWithValue("@Created_Date", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    cmd.Parameters.AddWithValue("@Created_IP", IGTMAIN.GetIpAddress().ToString());
                    cmd.Parameters.AddWithValue("@Created_MAC", IGTMAIN.GetMacAddress().ToString());
                    cmd.Parameters.AddWithValue("@Created_By", HttpContext.Current.Session["User_ID"].ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
           
                    imageno++;
                }
            }
                 }

            lblImageMes.Text = "Images are uploaded Successfully.";
            btn_Upload.Enabled = false;
            fileuploadimages.Enabled = false;
            fileuploadTitle.Enabled =false;
            txt_News_Code.Enabled = false;
            txt_link_name.Enabled = false;
        }
        else
        {
            string script = "alert(\"Enter All Fields.\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);


        }


}

        protected void txt_Title_TextChanged(object sender, EventArgs e)
        {
            //         txt_Title.Text = Regex.Replace(txt_Title.Text, @"\s+", " ");
            //string[] delimiters = new string[] { "---" };
            //string[] txtdiv = ddl_News_Type.Text.ToString().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            //if (txt_link_name.Text.Length == 0) {

            //    string linkname =  txt_Title.Text.Trim();
            //   // linkname = Google.API.Translate.Translator.Translate(linkname, Google.API.Translate.Language.Hindi, Google.API.Translate.Language.English);


            //    txt_link_name.Text = txtdiv[1].ToString() + "/" + linkname.Replace(' ', '-');


            //     ScriptManager.RegisterStartupScript(this, GetType(),
            //         "ServerControlScript", txt_link_name.Text, true);
            //      txt_News_Code.Text = txtdiv[1].ToString() + "--" + txt_Title.Text.Replace(' ', '-');

            //}
           
                

                      
        }

        /// <summary>
        /// Method to resize, convert and save the image.
        /// </summary>
        /// <param name="image">Bitmap image.</param>
        /// <param name="maxWidth">resize width.</param>
        /// <param name="maxHeight">resize height.</param>
        /// <param name="quality">quality setting value.</param>
        /// <param name="filePath">file path.</param>      
        public void ImagesChangeandSave(Bitmap image, int maxWidth, int maxHeight, int quality, string filePath)
        {
            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            // Convert other formats (including CMYK) to RGB.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Get an ImageCodecInfo object that represents the JPEG codec.
            ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

            // Create an Encoder object for the Quality parameter.
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object. 
            EncoderParameters encoderParameters = new EncoderParameters(1);

            // Save the image as a JPEG file with quality level.
            EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
            encoderParameters.Param[0] = encoderParameter;
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            newImage.Save(filePath, imageCodecInfo, encoderParameters);
        }

        /// <summary>
        /// Method to get encoder infor for given image format.
        /// </summary>
        /// <param name="format">Image format</param>
        /// <returns>image codec info.</returns>
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }


        protected void txt_Story_Details_TextChanged(object sender, EventArgs e)
        {
           //  marks1.Text = "Total Marks : " + sum3.ToString();
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert(" + sum3.ToString() + ");", true);
 

            //remove all text     string script = "alert(\"News Already Exist.\");";
            string script = txt_Story_Details.Text.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "showAlert(" + script.ToString() + ");", true);



        }

        protected void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_City.Items.Clear();
            string selcectstatementCITY = "SELECT City_Code, City_Name FROM City WHERE City_Status='ACTIVE'  and State_Code= '" + ddl_State.SelectedValue + "'";

            SqlDataAdapter daCITY = new SqlDataAdapter(selcectstatementCITY, IGTMAIN.CS);
            DataTable dtCITY = new DataTable();
            daCITY.Fill(dtCITY);
            ddl_City.DataSource = dtCITY;
            ddl_City.DataTextField = "City_Name";
            ddl_City.DataValueField = "City_Code";
            ddl_City.DataBind();

        }

        public static string RemoveSpecialChars(string str)
        {
            // Create  a string array and add the special characters you want to remove
            string[] chars = new string[] {"?", ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";",  "(", ")", ":", "|", "[", "]" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "");
                }
            }
            return str;
        }

        protected void txt_ETitle_TextChanged(object sender, EventArgs e)
        {
         if  (  txt_link_name.Enabled == true)
         { 
                      //   txt_ETitle.Text = Regex.Replace(txt_ETitle.Text, @"\s+", " ");
            string[] delimiters = new string[] { "---" };
            string[] txtdiv = ddl_News_Type.Text.ToString().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);


            string linkname = RemoveSpecialChars(txt_ETitle.Text.Trim()); ;
                // linkname = Google.API.Translate.Translator.Translate(linkname, Google.API.Translate.Language.Hindi, Google.API.Translate.Language.English);


                txt_link_name.Text = txtdiv[1].ToString() + "/" + linkname.Replace(' ', '-');

              
                txt_News_Code.Text = txtdiv[1].ToString() + "--" + txt_Title.Text.Replace(' ', '-');
         }
            }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            ImageUpload();
            txt_Story_Details.ImageGalleryPath="/newsImages/"+ (DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));

            txt_Story_Details.ImageGalleryUrl = "ftb.imagegallery.aspx?rif=/imagespath/&cif=/newsImages/" + (DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)) + "/";



           
           
            
        }

        protected void ddl_News_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_link_name.Enabled == true)
            {
                string[] delimiters = new string[] { "---" };
                string[] txtdiv = ddl_News_Type.Text.ToString().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                string linkname = RemoveSpecialChars(txt_ETitle.Text.Trim()); ;
                txt_link_name.Text = txtdiv[1].ToString() + "/" + linkname.Replace(' ', '-');
                txt_News_Code.Text = txtdiv[1].ToString() + "--" + txt_Title.Text.Replace(' ', '-');


            }

        }
       
}
        }
    
    