Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System, System.IO, System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Imaging

MustInherit Class Theme
    Inherits ContainerControl

#Region " Initialization "

    Protected G As Graphics
    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
    End Sub

    Private ParentIsForm As Boolean
    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        Dock = DockStyle.Fill
        ParentIsForm = TypeOf Parent Is Form
        If ParentIsForm Then
            If Not _TransparencyKey = Color.Empty Then ParentForm.TransparencyKey = _TransparencyKey
            ParentForm.FormBorderStyle = FormBorderStyle.None
        End If
        MyBase.OnHandleCreated(e)
    End Sub

    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal v As String)
            MyBase.Text = v
            Invalidate()
        End Set
    End Property
#End Region

#Region " Sizing and Movement "

    Private _Resizable As Boolean = True
    Property Resizable() As Boolean
        Get
            Return _Resizable
        End Get
        Set(ByVal value As Boolean)
            _Resizable = value
        End Set
    End Property

    Private _MoveHeight As Integer = 24
    Property MoveHeight() As Integer
        Get
            Return _MoveHeight
        End Get
        Set(ByVal v As Integer)
            _MoveHeight = v
            Header = New Rectangle(7, 7, Width - 14, _MoveHeight - 7)
        End Set
    End Property

    Private Flag As IntPtr
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If Not e.Button = MouseButtons.Left Then Return
        If ParentIsForm Then If ParentForm.WindowState = FormWindowState.Maximized Then Return

        If Header.Contains(e.Location) Then
            Flag = New IntPtr(2)
        ElseIf Current.Position = 0 Or Not _Resizable Then
            Return
        Else
            Flag = New IntPtr(Current.Position)
        End If

        Capture = False
        DefWndProc(Message.Create(Parent.Handle, 161, Flag, Nothing))

        MyBase.OnMouseDown(e)
    End Sub
    Private Structure Pointer
        ReadOnly Cursor As Cursor, Position As Byte
        Sub New(ByVal c As Cursor, ByVal p As Byte)
            Cursor = c
            Position = p
        End Sub
    End Structure

    Private F1, F2, F3, F4 As Boolean, PTC As Point
    Private Function GetPointer() As Pointer
        PTC = PointToClient(MousePosition)
        F1 = PTC.X < 7
        F2 = PTC.X > Width - 7
        F3 = PTC.Y < 7
        F4 = PTC.Y > Height - 7

        If F1 And F3 Then Return New Pointer(Cursors.SizeNWSE, 13)
        If F1 And F4 Then Return New Pointer(Cursors.SizeNESW, 16)
        If F2 And F3 Then Return New Pointer(Cursors.SizeNESW, 14)
        If F2 And F4 Then Return New Pointer(Cursors.SizeNWSE, 17)
        If F1 Then Return New Pointer(Cursors.SizeWE, 10)
        If F2 Then Return New Pointer(Cursors.SizeWE, 11)
        If F3 Then Return New Pointer(Cursors.SizeNS, 12)
        If F4 Then Return New Pointer(Cursors.SizeNS, 15)
        Return New Pointer(Cursors.Default, 0)
    End Function

    Private Current, Pending As Pointer
    Private Sub SetCurrent()
        Pending = GetPointer()
        If Current.Position = Pending.Position Then Return
        Current = GetPointer()
        Cursor = Current.Cursor
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If _Resizable Then SetCurrent()
        MyBase.OnMouseMove(e)
    End Sub

    Protected Header As Rectangle
    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        Header = New Rectangle(7, 7, Width - 14, _MoveHeight - 7)
        Invalidate()
        MyBase.OnSizeChanged(e)
    End Sub

#End Region

#Region " Convienence "

    MustOverride Sub PaintHook()
    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        G = e.Graphics
        PaintHook()
    End Sub

    Private _TransparencyKey As Color
    Property TransparencyKey() As Color
        Get
            Return _TransparencyKey
        End Get
        Set(ByVal v As Color)
            _TransparencyKey = v
            Invalidate()
        End Set
    End Property

    Private _Image As Image
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
            Invalidate()
        End Set
    End Property
    ReadOnly Property ImageWidth() As Integer
        Get
            If _Image Is Nothing Then Return 0
            Return _Image.Width
        End Get
    End Property

    Private _Size As Size
    Private _Rectangle As Rectangle
    Private _Gradient As LinearGradientBrush
    Private _Brush As SolidBrush

    Protected Sub DrawCorners(ByVal c As Color, ByVal rect As Rectangle)
        _Brush = New SolidBrush(c)
        G.FillRectangle(_Brush, rect.X, rect.Y, 1, 1)
        G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y, 1, 1)
        G.FillRectangle(_Brush, rect.X, rect.Y + (rect.Height - 1), 1, 1)
        G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), 1, 1)
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal p2 As Pen, ByVal rect As Rectangle)
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3)
    End Sub

    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer)
        DrawText(a, c, x, 0)
    End Sub
    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        If String.IsNullOrEmpty(Text) Then Return
        _Size = G.MeasureString(Text, Font).ToSize
        _Brush = New SolidBrush(c)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawString(Text, Font, _Brush, x, _MoveHeight \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, _MoveHeight \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawString(Text, Font, _Brush, Width \ 2 - _Size.Width \ 2 + x, _MoveHeight \ 2 - _Size.Height \ 2 + y)
        End Select
    End Sub

    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer)
        DrawIcon(a, x, 0)
    End Sub
    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If _Image Is Nothing Then Return
        Select Case a
            Case HorizontalAlignment.Left
                G.DrawImage(_Image, x, _MoveHeight \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawImage(_Image, Width - _Image.Width - x, _MoveHeight \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawImage(_Image, Width \ 2 - _Image.Width \ 2, _MoveHeight \ 2 - _Image.Height \ 2)
        End Select
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        _Rectangle = New Rectangle(x, y, width, height)
        _Gradient = New LinearGradientBrush(_Rectangle, c1, c2, angle)
        G.FillRectangle(_Gradient, _Rectangle)
    End Sub

#End Region

End Class
MustInherit Class ThemeControl
    Inherits Control

#Region " Initialization "

    Protected G As Graphics, B As Bitmap
    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
        B = New Bitmap(1, 1)
        G = Graphics.FromImage(B)
    End Sub

    Sub AllowTransparent()
        SetStyle(ControlStyles.Opaque, False)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal v As String)
            MyBase.Text = v
            Invalidate()
        End Set
    End Property
#End Region

#Region " Mouse Handling "

    Protected Enum State As Byte
        MouseNone = 0
        MouseOver = 1
        MouseDown = 2
    End Enum

    Protected MouseState As State
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        ChangeMouseState(State.MouseNone)
        MyBase.OnMouseLeave(e)
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        ChangeMouseState(State.MouseOver)
        MyBase.OnMouseEnter(e)
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ChangeMouseState(State.MouseOver)
        MyBase.OnMouseUp(e)
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then ChangeMouseState(State.MouseDown)
        MyBase.OnMouseDown(e)
    End Sub

    Private Sub ChangeMouseState(ByVal e As State)
        MouseState = e
        Invalidate()
    End Sub

#End Region

#Region " Convienence "

    MustOverride Sub PaintHook()
    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        PaintHook()
        e.Graphics.DrawImage(B, 0, 0)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Not Width = 0 AndAlso Not Height = 0 Then
            B = New Bitmap(Width, Height)
            G = Graphics.FromImage(B)
            Invalidate()
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    Private _NoRounding As Boolean
    Property NoRounding() As Boolean
        Get
            Return _NoRounding
        End Get
        Set(ByVal v As Boolean)
            _NoRounding = v
            Invalidate()
        End Set
    End Property

    Private _Image As Image
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
            Invalidate()
        End Set
    End Property
    ReadOnly Property ImageWidth() As Integer
        Get
            If _Image Is Nothing Then Return 0
            Return _Image.Width
        End Get
    End Property
    ReadOnly Property ImageTop() As Integer
        Get
            If _Image Is Nothing Then Return 0
            Return Height \ 2 - _Image.Height \ 2
        End Get
    End Property

    Private _Size As Size
    Private _Rectangle As Rectangle
    Private _Gradient As LinearGradientBrush
    Private _Brush As SolidBrush

    Protected Sub DrawCorners(ByVal c As Color, ByVal rect As Rectangle)
        If _NoRounding Then Return

        B.SetPixel(rect.X, rect.Y, c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c)
        B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c)
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal p2 As Pen, ByVal rect As Rectangle)
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3)
    End Sub

    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer)
        DrawText(a, c, x, 0)
    End Sub
    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        If String.IsNullOrEmpty(Text) Then Return
        _Size = G.MeasureString(Text, Font).ToSize
        _Brush = New SolidBrush(c)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawString(Text, Font, _Brush, x, Height \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, Height \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawString(Text, Font, _Brush, Width \ 2 - _Size.Width \ 2 + x, Height \ 2 - _Size.Height \ 2 + y)
        End Select
    End Sub

    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer)
        DrawIcon(a, x, 0)
    End Sub
    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If _Image Is Nothing Then Return
        Select Case a
            Case HorizontalAlignment.Left
                G.DrawImage(_Image, x, Height \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawImage(_Image, Width - _Image.Width - x, Height \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawImage(_Image, Width \ 2 - _Image.Width \ 2, Height \ 2 - _Image.Height \ 2)
        End Select
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        _Rectangle = New Rectangle(x, y, width, height)
        _Gradient = New LinearGradientBrush(_Rectangle, c1, c2, angle)
        G.FillRectangle(_Gradient, _Rectangle)
    End Sub
#End Region

End Class
MustInherit Class ThemeContainerControl
    Inherits ContainerControl

#Region " Initialization "

    Protected G As Graphics, B As Bitmap
    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
        B = New Bitmap(1, 1)
        G = Graphics.FromImage(B)
    End Sub

    Sub AllowTransparent()
        SetStyle(ControlStyles.Opaque, False)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

#End Region

#Region " Convienence "

    MustOverride Sub PaintHook()
    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        PaintHook()
        e.Graphics.DrawImage(B, 0, 0)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Not Width = 0 AndAlso Not Height = 0 Then
            B = New Bitmap(Width, Height)
            G = Graphics.FromImage(B)
            Invalidate()
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    Private _NoRounding As Boolean
    Property NoRounding() As Boolean
        Get
            Return _NoRounding
        End Get
        Set(ByVal v As Boolean)
            _NoRounding = v
            Invalidate()
        End Set
    End Property

    Private _Rectangle As Rectangle
    Private _Gradient As LinearGradientBrush

    Protected Sub DrawCorners(ByVal c As Color, ByVal rect As Rectangle)
        If _NoRounding Then Return
        B.SetPixel(rect.X, rect.Y, c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c)
        B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c)
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal p2 As Pen, ByVal rect As Rectangle)
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3)
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        _Rectangle = New Rectangle(x, y, width, height)
        _Gradient = New LinearGradientBrush(_Rectangle, c1, c2, angle)
        G.FillRectangle(_Gradient, _Rectangle)
    End Sub
#End Region

End Class
Class Pigment
    Property Name As String = "Pigment"
    Property Value As Color = Color.Black

    Sub New()
    End Sub

    Sub New(ByVal n As String, ByVal v As Color)
        Name = n
        Value = v
    End Sub

    Sub New(ByVal n As String, ByVal a As Byte, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        Name = n
        Value = Color.FromArgb(a, r, g, b)
    End Sub

    Sub New(ByVal n As String, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        Name = n
        Value = Color.FromArgb(r, g, b)
    End Sub
End Class
Class Draw
    Shared Sub Gradient(ByVal g As Graphics, ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim R As New Rectangle(x, y, width, height)
        Using T As New LinearGradientBrush(R, c1, c2, LinearGradientMode.Vertical)
            g.FillRectangle(T, R)
        End Using
    End Sub
    Shared Sub Blend(ByVal g As Graphics, ByVal c1 As Color, ByVal c2 As Color, ByVal c3 As Color, ByVal c As Single, ByVal d As Integer, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim V As New ColorBlend(3)
        V.Colors = New Color() {c1, c2, c3}
        V.Positions = New Single() {0, c, 1}
        Dim R As New Rectangle(x, y, width, height)
        Using T As New LinearGradientBrush(R, c1, c1, CType(d, LinearGradientMode))
            T.InterpolationColors = V : g.FillRectangle(T, R)
        End Using
    End Sub
End Class

MustInherit Class ThemeContainer154
    Inherits ContainerControl

#Region " Initialization "

    Protected G As Graphics, B As Bitmap

    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)

        _ImageSize = Size.Empty
        Font = New Font("Verdana", 8S)

        MeasureBitmap = New Bitmap(1, 1)
        MeasureGraphics = Graphics.FromImage(MeasureBitmap)

        DrawRadialPath = New GraphicsPath

        InvalidateCustimization()
    End Sub

    Protected NotOverridable Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        If DoneCreation Then InitializeMessages()

        InvalidateCustimization()
        ColorHook()

        If Not _LockWidth = 0 Then Width = _LockWidth
        If Not _LockHeight = 0 Then Height = _LockHeight
        If Not _ControlMode Then MyBase.Dock = DockStyle.Fill

        Transparent = _Transparent
        If _Transparent AndAlso _BackColor Then BackColor = Color.Transparent

        MyBase.OnHandleCreated(e)
    End Sub

    Private DoneCreation As Boolean
    Protected NotOverridable Overrides Sub OnParentChanged(ByVal e As EventArgs)
        MyBase.OnParentChanged(e)

        If Parent Is Nothing Then Return
        _IsParentForm = TypeOf Parent Is Form

        If Not _ControlMode Then
            InitializeMessages()

            If _IsParentForm Then
                ParentForm.FormBorderStyle = _BorderStyle
                ParentForm.TransparencyKey = _TransparencyKey

                If Not DesignMode Then
                    AddHandler ParentForm.Shown, AddressOf FormShown
                End If
            End If

            Parent.BackColor = BackColor
        End If

        OnCreation()
        DoneCreation = True
        InvalidateTimer()
    End Sub

#End Region

    Private Sub DoAnimation(ByVal i As Boolean)
        OnAnimation()
        If i Then Invalidate()
    End Sub

    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return

        If _Transparent AndAlso _ControlMode Then
            PaintHook()
            e.Graphics.DrawImage(B, 0, 0)
        Else
            G = e.Graphics
            PaintHook()
        End If
    End Sub

    Protected Overrides Sub OnHandleDestroyed(ByVal e As EventArgs)
        RemoveAnimationCallback(AddressOf DoAnimation)
        MyBase.OnHandleDestroyed(e)
    End Sub

    Private HasShown As Boolean
    Private Sub FormShown(ByVal sender As Object, ByVal e As EventArgs)
        If _ControlMode OrElse HasShown Then Return

        If _StartPosition = FormStartPosition.CenterParent OrElse _StartPosition = FormStartPosition.CenterScreen Then
            Dim SB As Rectangle = Screen.PrimaryScreen.Bounds
            Dim CB As Rectangle = ParentForm.Bounds
            ParentForm.Location = New Point(SB.Width \ 2 - CB.Width \ 2, SB.Height \ 2 - CB.Width \ 2)
        End If

        HasShown = True
    End Sub


#Region " Size Handling "

    Private Frame As Rectangle
    Protected NotOverridable Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If _Movable AndAlso Not _ControlMode Then
            Frame = New Rectangle(7, 7, Width - 14, _Header - 7)
        End If

        InvalidateBitmap()
        Invalidate()

        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub SetBoundsCore(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal specified As BoundsSpecified)
        If Not _LockWidth = 0 Then width = _LockWidth
        If Not _LockHeight = 0 Then height = _LockHeight
        MyBase.SetBoundsCore(x, y, width, height, specified)
    End Sub

#End Region

#Region " State Handling "

    Protected State As MouseState
    Private Sub SetState(ByVal current As MouseState)
        State = current
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized) Then
            If _Sizable AndAlso Not _ControlMode Then InvalidateMouse()
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
        If Enabled Then SetState(MouseState.None) Else SetState(MouseState.Block)
        MyBase.OnEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        SetState(MouseState.Over)
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        SetState(MouseState.Over)
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        SetState(MouseState.None)

        If GetChildAtPoint(PointToClient(MousePosition)) IsNot Nothing Then
            If _Sizable AndAlso Not _ControlMode Then
                Cursor = Cursors.Default
                Previous = 0
            End If
        End If

        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then SetState(MouseState.Down)
        If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized OrElse _ControlMode) Then
            If _Movable AndAlso Frame.Contains(e.Location) Then
                Capture = False
                WM_LMBUTTONDOWN = True
                DefWndProc(Messages(0))
            ElseIf _Sizable AndAlso Not Previous = 0 Then
                Capture = False
                WM_LMBUTTONDOWN = True
                DefWndProc(Messages(Previous))
            End If
        End If

        MyBase.OnMouseDown(e)
    End Sub

    'moving function and aero shake simulation
    Private WM_LMBUTTONDOWN As Boolean
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        If m.Msg = 515 Then
            If Cursor.Position.X > dscWindow.Location.X And Cursor.Position.X < dscWindow.Location.X + dscWindow.Width - dscWindow.ControlBox1.Width And Cursor.Position.Y > dscWindow.Location.Y And Cursor.Position.Y < dscWindow.Location.Y + 26 Then
                If FindForm.WindowState = FormWindowState.Maximized Then
                    dscWindow.previouswinsize = FormWindowState.Maximized
                    FindForm.WindowState = FormWindowState.Normal
                    elementsplacing()
                Else
                    dscWindow.previouswinsize = FormWindowState.Normal
                    FindForm.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                    FindForm.WindowState = FormWindowState.Maximized
                    elementsplacing()
                End If
            End If
        End If

        If WM_LMBUTTONDOWN AndAlso m.Msg = 513 Then
            'WM_LMBUTTONDOWN = False

            SetState(MouseState.Over)
            If Not _SmartBounds Then Return

            If IsParentMdi Then
                CorrectBounds(New Rectangle(Point.Empty, Parent.Parent.Size))
            Else
                If settingswindow.aerosnapcheck.Checked = True Then
                    If Cursor.Position.X = 0 Then
                        dscWindow.windowwasdocked = 1
                        dscWindow.widthbeforedocking = dscWindow.Width
                        dscWindow.heightbeforedocking = dscWindow.Height
                        dscWindow.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                        dscWindow.Height = Screen.PrimaryScreen.WorkingArea.Height
                        dscWindow.Width = Screen.PrimaryScreen.WorkingArea.Width / 2
                        dscWindow.Location = New Point(0, 0)
                    ElseIf Cursor.Position.X = Screen.PrimaryScreen.WorkingArea.Width - 1 Then
                        dscWindow.windowwasdocked = 1
                        dscWindow.widthbeforedocking = dscWindow.Width
                        dscWindow.heightbeforedocking = dscWindow.Height
                        dscWindow.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                        dscWindow.Height = Screen.PrimaryScreen.WorkingArea.Height
                        dscWindow.Width = Screen.PrimaryScreen.WorkingArea.Width / 2
                        dscWindow.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width / 2, 0)
                    ElseIf Cursor.Position.Y = 0 Then
                        dscWindow.windowwasdocked = 1
                        dscWindow.widthbeforedocking = dscWindow.Width
                        dscWindow.heightbeforedocking = dscWindow.Height
                        dscWindow.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                        dscWindow.Height = Screen.PrimaryScreen.WorkingArea.Height
                        dscWindow.Width = Screen.PrimaryScreen.WorkingArea.Width
                        dscWindow.Location = New Point(0, 0)
                    ElseIf dscWindow.windowwasdocked = 1 Then
                        dscWindow.windowwasdocked = 0
                        dscWindow.Width = dscWindow.widthbeforedocking
                        dscWindow.Height = dscWindow.heightbeforedocking
                    End If
                End If
                'CorrectBounds(Screen.FromControl(Parent).WorkingArea)
            End If
        End If
    End Sub

    Private GetIndexPoint As Point
    Private B1, B2, B3, B4 As Boolean
    Private Function GetIndex() As Integer
        GetIndexPoint = PointToClient(MousePosition)
        B1 = GetIndexPoint.X < 7
        B2 = GetIndexPoint.X > Width - 7
        B3 = GetIndexPoint.Y < 7
        B4 = GetIndexPoint.Y > Height - 7

        If B1 AndAlso B3 Then Return 4
        If B1 AndAlso B4 Then Return 7
        If B2 AndAlso B3 Then Return 5
        If B2 AndAlso B4 Then Return 8
        If B1 Then Return 1
        If B2 Then Return 2
        If B3 Then Return 3
        If B4 Then Return 6
        Return 0
    End Function

    Private Current, Previous As Integer
    Private Sub InvalidateMouse()
        Current = GetIndex()
        If Current = Previous Then Return

        Previous = Current
        Select Case Previous
            Case 0
                Cursor = Cursors.Default
            Case 1, 2
                Cursor = Cursors.SizeWE
            Case 3, 6
                Cursor = Cursors.SizeNS
            Case 4, 8
                Cursor = Cursors.SizeNWSE
            Case 5, 7
                Cursor = Cursors.SizeNESW
        End Select
    End Sub

    Private Messages(8) As Message
    Private Sub InitializeMessages()
        Messages(0) = Message.Create(Parent.Handle, 161, New IntPtr(2), IntPtr.Zero)
        For I As Integer = 1 To 8
            Messages(I) = Message.Create(Parent.Handle, 161, New IntPtr(I + 9), IntPtr.Zero)
        Next
    End Sub

    Private Sub CorrectBounds(ByVal bounds As Rectangle)
        If Parent.Width > bounds.Width Then Parent.Width = bounds.Width
        If Parent.Height > bounds.Height Then Parent.Height = bounds.Height

        Dim X As Integer = Parent.Location.X
        Dim Y As Integer = Parent.Location.Y

        If X < bounds.X Then X = bounds.X
        If Y < bounds.Y Then Y = bounds.Y

        Dim Width As Integer = bounds.X + bounds.Width
        Dim Height As Integer = bounds.Y + bounds.Height

        If X + Parent.Width > Width Then X = Width - Parent.Width
        If Y + Parent.Height > Height Then Y = Height - Parent.Height

        Parent.Location = New Point(X, Y)
    End Sub

#End Region


#Region " Base Properties "

    Overrides Property Dock As DockStyle
        Get
            Return MyBase.Dock
        End Get
        Set(ByVal value As DockStyle)
            If Not _ControlMode Then Return
            MyBase.Dock = value
        End Set
    End Property

    Private _BackColor As Boolean
    <Category("Misc")> _
    Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            If value = MyBase.BackColor Then Return

            If Not IsHandleCreated AndAlso _ControlMode AndAlso value = Color.Transparent Then
                _BackColor = True
                Return
            End If

            MyBase.BackColor = value
            If Parent IsNot Nothing Then
                If Not _ControlMode Then Parent.BackColor = value
                ColorHook()
            End If
        End Set
    End Property

    Overrides Property MinimumSize As Size
        Get
            Return MyBase.MinimumSize
        End Get
        Set(ByVal value As Size)
            MyBase.MinimumSize = value
            If Parent IsNot Nothing Then Parent.MinimumSize = value
        End Set
    End Property

    Overrides Property MaximumSize As Size
        Get
            Return MyBase.MaximumSize
        End Get
        Set(ByVal value As Size)
            MyBase.MaximumSize = value
            If Parent IsNot Nothing Then Parent.MaximumSize = value
        End Set
    End Property

    Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            Invalidate()
        End Set
    End Property

    Overrides Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            Invalidate()
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Overrides Property ForeColor() As Color
        Get
            Return Color.Empty
        End Get
        Set(ByVal value As Color)
        End Set
    End Property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Overrides Property BackgroundImage() As Image
        Get
            Return Nothing
        End Get
        Set(ByVal value As Image)
        End Set
    End Property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Overrides Property BackgroundImageLayout() As ImageLayout
        Get
            Return ImageLayout.None
        End Get
        Set(ByVal value As ImageLayout)
        End Set
    End Property

#End Region

#Region " Public Properties "

    Private _SmartBounds As Boolean = True
    Property SmartBounds() As Boolean
        Get
            Return _SmartBounds
        End Get
        Set(ByVal value As Boolean)
            _SmartBounds = value
        End Set
    End Property

    Private _Movable As Boolean = True
    Property Movable() As Boolean
        Get
            Return _Movable
        End Get
        Set(ByVal value As Boolean)
            _Movable = value
        End Set
    End Property

    Private _Sizable As Boolean = True
    Property Sizable() As Boolean
        Get
            Return _Sizable
        End Get
        Set(ByVal value As Boolean)
            _Sizable = value
        End Set
    End Property

    Private _TransparencyKey As Color
    Property TransparencyKey() As Color
        Get
            If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.TransparencyKey Else Return _TransparencyKey
        End Get
        Set(ByVal value As Color)
            If value = _TransparencyKey Then Return
            _TransparencyKey = value

            If _IsParentForm AndAlso Not _ControlMode Then
                ParentForm.TransparencyKey = value
                ColorHook()
            End If
        End Set
    End Property

    Private _BorderStyle As FormBorderStyle
    Property BorderStyle() As FormBorderStyle
        Get
            If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.FormBorderStyle Else Return _BorderStyle
        End Get
        Set(ByVal value As FormBorderStyle)
            _BorderStyle = value

            If _IsParentForm AndAlso Not _ControlMode Then
                ParentForm.FormBorderStyle = value

                If Not value = FormBorderStyle.None Then
                    Movable = False
                    Sizable = False
                End If
            End If
        End Set
    End Property

    Private _StartPosition As FormStartPosition
    Property StartPosition As FormStartPosition
        Get
            If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.StartPosition Else Return _StartPosition
        End Get
        Set(ByVal value As FormStartPosition)
            _StartPosition = value

            If _IsParentForm AndAlso Not _ControlMode Then
                ParentForm.StartPosition = value
            End If
        End Set
    End Property

    Private _NoRounding As Boolean
    Property NoRounding() As Boolean
        Get
            Return _NoRounding
        End Get
        Set(ByVal v As Boolean)
            _NoRounding = v
            Invalidate()
        End Set
    End Property

    Private _Image As Image
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            If value Is Nothing Then _ImageSize = Size.Empty Else _ImageSize = value.Size

            _Image = value
            Invalidate()
        End Set
    End Property

    Private Items As New Dictionary(Of String, Color)
    Property Colors() As Bloom()
        Get
            Dim T As New List(Of Bloom)
            Dim E As Dictionary(Of String, Color).Enumerator = Items.GetEnumerator

            While E.MoveNext
                T.Add(New Bloom(E.Current.Key, E.Current.Value))
            End While

            Return T.ToArray
        End Get
        Set(ByVal value As Bloom())
            For Each B As Bloom In value
                If Items.ContainsKey(B.Name) Then Items(B.Name) = B.Value
            Next

            InvalidateCustimization()
            ColorHook()
            Invalidate()
        End Set
    End Property

    Private _Customization As String
    Property Customization() As String
        Get
            Return _Customization
        End Get
        Set(ByVal value As String)
            If value = _Customization Then Return

            Dim Data As Byte()
            Dim Items As Bloom() = Colors

            Try
                Data = Convert.FromBase64String(value)
                For I As Integer = 0 To Items.Length - 1
                    Items(I).Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4))
                Next
            Catch
                Return
            End Try

            _Customization = value

            Colors = Items
            ColorHook()
            Invalidate()
        End Set
    End Property

    Private _Transparent As Boolean
    Property Transparent() As Boolean
        Get
            Return _Transparent
        End Get
        Set(ByVal value As Boolean)
            _Transparent = value
            If Not (IsHandleCreated OrElse _ControlMode) Then Return

            If Not value AndAlso Not BackColor.A = 255 Then
                Throw New Exception("Unable to change value to false while a transparent BackColor is in use.")
            End If

            SetStyle(ControlStyles.Opaque, Not value)
            SetStyle(ControlStyles.SupportsTransparentBackColor, value)

            InvalidateBitmap()
            Invalidate()
        End Set
    End Property

#End Region

#Region " Private Properties "

    Private _ImageSize As Size
    Protected ReadOnly Property ImageSize() As Size
        Get
            Return _ImageSize
        End Get
    End Property

    Private _IsParentForm As Boolean
    Protected ReadOnly Property IsParentForm As Boolean
        Get
            Return _IsParentForm
        End Get
    End Property

    Protected ReadOnly Property IsParentMdi As Boolean
        Get
            If Parent Is Nothing Then Return False
            Return Parent.Parent IsNot Nothing
        End Get
    End Property

    Private _LockWidth As Integer
    Protected Property LockWidth() As Integer
        Get
            Return _LockWidth
        End Get
        Set(ByVal value As Integer)
            _LockWidth = value
            If Not LockWidth = 0 AndAlso IsHandleCreated Then Width = LockWidth
        End Set
    End Property

    Private _LockHeight As Integer
    Protected Property LockHeight() As Integer
        Get
            Return _LockHeight
        End Get
        Set(ByVal value As Integer)
            _LockHeight = value
            If Not LockHeight = 0 AndAlso IsHandleCreated Then Height = LockHeight
        End Set
    End Property

    Private _Header As Integer = 24
    Protected Property Header() As Integer
        Get
            Return _Header
        End Get
        Set(ByVal v As Integer)
            _Header = v

            If Not _ControlMode Then
                Frame = New Rectangle(7, 7, Width - 14, v - 7)
                Invalidate()
            End If
        End Set
    End Property

    Private _ControlMode As Boolean
    Protected Property ControlMode() As Boolean
        Get
            Return _ControlMode
        End Get
        Set(ByVal v As Boolean)
            _ControlMode = v

            Transparent = _Transparent
            If _Transparent AndAlso _BackColor Then BackColor = Color.Transparent

            InvalidateBitmap()
            Invalidate()
        End Set
    End Property

    Private _IsAnimated As Boolean
    Protected Property IsAnimated() As Boolean
        Get
            Return _IsAnimated
        End Get
        Set(ByVal value As Boolean)
            _IsAnimated = value
            InvalidateTimer()
        End Set
    End Property

#End Region


#Region " Property Helpers "

    Protected Function GetPen(ByVal name As String) As Pen
        Return New Pen(Items(name))
    End Function
    Protected Function GetPen(ByVal name As String, ByVal width As Single) As Pen
        Return New Pen(Items(name), width)
    End Function

    Protected Function GetBrush(ByVal name As String) As SolidBrush
        Return New SolidBrush(Items(name))
    End Function

    Protected Function GetColor(ByVal name As String) As Color
        Return Items(name)
    End Function

    Protected Sub SetColor(ByVal name As String, ByVal value As Color)
        If Items.ContainsKey(name) Then Items(name) = value Else Items.Add(name, value)
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        SetColor(name, Color.FromArgb(r, g, b))
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal a As Byte, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        SetColor(name, Color.FromArgb(a, r, g, b))
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal a As Byte, ByVal value As Color)
        SetColor(name, Color.FromArgb(a, value))
    End Sub

    Private Sub InvalidateBitmap()
        If _Transparent AndAlso _ControlMode Then
            If Width = 0 OrElse Height = 0 Then Return
            B = New Bitmap(Width, Height, PixelFormat.Format32bppPArgb)
            G = Graphics.FromImage(B)
        Else
            G = Nothing
            B = Nothing
        End If
    End Sub

    Private Sub InvalidateCustimization()
        Dim M As New MemoryStream(Items.Count * 4)

        For Each B As Bloom In Colors
            M.Write(BitConverter.GetBytes(B.Value.ToArgb), 0, 4)
        Next

        M.Close()
        _Customization = Convert.ToBase64String(M.ToArray)
    End Sub

    Private Sub InvalidateTimer()
        If DesignMode OrElse Not DoneCreation Then Return

        If _IsAnimated Then
            AddAnimationCallback(AddressOf DoAnimation)
        Else
            RemoveAnimationCallback(AddressOf DoAnimation)
        End If
    End Sub

#End Region


#Region " User Hooks "

    Protected MustOverride Sub ColorHook()
    Protected MustOverride Sub PaintHook()

    Protected Overridable Sub OnCreation()
    End Sub

    Protected Overridable Sub OnAnimation()
    End Sub

#End Region


#Region " Offset "

    Private OffsetReturnRectangle As Rectangle
    Protected Function Offset(ByVal r As Rectangle, ByVal amount As Integer) As Rectangle
        OffsetReturnRectangle = New Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2))
        Return OffsetReturnRectangle
    End Function

    Private OffsetReturnSize As Size
    Protected Function Offset(ByVal s As Size, ByVal amount As Integer) As Size
        OffsetReturnSize = New Size(s.Width + amount, s.Height + amount)
        Return OffsetReturnSize
    End Function

    Private OffsetReturnPoint As Point
    Protected Function Offset(ByVal p As Point, ByVal amount As Integer) As Point
        OffsetReturnPoint = New Point(p.X + amount, p.Y + amount)
        Return OffsetReturnPoint
    End Function

#End Region

#Region " Center "

    Private CenterReturn As Point

    Protected Function Center(ByVal p As Rectangle, ByVal c As Rectangle) As Point
        CenterReturn = New Point((p.Width \ 2 - c.Width \ 2) + p.X + c.X, (p.Height \ 2 - c.Height \ 2) + p.Y + c.Y)
        Return CenterReturn
    End Function
    Protected Function Center(ByVal p As Rectangle, ByVal c As Size) As Point
        CenterReturn = New Point((p.Width \ 2 - c.Width \ 2) + p.X, (p.Height \ 2 - c.Height \ 2) + p.Y)
        Return CenterReturn
    End Function

    Protected Function Center(ByVal child As Rectangle) As Point
        Return Center(Width, Height, child.Width, child.Height)
    End Function
    Protected Function Center(ByVal child As Size) As Point
        Return Center(Width, Height, child.Width, child.Height)
    End Function
    Protected Function Center(ByVal childWidth As Integer, ByVal childHeight As Integer) As Point
        Return Center(Width, Height, childWidth, childHeight)
    End Function

    Protected Function Center(ByVal p As Size, ByVal c As Size) As Point
        Return Center(p.Width, p.Height, c.Width, c.Height)
    End Function

    Protected Function Center(ByVal pWidth As Integer, ByVal pHeight As Integer, ByVal cWidth As Integer, ByVal cHeight As Integer) As Point
        CenterReturn = New Point(pWidth \ 2 - cWidth \ 2, pHeight \ 2 - cHeight \ 2)
        Return CenterReturn
    End Function

#End Region

#Region " Measure "

    Private MeasureBitmap As Bitmap
    Private MeasureGraphics As Graphics

    Protected Function Measure() As Size
        SyncLock MeasureGraphics
            Return MeasureGraphics.MeasureString(Text, Font, Width).ToSize
        End SyncLock
    End Function
    Protected Function Measure(ByVal text As String) As Size
        SyncLock MeasureGraphics
            Return MeasureGraphics.MeasureString(text, Font, Width).ToSize
        End SyncLock
    End Function

#End Region


#Region " DrawPixel "

    Private DrawPixelBrush As SolidBrush

    Protected Sub DrawPixel(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer)
        If _Transparent Then
            B.SetPixel(x, y, c1)
        Else
            DrawPixelBrush = New SolidBrush(c1)
            G.FillRectangle(DrawPixelBrush, x, y, 1, 1)
        End If
    End Sub

#End Region

#Region " DrawCorners "

    Private DrawCornersBrush As SolidBrush

    Protected Sub DrawCorners(ByVal c1 As Color, ByVal offset As Integer)
        DrawCorners(c1, 0, 0, Width, Height, offset)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal r1 As Rectangle, ByVal offset As Integer)
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal offset As Integer)
        DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2))
    End Sub

    Protected Sub DrawCorners(ByVal c1 As Color)
        DrawCorners(c1, 0, 0, Width, Height)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal r1 As Rectangle)
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        If _NoRounding Then Return

        If _Transparent Then
            B.SetPixel(x, y, c1)
            B.SetPixel(x + (width - 1), y, c1)
            B.SetPixel(x, y + (height - 1), c1)
            B.SetPixel(x + (width - 1), y + (height - 1), c1)
        Else
            DrawCornersBrush = New SolidBrush(c1)
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1)
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1)
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1)
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1)
        End If
    End Sub

#End Region

#Region " DrawBorders "

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal offset As Integer)
        DrawBorders(p1, 0, 0, Width, Height, offset)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal r As Rectangle, ByVal offset As Integer)
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal offset As Integer)
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2))
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen)
        DrawBorders(p1, 0, 0, Width, Height)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal r As Rectangle)
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        G.DrawRectangle(p1, x, y, width - 1, height - 1)
    End Sub

#End Region

#Region " DrawText "

    Private DrawTextPoint As Point
    Private DrawTextSize As Size

    Protected Sub DrawText(ByVal b1 As Brush, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        DrawText(b1, Text, a, x, y)
    End Sub
    Protected Sub DrawText(ByVal b1 As Brush, ByVal text As String, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If text.Length = 0 Then Return

        DrawTextSize = Measure(text)
        DrawTextPoint = New Point(Width \ 2 - DrawTextSize.Width \ 2, Header \ 2 - DrawTextSize.Height \ 2)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y)
            Case HorizontalAlignment.Center
                G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y)
            Case HorizontalAlignment.Right
                G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y)
        End Select
    End Sub

    Protected Sub DrawText(ByVal b1 As Brush, ByVal p1 As Point)
        If Text.Length = 0 Then Return
        G.DrawString(Text, Font, b1, p1)
    End Sub
    Protected Sub DrawText(ByVal b1 As Brush, ByVal x As Integer, ByVal y As Integer)
        If Text.Length = 0 Then Return
        G.DrawString(Text, Font, b1, x, y)
    End Sub

#End Region

#Region " DrawImage "

    Private DrawImagePoint As Point

    Protected Sub DrawImage(ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        DrawImage(_Image, a, x, y)
    End Sub
    Protected Sub DrawImage(ByVal image As Image, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If image Is Nothing Then Return
        DrawImagePoint = New Point(Width \ 2 - image.Width \ 2, Header \ 2 - image.Height \ 2)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height)
            Case HorizontalAlignment.Center
                G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height)
            Case HorizontalAlignment.Right
                G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height)
        End Select
    End Sub

    Protected Sub DrawImage(ByVal p1 As Point)
        DrawImage(_Image, p1.X, p1.Y)
    End Sub
    Protected Sub DrawImage(ByVal x As Integer, ByVal y As Integer)
        DrawImage(_Image, x, y)
    End Sub

    Protected Sub DrawImage(ByVal image As Image, ByVal p1 As Point)
        DrawImage(image, p1.X, p1.Y)
    End Sub
    Protected Sub DrawImage(ByVal image As Image, ByVal x As Integer, ByVal y As Integer)
        If image Is Nothing Then Return
        G.DrawImage(image, x, y, image.Width, image.Height)
    End Sub

#End Region

#Region " DrawGradient "

    Private DrawGradientBrush As LinearGradientBrush
    Private DrawGradientRectangle As Rectangle

    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(blend, DrawGradientRectangle)
    End Sub
    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(blend, DrawGradientRectangle, angle)
    End Sub

    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal r As Rectangle)
        DrawGradientBrush = New LinearGradientBrush(r, Color.Empty, Color.Empty, 90.0F)
        DrawGradientBrush.InterpolationColors = blend
        G.FillRectangle(DrawGradientBrush, r)
    End Sub
    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal angle As Single)
        DrawGradientBrush = New LinearGradientBrush(r, Color.Empty, Color.Empty, angle)
        DrawGradientBrush.InterpolationColors = blend
        G.FillRectangle(DrawGradientBrush, r)
    End Sub


    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(c1, c2, DrawGradientRectangle)
    End Sub
    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(c1, c2, DrawGradientRectangle, angle)
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle)
        DrawGradientBrush = New LinearGradientBrush(r, c1, c2, 90.0F)
        G.FillRectangle(DrawGradientBrush, r)
    End Sub
    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle, ByVal angle As Single)
        DrawGradientBrush = New LinearGradientBrush(r, c1, c2, angle)
        G.FillRectangle(DrawGradientBrush, r)
    End Sub

#End Region

#Region " DrawRadial "

    Private DrawRadialPath As GraphicsPath
    Private DrawRadialBrush1 As PathGradientBrush
    Private DrawRadialBrush2 As LinearGradientBrush
    Private DrawRadialRectangle As Rectangle

    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, width \ 2, height \ 2)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal center As Point)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, center.X, center.Y)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal cx As Integer, ByVal cy As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, cx, cy)
    End Sub

    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle)
        DrawRadial(blend, r, r.Width \ 2, r.Height \ 2)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal center As Point)
        DrawRadial(blend, r, center.X, center.Y)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal cx As Integer, ByVal cy As Integer)
        DrawRadialPath.Reset()
        DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1)

        DrawRadialBrush1 = New PathGradientBrush(DrawRadialPath)
        DrawRadialBrush1.CenterPoint = New Point(r.X + cx, r.Y + cy)
        DrawRadialBrush1.InterpolationColors = blend

        If G.SmoothingMode = SmoothingMode.AntiAlias Then
            G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3)
        Else
            G.FillEllipse(DrawRadialBrush1, r)
        End If
    End Sub


    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(c1, c2, DrawGradientRectangle)
    End Sub
    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(c1, c2, DrawGradientRectangle, angle)
    End Sub

    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle)
        DrawRadialBrush2 = New LinearGradientBrush(r, c1, c2, 90.0F)
        G.FillRectangle(DrawGradientBrush, r)
    End Sub
    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle, ByVal angle As Single)
        DrawRadialBrush2 = New LinearGradientBrush(r, c1, c2, angle)
        G.FillEllipse(DrawGradientBrush, r)
    End Sub

#End Region

#Region " CreateRound "

    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle

    Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return CreateRound(CreateRoundRectangle, slope)
    End Function

    Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function

#End Region

End Class
MustInherit Class ThemeControl154
    Inherits Control


#Region " Initialization "

    Protected G As Graphics, B As Bitmap

    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)

        _ImageSize = Size.Empty
        Font = New Font("Verdana", 8S)

        MeasureBitmap = New Bitmap(1, 1)
        MeasureGraphics = Graphics.FromImage(MeasureBitmap)

        DrawRadialPath = New GraphicsPath

        InvalidateCustimization() 'Remove?
    End Sub

    Protected NotOverridable Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        InvalidateCustimization()
        ColorHook()

        If Not _LockWidth = 0 Then Width = _LockWidth
        If Not _LockHeight = 0 Then Height = _LockHeight

        Transparent = _Transparent
        If _Transparent AndAlso _BackColor Then BackColor = Color.Transparent

        MyBase.OnHandleCreated(e)
    End Sub

    Private DoneCreation As Boolean
    Protected NotOverridable Overrides Sub OnParentChanged(ByVal e As EventArgs)
        If Parent IsNot Nothing Then
            OnCreation()
            DoneCreation = True
            InvalidateTimer()
        End If

        MyBase.OnParentChanged(e)
    End Sub

#End Region

    Private Sub DoAnimation(ByVal i As Boolean)
        OnAnimation()
        If i Then Invalidate()
    End Sub

    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return

        If _Transparent Then
            PaintHook()
            e.Graphics.DrawImage(B, 0, 0)
        Else
            G = e.Graphics
            PaintHook()
        End If
    End Sub

    Protected Overrides Sub OnHandleDestroyed(ByVal e As EventArgs)
        RemoveAnimationCallback(AddressOf DoAnimation)
        MyBase.OnHandleDestroyed(e)
    End Sub

#Region " Size Handling "

    Protected NotOverridable Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If _Transparent Then
            InvalidateBitmap()
        End If

        Invalidate()
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub SetBoundsCore(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal specified As BoundsSpecified)
        If Not _LockWidth = 0 Then width = _LockWidth
        If Not _LockHeight = 0 Then height = _LockHeight
        MyBase.SetBoundsCore(x, y, width, height, specified)
    End Sub

#End Region

#Region " State Handling "

    Private InPosition As Boolean
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        InPosition = True
        SetState(MouseState.Over)
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        If InPosition Then SetState(MouseState.Over)
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then SetState(MouseState.Down)
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        InPosition = False
        SetState(MouseState.None)
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
        If Enabled Then SetState(MouseState.None) Else SetState(MouseState.Block)
        MyBase.OnEnabledChanged(e)
    End Sub

    Protected State As MouseState
    Private Sub SetState(ByVal current As MouseState)
        State = current
        Invalidate()
    End Sub

#End Region


#Region " Base Properties "

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Overrides Property ForeColor() As Color
        Get
            Return Color.Empty
        End Get
        Set(ByVal value As Color)
        End Set
    End Property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Overrides Property BackgroundImage() As Image
        Get
            Return Nothing
        End Get
        Set(ByVal value As Image)
        End Set
    End Property
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Overrides Property BackgroundImageLayout() As ImageLayout
        Get
            Return ImageLayout.None
        End Get
        Set(ByVal value As ImageLayout)
        End Set
    End Property

    Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            Invalidate()
        End Set
    End Property
    Overrides Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            Invalidate()
        End Set
    End Property

    Private _BackColor As Boolean
    <Category("Misc")> _
    Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            If Not IsHandleCreated AndAlso value = Color.Transparent Then
                _BackColor = True
                Return
            End If

            MyBase.BackColor = value
            If Parent IsNot Nothing Then ColorHook()
        End Set
    End Property

#End Region

#Region " Public Properties "

    Private _NoRounding As Boolean
    Property NoRounding() As Boolean
        Get
            Return _NoRounding
        End Get
        Set(ByVal v As Boolean)
            _NoRounding = v
            Invalidate()
        End Set
    End Property

    Private _Image As Image
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            If value Is Nothing Then
                _ImageSize = Size.Empty
            Else
                _ImageSize = value.Size
            End If

            _Image = value
            Invalidate()
        End Set
    End Property

    Private _Transparent As Boolean
    Property Transparent() As Boolean
        Get
            Return _Transparent
        End Get
        Set(ByVal value As Boolean)
            _Transparent = value
            If Not IsHandleCreated Then Return

            If Not value AndAlso Not BackColor.A = 255 Then
                Throw New Exception("Unable to change value to false while a transparent BackColor is in use.")
            End If

            SetStyle(ControlStyles.Opaque, Not value)
            SetStyle(ControlStyles.SupportsTransparentBackColor, value)

            If value Then InvalidateBitmap() Else B = Nothing
            Invalidate()
        End Set
    End Property

    Private Items As New Dictionary(Of String, Color)
    Property Colors() As Bloom()
        Get
            Dim T As New List(Of Bloom)
            Dim E As Dictionary(Of String, Color).Enumerator = Items.GetEnumerator

            While E.MoveNext
                T.Add(New Bloom(E.Current.Key, E.Current.Value))
            End While

            Return T.ToArray
        End Get
        Set(ByVal value As Bloom())
            For Each B As Bloom In value
                If Items.ContainsKey(B.Name) Then Items(B.Name) = B.Value
            Next

            InvalidateCustimization()
            ColorHook()
            Invalidate()
        End Set
    End Property

    Private _Customization As String
    Property Customization() As String
        Get
            Return _Customization
        End Get
        Set(ByVal value As String)
            If value = _Customization Then Return

            Dim Data As Byte()
            Dim Items As Bloom() = Colors

            Try
                Data = Convert.FromBase64String(value)
                For I As Integer = 0 To Items.Length - 1
                    Items(I).Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4))
                Next
            Catch
                Return
            End Try

            _Customization = value

            Colors = Items
            ColorHook()
            Invalidate()
        End Set
    End Property

#End Region

#Region " Private Properties "

    Private _ImageSize As Size
    Protected ReadOnly Property ImageSize() As Size
        Get
            Return _ImageSize
        End Get
    End Property

    Private _LockWidth As Integer
    Protected Property LockWidth() As Integer
        Get
            Return _LockWidth
        End Get
        Set(ByVal value As Integer)
            _LockWidth = value
            If Not LockWidth = 0 AndAlso IsHandleCreated Then Width = LockWidth
        End Set
    End Property

    Private _LockHeight As Integer
    Protected Property LockHeight() As Integer
        Get
            Return _LockHeight
        End Get
        Set(ByVal value As Integer)
            _LockHeight = value
            If Not LockHeight = 0 AndAlso IsHandleCreated Then Height = LockHeight
        End Set
    End Property

    Private _IsAnimated As Boolean
    Protected Property IsAnimated() As Boolean
        Get
            Return _IsAnimated
        End Get
        Set(ByVal value As Boolean)
            _IsAnimated = value
            InvalidateTimer()
        End Set
    End Property

#End Region


#Region " Property Helpers "

    Protected Function GetPen(ByVal name As String) As Pen
        Return New Pen(Items(name))
    End Function
    Protected Function GetPen(ByVal name As String, ByVal width As Single) As Pen
        Return New Pen(Items(name), width)
    End Function

    Protected Function GetBrush(ByVal name As String) As SolidBrush
        Return New SolidBrush(Items(name))
    End Function

    Protected Function GetColor(ByVal name As String) As Color
        Return Items(name)
    End Function

    Protected Sub SetColor(ByVal name As String, ByVal value As Color)
        If Items.ContainsKey(name) Then Items(name) = value Else Items.Add(name, value)
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        SetColor(name, Color.FromArgb(r, g, b))
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal a As Byte, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        SetColor(name, Color.FromArgb(a, r, g, b))
    End Sub
    Protected Sub SetColor(ByVal name As String, ByVal a As Byte, ByVal value As Color)
        SetColor(name, Color.FromArgb(a, value))
    End Sub

    Private Sub InvalidateBitmap()
        If Width = 0 OrElse Height = 0 Then Return
        B = New Bitmap(Width, Height, PixelFormat.Format32bppPArgb)
        G = Graphics.FromImage(B)
    End Sub

    Private Sub InvalidateCustimization()
        Dim M As New MemoryStream(Items.Count * 4)

        For Each B As Bloom In Colors
            M.Write(BitConverter.GetBytes(B.Value.ToArgb), 0, 4)
        Next

        M.Close()
        _Customization = Convert.ToBase64String(M.ToArray)
    End Sub

    Private Sub InvalidateTimer()
        If DesignMode OrElse Not DoneCreation Then Return

        If _IsAnimated Then
            AddAnimationCallback(AddressOf DoAnimation)
        Else
            RemoveAnimationCallback(AddressOf DoAnimation)
        End If
    End Sub
#End Region


#Region " User Hooks "

    Protected MustOverride Sub ColorHook()
    Protected MustOverride Sub PaintHook()

    Protected Overridable Sub OnCreation()
    End Sub

    Protected Overridable Sub OnAnimation()
    End Sub

#End Region


#Region " Offset "

    Private OffsetReturnRectangle As Rectangle
    Protected Function Offset(ByVal r As Rectangle, ByVal amount As Integer) As Rectangle
        OffsetReturnRectangle = New Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2))
        Return OffsetReturnRectangle
    End Function

    Private OffsetReturnSize As Size
    Protected Function Offset(ByVal s As Size, ByVal amount As Integer) As Size
        OffsetReturnSize = New Size(s.Width + amount, s.Height + amount)
        Return OffsetReturnSize
    End Function

    Private OffsetReturnPoint As Point
    Protected Function Offset(ByVal p As Point, ByVal amount As Integer) As Point
        OffsetReturnPoint = New Point(p.X + amount, p.Y + amount)
        Return OffsetReturnPoint
    End Function

#End Region

#Region " Center "

    Private CenterReturn As Point

    Protected Function Center(ByVal p As Rectangle, ByVal c As Rectangle) As Point
        CenterReturn = New Point((p.Width \ 2 - c.Width \ 2) + p.X + c.X, (p.Height \ 2 - c.Height \ 2) + p.Y + c.Y)
        Return CenterReturn
    End Function
    Protected Function Center(ByVal p As Rectangle, ByVal c As Size) As Point
        CenterReturn = New Point((p.Width \ 2 - c.Width \ 2) + p.X, (p.Height \ 2 - c.Height \ 2) + p.Y)
        Return CenterReturn
    End Function

    Protected Function Center(ByVal child As Rectangle) As Point
        Return Center(Width, Height, child.Width, child.Height)
    End Function
    Protected Function Center(ByVal child As Size) As Point
        Return Center(Width, Height, child.Width, child.Height)
    End Function
    Protected Function Center(ByVal childWidth As Integer, ByVal childHeight As Integer) As Point
        Return Center(Width, Height, childWidth, childHeight)
    End Function

    Protected Function Center(ByVal p As Size, ByVal c As Size) As Point
        Return Center(p.Width, p.Height, c.Width, c.Height)
    End Function

    Protected Function Center(ByVal pWidth As Integer, ByVal pHeight As Integer, ByVal cWidth As Integer, ByVal cHeight As Integer) As Point
        CenterReturn = New Point(pWidth \ 2 - cWidth \ 2, pHeight \ 2 - cHeight \ 2)
        Return CenterReturn
    End Function

#End Region

#Region " Measure "

    Private MeasureBitmap As Bitmap
    Private MeasureGraphics As Graphics 'TODO: Potential issues during multi-threading.

    Protected Function Measure() As Size
        Return MeasureGraphics.MeasureString(Text, Font, Width).ToSize
    End Function
    Protected Function Measure(ByVal text As String) As Size
        Return MeasureGraphics.MeasureString(text, Font, Width).ToSize
    End Function

#End Region


#Region " DrawPixel "

    Private DrawPixelBrush As SolidBrush

    Protected Sub DrawPixel(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer)
        If _Transparent Then
            B.SetPixel(x, y, c1)
        Else
            DrawPixelBrush = New SolidBrush(c1)
            G.FillRectangle(DrawPixelBrush, x, y, 1, 1)
        End If
    End Sub

#End Region

#Region " DrawCorners "

    Private DrawCornersBrush As SolidBrush

    Protected Sub DrawCorners(ByVal c1 As Color, ByVal offset As Integer)
        DrawCorners(c1, 0, 0, Width, Height, offset)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal r1 As Rectangle, ByVal offset As Integer)
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal offset As Integer)
        DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2))
    End Sub

    Protected Sub DrawCorners(ByVal c1 As Color)
        DrawCorners(c1, 0, 0, Width, Height)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal r1 As Rectangle)
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height)
    End Sub
    Protected Sub DrawCorners(ByVal c1 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        If _NoRounding Then Return

        If _Transparent Then
            B.SetPixel(x, y, c1)
            B.SetPixel(x + (width - 1), y, c1)
            B.SetPixel(x, y + (height - 1), c1)
            B.SetPixel(x + (width - 1), y + (height - 1), c1)
        Else
            DrawCornersBrush = New SolidBrush(c1)
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1)
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1)
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1)
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1)
        End If
    End Sub

#End Region

#Region " DrawBorders "

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal offset As Integer)
        DrawBorders(p1, 0, 0, Width, Height, offset)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal r As Rectangle, ByVal offset As Integer)
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal offset As Integer)
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2))
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen)
        DrawBorders(p1, 0, 0, Width, Height)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal r As Rectangle)
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height)
    End Sub
    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        G.DrawRectangle(p1, x, y, width - 1, height - 1)
    End Sub

#End Region

#Region " DrawText "

    Private DrawTextPoint As Point
    Private DrawTextSize As Size

    Protected Sub DrawText(ByVal b1 As Brush, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        DrawText(b1, Text, a, x, y)
    End Sub
    Protected Sub DrawText(ByVal b1 As Brush, ByVal text As String, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If text.Length = 0 Then Return

        DrawTextSize = Measure(text)
        DrawTextPoint = Center(DrawTextSize)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y)
            Case HorizontalAlignment.Center
                G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y)
            Case HorizontalAlignment.Right
                G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y)
        End Select
    End Sub

    Protected Sub DrawText(ByVal b1 As Brush, ByVal p1 As Point)
        If Text.Length = 0 Then Return
        G.DrawString(Text, Font, b1, p1)
    End Sub
    Protected Sub DrawText(ByVal b1 As Brush, ByVal x As Integer, ByVal y As Integer)
        If Text.Length = 0 Then Return
        G.DrawString(Text, Font, b1, x, y)
    End Sub

#End Region

#Region " DrawImage "

    Private DrawImagePoint As Point

    Protected Sub DrawImage(ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        DrawImage(_Image, a, x, y)
    End Sub
    Protected Sub DrawImage(ByVal image As Image, ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If image Is Nothing Then Return
        DrawImagePoint = Center(image.Size)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height)
            Case HorizontalAlignment.Center
                G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height)
            Case HorizontalAlignment.Right
                G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height)
        End Select
    End Sub

    Protected Sub DrawImage(ByVal p1 As Point)
        DrawImage(_Image, p1.X, p1.Y)
    End Sub
    Protected Sub DrawImage(ByVal x As Integer, ByVal y As Integer)
        DrawImage(_Image, x, y)
    End Sub

    Protected Sub DrawImage(ByVal image As Image, ByVal p1 As Point)
        DrawImage(image, p1.X, p1.Y)
    End Sub
    Protected Sub DrawImage(ByVal image As Image, ByVal x As Integer, ByVal y As Integer)
        If image Is Nothing Then Return
        G.DrawImage(image, x, y, image.Width, image.Height)
    End Sub

#End Region

#Region " DrawGradient "

    Private DrawGradientBrush As LinearGradientBrush
    Private DrawGradientRectangle As Rectangle

    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(blend, DrawGradientRectangle)
    End Sub
    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(blend, DrawGradientRectangle, angle)
    End Sub

    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal r As Rectangle)
        DrawGradientBrush = New LinearGradientBrush(r, Color.Empty, Color.Empty, 90.0F)
        DrawGradientBrush.InterpolationColors = blend
        G.FillRectangle(DrawGradientBrush, r)
    End Sub
    Protected Sub DrawGradient(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal angle As Single)
        DrawGradientBrush = New LinearGradientBrush(r, Color.Empty, Color.Empty, angle)
        DrawGradientBrush.InterpolationColors = blend
        G.FillRectangle(DrawGradientBrush, r)
    End Sub


    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(c1, c2, DrawGradientRectangle)
    End Sub
    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawGradientRectangle = New Rectangle(x, y, width, height)
        DrawGradient(c1, c2, DrawGradientRectangle, angle)
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle)
        DrawGradientBrush = New LinearGradientBrush(r, c1, c2, 90.0F)
        G.FillRectangle(DrawGradientBrush, r)
    End Sub
    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle, ByVal angle As Single)
        DrawGradientBrush = New LinearGradientBrush(r, c1, c2, angle)
        G.FillRectangle(DrawGradientBrush, r)
    End Sub

#End Region

#Region " DrawRadial "

    Private DrawRadialPath As GraphicsPath
    Private DrawRadialBrush1 As PathGradientBrush
    Private DrawRadialBrush2 As LinearGradientBrush
    Private DrawRadialRectangle As Rectangle

    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, width \ 2, height \ 2)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal center As Point)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, center.X, center.Y)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal cx As Integer, ByVal cy As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(blend, DrawRadialRectangle, cx, cy)
    End Sub

    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle)
        DrawRadial(blend, r, r.Width \ 2, r.Height \ 2)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal center As Point)
        DrawRadial(blend, r, center.X, center.Y)
    End Sub
    Sub DrawRadial(ByVal blend As ColorBlend, ByVal r As Rectangle, ByVal cx As Integer, ByVal cy As Integer)
        DrawRadialPath.Reset()
        DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1)

        DrawRadialBrush1 = New PathGradientBrush(DrawRadialPath)
        DrawRadialBrush1.CenterPoint = New Point(r.X + cx, r.Y + cy)
        DrawRadialBrush1.InterpolationColors = blend

        If G.SmoothingMode = SmoothingMode.AntiAlias Then
            G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3)
        Else
            G.FillEllipse(DrawRadialBrush1, r)
        End If
    End Sub


    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(c1, c2, DrawRadialRectangle)
    End Sub
    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        DrawRadialRectangle = New Rectangle(x, y, width, height)
        DrawRadial(c1, c2, DrawRadialRectangle, angle)
    End Sub

    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle)
        DrawRadialBrush2 = New LinearGradientBrush(r, c1, c2, 90.0F)
        G.FillEllipse(DrawRadialBrush2, r)
    End Sub
    Protected Sub DrawRadial(ByVal c1 As Color, ByVal c2 As Color, ByVal r As Rectangle, ByVal angle As Single)
        DrawRadialBrush2 = New LinearGradientBrush(r, c1, c2, angle)
        G.FillEllipse(DrawRadialBrush2, r)
    End Sub

#End Region

#Region " CreateRound "

    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle

    Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return CreateRound(CreateRoundRectangle, slope)
    End Function

    Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function

#End Region

End Class
Module ThemeShare

#Region " Animation "

    Private Frames As Integer
    Private Invalidate As Boolean
    Public ThemeTimer As New PrecisionTimer

    Private Const FPS As Integer = 50 '1000 / 50 = 20 FPS
    Private Const Rate As Integer = 10

    Public Delegate Sub AnimationDelegate(ByVal invalidate As Boolean)

    Private Callbacks As New List(Of AnimationDelegate)

    Private Sub HandleCallbacks(ByVal state As IntPtr, ByVal reserve As Boolean)
        Invalidate = (Frames >= FPS)
        If Invalidate Then Frames = 0

        SyncLock Callbacks
            For I As Integer = 0 To Callbacks.Count - 1
                Callbacks(I).Invoke(Invalidate)
            Next
        End SyncLock

        Frames += Rate
    End Sub

    Private Sub InvalidateThemeTimer()
        If Callbacks.Count = 0 Then
            ThemeTimer.Delete()
        Else
            ThemeTimer.Create(0, Rate, AddressOf HandleCallbacks)
        End If
    End Sub

    Sub AddAnimationCallback(ByVal callback As AnimationDelegate)
        SyncLock Callbacks
            If Callbacks.Contains(callback) Then Return

            Callbacks.Add(callback)
            InvalidateThemeTimer()
        End SyncLock
    End Sub

    Sub RemoveAnimationCallback(ByVal callback As AnimationDelegate)
        SyncLock Callbacks
            If Not Callbacks.Contains(callback) Then Return

            Callbacks.Remove(callback)
            InvalidateThemeTimer()
        End SyncLock
    End Sub

#End Region

End Module
Enum MouseState As Byte
    None = 0
    Over = 1
    Down = 2
    Block = 3
End Enum
Structure Bloom

    Public _Name As String
    ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property

    Private _Value As Color
    Property Value() As Color
        Get
            Return _Value
        End Get
        Set(ByVal value As Color)
            _Value = value
        End Set
    End Property

    Property ValueHex() As String
        Get
            Return String.Concat("#", _
            _Value.R.ToString("X2", Nothing), _
            _Value.G.ToString("X2", Nothing), _
            _Value.B.ToString("X2", Nothing))
        End Get
        Set(ByVal value As String)
            Try
                _Value = ColorTranslator.FromHtml(value)
            Catch
                Return
            End Try
        End Set
    End Property


    Sub New(ByVal name As String, ByVal value As Color)
        _Name = name
        _Value = value
    End Sub
End Structure
Class PrecisionTimer
    Implements IDisposable

    Private _Enabled As Boolean
    ReadOnly Property Enabled() As Boolean
        Get
            Return _Enabled
        End Get
    End Property

    Private Handle As IntPtr
    Private TimerCallback As TimerDelegate

    <DllImport("kernel32.dll", EntryPoint:="CreateTimerQueueTimer")> _
    Private Shared Function CreateTimerQueueTimer( _
    ByRef handle As IntPtr, _
    ByVal queue As IntPtr, _
    ByVal callback As TimerDelegate, _
    ByVal state As IntPtr, _
    ByVal dueTime As UInteger, _
    ByVal period As UInteger, _
    ByVal flags As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="DeleteTimerQueueTimer")> _
    Private Shared Function DeleteTimerQueueTimer( _
    ByVal queue As IntPtr, _
    ByVal handle As IntPtr, _
    ByVal callback As IntPtr) As Boolean
    End Function

    Delegate Sub TimerDelegate(ByVal r1 As IntPtr, ByVal r2 As Boolean)

    Sub Create(ByVal dueTime As UInteger, ByVal period As UInteger, ByVal callback As TimerDelegate)
        If _Enabled Then Return

        TimerCallback = callback
        Dim Success As Boolean = CreateTimerQueueTimer(Handle, IntPtr.Zero, TimerCallback, IntPtr.Zero, dueTime, period, 0)

        If Not Success Then ThrowNewException("CreateTimerQueueTimer")
        _Enabled = Success
    End Sub

    Sub Delete()
        If Not _Enabled Then Return
        Dim Success As Boolean = DeleteTimerQueueTimer(IntPtr.Zero, Handle, IntPtr.Zero)

        If Not Success AndAlso Not Marshal.GetLastWin32Error = 997 Then
            ThrowNewException("DeleteTimerQueueTimer")
        End If

        _Enabled = Not Success
    End Sub

    Private Sub ThrowNewException(ByVal name As String)
        Throw New Exception(String.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error))
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Delete()
    End Sub
End Class

Class dscSeperator
    Inherits ThemeControl154

    Private _Orientation As Orientation
    Property Orientation() As Orientation
        Get
            Return _Orientation
        End Get
        Set(ByVal value As Orientation)
            _Orientation = value

            If value = Windows.Forms.Orientation.Vertical Then
                LockHeight = 0
                LockWidth = 14
            Else
                LockHeight = 14
                LockWidth = 0
            End If

            Invalidate()
        End Set
    End Property

    Sub New()
        Transparent = True
        BackColor = Color.Transparent

        LockHeight = 14
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)

        Dim BL1, BL2 As New ColorBlend
        BL1.Positions = New Single() {0.0F, 0.15F, 0.85F, 1.0F}
        BL2.Positions = New Single() {0.0F, 0.15F, 0.5F, 0.85F, 1.0F}

        BL1.Colors = New Color() {Color.Transparent, Color.Black, Color.Black, Color.Transparent}
        BL2.Colors = New Color() {Color.Transparent, Color.FromArgb(35, 35, 35), Color.FromArgb(45, 45, 45), Color.FromArgb(35, 35, 35), Color.Transparent}

        If _Orientation = Windows.Forms.Orientation.Vertical Then
            DrawGradient(BL1, 6, 0, 1, Height)
            DrawGradient(BL2, 7, 0, 1, Height)
        Else
            DrawGradient(BL1, 0, 6, Width, 1, 0.0F)
            DrawGradient(BL2, 0, 7, Width, 1, 0.0F)
        End If

    End Sub

End Class

Class ControlBox
    Inherits ThemeControl154
    Private _Min As Boolean = True
    Private _Max As Boolean = True
    Private X As Integer

    Protected Overrides Sub ColorHook()
    End Sub

    Public Property MinButton As Boolean
        Get
            Return _Min
        End Get
        Set(value As Boolean)
            _Min = value
            Dim tempwidth As Integer = 40
            If _Min Then tempwidth += 25
            If _Max Then tempwidth += 25
            Me.Width = tempwidth + 1
            Me.Height = 16
            Invalidate()
        End Set
    End Property

    Public Property MaxButton As Boolean
        Get
            Return _Max
        End Get
        Set(value As Boolean)
            _Max = value
            Dim tempwidth As Integer = 40
            If _Min Then tempwidth += 25
            If _Max Then tempwidth += 25
            Me.Width = tempwidth + 1
            Me.Height = 16
            Invalidate()
        End Set
    End Property

    Sub New()
        Size = New Size(92, 16)
        Location = New Point(50, 2)
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.Location.X
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As System.EventArgs)
        MyBase.OnClick(e)
        If _Min And _Max Then
            If X > 0 And X < 25 Then

            ElseIf X > 25 And X < 50 Then

            ElseIf X > 50 And X < 75 Then

            ElseIf X > 75 And X < 100 Then
                faqwindow.Show()
            ElseIf X > 103 And X < 128 Then
                dscWindow.previouswinsize = FindForm.WindowState
                FindForm.WindowState = FormWindowState.Minimized
                dscWindow.wasminimized = True
                If settingswindow.totray.Checked = True Then
                    dscWindow.ShowInTaskbar = False
                Else
                    dscWindow.ShowInTaskbar = True
                End If
            ElseIf X > 128 And X < 153 Then
                If FindForm.WindowState = FormWindowState.Maximized Then
                    dscWindow.previouswinsize = FormWindowState.Maximized
                    FindForm.WindowState = FormWindowState.Normal
                    elementsplacing()
                Else
                    dscWindow.previouswinsize = FormWindowState.Normal
                    FindForm.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                    FindForm.WindowState = FormWindowState.Maximized
                    elementsplacing()
                End If
            ElseIf X > 153 And X < 193 Then
                FindForm.Close()
            End If
        End If
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(47, 47, 47))
        Dim cblend As ColorBlend = New ColorBlend(2)
        cblend.Colors(0) = Color.FromArgb(66, 66, 66)
        cblend.Colors(1) = Color.FromArgb(50, 50, 50)
        cblend.Positions(0) = 0
        cblend.Positions(1) = 1
        DrawGradient(cblend, New Rectangle(New Point(0, 0), New Size(Me.Width, Me.Height)))

        If _Min And _Max Then
            If State = MouseState.Over Then
                If X > 0 And X < 25 Then
                    cblend = New ColorBlend(2)
                    cblend.Colors(0) = Color.FromArgb(80, 80, 80)
                    cblend.Colors(1) = Color.FromArgb(60, 60, 60)
                    cblend.Positions(0) = 0
                    cblend.Positions(1) = 1
                    DrawGradient(cblend, New Rectangle(New Point(1, 0), New Size(25, 15)))
                End If
                If X > 25 And X < 50 Then
                    cblend = New ColorBlend(2)
                    cblend.Colors(0) = Color.FromArgb(80, 80, 80)
                    cblend.Colors(1) = Color.FromArgb(60, 60, 60)
                    cblend.Positions(0) = 0
                    cblend.Positions(1) = 1
                    DrawGradient(cblend, New Rectangle(New Point(26, 0), New Size(26, 15)))
                End If
                If X > 50 And X < 75 Then
                    cblend = New ColorBlend(2)
                    cblend.Colors(0) = Color.FromArgb(80, 80, 80)
                    cblend.Colors(1) = Color.FromArgb(60, 60, 60)
                    cblend.Positions(0) = 0
                    cblend.Positions(1) = 1
                    DrawGradient(cblend, New Rectangle(New Point(51, 0), New Size(26, 15)))
                End If
                If X > 75 And X < 100 Then
                    cblend = New ColorBlend(2)
                    cblend.Colors(0) = Color.FromArgb(80, 80, 80)
                    cblend.Colors(1) = Color.FromArgb(60, 60, 60)
                    cblend.Positions(0) = 0
                    cblend.Positions(1) = 1
                    DrawGradient(cblend, New Rectangle(New Point(76, 0), New Size(26, 15)))
                End If
                If X > 103 And X < 128 Then
                    cblend = New ColorBlend(2)
                    cblend.Colors(0) = Color.FromArgb(80, 80, 80)
                    cblend.Colors(1) = Color.FromArgb(60, 60, 60)
                    cblend.Positions(0) = 0
                    cblend.Positions(1) = 1
                    DrawGradient(cblend, New Rectangle(New Point(101, 0), New Size(26, 15)))
                End If
                If X > 128 And X < 153 Then
                    cblend = New ColorBlend(2)
                    cblend.Colors(0) = Color.FromArgb(80, 80, 80)
                    cblend.Colors(1) = Color.FromArgb(60, 60, 60)
                    cblend.Positions(0) = 0
                    cblend.Positions(1) = 1
                    DrawGradient(cblend, New Rectangle(New Point(129, 0), New Size(26, 15)))
                End If
                If X > 153 And X < 193 Then
                    cblend = New ColorBlend(2)
                    cblend.Colors(0) = Color.FromArgb(80, 80, 80)
                    cblend.Colors(1) = Color.FromArgb(60, 60, 60)
                    cblend.Positions(0) = 0
                    cblend.Positions(1) = 1
                    DrawGradient(cblend, New Rectangle(New Point(151, 0), New Size(129, 15)))
                End If
            End If
            G.DrawLine(New Pen(Color.FromArgb(104, 104, 104)), New Point(0, 0), New Point(0, 14))
            G.DrawLine(New Pen(Color.FromArgb(104, 104, 104)), New Point(25, 0), New Point(25, 14))
            G.DrawLine(New Pen(Color.FromArgb(104, 104, 104)), New Point(50, 0), New Point(50, 14))
            G.DrawLine(New Pen(Color.FromArgb(104, 104, 104)), New Point(75, 0), New Point(75, 14))
            G.DrawLine(New Pen(Color.FromArgb(114, 144, 134)), New Point(100, 0), New Point(100, 14))
            G.DrawLine(New Pen(Color.FromArgb(114, 144, 134)), New Point(101, 0), New Point(101, 14))
            G.DrawLine(New Pen(Color.FromArgb(114, 144, 134)), New Point(102, 0), New Point(102, 14))
            'bottom line
            G.DrawLine(New Pen(Color.FromArgb(104, 104, 104)), New Point(1, 15), New Point(193, 15))
            G.DrawLine(New Pen(Color.FromArgb(104, 104, 104)), New Point(128, 0), New Point(128, 14))
            G.DrawLine(New Pen(Color.FromArgb(104, 104, 104)), New Point(153, 0), New Point(153, 14))
            G.DrawLine(New Pen(Color.FromArgb(104, 104, 104)), New Point(193, 0), New Point(193, 14))
            DrawPixel(Color.FromArgb(104, 104, 104), 1, 14)
            DrawPixel(Color.FromArgb(104, 104, 104), 192, 14)
            G.DrawString("s", New Font("Marlett", 8), Brushes.White, New Point(81, 2))
            G.DrawString("r", New Font("Marlett", 8), Brushes.White, New Point(166, 2))
            If FindForm.WindowState = FormWindowState.Normal Then
                G.DrawString("1", New Font("Marlett", 8), Brushes.White, New Point(135, 2))
            Else
                G.DrawString("2", New Font("Marlett", 8), Brushes.White, New Point(135, 2))
            End If
            G.DrawString("0", New Font("Marlett", 8), Brushes.White, New Point(109, 2))
        End If
    End Sub
End Class

Class dscTheme
    Inherits ThemeContainer154

    Sub New()
        Me.BackColor = Color.FromArgb(51, 51, 51)
        TransparencyKey = Color.Fuchsia

        SetColor("Sides", 232, 232, 232)
        SetColor("Gradient1", 252, 252, 252)
        SetColor("Gradient2", 242, 242, 242)
        SetColor("TextShade", Color.White)
        SetColor("Text", 80, 80, 80)
        SetColor("Back", Color.White)
        SetColor("Border1", Color.Black)
        SetColor("Border2", Color.White)
        SetColor("Border3", Color.White)
        SetColor("Border4", 150, 150, 150)
    End Sub

    Private C1, C2, C3 As Color
    Private B1, B2, B3 As SolidBrush
    Private P1, P2, P3, P4 As Pen

    Protected Overrides Sub ColorHook()
        C1 = GetColor("Sides")
        C2 = GetColor("Gradient1")
        C3 = GetColor("Gradient2")

        B1 = New SolidBrush(GetColor("TextShade"))
        B2 = New SolidBrush(GetColor("Text"))
        B3 = New SolidBrush(GetColor("Back"))

        P1 = New Pen(Color.FromArgb(24, 24, 24))
        P2 = New Pen(Color.FromArgb(126, 126, 126))

        P3 = New Pen(Color.FromArgb(92, 92, 92))
        P4 = New Pen(Color.FromArgb(24, 24, 24))

        BackColor = B3.Color
    End Sub

    Private RT1 As Rectangle

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(51, 51, 51))

        DrawGradient(C2, C3, 0, 0, Width, 15)

        DrawText(B1, HorizontalAlignment.Left, 13, 1)
        DrawText(B2, HorizontalAlignment.Left, 12, 0)

        DrawGradient(Color.FromArgb(92, 92, 92), Color.FromArgb(49, 49, 49), 0, 0, Width, 26)
        G.DrawLine(New Pen(P1.Color), New Point(0, 26), New Point(Width, 26))
        G.DrawRectangle(P1, 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(P2, 1, 1, Width - 3, Height - 3)
        DrawPixel(P1.Color, 1, 1)
        DrawPixel(P2.Color, 2, 2)
        DrawPixel(P1.Color, Width - 2, 1)
        DrawPixel(P2.Color, Width - 3, 2)
        DrawPixel(P1.Color, 1, Height - 2)
        DrawPixel(P2.Color, 2, Height - 3)
        DrawPixel(P1.Color, Width - 2, Height - 2)
        DrawPixel(P2.Color, Width - 3, Height - 3)
        DrawText(New SolidBrush(Color.FromArgb(61, 61, 61)), HorizontalAlignment.Center, 0, 1)
        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Center, 0, 2)

    End Sub
End Class
Class dscProgressBar
    Inherits ThemeControl154
    Private _Maximum As Integer = 100
    Private _Value As Integer
    Private Progress As Integer

    Protected Overrides Sub ColorHook()

    End Sub

    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal V As Integer)
            If V < 1 Then V = 1
            If V < _Value Then _Value = V
            _Maximum = V
            Invalidate()
        End Set
    End Property
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(ByVal V As Integer)
            If V > _Maximum Then V = Maximum
            _Value = V
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub PaintHook()
        G.Clear(Color.Black)
        'Border
        Dim left As New Rectangle(0, 0, 60, Height - 1)
        Dim leftLGB As New LinearGradientBrush(left, Color.FromArgb(255, 32, 32, 32), Color.FromArgb(100, Color.White), 180.0F)
        G.FillRectangle(leftLGB, left)
        Dim right As New Rectangle(Width - 61, 0, 60, Height - 1)
        Dim rightLGB As New LinearGradientBrush(right, Color.FromArgb(100, Color.White), Color.FromArgb(255, 32, 32, 32), 180.0F)
        G.FillRectangle(rightLGB, right)
        Dim middle As New Rectangle(60, 0, Width - 120, Height - 1)
        Dim middleSB As New SolidBrush(Color.FromArgb(255, 32, 32, 32))
        G.FillRectangle(middleSB, middle)
        'Background
        Dim rect As New Rectangle(2, 2, Width - 4, Height - 4)
        Dim backHB As New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(255, 10, 10, 10), Color.FromArgb(255, 11, 11, 11))
        G.FillRectangle(backHB, rect)
        'Bar
        Dim cblend As New ColorBlend(2)

        If _Value <= 20 Then
            cblend.Colors(0) = Color.Red
            cblend.Colors(1) = Color.FromArgb(255, 90, 0, 0)
        ElseIf _Value > 75 Then
            cblend.Colors(0) = Color.FromArgb(255, 54, 217, 0)
            cblend.Colors(1) = Color.FromArgb(255, 26, 102, 0)
        Else
            cblend.Colors(0) = Color.Orange
            cblend.Colors(1) = Color.FromArgb(255, 145, 70, 0)
        End If

        cblend.Positions(0) = 0
        cblend.Positions(1) = 1
        DrawGradient(cblend, New Rectangle(2, 2, CInt(((Width / _Maximum) * _Value) - 4), Height - 4))
        'Border
        DrawBorders(Pens.Black, 0)
        DrawBorders(Pens.Black, 2)
    End Sub

    Public Sub New()
        _Maximum = 100
    End Sub

End Class
Class dscButton
    Inherits ThemeControl154

    Sub New()
    End Sub
    Private TopGradient, BotGradient As Color
    Private TopGradientClick, BotGradientClick As Color
    Private TopGradientHover, BotGradientHover As Color
    Private InnerBorder, OuterBorder, InnerBorderHover, OuterBorderHover, InnerBorderClick, OuterBorderClick As Pen
    Private TextCol As SolidBrush
    Protected Overrides Sub ColorHook()
        TopGradient = Color.FromArgb(55, 55, 55)
        BotGradient = Color.FromArgb(32, 32, 32)

        TopGradientHover = Color.FromArgb(66, 66, 66)
        BotGradientHover = Color.FromArgb(41, 41, 41)

        TopGradientClick = Color.FromArgb(60, 60, 60)
        BotGradientClick = Color.FromArgb(37, 37, 37)

        TextCol = New SolidBrush(Color.FromArgb(204, 204, 204))

        OuterBorder = New Pen(Color.Black)
        InnerBorder = New Pen(Color.FromArgb(76, 76, 76))

        OuterBorderHover = New Pen(Color.Black)
        InnerBorderHover = New Pen(Color.FromArgb(87, 87, 87))

        OuterBorderClick = New Pen(Color.Black)
        InnerBorderClick = New Pen(Color.FromArgb(71, 71, 71))
    End Sub

    Protected Overrides Sub PaintHook()

        If State = MouseState.Down Then
            DrawGradient(TopGradientClick, BotGradientClick, New Rectangle(2, 1, Width - 4, Height - 3), 90.0F)
            G.DrawRectangle(InnerBorderClick, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3)
            'TOPLEFT
            DrawPixel(OuterBorderClick.Color, 1, 1)
            DrawPixel(InnerBorderClick.Color, 2, 2)
            'TOPRIGHT
            DrawPixel(OuterBorderClick.Color, Width - 2, 1)
            DrawPixel(InnerBorderClick.Color, Width - 3, 2)
            'BOTTOMLEFT
            DrawPixel(OuterBorderClick.Color, 1, Height - 2)
            DrawPixel(InnerBorderClick.Color, 1, Height - 3)
            'BOTTOMRIGHT
            DrawPixel(OuterBorderClick.Color, Width - 2, Height - 2)
            DrawPixel(InnerBorderClick.Color, Width - 3, Height - 3)
            DrawBorders(OuterBorderClick)
        Else
            DrawGradient(TopGradient, BotGradient, New Rectangle(2, 1, Width - 4, Height - 3), 90.0F)
            G.DrawRectangle(InnerBorder, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3)
            'TOPLEFT
            DrawPixel(OuterBorder.Color, 1, 1)
            DrawPixel(InnerBorder.Color, 2, 2)
            'TOPRIGHT
            DrawPixel(OuterBorder.Color, Width - 2, 1)
            DrawPixel(InnerBorder.Color, Width - 3, 2)
            'BOTTOMLEFT
            DrawPixel(OuterBorder.Color, 1, Height - 2)
            DrawPixel(InnerBorder.Color, 1, Height - 3)
            'BOTTOMRIGHT
            DrawPixel(OuterBorder.Color, Width - 2, Height - 2)
            DrawPixel(InnerBorder.Color, Width - 3, Height - 3)
            DrawBorders(OuterBorder)
        End If

        If State = MouseState.Over Then
            DrawGradient(TopGradientHover, BotGradientHover, New Rectangle(2, 1, Width - 4, Height - 3), 90.0F)
            G.DrawRectangle(InnerBorderHover, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3)
            'TOPLEFT
            DrawPixel(OuterBorderHover.Color, 1, 1)
            DrawPixel(InnerBorderHover.Color, 2, 2)
            'TOPRIGHT
            DrawPixel(OuterBorderHover.Color, Width - 2, 1)
            DrawPixel(InnerBorderHover.Color, Width - 3, 2)
            'BOTTOMLEFT
            DrawPixel(OuterBorderHover.Color, 1, Height - 2)
            DrawPixel(InnerBorderHover.Color, 1, Height - 3)
            'BOTTOMRIGHT
            DrawPixel(OuterBorderHover.Color, Width - 2, Height - 2)
            DrawPixel(InnerBorderHover.Color, Width - 3, Height - 3)
            DrawBorders(OuterBorderHover)
        End If

        DrawText(TextCol, HorizontalAlignment.Center, 0, 0)

        DrawCorners(Color.FromArgb(151, 151, 151))
    End Sub
End Class
Class dscMiddleBar
    Inherits ThemeControl154

    Sub New()
        LockHeight = 31
        Height = 31
    End Sub
    Protected Overrides Sub ColorHook()
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(54, 54, 54))
        G.DrawLine(New Pen(Color.FromArgb(24, 24, 24)), 0, 0, Width, 0)
        G.DrawLine(New Pen(Color.FromArgb(69, 69, 69)), 0, 1, Width, 1)
        G.DrawLine(New Pen(Color.FromArgb(24, 24, 24)), 0, Height - 2, Width, Height - 2)
        G.DrawLine(New Pen(Color.FromArgb(69, 69, 69)), 0, Height - 1, Width, Height - 1)
    End Sub
End Class
Class dscSideButton

    Inherits ThemeControl154
    Public Enum _Icon
        Square = 1
        Circle = 2
        Triangle = 3
        Custom_Image = 4
    End Enum
    Public Enum _Color
        Red = 1
        Green = 2
        Yellow = 3
        Violet = 4
    End Enum
    Private _DisplayIcon As _Icon
    Private _Col As _Color
    Property DisplayIcon As _Icon
        Get
            Return _DisplayIcon
        End Get
        Set(ByVal value As _Icon)
            _DisplayIcon = value
            Invalidate()
        End Set
    End Property
    Property SideColor As _Color
        Get
            Return _Col
        End Get
        Set(ByVal value As _Color)
            _Col = value
            Invalidate()
        End Set
    End Property
    Sub New()
        LockHeight = 30
        Width = 227
    End Sub
    Private GrayGradient1, GrayGradient2, GrayGradient3, GrayGradient4, RedGradient1, RedGradient2, RedGradient3, RedGradient4 As Color
    Private OuterBorder, InnerBorderGray, InnerBorderRed As Pen
    Private InnerBorderGreen, InnerBorderYellow, InnerBorderViolet As Pen
    Private InnerBorderGrayHover As Pen
    Private InnerBorderGrayClick As Pen
    Private GreenGradient1, GreenGradient2, GreenGradient3, GreenGradient4 As Color
    Private YellowGradient1, YellowGradient2, YellowGradient3, YellowGradient4 As Color
    Private ExtraPixelRed, ExtraPixelGreen, ExtraPixelYellow, ExtraPixelViolet As Color
    Private VioletGradient1, VioletGradient2, VioletGradient3, VioletGradient4 As Color
    Private GrayGradientHover1, GrayGradientHover2, GrayGradientHover3, GrayGradientHover4 As Color
    Private GrayGradientClick1, GrayGradientClick2, GrayGradientClick3, GrayGradientClick4 As Color
    Private TextCol As SolidBrush
    Private CircleColor As Color
    Private SquareColor As Color
    Private TriangleColor As Color
    Protected Overrides Sub ColorHook()
        OuterBorder = New Pen(Color.Black)
        InnerBorderRed = New Pen(Color.FromArgb(216, 70, 70))
        InnerBorderGray = New Pen(Color.FromArgb(87, 87, 87))
        InnerBorderGreen = New Pen(Color.FromArgb(68, 204, 2))
        InnerBorderYellow = New Pen(Color.FromArgb(247, 219, 17))
        InnerBorderViolet = New Pen(Color.FromArgb(126, 97, 168))
        InnerBorderGrayHover = New Pen(Color.FromArgb(104, 104, 104))
        InnerBorderGrayClick = New Pen(Color.FromArgb(79, 79, 79))
        TextCol = New SolidBrush(Color.White)
        ExtraPixelRed = Color.FromArgb(133, 37, 37)
        ExtraPixelGreen = Color.FromArgb(1, 58, 11)
        ExtraPixelYellow = Color.FromArgb(206, 111, 4)
        SquareColor = Color.White

        GrayGradient1 = Color.FromArgb(59, 59, 59)
        GrayGradient2 = Color.FromArgb(45, 45, 45)
        GrayGradient3 = Color.FromArgb(33, 33, 33)
        GrayGradient4 = Color.FromArgb(24, 24, 24)

        GrayGradientHover1 = Color.FromArgb(78, 78, 78)
        GrayGradientHover2 = Color.FromArgb(64, 64, 64)
        GrayGradientHover3 = Color.FromArgb(48, 48, 48)
        GrayGradientHover4 = Color.FromArgb(38, 38, 38)

        GrayGradientClick1 = Color.FromArgb(48, 48, 48)
        GrayGradientClick2 = Color.FromArgb(35, 35, 35)
        GrayGradientClick3 = Color.FromArgb(33, 33, 33)
        GrayGradientClick4 = Color.FromArgb(24, 24, 24)

        RedGradient1 = Color.FromArgb(206, 38, 38)
        RedGradient2 = Color.FromArgb(157, 25, 25)
        RedGradient3 = Color.FromArgb(147, 12, 12)
        RedGradient4 = Color.FromArgb(104, 2, 2)

        GreenGradient1 = Color.FromArgb(52, 155, 2)
        GreenGradient2 = Color.FromArgb(43, 129, 1)
        GreenGradient3 = Color.FromArgb(2, 100, 19)
        GreenGradient4 = Color.FromArgb(1, 78, 15)

        YellowGradient1 = Color.FromArgb(232, 151, 10)
        YellowGradient2 = Color.FromArgb(236, 167, 12)
        YellowGradient3 = Color.FromArgb(228, 141, 5)
        YellowGradient4 = Color.FromArgb(223, 122, 4)

        VioletGradient1 = Color.FromArgb(111, 29, 161)
        VioletGradient2 = Color.FromArgb(115, 45, 163)
        VioletGradient3 = Color.FromArgb(107, 19, 156)
        VioletGradient4 = Color.FromArgb(102, 0, 153)

        CircleColor = Color.White
        TriangleColor = Color.White
    End Sub

    Protected Overrides Sub PaintHook()
        ''---GRAY---
        If State = MouseState.Down Then
            DrawGradient(GrayGradientClick3, GrayGradientClick4, New Rectangle(1, Height / 2 - 1, Width, Height / 2 + 2)) 'BOT
            DrawGradient(GrayGradientClick1, GrayGradientClick2, New Rectangle(1, 1, Width, Height / 2 - 1)) 'TOP
        ElseIf State = MouseState.Over Then
            DrawGradient(GrayGradientHover3, GrayGradientHover4, New Rectangle(1, Height / 2 - 1, Width, Height / 2 + 2)) 'BOT
            DrawGradient(GrayGradientHover1, GrayGradientHover2, New Rectangle(1, 1, Width, Height / 2 - 1)) 'TOP
        Else
            DrawGradient(GrayGradient3, GrayGradient4, New Rectangle(1, Height / 2 - 1, Width, Height / 2 + 2)) 'BOT
            DrawGradient(GrayGradient1, GrayGradient2, New Rectangle(1, 1, Width, Height / 2 - 1)) 'TOP
        End If
        ''---COLOR---
        If _Col = _Color.Green Then
            DrawGradient(GreenGradient3, GreenGradient4, New Rectangle(1, Height / 2 - 1, 23, Height / 2 + 2)) 'BOT
            DrawGradient(GreenGradient1, GreenGradient2, New Rectangle(1, 1, 23, Height / 2 - 1)) 'TOP
        ElseIf _Col = _Color.Yellow Then
            DrawGradient(YellowGradient3, YellowGradient4, New Rectangle(1, Height / 2 - 1, 23, Height / 2 + 2)) 'BOT
            DrawGradient(YellowGradient1, YellowGradient2, New Rectangle(1, 1, 23, Height / 2 - 1)) 'TOP
        ElseIf _Col = _Color.Violet Then
            DrawGradient(VioletGradient3, VioletGradient4, New Rectangle(1, Height / 2 - 1, 23, Height / 2 + 2)) 'BOT
            DrawGradient(VioletGradient1, VioletGradient2, New Rectangle(1, 1, 23, Height / 2 - 1)) 'TOP
        Else
            DrawGradient(RedGradient3, RedGradient4, New Rectangle(1, Height / 2 - 1, 23, Height / 2 + 2)) 'BOT
            DrawGradient(RedGradient1, RedGradient2, New Rectangle(1, 1, 23, Height / 2 - 1)) 'TOP
        End If
        ''---------
        If _Col = _Color.Green Then
            G.DrawRectangle(InnerBorderGreen, New Rectangle(1, 1, 22, Height - 3))
        ElseIf _Col = _Color.Yellow Then
            G.DrawRectangle(InnerBorderYellow, New Rectangle(1, 1, 22, Height - 3))
        ElseIf _Col = _Color.Violet Then
            G.DrawRectangle(InnerBorderViolet, New Rectangle(1, 1, 22, Height - 3))
        Else
            G.DrawRectangle(InnerBorderRed, New Rectangle(1, 1, 22, Height - 3))
        End If
        If State = MouseState.Down Then
            G.DrawRectangle(InnerBorderGrayClick, New Rectangle(24, 1, Width - 26, Height - 3))
        ElseIf State = MouseState.Over Then
            G.DrawRectangle(InnerBorderGrayHover, New Rectangle(24, 1, Width - 26, Height - 3))
        Else
            G.DrawRectangle(InnerBorderGray, New Rectangle(24, 1, Width - 26, Height - 3))
        End If
        DrawBorders(OuterBorder)
        '---TOPLEFT---

        If _Col = _Color.Green Then
            DrawPixel(ExtraPixelGreen, 1, 2)
            DrawPixel(ExtraPixelGreen, 2, 1)
            DrawPixel(InnerBorderGreen.Color, 2, 2)
        ElseIf _Col = _Color.Yellow Then
            DrawPixel(ExtraPixelYellow, 1, 2)
            DrawPixel(ExtraPixelYellow, 2, 1)
            DrawPixel(InnerBorderYellow.Color, 2, 2)
        ElseIf _Col = _Color.Violet Then
            DrawPixel(ExtraPixelViolet, 1, 2)
            DrawPixel(ExtraPixelViolet, 2, 1)
            DrawPixel(InnerBorderViolet.Color, 2, 2)
        Else
            DrawPixel(ExtraPixelRed, 1, 2)
            DrawPixel(ExtraPixelRed, 2, 1)
            DrawPixel(InnerBorderRed.Color, 2, 2)
        End If
        DrawPixel(OuterBorder.Color, 1, 1)
        '---BOTLEFT---
        DrawPixel(Color.FromArgb(51, 51, 51), 0, Height - 1)
        DrawPixel(Color.FromArgb(51, 51, 51), 1, Height - 1)
        DrawPixel(Color.FromArgb(51, 51, 51), 0, Height - 2)

        If _Col = _Color.Green Then
            DrawPixel(InnerBorderGreen.Color, 2, Height - 3)
            DrawPixel(ExtraPixelGreen, 1, Height - 3)
            DrawPixel(ExtraPixelGreen, 2, Height - 2)
        ElseIf _Col = _Color.Yellow Then
            DrawPixel(InnerBorderYellow.Color, 2, Height - 3)
            DrawPixel(ExtraPixelYellow, 1, Height - 3)
            DrawPixel(ExtraPixelYellow, 2, Height - 2)
        ElseIf _Col = _Color.Violet Then
            DrawPixel(InnerBorderViolet.Color, 2, Height - 3)
            DrawPixel(ExtraPixelViolet, 1, Height - 3)
            DrawPixel(ExtraPixelViolet, 2, Height - 2)
        Else
            DrawPixel(InnerBorderRed.Color, 2, Height - 3)
            DrawPixel(ExtraPixelRed, 1, Height - 3)
            DrawPixel(ExtraPixelRed, 2, Height - 2)
        End If
        DrawPixel(OuterBorder.Color, 1, Height - 2)

        '---ICON---
        If DisplayIcon = _Icon.Square Then
            DrawGradient(SquareColor, SquareColor, New Rectangle(7, 9, 5, 5))
            DrawGradient(SquareColor, SquareColor, New Rectangle(13, 9, 5, 5))
            DrawGradient(SquareColor, SquareColor, New Rectangle(7, 15, 5, 5))
            DrawGradient(SquareColor, SquareColor, New Rectangle(13, 15, 5, 5))
        ElseIf DisplayIcon = _Icon.Circle Then
            G.SmoothingMode = SmoothingMode.HighQuality
            G.DrawEllipse(New Pen(CircleColor), 6, 8, 12, 12)
            G.FillEllipse(New SolidBrush(CircleColor), 8, 10, 8, 8)
        ElseIf DisplayIcon = _Icon.Triangle Then
            G.SmoothingMode = SmoothingMode.HighQuality
            Dim Points(2) As Point
            Points(0) = New Point(3, 7)
            Points(1) = New Point(10, 7)
            Points(2) = New Point(7, 19)
            G.DrawPolygon(New Pen(TriangleColor, 2), Points)
            Points(0) = New Point(14, 7)
            Points(1) = New Point(21, 7)
            Points(2) = New Point(17, 19)
            G.DrawPolygon(New Pen(TriangleColor, 2), Points)
            Points(0) = New Point(9, 23)
            Points(1) = New Point(15, 23)
            Points(2) = New Point(12, 11)
            G.DrawPolygon(New Pen(TriangleColor, 2), Points)
        ElseIf DisplayIcon = _Icon.Custom_Image Then
            G.DrawImage(Image, 5, 8, 16, 16)
        Else
            DrawGradient(SquareColor, SquareColor, New Rectangle(7, 9, 5, 5))
            DrawGradient(SquareColor, SquareColor, New Rectangle(13, 9, 5, 5))
            DrawGradient(SquareColor, SquareColor, New Rectangle(7, 15, 5, 5))
            DrawGradient(SquareColor, SquareColor, New Rectangle(13, 15, 5, 5))
        End If

        DrawText(TextCol, HorizontalAlignment.Center, 0, 0)
        DrawPixel(Color.FromArgb(51, 51, 51), 0, 0)
        DrawPixel(Color.FromArgb(51, 51, 51), 1, 0)
        DrawPixel(Color.FromArgb(51, 51, 51), 0, 1)
        DrawPixel(Color.FromArgb(51, 51, 51), 0, Height - 1)
        DrawPixel(Color.FromArgb(51, 51, 51), 1, Height - 1)
        DrawPixel(Color.FromArgb(51, 51, 51), 0, Height - 2)

    End Sub
End Class
Class dscGroupDropBox
    Inherits ThemeContainerControl
    Private _Checked As Boolean
    Private X As Integer
    Private y As Integer
    Private _OpenedSize As Size

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal V As Boolean)
            _Checked = V
            Invalidate()
        End Set
    End Property
    Public Property OpenSize As Size
        Get
            Return _OpenedSize
        End Get
        Set(ByVal V As Size)
            _OpenedSize = V
            Invalidate()
        End Set
    End Property
    Sub New()
        AllowTransparent()
        Size = New Size(90, 30)
        MinimumSize = New Size(5, 30)
        _Checked = True
    End Sub
    Overrides Sub PaintHook()
        Me.Font = New Font("Tahoma", 10)
        Me.ForeColor = Color.FromArgb(121, 121, 121)
        If _Checked = True Then
            G.SmoothingMode = SmoothingMode.HighQuality
            G.Clear(Color.FromArgb(41, 41, 41))
            G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, Width, 30))
            G.DrawLine(New Pen(Color.FromArgb(37, 37, 37)), 1, 1, Width - 2, 1)
            G.DrawRectangle(New Pen(Color.FromArgb(37, 37, 37)), 0, 0, Width - 1, Height - 1)
            G.DrawRectangle(New Pen(Color.FromArgb(37, 37, 37)), 0, 0, Width - 1, 30)
            Me.Size = _OpenedSize
            G.DrawString("t", New Font("Marlett", 12), New SolidBrush(Me.ForeColor), Width - 25, 5)
        Else
            G.SmoothingMode = SmoothingMode.AntiAlias
            G.Clear(Color.FromArgb(41, 41, 41))
            G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, Width, 30))
            G.DrawLine(New Pen(Color.FromArgb(37, 37, 37)), 1, 1, Width - 2, 1)
            G.DrawRectangle(New Pen(Color.FromArgb(37, 37, 37)), 0, 0, Width - 1, Height - 1)
            G.DrawRectangle(New Pen(Color.FromArgb(37, 37, 37)), 0, 0, Width - 1, 30)
            Me.Size = New Size(Width, 30)
            G.DrawString("u", New Font("Marlett", 12), New SolidBrush(Me.ForeColor), Width - 25, 5)
        End If
        G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), 7, 6)
    End Sub

    Private Sub meResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If _Checked = True Then
            _OpenedSize = Me.Size
        Else
        End If
    End Sub


    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X
        y = e.Y
        Invalidate()
    End Sub

    Sub changeCheck() Handles Me.MouseDown

        If X >= Width - 22 Then
            If y <= 30 Then
                Select Case Checked
                    Case True
                        Checked = False
                    Case False
                        Checked = True
                End Select
            End If
        End If
    End Sub
End Class
Class dscButtonBlackBG
    Inherits ThemeControl154

    Sub New()
    End Sub
    Private TopGradient, BotGradient As Color
    Private TopGradientClick, BotGradientClick As Color
    Private TopGradientHover, BotGradientHover As Color
    Private InnerBorder, OuterBorder, InnerBorderHover, OuterBorderHover, InnerBorderClick, OuterBorderClick As Pen
    Private TextCol As SolidBrush
    Protected Overrides Sub ColorHook()
        TopGradient = Color.FromArgb(55, 55, 55)
        BotGradient = Color.FromArgb(32, 32, 32)

        TopGradientHover = Color.FromArgb(66, 66, 66)
        BotGradientHover = Color.FromArgb(41, 41, 41)

        TopGradientClick = Color.FromArgb(60, 60, 60)
        BotGradientClick = Color.FromArgb(37, 37, 37)

        TextCol = New SolidBrush(Color.FromArgb(204, 204, 204))

        OuterBorder = New Pen(Color.Black)
        InnerBorder = New Pen(Color.FromArgb(76, 76, 76))

        OuterBorderHover = New Pen(Color.Black)
        InnerBorderHover = New Pen(Color.FromArgb(87, 87, 87))

        OuterBorderClick = New Pen(Color.Black)
        InnerBorderClick = New Pen(Color.FromArgb(71, 71, 71))
    End Sub

    Protected Overrides Sub PaintHook()

        If State = MouseState.Down Then
            DrawGradient(TopGradientClick, BotGradientClick, New Rectangle(2, 1, Width - 4, Height - 3), 90.0F)
            G.DrawRectangle(InnerBorderClick, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3)
            'TOPLEFT
            DrawPixel(OuterBorderClick.Color, 1, 1)
            DrawPixel(InnerBorderClick.Color, 2, 2)
            'TOPRIGHT
            DrawPixel(OuterBorderClick.Color, Width - 2, 1)
            DrawPixel(InnerBorderClick.Color, Width - 3, 2)
            'BOTTOMLEFT
            DrawPixel(OuterBorderClick.Color, 1, Height - 2)
            DrawPixel(InnerBorderClick.Color, 1, Height - 3)
            'BOTTOMRIGHT
            DrawPixel(OuterBorderClick.Color, Width - 2, Height - 2)
            DrawPixel(InnerBorderClick.Color, Width - 3, Height - 3)
            DrawBorders(OuterBorderClick)
        Else
            DrawGradient(TopGradient, BotGradient, New Rectangle(2, 1, Width - 4, Height - 3), 90.0F)
            G.DrawRectangle(InnerBorder, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3)
            'TOPLEFT
            DrawPixel(OuterBorder.Color, 1, 1)
            DrawPixel(InnerBorder.Color, 2, 2)
            'TOPRIGHT
            DrawPixel(OuterBorder.Color, Width - 2, 1)
            DrawPixel(InnerBorder.Color, Width - 3, 2)
            'BOTTOMLEFT
            DrawPixel(OuterBorder.Color, 1, Height - 2)
            DrawPixel(InnerBorder.Color, 1, Height - 3)
            'BOTTOMRIGHT
            DrawPixel(OuterBorder.Color, Width - 2, Height - 2)
            DrawPixel(InnerBorder.Color, Width - 3, Height - 3)
            DrawBorders(OuterBorder)
        End If

        If State = MouseState.Over Then
            DrawGradient(TopGradientHover, BotGradientHover, New Rectangle(2, 1, Width - 4, Height - 3), 90.0F)
            G.DrawRectangle(InnerBorderHover, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3)
            'TOPLEFT
            DrawPixel(OuterBorderHover.Color, 1, 1)
            DrawPixel(InnerBorderHover.Color, 2, 2)
            'TOPRIGHT
            DrawPixel(OuterBorderHover.Color, Width - 2, 1)
            DrawPixel(InnerBorderHover.Color, Width - 3, 2)
            'BOTTOMLEFT
            DrawPixel(OuterBorderHover.Color, 1, Height - 2)
            DrawPixel(InnerBorderHover.Color, 1, Height - 3)
            'BOTTOMRIGHT
            DrawPixel(OuterBorderHover.Color, Width - 2, Height - 2)
            DrawPixel(InnerBorderHover.Color, Width - 3, Height - 3)
            DrawBorders(OuterBorderHover)
        End If

        DrawText(TextCol, HorizontalAlignment.Center, 0, 0)

        DrawCorners(Color.FromArgb(34, 34, 34))
    End Sub
End Class