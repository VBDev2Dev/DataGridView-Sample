Public Class frmGrid
﻿

Imports System.ComponentModel

Public Class frmGrid

    Dim data As List(Of Person)

    Private Sub frmGrid_Load(sender As Object, e As EventArgs) Handles Me.Load
        data = GetData.ToList

        PersonBindingSource.DataSource = New BindingList(Of Person)(data)


    End Sub

    Function GetData() As IEnumerable(Of Person)

        'Act like we are getting data from a db.  
        'What Type of data you bind will determine what type you cast the bound data.
        'Could have used a datatable, a list(of EF model class), dataset,....
        Return Enumerable.Range(0, 30).Select(Function(n) New Person With
                                                        {
                                                        .Name = n.ToString,
                                                        .EmailAddress = $"{n}@{n}.com",
                                                        .Birthdate = Now.Date.AddYears(-18 - n).AddMonths(-n).AddDays(-n * 20)
                                                        }
                                                   )

    End Function
End Class
