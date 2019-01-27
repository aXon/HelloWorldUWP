Option Strict On
Option Explicit On

' shapes library has ellipse, polygon and rectangle subclasses
Imports Windows.UI.Xaml.Shapes
Imports Windows.UI ' includes e.g. Colors
Imports Windows.UI.Xaml.Controls ' contains contendialog 


Public NotInheritable Class MainPage
    Inherits Page

    ''' <summary>
    ''' This simple program draw various shapes onto a canvas to
    ''' demonstrate the new syntax/elements required to achieve 
    ''' similar goals taught with Classic Desktop applications
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        ' setting up an ellipse shape with fill
        Dim ellipse1 = New Ellipse
        ellipse1.Fill = New SolidColorBrush(Colors.SteelBlue)
        ellipse1.Width = 100 ' bounding rectangle's width
        ellipse1.Height = 100 ' bounding rectangle's height
        ellipse1.SetValue(Canvas.TopProperty, 100) ' top offset (Y)
        ellipse1.SetValue(Canvas.LeftProperty, 0) ' left offset (X)

        ' setting up a rectangle shape with stroke
        Dim rectangle1 = New Rectangle
        rectangle1.Stroke = New SolidColorBrush(Colors.Black)
        rectangle1.StrokeThickness = 3
        rectangle1.Width = myCanvas.Width
        rectangle1.Height = myCanvas.Height
        rectangle1.SetValue(Canvas.TopProperty, 0) ' setting offset from top
        rectangle1.SetValue(Canvas.LeftProperty, 0) ' setting offset from left

        ' setting up a polygon shape with points
        Dim polygon1 = New Polygon
        polygon1.Fill = New SolidColorBrush(Colors.MediumVioletRed)
        Dim points = New PointCollection
        points.Add(New Point(10, 50))
        points.Add(New Point(30, 90))
        points.Add(New Point(60, 60))
        polygon1.Points = points
        polygon1.SetValue(Canvas.TopProperty, 0)
        polygon1.SetValue(Canvas.LeftProperty, 100)
        polygon1.SetValue(Canvas.ZIndexProperty, 100)

        ' setting up a simple line shape
        Dim line1 = New Line
        line1.Stroke = New SolidColorBrush(Colors.ForestGreen)
        line1.StrokeThickness = 3
        line1.X1 = 50
        line1.Y1 = 50
        line1.X2 = 150
        line1.Y2 = 150

        ' using a new class (emulating old desktop classic behaviour)
        Dim paper As New paperNB(myCanvas) ' custom class
        ' this looks almost the same as before
        paper.DrawEllipse(New SolidColorBrush(Colors.DarkRed), 10, 10, 200, 100)

        ' attaching the shapes to a UI element, in this case a canvas
        myCanvas.Children.Add(ellipse1)
        myCanvas.Children.Add(rectangle1)
        myCanvas.Children.Add(polygon1)
        myCanvas.Children.Add(line1)


    End Sub

    ''' <summary>
    ''' A simple asynchronous call to a popup messagedialog
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub MessageBtn_Click(sender As Object, e As RoutedEventArgs) Handles messageBtn.Click
        Dim myContentDialogue = New ContentDialog()
        myContentDialogue.Title = "No wifi connection"
        myContentDialogue.Content = "Check connection and try again."
        myContentDialogue.SecondaryButtonText = "Secondary"
        myContentDialogue.PrimaryButtonText = "Primary"

        Await myContentDialogue.ShowAsync()
    End Sub

    Private Async Sub TextBtn_Click(sender As Object, e As RoutedEventArgs) Handles textBtn.Click
        Dim myContentDialogue = New ContentDialog()
        myContentDialogue.Title = "This what you entered"
        myContentDialogue.Content = "Your name is: " & nameTB.Text

        myContentDialogue.PrimaryButtonText = "Yes"
        myContentDialogue.SecondaryButtonText = "No"

        ' show dialogue and save returned button for further actions
        Dim result As ContentDialogResult = Await myContentDialogue.ShowAsync()

        If result = ContentDialogResult.Primary Then
            nameTB.Text = "Great!"
        Else
            nameTB.Text = "Name was not accepted"
        End If

    End Sub

    Private Sub CheckBx_Checked(sender As Object, e As RoutedEventArgs) Handles checkBx.Checked
        ' set radio button text accordingly
        checkBx.Content = "Disable all"

        ' do the actual "hiding"/"unhiding"
        nameTB.IsEnabled = False
        messageBtn.IsEnabled = False
        shapeBtn.IsEnabled = False
        textBtn.IsEnabled = False
    End Sub

    Private Sub checkBx_Unchecked(sender As Object, e As RoutedEventArgs) Handles checkBx.Unchecked
        ' set radio button text accordingly
        checkBx.Content = "Enable all"

        ' do the actual "hiding"/"unhiding"
        nameTB.IsEnabled = True
        messageBtn.IsEnabled = True
        shapeBtn.IsEnabled = True
        textBtn.IsEnabled = True
    End Sub
End Class
