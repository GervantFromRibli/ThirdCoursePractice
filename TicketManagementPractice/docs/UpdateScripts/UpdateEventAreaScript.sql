USE TicketManagementPractice;
GO
CREATE PROCEDURE UpdateEventArea
	@Id INT,
	@EventId INT,
	@Descr NVARCHAR(100),
	@StartX INT,
	@StartY INT,
	@EndX INT,
	@EndY INT,
	@Price DECIMAL
AS
BEGIN
	UPDATE EventArea SET EventId = @EventId, [Description] = @Descr, StartCoordX = @StartX, StartCoordY = @StartY, 
	EndCoordX = @EndX, EndCoordY = @EndY, Price = @Price WHERE Id = @Id
END;