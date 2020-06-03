<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Video_News.aspx.cs" Inherits="IGTNewsfNation.Video_News" %>
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
                          Home>Breaking News Entry 
                       </div>
         
         </div>
           
        <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-2" style="text-align:right; vertical-align:central">   
                    Video News Title:
                   </div>  
            <div class="col-sm-10" style="text-align:left;padding-left:5px;" tabindex="0" >
                    <asp:TextBox style =""   ID="txt_Video_News_Title"  runat="server"  Width="100%"></asp:TextBox>
                </div>
           
            </div>
         <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-2" style="text-align:right; vertical-align:central">   
                    Video YouTube URL:
                   </div>  
            <div class="col-sm-5" style="text-align:left;padding-left:5px;" tabindex="0" >
                    <asp:TextBox style =""   ID="txt_Video_News_URL"  runat="server"  Width="100%"></asp:TextBox>
                </div>
           
               <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                Images:
                    </div>
                     <div class="col-sm-2" style="text-align:left; padding-left:5px;" >
                                       
                       
                   <asp:FileUpload AllowMultiple="false"  ID="fileuploadTitle" runat="server" />
                  
                </div>


            </div>


         <div class="col-sm-12" style="text-align:left;padding:5px;">
               <div class="col-sm-2" style="text-align:right; vertical-align:central">   
                    Video News Desc:
                   </div>  
            <div class="col-sm-10" style="text-align:left;padding-left:5px;" tabindex="0" >
                    <asp:TextBox TextMode="MultiLine"   ID="txt_Video_News_Desc"   runat="server"  Width="100%"></asp:TextBox>
                </div>
           
            </div>

         <div class="col-sm-12" style="text-align:left;padding:5px;">

         <div class="col-sm-2" style="text-align:right; vertical-align:central">   
                    IP TV Video:
                   </div>  
            <div class="col-sm-2" style="text-align:left;padding-left:5px;" >
                
                    <asp:DropDownList ID="ddl_IPYTTV" Width="100%" Height="25px" runat="server" TabIndex="2"></asp:DropDownList>
                </div>

             <div class="col-sm-2" style="text-align:right; vertical-align:central">   
                     Viral Video:
                   </div>  
            <div class="col-sm-2" style="text-align:left;padding-left:5px;" >
                
                    <asp:DropDownList ID="ddl_Viral_Video" Width="100%" Height="25px" runat="server" TabIndex="2"></asp:DropDownList>
                </div>

                <div class="col-sm-2" style="text-align:right; vertical-align:central">   
                     Status:
                   </div>  
            <div class="col-sm-2" style="text-align:left;padding-left:5px;" >
                
                    <asp:DropDownList ID="ddl_Status" Width="100%" Height="25px" runat="server" TabIndex="2"></asp:DropDownList>
                </div>
                
             </div>
              

          <div class="col-sm-12" style="text-align:left;padding:5px;">

          <div class="col-sm-2" style="text-align:right;padding-left:5px;" >
                    Remarks:    </div>
            
            <div class="col-sm-10" style="text-align:left" >
                
                      <asp:TextBox style =""  Width="100%" ID="txt_Remarks" runat="server" TabIndex="9" ></asp:TextBox>
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
                <td style="width:5%">
                    <b>Sno</b>
                </td>
                 <td>
                    <b style="width:20%">Video News Title</b>
                </td>
                <td>
                    <b style="width:20%">Video YouTube URL</b>
                </td>

                <td>
                    <b style="width:30%">Video News Desc</b>
                </td>
                 <td>
                    <b style="width:5%">IP TV</b>
                </td>
                 <td>
                    <b style="width:5%">Viral</b>
                </td>

                 
                 <td>
                    <b style="width:5%">Status</b>
                </td>
                 <td>
                    <b style="width:10%">Remarks</b>
                </td>
                <td>
                    <b style="width:5%">Action</b>
                </td>
              
            </tr>
            <asp:ListView ID="lstViewDetails" OnItemCommand="lstViewDetails_ItemCommand"  runat="server">
                <ItemTemplate>
                 
                    <tr class="<%#(Container.DataItemIndex+1)%2==0?" altrow":"normalrow"%>">
                         <td>
                            <%#Eval("Video_News_ID") %>
                        </td>
                        <td>
                            <%#Eval("Video_News_Title") %>
                        </td>

                        <td>
                            <%#Eval("Video_News_URL") %>
                        </td>
                       
                       <td>
                            <%#Eval("Video_News_Desc") %>
                        </td>

                       
                        
                        <td>
                            <%#Eval("IPYTTV") %>
                        </td>
                        
                        <td>
                            <%#Eval("Viral_Video") %>
                        </td>

                        <td>
                            <%#Eval("Status") %>
                        </td>

                        <td>
                            <%#Eval("Remarks") %>
                        </td>
                        <td>
                            <%--//==== Here we have used CommandName property to distinguish which button is 
                        clicked and we have passed our primary key to CommandArgument property. ====//--%>
                            <asp:ImageButton ID="imgBtnEdit" CommandName="Edt" ToolTip="Edit a record." CommandArgument='<%#Eval("Video_News_ID") %>' runat="server" ImageUrl="icons/edit.png" Width="10px" Height="10px"/>
                            <asp:ImageButton ToolTip="Delete a record." OnClientClick="javascript:return confirm('Are you sure to delete record?')" ID="imgBtnDelete" CommandName="Del" CommandArgument='<%#Eval("Video_News_ID") %>' runat="server" ImageUrl="icons/delete.png" Width="10px" Height="10px"></asp:ImageButton>
                        </td>
                        
                    </tr>
                  

                </ItemTemplate>
            </asp:ListView>

</table>

               <br /><br />
             </div>

              </div>
    </asp:Content>
