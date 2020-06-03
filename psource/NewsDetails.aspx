<%@ Page validateRequest="false" Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="JECRC_PMall.NewsDetails" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div  class="col-sm-12" style ="   background-color: #f2f2f2; padding:0px;margin:0px; line-height:140%;min-height:400px">  
   
    <div class="col-sm-12"  style="background-color: #0f3955; color:white; line-height:140%;font-size:20px; font-family:Cambria; " >
                     Home>News Details Entry 
    </div>

        <div class="col-sm-12" style="text-align:left;padding:10px;">
                <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                    News Type:
                    </div>
             <div class="col-sm-3" style="text-align:left; padding-left:5px;" >
                     <asp:DropDownList ID="ddl_News_Type" Width="100%" Height="25px" runat="server" OnSelectedIndexChanged="ddl_News_Type_SelectedIndexChanged" AutoPostBack="true" TabIndex="0"></asp:DropDownList>
                </div>
            <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                News Code: 
                    </div>
            <div class="col-sm-7" style="text-align:left; padding-left:5px;" >
                    <asp:TextBox style ="text-transform:uppercase"   ID="txt_News_Code" runat="server" Width="100%"></asp:TextBox>
                </div>
           
            </div>
        
               <div class="col-sm-12" style="text-align:left;padding:10px;">
                 <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                Title:
                    </div>
                     <div class="col-sm-11" style="text-align:left; padding-left:5px;" >

                   
                  <asp:TextBox style ="text-transform:uppercase; padding-left:10px"   ID="txt_Title" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txt_Title_TextChanged" TabIndex="1" MaxLength="100"></asp:TextBox>
               </div>
                          </div>
          <div class="col-sm-12" style="text-align:left;padding:10px;">
                 <div class="col-sm-1" style="text-align:right; vertical-align:central">  
              English  Title:
                    </div>
                     <div class="col-sm-11" style="text-align:left; padding-left:5px;" >

                   
                  <asp:TextBox style ="text-transform:uppercase; padding-left:10px"   ID="txt_ETitle" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txt_ETitle_TextChanged" TabIndex="2" MaxLength="90"></asp:TextBox>                                            
               </div>
                          </div>

           <div class="col-sm-12" style="text-align:left;padding:10px;">
                 <div class="col-sm-1" style="text-align:right; vertical-align:central">  
              Introduction:
                    </div>
                     <div class="col-sm-11" style="text-align:left; padding-left:5px;" >                  
                  <asp:TextBox style ="text-transform:uppercase; padding-left:10px"   ID="txt_Intro" runat="server" Width="100%" TabIndex="3" MaxLength="160" ></asp:TextBox>                                            
               </div>
                          </div>
           <div class="col-sm-12" style="text-align:left;padding:10px;">
                 <div class="col-sm-1" style="text-align:right; vertical-align:central">  
              Keywords:
                    </div>
                     <div class="col-sm-11" style="text-align:left; padding-left:5px;" >

                   
                  <asp:TextBox style ="text-transform:uppercase; padding-left:10px"   ID="txt_Keyword" runat="server" Width="100%" TabIndex="4" MaxLength="200" ></asp:TextBox>                                            
               </div>
                          </div>

           <div class="col-sm-12" style="text-align:left;padding:10px;">
                 <div class="col-sm-1" style="text-align:right; vertical-align:central">  
              Meta Desc:
                    </div>
                     <div class="col-sm-11" style="text-align:left; padding-left:5px;" >

                   
                  <asp:TextBox style ="text-transform:uppercase; padding-left:10px"   ID="txt_Desc" runat="server" Width="100%" MaxLength="200"  ></asp:TextBox>                                            
               </div>
                          </div>


          <div class="col-sm-12" style="text-align:left;padding:10px;">
              <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                State: 
                    </div>
            <div class="col-sm-3" style="text-align:left; padding-left:5px;" >
                
                    <asp:DropDownList ID="ddl_State"  AutoPostBack="true" Width="100%" Height="25px" runat="server" OnSelectedIndexChanged="ddl_State_SelectedIndexChanged"></asp:DropDownList>
                </div>

              <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                City: 
                    </div>
            <div class="col-sm-3" style="text-align:left; padding-left:5px;" >
                
                    <asp:DropDownList ID="ddl_City" Width="100%" Height="25px" runat="server"></asp:DropDownList>
                </div>


          <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                Breaking: 
                    </div>
            <div class="col-sm-3" style="text-align:left; padding-left:5px;" >
                
                    <asp:DropDownList ID="ddl_Breaking" Width="100%" Height="25px" runat="server"></asp:DropDownList>
                </div>

              </div>


          <div class="col-sm-12" style="text-align:left;padding:10px; vertical-align: middle">    
                    <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                Images:
                    </div>
                     <div class="col-sm-2" style="text-align:left; padding-left:5px;" >
                                       
                       
                   <asp:FileUpload AllowMultiple="false"  ID="fileuploadTitle" runat="server" />
                  
                </div>
                <div class="col-sm-2" style="text-align:left; padding-left:5px;" >
                                       
                       
                   <asp:FileUpload AllowMultiple="true"  ID="fileuploadimages" runat="server" />
                  
                </div>
              <div class="col-sm-2" style="text-align:left; padding-left:5px;" >
                  <asp:Button ID="btn_Upload" runat="server" Text="Upload"  BorderStyle="Outset" Font-Bold="True" Font-Names="Monotype Corsiva" Font-Size="Large" ForeColor="#000099" OnClick="btn_Upload_Click" CssClass="btn-default active" TabIndex="10" />
                  </div>
               <div class="col-sm-4" style="text-align:left; padding-left:5px;" >
                <asp:Label ID="lblImageMes" runat="server" Text="Message" ForeColor="Red"></asp:Label>
                    </div>
                    </div>
        

                <div class="col-sm-12" style="text-align:left;padding:10px; vertical-align: middle">    
                    <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                Story Details:
                    </div>
                     <div class="col-sm-11" style="text-align:left; padding-left:5px;" >

                                              
                   
                   <FTB:FreeTextbox  ID="txt_Story_Details"   runat="server" Height="400px" Width="100%" AllowHtmlMode="True"  EnableHtmlMode="True" ButtonOverImage="true" ImageGalleryUrl="ftb.imagegallery.aspx?rif=/imagespath/&cif=/newsImages/"
  Focus="False" OnTextChanged="txt_Story_Details_TextChanged" ImageGalleryPath="/newsImages" ButtonDownImage="True" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"  ValidateRequestMode="Disabled"  />
                </div>
                    </div>
        
         


         <div class="col-sm-12" style="text-align:left;padding:10px;">
               <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                 Written_By: 
                    </div>
            <div class="col-sm-3" style="text-align:left;padding-left:5px;" >
                   <asp:TextBox style ="text-transform:uppercase"   ID="txt_Written_By" runat="server" Width="100%"></asp:TextBox>
                </div>
             <div class="col-sm-1" style="text-align:right; vertical-align:central">  
               Covered_By:  
                    </div>
            <div class="col-sm-3" style="text-align:left;padding-left:5px;" >
                
                    <asp:TextBox style ="text-transform:uppercase"   ID="txt_Covered_By" runat="server" Width="100%"></asp:TextBox>
                </div>
             <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                Photo_By: 
                    </div>
             <div class="col-sm-3" style="text-align:left;padding-left:5px;" >
                
                    <asp:TextBox style ="text-transform:uppercase"   ID="txt_Photo_By" runat="server" Width="100%"></asp:TextBox>
                </div>
            </div>
         <div class="col-sm-12" style="text-align:left;padding:10px;">
                <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                Status:
                    </div>

            <div class="col-sm-3" style="text-align:left;padding-left:5px;" >
                    <asp:DropDownList ID="ddl_Status" Width="100%" Height="25px" runat="server" TabIndex="2"></asp:DropDownList>
                </div>
              <div class="col-sm-1" style="text-align:right; vertical-align:central">  
                 Remarks: 
                    </div>
            <div class="col-sm-7" style="text-align:left;padding-left:5px;" >
                
                    <asp:TextBox style ="text-transform:uppercase"   ID="txt_Remarks" runat="server" Width="100%"></asp:TextBox>
                </div>
             
            </div>

        <div class="col-sm-12" style="text-align:left;padding:10px;">
                <div class="col-sm-1" style="text-align:right; vertical-align:central">  
               link_name:
                    </div>
                     <div class="col-sm-11" style="text-align:left; padding-left:5px;" >

                    
                  <asp:TextBox style ="text-transform:uppercase; padding-left:10px"   ID="txt_link_name" runat="server" Width="100%"></asp:TextBox>
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
