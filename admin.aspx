<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplicationLibraryManagement.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                
                <div class="card">
                    
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/adminuser.png" />
                                </center>
                            </div>

                        </div>





                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                    </center>
                            </div>

                        </div>
                


                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>

                        </div>



                        <div class="row">
                            <div class="col">

                                <label>Admin ID</label>
                                <div class="mb-3">
                                    
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"  runat="server" placeholder="Admin ID"></asp:TextBox>

                                </div>


                                <label>Password</label>
                                <div class="mb-3" >

                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password" ></asp:TextBox>

                                </div>



                                <div class="mb-3 d-grid gap-2">

                                    <asp:Button ID="Button1" class="btn btn-success btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />
                                   

                                </div>
                                
                            </div>

                        </div>
                   
                        </div>

                </div>


                <a href="homepage.aspx"><< Back to Home</a> <br /><br />


            </div>
        </div>
    </div>


</asp:Content>
