USE TicketManagementPractice;
GO
CREATE PROCEDURE UpdateArea
	@Id INT,
	@LayoutId INT,
	@Descr NVARCHAR(100),
	@StartX INT,
	@StartY INT,
	@EndX INT,
	@EndY INT
AS
BEGIN
	UPDATE Area SET LayoutId = @LayoutId, [Description] = @Descr, StartCoordX = @StartX, StartCoordY = @StartY, 
	EndCoordX = @EndX, EndCoordY = @EndY WHERE Id = @Id
END;