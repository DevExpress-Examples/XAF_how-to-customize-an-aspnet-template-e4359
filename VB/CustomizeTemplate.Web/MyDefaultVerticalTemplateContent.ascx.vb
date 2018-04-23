Imports System.Web.UI
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Web.Controls
Imports DevExpress.ExpressApp.Web.Templates.ActionContainers
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Web.Templates
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Web.SystemModule

Namespace CustomizeTemplate.Web
    Partial Public Class MyDefaultVerticalTemplateContent
        Inherits TemplateContent
        Implements IXafPopupWindowControlContainer, IXafSecurityActionContainerHolder

        Shared Sub New()
            AdditionalClass = "sizeLimit"
        End Sub
        Public Shared Sub ClearSizeLimit()
            AdditionalClass = ""
        End Sub
        Public Shared Property AdditionalClass() As String

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            Page.ClientScript.RegisterClientScriptResource(GetType(WebWindow), "DevExpress.ExpressApp.Web.Resources.JScripts.XafNavigation.js")
            Page.ClientScript.RegisterClientScriptResource(GetType(WebWindow), "DevExpress.ExpressApp.Web.Resources.JScripts.XafFooter.js")
            Page.ClientScript.RegisterClientScriptResource(GetType(WebWindow), "DevExpress.ExpressApp.Web.Resources.JScripts.DefaultVerticalTemplate.js")
            If WebWindow.CurrentRequestWindow IsNot Nothing Then
                AddHandler WebWindow.CurrentRequestWindow.PagePreRender, AddressOf CurrentRequestWindow_PagePreRender
            End If
        End Sub
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)
            Dim modelApplicationNavigationItems As IModelApplicationNavigationItems = CType(WebApplication.Instance.Model, IModelApplicationNavigationItems)
            Dim showNavigationOnStart As Boolean = CType(modelApplicationNavigationItems.NavigationItems, IModelRootNavigationItemsWeb).ShowNavigationOnStart
            ClientParams.Set("ShowNavigationPanelOnStart", showNavigationOnStart)
            If (Not showNavigationOnStart) AndAlso (Not navigation.CssClass.Contains("xafHidden")) Then
                navigation.CssClass &= " xafHidden"
            End If
            WebApplication.Instance.ClientInfo.SetInfo(ClientParams)
        End Sub
        Private Sub CurrentRequestWindow_PagePreRender(ByVal sender As Object, ByVal e As EventArgs)
            Dim window As WebWindow = CType(sender, WebWindow)
            window.RegisterStartupScript("Init", "Init();")
        End Sub
        Protected Overrides Sub OnUnload(ByVal e As EventArgs)
            If WebWindow.CurrentRequestWindow IsNot Nothing Then
                RemoveHandler WebWindow.CurrentRequestWindow.PagePreRender, AddressOf CurrentRequestWindow_PagePreRender
            End If
            MyBase.OnUnload(e)
        End Sub
        Public Overrides Sub SetStatus(ByVal statusMessages As ICollection(Of String))
        End Sub
        Public Overrides ReadOnly Property DefaultContainer() As IActionContainer
            Get
                If mainMenu IsNot Nothing Then
                    Return mainMenu.FindActionContainerById("View")
                End If
                Return Nothing
            End Get
        End Property
        Public Overrides ReadOnly Property ViewSiteControl() As Object
            Get
                Return VSC
            End Get
        End Property
        Public ReadOnly Property XafPopupWindowControl() As XafPopupWindowControl Implements IXafPopupWindowControlContainer.XafPopupWindowControl
            Get
                Return PopupWindowControl
            End Get
        End Property
        Public Overrides Sub BeginUpdate()
            MyBase.BeginUpdate()
            Me.SAC.BeginUpdate()
            Me.mainMenu.BeginUpdate()
            Me.SearchAC.BeginUpdate()
        End Sub
        Public Overrides Sub EndUpdate()
            Me.SAC.EndUpdate()
            Me.mainMenu.EndUpdate()
            Me.SearchAC.EndUpdate()
            MyBase.EndUpdate()
        End Sub
        Private ReadOnly Property IXafSecurityActionContainerHolder_SecurityActionContainerHolder() As ActionContainerHolder Implements IXafSecurityActionContainerHolder.SecurityActionContainerHolder
            Get
                Return SAC
            End Get
        End Property
    End Class
End Namespace
