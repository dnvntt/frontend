<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="member" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    
<style>   
 .col0
    {
      display: none;
    }
</style>

<script type="text/javascript">
     function clientLoaded(sender, eventArgs)
        {
           document.getElementById("myRisk").innerHTML = sender.get_value();
        }
    function clientValueChange(sender, eventArgs)
    {           
      var myDiv = document.getElementById("myRisk");
      myDiv.innerHTML = sender.get_value();              
    }
</script>
</head>
<body>
     <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    Well come back 
        <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" 
            Text="                   "></asp:Label>
    </div>
    <div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Your Equity</td>
                <td class="auto-style2">Cash Available</td>
                <td class="auto-style2">Open Profit</td>
                <td class="auto-style3">Curent Margin</td>
                <td>Profit since the Start</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
            <table>
            <tr>
            <td>Risk Meter Bar:</td>
            <td><telerik:RadSlider ID="RadSlider1" runat="server" Height="22px" Length="200" onclientload="clientLoaded"
                    ShowDecreaseHandle="False" ShowIncreaseHandle="False" Width="200px" OnClientValueChanged="clientValueChange"
                    OnValueChanged="RadSlider1_ValueChanged" AutoPostBack="True"></telerik:RadSlider> </td>
            
            <td id="myRisk"> </td>
            </tr>
            </table>
            
    </div>
        <br />
        List of Traders you are currently following<br />
     <br />
    <asp:GridView ID="GridView1" 
        runat="server" BackColor="White"  AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"  CellPadding="4">
            <RowStyle BackColor="White" ForeColor="#003399" />
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            
            <Columns>
            
                <%--DATA BOUND COLUMNS--%>
                <asp:BoundField DataField="traderid" HeaderText="Trader Id" SortExpression="traderid" 
                    ReadOnly="true" />
                <asp:BoundField DataField="username" HeaderText="Trader" SortExpression="Trader" 
                    ReadOnly="true" />
                <asp:BoundField DataField="moneyallocate" HeaderText="Money Allocate" SortExpression="moneyallocate" 
                    ReadOnly="true" />
                 <asp:BoundField DataField="maxopen" HeaderText="Max Open Trade" SortExpression="maxopen" 
                    ReadOnly="true" />
                 
                
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" Runat="server"   CommandName="Unfollow" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Unfollow</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Follow Trader" />
    </form>
 
</body>

</html>
