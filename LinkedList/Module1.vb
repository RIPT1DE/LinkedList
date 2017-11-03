Module Module1

    Public Class LinkedList
        Private Class node
            Private entry As String
            Private pointer As node

            Public Sub setEntry(ByVal value As String)
                entry = value
            End Sub
            Public Function getEntry()
                Return entry
            End Function

            Public Sub setPointer(ByVal nextNode As node)
                pointer = nextNode
            End Sub
            Public Function getPointer()
                Return pointer
            End Function
        End Class
        Dim head As node
        Dim tail As node

        Sub New()
            head = New node
            head.setEntry(vbNullString)
            head.setPointer(Nothing)
            tail = Nothing
        End Sub

        Sub New(ByVal entry As String)
            head = New node
            head.setEntry(entry)
            head.setPointer(Nothing)
            tail = head
        End Sub

        Sub addNew(ByVal entry As String)
            If IsNothing(tail) Then
                head.setEntry(entry)
                head.setPointer(Nothing)
                tail = head
            Else
                tail.setPointer(New node)
                tail = tail.getPointer
                tail.setEntry(entry)
                tail.setPointer(Nothing)
            End If
        End Sub

        Sub print()
            Dim mNext As node = head
            Do While IsNothing(mNext) = False
                Console.Write(mNext.getEntry & " ")
                mNext = mNext.getPointer
            Loop
        End Sub

    End Class


    Sub Main()
        Dim names = New LinkedList("A")
        names.addNew("B")
        names.addNew("C")
        names.print()
        Console.ReadLine()
    End Sub

    'Sub insert(ByRef list() As LinkedList, ByVal input As String)
    '    list(nextFree).entry = input
    '    If nextFree = 1 Then
    '        list(nextFree).pointer = 0
    '        start = 1
    '    Else
    '        If input < list(start).entry Then
    '            list(nextFree).pointer = start
    '            start = nextFree
    '        Else
    '            Dim index As Integer = start
    '            Dim prevIndex As Integer = start
    '            Do While input > list(index).entry And list(prevIndex).pointer <> 0
    '                prevIndex = index
    '                index = list(index).pointer
    '            Loop
    '            list(nextFree).pointer = index
    '            list(prevIndex).pointer = nextFree
    '        End If
    '    End If
    '    nextFree += 1
    'End Sub

    'Sub printList(ByVal list() As LinkedList)
    '    Dim prev As Integer = start
    '    Dim arr(nextFree - 1) As String
    '    For i = 1 To arr.Length - 1
    '        arr(i) = list(prev).entry
    '        prev = list(prev).pointer
    '    Next
    '    For i = 1 To arr.Length - 1
    '        Console.Write(arr(i) & " ")
    '    Next
    'End Sub


End Module
