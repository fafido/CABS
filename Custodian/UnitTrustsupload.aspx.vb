Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Orders
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet
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
            'getcompanies()
            Getorders()

        End If
        If Session("finish") = "yes" Then
            Session("finish") = ""
            msgbox("Sent for Approval")
        End If
    End Sub


    'Public Sub getcompanies()
    '    Dim ds As New DataSet
    '    cmd = New SqlCommand("select * from para_company", cn)
    '    adp = New SqlDataAdapter(cmd)
    '    adp.Fill(ds, "para_lendingRules")
    '    If (ds.Tables(0).Rows.Count > 0) Then
    '        ASPxComboBox1.DataSource = ds
    '        ASPxComboBox1.TextField = "fnam"
    '        ASPxComboBox1.ValueField = "company"
    '        ASPxComboBox1.DataBind()
    '    End If
    'End Sub

    Public Sub Getorders()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select id,shareholder,clientname,quantity as value,sharequantity as shares ,date,brokerref,company ,response,ordertype  from [testcds_ROUTER].[dbo].[Unit_Trust] where status='pending' ", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "para_lendingRules")
            If (ds.Tables(0).Rows.Count > 0) Then
                grdRules.DataSource = ds.Tables(0)
                grdRules.DataBind()
            Else
                grdRules.DataSource = Nothing
                grdRules.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub















    Protected Sub btnupload_Click(sender As Object, e As EventArgs)
        'Dim lines As String()

        'Dim query As String

        'Dim i As Integer = 0
        'Dim sr As StreamReader = New StreamReader("C:\DEV\omt.txt")
        'Dim b = sr.ReadToEnd.Length


        'Dim line As String = sr.ReadLine()
        'cn.Close()
        'cn.Open()


        'While i <= b
        '    Dim fields() As String = line.Split(",")

        '    cmd = New SqlCommand("INSERT INTO [testcds_ROUTER].[dbo].[Unit_Trusts](shareholder, clientname,quantity, date,brokerref,company)VALUES('" & fields(0) & "','" & fields(1) & "', '" & fields(2) & "', '" & fields(3) & "','" & fields(4) & "','" & fields(5) & "' )", cn)

        '    cmd.ExecuteNonQuery()

        '    line = sr.ReadLine()
        '    i = i + 1
        'End While


        'msgbox("upload successful")
        'cn.Close()
        Dim lines As String()
        Dim query As String
        If fileupload1.HasFile Then
            Dim connectionString As String = ""
            Dim fileName2 As String = Path.GetFileName(fileupload1.PostedFile.FileName)
            'Dim filepath = System.IO.Path.GetDirectoryName(fileName2)
            ' msgbox(filepath)
            ' Exit Sub
            Dim fileLocation As String = Server.MapPath("~/uploads/uploads_" & Date.Now.ToString("ddMMyyyymmsss") & fileName2)
            fileupload1.SaveAs(fileLocation)

            Using dbConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(constr)
                Using dbCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
                    dbCmd.Connection = dbConn
                    dbCmd.Connection.Close()
                    dbCmd.Connection.Open()


                    lines = File.ReadAllLines(fileLocation)


                    For Each line As String In lines
                        Dim values As String() = line.Split(",")
                        'msgbox(values(0))
                        'Exit Sub
                        If (line = "") Then
                        Else
                            query = "INSERT INTO [testcds_ROUTER].[dbo].[Unit_Trust](shareholder, clientname,quantity, date,brokerref,company,sharequantity,response,uploaddate,ordertype,status)  values ('" + values(0) + "','" + values(1) + "','" + values(2) + "','" + values(3) + "','" + values(4) + "','" + values(5) + "','" + values(6) + "','" + values(7) + "','" + uploaddate.Text + "','" + ASPxComboBox2.SelectedItem.Text + "','pending')"

                            dbCmd.CommandText = query
                            'dbCmd.Connection.Open()
                            dbCmd.ExecuteNonQuery()

                        End If
                    Next
                End Using
            End Using
        End If
        msgbox("upload successful")
        Getorders()

    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs)



        Dim count = grdRules.Rows.Count
        For Each row In grdRules.Rows

            Dim id = row.cells(0).text.ToString
            Dim cdsnumber = row.cells(1).text.ToString
            Dim value = row.cells(3).text.ToString
            Dim shares = row.cells(4).text.ToString
            Dim tradedate = row.cells(5).text.ToString
            Dim company = row.cells(7).text.ToString
            Dim status = row.cells(9).text.ToString
            ' Dim shares = "90"
            If status = "Sell" Then
                inserttransaction(cdsnumber, value, tradedate, company, status)
            End If
            insertshares(cdsnumber, value, tradedate, company, status, shares)
            updatedata(id)

        Next row

        msgbox("Orders Successfully Processed")
        Getorders()



    End Sub
    Public Function inserttransaction(ByVal cdsnumber As String, ByVal quantity As String, ByVal tradedate As String, ByVal company As String, ByVal status As String)






        cmd = New SqlCommand(" insert into  [CDSC].[dbo].[CashTrans] (description,transtype,amount,DateCreated,CDS_Number) values('trade','Sell','" + quantity + "','" + tradedate + "','" + cdsnumber + "')", cn)


        If (cn.State = ConnectionState.Open) Then
            cn.Close()

        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()




        Return 0
    End Function
    Public Function insertshares(ByVal cdsnumber As String, ByVal quantity As String, ByVal tradedate As String, ByVal company As String, ByVal status As String, ByVal shares As String)





        If status = "Buy" Then

            cmd = New SqlCommand(" insert into [CDS_ROUTER].[dbo].[trans](company,CDS_Number,Date_Created,Trans_Time,shares,Update_Type,Created_By) values('" + company + "','" + cdsnumber + "','" + tradedate + "','" + tradedate + "','" + shares + "', 'crediting','escrow') ", cn)
        ElseIf status = "Sell"
            Dim sharevalue = Convert.ToInt16(shares) * -1
            cmd = New SqlCommand(" insert into [CDS_ROUTER].[dbo].[trans](company,CDS_Number,Date_Created,Trans_Time,shares,Update_Type,Created_By) values('" + company + "','" + cdsnumber + "','" + tradedate + "','" + tradedate + "','" + shares + "', 'crediting','escrow') ", cn)
        End If



        If (cn.State = ConnectionState.Open) Then
            cn.Close()

        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()




        Return 0
    End Function
    Public Function updatedata(ByVal id As String)



        cmd = New SqlCommand("update [testcds_ROUTER].[dbo].[Unit_Trust]  set status='completed' where id='" + id + "'", cn)

        If (cn.State = ConnectionState.Open) Then
            cn.Close()

        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()



        Return 0
    End Function



End Class
