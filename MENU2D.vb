
Module MENU2D

    Sub Main()
        'Changing the color of the console
        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.White
        Console.Clear()

        ' Initialize a 2D array with some menu items
        ' 1D = index that holds the position of the item
        ' 2D = all the info about the item (Name, Price, Rating)
        Dim Menu(3, 2) As String
        Menu(0, 0) = "Kebab"
        Menu(0, 1) = "9.99"
        Menu(0, 2) = "5"

        Menu(1, 0) = "Beef"
        Menu(1, 1) = "6.99"
        Menu(1, 2) = "7"

        Menu(2, 0) = "Chicken"
        Menu(2, 1) = "4.00"
        Menu(2, 2) = "9"

        Menu(3, 0) = "Beer"
        Menu(3, 1) = "0.99"
        Menu(3, 2) = "10"

        Dim userInput As String
        ' I need this to add new items on the menu
        ' Initialiy the size is 3, so I need 4 to add
        Dim indexSizePlusOne As Integer = 4




        Do
            ' Print out the menu
            Console.WriteLine("*******************************************************************")
            Console.WriteLine("*************************** MENU  *********************************")
            Console.WriteLine("*******************************************************************")
            Console.WriteLine(vbNewLine)

            Console.WriteLine("ITEM #" & vbTab & "NAME" & vbTab & "PRICE" & vbTab & "RATING")
            ' Looping through my array
            For i As Integer = 0 To indexSizePlusOne - 1
                Console.WriteLine("Item " & i + 1 & ": " & Menu(i, 0) & vbTab & Menu(i, 1) & "$" & vbTab & Menu(i, 2))
            Next i
            Console.WriteLine(vbNewLine)
            Do
                ' Ask the user if they want to enter a new item
                Console.WriteLine()
                Console.WriteLine("Do you want to enter a new item? (y/n)")
                userInput = Console.ReadLine()

                If userInput.ToLower() = "y" Then
                    ' Create a new array with one more row
                    Dim newMenu(indexSizePlusOne, 2) As String

                    ' Copy old array to new array
                    For i As Integer = 0 To indexSizePlusOne - 1
                        For j As Integer = 0 To 2
                            newMenu(i, j) = Menu(i, j)
                        Next
                    Next

                    Dim temp As String
                    Dim price As Double
                    Dim rate As Integer

                    ' Validate name (not empty)
                    Do
                        Console.WriteLine()
                        Console.WriteLine("Enter the name of the new item (cannot be empty):")
                        temp = Console.ReadLine()
                    Loop While String.IsNullOrEmpty(temp)
                    newMenu(indexSizePlusOne, 0) = temp

                    ' Validate price (between 0.99 and 100)
                    Do
                        Console.WriteLine()
                        Console.WriteLine("Enter the price of the new item (the price must be between 0.99 and 100.00):")
                        temp = Console.ReadLine()
                    Loop While Not Double.TryParse(temp, price) OrElse price < 0.99 OrElse price > 100
                    'Format "F2" = format number to 2 digits
                    newMenu(indexSizePlusOne, 1) = price.ToString("F2")


                    ' Validate rate (integer between 1 and 10)
                    Do
                        Console.WriteLine()
                        Console.WriteLine("Enter the rate of the new item (1 to 10):")
                        temp = Console.ReadLine()
                    Loop While Not Integer.TryParse(temp, rate) OrElse rate < 1 OrElse rate > 10
                    newMenu(indexSizePlusOne, 2) = temp


                    ' Point old array to new array
                    Menu = newMenu

                    ' Increase the current size of the array
                    indexSizePlusOne += 1

                    Console.Clear()
                    Exit Do

                ElseIf userInput.ToLower() = "n" Then
                    Dim exitMenu As String
                    Console.WriteLine()
                    Console.WriteLine("Do you want to exit the program?")
                    Console.WriteLine("Press X to exit or any other key to continue")
                    exitMenu = Console.ReadLine()
                    If UCase(exitMenu) = "X" Then
                        Environment.Exit(0)
                    Else
                        ' Continue the program
                    End If

                Else
                    Console.WriteLine()
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.")
                End If
            Loop


        Loop


    End Sub

End Module
