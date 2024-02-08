<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageRole.aspx.cs" Inherits="Unt_tutoring_app_test.ManageRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function OpenDiag() {
            setTimeout(function () {
                $('#UserPermissions').modal();
            }, 200);
        }

        function ShowPermissionAddSection() {
            $("#MainContent_divAddNewUserPermission").css({ "display": "block", "margin-top": "20px", "margin-bottom": "20px", "border-style": "solid", "border-width": "0.5px", "border-color": "lightgray" });
            $("#MainContent_lnkAddUserPermission").css({ "display": "none" });
            return false;
        }
        function HidePermissionAddSection() {
            $("#MainContent_divAddNewUserPermission").css({ "display": "none", "margin-top": "20px", "margin-bottom": "20px", "border-style": "solid", "border-width": "0.5px", "border-color": "lightgray" });
            $("#MainContent_lnkAddUserPermission").css({ 'display': 'block' });
            return false;
        }
    </script>
    <div class="row" style="margin-top: 10px;">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Roles</h4>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvRole" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="RoleDataSource" ShowHeaderWhenEmpty="True"
                        BackColor="White" BorderStyle="Solid" BorderWidth="0.5px" CellPadding="4" BorderColor="LightGray"
                        ForeColor="Black" GridLines="Horizontal" AllowPaging="true" AllowSorting="true" PageSize="10" Width="100%"
                        OnSelectedIndexChanged="gvRole_SelectedIndexChanged" EnablePersistedSelection="true" OnRowDataBound="gvRole_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="UID" SortExpression="Id"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>

                        </Columns>

                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle CssClass="pagination-ys" />
                        <%--<RowStyle BackColor="#F7F7DE" />--%>
                        <RowStyle BackColor="WhiteSmoke" />
                        <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />

                    </asp:GridView>
                </div>
            </div>
            <div>
                <asp:SqlDataSource runat="server" ID="RoleDataSource" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="select * from [dbo].[AspNetRoles]"></asp:SqlDataSource>
            </div>
            <div>
                <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
                </p>

                <p class="text-success">
                    <asp:Literal runat="server" ID="SuccessMessage" />
                </p>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Add/Edit Role</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label runat="server" AssociatedControlID="txtRoleName">Role Name</asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="txtRoleName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRoleName"
                                CssClass="text-danger" ErrorMessage="Role Name is required." Display="Dynamic" />
                        </div>

                    </div>

                </div>
                <div class="panel-footer" style="text-align: right;">
                    <div class="btn-group">
                        <asp:Button ID="btnSave" runat="server" Text="Save As New Role" CommandArgument="Create" CssClass="btn btn-default" OnClick="btnSave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument="Update" CssClass="btn btn-default" OnClick="btnSave_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument="Delete" CssClass="btn btn-default" OnClick="btnSave_Click" OnClientClick=" return confirm('Are you sure you want to delete the record?');" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Users in role 
                        <b>
                            <asp:Literal runat="server" ID="ltRoleName"></asp:Literal></b>
                    </h4>
                    <asp:TextBox ID="txtCurrentUserId" runat="server" Text="test" Style="display: none;"></asp:TextBox>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="RoleId,UserId" DataSourceID="UserDataSource" ShowHeaderWhenEmpty="True"
                        BackColor="White" BorderStyle="Solid" BorderColor="LightGray" BorderWidth="0.5px" CellPadding="4"
                        ForeColor="Black" GridLines="Horizontal" AllowPaging="true" AllowSorting="true" PageSize="10" Width="100%" OnRowCommand="gvUsers_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Email" HeaderText="Email/Username" SortExpression="Email"></asp:BoundField>
                            <asp:TemplateField HeaderText="Command">
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <asp:Button ID="btnDeleteUserFromGroup" runat="server" Text="Delete" CssClass="btn btn-default" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to remove the use from this role?');" AlternateText="Delete" />
                                        <asp:LinkButton ID="lnkViewPermission" runat="server" CssClass="btn btn-default" CommandName="OpenModDialog" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserId") %>' Text="View/Assign Permissions" Visible='<%# !IsAdminUser() %>' />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle CssClass="pagination-ys" />
                        <%--<RowStyle BackColor="#F7F7DE" />--%>
                        <RowStyle BackColor="WhiteSmoke" />
                        <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />

                    </asp:GridView>

                </div>
                <div>
                    <asp:SqlDataSource runat="server" ID="UserDataSource" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="select b.RoleId, a.Id UserId, a.Email from [dbo].[AspNetUsers] a inner join [dbo].[AspNetUserRoles] b on a.Id = b.UserId inner join [dbo].[AspNetRoles] c on b.RoleId = c.Id where c.Name = @RoleName"
                        DeleteCommand="delete from [dbo].[AspNetUserRoles] where RoleId=@RoleId and UserId=@UserId" OnDeleted="UserDataSource_Deleted">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtRoleName" Name="RoleName" PropertyName="Text" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="RoleId" Type="String" />
                            <asp:Parameter Name="UserId" Type="String" />
                        </DeleteParameters>
                    </asp:SqlDataSource>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Add User in Role <b>
                        <asp:Literal runat="server" ID="ltUserRoleName"></asp:Literal></b></h4>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvUserSelectList" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId" DataSourceID="UserNotInRoleDataSource" ShowHeaderWhenEmpty="True"
                        BackColor="White" BorderStyle="Solid" BorderColor="LightGray" BorderWidth="0.5px" CellPadding="4"
                        ForeColor="Black" GridLines="Horizontal" AllowPaging="true" AllowSorting="true" PageSize="10" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" Checked='<%# Eval("Select") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" Visible="false" />
                            <asp:BoundField DataField="Email" HeaderText="Email/Username" SortExpression="Email" />
                        </Columns>
                        <%--<RowStyle BackColor="#F7F7DE" />--%>
                        <RowStyle BackColor="WhiteSmoke" />
                    </asp:GridView>
                    <div>
                        <asp:SqlDataSource runat="server" ID="UserNotInRoleDataSource" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
                            SelectCommand="select cast(0 as bit) [Select], a.Id UserId, a.Email from [dbo].[AspNetUsers] a left join [dbo].[AspNetUserRoles] b on a.Id = b.UserId left join [dbo].[AspNetRoles] c on b.RoleId = c.Id where (c.Name is null or c.Name <> @RoleName) and b.UserId is null">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtRoleName" Name="RoleName" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnAddUserInRole" runat="server" Text="Add User Role" CssClass="btn btn-default" CommandArgument="AddUserRole" OnClick="btnAddUserInRole_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="UserPermissions" tabindex="-1" role="dialog" aria-labelledby="UserPermissionsTitle" aria-hidden="true">
        <div class="modal-dialog" role="document" style="min-width: 780px">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="UserPermissionsTitle">User Permissions</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <asp:GridView ID="gvUserPermissions" runat="server" AutoGenerateColumns="False" DataSourceID="UserPermissionsSource" ShowHeaderWhenEmpty="True"
                        BackColor="White" BorderStyle="Solid" BorderColor="LightGray" BorderWidth="0.5px" CellPadding="4"
                        ForeColor="Black" GridLines="Both" AllowPaging="false" AllowSorting="true" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelectPermission" runat="server" Checked='<%# Eval("Select") %>' Enabled='<%# HttpContext.Current.User.IsInRole("admin") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClaimType" HeaderText="Type" SortExpression="ClaimType" />
                            <asp:BoundField DataField="ClaimValue" HeaderText="Name" SortExpression="ClaimValue" />
                        </Columns>
                        <RowStyle BackColor="WhiteSmoke" />
                    </asp:GridView>
                    <div style="margin-top: 15px;">
                        <asp:LinkButton Width="100%" ID="lnkAddUserPermission" runat="server" CssClass="btn btn-default" Text="Add Permission" Visible='<%# !IsAdminUser() %>' OnClientClick="return ShowPermissionAddSection()" />
                    </div>
                    <div id="divAddNewUserPermission" runat="server" style="margin-top: 20px; margin-bottom: 20px; display: none; border-style: solid; border-width: 0.5px; border-color: lightgray">
                        <div class="row" style="margin-top:15px;margin-bottom:15px;">
                            <div class="col-sm-5">
                                <asp:Label ID="lblPermissionType" runat="server" Text="Type"></asp:Label>&nbsp;<asp:TextBox ID="txtPermissionType" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-5">
                                <asp:Label ID="lblValue" runat="server" Text="Value"></asp:Label>&nbsp;<asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                &nbsp;<asp:Button ID="btnSaveUserPermission" runat="server" Text="Save" OnClick="btnSaveUserPermission_Click" />
                                <asp:LinkButton ID="lnkHide" runat="server" OnClientClick="return HidePermissionAddSection();">Hide</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSavePermission" runat="server" Text="Save" CssClass="btn btn-default" CommandArgument="SavePermission" OnClick="btnSavePermission_Click" />
                </div>
            </div>
            <div>
                <asp:SqlDataSource runat="server" ID="UserPermissionsSource" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'
                    SelectCommand="select cast(case when t2.Id is null then 0 else 1 end as bit) [Select], t1.* from (select distinct ClaimType, ClaimValue from [dbo].[AspNetUserClaims]) t1 left join (select * from [dbo].[AspNetUserClaims] where UserId = @UserId) t2 on t1.ClaimValue = t2.ClaimValue">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtCurrentUserId" Name="UserId" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>