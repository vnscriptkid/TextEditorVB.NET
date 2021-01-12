Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Using streamReader As New StreamReader(OpenFileDialog1.FileName)
                Try
                    RichTextBox1.Text = streamReader.ReadToEnd()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Info: ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End Using
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Using streamWriter = File.CreateText(SaveFileDialog1.FileName)
                Try
                    streamWriter.Write(RichTextBox1.Text)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Info: ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End Using
        End If
    End Sub

    Private Sub StyleAndSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StyleAndSizeToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        RichTextBox1.Font = FontDialog1.Font
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        RichTextBox1.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(RichTextBox1.Text, FontDialog1.Font, New SolidBrush(ColorDialog1.Color), 20, 20)
    End Sub

    Private Sub PrintReviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintReviewToolStripMenuItem.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub
End Class