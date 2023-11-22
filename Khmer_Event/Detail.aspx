<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="Detail" %>

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
    </style>
    <asp:ListView ID="lview1" runat="server">
        <ItemTemplate>
            <div class="detail-containner">
                <table width="90%" style="margin:0 auto">
                    <tr>
                        <td width="40%">
                            <asp:image CssClass="img" ID="ImageURL" runat="server" ImageUrl='<%# Eval("ImageURL") %>'/>
                        </td>
                        <td width="35%">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:label ID="txtEventName" runat="server" Text='<%# Eval("EventName") %>' Font-Bold="True" Font-Size="14pt" ForeColor="Blue" />
                                    </td>                                  
                                </tr>
                                <tr>
                                    <td>Event ID :</td>
                                    <td>
                                        <asp:Label runat="server" ID="txtEventID" Text='<%# Eval("EventID") %>' ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="75%">Douration :</td>
                                    <td>
                                        <asp:Label ID="txtDouration" runat="server" Text='<%# Eval("Douration") %>' ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date Start :</td>
                                    <td>
                                        <asp:Label ID="txtDateStart" runat="server" Text='<%# Eval("DateStart") %>' ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date End :</td>
                                    <td>
                                        <asp:Label ID="txtDateEnd" runat="server" Text='<%# Eval("DateEnd") %>' ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Price :</td>
                                    <td>
                                        <asp:Label ID="txtPrice" runat="server" Text='<%# Eval("Price")+" $" %>' ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Place :</td>
                                    <td>
                                        <asp:Label ID="txtPlace" runat="server" Text='<%# Eval("Place") %>' ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Desciption :</td>
                                    <td>
                                        <asp:Label ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Contact :</td>
                                    <td>
                                        <asp:Label ID="txtContact" runat="server" Text='<%# Eval("Contace") %>' ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Link :</td>
                                    <td>
                                        <asp:Hyperlink ID="txtLink" runat="server" Text='<%# Eval("Link") %>' NavigateUrl='<%# Eval("Link") %>' ForeColor="Blue" Target="_blank" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>User Name :</td>
                                    <td>
                                        <asp:Label ID="txtUserName" runat="server" Text='<%# Eval("Username") %>' ForeColor="Black" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <asp:textbox Visible="false" ID="txtId" runat="server" Text='<%# Eval("EventID") %>' />
                                    </th>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <th width="15%">
                            <asp:Button CssClass="btn-Buy" runat="server" ID="btnBuy" Text="Buy Now" />
                        </th>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

