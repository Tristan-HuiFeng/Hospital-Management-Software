<%@ Page Title="Staff Login" Language="C#" MasterPageFile="~/Views/layout/Site_No_Footer.Master" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="Hospital_Management_Software.Login.StaffLogin" %>

<asp:Content ID="Header1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../src/css/login.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
   

    <div class="limiter">
        <div class="container">
            <asp:Label ID="lb_loginError" class="alert alert-danger container" style="margin-top:100px;position:fixed;" runat="server" Text="Label"></asp:Label>
            <asp:PlaceHolder runat="server" ID="LoginStatus">
         </asp:PlaceHolder>
        </div>
        
        <div class="login-container">
            <div class="wrap-login">
                <p class="login-title">Staff Login</p>
                <div class="input-container">
                    <p>Login ID: </p>
                    <asp:TextBox spellcheck="false" class="login-tb" ID="tb_loginID" style="color:#000000" runat="server"></asp:TextBox>
                    <p>Password: </p>
                    <asp:TextBox class="login-tb" ID="tb_password" style="color:#000000" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button class="login-btn" ID="btn_SignIn" runat="server" Text="Login" OnClick="btn_SignIn_Click" />
                <div class="text-btm">
                    <asp:Label ID="Label1" runat="server" Text="Label">Forgot Password?</asp:Label>
                </div>
                

            </div>
            
        </div>
    </div>

    <!--
    <section style="overflow: hidden;">
    <div class="container-1 vertical-center">
        <div class="login-container">
            <div class="heading">
                
                <span class="form-title">Login</span>
                <div class="sign-up-link-container">
                    <a id="sign-up-link" href="/user/signup">Create Account</a> instead?
                </div>
            </div>
            <form novalidate method="POST" action="">
                <div class="">
                    <label for="email">Email</label>
                    <input type="text" class="form-control" id="email" name="email" value="">
                </div>

                <div class="">
                    <label for="password">Password</label>
                    <input type="password" class="form-control" id="password" name="password" value="">
                </div>

                <div class="container-1 form-elements">
                    <input type="Submit" name="submit" value="Login" class="btn form-button"/>
                </div>
            </form>
        </div>
    </div>
</section> -->
</asp:Content>