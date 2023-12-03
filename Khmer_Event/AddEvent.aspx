<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="AddEvent.aspx.cs" Inherits="AddEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="userContain" Runat="Server">
    <style>
        .btnAdd{
            background-color:cornflowerblue;
            color:black;
            border-radius:5px;
            height:30px;
            border:none;
            cursor:pointer
        }
        .btnAdd:hover{
            background-color:blue;
            color:white
        }
        .inputfile{
            border-radius:5px;
            border: 1px solid black;
        }
        .inputfile:focus{
            box-shadow:1px 1px 1px 1px #808080;
        }
    </style>
    <table width="100%">
        <tr>
            <td width="25%" ></td>
            <td width="50%">
                <table width="100%">
                    <tr>
                        <th colspan="2" style="font-family:'Times New Roman', Times, serif;font-size:24px">Please Fill The Information of Ticket</th>
                    </tr>
                    <tr>
                        <th colspan="2" style="padding:10px;font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="lblMessage"></asp:Label></th>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label1" Text="Event Name"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtEventName" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label2" Text="Douration"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtDoutration" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label3" Text="Date Start"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtDateStart" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label4" Text="Date End"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtDateEnd" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label5" Text="Location Place"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtPlace" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label6" Text="Price"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtPrice" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label11" Text="QTY"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtQTY" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label7" Text="Description"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtDescription" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label8" Text="Contact"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtContact" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label9" Text="Link"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:TextBox CssClass="inputfile" runat="server" ID="txtLink" Width="100%" Height="25px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:Label runat="server" ID="label10" Text="Image Of Event"></asp:Label></td>
                        <td style="font-family:'Times New Roman', Times, serif;font-size:18px"><asp:FileUpload runat="server" ID="imgUpload" Width="100%" Height="25px"></asp:FileUpload></td>
                    </tr>
                    </table>
                <center>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button CssClass="btnAdd" runat="server" ID="cmdAdd" Text="Add New Event" OnClick="cmdAdd_Click" />
                </center>
            </td>
            <td width="25%"></td>
        </tr>
    </table>
</asp:Content>

