Imports System.IO
Imports System.Array
Partial Class CDSMode_WSDLATSConfirmation
    Inherits System.Web.UI.Page
    Dim cnstr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim conn As New SqlConnection(cnstr)
    Dim cn As New SqlConnection(cnstr)
    Dim cmd As SqlCommand
    Dim comm As SqlCommand
    Dim adp As SqlDataAdapter
    Dim wk_rec As String, sw_first As Boolean, fs, f
    Dim wk_head_shares As Double, wk_head_cnt As Integer, wk_tot_shares As Double
    Dim wk_tot_cnt As Integer, wk_err As Integer, wk_date As Date, wk_sys_cds As Double, wk_cds_ac As Long
    Dim wk_dets_shareholder As Long, wk_work_shareholder As Long
    Dim wk_shares, wk_shareholder As Long
    Private _cmd1 As SqlCommand

    Private Property cmd1 As SqlCommand
        Get
            Return _cmd1
        End Get
        Set(value As SqlCommand)
            _cmd1 = value
        End Set
    End Property

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Not IsPostBack) Then
                GetOTCTrades()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetOTCTrades()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select * from OTC_Data_Import ", cn)
            cmd = New SqlCommand("select  company as [Company], orderNumber as [OrderNumber],OrderType as [Order Type] ,Cds_number as [CDS Number],Order_Quantity as [Quantity],OrderDate as [Order Date], CASE STATUS WHEN 'O' then 'PENDING' WHEN 'C' THEN 'CONFIRMED' WHEN 'X'then 'INVALID' END AS STATUS FROM OrdersSummary order by OrderDate desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OTC_Data_Import")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdOrdersSummary.DataSource = ds.Tables(0)
                grdOrdersSummary.DataBind()
            Else
                grdOrdersSummary.DataSource = Nothing
                grdOrdersSummary.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    
End Class
