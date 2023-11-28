<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="EditUserBalance.aspx.cs" Inherits="EditUserBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminContain" Runat="Server">
    <style>
           .textbox{
            width:200px;
            height:20px;
            }
    </style>
    <div style="width:34%;margin:0 auto">
    <br />
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:Label ForeColor="Black" runat="server" ID="lblMes"></asp:Label>
            </td>
        </tr>
        <tr>
            <th colspan="2">
                <asp:Label runat="server" ID="txtID"></asp:Label>
            </th>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="label1" Text="Amount :"></asp:Label></td>
            <td><asp:TextBox CssClass="textbox" runat="server" ID="txtAmount"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="label2" Text="Spent :"></asp:Label></td>
            <td><asp:TextBox CssClass="textbox" runat="server" ID="txtSpent"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label8" Text="User Name :"></asp:Label></td>
            <td>
                <asp:DropDownList runat="server" ID="txtUser" Font-Size="14px" Width="207px" Height="25px" DataSourceID="tourTypeDS" DataTextField="UserName" DataValueField="UserId" ></asp:DropDownList>
                <asp:SqlDataSource ID="tourTypeDS" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" ProviderName="<%$ ConnectionStrings:LocalSqlServer.ProviderName %>" SelectCommand="SELECT * FROM [dbo].[aspnet_Users]"></asp:SqlDataSource>
            </td>        
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="label3" Text="Balance:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="textbox" runat="server" ID="txtBalance"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox runat="server" ID="chkAgr" Text="Check For Confirm" AutoPostBack="true" OnCheckedChanged="chkAgr_CheckedChanged"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnBalance" Text="UpDate" OnClick="btnBalance_Click"/>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

