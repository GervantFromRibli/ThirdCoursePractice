USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadEvent
	@Id INT
AS
BEGIN
	SELECT Id, [Name], [Description], LayoutId, StartDate, EndDate
	FROM [Event] WHERE Id = @Id
END;