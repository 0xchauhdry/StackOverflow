<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="StackOverflow.PresentationLayer.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/Signup.js?v=10" defer></script>
    <style>
        #togglePassword, #toggleConPassword{
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

                            <h3 class="mb-5">Sign Up</h3>

                            <div class="form-outline mb-4">
                                <%--<input type="text" id="Name" class="form-control form-control-lg" placeholder="Name"/>--%>
                                <asp:TextBox ClientIDMode="Static" runat="server" ID="Name" CssClass="form-control form-control-lg" placeholder="Name" /> 
                            </div>

                            <div class="form-outline mb-4">
                                <%--<input type="email" id="email" class="form-control form-control-lg" data-bs-toggle="tooltip" placeholder="Email" />--%>
                                <asp:TextBox ClientIDMode="Static" type="email" runat="server" ID="Email" CssClass="form-control form-control-lg" placeholder="Email" /> 
                            </div> 

                            <div class="form-outline mb-4">
                                <%--<input type="text" id="username" class="form-control form-control-lg" placeholder="Username"/>--%>
                                <asp:TextBox ClientIDMode="Static" runat="server" ID="Username" CssClass="form-control form-control-lg" placeholder="Username" /> 
                            </div>

                            <div class="form-outline mb-4 d-flex align-items-center">
                                <asp:TextBox ClientIDMode="Static" runat="server" type="password" ID="Password" CssClass="form-control form-control-lg" placeholder="Password (Must be 8-15 characters)" />
                                <%--<input type="password" id="password" class="form-control form-control-lg" placeholder="Password (Must be 8-15 characters)"/>--%>
                                <i class="far fa-eye" id="togglePassword"></i>
                            </div>

                            <div class="form-outline mb-4 d-flex align-items-center">
                                <asp:TextBox ClientIDMode="Static" runat="server" type="password" ID="confirmPassword" CssClass="form-control form-control-lg" placeholder="Confirm Password" />
                                <%--<input type="password" id="confirmPassword" class="form-control form-control-lg" placeholder="Confirm Password"/>--%>
                                <i class="far fa-eye" id="toggleConPassword"></i>
                            </div>
                            <div class="form-outline mb-4">
                                <asp:Label ClientIDMode="Static" runat="server" ID="lblusernameSignup" CssClass="form-label text-danger" />
                            </div>

                            <asp:button runat="server" id="signupBtn" CssClass="btn btn-primary btn-lg btn-block" OnClientClick="javascript:return CheckValidations()" OnClick="signup" Text="Sign Up"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
