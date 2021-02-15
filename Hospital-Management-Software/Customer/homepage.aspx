<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Customer.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="Hospital_Management_Software.Customer.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width: 100%;">
            <tr>
                <td style="text-align:center">View Appointments</td>
            </tr>
            <tr>
                <td style="text-align:center"><asp:Label ID="lbl_noAppt" runat="server" Text="You currently have no appointments!"></asp:Label></td>
            </tr>
            <tr>
                                <td style="text-align:center"><asp:Label ID="lbl_Appt" Visible="false" runat="server" Text="You currently have an appointment made!"></asp:Label></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
<%--            <tr><td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="NRIC" HeaderText="NRIC" SortExpression="NRIC" />
                        <asp:BoundField DataField="Allergies" HeaderText="Allergies" SortExpression="Allergies" />
                        <asp:BoundField DataField="Medical_History" HeaderText="Medical_History" SortExpression="Medical_History" />
                        <asp:BoundField DataField="Appt_Time" HeaderText="Appt_Time" SortExpression="Appt_Time" />
                        <asp:BoundField DataField="Appt_Reason" HeaderText="Appt_Reason" SortExpression="Appt_Reason" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyDB %>" SelectCommand="SELECT [Appt_Time], [Appt_Reason], [Allergies], [Medical_History], [NRIC] FROM [PATIENT]"></asp:SqlDataSource>
            </td></tr>--%>
            <tr><td style="text-align:center"><asp:Label ID="lblAppointments" runat="server" Text="Label" Visible="false"></asp:Label></td></tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td style="text-align:center"><asp:Button ID="btn_makeAppt" runat="server" Text="Make / Edit Appointment" onclick="MakeAppt"/>
                    <asp:Button ID="btn_Logout" runat="server" Text="Logout" onclick="logout"/></td>
            </tr>
        </table>
</asp:Content>