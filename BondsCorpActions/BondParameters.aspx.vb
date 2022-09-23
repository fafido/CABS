Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Services

Partial Class Corp_MMParams
    Inherits System.Web.UI.Page
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
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                getCompanies()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub getCompanies()
        Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("SELECT DISTINCT a.Code FROM Bond a order by a.Code", cn)
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Bond")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbCompany.DataSource = ds
                cmbCompany.ValueField = "Code"
                cmbCompany.TextField = "Code"
                cmbCompany.DataBind()
            Else
                cmbCompany.DataSource = Nothing
                cmbCompany.DataBind()
            End If
        End Using
    End Sub
    Protected Sub cmbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        getDividendData()
    End Sub
    Sub getDividendData()
        If cmbCompany.Text <> "" Then
            Dim strSQL As String = " "
            strSQL = "SELECT ID,PaymentNo,Code,format(PaymentDate,'dd-MMM-yyyy','en-us') as PaymentDate,Amount AS [Interest Amount],CapitalAmount as [Capital Amount],CapitalPercentage as [Capital Percentage] FROM Bond_InterestPayment WHERE Code=@Company ORDER BY PaymentDate"
            Using cn = New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Dim ds As New DataSet
                Dim cmd = New SqlCommand(strSQL, cn)
                cmd.Parameters.AddWithValue("@Company", cmbCompany.Value)
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "dividend")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdParams.DataSource = ds
                    grdParams.DataBind()
                Else
                    grdParams.DataSource = Nothing
                    grdParams.DataBind()
                End If
            End Using
        End If
    End Sub
End Class
