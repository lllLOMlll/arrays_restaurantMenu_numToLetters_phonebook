Module NUMBA2LETTERS

    Sub Main()
        'Changing the color of the console
        Console.BackgroundColor = ConsoleColor.DarkGreen
        Console.ForegroundColor = ConsoleColor.White
        Console.Clear()

        Dim exitLoop As String

        Do
            Dim inputNumber As String
            Dim wordAsNumber As String = ""

            ' Ask the user for a number between 0 and 1000
            Console.WriteLine("Please enter a number between 0 and 1000:")
            inputNumber = Console.ReadLine()

            ' Validate the input to make sure it's a number
            While Not IsNumeric(inputNumber)
                Console.WriteLine()
                Console.WriteLine("Wrong input!")
                Console.WriteLine("Please enter a number between 0 and 1000:")
                inputNumber = Console.ReadLine()
            End While

            Dim parsedNumber As Integer = Integer.Parse(inputNumber)

            If parsedNumber >= 0 And parsedNumber <= 1000 Then
                Dim hundreds As Integer = parsedNumber \ 100
                Dim remainder As Integer = parsedNumber Mod 100

                Select Case hundreds
                        Case 1
                            wordAsNumber = "One Hundred "
                        Case 2
                            wordAsNumber = "Two Hundred "
                        Case 3
                            wordAsNumber = "Three Hundred "
                        Case 4
                            wordAsNumber = "Four Hundred "
                        Case 5
                            wordAsNumber = "Five Hundred "
                        Case 6
                            wordAsNumber = "Six Hundred "
                        Case 7
                            wordAsNumber = "Seven Hundred "
                        Case 8
                            wordAsNumber = "Eight Hundred "
                        Case 9
                            wordAsNumber = "Nine Hundred "
                        Case 10
                            wordAsNumber = "One Thousand "
                    End Select

                    ' Handle tens and ones
                    If remainder > 0 Then
                        Dim tens As Integer = remainder \ 10
                        Dim ones As Integer = remainder Mod 10

                        '10 to 19
                        Select Case tens
                            Case 1
                                Select Case ones
                                    Case 0
                                        wordAsNumber += "Ten"
                                    Case 1
                                        wordAsNumber += "Eleven"
                                    Case 2
                                        wordAsNumber += "Twelve"
                                    Case 3
                                        wordAsNumber += "Thirteen"
                                    Case 4
                                        wordAsNumber += "Fourteen"
                                    Case 5
                                        wordAsNumber += "Fifteen"
                                    Case 6
                                        wordAsNumber += "Sixteen"
                                    Case 7
                                        wordAsNumber += "Seventeen"
                                    Case 8
                                        wordAsNumber += "Eighteen"
                                    Case 9
                                        wordAsNumber += "Nineteen"
                                End Select
                    '20 to 90
                            Case 2
                                wordAsNumber += "Twenty "
                            Case 3
                                wordAsNumber += "Thirty "
                            Case 4
                                wordAsNumber += "Forty "
                            Case 5
                                wordAsNumber += "Fifty "
                            Case 6
                                wordAsNumber += "Sixty "
                            Case 7
                                wordAsNumber += "Seventy "
                            Case 8
                                wordAsNumber += "Eighty "
                            Case 9
                                wordAsNumber += "Ninety "
                        End Select

                        '1 to 9
                        If tens <> 1 Then
                            Select Case ones
                                Case 1
                                    wordAsNumber += "One"
                                Case 2
                                    wordAsNumber += "Two"
                                Case 3
                                    wordAsNumber += "Three"
                                Case 4
                                    wordAsNumber += "Four"
                                Case 5
                                    wordAsNumber += "Five"
                                Case 6
                                    wordAsNumber += "Six"
                                Case 7
                                    wordAsNumber += "Seven"
                                Case 8
                                    wordAsNumber += "Eight"
                                Case 9
                                    wordAsNumber += "Nine"
                            End Select
                        End If
                    End If

                    Console.WriteLine()
                    Console.WriteLine("The number " & inputNumber & " in words is: ")
                    Console.WriteLine(wordAsNumber)
                    Console.WriteLine(vbNewLine)

                Else
                    Console.WriteLine("The number should be between 0 and 1000.")
                    Console.WriteLine()
                End If

            Loop


            Console.ReadKey()
    End Sub

End Module

