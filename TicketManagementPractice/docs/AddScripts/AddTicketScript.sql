USE TicketManagementPractice;
GO
CREATE PROCEDURE AddTicket
	@EventSeatId INT,
	@UserId INT
AS
BEGIN
	DECLARE @Id INT = (SELECT MAX(Id) FROM Ticket) + 1;
	INSERT INTO Ticket(Id, EventSeatId, UserId)
	VALUES (@Id, @EventSeatId, @UserId)
END;