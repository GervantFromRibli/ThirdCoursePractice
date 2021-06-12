USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadAllEventSeat
AS
BEGIN
	SELECT Id, EventAreaId, [Row], Number, [State]
	FROM EventSeat
END;