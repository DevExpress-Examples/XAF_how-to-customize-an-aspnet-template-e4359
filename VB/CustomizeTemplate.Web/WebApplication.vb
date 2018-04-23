Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.EF
Imports CustomizeTemplate.Module.BusinessObjects
Imports System.Data.Common

Namespace CustomizeTemplate.Web
    ' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
    Partial Public Class CustomizeTemplateAspNetApplication
        Inherits WebApplication

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As CustomizeTemplate.Module.CustomizeTemplateModule
        Private module4 As CustomizeTemplate.Module.Web.CustomizeTemplateAspNetModule

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            If args.Connection IsNot Nothing Then
                args.ObjectSpaceProvider = New EFObjectSpaceProvider(GetType(CustomizeTemplateDbContext), TypesInfo, Nothing, CType(args.Connection, DbConnection))
            Else
                args.ObjectSpaceProvider = New EFObjectSpaceProvider(GetType(CustomizeTemplateDbContext), TypesInfo, Nothing, args.ConnectionString)
            End If
            args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
        End Sub
        Private Sub CustomizeTemplateAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            Else
                Dim message As String = "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & vbCrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & vbCrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & vbCrLf & "Anyway, refer to the following help topics for more detailed information:" & vbCrLf & "'Update Application and Database Versions' at http://help.devexpress.com/#Xaf/CustomDocument2795" & vbCrLf & "'Database Security References' at http://help.devexpress.com/#Xaf/CustomDocument3237" & vbCrLf & "If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/"

                If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
                    message &= vbCrLf & vbCrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
                End If
                Throw New InvalidOperationException(message)
            End If
#End If
        End Sub
        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New CustomizeTemplate.Module.CustomizeTemplateModule()
            Me.module4 = New CustomizeTemplate.Module.Web.CustomizeTemplateAspNetModule()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' CustomizeTemplateAspNetApplication
            ' 
            Me.ApplicationName = "CustomizeTemplate"
            Me.LinkNewObjectToParentImmediately = False
            Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module4)
'            Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.CustomizeTemplateAspNetApplication_DatabaseVersionMismatch)
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
