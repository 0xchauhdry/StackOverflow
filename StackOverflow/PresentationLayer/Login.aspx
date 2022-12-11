<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StackOverflow.PresentationLayer.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/Login.js?v=5" defer></script>
    <style>
        #togglePassword{
            margin-left: -30px; 
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <section class="vh-100" style="background-color: #508bfc;">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="card shadow-2-strong" style="border-radius: 1rem;">
                            <div class="card-body p-5 text-center">

                            <h3 class="mb-5">Log in</h3>

                            <div class="form-outline mb-4">
                                <%--<input type="text" id="username" class="form-control form-control-lg" placeholder="Username"/>--%>
                                <asp:TextBox ClientIDMode="Static" runat="server" ID="usernameLogin" CssClass="form-control form-control-lg" placeholder="Username" />  
                            </div>

                            <div class="form-outline mb-4 d-flex align-items-center">
                                <asp:TextBox ClientIDMode="Static" runat="server" type="password" ID="passwordLogin" CssClass="form-control form-control-lg" placeholder="Password" />
                                <%--<input type="password" id="passwordLogin" class="form-control form-control-lg" placeholder="Password"/>--%>
                                <i class="far fa-eye" id="togglePassword"></i>
                            </div>
                            <div class="form-outline mb-4">
                                <asp:Label ClientIDMode="Static" runat="server" ID="lblusernameLogin" CssClass="form-label text-danger" />
                            </div>

                            <asp:button runat="server" id="loginBtn" CssClass="btn btn-primary btn-lg btn-block" OnClientClick="javascript:return ValidateLogin()" OnClick="login" Text="Login"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
