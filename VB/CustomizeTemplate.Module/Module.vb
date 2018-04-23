Imports System.Text
Imports System.Linq
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Model.DomainLogics
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports System.Data.Entity
Imports CustomizeTemplate.Module.BusinessObjects

Namespace CustomizeTemplate.Module
    ' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    Public NotInheritable Partial Class CustomizeTemplateModule
        Inherits ModuleBase

        Shared Sub New()
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = GetType(System.Data.Entity.SqlServer.SqlFunctions)
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = GetType(System.Data.Entity.DbFunctions)
            ' Uncomment this code to delete and recreate the database each time the data model has changed.
            ' Do not use this code in a production environment to avoid data loss.
            ' #if DEBUG
            ' Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomizeTemplateDbContext>());
            ' #endif 
        End Sub
        Public Sub New()
            InitializeComponent()
        End Sub
        Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
            Dim updater As ModuleUpdater = New DatabaseUpdate.Updater(objectSpace, versionFromDB)
            Return New ModuleUpdater() { updater }
        End Function
        Public Overrides Sub Setup(ByVal application As XafApplication)
            MyBase.Setup(application)
            ' Manage various aspects of the application UI and behavior at the module level.
        End Sub
    End Class
End Namespace
