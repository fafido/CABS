﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dash.aspx.vb" Inherits="Reporting_Dashboard_dash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
        <title>Custodian Dashboard</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <meta content="Admin Dashboard" name="description" />
        <meta content="ThemeDesign" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="refresh" content="10;url=dash.aspx"/>

        <!--<link rel="shortcut icon" href="assets/images/favicon.ico">-->

        <!--Morris Chart CSS -->
        <link rel="stylesheet" href="assets/plugins/morris/morris.css">

        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css">
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css">
        <link href="assets/css/style.css" rel="stylesheet" type="text/css">
</head>

    <body class="fixed-left">

        <!-- Begin page -->
        <div id="wrapper" class="enlarged forced">

            <!-- Top Bar Start -->
            <div class="topbar">
                <!-- LOGO -->
                <div class="topbar-left">
                    <div class="text-center">
                       
                        <!--<a href="index.html"><img src="assets/images/cbz.png" style="width:150px;height:80px;"></a>-->
                        <!--<a href="index.html"><img src="assets/images/cbz.png" style="width:100px;height:100px;"></a>-->
                    </div>
                </div>

                <!-- Button mobile view to collapse sidebar menu -->
                <div class="navbar navbar-default" role="navigation">
                    <div class="container">
                        <div class="">
                            <div class="pull-left">
                                <button type="button" class="button-menu-mobile open-left waves-effect waves-light">
                                    <i class="ion-navicon"></i>
                                </button>
                                <span class="clearfix"></span>
                            </div>
                            <form class="navbar-form pull-left" role="search">
                                <div class="form-group">
                                    <input type="text" class="form-control search-bar" placeholder="Search...">
                                </div>
                                <button type="submit" class="btn btn-search"><i class="fa fa-search"></i></button>
                            </form>

                            <ul class="nav navbar-nav navbar-right pull-right">
                                <li class="dropdown hidden-xs">
                                    <a href="#" data-target="#" class="dropdown-toggle waves-effect waves-light notification-icon-box" data-toggle="dropdown" aria-expanded="true">
                                        <i class="fa fa-bell"></i> <span class="badge badge-xs badge-danger"></span>
                                    </a>
                                    <ul class="dropdown-menu dropdown-menu-lg noti-list-box">
                                        <li class="text-center notifi-title">Notification <span class="badge badge-xs badge-success">3</span></li>
                                        <li class="list-group">
                                           <!-- list item-->
                                           <a href="javascript:void(0);" class="list-group-item">
                                              <div class="media">
                                                 <div class="media-heading">Your order is placed</div>
                                                 <p class="m-0">
                                                   <small>Dummy text of the printing and typesetting industry.</small>
                                                 </p>
                                              </div>
                                           </a>
                                           <!-- list item-->
                                            <a href="javascript:void(0);" class="list-group-item">
                                              <div class="media">
                                                 <div class="media-body clearfix">
                                                    <div class="media-heading">New Message received</div>
                                                    <p class="m-0">
                                                       <small>You have 87 unread messages</small>
                                                    </p>
                                                 </div>
                                              </div>
                                            </a>
                                            <!-- list item-->
                                            <a href="javascript:void(0);" class="list-group-item">
                                              <div class="media">
                                                 <div class="media-body clearfix">
                                                    <div class="media-heading">Your item is shipped.</div>
                                                    <p class="m-0">
                                                       <small>It is a long established fact that a reader will</small>
                                                    </p>
                                                 </div>
                                              </div>
                                            </a>
                                           <!-- last list item -->
                                            <a href="javascript:void(0);" class="list-group-item">
                                              <small class="text-primary">See all notifications</small>
                                            </a>
                                        </li>
                                    </ul>
                                </li>
                                <li class="hidden-xs">
                                    <a href="#" id="btn-fullscreen" class="waves-effect waves-light notification-icon-box"><i class="mdi mdi-fullscreen"></i></a>
                                </li>
                                <li class="dropdown">
                                    <a href="" class="dropdown-toggle profile waves-effect waves-light" data-toggle="dropdown" aria-expanded="true">
                                        <img src="assets/images/users/avatar-1.jpg" alt="user-img" class="img-circle">
                                    </a>
                                    <ul class="dropdown-menu">
                                        <li><a href="javascript:void(0)"> Profile</a></li>
                                        <li><a href="javascript:void(0)"><span class="badge badge-success pull-right">5</span> Settings </a></li>
                                        <li><a href="javascript:void(0)"> Lock screen</a></li>
                                        <li class="divider"></li>
                                        <li><a href="javascript:void(0)"> Logout</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <!--/.nav-collapse -->
                    </div>
                </div>
            </div>
            <!-- Top Bar End -->


            <!-- ========== Left Sidebar Start ========== -->

            <div class="left side-menu">
                <div class="sidebar-inner slimscrollleft">

                    <!--<div class="user-details">-->
                        <!--<div class="pull-left">-->
                            <!--<img src="assets/images/users/avatar-1.jpg" alt="" class="thumb-md img-circle">-->
                        <!--</div>-->
                        <!--<div class="user-info">-->
                            <!--<div class="dropdown">-->
                                <!--<a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-expanded="false">David Cooper <span class="caret"></span></a>-->
                                <!--<ul class="dropdown-menu">-->
                                    <!--<li><a href="javascript:void(0)"><i class="md md-face-unlock"></i> Profile<div class="ripple-wrapper"></div></a></li>-->
                                    <!--<li><a href="javascript:void(0)"><i class="md md-settings"></i> Settings</a></li>-->
                                    <!--<li><a href="javascript:void(0)"><i class="md md-lock"></i> Lock screen</a></li>-->
                                    <!--<li><a href="javascript:void(0)"><i class="md md-settings-power"></i> Logout</a></li>-->
                                <!--</ul>-->
                            <!--</div>-->

                            <!--<p class="text-muted m-0">Admin</p>-->
                        <!--</div>-->
                    <!--</div>-->
                    <!--- Divider -->


                    <div id="sidebar-menu">
                        <ul>
                            <li class="menu-title"></li>
                            <li>
                                <a href="index.html" class="waves-effect"><i class="mdi mdi-home"></i><span> Dashboard <span class="badge badge-primary pull-right">1</span></span></a>
                            </li>

                            <!--<li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-album"></i> <span> UI Elements </span> <span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul class="list-unstyled">
                                    <li><a href="ui-components.html">Components</a></li>
                                    <li><a href="ui-buttons.html">Buttons</a></li>
                                    <li><a href="ui-panels.html">Panels</a></li>
                                    <li><a href="ui-tabs-accordions.html">Tabs &amp; Accordions</a></li>
                                    <li><a href="ui-modals.html">Modals</a></li>
                                    <li><a href="ui-progressbars.html">Progress Bars</a></li>
                                    <li><a href="ui-alerts.html">Alerts</a></li>
                                    <li><a href="ui-sweet-alert.html">Sweet-Alert</a></li>
                                    <li><a href="ui-grid.html">Grid</a></li>
                                </ul>
                            </li>

                            <li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-layers"></i><span> Forms </span><span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul class="list-unstyled">
                                    <li><a href="form-elements.html">General Elements</a></li>
                                    <li><a href="form-validation.html">Form Validation</a></li>
                                    <li><a href="form-advanced.html">Advanced Form</a></li>
                                    <li><a href="form-wysiwyg.html">WYSIWYG Editor</a></li>
                                    <li><a href="form-uploads.html">Multiple File Upload</a></li>
                                </ul>
                            </li>

                            <li>
                                <a href="typography.html" class="waves-effect"><i class="mdi mdi-diamond"></i><span> Typography <span class="badge badge-primary pull-right">4</span></span></a>
                            </li>

                            <li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-table"></i><span> Tables </span><span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul class="list-unstyled">
                                    <li><a href="tables-basic.html">Basic Tables</a></li>
                                    <li><a href="tables-datatable.html">Data Table</a></li>
                                    <li><a href="tables-responsive.html">Responsive Table</a></li>
                                    <li><a href="tables-editable.html">Editable Table</a></li>
                                </ul>
                            </li>

                            <li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-chart-pie"></i><span> Charts </span><span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul class="list-unstyled">
                                    <li><a href="charts-morris.html">Morris Chart</a></li>
                                    <li><a href="charts-chartjs.html">Chartjs</a></li>
                                    <li><a href="charts-flot.html">Flot Chart</a></li>
                                    <li><a href="charts-other.html">Other Chart</a></li>
                                </ul>
                            </li>

                            <li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-opacity"></i> <span> Icons </span> <span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul class="list-unstyled">
                                    <li><a href="icons-material.html">Material Design</a></li>
                                    <li><a href="icons-ion.html">Ion Icons</a></li>
                                    <li><a href="icons-fontawesome.html">Font awesome</a></li>
                                    <li><a href="icons-themify.html">Themify Icons</a></li>
                                </ul>
                            </li>

                            <li class="menu-title">Features</li>

                            <li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-map"></i><span> Maps </span><span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul class="list-unstyled">
                                    <li><a href="maps-google.html"> Google Map</a></li>
                                    <li><a href="maps-vector.html"> Vector Map</a></li>
                                </ul>
                            </li>

                            <li>
                                <a href="calendar.html" class="waves-effect"><i class="mdi mdi-calendar"></i><span> Calendar <span class="badge badge-primary pull-right">NEW</span></span></a>
                            </li>

                            <li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-assistant"></i><span> Layouts </span><span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul class="list-unstyled">
                                    <li><a href="layouts-collapse.html">Menu Collapse</a></li>
                                    <li><a href="layouts-smallmenu.html">Menu Small</a></li>
                                    <li><a href="layouts-menu2.html">Menu Style 2</a></li>
                                </ul>
                            </li>

                            <li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-google-pages"></i><span> Pages </span><span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul class="list-unstyled">
                                    <li><a href="pages-login.html">Login</a></li>
                                    <li><a href="pages-register.html">Register</a></li>
                                    <li><a href="pages-recoverpw.html">Recover Password</a></li>
                                    <li><a href="pages-lock-screen.html">Lock Screen</a></li>
                                    <li><a href="pages-blank.html">Blank Page</a></li>
                                    <li><a href="pages-404.html">Error 404</a></li>
                                    <li><a href="pages-500.html">Error 500</a></li>
                                    <li><a href="pages-timeline.html">Timeline</a></li>
                                    <li><a href="pages-invoice.html">Invoice</a></li>
                                    <li><a href="pages-directory.html">Directory</a></li>
                                </ul>
                            </li>-->

                            <li class="has_sub">
                                <a href="javascript:void(0);" class="waves-effect"><i class="mdi mdi-share-variant"></i><span>Multi Menu </span><span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                <ul>
                                    <li class="has_sub">
                                        <a href="javascript:void(0);" class="waves-effect"><span>Menu Item 1.1</span> <span class="pull-right"><i class="mdi mdi-plus"></i></span></a>
                                        <ul style="">
                                            <li><a href="javascript:void(0);"><span>Menu Item 2.1</span></a></li>
                                            <li><a href="javascript:void(0);"><span>Menu Item 2.2</span></a></li>
                                        </ul>
                                    </li>
                                    <li>
                                        <a href="javascript:void(0);"><span>Menu Item 1.2</span></a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <div class="clearfix"></div>
                </div> <!-- end sidebarinner -->
            </div>
            <!-- Left Sidebar End -->

            <!-- Start right Content here -->

            <div class="content-page">
                <!-- Start content -->
                <div class="content">

                    <div class="">
                        <div class="page-header-title">
                            <h4 class="page-title">C-Trade Custodian Dashboard</h4>
                        </div>
                    </div>

                    <div class="page-content-wrapper ">

                        <div class="container">

                            <div class="row">
                                <div class="col-sm-6 col-lg-3">
                                    <div class="panel text-center">
                                        <div class="panel-heading">
                                            <h4 class="panel-title text-muted font-light">Total Registrations</h4>
                                        </div>
                                        <div class="panel-body p-t-10">
                                            <h2 class="m-t-0 m-b-15"><i class="mdi mdi-arrow-up text-success m-r-10"></i><b runat="server" id="lbltotal_registrations"></b></h2>
                                            <p class="text-muted m-b-0 m-t-20"><b>10%</b> From Last 24 Hours</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-lg-3">
                                    <div class="panel text-center">
                                        <div class="panel-heading">
                                            <h4 class="panel-title text-muted font-light">Total Funds</h4>
                                        </div>
                                        <div class="panel-body p-t-10">
                                            <h2 class="m-t-0 m-b-15"><i class="mdi mdi-arrow-up text-success m-r-10"></i><b runat="server" id="lbltotal_funds"></b></h2>
                                            <p class="text-muted m-b-0 m-t-20"><b>5%</b> From Last 24 hours</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-lg-3">
                                    <div class="panel text-center">
                                        <div class="panel-heading">
                                            <h4 class="panel-title text-muted font-light">Total Holdings</h4>
                                        </div>
                                        <div class="panel-body p-t-10">
                                            <h2 class="m-t-0 m-b-15"><i class="mdi mdi-arrow-up text-success m-r-10"></i><b runat="server" id="lbltotal_holdings"></b></h2>
                                            <p class="text-muted m-b-0 m-t-20"><b>10%</b> From Last 24 Hours</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-lg-3">
                                    <div class="panel text-center">
                                        <div class="panel-heading">
                                            <h4 class="panel-title text-muted font-light">Matched Deals</h4>
                                        </div>
                                        <div class="panel-body p-t-10">
                                            <h2 class="m-t-0 m-b-15"><i class="mdi mdi-arrow-down text-danger m-r-10"></i><b runat="server" id="lbldepositoryholdings"></b></h2>
                                            <p class="text-muted m-b-0 m-t-20"><b>10%</b> From Last 1 Month</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 col-lg-3">
                                    <div class="panel text-center">
                                        <div class="panel-heading">
                                            <h4 class="panel-title text-muted font-light">Incoming Sells</h4>
                                        </div>
                                        <div class="panel-body p-t-10">
                                            <h2 class="m-t-0 m-b-15"><i class="mdi mdi-arrow-down text-danger m-r-10"></i><b runat="server" id="lblincomingsells"></b></h2>
                                            <!--<p class="text-muted m-b-0 m-t-20"><b>10%</b> From Last 24 Hours</p>-->
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-lg-3">
                                    <div class="panel text-center">
                                        <div class="panel-heading">
                                            <h4 class="panel-title text-muted font-light">Incoming Buys</h4>
                                        </div>
                                        <div class="panel-body p-t-10">
                                            <h2 class="m-t-0 m-b-15"><i class="mdi mdi-arrow-up text-success m-r-10"></i><b runat="server" id="lblincomingbuys"></b></h2>
                                            <!--<p class="text-muted m-b-0 m-t-20"><b>5%</b> From Last 24 hours</p>-->
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-lg-3">
                                    <div class="panel text-center">
                                        <div class="panel-heading">
                                            <h4 class="panel-title text-muted font-light">Pending Settlement</h4>
                                        </div>
                                        <div class="panel-body p-t-10">
                                            <h2 class="m-t-0 m-b-15"><i class="mdi mdi-arrow-up text-success m-r-10"></i><b runat="server" id="lblpendingsettlement"></b></h2>
                                            <!--<p class="text-muted m-b-0 m-t-20"><b>10%</b> From Last 24 Hours</p>-->
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6 col-lg-3">
                                    <div class="panel text-center">
                                        <div class="panel-heading">
                                            <h4 class="panel-title text-muted font-light">Settled Today</h4>
                                        </div>
                                        <div class="panel-body p-t-10">
                                            <h2 class="m-t-0 m-b-15"><i class="mdi mdi-arrow-down text-danger m-r-10"></i><b runat="server" id="lbltodaysettled"></b></h2>
                                            <!--<p class="text-muted m-b-0 m-t-20"><b>10%</b> From Last 1 Month</p>-->
                                        </div>
                                    </div>
                                </div>
                            </div>

                        <!--end-->
                            <div class="row">

                                <div class="col-lg-4">
                                    <div class="panel panel-primary">
                                        <div class="panel-body">
                                            <h4 class="m-t-0">Registrations By Channel</h4>

                                            <ul class="list-inline widget-chart m-t-20 text-center">
                                                <li>
                                                    <h4 class=""><b runat="server" id="lblonline">0</b></h4>
                                                    <p class="text-muted m-b-0">Online</p>
                                                </li>
                                                <li>
                                                    <h4 class=""><b runat="server" id="lblmobile">0</b></h4>
                                                    <p class="text-muted m-b-0">Mobile App</p>
                                                </li>
                                                <li>
                                                    <h4 class=""><b runat="server" id="lblussd">0</b></h4>
                                                    <p class="text-muted m-b-0">USSD</p>
                                                </li>
                                            </ul>

                                            <%--<div id="morris-donut-example" style="height: 300px"></div>--%>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-4">
                                    <div class="panel panel-primary">
                                        <div class="panel-body">
                                            <h4 class="m-t-0">Funding By Channel</h4>

                                            <ul class="list-inline widget-chart m-t-20 text-center">
                                                <li>
                                                    <h4 class=""><b runat="server" id="lblonlinefunds">$0</b></h4>
                                                    <p class="text-muted m-b-0">Online</p>
                                                </li>
                                                <li>
                                                    <h4 class=""><b runat="server" id="lblmobilefunds">$0</b></h4>
                                                    <p class="text-muted m-b-0">Mobile App</p>
                                                </li>
                                                <li>
                                                    <h4 class=""><b runat="server" id="lblussdfunds">$0</b></h4>
                                                    <p class="text-muted m-b-0">USSD</p>
                                                </li>

                                            </ul>

                                           <%-- <div id="morris-bar-example" style="height: 300px"></div>--%>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-4">
                                    <div class="panel panel-primary">
                                        <div class="panel-body">
                                            <h4 class="m-t-0">Holdings Distribution</h4>

                                            <ul class="list-inline widget-chart m-t-20 text-center">
                                                <li>
                                                    <h4 class=""><b runat="server" id="lblfinsec">10</b></h4>
                                                    <p class="text-muted m-b-0">Total Holdings</p>
                                                </li>
                                                <li>
                                                    <h4 class=""><b></b></h4>
                                                    <p class="text-muted m-b-0"></p>
                                                </li>
                                                <li>
                                                    <h4 class=""><b>0</b></h4>
                                                    <p class="text-muted m-b-0">CDC Holdings</p>
                                                </li>
                                            </ul>

                                           <%-- <div id="morris-area-example" style="height: 300px"></div>--%>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <!-- end row -->

                            <div class="row">
                                <div class="col-md-7">
                                    <div class="panel">
                                        <div class="panel-body">
                                            <h4 class="m-b-30 m-t-0">Top 7 Latest Registrations</h4>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <div class="table-responsive">
                                                        <table class="table table-hover m-b-0">
                                                            <thead>
                                                            <tr>
                                                                <th>Name</th>
                                                                <th>CDS No</th>
                                                                <th>Phone</th>
                                                                <th>Broker</th>
                                                                <th>ID Number</th>
                                                                <%--<th>Custodian</th>--%>
                                                            </tr>

                                                            </thead>
                                                            <tbody>
                                                            <tr>
                                                                <td runat="server" id="name1"></td>
                                                                <td runat="server" id="cds1"></td>
                                                                <td runat="server" id="phone1"></td>
                                                                <td runat="server" id="broker1"></td>
                                                                <td runat="server" id="idnumber1"></td>
                                                                <%--<td runat="server" id="custodian1"></td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td runat="server" id="name2"></td>
                                                                <td runat="server" id="cds2"></td>
                                                                <td runat="server" id="phone2"></td>
                                                                <td runat="server" id="broker2"></td>
                                                                <td runat="server" id="idnumber2"></td>
                                                               
                                                            </tr>
                                                            <tr>
                                                                <td runat="server" id="name3"></td>
                                                                <td runat="server" id="cds3"></td>
                                                                <td runat="server" id="phone3"></td>
                                                                <td runat="server" id="broker3"></td>
                                                                <td runat="server" id="idnumber3"></td>
                                                               <%-- <td runat="server" id="custodian3"></td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td runat="server" id="name4"></td>
                                                                <td runat="server" id="cds4"></td>
                                                                <td runat="server" id="phone4"></td>
                                                                <td runat="server" id="broker4"></td>
                                                                <td runat="server" id="idnumber4"></td>
                                                             <%--   <td runat="server" id="custodian4"></td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td runat="server" id="name5"></td>
                                                                <td runat="server" id="cds5"></td>
                                                                <td runat="server" id="phone5"></td>
                                                                <td runat="server" id="broker5"></td>
                                                                <td runat="server" id="idnumber5"></td>
                                                               <%-- <td runat="server" id="custodian5"></td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td runat="server" id="name6"></td>
                                                                <td runat="server" id="cds6"></td>
                                                                <td runat="server" id="phone6"></td>
                                                                <td runat="server" id="broker6"></td>
                                                                <td runat="server" id="idnumber6"></td>
                                                               <%-- <td runat="server" id="custodian6"></td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td runat="server" id="name7"></td>
                                                                <td runat="server" id="cds7"></td>
                                                                <td runat="server" id="phone7"></td>
                                                                <td runat="server" id="broker7"></td>
                                                                <td runat="server" id="idnumber7"></td>
                                                               <%-- <td runat="server" id="custodian7"></td>--%>
                                                            </tr>

                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- end col -->

                                <div class="col-md-5">
                                    <div class="panel">
                                        <div class="panel-body">
                                            <h4 class="m-b-30 m-t-0">Statistics</h4>

                                            <p class="font-600 m-b-5">Local Registrations <span class="text-primary pull-right"><b id="lbllocalregistrations" runat="server">80%</b></span></p>
                                            <div class="progress  m-b-20">
                                                <div id="lbllocalregistrations1" runat="server" class="progress-bar progress-bar-primary " role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%;">
                                                </div><!-- /.progress-bar .progress-bar-danger -->
                                            </div><!-- /.progress .no-rounded -->

                                            <p class="font-600 m-b-5">Failed Registrations <span class="text-primary pull-right"><b id="lblfailedregistrations" runat="server">50%</b></span></p>
                                            <div class="progress  m-b-20">
                                                <div id="lblfailedreg1" runat="server" class="progress-bar progress-bar-primary " role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" style="width: 50%;">
                                                </div><!-- /.progress-bar .progress-bar-pink -->
                                            </div><!-- /.progress .no-rounded -->

                                            <p class="font-600 m-b-5">Accounts with Holdings<span class="text-primary pull-right"><b id="lblwithholdings" runat="server">70%</b></span></p>
                                            <div class="progress  m-b-20">
                                                <div id="lblaccountswithholdings1" runat="server" class="progress-bar progress-bar-primary " role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 70%;">
                                                </div><!-- /.progress-bar .progress-bar-info -->
                                            </div><!-- /.progress .no-rounded -->

                                            <p class="font-600 m-b-5">Online Registrations <span class="text-primary pull-right"><b id="lblonlineper" runat="server">65%</b></span></p>
                                            <div class="progress  m-b-20">
                                                <div id="lblonline1" runat="server" class="progress-bar progress-bar-primary " role="progressbar" aria-valuenow="65" aria-valuemin="0" aria-valuemax="100" style="width: 65%;">
                                                </div><!-- /.progress-bar .progress-bar-warning -->
                                            </div><!-- /.progress .no-rounded -->

                                            <p class="font-600 m-b-5">Mobile App Registrations <span class="text-primary pull-right"><b id="lblmobileper" runat="server">25%</b></span></p>
                                            <div  class="progress  m-b-20">
                                                <div  id="lblmobile1" runat="server" class="progress-bar progress-bar-primary " role="progressbar" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" style="width: 25%;">
                                                </div><!-- /.progress-bar .progress-bar-warning -->
                                            </div><!-- /.progress .no-rounded -->

                                            <p class="font-600 m-b-5">USSD Registrations<span class="text-primary pull-right"><b id="lblussdperc" runat="server">40%</b></span></p>
                                            <div class="progress  m-b-0">
                                                <div id="lblussd1" runat="server" class="progress-bar progress-bar-primary " role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%;">
                                                </div><!-- /.progress-bar .progress-bar-success -->
                                            </div><!-- /.progress .no-rounded -->
                                        </div>
                                    </div>
                                </div> <!-- end col -->
                            </div>
                            <!-- end row -->



                        </div><!-- container -->


                    </div> <!-- Page content Wrapper -->

                </div> <!-- content -->

                <footer class="footer">
                     ©2018 Escrow Systems - All Rights Reserved.
                </footer>

            </div>
            <!-- End Right content here -->

        </div>
        <!-- END wrapper -->


        <!-- jQuery  -->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/modernizr.min.js"></script>
        <script src="assets/js/detect.js"></script>
        <script src="assets/js/fastclick.js"></script>
        <script src="assets/js/jquery.slimscroll.js"></script>
        <script src="assets/js/jquery.blockUI.js"></script>
        <script src="assets/js/waves.js"></script>
        <script src="assets/js/wow.min.js"></script>
        <script src="assets/js/jquery.nicescroll.js"></script>
        <script src="assets/js/jquery.scrollTo.min.js"></script>

        <!--Morris Chart-->
        <script src="assets/plugins/morris/morris.min.js"></script>
        <script src="assets/plugins/raphael/raphael-min.js"></script>

        <script src="assets/pages/dashborad.js"></script>

        <script src="assets/js/app.js"></script>

    </body>
</html>
