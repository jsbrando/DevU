<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeSimpleDarts.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="simButton" runat="server" OnClick="simButton_Click" Text="Simulate Dart Game" />
        <br />
        <br />
        <asp:TextBox ID="player1TextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="player2TextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
