<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="ProjectTasks.Views.TaskList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="TaskList" runat="server">
        <div>
            <asp:Button runat="server" ID="CreateNewTask"  PostBackUrl="Task.aspx" Text="Create New Task"/>

            <br />
            <br />
            <asp:GridView ID="ListTask" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="IdTask" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Workload" HeaderText="Workload" />
                <asp:BoundField DataField="DateStart" HeaderText="DateStart" />
                <asp:BoundField DataField="DateFinish" HeaderText="DateFinish" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="IdPerson" HeaderText="IdPerson" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                <asp:BoundField DataField="Fathername" HeaderText="Fathername" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Id="linkDelete" Text="Delete" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="DeleteTask"></asp:LinkButton>
                        <asp:LinkButton Id="LinkUpdate" Text="Update" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="UpdateTask"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

        </div>
    </form>
</body>
</html>
