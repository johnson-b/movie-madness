<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MovieMadness.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="MovieTitle" />
            <asp:TextBox runat="server" ID="ReleaseDate" />
            <asp:TextBox runat="server" ID="Duration" />
            <asp:TextBox runat="server" ID="Rating" />
            <asp:Button runat="server" ID="Update" Text="Update" />
        </div>
    </form>
</body>
</html>
