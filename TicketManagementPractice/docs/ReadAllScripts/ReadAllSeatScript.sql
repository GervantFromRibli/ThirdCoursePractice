USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadAllSeat
AS
BEGIN
	SELECT Id, AreaId, [Row], Number
	FROM Seat
END;