﻿Imports System.Net.Sockets

Public Class NetServer

    Private connector As ServerConnector

    Sub New()
    End Sub

    ' Erstellt neue Instanz und verbindet sich
    Public Sub connect()
        connector = New ServerConnector()
        ' Einkommende Nachricht handeln
        connector.OnRecieve.addHandler(AddressOf onRequest)
        connector.connect()
    End Sub

    ' Event für Registrierung Neue Methode zuweisen!
    Public OnRegister As Action(Of String, String, String, Action(Of User))
    ' Event für login Neue Methode zuweisen!
    Public OnLogin As Action(Of String, String, Action(Of User))
    'Event für alle Benutzernamen senden
    Public OnUserlist As Action(Of Integer, Action(Of User()))
    'Event für Freunde senden
    Public OnChats As Action(Of Integer, Action(Of Chat()))
    'Event für Neue Freunde
    Public OnNewFriend As Action(Of Integer, Integer, Action(Of User))
    'Event für alle Nachrichten
    Public OnMessages As Action(Of Action(Of Message()))


    ' Falls neue Nachricht kommt:
    Private Sub onRequest(req As ConnectionData, client As TcpClient)
        Console.WriteLine("Einkommende Nachricht des Typs " & req.Type)
        ' Welcher Typ ist die Nachricht?
        Select Case req.Type
            Case "register"
                If OnRegister IsNot Nothing Then
                    ' Argumente bekommen
                    Dim name As String = req.Data.Item("name")
                    Dim username As String = req.Data.Item("username")
                    Dim password As String = req.Data.Item("password")

                    ' Methode aufrufen + Callback 
                    OnRegister(
                        name,
                        username,
                        password,
                        Sub(User As User)
                            RegisterConfirm(User, client)
                        End Sub
                    )
                End If
            Case "login"
                If OnLogin IsNot Nothing Then
                    ' Argumente bekommen
                    Dim username As String = req.Data.Item("username")
                    Dim password As String = req.Data.Item("password")


                    ' Methode aufrufen + Callback 
                    OnLogin(
                        username,
                        password,
                        Sub(User As User)
                            LoginConfirm(User, client)
                        End Sub
                    )
                End If

            Case "userlist"
                If OnUserlist IsNot Nothing Then
                    Dim id As Integer = req.getData("id")
                    OnUserlist(
                    Sub(val As User())
                        AllUsersSend(val, client)
                    End Sub)

                End If

            Case "chats"
                If OnChats IsNot Nothing Then
                    Dim id As Integer = req.getData("id")
                    OnFriends(
                        id,
                        Sub(list As Chat())
                            FriendsSend(list, client)
                        End Sub)
                End If

            Case "AddNewFriend"
                If OnNewFriend IsNot Nothing Then
                    Dim idself As Integer = req.Data.Item("IDself")
                    Dim idfriend As Integer = req.Data.Item("IDfriend")
                    OnNewFriend(idself,
                                idfriend,
                                Sub(User As User)
                                    NewFriendConfirm(User, client)
                                End Sub)

                End If

            Case "messages"
                If OnMessages IsNot Nothing Then
                    OnMessages(
                        Sub(val As Message())
                            SendAllMessages(val, client)
                        End Sub)

                End If

        End Select

    End Sub

    ' Sende Antwort für Registrieren
    Sub RegisterConfirm(User As User, client As TcpClient)
        Dim data As New Dictionary(Of String, Object)
        data.Add("user", User)
        Dim req As New ConnectionData("registerconfirm", data)
        connector.send(client, req)
    End Sub

    ' Sende Antwort für Login
    Sub LoginConfirm(User As User, client As TcpClient)
        Dim data As New Dictionary(Of String, Object)
        data.Add("user", User)
        Dim req As New ConnectionData("loginconfirm", data)
        connector.send(client, req)
    End Sub


    Sub AllUsersSend(ans As User(), client As TcpClient)
        Dim data As New Dictionary(Of String, Object)
        data.Add("userlist", ans)
        connector.send(client, New ConnectionData("userlist", data))
    End Sub

    Sub ChatsSend(ans As Chat(), client As TcpClient)
        Dim data As New Dictionary(Of String, Object)
        data.Add("Friends", ans)
        connector.send(client, New ConnectionData("friends", data))
    End Sub

    Sub NewFriendConfirm(val As User, client As TcpClient)
        Dim data As New Dictionary(Of String, Object)
        data.Add("success", val)
        connector.send(client, New ConnectionData("AddNewFriend", data))
    End Sub

    Sub SendAllMessages(val As Message(), client As TcpClient)
        Dim data As New Dictionary(Of String, Object)
        data.Add("messages", data)
        connector.send(client, New ConnectionData("messages", data))
    End Sub
End Class
