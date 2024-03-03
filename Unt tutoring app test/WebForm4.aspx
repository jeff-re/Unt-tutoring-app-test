<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Unt_tutoring_app_test.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Bookable Appointment Schedule</title>
</head>
<body>
    
        <div>
            <h1>Bookable Appointment Schedule</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                EmptyDataText="No appointments available." ShowHeader="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBook" runat="server" Text="Book" CommandName="Book" CommandArgument='<%# Eval("AppointmentID") %>'></asp:LinkButton>
                            <asp:Label ID="lblTime" runat="server" Text='<%# Eval("AppointmentTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

</body>
</html>



</asp:Content>
