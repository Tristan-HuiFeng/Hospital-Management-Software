<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Customer.Master" AutoEventWireup="true" CodeBehind="allFeedbackAdmin.aspx.cs" Inherits="Hospital_Management_Software.Customer.allFeedbackAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowSorting="True" Width="100%">
        <Columns>
            <asp:BoundField DataField="Feedback_ID" HeaderText="Feedback_ID" ReadOnly="True" SortExpression="Feedback_ID" InsertVisible="False" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
            <asp:BoundField DataField="Feedback" HeaderText="Feedback" SortExpression="Feedback" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyDB %>" SelectCommand="SELECT * FROM [FEEDBACK]"></asp:SqlDataSource>
    <br />
    <!-- <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /> -->
</asp:Content>
