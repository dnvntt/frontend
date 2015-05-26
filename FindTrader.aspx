<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindTrader.aspx.cs" Inherits="FindTrader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Find trader to follow</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Choose one of these traders below to follow
        <br /> <br />
        <asp:GridView ID="GridView1" runat="server"
         AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
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
                <asp:BoundField DataField="numberfollow" HeaderText="Number follow" SortExpression="numberfollow" 
                    ReadOnly="true" />
                 <asp:BoundField DataField="monneyfollow" HeaderText="Monney follow" SortExpression="monneyfollow" 
                    ReadOnly="true" />
                 
                 <asp:TemplateField HeaderText="Monney Allocate">
                  <ItemTemplate >
                       <asp:TextBox ID="txbox1" runat="server" width="80" ></asp:TextBox>
                  </ItemTemplate>
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Max Open Trade">
                      <ItemTemplate >
                          <asp:TextBox ID="txbox2" runat="server" width="80"></asp:TextBox>
                      </ItemTemplate>
                 </asp:TemplateField>
                           
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" Runat="server"   CommandName="Follow" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Follow</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            
        </asp:GridView>
    </div>
    </form>
</body>
</html>
