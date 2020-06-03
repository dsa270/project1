<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserEntry.aspx.cs" Inherits="IGTNewsfNation.UserEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     

     <div  class="col-sm-12" style ="   background-color: #f2f2f2; padding:0px;margin:0px; line-height:140%;min-height:458px">  
   
    <div class="col-sm-12"  style="background-color: #0f3955; color:white; line-height:140%;font-size:20px; font-family:Cambria; " >
                     Home>User Details Entry 
    </div>

        <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                    Login ID:
                   </div>  
            <div class="col-sm-5" style="text-align:left;padding-left:5px;" tabindex="0" >
                    <asp:TextBox style ="text-transform:uppercase"   ID="txt_User_Code"  ReadOnly="true" runat="server" Text="Auto Generated" Width="100%"></asp:TextBox>
                </div>
            <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                   Type:
                   </div>  
            <div class="col-sm-2" style="text-align:left;padding-left:5px;" >
                     <asp:DropDownList ID="ddl_User_Type" Width="100%" Height="25px" runat="server" TabIndex="1"></asp:DropDownList>
                </div>
           <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                     Status:
                   </div>  
            <div class="col-sm-2" style="text-align:left;padding-left:5px;" >
                
                    <asp:DropDownList ID="ddl_Status" Width="100%" Height="25px" runat="server" TabIndex="2"></asp:DropDownList>
                </div>
            </div>
        
               <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                   Name:
                   </div>  
                   <div class="col-sm-11" style="text-align:left; vertical-align:central;padding-left:5px;">  
                  <asp:TextBox style ="text-transform:uppercase; padding-left:10px"   ID="txt_Name" runat="server" Width="100%" AutoPostBack="true" TabIndex="3" ></asp:TextBox>
                </div>
                   </div>
         <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                    Descrption:
                   </div>  
                      <div class="col-sm-11" style="text-align:left; vertical-align:central;padding-left:5px;">  
                  <asp:TextBox style ="text-transform:uppercase; padding-left:10px"   ID="txt_Description" runat="server" Width="100%" TabIndex="4"></asp:TextBox>
                </div>
             </div>
           <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                     Email:
                   </div>  
                <div class="col-sm-5" style="text-align:left; vertical-align:central;padding-left:5px;">             
                  
                  <asp:TextBox style ="text-transform:uppercase;  padding-left:10px" Width="100%"  ID="txt_Email" runat="server" OnTextChanged="txt_Email_TextChanged" TabIndex="5"></asp:TextBox>
                </div>
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                   Alt  Email:
                   </div>  

          <div class="col-sm-5" style="text-align:left; vertical-align:central;padding-left:5px;">             
                  
                  <asp:TextBox style ="text-transform:uppercase;  padding-left:10px" Width="100%" ID="txt_Alt_Email" runat="server" TabIndex="6"  ></asp:TextBox>
                </div>
               </div>
          <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                   Phone No:
                   </div>  
               <div class="col-sm-5" style="text-align:left; vertical-align:central;padding-left:5px;">             
                   
                  <asp:TextBox style ="text-transform:uppercase;  padding-left:10px"  ID="txt_Phone" Width="100%" runat="server" TabIndex="7"></asp:TextBox>
                </div>

          <div class="col-sm-1" style="text-align:right; vertical-align:central">             
                   Alt  No:
              </div>
               <div class="col-sm-5" style="text-align:left; vertical-align:central;padding-left:5px;">    
                  <asp:TextBox style ="text-transform:uppercase;  padding-left:10px" Width="100%" ID="txt_Alt_Phone" runat="server" TabIndex="8"  ></asp:TextBox>
                </div>
               </div>

         <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                   Password:
                   </div>  
               <div class="col-sm-5" style="text-align:left; vertical-align:central;padding-left:5px;">             
                   
                  <asp:TextBox style ="text-transform:uppercase;  padding-left:10px"  ID="txt_Password" Width="100%" runat="server" TabIndex="9"></asp:TextBox>
                </div>

          <div class="col-sm-2" style="text-align:right; vertical-align:central">             
                  Confirm Password:
              </div>
               <div class="col-sm-4" style="text-align:left; vertical-align:central;padding-left:5px;">    
                  <asp:TextBox style ="text-transform:uppercase;  padding-left:10px" Width="100%" ID="txt_Confirm_Password" runat="server" TabIndex="10"  ></asp:TextBox>
                </div>
               </div>

         <div class="col-sm-12" style="text-align:left;padding:5px;">
           
            <div class="col-sm-1" style="text-align:right;padding-left:5px;" >
                    Remarks:    </div>
            
            <div class="col-sm-11" style="text-align:left;padding-left:5px;" >
                
                      <asp:TextBox style ="text-transform:uppercase"  Width="100%" ID="txt_Remarks" runat="server" TabIndex="11" ></asp:TextBox>
                </div>
             
            </div>

        
         

                    <div class="col-sm-12" style="text-align:left;padding:5px;">
                <div class="col-sm-6" style="text-align:left" >
                    
                </div>
                <div class="col-sm-6"  >
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit"  BorderStyle="Outset" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="X-Large" ForeColor="#000099" OnClick="btn_Submit_Click" CssClass="btn-default active" TabIndex="12" />
                </div>
            </div>      
          
        


</asp:Content>