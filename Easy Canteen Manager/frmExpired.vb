Public Class frmExpired

    ' Assume you have a TextBox control named "txtKey" for key entry
    ' Assume you have a Button control named "btnExtend" for initiating the key validation and expiry extension

    Private Sub btnExtend_Click(sender As Object, e As EventArgs) Handles btnExtend.Click
        Dim extensionKey As String = txtKey.Text.Trim() ' Get the key entered by the user

        If ExpiryModule.ExtendExpiry(extensionKey) Then
            MessageBox.Show("Expiry extended successfully!")
        Else
            MessageBox.Show("Invalid key. Please try again.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtkey.Text = ExpiryModule.GenerateExtensionKey()
    End Sub

    Private Sub frmExpired_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExpiryModule.IsExpiredNotif()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class