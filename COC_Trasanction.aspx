<%@ Page Title="" Language="C#" MasterPageFile="~/RBS.master" AutoEventWireup="true" CodeFile="COC_Trasanction.aspx.cs" Inherits="Default2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="http://localhost:53752/netdna.bootstrapcdn.com/bootstrap/3.1.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script type="text/javascript" src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <script type="text/javascript" src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>


    <script type="text/javascript">
        function successalert() {
            swal({
                title: "Congratulations!",
                text: "File have been updated successfully! ",
                imageUrl: 'thumbs-up.jpg'
            });
        }
        function failedalert() {
            swal({
                title: 'Error',
                text: 'Data is not present,Please uplaod the data',
                type: 'error'
            });
        }
        function failedError() {
            swal({
                title: 'Error',
                text: 'Error While uplading data,Please Try Again',
                type: 'error'
            });
        }
        function CheckPS() {
            swal({
                title: 'Please try again',
                text: 'Please make sure that enter psno is correct or not',
                type: 'error'
            });
        }
        function ExcelJS() {
            swal({
                title: 'ERROR',
                text: 'Error in while uploading the excel,Please check your excel format.(Format must be .XLSX)',
                type: 'error'
            });
        }
        //function checkalert() {
        //    swal("User is alreday present !", "if you want you can give additional reports right")
        //}
        //function checksucessalert() {
        //    swal("User is not present !", "you can create user login")
        //}

    </script>




    <style type="text/css">
        .style1
        {
            height: 36px;
        }

        .style2
        {
            height: 14px;
        }

        .style3
        {
            height: 39px;
        }

        .container
        {
            margin-top: 20px;
        }

        .image-preview-input
        {
            position: relative;
            overflow: hidden;
            margin: 0px;
            color: #333;
            background-color: #fff;
            border-color: #ccc;
        }

            .image-preview-input input[type=file]
            {
                position: absolute;
                top: 0;
                right: 0;
                margin: 0;
                padding: 0;
                font-size: 20px;
                cursor: pointer;
                opacity: 0;
                filter: alpha(opacity=0);
            }

        .image-preview-input-title
        {
            margin-left: 2px;
        }

        .centerTable
        {
            margin: 0px auto;
        }

        .auto-style1
        {
            width: 350px;
        }

        .auto-style2
        {
            height: 36px;
            width: 262px;
        }

        .auto-style3
        {
            width: 326px;
        }
        .auto-style4
        {
            height: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <table class="centerTable" style="margin: 0px auto;" border="1" cellpadding="1" cellspacing="1" width="80%">
        <tr>
            <td colspan="3" align="center">
                <h2><a href="Files/RBSCOC.xlsx">Note.Download upload file format from here </a></h2>

            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <h3>Uplaod File:</h3>
            </td>
            <td class="auto-style2">&nbsp;&nbsp;&nbsp
            <asp:FileUpload class="form-control-file" ID="rbsuplaod" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ValidationGroup="browse" ControlToValidate="rbsuplaod" ErrorMessage="Please browse your file"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnuplaod" runat="server" CssClass="button" ValidationGroup="browse" Text="Upload" Height="32px" Width="87px" OnClick="btnuplaod_Click"  /></td>

        </tr>
    </table>


    <table class="centerTable" cellpadding="0" cellspacing="1" width="80%">
        <tr align="left">
            <td>
                <h3>PSNO:</h3>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="txtpsno" runat="server" AutoPostBack="true" OnTextChanged="txtpsno_TextChanged"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtpsno"
                    ValidationGroup="CheckPSNO" ForeColor="Red" runat="server" ErrorMessage="Please Enter PSNO"></asp:RequiredFieldValidator>
              
            </td>
            <%--<td>
                <asp:Button ID="btn" runat="server" ValidationGroup="CheckPSNO" CssClass="button" Text="GO" Width="84px"
                    OnClick="btn_Click" />
                    </td>--%>
            <td>
                <h3>Transaction ID</h3>
            </td>
            <td>
                <asp:DropDownList ID="ddlUserID" runat="server" AutoPostBack="true" Height="23px" Width="152px" OnSelectedIndexChanged="ddlUserID_SelectedIndexChanged">
                </asp:DropDownList>
            </td>

        </tr>
    </table>

    <asp:Panel ID="RbsPanel" runat="server">
        <table border="1" class="centerTable" cellpadding="1" cellspacing="1" width="80%">
            <tr>
                <td colspan="4" class="style3">&nbsp;
                </td>
            </tr>
            <tr align="left">
                <td>
                    <h3>NAME</h3>
                </td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" Width="180px" Height="16px"></asp:TextBox>
                </td>
                <td>
                    <h3>UAN NO.</h3>
                </td>
                <td>
                    <asp:TextBox ID="txtuan" runat="server" Width="180px" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    <h3>EPS NO:</h3>
                </td>
                <td>
                    <asp:TextBox ID="txteps" runat="server" Width="180px" Height="16px"></asp:TextBox>
                </td>
                <td>
                    <h3>ENTITY</h3>
                </td>
                <td>
                    <asp:TextBox ID="txtentity" runat="server" Width="180px" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <h3>LOCATION</h3>
                </td>
                <td>
                    <asp:TextBox ID="txtlocation" runat="server" Width="180px" Height="16px"></asp:TextBox>
                </td>
                <td>
                    <h3>DOB</h3>
                </td>
                <td>
                    <asp:TextBox ID="txtdob" runat="server" Width="180px" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <h3>DOJ</h3>
                </td>
                <td>
                    <asp:TextBox ID="txtdoj" runat="server" Width="180px" Height="16px"></asp:TextBox>
                </td>
            </tr>
        </table>



        <table cellpadding="1" class="centerTable" border="1" cellspacing="1" width="80%">
            <tr>

                <td>Deputation Period From Date:
                </td>
                <td>
                    <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFrom">
                    </asp:CalendarExtender>
                </td>
                <td>Deputation Period To Date:
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Country deputed
                </td>
                <td>
                    <asp:DropDownList ID="ddlDeputedCountry" runat="server" Height="23px" Width="145px">
                    </asp:DropDownList>
                </td>
                <td>Application Recevied date:
                </td>
                <td>
                    <asp:TextBox ID="txtRcvdDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Submission TO RPFC Date:
                </td>
                <td>
                    <asp:TextBox ID="txtRPFC" runat="server"></asp:TextBox>
                </td>
                <td>Application No:
                </td>
                <td>
                    <asp:TextBox ID="txtAppNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>COC No:
                </td>
                <td>
                    <asp:TextBox ID="txtCOCNo" runat="server"></asp:TextBox>
                </td>
                <td>Original COC Sent to:
                </td>
                <td>
                    <asp:TextBox ID="txtORGCOCSent" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Sent Date:
                </td>
                <td>
                    <asp:TextBox ID="txtSentDate" runat="server"></asp:TextBox>
                </td>
                <td>
                 
                </td>
                <td>
                  
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style4">Comment</td>
                <td colspan="2" class="auto-style4">
                    <asp:TextBox ID="txtcmt" runat="server" TextMode="MultiLine" Height="67px" Width="251px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2"><asp:CheckBox ID="CheckBoxEmail" Text="Email Attachment" AutoPostBack="true" runat="server" OnCheckedChanged="CheckBoxEmail_CheckedChanged" /></td>
                <td colspan="2">
                    <asp:CheckBox ID="CheckBoxReason" Text="Rejection Remark" AutoPostBack="true" runat="server" OnCheckedChanged="CheckBoxReason_CheckedChanged" />
                </td>
                
            </tr>
             </table>
            </asp:Panel>
        <asp:Panel ID="panelEmail" runat="server">
            <table cellpadding="1" class="centerTable" border="1" cellspacing="1" width="80%">
                <tr>
                    <td>File Uplod</td>
                    <td> <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    <td>Email Id TO</td>
                    <td> <asp:TextBox ID="txtEmail"  runat="server" ></asp:TextBox></td>

                </tr>
             <tr>

              
                <td>Email Id CC</td>
                <td>
                    <asp:TextBox ID="txtCC" runat="server"></asp:TextBox>
                </td>
                 <td>Email Id BCC</td>
               <td>
                   <asp:TextBox ID="txtBCC" runat="server"></asp:TextBox></td>

            </tr>
                </table>
      </asp:Panel>
        <asp:Panel ID="panelReason" runat="server">
        <table cellpadding="1" class="centerTable" border="1" cellspacing="1" width="80%">
        <tr>

                <td colspan="2">
                    <h3>Reason for Rejection:</h3>
                </td>
                <td colspan="2" align="center">
                    <asp:TextBox ID="txtReason" TextMode="MultiLine" runat="server" Height="67px"
                        Width="251px"></asp:TextBox>
                </td>

            </tr>

        </table>
     </asp:Panel>

       
        <table cellpadding="1" class="centerTable" border="1" cellspacing="1" width="80%">
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Update" OnClick="btnSave_Click" /></td>
                <td colspan="2" align="left">
                    <asp:Button ID="btnClear" runat="server" CssClass="button" Text="CLEAR" OnClick="btnClear_Click" /></td>
            </tr>

        </table>

</asp:Content>

