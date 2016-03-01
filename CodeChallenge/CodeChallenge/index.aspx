<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CodeChallenge.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Weather Information</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
    <link rel="stylesheet" href="assets/css/main.css" />
    <!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->
    <!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->

</head>
<body>

    <!-- Header -->
    <header id="header">
        <a href="index.html" class="title">Weather Information </a>
        <nav>
            <ul>
                <li><a href="index.aspx">Home</a></li>
                <li><a href="TempRange.aspx">Temperature Range </a></li>
                <li><a href="AdminPage.aspx" class="active">Admin Page </a></li>
            </ul>
        </nav>
    </header>

    <!-- Wrapper -->
    <div id="wrapper">

        <!-- Main -->
        <section id="main" class="wrapper">
            <div class="inner">

                <form id="form1" runat="server">

                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Countries"></asp:Label>
                        <br />
                        <asp:ListBox ID="ListBox1" runat="server" Height="159px" Width="143px"
                            SelectionMode="Multiple" AutoPostBack="True"
                            
                            ></asp:ListBox>
                        <br />
                         </div>
                        <br />
                        <asp:Label ID="lblResults" runat="server" Width="384px" Height="168px">
                        </asp:Label>
                        <br />
                        <asp:Label ID="Label1" runat="server" Width="384px" Height="168px" Text="">
                        </asp:Label>

                        <div class="12u$">
                            <ul class="actions">
                                <li>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="Button1_Click" Text="Submit"
                            Width="103px" /> </li>

                         <li>
                                    <asp:Button ID="btnReset"  runat="server" OnClick="Button2_Click" Text="Clear" /></li>
                                    
                            </ul>
                    </div>
                </form>


            </div>

        </section>
    </div>


    <!-- Footer -->
    <footer id="footer" class="wrapper alt">
        <div class="inner">
            <ul class="menu">
                <li> <asp:Label ID="lbltime" runat="server" Text="Label"></asp:Label></li>
                <li>Design: <a href="http://Qualcomm.com">QualComm Challenge</a></li>
            </ul>
        </div>
    </footer>

    <!-- Scripts -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery.scrollex.min.js"></script>
    <script src="assets/js/jquery.scrolly.min.js"></script>
    <script src="assets/js/skel.min.js"></script>
    <script src="assets/js/util.js"></script>
    <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
    <script src="assets/js/main.js"></script>


</body>
</html>

