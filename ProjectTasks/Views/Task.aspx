<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="ProjectTasks.Views.Task" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="Task" runat="server">
        <div>
            <asp:TextBox runat="server" type="hidden" id="id"/>
            <label>Title</label><br />
            <asp:TextBox id="title" type="text" runat="server" /><br /><br />
            <label>Workload</label><br />
            <asp:TextBox id="workload" type="int"  runat="server"/><br /><br />
            <label>DateStart</label><br />
            <asp:TextBox id="dateStart" type="date"  runat="server"/><br /><br />
            <label>DateFinish</label><br />
            <asp:TextBox id="dateFinish" type="date"  runat="server"/><br /><br />
            <label>Status</label><br />
            <asp:TextBox id="status" type="text"  runat="server"/><br /><br />
            <label>Persons<br />
            </label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Text="" Value=""></asp:ListItem>
            </asp:DropDownList>
            <br />


            <asp:button ID="buttonAdd" type="button" runat="server" Text="Add Task" OnClick="AddTask" Width="107px" />
            <asp:button ID="buttonEdit" type="button" runat="server" Text="Edit Task" OnClick="EditTask" Width="107px" />
            <asp:Button runat="server" PostBackUrl="TaskList.aspx" Text="Cancel" />
        </div>
    </form>
</body>
</html>
