' Developer Express Code Central Example:
' How to apply different templates to NavBarItem's (using the ItemTemplateSelector property)
' 
' Implement several templates, inherit from the DataTemplateSelector class,
' override the SelectTemplate method. In this method, based on the NavBarItem
' template assign the necessary template
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2850


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.NavBar

Namespace SilverlightApplication1
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			navbar.Groups(0).ItemTemplateSelector = New CustomItemTemplateSelector() With {.NavBar = navbar}
		End Sub
	End Class

	Public Class CustomItemTemplateSelector
		Inherits DataTemplateSelector
		Public Property NavBar() As NavBarControl
		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim info As NavBarObjectInfo = TryCast(item, NavBarObjectInfo)
			If info Is Nothing Then
				Return MyBase.SelectTemplate(item, container)
			End If
			Dim navBarItem As NavBarItem = TryCast(info.Element, NavBarItem)
			If navBarItem Is Nothing Then
				Return MyBase.SelectTemplate(item, container)
			End If
			Select Case navBarItem.Content.ToString()
				Case "Item Red"
					Return CType(NavBar.Resources("RedContentTemplate"), DataTemplate)
				Case "Item Green"
					Return CType(NavBar.Resources("GreenContentTemplate"), DataTemplate)
				Case "Item Blue"
					Return CType(NavBar.Resources("BlueContentTemplate"), DataTemplate)
				Case Else
					Return Nothing
			End Select
		End Function
	End Class
End Namespace