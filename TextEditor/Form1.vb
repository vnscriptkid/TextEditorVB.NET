Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

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
End Class