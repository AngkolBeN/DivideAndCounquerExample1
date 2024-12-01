Public Class Form1


    'Merge Sort Function - Divide And Conquer

    Public Function MergeSort(arr As Integer()) As Integer()

        If arr.Length <= 1 Then

            Return arr

        End If

        'Divide step

        Dim mid As Integer = arr.Length \ 2
        Dim left As Integer() = MergeSort(arr.Take(mid).ToArray()) ' Recursively divide left
        Dim right As Integer() = MergeSort(arr.Skip(mid).ToArray()) ' Recursively divide right

        'Conquer step - merge the two sorted halves


        Return Merge(left, right)

    End Function

    'Function to merge two sorted arrays
    Private Function Merge(left As Integer(), right As Integer()) As Integer()

        Dim result As New List(Of Integer)()
        Dim i As Integer = 0
        Dim j As Integer = 0

        'Merge the two arrays

        While i < left.Length AndAlso j < right.Length

            If left(i) < right(j) Then

                result.Add(left(i))
                i += 1
            Else
                result.Add(right(j))
                j += 1
            End If

        End While

        'Add any remaining elements

        If i < left.Length Then

            result.AddRange(left.Skip(i))
        End If
        If j < right.Length Then
            result.AddRange(right.Skip(j))
        End If

        Return result.ToArray()
    End Function

    'Event handler for the Sort button click
    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click

        'Get the input numbers
        Dim input As String = txtInput.Text.Trim()
            If String.IsNullOrEmpty(input) Then
            MessageBox.Show("Please enter a list Of numbers separated by commas.")

            Return

        End If

        'Convert input string into an array of integers

        Dim numbers As Integer()
            Try
            numbers = input.Split(","c).Select(Function(n) Integer.Parse(n.Trim())).ToArray()
        Catch ex As Exception
            MessageBox.Show("Please enter valid numbers separated by commas")

            Return

        End Try

        'Apply MergeSort using Divide And Conquer
        Dim sortedNumbers As Integer() = MergeSort(numbers)

        'Show the sorted numbers in the output box

        txtOutput.Text = String.Join(",", sortedNumbers)




    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
