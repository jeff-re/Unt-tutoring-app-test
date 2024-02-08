using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unt_tutoring_app_test
{
    public partial class ManageRoles : System.Web.UI.Page
    {
        private void SelectRoleGridRow(int rowIndex)
        {
            if (gvRole.Rows.Count > 0)
            {
                gvRole.SelectedIndex = rowIndex;
                txtRoleName.Text = gvRole.Rows[rowIndex].Cells[1].Text;
                ltRoleName.Text = txtRoleName.Text;
                ltUserRoleName.Text = txtRoleName.Text;
                btnDelete.Enabled = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SuccessMessage.Text = string.Empty;
            ErrorMessage.Text = string.Empty;

            if (!IsPostBack)
            {
                if (gvRole.SelectedRow == null)
                {
                    SelectRoleGridRow(0);
                }
            }

            if (gvRole.SelectedRow == null)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                var roleManager = new RoleManager<IdentityRole>(
                      new RoleStore<IdentityRole>(new Models.ApplicationDbContext()));

                var ctrl = sender as Button;
                if (ctrl.CommandArgument == "Create")
                {
                    if (!roleManager.RoleExists(txtRoleName.Text.Trim()))
                    {
                        var role = new IdentityRole();
                        role.Name = txtRoleName.Text.Trim();
                        var result = roleManager.Create(role);
                        if (result.Succeeded)
                        {
                            SuccessMessage.Text = "User role created successfully.";
                            gvRole.DataBind();
                            foreach (GridViewRow row in gvRole.Rows)
                            {
                                if (row.Cells[1].Text == role.Name)
                                {
                                    SelectRoleGridRow(row.RowIndex);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            ErrorMessage.Text = result.Errors != null && result.Errors.Any() ? string.Join("<br />", result.Errors) : "Failed to create role";
                        }
                    }
                }
                else if (ctrl.CommandArgument == "Update")
                {
                    if (gvRole.SelectedRow == null)
                    {
                        ErrorMessage.Text = "Please select a row to update";
                    }
                    else if (!roleManager.RoleExists(txtRoleName.Text.Trim()))
                    {
                        var role = roleManager.FindById(gvRole.SelectedRow.Cells[0].Text);
                        role.Name = txtRoleName.Text.Trim();
                        var result = roleManager.Update(role);
                        if (result.Succeeded)
                        {
                            SuccessMessage.Text = "User role updated successfully.";
                            gvRole.DataBind();
                        }
                        else
                        {
                            ErrorMessage.Text = result.Errors != null && result.Errors.Any() ? string.Join("<br />", result.Errors) : "Failed to update role";
                        }
                    }
                }
                else if (ctrl.CommandArgument == "Delete")
                {
                    if (gvRole.SelectedRow == null)
                    {
                        ErrorMessage.Text = "Please select a row to delete";
                    }
                    else
                    {
                        var role = roleManager.FindById(gvRole.SelectedRow.Cells[0].Text);
                        if (role != null)
                        {
                            var result = roleManager.Delete(role);
                            if (result.Succeeded)
                            {
                                txtRoleName.Text = string.Empty;
                                SuccessMessage.Text = "User role deleted successfully.";
                                var selectedRowIndex = gvRole.SelectedIndex;
                                gvRole.DataBind();

                                if (gvRole.Rows.Count <= selectedRowIndex)
                                {
                                    --selectedRowIndex;
                                }

                                SelectRoleGridRow(selectedRowIndex);

                            }
                            else
                            {
                                ErrorMessage.Text = result.Errors != null && result.Errors.Any() ? string.Join("<br />", result.Errors) : "Failed to delete role";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = ex.Message;
            }

        }

        protected void gvRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gvRole.SelectedRow;
            if (row != null)
            {
                txtRoleName.Text = row.Cells[1].Text;
                ltRoleName.Text = txtRoleName.Text;
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        protected void gvRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Change the mouse cursor to Hand symbol to show the user the cell is selectable
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';this.style.cursor='Pointer'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Attach the click event to each cells
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvRole, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnAddUserInRole_Click(object sender, EventArgs e)
        {
            if (gvRole.SelectedRow != null)
            {
                var roleManager = new RoleManager<IdentityRole>(
                      new RoleStore<IdentityRole>(new Models.ApplicationDbContext()));
                foreach (GridViewRow item in gvUserSelectList.Rows)
                {
                    if (item.RowType == DataControlRowType.DataRow)
                    {
                        var ctrlChkBx = item.FindControl("chkSelect") as CheckBox;
                        if (ctrlChkBx != null && ctrlChkBx.Checked)
                        {
                            IdentityUserRole identityUserRole = new IdentityUserRole();
                            identityUserRole.RoleId = gvRole.SelectedRow.Cells[0].Text;
                            identityUserRole.UserId = gvUserSelectList.DataKeys[item.RowIndex].Values[0].ToString();
                            var role = roleManager.FindById(identityUserRole.RoleId);
                            role.Users.Add(identityUserRole);
                            roleManager.Update(role);
                        }
                    }
                }

                gvUsers.DataBind();
                gvUserSelectList.DataBind();
            }
        }

        protected void UserDataSource_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            gvUserSelectList.DataBind();
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OpenModDialog")
            {
                var lnkBtn = e.CommandSource as LinkButton;
                if (lnkBtn.ID.EndsWith("lnkAddNewPermission"))
                {
                    divAddNewUserPermission.Attributes.Add("style", "display:block;");
                    gvUserPermissions.Visible = false;
                }
                else
                {
                    divAddNewUserPermission.Attributes.Add("style", "display:none;");
                    gvUserPermissions.Visible = true;
                }
                txtCurrentUserId.Text = e.CommandArgument.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenUserClaimDiag", "OpenDiag()", true);
            }
        }

        public bool IsAdminUser()
        {
            string userId = Convert.ToString(Eval("UserId"));
            var roleManager = new RoleManager<IdentityRole>(
                      new RoleStore<IdentityRole>(new Models.ApplicationDbContext()));

            var adminRole = roleManager.FindByName("admin");
            if (adminRole != null && adminRole.Users.Any(t => t.UserId == userId))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void btnSavePermission_Click(object sender, EventArgs e)
        {
            var appUserManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var claims = appUserManager.GetClaims(txtCurrentUserId.Text);
            foreach (GridViewRow item in gvUserPermissions.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    var ctrlChkBx = item.FindControl("chkSelectPermission") as CheckBox;
                    if (ctrlChkBx != null && ctrlChkBx.Checked)
                    {
                        if (!claims.Any(c => c.Value == item.Cells[2].Text))
                        {
                            var res = appUserManager.AddClaim(txtCurrentUserId.Text, new System.Security.Claims.Claim(item.Cells[1].Text, item.Cells[2].Text));
                        }
                    }
                    else
                    {
                        if (claims.Any(c => c.Value == item.Cells[2].Text))
                        {
                            var res = appUserManager.RemoveClaim(txtCurrentUserId.Text, new System.Security.Claims.Claim(item.Cells[1].Text, item.Cells[2].Text));
                        }
                    }
                }
            }
        }

        protected void btnSaveUserPermission_Click(object sender, EventArgs e)
        {
            var appUserManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var claims = appUserManager.GetClaims(txtCurrentUserId.Text);
            if (!claims.Any(c => c.Value == txtValue.Text.Trim()))
            {
                var res = appUserManager.AddClaim(txtCurrentUserId.Text, new System.Security.Claims.Claim(txtPermissionType.Text, txtValue.Text.Trim()));
                if (res.Succeeded)
                {
                    gvUserPermissions.DataBind();
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenUserClaimDiag", "OpenDiag()", true);
        }
    }
}