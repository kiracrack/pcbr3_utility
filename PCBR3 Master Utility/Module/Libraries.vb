Imports MySql.Data.MySqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils
Imports System.IO
Imports System.Drawing.Imaging
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data

Module Libraries
    Public bmpScreenShot As Bitmap
    Public gfxScreenshot As Graphics

    Public Function CloseOpenForm(ByVal form As DevExpress.XtraEditors.XtraForm)
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot PCBR3Main And My.Application.OpenForms.Item(i) IsNot frmLogin And My.Application.OpenForms.Item(i) IsNot form Then
                My.Application.OpenForms.Item(i).Close()
            End If
        Next i
        Return 0
    End Function
    Public Function LoadToComboBox(ByVal fld As String, ByVal tbl As String, ByVal combo As DevExpress.XtraEditors.ComboBoxEdit, ByVal mode As Boolean)
        Dim Coll As ComboBoxItemCollection = combo.Properties.Items
        If mode = True Then
            Coll.Clear()
            com.CommandText = "Select distinct(" & fld & ") from " & tbl & " order by " & fld & " DESC"
            rst = com.ExecuteReader
            Coll.BeginUpdate()
            Try
                While rst.Read
                    Coll.Add(rst(fld))
                End While
                rst.Close()
            Finally
                Coll.EndUpdate()
            End Try
        End If
        Return Coll
    End Function
    Public Function LoadXgrid(ByVal qry As String, ByVal tbl As String, ByVal Em As DevExpress.XtraGrid.GridControl, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim dst = New DataSet : dst.Clear()
            xgrid.ClearGrouping()
            Em.DataSource = Nothing
            msda = New MySqlDataAdapter(qry, conn)
            msda.SelectCommand.CommandTimeout = 6000000
            msda.Fill(dst, tbl)
            Em.DataSource = dst.Tables(tbl)
            xgrid.PopulateColumns(dst.Tables(tbl))
            Em.ForceInitialize()
            xgrid.BestFitColumns()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        Return 0
    End Function
    Public Function LoadXgridLookupEdit(ByVal qry As String, ByVal tbl As String, ByVal Xglue As DevExpress.XtraEditors.GridLookUpEdit, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim dst As New DataSet : dst.Clear()
            msda = New MySql.Data.MySqlClient.MySqlDataAdapter(qry, conn)
            msda.Fill(dst, tbl)
            Xglue.Properties.DataSource = dst.Tables(tbl)
            xgrid.PopulateColumns(dst.Tables(tbl))
            Xglue.Properties.View.BestFitColumns()
            Xglue.ForceInitialize()
            xgrid.BestFitColumns()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function GridColumnAlignment(ByVal grdView As DataGridView, ByVal column As Array, ByVal alignment As DataGridViewContentAlignment) As DataGridView
        '   Dim array() As String = {a}
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    grdView.Columns(i).DefaultCellStyle.Alignment = alignment
                    grdView.Columns(i).HeaderCell.Style.Alignment = alignment
                End If
            Next
        Next
        Return grdView
    End Function
    Public Function LoadXgridLookupSearch(ByVal qry As String, ByVal tbl As String, ByVal Xglue As DevExpress.XtraEditors.SearchLookUpEdit, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim dst As New DataSet : dst.Clear()
            msda = New MySql.Data.MySqlClient.MySqlDataAdapter(qry, conn)
            msda.Fill(dst, tbl)
            Xglue.Properties.DataSource = dst.Tables(tbl)
            xgrid.PopulateColumns(dst.Tables(tbl))
            Xglue.Properties.View.BestFitColumns()
            Xglue.ForceInitialize()
            xgrid.BestFitColumns()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function LoadXgridLookupSearchServer(ByVal qry As String, ByVal tbl As String, ByVal Xglue As DevExpress.XtraEditors.SearchLookUpEdit, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim dstclient As New DataSet : dstclient.Clear()
            msdaclient = New MySql.Data.MySqlClient.MySqlDataAdapter(qry, connclient)
            msdaclient.Fill(dstclient, tbl)
            Xglue.Properties.DataSource = dstclient.Tables(tbl)
            xgrid.PopulateColumns(dstclient.Tables(tbl))
            Xglue.Properties.View.BestFitColumns()
            Xglue.ForceInitialize()
            xgrid.BestFitColumns()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function XgridColCurrency(ByVal i As String, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            xgrid.Columns(i).DisplayFormat.FormatType = FormatType.Numeric
            xgrid.Columns(i).DisplayFormat.FormatString = "n"
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function XgridColNumber(ByVal i As String, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            xgrid.Columns(i).DisplayFormat.FormatType = FormatType.Numeric
            xgrid.Columns(i).DisplayFormat.FormatString = "N0"
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function XgridColAlign(ByVal i As String, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal algn As DevExpress.Utils.HorzAlignment)
        Try
            xgrid.Columns(i).AppearanceCell.TextOptions.HAlignment = algn
            xgrid.Columns(i).AppearanceHeader.TextOptions.HAlignment = algn
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function XgridColWidth(ByVal i As String, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal size As Integer)
        Try
            xgrid.Columns(i).Width = size
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Sub RemoveSpecialChar(ByVal panel As DevExpress.XtraEditors.PanelControl)
        Dim Ctl As Control
        Try
            For Each Ctl In panel.Controls
                If TypeOf Ctl Is DevExpress.XtraEditors.TextEdit Or TypeOf Ctl Is DevExpress.XtraEditors.ComboBoxEdit Or TypeOf Ctl Is DevExpress.XtraEditors.MemoEdit Then
                    Ctl.Text = Ctl.Text.Replace("'", "''")
                    Ctl.Text = Ctl.Text.Replace("\", "\\")
                End If
            Next Ctl
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
    End Sub
    Public Function CheckSelectedRow(ByVal col As String, ByVal Xgrid As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Try
            If Xgrid.GetFocusedRowCellValue(col) = "" Then
                XtraMessageBox.Show("There is no item selected! make sure, the selection is on the list", compname, MessageBoxButtons.OK, MessageBoxIcon.Error)
                CheckSelectedRow = False
            Else
                CheckSelectedRow = True
            End If
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
    End Function
    Public Function DeleteRow(ByVal col As String, ByVal fld As String, ByVal tbl As String, ByVal Xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim Row As DataRow : Dim Rows() As DataRow : Dim I As Integer : Dim todelete As String = ""
            ReDim Rows(Xgrid.SelectedRowsCount - 1)
            For I = 0 To Xgrid.SelectedRowsCount - 1
                Rows(I) = Xgrid.GetDataRow(Xgrid.GetSelectedRows(I))
                todelete = Xgrid.GetRowCellValue(Xgrid.GetSelectedRows(I), col)
                com.CommandText = "DELETE from " & tbl & " where " & fld & "='" & todelete & "'"
                rst = com.ExecuteReader() : rst.Close()
            Next
            For Each Row In Rows
                Row.Delete()
            Next
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function ResizeImage(ByVal img As DevExpress.XtraEditors.PictureEdit, ByVal imgsize As Integer, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            If Not img.Image Is Nothing Then
                Dim Original As New Bitmap(img.Image)
                img.Image = Original
                If imgsize < Original.Width Then
                    Dim m As Int32 = imgsize
                    Dim n As Int32 = m * Original.Height / Original.Width

                    Dim Thumb As New Bitmap(m, n, Original.PixelFormat)
                    Thumb.SetResolution(Original.HorizontalResolution, Original.VerticalResolution)

                    Dim g As Graphics = Graphics.FromImage(Thumb)
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High

                    g.DrawImage(Original, New Rectangle(0, 0, m, n))
                    img.Image = Thumb
                End If
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function

    Public Function UpdateImage(ByVal qry As String, ByVal fld As String, ByVal tbl As String, ByVal Ximg As DevExpress.XtraEditors.PictureEdit, ByVal myform As DevExpress.XtraEditors.XtraForm)
        arrImage = Nothing
        Try
            If Not Ximg.Image Is Nothing Then
                Dim mstream As New System.IO.MemoryStream()
                Ximg.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                arrImage = mstream.GetBuffer()
                mstream.Close()
            End If

            sql = "Update " & tbl & " set " & fld & " = @file where " & qry

            With sqlcmd
                .CommandText = sql
                .Connection = conn
                .Parameters.AddWithValue("@file", arrImage)
                .ExecuteNonQuery()
            End With
            sqlcmd.Parameters.Clear()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function UpdateIcon(ByVal qry As String, ByVal fld As String, ByVal tbl As String, ByVal Ximg As DevExpress.XtraEditors.PictureEdit, ByVal myform As DevExpress.XtraEditors.XtraForm)
        arrImage = Nothing
        Try
            If Not Ximg.Image Is Nothing Then
                Dim mstream As New System.IO.MemoryStream()
                Ximg.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Icon)
                arrImage = mstream.GetBuffer()
                mstream.Close()
            End If

            sql = "Update " & tbl & " set " & fld & " = @file where " & qry

            With sqlcmd
                .CommandText = sql
                .Connection = conn
                .Parameters.AddWithValue("@file", arrImage)
                .ExecuteNonQuery()
            End With
            sqlcmd.Parameters.Clear()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Function ShowImage(ByVal fld As String, ByVal Ximg As DevExpress.XtraEditors.PictureEdit, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            If rst(fld).ToString <> "" Then
                imgBytes = CType(rst(fld), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)
                Ximg.Image = img
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function

    Public Function UpdateReportTitle(ByVal Title As String, ByVal customText As String, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            If countqry("tblreportsetting", "formname='" & myform.Name.ToString & "'") = 0 Then
                com.CommandText = "insert into tblreportsetting set title='" & Title & "', customtext='" & customText & "' where formname='" & myform.Name.ToString & "' " : com.ExecuteNonQuery()
            Else
                com.CommandText = "update tblreportsetting set title='" & Title & "', customtext='" & customText & "' where formname='" & myform.Name.ToString & "' " : com.ExecuteNonQuery()
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return 0
    End Function
    Public Sub AddRowXgrid(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim currentRow As Integer
        Try
            currentRow = View.FocusedRowHandle
            If currentRow < 0 Then
                currentRow = View.GetDataRowHandleByGroupRowHandle(currentRow)
            End If
            View.AddNewRow()
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
    End Sub
    Public Function qrysingledata(ByVal field As String, ByVal fqry As String, ByVal qry As String, ByVal tbl As String)
        Dim def As String = ""
        Try
            If countrecord(tbl) = 0 Then
                def = ""
            Else
                com.CommandText = "select " & fqry & " from " & tbl & " " & qry : rst = com.ExecuteReader
                While rst.Read
                    def = rst(field).ToString
                End While
                rst.Close()
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()

        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return def
    End Function
    Public Function qrysingledataServer(ByVal field As String, ByVal fqry As String, ByVal qry As String, ByVal tbl As String)
        Dim def As String = ""
        Try
            If countrecordserver(tbl) = 0 Then
                def = ""
            Else
                comclient.CommandText = "select " & fqry & " from " & tbl & " " & qry : rstclient = comclient.ExecuteReader
                While rstclient.Read
                    def = rstclient(field).ToString
                End While
                rstclient.Close()
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PrintError()
        End Try
        Return def
    End Function

    Public Sub ViewGridtype(ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        If globalprintjettype = True Then
            xgrid.PaintStyleName = "Web"
            xgrid.Appearance.FooterPanel.BackColor = Color.White
            xgrid.Appearance.FooterPanel.BackColor2 = Color.White

            xgrid.Appearance.GroupFooter.BackColor = Color.White
            xgrid.Appearance.GroupFooter.BackColor2 = Color.White

            xgrid.Appearance.FooterPanel.BorderColor = Color.LightGray
            xgrid.BestFitColumns()
            'xgrid.Appearance.GroupPanel.BorderColor = Color.LightGray
        Else
            xgrid.PaintStyleName = "Default"
            xgrid.BestFitColumns()
        End If
    End Sub
    Public Sub PrintError()
        bmpScreenShot = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb)
        gfxScreenshot = Graphics.FromImage(bmpScreenShot)
        gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)
        bmpScreenShot.Save(Application.StartupPath & "\Errors\" & createTRNID("ERR") & ".png", ImageFormat.Png)
    End Sub

    Public Function ConvertCurrencyToEnglish(ByVal MyNumber As Double) As String
        Dim Temp As String
        Dim Dollars, Cents As String
        Dim DecimalPlace, Count As Integer
        Dim Place(9) As String
        Dim Numb As String
        Place(2) = " Thousand " : Place(3) = " Million " : Place(4) = "Billion " : Place(5) = " Trillion "
        ' Convert Numb to a string, trimming extra spaces.
        Numb = Trim(Str(MyNumber))
        ' Find decimal place.
        DecimalPlace = InStr(Numb, ".")
        ' If we find decimal place...
        If DecimalPlace > 0 Then
            ' Convert cents
            Temp = Left(Mid(Numb, DecimalPlace + 1) & "00", 2)
            Cents = ConvertTens(Temp)
            ' Strip off cents from remainder to convert.
            Numb = Trim(Left(Numb, DecimalPlace - 1))
        End If
        Count = 1
        Do While Numb <> ""
            ' Convert last 3 digits of Numb to English dollars.
            Temp = ConvertHundreds(Right(Numb, 3))
            If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
            If Len(Numb) > 3 Then
                ' Remove last 3 converted digits from Numb.
                Numb = Left(Numb, Len(Numb) - 3)
            Else
                Numb = ""
            End If
            Count = Count + 1
        Loop

        ' Clean up dollars.
        Select Case Dollars
            Case "" : Dollars = ""
            Case "One" : Dollars = "One Peso"
            Case Else : Dollars = Dollars & "Pesos"
        End Select

        ' Clean up cents.
        Select Case Cents
            Case "" : Cents = ""
            Case "One" : Cents = " And One Cent"
            Case Else : Cents = " And " & Cents & "Cents"
        End Select

        If Dollars & Cents <> "" Then
            ConvertCurrencyToEnglish = Dollars & Cents
        End If
    End Function

    Private Function ConvertHundreds(ByVal MyNumber As String) As String
        Dim Result As String
        ' Exit if there is nothing to convert.
        If Val(MyNumber) = 0 Then Exit Function
        ' Append leading zeros to number.
        MyNumber = Right("000" & MyNumber, 3)
        ' Do we have a hundreds place digit to convert?
        If Left(MyNumber, 1) <> "0" Then
            Result = ConvertDigit(Left(MyNumber, 1)) & " Hundred "
        End If
        ' Do we have a tens place digit to convert?
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & ConvertTens(Mid(MyNumber, 2))
        Else
            ' If not, then convert the ones place digit.
            Result = Result & ConvertDigit(Mid(MyNumber, 3))
        End If
        ConvertHundreds = Trim(Result)
    End Function

    Private Function ConvertTens(ByVal MyTens As String) As String
        Dim Result As String
        ' Is value between 10 and 19?
        If Val(Left(MyTens, 1)) = 1 Then
            Select Case Val(MyTens)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else
            ' .. otherwise it's between 20 and 99.
            Select Case Val(Left(MyTens, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            ' Convert ones place digit.
            Result = Result & ConvertDigit(Right(MyTens, 1))
        End If
        ConvertTens = Result
    End Function

    Private Function ConvertDigit(ByVal MyDigit As String) As String
        Select Case Val(MyDigit)
            Case 1 : ConvertDigit = "One"
            Case 2 : ConvertDigit = "Two"
            Case 3 : ConvertDigit = "Three"
            Case 4 : ConvertDigit = "Four"
            Case 5 : ConvertDigit = "Five"
            Case 6 : ConvertDigit = "Six"
            Case 7 : ConvertDigit = "Seven"
            Case 8 : ConvertDigit = "Eight"
            Case 9 : ConvertDigit = "Nine"
            Case Else : ConvertDigit = ""
        End Select
    End Function

#Region "New Library"
    Public Function XGridColumnCurrency(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal column As Array) As GridView
        For Each valueArr As String In column
            For I = 0 To grdView.Columns.Count - 1
                If valueArr = grdView.Columns(I).FieldName Then
                    'grdView.Columns(I).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
                    'grdView.Columns(I).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far
                    grdView.Columns(I).DisplayFormat.FormatType = FormatType.Numeric
                    grdView.Columns(I).DisplayFormat.FormatString = "n"
                    grdView.Columns(I).Width = 100
                End If
            Next
        Next
        Return grdView
    End Function
    Public Function XGridColumnNumber(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal column As Array) As GridView
        For Each valueArr As String In column
            For I = 0 To grdView.Columns.Count - 1
                If valueArr = grdView.Columns(I).FieldName Then
                    grdView.Columns(valueArr).DisplayFormat.FormatType = FormatType.Numeric
                    grdView.Columns(valueArr).DisplayFormat.FormatString = "N0"
                End If
            Next
        Next
        Return grdView
    End Function
    Public Function XGridColumnAlignment(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal column As Array, ByVal algn As DevExpress.Utils.HorzAlignment) As GridView
        For Each valueArr As String In column
            For I = 0 To grdView.Columns.Count - 1
                If valueArr = grdView.Columns(I).FieldName Then
                    grdView.Columns(valueArr).AppearanceCell.TextOptions.HAlignment = algn
                    grdView.Columns(valueArr).AppearanceHeader.TextOptions.HAlignment = algn
                End If
            Next
        Next
        Return grdView
    End Function
    
    Public Function XGridColumnFooterSummaryCurrency(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal column As Array, ByVal summaryType As SummaryItemType) As GridView
        For Each valueArr As String In column
            For I = 0 To grdView.Columns.Count - 1
                If valueArr = grdView.Columns(I).FieldName Then
                    grdView.Columns(valueArr).SummaryItem.SummaryType = summaryType
                    grdView.Columns(valueArr).SummaryItem.DisplayFormat = "{0:n}"
                    grdView.Columns(valueArr).SummaryItem.Tag = 1
                    CType(grdView.Columns(valueArr).View, GridView).OptionsView.ShowFooter = True
                End If
            Next
        Next
        Return grdView
    End Function

    Public Function XGridColumnFooterSummaryNumber(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal column As Array, ByVal summaryType As SummaryItemType) As GridView
        For Each valueArr As String In column
            For I = 0 To grdView.Columns.Count - 1
                If valueArr = grdView.Columns(I).FieldName Then
                    grdView.Columns(valueArr).SummaryItem.SummaryType = summaryType
                    grdView.Columns(valueArr).SummaryItem.DisplayFormat = "{0:N0}"
                    grdView.Columns(valueArr).SummaryItem.Tag = 1
                    CType(grdView.Columns(valueArr).View, GridView).OptionsView.ShowFooter = True
                End If
            Next
        Next
        Return grdView
    End Function

    Public Function XGridColumnGroupSummaryCurrency(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal column As Array, ByVal summaryType As SummaryItemType) As GridView
        For Each valueArr As String In column
            For I = 0 To grdView.Columns.Count - 1
                If valueArr = grdView.Columns(I).FieldName Then
                    Dim item As New GridGroupSummaryItem()
                    item.FieldName = valueArr
                    item.SummaryType = summaryType
                    item.DisplayFormat = "{0:n}"
                    item.ShowInGroupColumnFooter = grdView.Columns(valueArr)
                    grdView.GroupSummary.Add(item)
                End If
            Next
        Next
        Return grdView
    End Function

    Public Function XGridColumnGroupSummaryNumber(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal column As Array, ByVal summaryType As SummaryItemType) As GridView
        For Each valueArr As String In column
            For I = 0 To grdView.Columns.Count - 1
                If valueArr = grdView.Columns(I).FieldName Then
                    Dim item As New GridGroupSummaryItem()
                    item.FieldName = valueArr
                    item.SummaryType = summaryType
                    item.DisplayFormat = "{0:N0}"
                    item.ShowInGroupColumnFooter = grdView.Columns(valueArr)
                    grdView.GroupSummary.Add(item)
                End If
            Next
        Next
        Return grdView
    End Function
    Public Function ReadFile(ByVal path As String) As String
        Dim oReader As StreamReader
        oReader = New StreamReader(path, True)
        ReadFile = oReader.ReadToEnd
        oReader.Close()
        Return ReadFile
    End Function

#End Region
End Module

