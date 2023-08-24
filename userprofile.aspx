<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplicationLibraryManagement.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
         $(document).ready(function () {
             $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                
                <div class="card">
                    
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>

                        </div>



                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>

                                    <span>Account Status - </span>
                                    <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your Status"></asp:Label>

                                    </center>
                            </div>

                        </div>
                


                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="mb-3">
                                    
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox3"  runat="server" placeholder="Full Name"></asp:TextBox>

                                </div>
                            </div>


                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="mb-3" >

                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Password" TextMode="Date" ></asp:TextBox>

                                </div>
                            </div>
                        </div>





                         <div class="row">
                            <div class="col-md-6">
                                <label>Contact No.</label>
                                <div class="mb-3">
                                    
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"  runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>

                                </div>
                            </div>


                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="mb-3" >

                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Email ID" TextMode="Email" ></asp:TextBox>

                                </div>
                            </div>
                        </div>




                         <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="mb-3">
                                    
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                            <asp:ListItem Text="Option 1" Value="option1" />
                                            <asp:ListItem Text="Option 2" Value="option2" />
                                             <asp:ListItem Text="Option 3" Value="option3" />
                                            <asp:ListItem Text="Option 4" Value="option4" />
                                        <asp:ListItem Text="Option 30" Value="option30" />
                                    </asp:DropDownList>
                                 

                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>City</label>
                                <div class="mb-3" >

                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City" ></asp:TextBox>

                                </div>
                            </div>


                             <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="mb-3" >

                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number" ></asp:TextBox>

                                </div>
                            </div>




                             <div class="col">
                                <label>Full Address</label>
                                <div class="mb-3">
                                    
                                    
                                    <asp:TextBox CssClass="form-control" ID="TextBox5"  runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>

                                </div>
                            </div>




                        </div>


                        <div class="row">
                            <div class="col">
                            <center>
                          <span class="badge rounded-pill text-bg-info">Login Credentials</span>

                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="mb-3">
                                    
                                    
                                    <asp:TextBox class="form-control" ID="TextBox8"  runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="mb-3" >

                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Password" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="mb-3" >

                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col">

                           <div class="mb-3 d-grid gap-2 " >
                                    <center>
                                   <a href="usersignup.aspx" class="btn btn-block d-grid gap-2">
                                       <asp:Button class="btn btn-primary btn-lg"  ID="Button1" runat="server" Text="Update" OnClick="Button1_Click1" /></a>
                                    </center>
                                </div>

                                
                            </div>

                        </div>
                   
                        </div>

                </div>


                <a href="homepage.aspx"><< Back to Home</a> <br /><br />

                    
            </div>

            <div class="col-md-7">

                <div class="card">
                    
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books.png" />
                                </center>
                            </div>

                        </div>



                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issue Books</h4>

                                   
                                    <asp:Label class="badge rounded-pill text-bg-info" ID="Label2" runat="server" Text="Your Books Info"></asp:Label>

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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                            </div>

                        </div>

                   
                        </div>

                </div>

            </div>


        </div>
    </div>

</asp:Content>
