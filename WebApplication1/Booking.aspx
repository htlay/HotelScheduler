<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="WebApplication1.Booking" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 107px; width: 1298px">
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
