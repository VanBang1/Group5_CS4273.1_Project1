<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registered_page.aspx.cs" Inherits="Group5_QLCGP.WebForm2" %>
 <!--#include file ="header.html"-->
    <head>
        <style type="text/css">
            .auto-style1 {
                width: 1228px;
                height: 275px;
                color:black;
            }
            .auto-style2 {
                width: 475px;
            }
            .auto-style3 {
                width: 471px;
            }
            .auto-style4 {
                width: 97px;
            }
        </style>
</head>
    <form id="form1" runat="server">
        <div style="height: 321px">

            <h2>Form register account</h2>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">User name</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Password</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Re-enter pass</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
                        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
