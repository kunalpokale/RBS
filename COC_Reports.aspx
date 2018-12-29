<%@ Page Title="" Language="C#" MasterPageFile="~/RBS.master" AutoEventWireup="true" CodeFile="COC_Reports.aspx.cs" Inherits="Default2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="CalenderUserControl.ascx" tagname="CalenderUserControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="http://localhost:53752/netdna.bootstrapcdn.com/bootstrap/3.1.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script type="text/javascript" src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>


    <script type="text/javascript">
        function GrvData()
        {
            swal("No Data Found");
        }

    </script>
    <style type="text/css">
        .auto-style1
        {
            width: 939px;
        }
        .auto-style2
        {
            width: 796px;
        }
        .auto-style3
        {
            width: 730px;
        }
        .auto-style5
        {
            width: 623px;
        }
        .auto-style6
        {
            width: 243px;
        }
        .auto-style7
        {
            width: 417px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <table class="centerTable" style="margin: 0px auto;" border="1" cellpadding="1"  cellspacing="1" width="80%">
        <tr>
            <td colspan="3" class="auto-style1" align="center">
                   <h1>RBS COC Report</h1>

            </td>
        </tr>
        <tr>
      <td class="auto-style1" align="right">
               <h2>Search on basis:</h2>
           </td>
            <td class="auto-style2">

                <asp:DropDownList ID="ddlsearch" AutoPostBack="true" runat="server" Height="25px" Width="189px" OnSelectedIndexChanged="ddlsearch_SelectedIndexChanged">
                    <asp:ListItem Value="0">Select Your Search option</asp:ListItem>
                    <asp:ListItem Value="1">Country Wise Report</asp:ListItem>
                    <asp:ListItem Value="2">Application received from and to date</asp:ListItem>
                    <asp:ListItem Value="3">RPFC Submission pending-Date is blank</asp:ListItem>
                    <asp:ListItem Value="4">Rejection List</asp:ListItem>
                     <asp:ListItem Value="5">Serach By PSNO</asp:ListItem>
                     <asp:ListItem Value="6">LOG Detail</asp:ListItem>
                </asp:DropDownList> &nbsp;&nbsp;&nbsp
            </td>
            <td></td>
           
        
        </tr>
    </table>
    <asp:Panel ID="pnlcountry" runat="server">
          <table class="centerTable" style="margin: 0px auto;" border="1" cellpadding="1"  cellspacing="1" width="80%">
        <tr>
            <td colspan="3" align="center">
                   <h4>Country Wise Report</h4>

            </td>
        </tr>
        <tr>
      <td class="auto-style3" align="right">
               <h4>Select Deputed Country</h4>
           </td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddlSearchCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchCountry_SelectedIndexChanged"></asp:DropDownList>
          
            </td>
           
        
        </tr>
    </table>

    </asp:Panel>
     <asp:Panel ID="panelApplication" runat="server">
          <table class="centerTable" style="margin: 0px auto;" border="1" cellpadding="1"  cellspacing="1" width="80%">
        <tr>
            <td colspan="4" align="center">
                   <h4>Application Received From and to Date</h4>

            </td>
        </tr>
        <tr>
      <td class="auto-style6" align="left">
               <h4>FROM DATE:</h4>
           </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
       
       
                <br />
             
            </td>
            <td class="auto-style7" align="right">
                <h4>TO DATE:</h4>
            </td>
            <td>
                <asp:TextBox ID="txtTO" runat="server"></asp:TextBox>
       
       
            </td>
         </tr>
              <tr>
                  <td colspan="4" align="center">
                      <asp:Button ID="gtnFetch" CssClass="button" runat="server" Text="Get Report" OnClick="gtnFetch_Click" /></td>
              </tr>
    </table>

    </asp:Panel>

    <asp:Panel ID="panelStxt" runat="server">
        <table class="centerTable" style="margin: 0px auto;" border="1" cellpadding="1"  cellspacing="1" width="80%">
        <tr>
            <td colspan="4" align="center">
                   <h4>Search By PSNO</h4>

            </td>
        </tr>
        <tr>
      <td class="auto-style6" colspan="2" align="right">
               <h4>PSNO:</h4>
           </td>
            <td class="auto-style5" colspan="2">
                <asp:TextBox ID="txtPSNO" ToolTip="Please Enter PSNO"  runat="server" OnTextChanged="txtPSNO_TextChanged"></asp:TextBox>
               
             
            </td>
          
              </tr>
    </table>
   </asp:Panel>


    <asp:Panel ID="PanelLog" runat="server">
        <table class="centerTable" style="margin: 0px auto;" border="1" cellpadding="1"  cellspacing="1" width="80%">
        <tr>
            <td colspan="4" align="center">
                   <h4>Search Audit log details By PSNO OR Transaction ID</h4>

            </td>
        </tr>
        <tr>
      <td class="auto-style6" colspan="2" align="right">
               <h4>PSNO /Transaction ID</h4>
           </td>
            <td class="auto-style5" colspan="2">
                <asp:TextBox ID="txtlog" ToolTip="Please Enter PSNO" AutoPostBack="true"  runat="server" OnTextChanged="txtlog_TextChanged"></asp:TextBox>
           </td>
          
              </tr>
    </table>
   </asp:Panel>
    <table class="centerTable" style="margin: 0px auto;" border="1" cellpadding="1"  cellspacing="1" width="80%">
        <tr>
            <td>
                
            </td>

        </tr>
        </table>

     <asp:Panel ID="Panel1" runat="server">

          </asp:Panel>

    <asp:Panel ID="grvpanel" runat="server">
    <table class="centerTable" style="margin: 0px auto;" cellpadding="1"  cellspacing="1" width="80%">
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="grvreport" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    Width="100%" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="User ID" DataField="COCID" />
                        <asp:BoundField HeaderText="PSNO" DataField="PSNO" />
                        <asp:BoundField HeaderText="Country" DataField="Country_Deputed">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Deputation From" DataField="Deputation_From" />
                        <asp:BoundField HeaderText="Deputation TO" DataField="Deputation_TO" />
                        <asp:BoundField HeaderText="App_ReceivedDate" DataField="App_ReceivedDate" />
                        <asp:BoundField HeaderText="Sub_RPFC_Date" DataField="Submision_RFC_Date" />
                         <asp:BoundField HeaderText="Application_No" DataField="Application_No" />
                        <asp:BoundField HeaderText="COC_No" DataField="COC_No" />
                         <asp:BoundField HeaderText="InsertedBy" DataField="InsertedBy" />
                        <asp:BoundField HeaderText="InsertedON" DataField="InsertedON" />
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    </asp:Panel>   
     <asp:Panel ID="panelgrvlog" runat="server">
    <table class="centerTable" style="margin: 0px auto;" cellpadding="1"  cellspacing="1" width="80%">
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GrvLog" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    Width="100%" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="Transaction ID" DataField="COCID" />
                        <asp:BoundField HeaderText="PSNO" DataField="PSNO" />
                        <asp:BoundField HeaderText="Changes On Column" DataField="Changes_On">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Changes Remark" DataField="ChangesRemark" />
                        <asp:BoundField HeaderText="ActionBY" DataField="ActionBY" />
                        <asp:BoundField HeaderText="ActionON" DataField="ActionON" />
                       
                     </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    </asp:Panel>   




</asp:Content>

