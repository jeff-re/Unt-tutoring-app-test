<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBookedAppointments.aspx.cs" Inherits="Unt_tutoring_app_test.ViewBookedAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
    <html>

    <head>
        <style>
            body {
                background-image: url('UNTpic2.png');
                background-repeat: no-repeat;
                background-attachment: fixed;
                background-size: cover;
            }
        </style>
        <title>Student Schedule</title>


    </head>

    <body>


        <table align="left" style="height: 150px" border="1" bgcolor="lightgray">
            <tr align="center">
                <td align="center">
                    <button style="width: 100%; height: 100%;" align="center" onclick="window.open('student-login.html', '_self')">Go Back</button>
                </td>
            </tr>

        </table>

        <table align="center" style="height: 400px" border="1" bgcolor="lightgray">
            <tr>
                <td align="center">
                    <h1 style="color: rgb(0, 123, 60);">University of North Texas</h1>
                    <h2>Eagle Tutoring</h2>
                </td>
            </tr>

            <tr>
                <td align="center">
                    <%--<button style="width: 100%; height: 100%;" onclick="window.open('student select subject.html', '_self')">Schedule Appointment</button>--%>
                    <asp:GridView ID="GvBooked" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Height="160px" Width="391px" OnRowCommand="GvBooked_RowCommand">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="AppointDate" HeaderText="AppointDate" DataFormatString="{0:MM/dd/yyyy}" SortExpression="AppointDate" />
                            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                            <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
                            <asp:BoundField DataField="Tutor" HeaderText="Tutor" SortExpression="Tutor" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%-- CommandArgument='<%# Eval("Id") %>'--%>
                                    <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Remove" Width="20px" Height="20px" ToolTip="Delete" />
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceViewAppointments" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT ta.AppointDate, a.Subject, a.Time, a.Tutor 
FROM [Appointments] as a
INNER JOIN [dbo].[TutorAvailable] AS ta
	ON a.TimeId = ta.Id"></asp:SqlDataSource>
                </td>
            </tr>

            <tr>
                <td align="center">
                    <%--<button style="width: 100%; height: 100%;" onclick="window.open('change or cancel.html', '_self')">Change or Cancel Appointment</button>--%>
                </td>
            </tr>
            <p></p>
            <tr>
                <td align="center">
                    <img
                        src="https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/North_Texas_Mean_Green_logo.svg/800px-North_Texas_Mean_Green_logo.svg.png"
                        style="width: 90px; height: 100px;">
                </td>
            </tr>

        </table>


    </body>

    </html>
</asp:Content>
