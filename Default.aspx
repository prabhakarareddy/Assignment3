<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
#header {
    background-color:cornflowerblue;
    color:white;
    text-align:center;
    padding:5px;
}
#nav {
    line-height:30px;
    background-color:#eeeeee;
    height:300px;
    width:100px;
    float:left;
    padding:5px; 
}
#section {
    width:350px;
    float:left;
    padding:10px; 
}
#footer {
    background-color:black;
    color:white;
    clear:both;
    text-align:center;
    padding:5px; 
}
</style>
</head>
<body>
    <div id="header">
<h1>User Information Application</h1>
</div>
    <form id="form1" runat="server" style="padding-top:50px">
    <table style="background-color:papayawhip;" align="center">
        <tr><td>Create UserType</td></tr>
        <tr>
            <td>
            <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnTextChanged="Unnamed_TextChanged">
<asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
            <asp:ListItem>Teachers</asp:ListItem>
            <asp:ListItem>Professors</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>

        <tr><td>Specife a Username</td></tr>
        <tr>
            <td>
           <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><asp:Label ID="lblDisplay" runat="server"></asp:Label>
            </td>
             <td>
           <asp:Button ID="btnFindUser" text="Find User" runat="server" OnClick="btnFindUser_Click"></asp:Button>
            </td>
        </tr>

        <tr><td>Specife a password</td></tr>
        <tr>
            <td>
           <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>

        <tr><td>Specife a password</td></tr>
        <tr>
            <td>
           <asp:CheckBox ID="chkDefaule" runat="server" Text="Reset To the Default Password" />
            </td>
        </tr>

        <tr><td>Specife an email</td></tr>
        <tr>
            <td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>

         <tr><td>Choose a email Extension</td></tr>
        <tr>
            <td>
            <asp:RadioButtonList id="emailType" runat="server">
                <asp:ListItem Text="@robertmorris.edu" value="@robertmorris.edu"></asp:ListItem>
                <asp:ListItem Text="@gmail.com" value="@robertmorris.edu"></asp:ListItem>
                <asp:ListItem Text="@yahoo.com" value="@robertmorris.edu"></asp:ListItem>
                <asp:ListItem Text="@hotmail.com" value="@robertmorris.edu"></asp:ListItem>                
            </asp:RadioButtonList>
            </td>
        </tr>

        <tr><td>Enter Miscellaneous instructions:</td></tr>
        <tr>
            <td>
           <asp:TextBox ID="txtNode" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
          <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr><td><asp:Button ID="btnCreatUser" runat="server" text="Create User" style="padding-left:10px" OnClick="btnCreatUser_Click"/></td>
            <td><asp:Button ID="btnUpdate" runat="server" text="Update" align="center" OnClick="btnUpdate_Click" /></td>
            <td><asp:Button ID="btnDelete" runat="server" text="Delete" align="center" OnClick="btnDelete_Click" /></td>
        </tr>            
    </table>
    
    </form>
</body>
</html>
