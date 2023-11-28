<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminContain" Runat="Server">
    <br />
    <center>
    <asp:Login runat="server"></asp:Login>
    <br />
    </center>
    <a style="color:blue" href="SignUp.aspx">Sign Up New User</a>
</asp:Content>

