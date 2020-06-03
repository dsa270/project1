
<%@ Page Title="Welcome to News for Nation-Login Page" Language="C#" MasterPageFile="~/MLogin.master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JECRC_PMall.Login" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   
</asp:Content>

      
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <div  class="col-sm-12" style ="   background-color: #f2f2f2; padding:0px;margin:0px; line-height:140%;min-height:500px">  
   
    <div class="col-sm-12"  style="background-color: #0f3955; color:white; line-height:140%;font-size:20px; font-family:Cambria; " >
                     Home>Login Details
    </div>

        <div class="col-sm-12" style="text-align:right;padding:10px;">
                <div class="col-sm-6" style="text-align:right" >
                    Login Id:
                </div>
                <div class="col-sm-6" style="text-align:left" >
                    <asp:TextBox style ="text-transform:uppercase"   ID="txt_User_ID" runat="server" Width="200px"></asp:TextBox>
                </div>
            </div>
               <div class="col-sm-12" style="text-align:right;padding:10px;">
                <div class="col-sm-6" style="text-align:right" >
                    Password:
                </div>
                <div class="col-sm-6" style="text-align:left" >
                    <asp:TextBox style ="text-transform:uppercase"  TextMode="Password"  ID="txt_Password" runat="server" Width="200px"></asp:TextBox>
                </div>
            </div>
                    <div class="col-sm-12" style="text-align:right;padding:10px;">
                <div class="col-sm-6" style="text-align:right" >
                    
                </div>
                <div class="col-sm-6" style="text-align:left" >
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" BackColor="White" BorderColor="#000066" BorderStyle="Solid" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="X-Large" ForeColor="#000099" OnClick="btn_Submit_Click" />
                </div>
            </div>       
              </div>

   
    </asp:Content>