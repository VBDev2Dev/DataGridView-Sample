

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

    Private Sub PersonDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PersonDataGridView.RowHeaderMouseDoubleClick
        If Not PersonDataGridView.Rows(e.RowIndex).IsNewRow Then
            'Note that there are many ways to get the data 
            Dim p As Person = PersonDataGridView.Rows(e.RowIndex).DataBoundItem
            MessageBox.Show($"You double clicked on {p}")
            MessageBox.Show($"The binding source has {DirectCast(
                            PersonBindingSource.DataSource,
                            IEnumerable(Of Person)
                            ).
                            First(Function(p2) p2 Is p)}")

            MessageBox.Show($"Data contains:{data.Item(data.IndexOf(p))}")
            MessageBox.Show($"Data now has {data.Count} items.")
        End If
    End Sub
End Class
