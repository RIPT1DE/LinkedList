Module Module1

    Structure Node
        Dim data As String
        Dim pointer As Integer
    End Structure

    Dim nextFree As Integer = 1
    Dim head As Integer

    Sub Main()
        Dim names(10) As Node
        insert(names, "H")
        insert(names, "A")
        insert(names, "G")
        insert(names, "Z")
        insert(names, "E")
        insert(names, "B")
        printList(names)
        Console.ReadLine()
    End Sub

    Sub insert(ByRef list() As Node, ByVal input As String)
        list(nextFree).data = input
        If nextFree = 1 Then
            list(nextFree).pointer = 0
            head = 1
        Else
            If input < list(head).data Then
                list(nextFree).pointer = head
                head = nextFree
            Else
                Dim index As Integer = head
                Do While input > list(list(index).pointer).data And list(index).pointer <> 0
                    index = list(index).pointer
                Loop
                list(nextFree).pointer = list(index).pointer
                list(index).pointer = nextFree
            End If
        End If
        nextFree += 1
    End Sub



    Sub printList(ByVal list() As Node)
        Dim prev As Integer = head
        Dim arr(nextFree - 1) As String
        For i = 1 To arr.Length - 1
            arr(i) = list(prev).data
            prev = list(prev).pointer
        Next
        For i = 1 To arr.Length - 1
            Console.Write(arr(i) & " ")
        Next
    End Sub


End Module
