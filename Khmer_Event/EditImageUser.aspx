<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="EditImageUser.aspx.cs" Inherits="EditImageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="userContain" Runat="Server">
    <style>
        .btnUpdate{
            background-color:cornflowerblue;
            color:black;
            border-radius:5px;
            height:30px;
            border:none;
            cursor:pointer
        }
        .btnUpdate:hover{
            background-color:blue;
            color:white
        }
    </style>
       <table style="width:50%;margin:0 auto;">
            <tr>
                <td style="vertical-align:top; text-align:center"> <h3>Please Choose New Image For Update! </h3></td></tr>
            <tr>
            <td style="vertical-align:top; text-align:center"> 
                <h2>Your Current Image</h2>
                <asp:ListView runat="server" ID="lview1" >
                     <ItemTemplate>
                        <asp:image Width="100%" ID="mImgUrl" runat="server" 
                            ImageUrl='<%# Eval("ImageURL") %>' />
                        
                    </ItemTemplate>
                </asp:ListView> 
            </td>
         </tr>
        <tr>
            <td style="text-align:center; padding:10px">
                <asp:textbox Visible="false" ID="txtEventID" runat="server" />
                <h3>Choose The New Image :<asp:FileUpload ID="fmImg" runat="server" /></h3> 
                <asp:Button runat="server" CssClass="btnUpdate" Text="Update the Image" ID="cmdEditImg" OnClick="cmdEditImg_Click" />
            </td>
        </tr>
        </table>
</asp:Content>

