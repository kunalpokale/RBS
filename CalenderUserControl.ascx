<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalenderUserControl.ascx.cs" Inherits="CalenderUserControl" %>
Date of birth:
<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar.png" OnClick="ImageButton1_Click" />

<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
