Partial Class CDSMode_CertificatesTracking
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Protected Sub btnHolderNumSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHolderNumSearch.Click
        Try
            If (txtshareholder.Text = "") Then
                msgbox("Enter a valid Shareholder Number")
                Exit Sub
            End If
            Dim ds As New DataSet
            cmd = New SqlCommand("select mast.cert as [Certificate], mast.CDS_Number as [CDS Number] , mast.Date_Created as [Date Created], names.Surname +' '+ names.Forenames as [Holder] from names, mast where names.CDS_Number = mast.CDS_Number and mast.cert = " & txtshareholder.Text & " and mast.company='" & cmbCompany.Text & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "mast")

            If (ds.Tables(0).Rows.Count > 0) Then
                grdCertsRec.DataSource = ds.Tables(0)
                grdCertsRec.DataBind()
            Else
                grdCertsRec.DataSource = Nothing
                grdCertsRec.DataBind()
                msgbox("No record found")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")

            If (ds.Tables(0).Rows.Count > 0) Then
                cmbCompany.DataSource = ds.Tables(0)
                cmbCompany.DataValueField = "company"
                cmbCompany.DataBind()
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (Not IsPostBack) Then
                getcompany()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
