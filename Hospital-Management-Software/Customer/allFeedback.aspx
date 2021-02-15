<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Customer.Master" AutoEventWireup="true" CodeBehind="allFeedback.aspx.cs" Inherits="Hospital_Management_Software.Customer.allFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowSorting="True" Width="100%">
        <Columns>
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Feedback" HeaderText="Feedback" SortExpression="Feedback" />
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Subject], [Name], [Feedback], [DateCreated] FROM [FEEDBACK]"></asp:SqlDataSource>
</asp:Content>
