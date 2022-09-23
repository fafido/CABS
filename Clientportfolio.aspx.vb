Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Class Depositor_Clientportfolio
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim irow As Integer
    Public Shared val As Integer = 0

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub checkSessionState()
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserName").ToString = "" Then
            Session.Abandon()
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Buffer = True
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0)
            Response.Expires = -1000
            Response.CacheControl = "no-cache"
            Response.Redirect("~/loginsystem.aspx", True)
        End If
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()
                Panel5.Visible = True
                Panel3.Visible = True
                Panel2.Visible = True
                Getwahousesfin()
                Getwahouses()
                GetwahousesPledges()
                GetwahousesSplited()




            End If

            Getwahousesfin()
            Getwahouses()
            GetwahousesPledges()
            GetwahousesSplited()



        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub GetwahousesPledges()
        Try





            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT  w.id ,w.id as [S.No], s.WarehouseName  ,w.Commodity ,w.Grade , FORMAT(w.Quantity,'#,0.00') as [Quantity]  ,FORMAT(w.Price,'#,0.00') as [Price]  ,w.ReceiptNo  ,w.UnitMeasure as [Unit of Measure] FROM [CDS].[dbo].[WR] W ,[CDS].[dbo].[WarehouseCreation] S where s.WarehouseCode = w.WarehousePhysical and w.Holder = '" + getDEPCDS(Session("Username")) + "' and  isnull(Status ,'') ='PLEDGED'  ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then



                GridView2.DataSource = ds.Tables(0)
                GridView2.DataBind()
            Else

                GridView2.DataSource = Nothing
                GridView2.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub GetwahousesSplited()
        Try





            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT  w.id ,w.id as [S.No], s.WarehouseName  ,w.Commodity ,w.Grade , (select top 1  FORMAT( ISNULL(OriginalQTY,'0'),'#,0.00')  FROM [CDS].[dbo].[tblWRSplits] s where OriginalWRNo  = w.ReceiptNo ) as  [Quantity]  ,FORMAT(w.Price,'#,0.00') as [Price]  ,w.ReceiptNo  ,w.UnitMeasure as [Unit of Measure] FROM [CDS].[dbo].[WR] W ,[CDS].[dbo].[WarehouseCreation] S where s.WarehouseCode = w.WarehousePhysical and w.Holder = '" + getDEPCDS(Session("Username")) + "' and  isnull(w.Status ,'') ='SPLIT' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then



                ASPxGridView1.DataSource = ds.Tables(0)
                ASPxGridView1.DataBind()
            Else

                ASPxGridView1.DataSource = Nothing
                ASPxGridView1.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub Getwahousesfin()
        Try



            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT  w.id ,w.id as [S.No], s.WarehouseName  ,w.Commodity ,w.Grade , FORMAT(w.Quantity,'#,0.00') as [Quantity] , FORMAT(w.Price,'#,0.00') as [Price]  ,w.ReceiptNo  ,w.UnitMeasure as [Unit of Measure] FROM [CDS].[dbo].[WR] W ,[CDS].[dbo].[WarehouseCreation] S where s.WarehouseCode = w.WarehousePhysical and w.Holder = '" + getDEPCDS(Session("Username")) + "' and  isnull(Status ,'') ='ISSUED'  ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then



                GridView1.DataSource = ds.Tables(0)
                GridView1.DataBind()

            Else

                GridView1.DataSource = Nothing
                GridView1.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Sub Getwahouses()
        Try



            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT  w.id ,w.id as [S.No], s.WarehouseName  ,w.Commodity ,w.Grade , FORMAT(w.Quantity,'#,0.00') as [Quantity] ,FORMAT(w.Price,'#,0.00') as [Price] ,w.ReceiptNo ,w.UnitMeasure as [Unit of Measure] FROM [CDS].[dbo].[WR] W ,[CDS].[dbo].[WarehouseCreation] S where s.WarehouseCode = w.WarehousePhysical and w.Holder = '" + getDEPCDS(Session("Username")) + "'  and isnull(Status ,'') LIKE '%AFT%' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then



                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else

                grdRules.DataSource = Nothing
                grdRules.DataBind()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim chkView As CheckBox
    '        chkView = DirectCast(e.Row.FindControl("chkRow1"), CheckBox)
    '        Dim id = DirectCast(e.Row.FindControl("id"), Label).Text
    '        msgbox(id)

    '        If chkView.Checked = True Then




    '            'If irow = 0 Then
    '            '    chkView.Checked = getatfdetailts(id)
    '            '    irow += 1
    '            'ElseIf irow >= 1 Then
    '            '    msgbox("You can not process more than 1 transaction .Please select 1 transaction")
    '            '    chkView.Checked = False
    '            '    irow = 0
    '            'End If
    '        End If


    '    End If
    'End Sub









    Public Function getDEPCDS(CDSno As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select Role  FROM [CDS].[dbo].[SystemUsers] where UserName='" + CDSno + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("Role").ToString
        Else
            Return ""

        End If
    End Function


    Protected Sub lstSearchAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearchAcc.SelectedIndexChanged
        Try
            If Session("usertype") = "CDSAdmin" Or Session("usertype") = "CDSUser" Then
                Dim ds As New DataSet
                cmd = New SqlCommand("select FORENAMES, SURNAME, LEFT(CDS_NUMBER,100) AS CDS_NUMBER from Accounts_clients where LEFT(cds_number,100)+' '+surname+ ' '+forenames = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                    Dim ds1 As New DataSet
                    cmd = New SqlCommand("select distinct company as company from trans where cds_number = '" & lblCDsNumber.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds1, "trns")
                    If ds1.Tables("trns").Rows.Count > 0 Then
                        'ASPxComboBox1.DataSource = ds1
                        'ASPxComboBox1.TextField = "company"
                        'ASPxComboBox1.DataBind()
                    End If

                Else
                    lblCDsAccount.Text = ""
                    lblCDsNumber.Text = ""
                End If
            Else
                Dim ds As New DataSet
                cmd = New SqlCommand("select FORENAMES, SURNAME, CDS_NUMBER AS CDS_NUMBER from names where cds_number+' '+surname+ ' '+forenames = '" & lstSearchAcc.SelectedItem.Text & "'", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "names")
                If (ds.Tables(0).Rows.Count > 0) Then
                    lblCDsNumber.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString
                    lblCDsAccount.Text = ds.Tables(0).Rows(0).Item("Forenames").ToString & " " & ds.Tables(0).Rows(0).Item("Surname").ToString

                    Dim ds1 As New DataSet
                    cmd = New SqlCommand("select distinct company as company from trans where cds_number = '" & lblCDsNumber.Text & "'", cn)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds1, "trns")
                    If ds1.Tables("trns").Rows.Count > 0 Then
                        'ASPxComboBox1.DataSource = ds1
                        'ASPxComboBox1.TextField = "company"
                        'ASPxComboBox1.DataBind()
                    End If

                Else
                    lblCDsAccount.Text = ""
                    lblCDsNumber.Text = ""
                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub







    Public Function getemail(cdsnumber As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select email from accounts_clients where cds_Number='" + cdsnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "names")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("email").ToString
        Else
            Return ""
        End If
    End Function

    Public Function checkotp(otp As String) As Boolean
        Dim ds As New DataSet

        cmd = New SqlCommand("select top 1 *   FROM [CDS].[dbo].[AFT] where isnull(OTP,'')='" + otp.Trim + "' order by id desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "otp")
        If (ds.Tables(0).Rows.Count > 0) Then

            Return False


        Else
            Return True


        End If
    End Function

    Public Function getoperator(cdsnumber As String) As String
        Dim ds As New DataSet
        cmd = New SqlCommand("select BrokerCode from accounts_clients where cds_number='" + cdsnumber + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("BrokerCode").ToString
        Else
            Return ""
        End If

    End Function




    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Try
            Dim keys As List(Of Object) = GridView1.GetSelectedFieldValues(GridView1.KeyFieldName)

            ' Dim id As String = keys(0).ToString

            Dim id As String = ""
            Try
                id = keys(0).ToString
            Catch ex As Exception
                id = ""
            End Try


            If id.Trim = "" Then
                msgbox("please select receipt first")
                Exit Sub
            End If
            Dim PrintInforCopy As String = "Yes"



            Dim queryString As String = "../Custodian/gvtschedulereport.aspx?id=" + id + "&PrintInforCopy=" & PrintInforCopy & ""
            'Dim queryString As String = "gvtschedulereport.aspx?id=" + id + ""
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Try
            Dim keys As List(Of Object) = ASPxGridView1.GetSelectedFieldValues(ASPxGridView1.KeyFieldName)

            ' Dim id As String = keys(0).ToString

            Dim id As String = ""
            Try
                id = keys(0).ToString
            Catch ex As Exception
                id = ""
            End Try


            If id.Trim = "" Then
                msgbox("please select receipt first")
                Exit Sub
            End If
            Dim PrintInforCopy As String = "Yes"



            Dim queryString As String = "../Custodian/gvtschedulereport.aspx?id=" + id + "&PrintInforCopy=" & PrintInforCopy & ""
            'Dim queryString As String = "gvtschedulereport.aspx?id=" + id + ""
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSaveContract0_Click(sender As Object, e As EventArgs) Handles btnSaveContract0.Click
        Try
            Dim keys As List(Of Object) = grdRules.GetSelectedFieldValues(grdRules.KeyFieldName)

            ' Dim id As String = keys(0).ToString

            Dim id As String = ""
            Try
                id = keys(0).ToString
            Catch ex As Exception
                id = ""
            End Try


            If id.Trim = "" Then
                msgbox("please select receipt first")
                Exit Sub
            End If
            Dim PrintInforCopy As String = "Yes"



            Dim queryString As String = "../Custodian/gvtschedulereport.aspx?id=" + id + "&PrintInforCopy=" & PrintInforCopy & ""
            'Dim queryString As String = "gvtschedulereport.aspx?id=" + id + ""
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Try
            Dim keys As List(Of Object) = GridView2.GetSelectedFieldValues(GridView2.KeyFieldName)

            ' Dim id As String = keys(0).ToString

            Dim id As String = ""
            Try
                id = keys(0).ToString
            Catch ex As Exception
                id = ""
            End Try


            If id.Trim = "" Then
                msgbox("please select receipt first")
                Exit Sub
            End If
            Dim PrintInforCopy As String = "Yes"



            Dim queryString As String = "../Custodian/gvtschedulereport.aspx?id=" + id + "&PrintInforCopy=" & PrintInforCopy & ""
            'Dim queryString As String = "gvtschedulereport.aspx?id=" + id + ""
            Dim newWin As String = "window.open('" + queryString + "','_blank');"
            ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        Catch ex As Exception

        End Try
    End Sub



    'Protected Sub btnprocess_Click(sender As Object, e As EventArgs) Handles btnprocess.Click
    '    Dim qnty As String



    '    For i As Integer = 0 To grdRules.VisibleRowCount - 1
    '        Dim dataColumn As GridViewDataColumn = TryCast(grdRules.Columns(0), GridViewDataColumn)
    '        Dim box As ASPxCheckBox = TryCast(grdRules.FindRowCellTemplateControl(i, dataColumn, "cbStatus"), ASPxCheckBox)
    '        Dim dataColumn1 As GridViewDataColumn = TryCast(grdRules.Columns(5), GridViewDataColumn)

    '        Dim quanty As ASPxLabel = TryCast(grdRules.FindRowCellTemplateControl(i, dataColumn1, "quantity"), ASPxLabel)




    '        ' Dim Id As String = Row.Cells(2).Text

    '        If box IsNot Nothing AndAlso box.Checked = True Then
    '            ' msgbox(val)


    '            ViewState("irowcheched") += 1
    '        End If



    '    Next


    '    For i As Integer = 0 To GridView1.VisibleRowCount - 1
    '        Dim dataColumn As GridViewDataColumn = TryCast(GridView1.Columns(0), GridViewDataColumn)

    '        Dim box As ASPxCheckBox = TryCast(GridView1.FindRowCellTemplateControl(i, dataColumn, "cbStatus1"), ASPxCheckBox)
    '        Dim dataColumn1 As GridViewDataColumn = TryCast(GridView1.Columns(5), GridViewDataColumn)

    '        Dim quanty As ASPxLabel = TryCast(GridView1.FindRowCellTemplateControl(i, dataColumn1, "quantity1"), ASPxLabel)


    '        If box IsNot Nothing AndAlso box.Checked = True Then
    '            ' msgbox(val)
    '            qnty = Replace(quanty.Value, ",", "")

    '            If qnty > 10 Then
    '                msgbox("Quantity for this EWR is greater than 10MT required for AFT marking .Please first split this EWR then proceed")
    '                box.Checked = False
    '                Exit Sub
    '            End If

    '            ViewState("irowcheched") += 1
    '        End If



    '    Next

    '    If ViewState("irowcheched") > 1 Then


    '        msgbox("You cannot mark more than 1 transaction,Uncheck all then proceed")
    '        ViewState("irowcheched") = 0

    '        Exit Sub

    '    End If





    '    Dim recp As String = ""
    '    Dim ds As New DataSet

    '    If ViewState("trnsid") <> "" And ViewState("trnsid1") = "" Then

    '    Else
    '        ViewState("trnsid") = ViewState("trnsid1")
    '    End If

    '    cmd = New SqlCommand("select id ,ReceiptNo FROM [CDS].[dbo].[WR] where ID='" + ViewState("trnsid") + "' ", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "otp")
    '    If (ds.Tables(0).Rows.Count > 0) Then
    '        recp = ds.Tables(0).Rows(0).Item("ReceiptNo").ToString()
    '        ViewState("recp") = recp

    '    End If
    '    Dim OTP As String = CreateOTP(4)
    '    Dim xyz As New Common
    '    If xyz.OTPenabled = True Then
    '        If (cn.State = ConnectionState.Open) Then
    '            cn.Close()
    '        End If
    '        cn.Open()

    '        Dim z As New sendmail

    '        Try
    '            z.sendmail(getemail(getDEPCDS(Session("Username"))).ToString, "AFT Authorization Request", "A AFT on EWR No. " + recp.ToString + " has been initiated in your account. Please authorize using OTP: " + OTP + "")
    '        Catch ex As Exception
    '            msgbox("Error Sending Email:" + ex.Message + "")
    '        End Try

    '        If (ViewState("trnsid") <> "" And ViewState("trnsid1") = "") Then





    '            cmd = New SqlCommand("insert into  [CDS].[dbo].[AFT] ([AFT_Quantity],[EWR_holder],[date],[status],[query],[ReceiptID],ParticipantCode,[OTP],[OTPSent],AFT_Type,OTPCreateTime)  select Quantity as amount,Holder,GETDATE() , '0','0',ReceiptNo,'" + getoperator(getDEPCDS(Session("Username"))) + "','" + OTP + "','1','Mark AFT',GETDATE()    FROM [CDS].[dbo].[WR] where id = '" + ViewState("trnsid") + "'", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()
    '            End If
    '            cn.Open()

    '        ElseIf (ViewState("trnsid1") <> "") Then

    '            cmd = New SqlCommand("insert into  [CDS].[dbo].[AFT] ([AFT_Quantity],[EWR_holder],[date],[status],[query],[ReceiptID],ParticipantCode,[OTP],[OTPSent],AFT_Type,OTPCreateTime)  select Quantity as amount,Holder,GETDATE() , '0','0',ReceiptNo,'" + getoperator(getDEPCDS(Session("Username"))) + "','" + OTP + "','1','Un-mark AFT' ,GETDATE()  FROM [CDS].[dbo].[WR] where id = '" + ViewState("trnsid") + "'", cn)
    '            If (cn.State = ConnectionState.Open) Then
    '                cn.Close()
    '            End If
    '            cn.Open()

    '        End If


    '        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
    '        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

    '        ASPxPopupControl1.AllowDragging = True
    '        ASPxPopupControl1.ShowCloseButton = True
    '        ASPxPopupControl1.ShowOnPageLoad = True
    '        Page.MaintainScrollPositionOnPostBack = True
    '        ViewState("irowcheched") = 0
    '        If cmd.ExecuteNonQuery() = 1 Then

    '            msgbox("Transaction successfully captured, enter OTP to submit")

    '        End If

    '    Else
    '        cmd = New SqlCommand("insert into  [CDS].[dbo].[AFT] ([AFT_Amount],[EWR_holder],[date],[status],[query],[ReceiptID],ParticipantCode)  select Price * Quantity as amount,Holder,GETDATE() , '0','0',ReceiptNo,'" + getoperator(getDEPCDS(Session("Username"))) + "'  FROM [CDS].[dbo].[WR] where id = '" + ViewState("trnsid") + "')", cn)

    '        If cmd.ExecuteNonQuery() = 1 Then

    '            msgbox("You have successfully Submitted EWR " + recp.ToString + " waiting for final approval")
    '            ASPxPopupControl1.AllowDragging = False
    '            ASPxPopupControl1.ShowCloseButton = False
    '            ASPxPopupControl1.ShowOnPageLoad = False
    '            Page.MaintainScrollPositionOnPostBack = False

    '        End If

    '    End If

    '    Dim ds1 As New DataSet



    '    cmd = New SqlCommand("select id  FROM [CDS].[dbo].[AFT] where isnull(OTP,'')='" + OTP.Trim + "'  and ReceiptID = '" + recp.ToString + "' and EWR_holder  = '" + getDEPCDS(Session("Username")) + "'", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds1, "otp")
    '    If (ds1.Tables(0).Rows.Count > 0) Then
    '        ViewState("trnsid") = ds1.Tables(0).Rows(0).Item("id").ToString()
    '        ' msgbox(ViewState("trnsid"))
    '        lbltransid.Text = ViewState("trnsid")


    '    End If
    '    cn.Close()









    '    ViewState("trnsid") = ""
    '    ViewState("trnsid1") = ""




    'End Sub
End Class
