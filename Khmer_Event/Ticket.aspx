<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Ticket.aspx.cs" Inherits="Ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminContain" Runat="Server">
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
                <td></td>
                <td>EventName</td>
                <td>Douration</td>
                <td>Place</td>
                <td>Own Event</td>
                <td>Contact</td>
                <td>Price</td>
                <td>QTY</td>
                <td>TotalPrice</td>
                <td>Own Ticket</td>
                <td>Status</td>
                <td>View</td>
                <td>Drop</td>
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
                        <td width="30%">
                            <asp:Label runat="server" ID="txtEventName" Text='<%# Eval("EventName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtDouration" Text='<%# Eval("Douration") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtPlace" Text='<%# Eval("Place") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtOwnEvent" Text='<%# Eval("Username") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtContact" Text='<%# Eval("Contace") %>'></asp:Label>
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
                            <asp:Label runat="server" ID="txtOwnTicket" Text='<%# Eval("CurrentUser") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="txtStatus" Text='<%# Eval("Status") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton CommandName="lView" runat="server" ID="lView" Text="View Ticket" ForeColor="Blue"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton CommandName="lDrop" runat="server" ID="lDrop" Text="Delete" ForeColor="Blue"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>

