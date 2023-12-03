<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="userContain" Runat="Server">
    <style>
        .btn-style{
            background-color:green;
            color:white;
            border-radius:5px;
            cursor:pointer;
            border:none;
            width:50px;
            height:22px;
        }
        .btn-style:hover{
            background-color:blue;
        }
    </style>
    <div style="width:30%;height:200px;margin:0 auto;background-color:whitesmoke;border-radius:10px">
        <table width="100%">
            <tr><th colspan="2">PayMent Method</th></tr>
            <tr><th colspan="2"><asp:Label runat="server" ID="lblMes"></asp:Label></th></tr>
            <tr>              
                <th width="40%" colspan="2">
                    <asp:Label runat="server" ID="txtID" Visible="false"></asp:Label>
                </th>
            </tr>
            <tr style="height:40px">
                <th>
                    <asp:Label runat="server" ID="label1" Text="Total Pay :"></asp:Label>
                </th>
                <th>
                    <asp:TextBox runat="server" ID="txtPayMent" Width="100px"></asp:TextBox> $
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:TextBox runat="server" ID="txtTotalSpent" Visible="false"></asp:TextBox>
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:TextBox runat="server" ID="txtBalance" Visible="false"></asp:TextBox>
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="txtStatus" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="2" style="height:60px">
                    <asp:CheckBox runat="server" ID="chb" AutoPostBack="true" Text="check for confirm"/>
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:Button CssClass="btn-style" runat="server" ID="btnPay" Text="Pay" OnClick="btnPay_Click"/>
                </th>
            </tr>
        </table>
    </div>
</asp:Content>

