Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Shared random As New Random()
    'Dim Mail As New MailMessage
    'Dim SMTP As New SmtpClient("smtp.googlemail.com")


    Public Sub GetCurrencies()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_currencies where CurrencyStatus <> 'default'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Currencies")
            If (ds.Tables(0).Rows.Count > 0) Then

                ddCurrency.DataSource = ds.Tables(0)
                ddCurrency.DataTextField = "CurrencyName"
                ddCurrency.DataValueField = "CurrencyCode"
                ddCurrency.DataBind()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub GetDefaultCurrency()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_Currencies where CurrencyStatus='default'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Currencies")
            If (ds.Tables(0).Rows.Count > 0) Then
                lbldefaultcur.Text = ds.Tables(0).Rows(0).Item("CurrencyCode")
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            GetCurrencies()
            GetDefaultCurrency()
            FillGrid()
        End If
    End Sub
    Public Function CheckRateOverlap() As Boolean
        CheckRateOverlap = False
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from para_CurrencyRates Where CurrencyCode='" & ddCurrency.DataTextField & "' and  DateFrom <= '" & dtpFrom.Text & "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_CurrencyRates")

        If (ds.Tables(0).Rows.Count > 0) Then
            CheckRateOverlap = True
        Else
            CheckRateOverlap = False
        End If
    End Function
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        If CheckRateOverlap() = True Then
            MsgBox("Possible rates overlap kindly adjust dates")
            Exit Sub
        End If
        If txtRate.Text = "" Then
            msgbox("Please enter the rate!")
            Exit Sub
        Else
            If dtpFrom.Text = "" Then
                msgbox("Please enter the Date from!")
                Exit Sub
            Else

            End If
        End If
        Dim dsid As New DataSet

        If ASPxButton1.Text = "Save Rate" Then
            Dim cmd1 = New SqlCommand("insert into para_CurrencyRates (CurrencyCode,RateToBase,DateFrom) values (@currencycode,@ratetobase,@datefrom)", cn)
            cmd1.Parameters.AddWithValue("@currencycode", ddCurrency.Text)
            cmd1.Parameters.AddWithValue("@ratetobase", txtRate.Text)
            cmd1.Parameters.AddWithValue("@datefrom", dtpFrom.Text)
            '   cmd1.Parameters.AddWithValue("@dateto", dtpTo.Text)

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd1.ExecuteNonQuery()
            cn.Close()
            msgbox("New rate entry saved successfully")
        Else
            Dim cmd1 As SqlCommand

            cmd1 = New SqlCommand("update para_CurrencyRates set currencycode=@currencycode, RateToBase=@RateToBase, DateFrom=@DateFrom where RateID = @SelectedID", cn)
            cmd1.Parameters.AddWithValue("@currencycode", ddCurrency.Text)
            cmd1.Parameters.AddWithValue("@RateToBase", txtRate.Text)
            cmd1.Parameters.AddWithValue("@DateFrom", dtpFrom.Text)
            '  cmd1.Parameters.AddWithValue("@DateTo", dtpTo.Text)
            cmd1.Parameters.AddWithValue("@SelectedID", grdvRates.SelectedRow.Cells(1).Text)

            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd1.ExecuteNonQuery()
            cn.Close()
            msgbox("Rate entry edited successfully")
        End If
        GetCurrencies()
        FillGrid()
        txtRate.Text = ""

    End Sub
    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT RateID,CurrencyCode,RateToBase,Datefrom as [Date] from  para_CurrencyRates order by [Datefrom] desc, rateid desc", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_CurrencyRates")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvRates.DataSource = ds.Tables(0)
            grdvRates.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub

    Protected Sub grdvRates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvRates.SelectedIndexChanged

        ASPxButton1.Text = "Update Rate"
        ddCurrency.Text = grdvRates.SelectedRow.Cells(2).Text
        txtRate.Text = grdvRates.SelectedRow.Cells(3).Text
        dtpFrom.SelectedDate = grdvRates.SelectedRow.Cells(4).Text
        '  dtpTo.SelectedDate = grdvRates.SelectedRow.Cells(5).Text

        btnDelete.Visible = True
        btnClear.Visible = True
        'Dim cmd1 = New SqlCommand("Delete from para_CurrencyRates where CurrencyCode = '" & grdvRates.SelectedRow.Cells(1).Text & "'", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd1.ExecuteNonQuery()
        'cn.Close()

        FillGrid()
    End Sub
    Protected Sub btnSave0_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim cmd1 = New SqlCommand("delete  para_CurrencyRates  where RateID = '" & grdvRates.SelectedRow.Cells(1).Text & "'", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()
        msgbox("Rate entry successfull deleted")
        FillGrid()
    End Sub
    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtRate.Text = ""
        ASPxButton1.Text = "Save Rate"
        btnDelete.Visible = False
        btnClear.Visible = False
    End Sub
End Class
