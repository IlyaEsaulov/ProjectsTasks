<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterPerson.aspx.cs" Inherits="ProjectTasks.Views.EnterPerson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="EnterPersonForm" runat="server">
        <div>
            <asp:TextBox runat="server" type="hidden" id="id"/>
            <label>Name</label><br />
            <asp:TextBox id="name" type="text" runat="server" /><br /><br />
            <label>Surname</label><br />
            <asp:TextBox id="surname" type="text"  runat="server"/><br /><br />
            <label>Fathername</label><br />
            <asp:TextBox id="fathername" type="text"  runat="server"/><br /><br />

            <asp:button ID="buttonAdd" type="button" runat="server" Text="Add person" OnClick="AddPerson" Width="107px" />
            <asp:button ID="buttonEdit" type="button" runat="server" Text="Edit person" OnClick="EditPerson" Width="107px" />
            <asp:Button runat="server" PostBackUrl="PersonList.aspx" Text="Cancel" />

        </div>
    </form>
</body>
</html>
