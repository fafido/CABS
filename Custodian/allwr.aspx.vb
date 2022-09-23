Imports System.Collections.Generic
Imports DevExpress.Web.ASPxEditors

Partial Class allwr
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public max As Decimal

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
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()

                loadall()
                Session("Temp") = ""
            End If
            loadall()
            If Session("finish") = "true" Then
                Session("finish") = ""
                msgbox("Warehouse Receipt Successfully Captured! Awaiting Authorization")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub



    Public Sub loadall()
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select ID, Holder, Commodity, Warehouse as [Operator], WarehousePhysical as [Warehouse] , Expiry, FORMAT(Price,'#,0.00') AS Price, format(Quantity,'#,0.00') as Quantity, InsurancePolicy, ReceiptNo, [Status]  from WR where  ApprovedOn is not NULL ORDER BY ID DESC ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()
        End If
    End Sub


    Protected Sub btnSaveContract0_Click(sender As Object, e As EventArgs) Handles btnSaveContract0.Click
        Dim keys As List(Of Object) = ASPxGridView3.GetSelectedFieldValues(ASPxGridView3.KeyFieldName)

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
        Dim PrintInforCopy As String = ""
        If chkPrintInfoCopy.Checked = True Then
            PrintInforCopy = "Yes"
        Else
            PrintInforCopy = "No"
        End If
        Dim queryString As String = "gvtschedulereport.aspx?id=" + id + "&PrintInforCopy=" & PrintInforCopy & ""
        'Dim queryString As String = "gvtschedulereport.aspx?id=" + id + ""
        Dim newWin As String = "window.open('" + queryString + "','_blank');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub



    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Dim ds As New DataSet
        cmd = New SqlCommand("  Select ID, Holder, Commodity, Warehouse as [Operator], WarehousePhysical as [Warehouse] , Expiry, FORMAT(Price,'#,###.##','en-us') as Price,FORMAT(Quantity,'#,###.##','en-us') as  Quantity, InsurancePolicy, ReceiptNo, [Status]  from WR where  ApprovedOn is not NULL  and convert(nvarchar(50),id)+' '+Holder+' '+commodity+' '+Warehouse+' '+WarehousePhysical+' '+InsurancePolicy+' '+ReceiptNo+' '+[Status] like '%" + txtsearch.Text + "%' ORDER BY ID DESC ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            ASPxGridView3.DataSource = ds
            ASPxGridView3.DataBind()
        End If
    End Sub
End Class
