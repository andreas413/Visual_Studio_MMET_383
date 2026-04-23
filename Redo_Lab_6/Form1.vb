Public Class Form1
    Private student_names(10) As String
    Private student_ids(10) As String
    Private student_scores(10) As String
    Private count As Integer

    Private Sub DisplayStudents()
        Dim report As String = "Name" & vbTab & "ID" & vbTab & "Score" & vbTab & "Score" & vbCrLf
        report &= "---------------------------------------------" & vbCrLf

        For i As Integer = 0 To count - 1
            report &= student_names(i) & vbTab & student_ids(i) & vbTab & student_scores(i) & vbCrLf
        Next

        RichTextBox1.Text = report

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox2.Text <> "") And IsNumeric(TextBox3.Text) Then
            If count < student_names.Length Then
                student_names(count) = TextBox2.Text
                student_ids(count) = TextBox1.Text
                student_scores(count) = TextBox3.Text

                count += 1

                'Clear inputs and focus

                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox1.Focus()

                MsgBox("Student added successfully", vbOKOnly)

            Else
                MsgBox("Array is full")
            End If
        Else
            MsgBox("Please enter a valid name and score.", vbOKOnly)
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox1.Focus()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call DisplayStudents()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If count = 0 Then Exit Sub

        Dim max_index As Integer = 0 'Assume first student is the highest

        For i As Integer = 1 To count - 1
            MsgBox(i)
            If student_scores(i) > student_scores(max_index) Then
                max_index = i
            End If
        Next

        RichTextBox1.Text = "Highest Score: " & student_names(max_index) & " ID: " & student_ids(max_index) & " ) - " & student_scores(max_index) & vbNewLine & vbCrLf
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If count = 0 Then
            MsgBox("There are no students in the list.", vbOKOnly)
            Exit Sub
        End If

        Dim min_index As Integer = 0

        For i As Integer = 1 To count - 1
            If student_scores(i) < student_scores(min_index) Then
                min_index = i
            End If
        Next

        'Display results
        RichTextBox1.Text &= "Lowest Score: " & student_names(min_index) & " ID: " & student_ids(min_index) & " ) - " & student_scores(min_index)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Selection Sort Logic
        For i As Integer = 0 To count - 2
            For j As Integer = i + 1 To count - 1
                If student_scores(i) > student_scores(j) Then
                    'swap scores
                    Dim temp_score As Integer = student_scores(i)
                    student_scores(i) = student_scores(j)
                    student_scores(j) = temp_score

                    'Swap names
                    Dim temp_name As String = student_names(i)
                    student_names(i) = student_names(j)
                    student_names(j) = temp_name

                    'Swap student id
                    Dim temp_id As Integer = student_ids(i)
                    student_ids(i) = student_ids(j)
                    student_ids(j) = temp_id

                End If
            Next
        Next

        Call DisplayStudents()
    End Sub
End Class
