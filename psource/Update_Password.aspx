<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Update_Password.aspx.cs" Inherits="JECRC_PMall.Update_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div   style="background-color:#f2f2f2;">

                  <div class="col-sm-12" style="background-color:#f2f2f2;">
                       <div class="col-sm-12"  style="background-color: #0f3955; color:white; line-height:140%;font-size:20px; font-family:Cambria; " >
                     Home>News>>Day Wise Visit Details Report
   
                     
                      </div>
                       <div class="col-sm-12" style="background-color:#f2f2f2; text-align:center">
                          <div class="col-sm-6" style="background-color:#f2f2f2; text-align:right">
                              Current Password:
                              </div>
                            <div class="col-sm-6" style="background-color:#f2f2f2; text-align:left">
                                 <asp:TextBox style ="text-transform:uppercase"   ID="txt_CPass" runat="server" TextMode="Password" Width="50%"></asp:TextBox>
                              </div>
                           </div>

                       <div class="col-sm-12" style="background-color:#f2f2f2; text-align:center">
                          <div class="col-sm-6" style="background-color:#f2f2f2; text-align:right">
                              New Password:
                              </div>
                            <div class="col-sm-6" style="background-color:#f2f2f2; text-align:left">
                                 <asp:TextBox style ="text-transform:uppercase"   ID="txt_NewPass" runat="server" TextMode="Password" Width="50%"></asp:TextBox>
                              </div>
                           </div>


                       <div class="col-sm-12" style="background-color:#f2f2f2; text-align:center">
                          <div class="col-sm-6" style="background-color:#f2f2f2; text-align:right">
                              Confirm Password:
                              </div>
                            <div class="col-sm-6" style="background-color:#f2f2f2; text-align:left">
                                 <asp:TextBox style ="text-transform:uppercase"   ID="txt_NCPass" runat="server" TextMode="Password" Width="50%"></asp:TextBox>
                              </div>
                           </div>

                       


                       <div class="col-sm-12" style="text-align:left;padding:5px;">
                <div class="col-sm-10" style="text-align:center" >
                      <asp:HiddenField ID="hfSelectedRecord" runat="server" />
                    <asp:Label ID="lbl_Message" runat="server" Text="Message" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-sm-2"  >
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit"  BorderStyle="Outset" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="X-Large" ForeColor="#000099" OnClick="btn_Submit_Click" CssClass="btn-default active" TabIndex="10" />
                </div>
                
            </div> 
                  </div>
</asp:Content>
