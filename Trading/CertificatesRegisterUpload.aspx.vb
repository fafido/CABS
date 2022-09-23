Imports System.Data
Imports System.Data.SqlClient
Partial Class Trading_CertificatesRegisterUpload
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim conn As New SqlConnection(constr)
    Dim comm As SqlCommand
    Dim adp As SqlDataAdapter
    Dim maxbatchref As Integer
    Dim wk_rec As String, sw_first As Boolean, fs, f
    Dim wk_tot_cnt As Integer, wk_err As Integer, wk_date As Date, wk_sys_cds As Double, wk_cds_ac As Long
    Dim wk_head_shares As Double, wk_head_cnt As Integer, wk_tot_shares As Double
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
            getCompany()
        End If
    End Sub
    Public Sub getmaxBatchref()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select max(batch_ref) as batch_ref from broker_batch_header", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_header")
            maxbatchref = ((ds.Tables(0).Rows(0).Item("batch_ref").ToString) + 1)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select company from para_company", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_company")
            cmbParaCompany.DataSource = ds.Tables(0)
            cmbParaCompany.DataValueField = "company"
            cmbParaCompany.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub LoadUploadvalue()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("insert into UploadKeyReg (id,date,company) values ('" & Session("BrokerCode") & "','" & Date.Now & "', '" & cmbParaCompany.Text & "')", cn)
            If (cn.State = ConnectionState.Open) Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BatchSumValidation()
        Try
            Dim totBatch As Integer = 0
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from broker_batch_ref where batch_ref=" & lblbatchref.Text & "", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "broker_batch_ref")
            If (ds.Tables(0).Rows.Count > 0) Then
                Dim res As New DataSet
                cmd = New SqlCommand("Select sum(shares) as shares from broker_batch_ref where batch_ref=" & lblbatchref.Text & "", cn)
                adp = New SqlDataAdapter(cmd)
                adp.Fill(res, "broker_batch_ref")

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            LoadUploadvalue()
            Dim ds As New DataSet
            cmd = New SqlCommand("select max(UploadKey) as UploadKey from UploadKeyReg where id ='" & Session("Brokercode") & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "UploadKeyReg")

            If (ds.Tables(0).Rows.Count > 0) Then
                lblUploadId.Text = ds.Tables(0).Rows(0).Item("UploadKey").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Sub ImportFile()
        Try


            Dim ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds15, ds16, ds17, ds18, ds19 As New DataSet
            Dim i, j, k, l, m, o, p, q As Integer

            fDocument.PostedFile.SaveAs(Server.MapPath("CertificatesUpload\" & fDocument.Value))
            TextBox1.Text = Server.MapPath("CertificatesUpload\" & fDocument.Value)
            If Not IO.File.Exists(TextBox1.Text) Then
                msgbox("No File Found")
                lblbatchref.Visible = True
                lblbatchref.Text = "Error..No File"
                Exit Sub
            End If

            If Not IsDate(BasicDatePicker1.Text) Then
                msgbox("Please enter valid date")
                Exit Sub
            End If

            Dim filname, ext As String
            ext = IO.Path.GetExtension(TextBox1.Text)

            filname = IO.Path.GetFileName(TextBox1.Text)

            If filname.Remove(filname.IndexOf(".")) <> cmbParaCompany.Text And filname.Remove(filname.IndexOf(".")).ToUpper <> cmbParaCompany.Text And filname.Remove(filname.IndexOf(".")).ToLower <> cmbParaCompany.Text Then
                msgbox("SELECT CORRECT COMPANY")
                Exit Sub
            End If

            
            wk_path.Text = "CertificatesUpload\" & IO.Path.GetFileName(TextBox1.Text)

            'Dim SqlErr As String
            lblbatchref.Visible = True
            lblbatchref.Text = "Processing..."
            'wk_tot_shares = 0
            'wk_tot_cnt = 0
            'sw_first = True
            If String.IsNullOrEmpty(Me.cmbParaCompany.Text) Or String.IsNullOrEmpty(Me.wk_path.Text) Then
                msgbox("PLEASE FILL IN ALL DETAILS")
                Exit Sub
            End If

            fs = CreateObject("scripting.filesystemobject")
            If Not fs.FileExists(Server.MapPath(wk_path.Text)) Then
                msgbox("FILE NOT FOUND")
                Exit Sub
            End If
            comm = New SqlCommand

            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString = constr
                conn.Open()
            End If
            
            fs = CreateObject("Scripting.FileSystemObject")
            f = fs.OpenTextFile(TextBox1.Text, 1)

            wk_rec = f.readline

            Do Until Mid(wk_rec, wk_rec.Length) = "2"
                If sw_first Then
                    sw_first = False
                    If Mid(wk_rec, wk_rec.Length) <> "0" Then
                        msgbox("TEXT FILE FORMAT ERROR #0")
                        Exit Sub
                    End If
                End If

                If Mid(wk_rec, wk_rec.Length) = "0" Then
                    GoTo proc_header
                Else
                    GoTo proc_record
                End If
looping:
                wk_rec = f.readline
                'msgbox("a" & Mid(wk_rec, wk_rec.Length) & "b")
            Loop
            f.Close()

            GoTo validate
            If wk_err = 1 Then
                Exit Sub
            End If
aftervalidate:
afterproc_mast_etc:
            'If wk_update.Checked = True Then
            'GoTo Proc_Update
            'afterproc_update:
            'End If

            If wk_err = 0 Then
                Me.lblbatchref.Text = "Completed"
            Else
                Me.lblbatchref.Text = "Completed with ERRORS"
            End If

            Exit Sub
            '--------------------------------- WRITE HEADER -------
proc_header:
            wk_head_shares = CDbl(Mid(wk_rec, 68, 16))
            wk_head_cnt = CInt(Mid(wk_rec, 84, 10))


            Dim company = Me.cmbParaCompany.Text

            Dim HDate As Date = CDate(Mid(wk_rec, 3, 2) & "/" & Mid(wk_rec, 1, 2) & "/" & Mid(wk_rec, 5, 4))
            wk_date = HDate
            Dim Hdesc = Trim(Mid(wk_rec, 9, 50))
            'Dim Hdesc = ""
            Dim HSec = Trim(Mid(wk_rec, 13, 8))
            Dim HTot_Shares = CDbl(Mid(wk_rec, 68, 12))
            Dim HTot_Cnt = CDbl(Mid(wk_rec, 84, 10))
            Dim status = "E"
            comm = New SqlCommand
            comm.Connection = conn
            comm.CommandText = "insert into cds_header values('" & company & "','" & HDate & "','" & Hdesc & "','" _
            & HSec & "'," & HTot_Shares & "," & HTot_Cnt & ",'" & status & "')"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            wk_date = BasicDatePicker1.Text

            GoTo looping
            '---------------------------------  WRITE DETAILS -----------
proc_record:

            Dim company1 = Me.cmbParaCompany.Text
            Dim upload = Me.BasicDatePicker1.Text
            Dim shareholder = Mid(wk_rec, 1, 13)
            Dim idkey = Mid(wk_rec, 1, 22)
            Dim industry = Trim(Mid(wk_rec, 14, 2))
            Dim BrokerType = Mid(wk_rec, 22, 1)
            Dim title As String = Trim(Mid(wk_rec, 23, 10))
            Dim surname As String = Trim(Mid(wk_rec, 213, 50))
            Dim forenames As String = Trim(Mid(wk_rec, 53, 160))
            Dim add_1 As String = Trim(Mid(wk_rec, 263, 30))
            Dim add_2 As String = Trim(Mid(wk_rec, 293, 30))
            Dim add_3 As String = Trim(Mid(wk_rec, 323, 30))
            Dim add_4 As String = Trim(Mid(wk_rec, 353, 20)) & " " & Trim(Mid(wk_rec, 373, 15))
            If surname.Contains("'") Then
                surname = surname.Replace("'", "''")
            End If
            If forenames.Contains("'") Then
                forenames = forenames.Replace("'", "''")
            End If
            If title.Contains("'") Then
                title = title.Replace("'", "''")
            End If
            If add_1.Contains("'") Then
                add_1 = add_1.Replace("'", "''")

            End If
            If add_2.Contains("'") Then
                add_2 = add_2.Replace("'", "''")
            End If
            If add_3.Contains("'") Then
                add_3 = add_3.Replace("'", "''")
            End If
            If add_4.Contains("'") Then
                add_4 = add_4.Replace("'", "''")
            End If
            If add_2 = "" Then
                add_2 = add_4
                add_3 = ""
                add_4 = ""
            ElseIf add_3 = "" Then
                add_3 = add_4
                add_4 = ""
            End If
            If add_2 = "" Then
                add_2 = ""
            End If
            If add_3 = "" Then
                add_3 = ""
            End If
            If add_4 = "" Then
                add_4 = ""
            End If
            Dim country = Trim(Mid(wk_rec, 388, 2))
            Dim bank = Trim(Mid(wk_rec, 390, 10))
            If bank = "" Then
                bank = ""
            End If
            Dim branch = Trim(Mid(wk_rec, 400, 15))
            If branch = "" Then
                branch = ""
            End If
            Dim account = Trim(Mid(wk_rec, 415, 20))
            If account = "" Then
                account = ""
            End If
            Dim taxcode = Trim(Mid(wk_rec, 435, 6))
            Dim shares
            Try


                shares = CDbl(Mid(wk_rec, 441, 14))
            Catch ex As Exception
                shares = 0.0
            End Try
            Dim SharesPlus = 0
            comm = New SqlCommand
            comm.Connection = conn
            comm.CommandText = "insert into cds_dets values('" & company1 & "','" & idkey & "','" & shareholder & "','" & industry & "','" _
            & BrokerType & "','" & surname & "','" & forenames & "','" & title & "','" & add_1 & "','" & add_2 & "','" & add_3 & "','" _
            & add_4 & "','" & country & "','" & bank & "','" & branch & "','" & account & "','" & taxcode & "'," & shares & "," & SharesPlus & ",'" & upload & "')"
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            GoTo looping
            '-------------------------------------- VALIDATION ----------
validate:
            wk_err = 0
            Dim ds As New DataSet
            Dim da As SqlDataAdapter
            comm = New SqlCommand
            comm.Connection = conn
            comm.CommandText = "select sum(shares) from CDS_DETS where company='" & cmbParaCompany.Text & "'"
            da = New SqlDataAdapter(comm)
            da.Fill(ds, "CDS_DETS")
            If ds.Tables(0).Rows.Count <> 0 Then
                wk_tot_shares = CDbl(ds.Tables(0).Rows(0).Item(0))
            Else
                wk_tot_shares = 0
            End If
            ds.Clear()

            comm = New SqlCommand
            comm.Connection = conn
            comm.CommandText = "select count(*) from CDS_DETS where company='" & cmbParaCompany.Text & "'"
            da = New SqlDataAdapter(comm)
            da.Fill(ds, "CDS_DETS")
            If ds.Tables("CDS_DETS").Rows.Count <> 0 Then
                wk_tot_cnt = CDbl(ds.Tables("CDS_DETS").Rows(0).Item(0))
            End If


            If wk_head_shares <> wk_tot_shares Then
                wk_err = 1
                msgbox("SHARES OUT OF BALANCE" & Chr(13) & "HEADER = " & wk_head_shares & Chr(13) & "FILE = " & wk_tot_shares)
            End If

            If wk_head_cnt <> wk_tot_cnt Then
                wk_err = 1
                msgbox("RECORD COUNT OUT OF BALANCE" & Chr(13) & "HEADER = " & wk_head_cnt & Chr(13) & "FILE = " & wk_tot_cnt)
            End If
            If wk_sys_cds <> wk_head_shares Then
                msgbox("CDS INPUT OUT OF BALANCE WITH SYSTEM CDS ACCOUNT (" & wk_cds_ac & ")" & "\n" _
                     & "INCOMING CDS BALANCE   " & wk_head_shares & "\n" _
                     & "SYSTEM ACCOUNT BALANCE " & wk_sys_cds _
                     & "DIFFERENCE             " & wk_head_shares - wk_sys_cds)
                wk_err = 1
            End If
            '------------ Check Country,industry etc.
            'dets = dbs.OpenRecordset("CDS_Dets", dbOpenSnapshot)
            comm = New SqlCommand
            comm.Connection = conn
            comm.CommandText = "select * from CDS_DETS where company='" & cmbParaCompany.Text & "'"
            da = New SqlDataAdapter(comm)
            da.Fill(ds2, "CDS_DETS")
            If ds2.Tables("CDS_DETS").Rows.Count <> 0 Then
                For i = 0 To ds2.Tables(0).Rows.Count - 1
                    comm.CommandText = "select code from para_industry where code='" & ds2.Tables(0).Rows(i).Item("industry").ToString & "'"
                    da = New SqlDataAdapter(comm)
                    da.Fill(ds3, "CDS_DETS")
                    If ds3.Tables(0).Rows.Count <= 0 Then
                        wk_err = 1
                        msgbox("UNKNOWN INDUSTRY CODE " & ds2.Tables(0).Rows(i).Item("industry").ToString)
                    End If
                    comm.CommandText = "select country from para_country where country='" & ds2.Tables(0).Rows(i).Item("country").ToString & "'"
                    da = New SqlDataAdapter(comm)
                    da.Fill(ds16, "CDS_DETS")
                    If ds16.Tables(0).Rows.Count <= 0 Then
                        wk_err = 1
                        msgbox("UNKNOWN COUNTRY CODE " & ds2.Tables(0).Rows(i).Item("country").ToString)
                    End If
                    comm.CommandText = "select code from para_tax where code='" & ds2.Tables(0).Rows(i).Item("taxcode").ToString & "'"
                    da = New SqlDataAdapter(comm)
                    da.Fill(ds17, "CDS_DETS")
                    If ds17.Tables(0).Rows.Count <= 0 Then
                        wk_err = 1
                        msgbox("UNKNOWN TAX CODE " & ds2.Tables(0).Rows(i).Item("taxcode").ToString)
                    End If
                Next
            End If

            
            If wk_err = 0 Then
                comm.CommandText = "update CDS_Header set status = 'B'"
                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If
                comm.ExecuteNonQuery()
                conn.Close()
                'dbs.Execute("update CDS_Header set status = 'B'")
            Else
                comm.CommandText = "update CDS_Header set status = 'E'"
                conn.Open()
                comm.ExecuteNonQuery()
                conn.Close()
                'dbs.Execute("update CDS_Header set status = 'E'")
            End If
            GoTo aftervalidate
            '-----------------------------------------------
            
        Catch ex As Exception
            msgbox(ex.Message)

        End Try
    End Sub
End Class
