﻿Imports System.Configuration
Imports System.Data.SqlClient

Public Class ValidaDocumento
    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        EjecutaSQL()
    End Sub

    Private Sub EjecutaSQL()
        Try
            'Dim name As String = ConfigurationManager.AppSettings("Cnx")

            Dim connectionString = ConfigurationManager.ConnectionStrings("Cnx").ConnectionString
            Dim queryString = "dbo.Rutas"
            Using connection As New SqlConnection(connectionString)
                Dim command = New SqlCommand(queryString, connection)
                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        'Console.WriteLine(String.Format("{0}, {1}", reader(0), reader(1)))
                        MsgBox(String.Format("{0}, {1}", reader(0), reader(1)))
                    End While
                End Using
                connection.Open()

            End Using



            'Dim s As String = ("SELECT * FROM Alumnes")
            'connexio = New OleDbConnection(myConnectionString)
            'myCommand = New OleDbCommand(s)
            'myCommand.Connection = connexio
            'connexio.Open()
            'Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
            'While myReader.Read()
            '    Dim NOM As String = myReader("NOM")
            '    Dim COGNOM As String = myReader("COGNOM")
            'End While
        Catch exc As Exception
            'Throw New GestorExcepcio(exc.Message)
            MsgBox(exc.Message)
        End Try

    End Sub


End Class