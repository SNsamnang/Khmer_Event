<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddAmount.aspx.cs" Inherits="AddAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminContain" Runat="Server">
    <style>
        .textbox{
            width:200px;
            height:20px;
            
        }
        .userbalance{
            background-color:#6cc6f5;
        }
        .userbalance:hover{
            background-color:#51a1d0;          
        }
        .btnAdd{
            width:80px;
            height:30px;
            background-color:dodgerblue;
            border-radius:5px;
            color:white;
            cursor:pointer
        }
        .btnAdd:hover{
            background-color:green;
        }
        .Search{
            border: 1px solid black;
            border-radius:5px;
            height:22px
        }
        .btn{
            color:white;
            background-color:green;
            cursor:pointer;
        }
        .btn:hover{
            background-color:blue;
        }
    </style>
    <div style="width:34%;float:left;margin-left:1%">
    <br />
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:Label ForeColor="Black" runat="server" ID="lblMes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="label1" Text="Amount :"></asp:Label></td>
            <td><asp:TextBox CssClass="textbox Search" runat="server" ID="txtAmount"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="label2" Text="Spent :"></asp:Label></td>
            <td><asp:TextBox CssClass="textbox Search" runat="server" ID="txtSpent"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label8" Text="User Name :"></asp:Label></td>
            <td>
                <asp:DropDownList runat="server" CssClass="Search" ID="txtUser" Font-Size="14px" Width="205px" Height="25px" DataSourceID="tourTypeDS" DataTextField="UserName" DataValueField="UserId" ></asp:DropDownList>
                <asp:SqlDataSource ID="tourTypeDS" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" ProviderName="<%$ ConnectionStrings:LocalSqlServer.ProviderName %>" SelectCommand="SELECT * FROM [dbo].[aspnet_Users]"></asp:SqlDataSource>
            </td>        
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="label3" Text="Balance:"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="textbox Search" runat="server" ID="txtBalance"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox runat="server" ID="chkgr" Text="Check For Confirm" AutoPostBack="true"/>
            </td>
        </tr>
        <tr>
            <th colspan="2">
                <asp:Button CssClass="btnAdd" runat="server" ID="btnBalance" Text="Add New" OnClick="btnBalance_Click" />
            </th>
        </tr>
    </table>
    </div>
    <div style="width:63%;float:left;margin-right:2%">
        <table width="100%">
            <tr>
                <th colspan="6">Balance Of User</th>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:DropDownList runat="server" CssClass="Search" ID="DropDownList1" Font-Size="14px" Width="300px" Height="25px" DataSourceID="tourTypeDS" DataTextField="UserName" DataValueField="UserId" ></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" ProviderName="<%$ ConnectionStrings:LocalSqlServer.ProviderName %>" SelectCommand="SELECT * FROM [dbo].[aspnet_Users]"></asp:SqlDataSource>
                </td>
                <td colspan="1">
                    <asp:Button runat="server" ID="btnlist" Text="List By User" CssClass="Search" Width="90px" OnClick="btnlist_Click"/>
                </td>
                <td colspan="1">
                    <asp:Button runat="server" ID="txtRefresh" Text="Refresh" CssClass="Search" Width="90px" OnClick="txtRefresh_Click"/>
                </td>
            </tr>
            <tr style="background-color:whitesmoke">
                <td style="width:5%"></td>
                <td style="width:18%">Amount</td>
                <td style="width:18%">Spent</td>
                <td style="width:19%">Balance</td>
                <td style="width:20%">UserId</td>
                <td style="width:10%">Edit</td>
                <td style="width:10%">Delete</td>
            </tr>       
                <asp:ListView ID="view1" runat="server" GroupPlaceholderID="groupPlacehoder1" ItemPlaceholderID="itemPlaceholder1" OnItemCommand="lview1_ItemCommand" OnPagePropertiesChanging="view1_PagePropertiesChanging">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="groupPlacehoder1"></asp:PlaceHolder>
                </LayoutTemplate>
                <GroupTemplate> 
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder1"></asp:PlaceHolder>
                </GroupTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblMes"></asp:Label>
                            </td>
                        </tr>
                        <tr class="userbalance">
                            <td>
                                <asp:TextBox Visible="false" runat="server" ID="txtID" Text='<%# Eval("ID") %>'></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtAmount1" Text='<%# Eval("Amount")+"$" %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtSpent1" Text='<%# Eval("Spent")+"$" %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="txtBalance1" Text='<%# Eval("Balance")+"$" %>'></asp:Label>
                            </td>
                            <td>                                
                                <asp:Label runat="server" ID="txtUser1" Text='<%# Eval("UserName") %>'  ForeColor="black"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton ForeColor="black" CommandName="Edit" runat="server" ID="Label7" Text="Edit"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ForeColor="black" CommandName="Delete" runat="server" ID="btnDelete" Text="Delete"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>    
        </table>
    </div>
</asp:Content>

