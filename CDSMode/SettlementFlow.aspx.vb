
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadGridsOrdersSummary()
        LoadGridsPool()
        LoadGridsRaw()
        
    End Sub
    Public Sub LoadGridsOrdersSummary()
        Dim ds As New DataSet

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd = New SqlCommand("SELECT OrderNumber,Company,CDS_Number,Order_Quantity,OrderValue,OrderType,OrderDate,PurchasingBroker,CapturedBy,Status from OrdersSummary where SettlementRef is not Null", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "OrdersSummary")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvOrdersSummary.DataSource = ds.Tables(0)
            grdvOrdersSummary.DataBind()
        Else
            'msgbox("not found")
        End If

    End Sub
    
    Public Sub LoadGridsPool()
        Dim ds As New DataSet
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd = New SqlCommand("SELECT * from SettlementPool", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SettlementPool")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvBankOutbox.DataSource = ds.Tables(0)
            grdvBankOutbox.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub
    Public Sub LoadGridsRaw()
        Dim ds As New DataSet
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        cmd = New SqlCommand("SELECT * from MessageLog", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "BankResponses")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvBankResponses.DataSource = ds.Tables(0)
            grdvBankResponses.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub
    
   
End Class
