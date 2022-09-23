Imports System.Data
Imports System.Data.SqlClient
Partial Class CDSMode_PostedOrders
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim maxbatchref As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            'getCompany()
            HideControls()
        End If
    End Sub
    Public Sub HideControls()
        Try
            Label7.Visible = False
            txtSearch.Visible = False
            btnBatchSearch.Visible = False
            cmbBatch.Visible = False
            Label3.Visible = False
            BasicDatePicker1.Visible = False

            grdAddedCertificate.DataSource = Nothing
            grdAddedCertificate.DataBind()
            Button1.Visible = False
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getmaxBatchref()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select max(batch_ref) as batch_ref from broker_batch_header", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_header")
            maxbatchref = ((ds.Tables(0).Rows(0).Item("batch_ref").ToString) + 1)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompanyData()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select OrdersSummary.orderNumber as [Order Number], OrdersSummary.Company as [Company] , OrdersSummary.CDS_Number as [CDS Number], OrdersSummary.Order_Quantity as [Quantity], case OrdersSummary.ordertype when 'PUR' then 'PURCHASE' when 'SAL' then 'SELL' end AS [Order Type] ,OrdersSummary.OrderDate as [Order Date],para_broker.fnam as [Broker]  from OrdersSummary , para_broker where para_broker .broker_code = OrdersSummary.PurchasingBroker and OrdersSummary .Company ='" & cmbBatch.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                grdAddedCertificate.DataSource = ds.Tables(0)
                grdAddedCertificate.DataBind()
            Else
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()

                msgbox("Record not found")

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from ordersSummary ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbBatch.DataSource = ds.Tables(0)
                cmbBatch.DataValueField = "company"
                cmbBatch.DataBind()
                'txtSearch.Text = cmbBatch.SelectedValue
                getCompanyData()
            Else
                txtSearch.Text = ""
                cmbBatch.DataSource = Nothing
                cmbBatch.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub btnBatchSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBatchSearch.Click
        Try
            If (txtSearch.Text = "") Then
                msgbox("Enter a batch Reference Number")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select OrdersSummary.orderNumber as [Order Number], OrdersSummary.Company as [Company] , OrdersSummary.CDS_Number as [CDS Number], OrdersSummary.Order_Quantity as [Quantity], case OrdersSummary.ordertype when 'PUR' then 'PURCHASE' when 'SAL' then 'SELL' end AS [Order Type] ,OrdersSummary.OrderDate as [Order Date],para_broker.fnam as [Broker]  from OrdersSummary , para_broker where para_broker .broker_code = OrdersSummary.PurchasingBroker and OrdersSummary .OrderNumber ='" & txtSearch.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                grdAddedCertificate.DataSource = ds.Tables(0)
                grdAddedCertificate.DataBind()
            Else
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()

                msgbox("Record not found")

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub cmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.SelectedIndexChanged
        Try
            txtSearch.Text = cmbBatch.SelectedValue

            If rdByBroker.Checked = True Then
                getPurchasingBroker()
                getDatabYbROKERS()
            End If
            If (rdByCompany.Checked = True) Then
                getCompanyData()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getDatabYbROKERS()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select OrdersSummary.orderNumber as [Order Number], OrdersSummary.Company as [Company] , OrdersSummary.CDS_Number as [CDS Number], OrdersSummary.Order_Quantity as [Quantity], case OrdersSummary.ordertype when 'PUR' then 'PURCHASE' when 'SAL' then 'SELL' end AS [Order Type] ,OrdersSummary.OrderDate as [Order Date],para_broker.fnam as [Broker]  from OrdersSummary , para_broker where para_broker .broker_code = OrdersSummary.PurchasingBroker and OrdersSummary.PurchasingBroker ='" & Label8.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                grdAddedCertificate.DataSource = ds.Tables(0)
                grdAddedCertificate.DataBind()
            Else
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()

                msgbox("Record not found")

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdByOrderID_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdByOrderID.CheckedChanged
        Try
            HideControls()
            Label7.Visible = True
            Label7.Text = "Order id Number"
            txtSearch.Text = ""
            txtSearch.Visible = True
            btnBatchSearch.Visible = True
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdByBroker_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdByBroker.CheckedChanged
        HideControls()
        Label7.Visible = True
        Label7.Text = "Broker"
        cmbBatch.Visible = True

        Dim ds As New DataSet
        cmd = New SqlCommand("select distinct (purchasingbroker) as purchasingbroker, fnam from OrdersSummary, para_broker where OrdersSummary .PurchasingBroker = para_broker .broker_code", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "OrdersSummary")

        cmbBatch.DataSource = ds.Tables(0)
        cmbBatch.DataValueField = "fnam"
        cmbBatch.DataBind()

        Label8.Text = ds.Tables(0).Rows(0).Item("purchasingbroker").ToString


    End Sub
    Public Sub getPurchasingBroker()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_broker where fnam='" & cmbBatch.Text & "' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_broker")

            If (ds.Tables(0).Rows.Count > 0) Then
                Label8.Text = ds.Tables(0).Rows(0).Item("broker_code").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub rdBydate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdBydate.CheckedChanged
        HideControls()
        Label3.Visible = True
        Label3.Text = "Date"
        Label8.Text = ""
        BasicDatePicker1.Visible = True
        Button1.Visible = True

    End Sub

    Protected Sub rdByCompany_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdByCompany.CheckedChanged
        If (rdByCompany.Checked = True) Then
            HideControls()
            Label7.Visible = True
            Label7.Text = "Company"
            cmbBatch.Visible = True
            getCompany()
        End If
        

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If BasicDatePicker1.Text = "" Then
                msgbox("Select a valid date")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select OrdersSummary.orderNumber as [Order Number], OrdersSummary.Company as [Company] , OrdersSummary.CDS_Number as [CDS Number], OrdersSummary.Order_Quantity as [Quantity], case OrdersSummary.ordertype when 'PUR' then 'PURCHASE' when 'SAL' then 'SELL' end AS [Order Type] ,OrdersSummary.OrderDate as [Order Date],para_broker.fnam as [Broker]  from OrdersSummary , para_broker where para_broker .broker_code = OrdersSummary.PurchasingBroker and OrdersSummary .OrderDate ='" & BasicDatePicker1.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OrdersSummary")

            If (ds.Tables(0).Rows.Count > 0) Then
                grdAddedCertificate.DataSource = ds.Tables(0)
                grdAddedCertificate.DataBind()
            Else
                grdAddedCertificate.DataSource = Nothing
                grdAddedCertificate.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
