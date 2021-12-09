<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Input_pesonal_infor.aspx.cs" Inherits="Group5_QLCGP.WebForm3" %>
<!--#include file ="header.html"-->

    <form id="form1" runat="server">
        <div>
            <h2>&nbsp;</h2>
            <h2>Form input personal information</h2>
            <table class="auto-style1">
                   <tr>
                    <td class="auto-style2">Id</td>
                    <td>
                        <asp:TextBox ID="TextBox0" runat="server"  Width="96px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Name</td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server"  Width="321px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Gender</td>
                    <td>
                        <asp:RadioButtonList ID="gender" runat="server" Width="149px">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Date of birth</td>
                    <td>
                        <asp:TextBox ID="bd" runat="server" Width="361px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Pic</td>
                    <td>
                        <asp:TextBox ID="image_link" runat="server" Width="364px"></asp:TextBox>
&nbsp;(images link)</td>
                </tr>
                <tr>
                    <td class="auto-style2">Relationship with<br />
                        <br />
                        <br />
                        <br />
                        Position in family</td>
                    <td>
                        <asp:ListBox ID="choses_relate" runat="server" Width="133px" Height="133px"></asp:ListBox>
                    &nbsp;<asp:RadioButtonList ID="position" runat="server">
                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Child</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit" Width="194px" />
                        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
