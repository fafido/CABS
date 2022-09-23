
Partial Class Custodian_searchform2
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then


                loadDetailsALL()


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


    Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If txtid.Text = "" Then
            msgbox("Please Enter Id")
            Exit Sub
        End If
        loadDetails(txtid.Text)


    End Sub

    Protected Sub loadDetails(ID As String)
        Try
            Using con As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Using cmd = New SqlCommand("  select Holder, a.surname+' '+a.forenames as [Names] , Commodity, Grade, Warehouse as [Warehouse Operator], WarehousePhysical as [Warehouse], Quantity, isnull(w.[Status],'Active') as [Status], c.County  from [WR] w, accounts_clients a, client_companies c where c.company_code=w.warehouse and a.cds_number=w.holder and w.[id]='" & ID & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QD")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grddetails.DataSource = ds.Tables(0)
                    Else
                        grddetails.DataSource = Nothing
                    End If
                    grddetails.DataBind()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub loadDetailsALL()
        Try
            Using con As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("connpath"))
                Using cmd = New SqlCommand(" select Holder, a.surname+' '+a.forenames as [Names] , Commodity, Grade, Warehouse as [Warehouse Operator], WarehousePhysical as [Warehouse], Quantity, isnull(w.[Status],'Active') as [Status], c.County  from [WR] w, accounts_clients a, client_companies c where c.company_code=w.warehouse and a.cds_number=w.holder and (w.[status]='LOST' OR w.[status]='STOLLEN')", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QD")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grddetails.DataSource = ds.Tables(0)
                    Else
                        grddetails.DataSource = Nothing
                    End If
                    grddetails.DataBind()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


End Class
