<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ListAllUser.aspx.cs" Inherits="ListAllUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminContain" Runat="Server">
    <div style="width:80%;margin:auto">
        <table width="100%">
            <tr>
                <th>User Name</th>
            </tr>
            <asp:ListView ID="lview1" runat="server" GroupPlaceholderID="groupPlacehoder1" ItemPlaceholderID="itemPlaceholder1" OnPagePropertiesChanging="lview1_PagePropertiesChanging">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="groupPlacehoder1"></asp:PlaceHolder>
                </LayoutTemplate>
                <GroupTemplate> 
                    <%--<tr id="itemPlaceholder1" runat="server">--%>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder1"></asp:PlaceHolder>
                </GroupTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="username" Font-Bold="true" Font-Size="18px" Text='<%# Eval("UserName") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
    </div>
</asp:Content>

