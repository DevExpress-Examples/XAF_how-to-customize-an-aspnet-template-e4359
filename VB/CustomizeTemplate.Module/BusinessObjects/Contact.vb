Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl.EF
Imports System.ComponentModel

Namespace CustomizeTemplate.Module.BusinessObjects
    <DefaultClassOptions> _
    Public Class Contact
        Private privateID As Int32
        <Browsable(False)> _
        Public Property ID() As Int32
            Get
                Return privateID
            End Get
            Protected Set(ByVal value As Int32)
                privateID = value
            End Set
        End Property
        Public Property LastName() As String
        Public Property FirstName() As String
    End Class
End Namespace

