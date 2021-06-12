USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadAllTicket
AS
BEGIN
	SELECT Id, EventSeatId, UserId
	FROM Ticket
END;