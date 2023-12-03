<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TopUp.aspx.cs" Inherits="TopUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminContain" Runat="Server">
    <style>
        .btn-style{
            background-color:green;
            color:white;
            border-radius:5px;
            cursor:pointer;
            border:none;
            width:120px;
            height:25px;
        }
        .btn-style:hover{
            background-color:blue;
        }
    </style>
    <div style="width:40%;margin:0 auto;height:200px;background-color:whitesmoke;border-radius:10px">
        <table width="100%">
            <tr>
                <th colspan="2">
                    <h4>Input Top Up</h4>
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:Label runat="server" ID="txtID" Visible="false"></asp:Label>
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:TextBox runat="server" ID="txtTotalAmount" Visible="false"></asp:TextBox>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:Label runat="server" ID="label" Text="Top Up :"></asp:Label>
                </th>
                <th>
                    <asp:TextBox runat="server" ID="txtAmountAdd"></asp:TextBox>
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox runat="server" ID="chb" AutoPostBack="true" Text="check for confirm"/>
                </td>
            </tr>
            <tr>
                <th colspan="2">
                    <br />
                    <asp:LinkButton CssClass="btn-style" runat="server" ID="btnTopup" Text="Top Up" OnClick="btnTopup_Click"></asp:LinkButton>
                </th>
            </tr>
        </table>
    </div>
</asp:Content>

