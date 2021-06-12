USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadAllEventArea
AS
BEGIN
	SELECT Id, EventId, [Description], StartCoordX, StartCoordY, 
	EndCoordX, EndCoordY, Price FROM EventArea
END;