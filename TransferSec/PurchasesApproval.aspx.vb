Partial Class Enquiries_purchasesApproval
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
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
                loadawaiting()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            txtClientNo.Text = ""
            txtTitle.Text = ""
            txtIDno.Text = ""
            txtForenames.Text = ""
            txtSurname.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub loadawaiting()
        Try

            Dim ds As New DataSet
            cmd = New SqlCommand("select CONVERT(NVARCHAR(50),ID)+' '+CLIENT_NO+' '+ISSUER as awaiting FROM TRANS_INSTRUMENTS WHERE UPDATE_STATUS='0'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbinstrument0.DataSource = ds
                cmbinstrument0.TextField = "awaiting"
                cmbinstrument0.DataBind()
            Else

            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

   
    Public Sub GetCashBal()
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Amount),0.0) as total from tbl_CashBalance where ClientID = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then

        End If

    End Sub
    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
      

        cmd = New SqlCommand("insert into trans select issuer, client_no, getdate(), getdate(), units,'Allot', 'Custodial', '0', 'S','0','0',instrument from trans_instruments where CONVERT(NVARCHAR(50),ID)+' '+CLIENT_NO+' '+ISSUER='" + cmbinstrument0.SelectedItem.Text + "' and update_status='0' update trans_instruments set update_status='1' where CONVERT(NVARCHAR(50),ID)+' '+CLIENT_NO+' '+ISSUER='" + cmbinstrument0.SelectedItem.Text + "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()

        cn.Close()

        clearfields2()
        ClearFields()

        loadawaiting()


        msgbox("Approved")

    End Sub

    Public Sub DepositReg()
        Dim result As Integer
        cmd = New SqlCommand("Update Deposits_Reg  Set Flag_Status='Closed' where CDS_Number='" & txtClientNo.Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        Dim cashbal As Double
        Dim ds As New DataSet
        cmd = New SqlCommand("select isnull(sum(Deposit_Amount),0.0) as total from Deposits_Reg where CDS_Number = '" & txtClientNo.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            cashbal = CDbl(ds.Tables(0).Rows(0).Item(0).ToString) + CDbl(txtunits.Text)
        Else
            cashbal = txtunits.Text
        End If
        cmd = New SqlCommand("", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        result = cmd.ExecuteNonQuery()
    End Sub
    Public Sub ClearFields()

        txtClientNo.Text = ""
        txtForenames.Text = ""
        txtIDno.Text = ""
        txtSurname.Text = ""
        txtTitle.Text = ""

    End Sub
    Public Sub clearfields2()
       
        txtunits.Text = ""
        txtfacevalue.Text = ""
        txtmaturity.Text = ""
        txtperiod.Text = ""
        txtprice.Text = ""
        txtprincipal.Text = ""
        txtpurpose.Text = ""
        txtunits.Text = ""
        txtinstrument.Text = ""
        txtissuer.Text = ""


    End Sub

   
   
    Public Sub getinstrumentstrans()
        '     Try
        Dim ds As New DataSet
        cmd = New SqlCommand("select Instrument, Issuer, Period as [Period(Months)], principal as [Principal Amt], Face_value as [Face Value], Units, Price, Purpose, Maturity_date as [Maturity Date] from trans_instruments where client_no='" + txtClientNo.Text + "' and update_status='1'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
          

        Else

        End If
        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub cmbinstrument0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbinstrument0.SelectedIndexChanged
        getselecteddetails()

    End Sub
    Public Sub getselecteddetails()
        Dim ds As New DataSet
        cmd = New SqlCommand("select * from Accounts_clients a, trans_instruments t where t.Client_No=a.CDS_Number and CONVERT(NVARCHAR(50),t.ID)+' '+CLIENT_NO+' '+ISSUER='" + cmbinstrument0.SelectedItem.Text + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts_Clients")
        If (ds.Tables(0).Rows.Count > 0) Then
            txtClientNo.Text = ds.Tables(0).Rows(0).Item("cds_number").ToString.ToUpper
            txtTitle.Text = ds.Tables(0).Rows(0).Item("title").ToString.ToUpper
            txtIDno.Text = ds.Tables(0).Rows(0).Item("idnopp").ToString.ToUpper
            txtForenames.Text = ds.Tables(0).Rows(0).Item("forenames").ToString.ToUpper
            txtSurname.Text = ds.Tables(0).Rows(0).Item("surname").ToString.ToUpper
            txtinstrument.Text = ds.Tables(0).Rows(0).Item("Instrument").ToString.ToUpper
            txtissuer.Text = ds.Tables(0).Rows(0).Item("Issuer").ToString.ToUpper
            txtmaturity.Text = ds.Tables(0).Rows(0).Item("maturity_date").ToString.ToUpper
            txtperiod.Text = ds.Tables(0).Rows(0).Item("Period").ToString.ToUpper
            txtprice.Text = ds.Tables(0).Rows(0).Item("Price").ToString.ToUpper
            txtprincipal.Text = ds.Tables(0).Rows(0).Item("Principal").ToString.ToUpper
            txtpurpose.Text = ds.Tables(0).Rows(0).Item("Purpose").ToString.ToUpper
            txtfacevalue.Text = ds.Tables(0).Rows(0).Item("face_value").ToString.ToUpper
            txtunits.Text = ds.Tables(0).Rows(0).Item("units").ToString.ToUpper
        Else

        End If
    End Sub
End Class
