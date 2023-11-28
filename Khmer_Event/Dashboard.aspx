<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminContain" Runat="Server">
    <style>
        .card-dashboard{
            width:27%;
            height:200px;
            background-color:cornflowerblue;
            float:left;
            margin:0 auto;
            margin-left:4%;
            margin-top:30px;
            border-radius:10px
        }
    </style>
    <div style="width:80%;margin:auto;text-align:center">
        <h3>DashBoard Admin !!!</h3>
        <a href="ListAllEvent.aspx">
        <div class="card-dashboard">
            <div style="margin-top:90px;color:white;font-size:large">
                <asp:Label runat="server" ID="label1" Text="All Event :"></asp:Label>
                <asp:label runat="server" ID="dashboardevent" Text=""></asp:label>
            </div>
        </div>
        </a>
        <a href="ListAllUser.aspx">
        <div class="card-dashboard">
            <div style="margin-top:90px;color:white;font-size:large">
                <asp:Label runat="server" ID="label2" Text="All User :"></asp:Label>
                <asp:label runat="server" ID="dashboarduser" Text=""></asp:label>
            </div>
        </div>
        </a>
        <a href="Ticket.aspx">
        <div class="card-dashboard">
            <div style="margin-top:90px;color:white;font-size:large">
                <asp:Label runat="server" ID="label3" Text="All Ticket :"></asp:Label>
                <asp:label runat="server" ID="dashboardticket" Text=""></asp:label>
            </div>
        </div>
        </a>
    </div>
</asp:Content>

