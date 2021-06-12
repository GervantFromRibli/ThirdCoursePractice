USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadTicket
	@Id INT
AS
BEGIN
	SELECT Id, EventSeatId, UserId
	FROM Ticket WHERE Id = @Id
END;