USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadEventArea
	@Id INT
AS
BEGIN
	SELECT Id, EventId, [Description], StartCoordX, StartCoordY, 
	EndCoordX, EndCoordY, Price FROM EventArea WHERE Id = @Id
END;