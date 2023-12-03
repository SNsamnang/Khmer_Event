<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Buy.aspx.cs" Inherits="Buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="userContain" Runat="Server">
    <style>
        .detail-containner{
            width:90%;
            height:430px;
            margin:0 auto;
            color:black;
            background-color:whitesmoke;
            border-radius:10px;
        }
        .img{
            width:90%; 
            height:350px;
            margin:0 auto;
            margin-top:20px;
            border-radius:5px;
        }
        .btn-Buy{
            width:60%;
            height:25px;
            border-radius:5px;
            border:none;
            background-color:green;
            color:white
        }
        .btn-Buy:hover{
            background-color:blue;
            cursor:pointer;
        }
        .refresh{
            width:16px;
            height:100%;
            cursor:pointer;
        }
        .refresh:hover{
            background-color:white;
            border-radius:50%;
            box-shadow:1px 1px 1px #808080
        }
    </style>
            <div class="detail-containner">
                <table width="90%" style="margin:0 auto">
                    <tr>
                        <asp:ListView ID="lview1" runat="server">
                            <ItemTemplate>
                               <td width="40%">
                                     <asp:image CssClass="img" ID="ImageURL" runat="server" ImageUrl='<%# Eval("ImageURL") %>'/>
                                </td>
                            </ItemTemplate>
                        </asp:ListView>
                        <td width="35%">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server" ID="lblMes"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height:50px">
                                    <td colspan="2">
                                        <asp:label ID="txtEventName" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="Blue" />
                                    </td>                                  
                                </tr>
                                <tr>
                                    <td width="50%">Douration :</td>
                                    <td>
                                        <asp:Label ID="txtDouration" runat="server" ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date :</td>
                                    <td>
                                        <asp:Label ID="txtDateStart" runat="server" ForeColor="Black" />
                                        &nbsp;To&nbsp
                                        <asp:Label ID="txtDateEnd" runat="server" ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Place :</td>
                                    <td>
                                        <asp:Label ID="txtPlace" runat="server" ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Contact :</td>
                                    <td>
                                        <asp:Label ID="txtContact" runat="server"  ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>User Name :</td>
                                    <td>
                                        <asp:Label ID="txtUserName" runat="server" ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Price per one :</td>
                                    <td>
                                        <asp:label ID="txtPrice" runat="server"  ForeColor="Black" Visible="false" />
                                        <asp:label ID="txtPrice1" runat="server"  ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Total QTY :</td>
                                    <td>
                                        <asp:label ID="txtTotalQTY" runat="server" ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Your Phone :</td>
                                    <td>
                                        <asp:TextBox ID="txtPhone" runat="server" ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>QTY :</td>
                                    <td style="height:100%">
                                        <asp:TextBox ID="txtQTY" runat="server" ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <asp:textbox Visible="false" ID="txtId" runat="server" />
                                    </th>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <th>
                            <asp:Button CssClass="btn-Buy" runat="server" ID="btnBuy" Text="Buy Now" OnClick="btnBuy_Click"/>
                        </th>
                    </tr>
                </table>
            </div>
</asp:Content>

