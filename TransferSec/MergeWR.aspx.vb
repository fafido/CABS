Partial Class TransferSec_MergeWR
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim fromEdit As Boolean = False
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
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Merge Transaction commited successfully")
            End If
            Page.MaintainScrollPositionOnPostBack = True
            If (Not IsPostBack) Then
                checkSessionState()


            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Function GetMaxSplit(WRNo As String) As Integer
        'Try
        Dim ds As New DataSet
        Dim maxmainstr As String = Mid(WRNo, 9, 3)
        Dim maxmain As Long = CLng(maxmainstr)
        Dim maxmini As Integer


        cmd = New SqlCommand("select isnull(max(convert(int,[WRChildSuffix])),0) as MaxSplit from [CDS].[dbo].[tblWRSplits] where substring([OriginalWRNo],1,7)= '" & Mid(WRNo, 1, 7) & "'", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "WRSplit")


        If (ds.Tables(0).Rows.Count > 0) Then
            maxmini = ds.Tables(0).Rows(0).Item("MaxSplit")
        Else
            maxmini = 0
        End If



        If maxmini > maxmain Then
            Return maxmini
        ElseIf maxmain > maxmini Then
            Return maxmain
        Else
            Return 0
        End If
        'Catch ex As Exception
        '    Return 0
        '    msgbox(ex.Message)
        'End Try

    End Function
    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Dim dsport As New DataSet
        If rblTranType.SelectedIndex = 0 Then
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and b.Forenames + ' ' + b.Surname like '%" + txtClientName.Text.ToString() + "%' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                grdAvailableWRs.DataSource = dsport
                grdAvailableWRs.DataBind()
            Else
                grdAvailableWRs.DataSource = Nothing
                grdAvailableWRs.DataBind()

            End If
        Else
            cmd = New SqlCommand("SELECT a.ID, ReceiptNo, a.Holder as DepositorAcc, b.Forenames + ' ' + b.Surname as  DepositorName, Commodity, Quantity   FROM [CDS].[dbo].[WR] a   inner join [CDS].[dbo].[Accounts_Clients] b   on a.Holder=b.CDS_Number   where a.Status='ISSUED' and b.Forenames + ' ' + b.Surname like '%" + txtClientName.Text.ToString() + "%' and ReceiptNo in (Select [OrigChildWRNo] From [CDS].[dbo].[tblWRMerges] where State='R') ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsport, "trans")
            If (dsport.Tables(0).Rows.Count > 0) Then
                grdAvailableWRs.DataSource = dsport
                grdAvailableWRs.DataBind()
            Else
                grdAvailableWRs.DataSource = Nothing
                grdAvailableWRs.DataBind()

            End If
        End If
    End Sub


    Public Function GetRejectionRemark(wrno As String) As String
        Dim dsport As New DataSet
        cmd = New SqlCommand("SELECT TOP 1 Remarks   FROM [CDS].[dbo].[tblWRSplits]   where State='R' and [OriginalWRNo] = '" & wrno & "' ", cn)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(dsport, "Splits")
        If (dsport.Tables(0).Rows.Count > 0) Then
            Return dsport.Tables(0).Rows(0).Item("Remarks")
        Else
            Return ""
        End If
    End Function

    Public Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function
    Protected Sub ASPxButton12_Click(sender As Object, e As EventArgs) Handles ASPxButton12.Click
        Dim tempwrno = CreateRandomPassword(10)
        For Each row As GridViewRow In grdAvailableWRs.Rows
            Dim chkMrgd As CheckBox = DirectCast(row.FindControl("chkMerge"), CheckBox)
            If chkMrgd.Checked = True Then
                Dim ReceiptNo As String = row.Cells(0).Text

                cmd = New SqlCommand("Insert into  [CDS].[dbo].[tblWRMerges] ([TransactionRef],[OrigChildWRNo],[NewParentWRNo],[MergeDate],[MergedBy],[State],[AuthDate],[AuthBy],[Participant],[LastWRNo]) Values('" & CreateRandomPassword(10) & "','" & ReceiptNo & "','" & tempwrno & "',GetDate(),'" & Session("Username") & "','C',null,null,'" & Session("BrokerCode") & "',null)", cn)
                If (cn.State = ConnectionState.Open) Then
                    cn.Close()
                End If
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()



            End If
        Next

        Session("finish") = "yes"
        Response.Redirect(Request.RawUrl)

    End Sub


End Class
