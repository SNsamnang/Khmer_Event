<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="MyTicket.aspx.cs" Inherits="MyTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="userContain" Runat="Server">
    <style>
        .row-ticket{
            background-color:white;
        }
        .row-ticket:hover{
            background-color:aqua;
            cursor:pointer
        }
    </style>
    <div Style="width:98%;margin:0 auto;background-color:#67cfe7;border-radius:5px">
        <table width="100%">
            <tr>
                <td>ID</td>
                <td>EventName</td>
                <td>Place</td>
                <td>Price</td>
                <td>QTY</td>
                <td>TotalPrice</td>
                <td>Status</td>
                <td>Pay</td>
                <td>View</td>
            </tr>
            <asp:ListView ID="lview1" runat="server" GroupPlaceholderID="groupPlacehoder1" ItemPlaceholderID="itemPlaceholder1" OnPagePropertiesChanging="lview1_PagePropertiesChanging" OnItemCommand="lview1_ItemCommand">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="groupPlacehoder1"></asp:PlaceHolder>
                </LayoutTemplate>
                <GroupTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder1"></asp:PlaceHolder>
                </GroupTemplate>
                <ItemTemplate>
                    <tr class="row-ticket">
                        <td>
                            <asp:TextBox runat="server" ID="txtID" Visible="false" Text='<%# Eval("TicketID") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtEventName" Text='<%# Eval("EventName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtPlace" Text='<%# Eval("Place") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtPrice" Text='<%# Eval("Price")+" $" %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtQTY" Text='<%# Eval("QTY") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtTotalPrice" Text='<%# Eval("TotalPrice")+" $" %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtStatus" Text='<%# Eval("Status") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton CommandName="lPay" runat="server" ID="lPay" Text="PayNow" ForeColor="Green"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton CommandName="lView" runat="server" ID="lView" Text="View Ticket" ForeColor="Blue"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>

