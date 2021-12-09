<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_personal.aspx.cs" Inherits="Group5_QLCGP.WebForm5" %>




<!--#include file ="header.html"-->


<body>
    <form id="form1" runat="server">
        <div>
            List of personal infrormation</div>
         <span id="Message" runat="server"/> 
  
    <table  border="1" class="auto-style1">
        <tr>
            <td>Id</td>
            <td>Name</td>
            <td>Gender</td>
            <td>Date_of_birth</td>
            <td class="auto-style2">Link picture</td>
            <td>User name</td>
           
        </tr>
        <%Response.Write(html); %>
       </table>
    
    </span>&nbsp;Input the ID need to delete<br />
        Do not delete Acestor ! <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black">

</asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete " ForeColor="Black" />
      </form>
</body>
</html>
