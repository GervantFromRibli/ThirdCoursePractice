USE TicketManagementPractice;
GO
CREATE PROCEDURE UpdateTicket
	@Id INT,
	@EventSeatId INT,
	@UserId INT
AS
BEGIN
	UPDATE Ticket SET EventSeatId = @EventSeatId, UserId = @UserId
	WHERE Id = @Id
END;