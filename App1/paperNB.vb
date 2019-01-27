Imports Windows.UI.Xaml.Shapes
Imports Windows.UI ' includes e.g. Colors

Public Class paperNB
    Private myCanvas As Canvas ' to connect shapes later to a specific canvas

    Public Sub New(newCanvas As Canvas)
        myCanvas = newCanvas
    End Sub

    Public Sub DrawEllipse(pen As SolidColorBrush, x As Integer, y As Integer, width As Integer, height As Integer)
        ' setting up an ellipse shape with fill
        Dim ellipse1 = New Ellipse
        ellipse1.Fill = pen
        ellipse1.Width = width ' bounding rectangle's width
        ellipse1.Height = height ' bounding rectangle's height
        ellipse1.SetValue(Canvas.TopProperty, x) ' top offset (Y)
        ellipse1.SetValue(Canvas.LeftProperty, y) ' left offset (X)
        myCanvas.Children.Add(ellipse1)
    End Sub
End Class
