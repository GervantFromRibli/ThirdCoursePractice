USE TicketManagementPractice;
GO
CREATE PROCEDURE DeleteEvent
	@Id INT
AS
BEGIN
	DELETE FROM [Event] WHERE Id = @Id
END;