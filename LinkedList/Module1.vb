Module Module1

    Public Class LinkedList

        Private head As node
        Private tail As node
        Private length As Integer

        Private Class node
            Private entry As String
            Private nextNode As node

            Sub New(ByVal input As String, ByVal pointer As node)
                entry = input
                nextNode = pointer
            End Sub

            Public Sub setEntry(ByVal value As String)
                entry = value
            End Sub
            Public Function getEntry()
                Return entry
            End Function

            Public Sub setNext(ByVal nextNode As node)
                Me.nextNode = nextNode
            End Sub
            Public Function getNext()
                Return nextNode
            End Function
        End Class

        Sub New()
            head = New node(vbNullString, Nothing)
            tail = Nothing
        End Sub
        Sub New(ByVal input As String)
            head = New node(input, Nothing)
            tail = head
        End Sub

        Sub addNew(ByVal input As String)
            If head.getEntry = vbNullString Then
                head.setEntry(input)
                head.setNext(Nothing)
                tail = head
            Else
                tail.setNext(New node(input, Nothing))
                tail = tail.getNext
            End If
            length += 1
        End Sub

        Sub insert(ByVal input As String)
            If head.getEntry = vbNullString Then
                addNew(input)
            Else
                If input < head.getEntry Then
                    head = New node(input, head)
                ElseIf input > tail.getEntry Then
                    addNew(input)
                Else
                    Dim current = head
                    Do While input > current.getNext.getEntry
                        current = current.getNext
                    Loop
                    current.setNext(New node(input, current.getNext))
                End If
            End If
            length += 1
        End Sub

        Sub insert(ByVal input As String, ByVal index As Integer)
            If index <= length - 1 Then
                If index = 0 Then
                    head = New node(input, head)
                ElseIf index = 1 Then
                    head.setNext(New node(input, head.getNext))
                Else
                    Dim current = head
                    Dim counter = 1
                    Do While counter < index
                        current = current.getNext
                        counter += 1
                    Loop
                    current.setNext(New node(input, current.getNext))
                End If
            End If
            length += 1
        End Sub

        Function getNode(ByVal index As Integer)
            Dim out = head
            For i = 0 To index
                If i <> 0 Then
                    out = out.getNext
                End If
            Next
            Return out
        End Function
        Function getHead()
            Return head
        End Function
        Function getTail()
            Return tail
        End Function

        Sub print()
            Dim mNext As node = head
            Do While IsNothing(mNext) = False
                Console.Write(mNext.getEntry & " ")
                mNext = mNext.getNext
            Loop
        End Sub

    End Class


    Sub Main()
        Dim names = New LinkedList
        names.insert("B")
        names.insert("A")
        names.addNew("F")
        names.insert("D")
        names.insert("Z")
        names.insert("Y")
        names.insert("J", 4)
        Console.Write(names.getNode(0).getEntry)
        names.print()
        Console.ReadLine()
    End Sub


End Module
