<%@ Page Title="Hospital Home" Language="C#" MasterPageFile="~/Views/layout/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hospital_Management_Software._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dashboard-hero">
        <div>
            <p class="eyebrow">Hospital Management Software</p>
            <h1>Connected care for patients, staff and administrators.</h1>
            <p class="lead">The platform brings appointments, patient information and operational workflows together in one place so hospital teams can move faster with less friction.</p>
            <div class="hero-actions">
                <a class="btn btn-primary btn-lg" href="~/About">About the system</a>
                <a class="btn btn-outline-secondary btn-lg" href="~/Contact">Contact the team</a>
            </div>
        </div>
    </div>

    <div class="section-grid">
        <asp:Repeater ID="SectionRepeater" runat="server" DataSource="<%# Sections %>">
            <ItemTemplate>
                <article class="feature-card">
                    <div class="feature-icon"><%# Eval("Icon") %></div>
                    <h2><%# Eval("Title") %></h2>
                    <p><%# Eval("Description") %></p>
                    <ul>
                        <asp:Repeater ID="HighlightRepeater" runat="server" DataSource="<%# Eval("Highlights") %>">
                            <ItemTemplate>
                                <li><%# Container.DataItem %></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </article>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
