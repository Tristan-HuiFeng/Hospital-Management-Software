<%@ Page Title="" Language="C#" MasterPageFile="~/Views/layout/Administrator.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Hospital_Management_Software.Administrator.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.23/css/jquery.dataTables.css">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.23/js/jquery.dataTables.js"></script>

    <script type="text/javascript">



        function populateData() {
            $.ajax({
                url: '<%= ResolveUrl("UserList.aspx/populateTable") %>',
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: {},
                async: false,
                success: function (data) {

                    console.log("data received:");
                    console.log(data);

                    var table = $('#userListTable').DataTable();

                    table.rows.add(
                        jQuery.parseJSON(data.d)

                        //[{"AccountID":"JH LEE","Name":"Internal meed","Role":"doc","Department":"Doctor"},{"AccountID":"Matthew Goh","Name":"Director","Role":"admin","Department":"IT"}]


                    ).draw();

                },
                failure: function (response) {
                    alert(response.d);
                }

            });


        }



        $(document).ready(function () {
            var table = $('#userListTable').DataTable({
                    "columns": [
                        { "data": "AccountID" },
                        { "data": "Name" },
                        { "data": "Role" },
                        { "data": "Department" }
                    ],


                });

            populateData();

            $('#userListTable tbody').on('click', 'tr', function () {
                console.log(table.row(this).data());
                console.log(table.row(this).data().AccountID);
                window.location = "UserAccountInformation.aspx?UserId=" + table.row(this).data().AccountID;
            });


        });



    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 60px">

        <h3>User List</h3>
        <hr />

        <div class="mt-3 mb-3">
            <asp:Label ID="lb_debugger" Style="background-color: #f8d7da" runat="server" Text="Message to be displayed here"></asp:Label>
        </div>

        <!--
        <div class="d-flex">
            <div class="mr-auto p-2">

                <div class="form-group">
                    <asp:Label class="" ID="lb_search" runat="server" Text="Change Role:"></asp:Label>
                    <asp:TextBox ID="tb_search" class="form-control" runat="server"></asp:TextBox>
                </div>

            </div>

            <div class="p-2">
                <div class="form-group">
                    <asp:Label class="" Style="margin-top: auto; margin-bottom: auto;" ID="Label1" runat="server" Text="Sort By:"></asp:Label>
                    <asp:DropDownList CssClass="form-control align-middle" ID="ddl_sort" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>

        <asp:GridView ID="gv_userList" class="table myGrid" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="AccountID" HeaderText="AccountID" ReadOnly="True" />
                <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="role" HeaderText="Role" ReadOnly="True" />
                <asp:BoundField DataField="department" HeaderText="Department" ReadOnly="True" />

                <asp:CommandField AccessibleHeaderText="Manage_Account" CausesValidation="False" HeaderText="Manage Account" SelectText="Manage Account" ShowSelectButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>-->

        <table id="userListTable" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th>Account ID</th>
                    <th>Name</th>
                    <th>Role</th>
                    <th>Department</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Account ID</th>
                    <th>Name</th>
                    <th>Role</th>
                    <th>Department</th>
                </tr>
            </tfoot>
        </table>


    </div>







</asp:Content>
