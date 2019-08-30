<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="DTUProject.MyClass.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>温湿度数据</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GradView1" runat="server" PageSize="20" AllowPaging="true" 
                AutoGenerateColumns="false" DataKeyNames="id">
                <Columns>
                    <asp:TemplateField HeaderText="时间">
                        <ItemTemplate>
                            <%# Eval("addtime") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="温度℃">
                        <ItemTemplate>
                            <%# Eval("temp") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="湿度%">
                        <ItemTemplate>
                            <%# Eval("humidity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


        <%--<div>
            <h1 style="background-color:red;color:aqua;font-family:Verdana;font-size:40px;">标题1</h1>
            <h2 style="background-color:springgreen">标题2</h2>
            <h3 style="background-color:blue">标题3</h3>
            <a href="http://www.baidu.com"> 百度连接</a>
        </div>
        <div>
            <table border="1" style="width:auto">
                <tr>
                    <th style="align-content:center">时间</th>
                    <th style="align-content:center">温度/℃</th>
                    <th style="align-content:center">湿度/%</th>
                </tr>
                <tr>
                    <th style="align-content:center">2019-08-23 10:20:55</th>
                    <th style="align-content:center">26</th>
                    <th style="align-content:center">65</th>
                </tr>
            </table>
        </div>--%>

        <asp:Button ID="Btn" runat="server" Text="Button" OnClick="Btn_Click"/>

    </form>

    <%-- Request对象可用于从表单取回用户信息 --%>
    <form method="get" action="MainForm.aspx">
        <p> First Name：<input type="text" name="fname" /></p>
        <p>Last Name：<input type="text" name="lname" /></p>
        <input type="submit" value="Submit" />
    </form>

    
</body>    
</html>
