Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_BatchReceipt
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            getCompany()
            getBroker()
            GetBatchTypes()
        End If
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
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbParaCompany.DataSource = ds.Tables(0)
            cmbParaCompany.DataValueField = "company"
            cmbParaCompany.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getBroker()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select fnam from para_broker", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Para_broker")
            CmbBroker.DataSource = ds.Tables(0)
            CmbBroker.DataValueField = "fnam"
            CmbBroker.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If (txtBatchShares.Text = "") Then
                MsgBox("Enter total batch shares")
                Exit Sub
            End If
            If (rdLodger.Checked = True) Then
                If (txtLodger.Text = "") Then
                    MsgBox("Enter a Lodger's name")
                    Exit Sub
                End If
            End If
            cmd = New SqlCommand("insert into batch_header ()values()", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub GetBatchTypes()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select distinct (batch_Type) from Para_Batch_type order by Batch_Type", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_batch_type")
            If (ds.Tables(0).Rows.Count > 0) Then
                CmbBatchType.DataSource = ds.Tables(0)
                CmbBatchType.DataValueField = "batch_Type"
                CmbBatchType.DataBind()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub rdBroker_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdBroker.CheckedChanged
        Try
            If (rdBroker.Checked = True) Then
                txtLodger.Visible = False
                txtLodger.Text = ""
                CmbBroker.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub rdLodger_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdLodger.CheckedChanged
        Try
            If (rdLodger.Checked = True) Then
                txtLodger.Visible = True
                CmbBroker.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
