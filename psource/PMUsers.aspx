<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PMUsers.aspx.cs" Inherits="JECRC_PMall.PMUsers" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <style type="text/css">
        #tblDataDetails {
            width: 95%;
            border: 1px solid black;
            padding-left: 50px;
            padding-right: 50px;
            margin: 0px;
            border-collapse: collapse;
        }
           #tblDataDetails td {
                padding: 5px;
            }
        .normalRow {
            background-color: blue;
        }

        .altRow {
            background-color: yellow;
        }
    </style>
     <div  class="col-sm-12" style ="   background-color: #f2f2f2; padding:0px;margin:0px; line-height:140%;min-height:458px">  
   
    <div class="col-sm-12"  style="background-color: #0f3955; color:white; line-height:140%;font-size:20px; font-family:Cambria; " >
                   <div class="col-sm-9" style="text-align:left;padding-left:5px;"  >
                          Home>User Details Entry 
                       </div>
         <div class="col-sm-3" style="text-align:right;padding-right:20px;" >

        <asp:ImageButton ID="btn_adobe" runat="server" ImageUrl="~/icons/adobe.PNG" Height="15px" Width="15px" OnClick="btn_adobe_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="btn_excel" runat="server" Height="15px" Width="15px" ImageUrl="~/icons/excel.PNG" OnClick="btn_excel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="btn_csv" runat="server" Height="15px" Width="15px" ImageUrl="~/icons/csv.PNG" OnClick="btn_csv_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="btn_word" runat="server" Height="15px" Width="15px" ImageUrl="~/icons/word.PNG" OnClick="btn_word_Click" /> 
    </div>
         </div>

        <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                    User Type:
                   </div>  
            <div class="col-sm-4" style="text-align:left;padding-left:5px;" tabindex="0" >
                     <asp:DropDownList style ="text-transform:uppercase"   ID="ddl_User_Type"  runat="server"  Width="100%"></asp:DropDownList>
                </div>
            <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                     Status:
                   </div>  
            <div class="col-sm-1" style="text-align:left;padding-left:5px;" >
                
                    <asp:DropDownList ID="ddl_Status" Width="100%" Height="25px" runat="server" TabIndex="2"></asp:DropDownList>
                </div>
            <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                   User_Code:
                   </div>  
            <div class="col-sm-4" style="text-align:left;padding-left:5px;" >
                    <asp:TextBox style ="text-transform:uppercase"   ID="txt_User_Code"  ReadOnly="true"  runat="server"  Width="100%"></asp:TextBox>
                </div>
           
            </div>
         <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                    User Name:
                   </div>  
            <div class="col-sm-5" style="text-align:left;padding-left:5px;" tabindex="0" >
                     <asp:TextBox style ="text-transform:uppercase"   ID="txt_User_Name"  runat="server"  Width="100%"></asp:TextBox>
                </div>
            <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                  Password   :
                   </div>  
            <div class="col-sm-5" style="text-align:left;padding-left:5px;" >
                
                     <asp:TextBox style ="text-transform:uppercase"   ID="txt_User_pass"   runat="server"  Width="100%" TextMode="Password"></asp:TextBox>
                </div>    
            </div>
         <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                    User_Email:
                   </div>  
            <div class="col-sm-5" style="text-align:left;padding-left:5px;" tabindex="0" >
                     <asp:TextBox style ="text-transform:uppercase"   ID="txt_User_Email"   runat="server"  Width="100%" TextMode="Email"></asp:TextBox>
                </div>
            <div class="col-sm-1" style="text-align:right; vertical-align:central">   
                  Mobile No   :
                   </div>  
            <div class="col-sm-5" style="text-align:left;padding-left:5px;" >
                
                     <asp:TextBox style ="text-transform:uppercase"   ID="txt_User_Phno"   runat="server"  Width="100%" TextMode="Phone"></asp:TextBox>
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
           <div style="padding-left:50px" id="listview" class="col-sm-12" runat ="server">

           
             <table id="tblDataDetails" >
             

            <tr class="altRow">
                <td style="width:50px">
                    <b>Sno</b>
                </td>
                <td>
                    <b style="width:60px">User_Type</b>
                </td>
                 <td>
                    <b style="width:120px">Code</b>
                </td>
                 <td>
                    <b style="width:120px">Name</b>
                </td>
                 <td>
                    <b style="width:120px">Email</b>
                </td>
                 <td>
                    <b style="width:50px">Status</b>
                </td>
                 <td>
                    <b style="width:50px">Ph No</b>
                </td>
                <td>
                    <b style="width:50px">Action</b>
                </td>
              
            </tr>
            <asp:ListView ID="lstViewDetails" OnItemCommand="lstViewDetails_ItemCommand"  runat="server">
                <ItemTemplate>
                 
                    <tr class="<%#(Container.DataItemIndex+1)%2==0?" altrow":"normalrow"%>">
                         <td>
                            <%#Eval("User_ID") %>
                        </td>
                        <td>
                            <%#Eval("User_Type") %>
                        </td>
                        <td>
                            <%#Eval("User_Code") %>
                        </td>
                        <td>
                            <%#Eval("User_Name") %>
                        </td>
                        <td>
                            <%#Eval("User_Email") %>
                        </td>
                        <td>
                            <%#Eval("User_Status") %>
                        </td>

                        <td>
                            <%#Eval("User_Phno") %>
                        </td>
                        <td>
                            <%--//==== Here we have used CommandName property to distinguish which button is 
                        clicked and we have passed our primary key to CommandArgument property. ====//--%>
                            <asp:ImageButton ID="imgBtnEdit" CommandName="Edt" ToolTip="Edit a record." CommandArgument='<%#Eval("User_ID") %>' runat="server" ImageUrl="icons/edit.png" Width="10px" Height="10px"/>
                            <asp:ImageButton ToolTip="Delete a record." OnClientClick="javascript:return confirm('Are you sure to delete record?')" ID="imgBtnDelete" CommandName="Del" CommandArgument='<%#Eval("User_ID") %>' runat="server" ImageUrl="icons/delete.png" Width="10px" Height="10px"></asp:ImageButton>
                        </td>
                        
                    </tr>
                  

                </ItemTemplate>
            </asp:ListView>

</table>

               <br /><br />
             </div>

              </div>


</asp:Content>
