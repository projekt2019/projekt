﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChatArea
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblChatpartner = New System.Windows.Forms.Label()
        Me.ltbChat = New System.Windows.Forms.ListBox()
        Me.btnSenden = New System.Windows.Forms.Button()
        Me.txtEingabe = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblChatpartner
        '
        Me.lblChatpartner.AutoSize = True
        Me.lblChatpartner.Location = New System.Drawing.Point(15, 10)
        Me.lblChatpartner.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblChatpartner.Name = "lblChatpartner"
        Me.lblChatpartner.Size = New System.Drawing.Size(62, 13)
        Me.lblChatpartner.TabIndex = 10
        Me.lblChatpartner.Text = "Chatpartner"
        '
        'ltbChat
        '
        Me.ltbChat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ltbChat.FormattingEnabled = True
        Me.ltbChat.Location = New System.Drawing.Point(18, 36)
        Me.ltbChat.Margin = New System.Windows.Forms.Padding(2)
        Me.ltbChat.Name = "ltbChat"
        Me.ltbChat.Size = New System.Drawing.Size(516, 212)
        Me.ltbChat.TabIndex = 9
        '
        'btnSenden
        '
        Me.btnSenden.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSenden.Location = New System.Drawing.Point(459, 268)
        Me.btnSenden.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSenden.Name = "btnSenden"
        Me.btnSenden.Size = New System.Drawing.Size(75, 30)
        Me.btnSenden.TabIndex = 8
        Me.btnSenden.Text = "Senden"
        Me.btnSenden.UseVisualStyleBackColor = True
        '
        'txtEingabe
        '
        Me.txtEingabe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEingabe.Location = New System.Drawing.Point(18, 276)
        Me.txtEingabe.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEingabe.Name = "txtEingabe"
        Me.txtEingabe.Size = New System.Drawing.Size(426, 20)
        Me.txtEingabe.TabIndex = 7
        '
        'ChatArea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblChatpartner)
        Me.Controls.Add(Me.ltbChat)
        Me.Controls.Add(Me.btnSenden)
        Me.Controls.Add(Me.txtEingabe)
        Me.Name = "ChatArea"
        Me.Size = New System.Drawing.Size(554, 312)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblChatpartner As Label
    Friend WithEvents ltbChat As ListBox
    Friend WithEvents btnSenden As Button
    Friend WithEvents txtEingabe As TextBox
End Class