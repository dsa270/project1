<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NewsUploading.aspx.cs" Inherits="IGTNewsfNation.NewsUploading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <div   style="background-color:#f2f2f2; min-height:500px;">

                  <div class="col-sm-12" style="background-color:#f2f2f2;">
                       <div class="col-sm-12"  style="background-color: #0f3955; color:white; line-height:140%;font-size:20px; font-family:Cambria; " >
                     Home>News>>Day Wise Visit Details Report
   
                     
                      </div>
                       <div class="col-sm-12" style="background-color:#f2f2f2; text-align:center">
                           <br />
                           <br />

                            <asp:Button ID="btn_Yesterday" runat="server" Text="Yesterday"  BorderStyle="Outset" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="X-Large" ForeColor="#000099" OnClick="btn_Yesterday_Click" CssClass="btn-default active" TabIndex="10" />
                            <asp:Button ID="btn_Today" runat="server" Text="Today"  BorderStyle="Outset" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="X-Large" ForeColor="#000099" OnClick="btn_Today_Click" CssClass="btn-default active" TabIndex="10" />

                            <asp:Button ID="btn_OverAll" runat="server" Text="OverAll"  BorderStyle="Outset" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="X-Large" ForeColor="#000099" OnClick="btn_OverAll_Click" CssClass="btn-default active" TabIndex="10" />
                           <br />
                           <br />
                           <br />


                           </div>

                      </div>
         <div class="col-sm-12" style="background-color:#f2f2f2;text-align:center;margin:auto;padding:50px;">
    
      <asp:GridView ID="PageVisit" runat="server" AllowSorting="true" HorizontalAlign="Center"></asp:GridView>
                  <br /> <br />  <br />
                 <br />
             </div>

      
                </div>
    


</asp:Content>
