Imports System.Collections.Generic

Partial Class BA_derivatives
    Inherits System.Web.UI.Page
    Dim constr As String = (System.Configuration.ConfigurationManager.AppSettings("connpath"))
    Dim cn As New SqlConnection(constr)
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Public datecreated As Date
   
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Public Sub GetLenders()
        Try
            Dim ds As New DataSet
            'cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate <='" & Now.Date & "'", cn)
            cmd = New SqlCommand("select distinct (convert(varchar,id)+' '+cds_number+' '+company) as namess from lendersRegister where expirydate >='" & Now.Date & "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "lendersRegister")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetSectype()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (SecCode) from sec_types", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "sec_types")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getcollateral()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (collateral_name) from para_collateral", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans1")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetCompany()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select distinct (company) from trans", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "trans")
            If (ds.Tables(0).Rows.Count > 0) Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub checkSessionState()
        Try
            GetCompany()
            GetSectype()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Session("finish") = "yes" Then
                Session("finish") = ""
                msgbox("Deposit Successfully Saved!")
            End If
            If Session("finish") = "yes1" Then
                Session("finish") = ""
                msgbox("Deposit Rejected")
            End If
            If (Not IsPostBack) Then
                checkSessionState()
                '  GetLenders()
                getcollateral()
                GetDetails()
           '     getgrades()

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub


    Public Sub GetDetails()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand(" select c.ContractNo as [Contract No.],a.forenames + ' ' + a.surname as Writer,c.Assetname as [Asset Name],c.AssetQuantity as [Quantity],FORMAT(c.ExpiryMaturityDate,'dd-MMM-yyyy') as [Expected Delivery],FORMAT(c.created_on,'dd-MMM-yyyy') as [Date Created],ContractType as [Type]  from cds_router.dbo.deriv_contract c, cds_router.dbo.accounts_clients_web a where c.status='0' and a.CDS_Number=c.writerNo order by c.ID desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView2.DataSource = ds
                ASPxGridView2.DataBind()
            Else
                ASPxGridView2.DataSource = Nothing
                ASPxGridView2.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
        Public Sub getrejected()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select c.ContractNo as [Contract No.],a.forenames + ' ' + a.surname as Writer,c.Assetname as [Asset Name],c.AssetQuantity as [Quantity],FORMAT(c.ExpiryMaturityDate,'dd-MMM-yyyy') as [Expected Delivery],FORMAT(c.created_on,'dd-MMM-yyyy') as [Date Created],ContractType as [Type], Rejection_Reason as [Rej Reason]  from cds_router.dbo.deriv_contract c, cds_router.dbo.accounts_clients_web a where c.status='1' and a.CDS_Number=c.writerNo and c.Rejected='1' order by c.ID desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView2.DataSource = ds
                ASPxGridView2.DataBind()
            Else
                ASPxGridView2.DataSource = Nothing
                ASPxGridView2.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub GetDetails_filter()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand(" select c.ContractNo as [Contract No.],a.forenames + ' ' + a.surname as Writer,c.Assetname as [Asset Name],c.AssetQuantity as [Quantity],FORMAT(c.ExpiryMaturityDate,'dd-MMM-yyyy') as [Expected Delivery],FORMAT(c.created_on,'dd-MMM-yyyy') as [Date Created], ContractType as [Type]  from cds_router.dbo.deriv_contract c, cds_router.dbo.accounts_clients_web a where c.status='0' and a.CDS_Number=c.writerNo  and  c.contractno+''+a.forenames + '' + a.surname+''+c.Assetname like '%"+txtcompany_name.text  +"%' order by c.ID desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                ASPxGridView2.DataSource = ds
                ASPxGridView2.DataBind()
            Else
                ASPxGridView2.DataSource = Nothing
                ASPxGridView2.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
     Public Sub getgrades()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("SELECT grade from para_commodity_grades where commodity='" + txtasset.Text + "'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                cmbgrading.DataSource = ds
                cmbgrading.TextField = "grade"
                cmbgrading.DataBind

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try


    End Sub
    Public Sub getdetailsofderiv()
        Dim keys As List(Of Object) = ASPxGridView2.GetSelectedFieldValues(ASPxGridView2.KeyFieldName)

        txtsecuritycode.Text = keys(0).ToString

        'Try
        Dim ds As New DataSet
            cmd = New SqlCommand(" select c.*, a.surname, a.Forenames, a.surname+' '+ a.Forenames as names, a.mobile  from cds_router.dbo.deriv_contract c, cds_router.dbo.Accounts_Clients_Web a where c.ContractNo='" + txtsecuritycode.Text + "' and a.CDS_Number=c.writerNo order by ID desc", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
                txtasset.Text = ds.Tables(0).Rows(0).Item("AssetName").ToString
                txtcompany_name.Text = ds.Tables(0).Rows(0).Item("WriterSurname").ToString
                txtcontractsize.Text = ds.Tables(0).Rows(0).Item("AssetQuantity").ToString
                'txtexercisestyle.Text = "American"
                txtwritercds.Text = ds.Tables(0).Rows(0).Item("writerno").ToString
                txtwritername.Text = ds.Tables(0).Rows(0).Item("names").ToString
                txtwriterphone.Text = ds.Tables(0).Rows(0).Item("mobile").ToString
                txtstrikeprice.Text = ds.Tables(0).Rows(0).Item("StrikeExercisePrice").ToString
                txttype.Text = ds.Tables(0).Rows(0).Item("ContractType").ToString
                datecreated  =  ds.Tables(0).Rows(0).Item("created_on").ToString
            Else

            End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

 

    Protected Sub ASPxButton5_Click(sender As Object, e As EventArgs) Handles ASPxButton5.Click
        GetDetails_filter()

    End Sub

    'Protected Sub grdEvent0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdEvent0.SelectedIndexChanged
    '    Response.Write("<script language='javascript'> window.open('enquirydetails.aspx?corr=" + grdEvent0.SelectedValue.ToString + "', 'window','HEIGHT=600,WIDTH=870,top=50,left=50,toolbar=no,scrollbars=yes,resizable=no');</script>")
    'End Sub

    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click
        'txtstrikeprice0.Visible = True
         ASPxButton10.Visible= true
        txtrejectreason.Visible=false
        ASPxLabel82.Visible=false
        ASPxButton9.Visible = False

        ' cmd = New SqlCommand("insert into cds_router.dbo.trans (company, cds_number, date_created, trans_time, shares, Update_Type, Created_By, Batch_Ref, source, Pledge_shares, reference, Instrument, [broker], Custodian) values ('"+ cmbgrading.text +"','"+ txtwritercds.text +"', '"+ dtreceived.text +"', getdate(), '"+ txtcontractsize.text +"','Allot','WDR','0','S','0','"+ txtsecuritycode.text  +"','WDR', NULL, NULL)    update cds_router.dbo.deriv_contract set [status]='1', assetquality='"+ cmbgrading.SelectedItem.Text   +"', comments='"+ txtcomment.text +"', assetquantity='"+ txtcontractsize.text +"' where contractNo='"+ txtsecuritycode.text +"'", cn)
        cmd = New SqlCommand(" Insert into WarehourseDeliveries (gRADE, Holder, Commodity, Warehouse, Expiry, Date_Issued, Quantity, InsurancePolicy, Price, Issued_By, receiptNo, financier,HarvestDate, UnitMeasure, InsuranceCompany, InsuranceDetails, InsuranceExpiry, MoistureContent, Broken, Damage, ForeignMatters, WAREHOUSENO, shelfNo, boxNo, compatimentNo, WarehouseOperator, [status], systemtype , Reference, OriginalQuantity )  values ( '" + cmbgrading.Text + "','" + txtwritercds.Text + "','" + txtasset.Text + "',(  SELECT TOP 1 WAREHOUSECODE FROM WAREHOUSECREATION WHERE WAREHOUSEOPERATOR='" + Session("BrokerCode") + "'),'01 Jan 2030',getdate(),'" + txtcontractsize.Text + "','N/A','" + txtstrikeprice.Text + "','" + Session("Username") + "',(select max(id)+1 from wr) , '','01 Jan 2030','Tonnes','N/A','N/A','01 Jan 1900','N/A','N/A','N/A','N/A', '','0','0','0','" + session("BrokerCode") + "', 'DELIVERED', 'NEW', '0','" + txtcontractsize.Text + "')  update cds_router.dbo.deriv_contract set [status]='1', assetquality='" + cmbgrading.SelectedItem.Text + "', comments='" + txtcomment.Text + "', assetquantity='" + txtcontractsize.Text + "' where contractNo='" + txtsecuritycode.Text + "'", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Session("finish") = "yes"
            Response.Redirect(Request.RawUrl)

    End Sub

    Protected Sub btnSaveContract0_Click(sender As Object, e As EventArgs) Handles btnSaveContract0.Click
     
  getdetailsofderiv()
        Page.MaintainScrollPositionOnPostBack = False
        ASPxPopupControl1.PopupHorizontalAlign = DevExpress.Web.ASPxClasses.PopupHorizontalAlign.WindowCenter
        ASPxPopupControl1.PopupVerticalAlign = DevExpress.Web.ASPxClasses.PopupVerticalAlign.WindowCenter

        ASPxPopupControl1.AllowDragging = True
        ASPxPopupControl1.ShowCloseButton = True
        ASPxPopupControl1.ShowOnPageLoad = True
        Page.MaintainScrollPositionOnPostBack = False

          ASPxButton10.Visible=true
        txtrejectreason.Visible=False
        ASPxLabel82.Visible=false
        ASPxButton9.Visible =false
        getgrades()
           

    End Sub


    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click
        ASPxButton10.Visible= False
        txtrejectreason.Visible=True
        ASPxLabel82.Visible= True
        ASPxButton9.Visible = True

    End Sub
    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click
        If txtrejectreason.Text ="" Then
            msgbox("Please enter the rejection reason")
            Exit Sub 
            
        End If



        cmd = New SqlCommand("update cds_router.dbo.deriv_contract set rejected='1', rejection_reason ='"+ txtrejectreason.text   +"', [status]='1' where contractNo='"+ txtsecuritycode.text +"'", cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()


        Dim x As New sendmail 

        x.sendmail(getemail(txtwritercds.text),"Deposit Rejected","Your deposit of "+ txtasset.text +" has been rejected. The reason for rejection is "+ txtrejectreason.text +". You can try to make another deposit using the C-Trade Platform.")



        Session("finish") = "yes1"
        Response.Redirect(Request.RawUrl)

    End Sub
    Protected Sub cmbgrading_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbgrading.SelectedIndexChanged
        txtstrikeprice.Text = getcurrentprice(cmbgrading.text)

    End Sub
    
    Public function getemail(cdsnumber As string) As string
         Dim ds As New DataSet
            cmd = New SqlCommand("select email from cds_router.dbo.accounts_clients_web where cds_number='"+ cdsnumber +"'", cn)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("email")
            Else
            Return ""
            End If
    End function
    Public function getcurrentprice(company As string) As Decimal 
         Dim ds As New DataSet
        cmd = New SqlCommand("select initialprice from testcds_router.dbo.para_company where company='" + company + "'", cn)
        adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts_Clients")
            If (ds.Tables(0).Rows.Count > 0) Then
            Return ds.Tables(0).Rows(0).Item("initialprice")
        Else
            Return 0
            End If
    End function
    Protected Sub ASPxButton4_Click(sender As Object, e As EventArgs) Handles ASPxButton4.Click
        If ASPxButton4.Text= "View Rejected Deposits" Then
             btnSaveContract0.Visible=False
        ASPxButton4.Text = "Back to Deposits"
            getrejected()
            ASPxGridView2.SettingsText.Title = "Rejected Deposits"

            Else
            GetDetails()
              btnSaveContract0.Visible=True
              ASPxButton4.Text = "View Rejected Deposits"
              ASPxGridView2.SettingsText.Title = "Deposits"
        End If
       

    End Sub
    Protected Sub btnSaveContract1_Click(sender As Object, e As EventArgs) Handles btnSaveContract1.Click

    End Sub
End Class
