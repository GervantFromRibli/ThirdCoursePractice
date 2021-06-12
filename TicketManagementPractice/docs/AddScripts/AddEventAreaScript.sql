USE TicketManagementPractice;
GO
CREATE PROCEDURE AddEventArea
	@EventId INT,
	@Descr NVARCHAR(100),
	@StartX INT,
	@StartY INT,
	@EndX INT,
	@EndY INT,
	@Price DECIMAL
AS
BEGIN
	DECLARE @Id INT = (SELECT MAX(Id) FROM EventArea) + 1;
	INSERT INTO EventArea(Id, EventId, [Description], StartCoordX, StartCoordY, EndCoordX, EndCoordY, Price)
	VALUES (@Id, @EventId, @Descr, @StartX, @StartY, @EndX, @EndY, @Price)
END;