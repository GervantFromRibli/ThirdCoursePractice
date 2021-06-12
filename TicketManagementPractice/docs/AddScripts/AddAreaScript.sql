USE TicketManagementPractice;
GO
CREATE PROCEDURE AddArea
	@LayoutId INT,
	@Descr NVARCHAR(100),
	@StartX INT,
	@StartY INT,
	@EndX INT,
	@EndY INT
AS
BEGIN
	DECLARE @Id INT = (SELECT MAX(Id) FROM Area) + 1;
	INSERT INTO Area(Id, LayoutId, [Description], StartCoordX, StartCoordY, EndCoordX, EndCoordY)
	VALUES (@Id, @LayoutId, @Descr, @StartX, @StartY, @EndX, @EndY)
END;