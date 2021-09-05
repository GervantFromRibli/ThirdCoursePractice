USE TicketManagementPractice;
GO
CREATE PROCEDURE [dbo].[CreateEvent]
	@name NVARCHAR(120),
	@description NVARCHAR(MAX),
	@layoutId INT,
	@start DATETIME,
	@end DATETIME,
	@imageUrl NVARCHAR(MAX)
AS
	INSERT INTO [Event] ([Name], [Description], LayoutId, StartDate, EndDate, ImagePath)
	VALUES (@name, @description, @layoutId, @start, @end, @imageUrl);

	DECLARE @eventId INT = (SELECT Id FROM [Event] WHERE Id = @@IDENTITY);
	DECLARE @areaId INT;
	DECLARE @eventAreaId INT;

	SELECT * INTO #AreaTemp FROM Area WHERE LayoutId = @layoutId;

	WHILE (SELECT COUNT(*) FROM #AreaTemp) > 0
	BEGIN
		SELECT TOP 1 @areaId = Id FROM #AreaTemp;

		INSERT INTO EventArea (EventId, [Description], StartCoordX, StartCoordY, EndCoordX, EndCoordY, Price)
		SELECT @eventId, Area.[Description], Area.StartCoordX, Area.StartCoordY, Area.EndCoordX, Area.EndCoordY, 1
		FROM Area
		WHERE Id = @areaId;

		SET @eventAreaId = (SELECT Id FROM EventArea WHERE Id = @@IDENTITY);

		INSERT INTO EventSeat (EventAreaId, [Row], Number, [State])
		SELECT @eventAreaId, Seat.[Row], Seat.Number, 'Свободно'
		FROM Seat
		WHERE AreaId = @areaId;

		DELETE #AreaTemp WHERE Id = @areaId;
	END;

	DROP TABLE #AreaTemp;
GO