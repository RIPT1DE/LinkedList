Module Module1

    Public Class LinkedList

        Private head As node
        Private tail As node
        Private length As Integer

        Private Class node
            Public entry As String
            Public nextNode As node

            Sub New(ByVal input As String, ByVal pointer As node)
                entry = input
                nextNode = pointer
            End Sub
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
            If head.entry = vbNullString Then
                head.entry = input
                head.nextNode = Nothing
                tail = head
            Else
                tail.nextNode = New node(input, Nothing)
                tail = tail.nextNode
            End If
            length += 1
        End Sub

        Sub insert(ByVal input As String)
            If head.entry = vbNullString Then
                addNew(input)
            Else
                If input < head.entry Then
                    head = New node(input, head)
                ElseIf input > tail.entry Then
                    addNew(input)
                Else
                    Dim current = head
                    Do While input > current.nextNode.entry
                        current = current.nextNode
                    Loop
                    current.nextNode = New node(input, current.nextNode)
                End If
            End If
            length += 1
        End Sub

        Sub insert(ByVal input As String, ByVal index As Integer)
            If index <= length - 1 Then
                If index = 0 Then
                    head = New node(input, head)
                ElseIf index = 1 Then
                    head.nextNode = New node(input, head.nextNode)
                Else
                    Dim current = head
                    Dim counter = 1
                    Do While counter < index
                        current = current.nextNode
                        counter += 1
                    Loop
                    current.nextNode = New node(input, current.nextNode)
                End If
            End If
            length += 1
        End Sub

        Function getNode(ByVal index As Integer)
            Dim out = head
            For i = 0 To index
                If i <> 0 Then
                    out = out.nextNode
                End If
            Next
            Return out
        End Function

        Function remNode(ByVal index As Integer)
            Dim out = head
            For i = 0 To index - 1
                If i <> 0 Then
                    out = out.nextNode
                End If
            Next
            out.nextNode = out.nextNode.nextNode
            Return out.nextNode
        End Function

        Sub remNode(ByVal ent As String)
            If ent = head.entry Then
                head = head.nextNode
            Else
                Dim counter As Integer = 1
                Dim out = head
                Do Until ent = out.nextNode.entry Or IsNothing(out)
                    out = out.nextNode
                Loop
                If IsNothing(out) Then
                    Return
                Else
                    out.nextNode = out.nextNode.nextNode
                End If
            End If

        End Sub

        Function getHead()
            Return head
        End Function
        Function getTail()
            Return tail
        End Function

        Sub print()
            Dim mNext As node = head
            Do While IsNothing(mNext) = False
                Console.Write(mNext.entry & " ")
                mNext = mNext.nextNode
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
        Console.Write(names.getNode(0).entry)
        names.print()
        Console.WriteLine()
        names.remNode("Z")
        names.print()
        Console.ReadLine()
    End Sub


End Module
