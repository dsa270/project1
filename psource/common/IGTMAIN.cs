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

using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Net.NetworkInformation;  

    public sealed class IGTMAIN
    {
       // using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html;
//using iTextSharp.text.html.simpleparser;


        #region Fields and Constant Declaration
        //The From address (Email ID)
        public static string str_from_address = "";
        //The Display Name
        public static string str_name = "";
        //The To address (Email ID) 
        public static string str_to_address = "";
        public static string forcaptcha = " ";
        public static string totalvisit;
        SqlCommand cmd1 = new SqlCommand();

        public static string cmdtextAll = "";
        public static string cmdtextSelect = "";
        public static string cmdtextadd = "";
        public static string cmdtextedit = "";
        public static string cmdtextdel = "";
        public static string cmdtextlp = "";
        public static string cmdtext = "";
        public static DataTable dtlp = new DataTable();


        public static string filename = "News_Type_Details";
        public static string Title1 = "News4Nation";
        public static string Title2 = "";
        public static string Title3 = "";
        public static string Title = "";
        
        #endregion
        #region For classes
        public static string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public static string GetMacAddress()  
    {
             #region--Collect the Mac address of the user machine--  
  
        string MacAddress = string.Empty;  
  
        try {  
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();  
  
            MacAddress = Convert.ToString(nics[0].GetPhysicalAddress());  
  
            return MacAddress;  
        } catch (ArgumentNullException Exc)  
        {  
           // lblErrorMsg.Text = "Application Error : " + Exc.Message;  
            return MacAddress;  
        } catch (InvalidCastException Exc)  
        {  
          //   lblErrorMsg.Text = "Application Error : " + Exc.Message;  
            return MacAddress;  
        } catch (InvalidOperationException Exc)   
        {  
           //  lblErrorMsg.Text = "Application Error : " + Exc.Message;  
            return MacAddress;  
        } catch (NullReferenceException Exc)  
        {  
           //  lblErrorMsg.Text = "Application Error : " + Exc.Message;  
            return MacAddress;  
        } catch (Exception Exc)   
        {  
          //  lblErrorMsg.Text = "Application Error : " + Exc.Message;  
            return MacAddress;  
        }  
 
        #endregion  
    }

         public static string GetIpAddress()  
{
            #region --Collect the IP address of the user machine--  
  
    string IpAddress = string.Empty;  
  
    try {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
       
        IpAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];  
  
        if (IpAddress == " " || IpAddress == null)  
        {
            IpAddress = context.Request.ServerVariables["REMOTE_ADDR"];  
  
            return IpAddress;  
        } else   
        {  
            return IpAddress;  
        }  
    } catch (ArgumentNullException Exc)  
    {  
       
        return IpAddress;  
    } catch (InvalidCastException Exc)  
    {
        // lblErrorMsg.Text = "Application Error : " + Exc.Message;  
        return IpAddress;  
    } catch (InvalidOperationException Exc)  
    {
        // lblErrorMsg.Text = "Application Error : " + Exc.Message;  
        return IpAddress;  
    } catch (NullReferenceException Exc)  
    {
        // lblErrorMsg.Text = "Application Error : " + Exc.Message;  
        return IpAddress;  
    } catch (Exception Exc)  
    {
        //  lblErrorMsg.Text = "Application Error : " + Exc.Message;  
        return IpAddress;  
    }  
 
    #endregion  
}
         public static string IsMobileBrowser()
         {
             String labelText = "A";
             System.Web.HttpBrowserCapabilities myBrowserCaps = System.Web.HttpContext.Current.Request.Browser; 
             if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
             {
                 labelText = "M";
             }
             else
             {
                 labelText = "P";
             }
             return labelText;
         }

         public static string Encryptdata(string password)
         {
             string strmsg = string.Empty;
             byte[] encode = new byte[password.Length];
             encode = Encoding.UTF8.GetBytes(password);
             strmsg = Convert.ToBase64String(encode);
             return strmsg;
         }

         public static string Decryptdata(string encryptpwd)
         {
             string decryptpwd = string.Empty;
             UTF8Encoding encodepwd = new UTF8Encoding();
             Decoder Decode = encodepwd.GetDecoder();
             byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
             int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
             char[] decoded_char = new char[charCount];
             Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
             decryptpwd = new String(decoded_char);
             return decryptpwd;
         }


        public static void GetDataLP()
        {


            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand(cmdtext, con);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;

            cmd.Connection = con;

            try
            {



                while (dtlp.Columns.Count > 0)
                {
                    dtlp.Columns.RemoveAt(0);
                }

                dtlp.Clear();
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dtlp);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

         #endregion 
    }
