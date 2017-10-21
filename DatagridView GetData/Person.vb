Public Class Person
    Property Name As String = ""
    Property EmailAddress As String = ""
    Property Birthdate As Date = Now.Date.AddYears(-18).AddMonths(-3).AddDays(-12)
    Public Overrides Function ToString() As String
        Return $"Name:{Name} Birthday:{Birthdate.ToShortDateString} Email:{EmailAddress}"
    End Function
End Class
