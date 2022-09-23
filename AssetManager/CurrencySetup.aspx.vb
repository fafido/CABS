
Imports System.Net.Mail
Imports System.IO

Partial Class Parameters_CurrencySetup
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Shared random As New Random()
    Dim Mail As New MailMessage
    Dim SMTP As New SmtpClient("smtp.googlemail.com")
  
    Public Sub GetCurStatus()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_CurrencyStatus", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_CurrencyStatus")
            If (ds.Tables(0).Rows.Count > 0) Then

                ddSStatus.DataSource = ds.Tables(0)
                ddSStatus.DataTextField = "StatusCode"
                ddSStatus.DataValueField = "StatusCode"
                ddSStatus.DataBind()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            GetCurStatus()

            FillGrid()

        End If
       
    End Sub

 

    'Protected Sub btnSetBase_Click() Handles btnSetBase.Click
    '    Dim cmd1 = New SqlCommand("Update para_Currencies set CurrencyStatus='BASE' Where CurrencyCode='" & ddCurrencies.DataValueField & "'", cn)
    '    If (cn.State = ConnectionState.Open) Then
    '        cn.Close()
    '    End If
    '    cn.Open()
    '    cmd1.ExecuteNonQuery()
    '    cn.Close()
    '    lblBase.Text = ddCurrencies.DataValueField
    'End Sub
    Public Sub FillGrid()
        Dim ds As New DataSet
        cmd = New SqlCommand("SELECT * from para_Currencies", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Currencies")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvCurrencies.DataSource = ds.Tables(0)
            grdvCurrencies.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub

    Protected Sub grdvCurrencies_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdvCurrencies.SelectedIndexChanged
        'If Not IsPostBack = True Then
        Try
            txtCCode.Text = grdvCurrencies.SelectedRow.Cells(1).Text
            txtCName.Text = grdvCurrencies.SelectedRow.Cells(2).Text
            txtCSymbol.Text = grdvCurrencies.SelectedRow.Cells(3).Text
            txtIntStd.Text = grdvCurrencies.SelectedRow.Cells(4).Text
            ddSStatus.Text = grdvCurrencies.SelectedRow.Cells(5).Text
            btnSave.Text = "Update Currency"
            btnDelete.Visible = True
            btnClear.Visible = True
            btnClear.Visible = True
        Catch ex As Exception
            msgbox(ex.Message)
        End Try



        'Dim cmd1 = New SqlCommand("Delete from para_Currencies where CurrencyCode = '" & grdvCurrencies.SelectedRow.Cells(1).Text & "'", cn)
        'If (cn.State = ConnectionState.Open) Then
        '    cn.Close()
        'End If
        'cn.Open()
        'cmd1.ExecuteNonQuery()
        'cn.Close()

        FillGrid()
        '   End If

    End Sub
    Public Function CheckCurrency() As Boolean
        Dim dsid As New DataSet

        CheckCurrency = True
        cmd = New SqlCommand("Select * from para_Currencies where CurrencyCode='" & txtCCode.Text & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid, "para_Currencies")
        If (dsid.Tables(0).Rows.Count > 0) Then
            CheckCurrency = False
        End If
    End Function
    Public Function CheckBase() As Boolean
        Dim dsid As New DataSet

        CheckBase = True
        cmd = New SqlCommand("Select * from para_Currencies where CurrencyStatus='BASE'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsid, "para_Currencies")
        If (dsid.Tables(0).Rows.Count > 0) Then
            CheckBase = False
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


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtCCode.Text = "" Then
            msgbox("Please enter the Currency Code!")
            Exit Sub
        End If
        If txtCName.Text = "" Then
            msgbox("Please enter the Currency Name!")
            Exit Sub
        End If
        If txtCSymbol.Text = "" Then
            msgbox("Please enter the Currency Symbol!")
            Exit Sub
        End If
        If txtIntStd.Text = "" Then
            msgbox("Please enter the International Standard!")
            Exit Sub
        End If
        Try


            If btnSave.Text = "Save Currency" Then
                Dim dsid As New DataSet



                If CheckCurrency() = False Then
                    msgbox("Currency already exists, select a different one")
                    Exit Sub
                End If
                If ddSStatus.Text = "BASE" Then
                    If CheckBase() = False Then
                        msgbox("Base currency already set")
                        Exit Sub
                    End If
                End If
                Dim cmd1 = New SqlCommand("insert into para_Currencies (CurrencyCode,CurrencyName,CurrencySymbol,InternationalSTD,CurrencyStatus) values (@currencycode,@currencyname,@currencysymbol,@internationalstd,'" & ddSStatus.Text & "')", cn)
                cmd1.Parameters.AddWithValue("@currencycode", txtCCode.Text)
                cmd1.Parameters.AddWithValue("@currencyname", txtCName.Text)
                cmd1.Parameters.AddWithValue("@currencysymbol", txtCSymbol.Text)
                cmd1.Parameters.AddWithValue("@internationalstd", txtIntStd.Text)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd1.ExecuteNonQuery()
                cn.Close()


            Else
                Dim cmd1 As SqlCommand
                If ddSStatus.Text = "default" Then
                    cmd1 = New SqlCommand("Update para_Currencies set CurrencyStatus='non default'", cn)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    cmd1.ExecuteNonQuery()
                    cn.Close()
                End If
                cmd1 = New SqlCommand("update para_Currencies set currencycode=@currencycode, currencyname=@currencyname, currencysymbol=@currencysymbol, InternationalSTD=@internationalstd,CurrencyStatus=@currencystatus where CurrencyCode = @selectedcode", cn)
                cmd1.Parameters.AddWithValue("@currencycode", txtCCode.Text)
                cmd1.Parameters.AddWithValue("@currencyname", txtCName.Text)
                cmd1.Parameters.AddWithValue("@currencysymbol", txtCSymbol.Text)
                cmd1.Parameters.AddWithValue("@internationalstd", txtIntStd.Text)
                cmd1.Parameters.AddWithValue("@selectedcode", grdvCurrencies.SelectedRow.Cells(1).Text)
                cmd1.Parameters.AddWithValue("@currencystatus", ddSStatus.Text)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd1.ExecuteNonQuery()
                cn.Close()
            End If

            FillGrid()
            btnSave.Text = "Save Currency"
            txtCCode.Text = ""
            txtCName.Text = ""
            txtCSymbol.Text = ""
            txtIntStd.Text = ""
        Catch ex As Exception
            msgbox("Error on Details Captured")
        End Try

    End Sub




    Public Function availableinparticipants(currency As String) As Boolean

        Dim ds As New DataSet
        cmd = New SqlCommand("select * from para_broker_currency where currency='" + currency + "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Currencies")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function
    Public Function availableinlistings(currency As String) As Boolean

        Dim ds As New DataSet
        cmd = New SqlCommand("select top 1 * from para_company where currency='" + currency + "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "para_Currencies")
        If (ds.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False

        End If
    End Function


    Protected Sub btnSave0_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If availableinlistings(grdvCurrencies.SelectedRow.Cells(1).Text) Then
                msgbox("Currency cannot be deleted! It is already referenced in the system!")
                Exit Sub

            End If
            If availableinparticipants(grdvCurrencies.SelectedRow.Cells(1).Text) Then
                msgbox("Currency cannot be deleted! It is already referenced in the system!")
                Exit Sub

            End If

            Dim cmd1 = New SqlCommand("delete  para_Currencies  where CurrencyCode = '" & grdvCurrencies.SelectedRow.Cells(1).Text & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd1.ExecuteNonQuery()
            cn.Close()

            FillGrid()
            btnSave.Text = "Save Currency"
            txtCCode.Text = ""
            txtCName.Text = ""
            txtCSymbol.Text = ""
            btnDelete.Visible = False

            txtIntStd.Text = ""
            msgbox("Currency Deleted")
        Catch ex As Exception
            msgbox("Please select Currency to delete")
        End Try

    End Sub
    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnSave.Text = "Save Currency"
        txtCCode.Text = ""
        txtCName.Text = ""
        txtCSymbol.Text = ""
        txtIntStd.Text = ""
        'ddSStatus.Text = ""
        btnClear.Visible = False
    End Sub
End Class
