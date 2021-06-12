USE TicketManagementPractice;
GO
CREATE PROCEDURE DeleteTicket
	@Id INT
AS
BEGIN
	DELETE FROM Ticket WHERE Id = @Id
END;