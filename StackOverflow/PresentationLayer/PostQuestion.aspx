<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/Site.Master" AutoEventWireup="true" CodeBehind="PostQuestion.aspx.cs" Inherits="StackOverflow.PresentationLayer.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/tagmanager/3.0.2/tagmanager.min.css">
    <link href = "https://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css"
         rel = "stylesheet">
    <script src="../Scripts/AddQuestion.js?v=1" defer></script>
    
    <script src = "https://code.jquery.com/jquery-1.10.2.js" defer></script>
    <script src = "https://code.jquery.com/ui/1.10.4/jquery-ui.js" defer></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tagmanager/3.0.2/tagmanager.min.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-100" style="background-color: #508bfc;">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="card shadow-2-strong" style="border-radius: 1rem;">
                            <div class="card-body p-5">

                            <h3 class="mb-3 text-center">Post New Question</h3>

                            <div class="form-outline mb-4">
                                <label for="title" class="form-label">Title:</label>
                                <asp:TextBox ClientIDMode="Static" runat="server" ID="title" CssClass="form-control form-control-lg" placeholder="Question Title" />
                                <%--<input type="text" id="title" class="form-control form-control-lg" placeholder="Title"/>--%>
                            </div>

                            <div class="form-outline mb-4">
                                <label for="textarea" class="form-label">Description:</label>
                                <asp:TextBox ClientIDMode="Static" runat="server" ID="textarea" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Description ..."/>
                                <%--<textarea class="form-control" id="textarea" rows="5" placeholder="Description ..."></textarea>--%>
                            </div> 

                            <div class="form-outline mb-4">
                                <label for="Tags" class="form-label">Tags:</label>
                                <asp:TextBox ClientIDMode="Static" runat="server" ID="Tags" CssClass="form-control form-control-lg tm-input" type="text" placeholder="Tags (Add Atleast One)" />
                                <asp:TextBox ClientIDMode="Static" runat="server" CssClass="d-none" ID="fieldTags" />
                                <%--<input type="text" id="Tags" class="form-control form-control-lg" placeholder="Tags"/>--%>
                            </div>
                            <div class="form-outline mb-4">
                                <asp:Label ClientIDMode="Static" runat="server" ID="lblTitle" CssClass="form-label text-danger" />
                            </div>

                            <asp:button runat="server" id="addQuestionBtn" CssClass="btn btn-primary btn-lg btn-block" OnClientClick="javascript:return ValidateQuestion()" OnClick="AddQuestion" Text="Add Question"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
