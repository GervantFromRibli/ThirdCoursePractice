USE TicketManagementPractice;
GO
CREATE PROCEDURE DeleteEventArea
	@Id INT
AS
BEGIN
	DELETE FROM EventArea WHERE Id = @Id
END;