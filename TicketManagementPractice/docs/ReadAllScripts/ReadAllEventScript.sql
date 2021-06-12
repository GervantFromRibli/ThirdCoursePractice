USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadAllEvent
AS
BEGIN
	SELECT Id, [Name], [Description], LayoutId, StartDate, EndDate
	FROM [Event]
END;