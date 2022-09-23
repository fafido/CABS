Imports System.Data
Imports System.Data.SqlClient
Partial Class Parameters_BrokerFees
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
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
                getcurrentFees()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub getcurrentFees()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select top 1 * from para_fees order by dateUpdate desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_fees")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtBasicFee.Text = ds.Tables(0).Rows(0).Item("BasicFee").ToString
                txtStampDuty.Text = ds.Tables(0).Rows(0).Item("StampDuty").ToString
                txtPurchaseReg.Text = ds.Tables(0).Rows(0).Item("PurchaseRegistration").ToString
                txtMiniMumBrokerage.Text = ds.Tables(0).Rows(0).Item("MinimumBrokerage").ToString
                TxtTransferFees.Text = ds.Tables(0).Rows(0).Item("TransferFees").ToString
                txtWithholding.Text = ds.Tables(0).Rows(0).Item("WithholdingTax").ToString
                lblUpdateDate.Text = "Date Last Updates: " & ds.Tables(0).Rows(0).Item("DateUpdate").ToString
            Else
                txtBasicFee.Text = 0
                txtStampDuty.Text = 0
                txtPurchaseReg.Text = 0
                txtMiniMumBrokerage.Text = 0
                TxtTransferFees.Text = 0
                txtWithholding.Text = 0
                lblUpdateDate.Text = "No last Update"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnPrintStatement_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintStatement.Click
        Try
            cmd = New SqlCommand("insert into para_fees (BasicFee,StampDuty,PurchaseRegistration,MinimumBrokerage,TransferFees,WithholdingTax,DateUpdate) values(" & txtBasicFee.Text & "," & txtStampDuty.Text & "," & txtPurchaseReg.Text & "," & txtMiniMumBrokerage.Text & "," & TxtTransferFees.Text & "," & txtWithholding.Text & ",'" & Date.Now & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            getcurrentFees()
        Catch ex As Exception
            msgbox("Please enter all the fields, they are Mandatory")
        End Try
    End Sub
End Class
