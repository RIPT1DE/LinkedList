Module Module1

    Structure LinkedList
        Dim entry As String
        Dim pointer As Integer
    End Structure

    Dim nextFree As Integer = 1
    Dim start As Integer

    Sub Main()
        Dim names(10) As LinkedList
        insert(names, "H")
        insert(names, "A")
        insert(names, "G")
        insert(names, "Z")
        insert(names, "E")
        insert(names, "B")
        printList(names)
        Console.ReadLine()
    End Sub

    Sub insert(ByRef list() As LinkedList, ByVal input As String)
        list(nextFree).entry = input
        If nextFree = 1 Then
            list(nextFree).pointer = 0
            start = 1
        Else
            If input < list(start).entry Then
                list(nextFree).pointer = start
                start = nextFree
            Else
                Dim index As Integer = start
                Do While input > list(list(index).pointer).entry And list(index).pointer <> 0
                    index = list(index).pointer
                Loop
                list(nextFree).pointer = list(index).pointer
                list(index).pointer = nextFree
            End If
        End If
        nextFree += 1
    End Sub

    Sub printList(ByVal list() As LinkedList)
        Dim prev As Integer = start
        Dim arr(nextFree - 1) As String
        For i = 1 To arr.Length - 1
            arr(i) = list(prev).entry
            prev = list(prev).pointer
        Next
        For i = 1 To arr.Length - 1
            Console.Write(arr(i) & " ")
        Next
    End Sub


End Module
