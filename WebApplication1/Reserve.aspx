<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reserve.aspx.cs" Inherits="WebApplication1.Users" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <asp:Label ID="LabelWelcome" runat="server" Text="Welcome  "></asp:Label>
        <br />
            <div class="space">
    <asp:LinkButton ID="LinkButtonSample" ForeColor="Gray" runat="server" OnClick="LinkButtonSample_Click">Clear and Generate Random Data</asp:LinkButton>
    </div>

    <DayPilot:DayPilotScheduler 
        ID="DayPilotScheduler1" 
        runat="server" 
        
        DataStartField="eventstart" 
        DataEndField="eventend" 
        DataTextField="name" 
        DataIdField="id" 
        DataResourceField="resource_id" 
        
        CellGroupBy="Month"
        Scale="Day"
        
        EventMoveHandling="CallBack" 
        OnEventMove="DayPilotScheduler1_EventMove" 
        >
    </DayPilot:DayPilotScheduler>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Reset</asp:LinkButton>

        <br />
        <br />

        <asp:Button ID="ButtonLogOut" runat="server" OnClick="ButtonLogOut_Click" Text="Log Out" />
    
    </div>
    </form>
</body>
</html>
