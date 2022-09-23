Imports System.Data
Imports System.Data.SqlClient
Partial Class Depositors
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
    Dim validate As Boolean = False
    Dim maxholder As Integer = 0
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
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            GetAll()

        Else
            Try
                GetAll()
            Catch ex As Exception
                msgbox(ex.Message)
            End Try



        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        Else
        End If
    End Sub



    Public Sub GetAll()
        Dim ds As New DataSet
        cmd = New SqlCommand("  select CDS_Number as [Holder No.], BrokerCode as [Warehouse],case AccountType when 'i' then Forenames+' '+Surname else Surname+' '+Forenames  end as [Names], CNIC as [CNIC/Registration No], City, Country,'('+(select top 1 phonecode from para_country where country=accounts_clients.country)+') '+Mobile as [Mobile], Email from Accounts_Clients", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub
    Public Sub GetAll_filter(searchtext As String)
        Dim ds As New DataSet
        cmd = New SqlCommand("select CDS_Number as [Holder No.], BrokerCode as [Warehouse],case AccountType when 'i' then Forenames+' '+Surname else Surname+' '+Forenames  end as [Names], CNIC as [CNIC/Registration No], City, Country,'('+(select top 1 phonecode from para_country where country=accounts_clients.country)+') '+Mobile as [Mobile], Email from Accounts_Clients where cds_number+' '+BrokerCode+' '+Forenames+' '+Surname+' '+IDNOPP+' '+CNIC+' '+COUNTRY+' '+CITY+' '+MOBILE+' '+EMAIL LIKE '%" + searchtext + "%'", cn)
        adp = New SqlDataAdapter(cmd)
        cmd.CommandTimeout = 99999
        adp.Fill(ds, "para_lendingRules")
        If (ds.Tables(0).Rows.Count > 0) Then
            grdRules.DataSource = ds.Tables(0)
            grdRules.DataBind()
        Else
            grdRules.DataSource = Nothing
            grdRules.DataBind()
        End If
        ' ''Catch ex As Exception
        ' ''    msgbox(ex.Message)
        ' ''End Try
    End Sub


    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click

        GetAll()

        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            GetAll_filter(txtsearch.Text)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
End Class
