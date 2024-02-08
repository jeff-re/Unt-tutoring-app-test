<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Unt_tutoring_app_test.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <!-- Your existing content goes here -->

        <!-- Button to schedule appointment -->
        <asp:Button ID="btnScheduleAppointment" runat="server" Text="Schedule Appointment" OnClick="btnScheduleAppointment_Click" />

        <!-- Button to cancel or change appointment -->
        <asp:Button ID="btnCancelChangeAppointment" runat="server" Text="Cancel/Change Appointment" OnClick="btnCancelChangeAppointment_Click" />
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
</asp:Content>
