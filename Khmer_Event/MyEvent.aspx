<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="MyEvent.aspx.cs" Inherits="MyEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="userContain" Runat="Server">
    <asp:ListView ID="lview1" runat="server" GroupPlaceholderID="groupPlacehoder1" ItemPlaceholderID="itemPlaceholder1" OnPagePropertiesChanging="ListView1_PagePropertiesChanging" OnItemCommand="ListView1_ItemCommand">
      <LayoutTemplate>
        <asp:PlaceHolder runat="server" ID="groupPlacehoder1"></asp:PlaceHolder>
     </LayoutTemplate>
     <GroupTemplate>
        <tr> 
            <%--<tr id="itemPlaceholder1" runat="server">--%>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder1"></asp:PlaceHolder>
        </tr>
     </GroupTemplate>
        <ItemTemplate>
        <style>
            .contain-card{
                width:22%;
                height:420px;
                float:left;
                margin-left:2%;
                border:1px solid black;
                border-radius:5px;
                box-shadow:2px 1px 1px 1px #cecbcb;
                color:black;
                margin-top:20px;
                margin-bottom:5px;
            }
            .img-card{
                width:90%;
                height:200px;
                margin:auto;
                margin-top:10px;
                border-radius:5px;
                box-shadow:2px 1px 1px 1px #cecbcb;
            }
            .img{
                width:100%; 
                height:100%;
                border-radius:5px;
            }
            .text-card{
                width:90%;
                margin:0 auto;
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
            .next{
                color:black;
            }
        </style>
        <div style="width:94%;margin:0 auto;color:black">
            <div class="contain-card">
                <div class="img-card">
                    <asp:image CssClass="img" ID="Image1" runat="server" ImageUrl='<%# Eval("ImageURL") %>'/>
                </div>
                <br />
                <div class="text-card">
                    <table width="100%">
                        <tr>
                            <th colspan="2"><asp:Hyperlink ID="Hyperlink1" runat="server" Text='<%# Eval("EventName") %>' Font-Bold="True" Font-Size="12pt" ForeColor="Black" Target="_blank" /></th>
                        </tr>
                        <tr>
                            <td width="50%">Douration:</td>
                            <th><asp:Label ID="TourTypesLabel" runat="server" Text='<%# Eval("Douration") %>' /></th>
                        </tr>
                        <tr>
                            <td>DateStart:</td>
                            <th><asp:Label ID="CityLabel" runat="server" Text='<%# Eval("DateStart") %>' /></th>
                        </tr>
                        <tr>
                            <td>Price:</td>
                            <th><asp:Label ID="DurationLabel" runat="server" Text='<%# Eval("Price")+" $" %>' /></th>
                        </tr>
                        <tr>
                            <td>Place:</td>
                            <th><asp:Label ID="DesLabel" runat="server" Text='<%# Eval("Place") %>' /></th>
                        </tr>
                        <tr>
                            <td><asp:textbox Visible="false" ID="txtId" runat="server" Text='<%# Eval("EventID") %>' /></td>
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:Button CssClass="btn-Buy" runat="server" ID="btnBuy" Text="Buy Now" />
                            </th>                               
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:LinkButton CommandName="Details" ID="Details" Text="See More" runat="server" Font-Bold="false" ForeColor="#009999" Font-Italic="true"></asp:LinkButton>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:LinkButton CommandName="editImage" ID="editImage" Text="Edit Image" runat="server" Font-Bold="false" ForeColor="#009999" Font-Italic="true"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:LinkButton CommandName="editInfo" ID="editInfo" Text="Edit Info" runat="server" Font-Bold="false" ForeColor="#009999" Font-Italic="true"></asp:LinkButton>
                            </th>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </ItemTemplate>
    </asp:ListView>
</asp:Content>

