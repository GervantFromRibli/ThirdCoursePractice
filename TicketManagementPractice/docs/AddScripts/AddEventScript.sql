USE TicketManagementPractice;
GO
CREATE PROCEDURE AddEvent
	@Name NVARCHAR(20),
	@Descr NVARCHAR(100),
	@LayoutId INT,
	@StartDate DATETIME,
	@EndDate DATETIME
AS
BEGIN
	DECLARE @Id INT = (SELECT MAX(Id) FROM [Event]) + 1;
	INSERT INTO [Event](Id, [Name], [Description], LayoutId, StartDate, EndDate)
	VALUES (@Id, @Name, @Descr, @LayoutId, @StartDate, @EndDate)
END;