<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .rotate{
            height:350px;
            color:white;
            font-size:14px;
            text-align:center;
            margin-left:24px;
            writing-mode:vertical-lr;
            transform:rotate(180deg)
        }
        .styleImg{
            width:450px;
            height:450px;
            margin-left:-94px;
            margin-top:-50px;
            border-radius:50%;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        }   
    </style>
</head>
<body>
    <form runat="server">
        <div style="width:80%;margin:0 auto;background-color:#498649;border-radius:10px;height:350px">
           <div style="width:93%;height:350px;float:left;overflow:hidden;">
              <div style="float:left">
                  <asp:ListView ID="ListView1" runat="server">
                      <ItemTemplate>
                          <asp:Image runat="server" CssClass="styleImg" ID="imgEvent" ImageUrl='<%# Eval("ImageURL") %>'/>
                      </ItemTemplate>
                  </asp:ListView>
              </div>
              <div style="width:80px;height:80px;background-color:#2c932a;border-radius:50%;float:left;margin-top:200px;margin-left:-60px;border: 1px solid white">
                  <table width="100%">
                      <tr style="height:65px">
                          <th>
                              <asp:Label runat="server" ID="txtTotalPrice" Font-Bold="true" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                          </th>
                      </tr>
                  </table>
              </div>
              <div style="width:462px;height:100%;float:left;margin-left:30px">
                <table width="100%">
                    <tr>
                        <th colspan="2" style="height:100px">
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="XX-Large" ID="txtEventName"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label" Text="Douration :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtDouration"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label1" Text="Date :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtDateStart"></asp:Label>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtDateEnd"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label3" Text="Location Event :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtPlace"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label4" Text="Own Event :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtUsername"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label5" Text="Contact :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtContact"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label6" Text="Price per one :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtPrice"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label7" Text="Quantity :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtQTY"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height:100px">
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label8" Text="Own Ticket :"></asp:Label>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtCurrentUser"></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ForeColor="White" ID="label9" Text="My Phone :"></asp:Label>
                            <asp:Label runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" ID="txtContactUser"></asp:Label>
                        </td>
                    </tr>
                </table>
              </div>
              
              </div>
              <div style="width:7%;height:350px;background-color:black;float:left;border-radius:0px 10px 10px 0px">
                 <p class="rotate">CopyRight From ©2023 KhmerEvent. All rights reserved.</p>
              </div>
          </div>
    </form>
</body>
</html>
