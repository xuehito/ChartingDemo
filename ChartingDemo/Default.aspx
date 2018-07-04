<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChartingDemo.Default" %>
<%@ Register TagPrefix="dotnetCHARTING" Namespace="dotnetCHARTING" Assembly="dotnetCHARTING" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <dotnetCHARTING:Chart ID="Chart1" runat="server">
        </dotnetCHARTING:Chart>
        <dotnetCHARTING:Chart ID="Chart2" runat="server">
        </dotnetCHARTING:Chart>
        <dotnetCHARTING:Chart ID="Chart3" runat="server">
        </dotnetCHARTING:Chart>
        <dotnetCHARTING:Chart ID="Chart4" runat="server">
        </dotnetCHARTING:Chart>
    </div>
    </form>
</body>
</html>
