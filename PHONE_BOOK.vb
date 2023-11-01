Imports System.Security.Cryptography

Module PHONE_BOOK

    Sub Main()
        'Changing the color of the console
        Console.BackgroundColor = ConsoleColor.DarkMagenta
        Console.ForegroundColor = ConsoleColor.White
        Console.Clear()

        ' Initialize a 2D array
        ' First number = number of entries
        ' Second number = number of data (Name + Phone)
        Dim phoneBook(8, 1) As String

        ' Some entries
        phoneBook(0, 0) = "Louis"
        phoneBook(0, 1) = "450-456-7784"
        phoneBook(1, 0) = "Marie"
        phoneBook(1, 1) = "514-789-0123"
        phoneBook(2, 0) = "Victor"
        phoneBook(2, 1) = "438-113-0023"
        phoneBook(3, 0) = "Magalie"
        phoneBook(3, 1) = "514-111-7854"
        phoneBook(4, 0) = "Michel"
        phoneBook(4, 1) = "514-111-1597"
        phoneBook(5, 0) = "Francine"
        phoneBook(5, 1) = "450-111-5512"
        phoneBook(6, 0) = "Jean"
        phoneBook(6, 1) = "514-111-6482"
        phoneBook(7, 0) = "Martin"
        phoneBook(7, 1) = "514-111-7411"
        phoneBook(8, 0) = "Sylvie"
        phoneBook(8, 1) = "450-111-5531"

        ' "currentSizePlusOne" is to be able to add new entries
        Dim currentSizePlusOne As Integer = 9
        ' Record the user choice
        Dim userChoice As String

        Do
            ' Display the phone book
            Console.WriteLine()
            Console.WriteLine("****************************************************")
            Console.WriteLine("***************** Phone Book ***********************")
            Console.WriteLine("****************************************************")

            ' Display the options
            Console.WriteLine()
            Console.WriteLine("Select an option:")
            Console.WriteLine("1. Add")
            Console.WriteLine("2. Edit")
            Console.WriteLine("3. Delete")
            Console.WriteLine("4. Display")
            Console.WriteLine("5. Exit")

            userChoice = Console.ReadLine()

            ' ADDING 
            Select Case userChoice
                Case 1 ' Add
                    Dim newName As String = ""
                    Dim newNumber As String = ""
                    Console.WriteLine()

                    ' Validate name
                    Do While String.IsNullOrEmpty(newName)
                        Console.WriteLine("Enter the name:")
                        newName = Console.ReadLine()
                        If String.IsNullOrEmpty(newName) Then
                            Console.WriteLine("Name cannot be empty.")
                        End If
                    Loop

                    ' Validate phone number
                    Dim isValid As Boolean = False
                    Do While Not isValid
                        Console.WriteLine()
                        Console.WriteLine("Enter the phone number in the format (XXX-XXX-XXXX):")
                        newNumber = Console.ReadLine()
                        ' Regex ^ = start  d{3} = 3 numbers   $ = end
                        If System.Text.RegularExpressions.Regex.IsMatch(newNumber, "^\d{3}-\d{3}-\d{4}$") Then
                            isValid = True
                        Else
                            Console.WriteLine("Invalid phone number format.")
                        End If
                    Loop

                    ' Resize array and add new entry
                    Dim arrayWithEmptySlot(currentSizePlusOne, 1) As String
                    'Array.Copy = build-in function. This is the syntax : Array.Copy(SourceArray, DestinationArray, Length) 
                    Array.Copy(phoneBook, 0, arrayWithEmptySlot, 0, currentSizePlusOne * 2)
                    arrayWithEmptySlot(currentSizePlusOne, 0) = newName
                    arrayWithEmptySlot(currentSizePlusOne, 1) = newNumber
                    phoneBook = arrayWithEmptySlot
                    currentSizePlusOne += 1

                    Console.WriteLine()
                    ' Display the name of the new added name and wait 2 seconds before clearing the console
                    Console.WriteLine(newName & " was added to the phonebook")
                    System.Threading.Thread.Sleep(2000)
                    Console.Clear()

                ' EDITING
                Case 2 ' Edit
                    Dim editName As String
                    Console.WriteLine()
                    Console.WriteLine("Enter the name of the entry you want to edit:")
                    editName = Console.ReadLine()

                    Dim found As Boolean = False
                    For i As Integer = 0 To currentSizePlusOne - 1
                        If phoneBook(i, 0) = editName Then

                            ' Validate name
                            Dim newName As String = ""
                            Do While String.IsNullOrEmpty(newName)
                                Console.WriteLine("Enter the new name:")
                                newName = Console.ReadLine()
                                If String.IsNullOrEmpty(newName) Then
                                    Console.WriteLine("Name cannot be empty.")
                                End If
                            Loop
                            ' Edit the name
                            phoneBook(i, 0) = newName

                            ' Validate phone number
                            Dim isValid As Boolean = False
                            Do While Not isValid
                                Dim newNumber As String = ""
                                Console.WriteLine()
                                Console.WriteLine("Enter the phone number in the format (XXX-XXX-XXXX):")
                                newNumber = Console.ReadLine()
                                ' Regex ^ = start  d{3} = 3 numbers   $ = end
                                If System.Text.RegularExpressions.Regex.IsMatch(newNumber, "^\d{3}-\d{3}-\d{4}$") Then
                                    isValid = True
                                    Console.WriteLine("Enter the new phone number:")
                                    ' Edit the number
                                    phoneBook(i, 1) = newNumber
                                Else
                                    Console.WriteLine("Invalid phone number format.")
                                End If
                            Loop

                            Console.WriteLine()
                            Console.WriteLine(editName & " has been updated successfully")
                            System.Threading.Thread.Sleep(2000)
                            Console.Clear()
                            found = True
                            Exit For
                        End If
                    Next
                    ' If found is still "False", this is because there was not match. 
                    If found = False Then
                        Console.WriteLine("Entry not found.")
                    End If

                ' DELETING        
                Case 3 ' Delete
                    Dim deleteName As String
                    Console.WriteLine()
                    Console.WriteLine("Enter the name of the entry you want to delete:")
                    deleteName = Console.ReadLine()

                    Dim found As Boolean = False
                    For i As Integer = 0 To currentSizePlusOne - 1
                        If phoneBook(i, 0) = deleteName Then
                            found = True
                            ' Starting at the "deleteName", I'm rewriting the array phoneBook (overwriting)
                            ' "currentSizePlusOne" because I'm removing an entry
                            For j As Integer = i To currentSizePlusOne - 2
                                ' j = i where i = index of the deleting name
                                ' replacing j index by j + 1 (the next entry in the phone book)
                                phoneBook(j, 0) = phoneBook(j + 1, 0)
                                phoneBook(j, 1) = phoneBook(j + 1, 1)
                            Next
                            ' Decrement by one since I removed an entry
                            currentSizePlusOne -= 1
                            ' Display the name of the delete one
                            Console.WriteLine()
                            Console.WriteLine(deleteName & " was removed from the phonebook")
                            ' Wait 2 seconds and then clear the console
                            System.Threading.Thread.Sleep(2000)
                            Console.Clear()
                            Exit For
                        End If
                    Next

                    ' If found is still "False", this is because there was not match.
                    If found = False Then
                        Console.WriteLine("Entry not found.")
                    End If

                ' DISPLAYING
                Case 4 ' Display
                    Console.WriteLine()
                    Console.WriteLine("****************************************************")
                    Console.WriteLine("***************** Phone Book ***********************")
                    Console.WriteLine("****************************************************")
                    Console.WriteLine()

                    ' Create a temporary 1D array to hold the names
                    Dim tempNames(currentSizePlusOne - 1) As String
                    For i As Integer = 0 To currentSizePlusOne - 1
                        tempNames(i) = phoneBook(i, 0)
                    Next

                    ' Sort the names                  
                    Array.Sort(tempNames)

                    ' Display the sorted phone book
                    For Each name In tempNames
                        For i As Integer = 0 To currentSizePlusOne - 1
                            If phoneBook(i, 0) = name Then
                                Console.WriteLine(phoneBook(i, 0) & ": " & phoneBook(i, 1))
                                Exit For
                            End If
                        Next
                    Next

                    Console.WriteLine()

                ' EXITING
                Case 5 ' Exit
                    Exit Do

                Case Else
                    Console.WriteLine()
                    Console.WriteLine("Invalid option.")

            End Select

        Loop

    End Sub

End Module

