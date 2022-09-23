Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Partial Class Parameters_Default
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim batchno As Long
    Shared random As New Random()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack = True Then
            GetCurrencies()
            FillGrid()
            LoadBase()
            GetBatch()
        End If
    End Sub
    Public Sub GetCurrencies()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_Currencies", cn)
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
    Public Sub LoadBase()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_Currencies Where CurrencyStatus='BASE'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_Currencies")
            If (ds.Tables(0).Rows.Count > 0) Then
                ddCurrency.Text = ds.Tables(0).Rows(0).Item("CurrencyName").ToString()
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
    Public Sub FillGrid()
        Dim ds As New DataSet

        cmd = New SqlCommand("SELECT * from FinTrans Where BatchNo = " & batchno & "", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "FinTrans")

        If (ds.Tables(0).Rows.Count > 0) Then
            grdvFinBatch.DataSource = ds.Tables(0)
            grdvFinBatch.DataBind()
        Else
            'msgbox("not found")
        End If
    End Sub
    Public Sub GetBatch()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select * from para_LastParam Where ParamName='FinBatch'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_LastParam")
            If (ds.Tables(0).Rows.Count > 0) Then
                batchno = ds.Tables(0).Rows(0).Item("LastUsed")
                batchno = batchno + 1
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub PostFinTrans(TransRef As String, TranDesc As String, ValueDate As Date, DRORCR As String, AccountNo As String, BaseAmount As Double, OGCurrency As String, ConRate As Double, OGAmount As Double, batchno As String)
        Dim dsid As New DataSet
        'Dim currentuser As String
        Dim posttime As Date

        'currentuser = Session("username")
        posttime = Now

        Dim cmd1 = New SqlCommand("Insert into FinTrans(TransRef, TranDesc,ValueDate,DRORCR,AccountNo,BaseAmount,OGCurrency,ConRate,OGAmount) values ('" & TransRef & "','" & TranDesc & "','" & ValueDate & "','" & DRORCR & "','" & AccountNo & "'," & BaseAmount & ",'" & OGCurrency & "','" & ConRate & "'," & OGAmount & "," & batchno & ")", cn)
        If (cn.State = ConnectionState.Open) Then
            cn.Close()
        End If
        cn.Open()
        cmd1.ExecuteNonQuery()
        cn.Close()


        ''do authoriser routine separately
    End Sub

    Public Sub AuthFinTrans(TransID As Integer, TransRef As String, Accepted As Boolean)
        Dim dsid As New DataSet
        'Dim currentuser As String
        Dim posttime As Date

        'currentuser = Session("username")
        posttime = Now

        If Accepted = True Then
            Dim cmd1 = New SqlCommand("Update FinTrans Set Authorised,Authoriser,AuthDateTime Where TransID'" & TransID & "' and TransRef ='" & TransRef & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd1.ExecuteNonQuery()
            cn.Close()
        Else
            Dim cmd1 = New SqlCommand("Insert into FinTransRejected values(Select * From  FinTrans Where TransID'" & TransID & "' and TransRef ='" & TransRef & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd1.ExecuteNonQuery()
            cn.Close()

            Dim cmd2 = New SqlCommand("Delete from FinTrans  Where TransID'" & TransID & "' and TransRef ='" & TransRef & "'", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd2.ExecuteNonQuery()
            cn.Close()

        End If

        ''do authoriser routine separately
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        PostFinTrans(txtTransRef.Text, txtTranDesc.Text, txtdate.Text, "DR", txtDebitAcc.Text, txtBaseAmount.Text, ddCurrency.DataTextField, txtConRate.Text, txtAmount.Text, batchno)
        PostFinTrans(txtTransRef.Text, txtTranDesc.Text, txtdate.Text, "CR", txtCreditAcc.Text, txtBaseAmount.Text, ddCurrency.DataTextField, txtConRate.Text, txtAmount.Text, batchno)
        FillGrid()
    End Sub

  
End Class
