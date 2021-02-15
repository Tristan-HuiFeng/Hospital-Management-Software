<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Administrator.Master" AutoEventWireup="true" CodeBehind="ViewAllAppointments.aspx.cs" Inherits="Hospital_Management_Software.Customer.ViewAllAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Patient_ID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Patient_ID" HeaderText="Patient_ID" InsertVisible="False" ReadOnly="True" SortExpression="Patient_ID" />
            <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
            <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
            <asp:BoundField DataField="NRIC" HeaderText="NRIC" SortExpression="NRIC" />
            <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
            <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
            <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" />
            <asp:BoundField DataField="Citizenship" HeaderText="Citizenship" SortExpression="Citizenship" />
            <asp:BoundField DataField="Postal_Code" HeaderText="Postal_Code" SortExpression="Postal_Code" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Allergies" HeaderText="Allergies" SortExpression="Allergies" />
            <asp:BoundField DataField="Medical_History" HeaderText="Medical_History" SortExpression="Medical_History" />
            <asp:BoundField DataField="Phone_Number" HeaderText="Phone_Number" SortExpression="Phone_Number" />
            <asp:BoundField DataField="Home_Number" HeaderText="Home_Number" SortExpression="Home_Number" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Created_Date" HeaderText="Created_Date" SortExpression="Created_Date" />
            <asp:BoundField DataField="Update_Date" HeaderText="Update_Date" SortExpression="Update_Date" />
            <asp:BoundField DataField="Appt_Reason" HeaderText="Appt_Reason" SortExpression="Appt_Reason" />
            <asp:BoundField DataField="Appt_Time" HeaderText="Appt_Time" SortExpression="Appt_Time" />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [PATIENT]"></asp:SqlDataSource>
</asp:Content>
