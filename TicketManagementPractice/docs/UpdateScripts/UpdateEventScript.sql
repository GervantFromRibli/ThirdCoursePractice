USE TicketManagementPractice;
GO
CREATE PROCEDURE UpdateEvent
	@Id INT,
	@Name NVARCHAR(20),
	@Descr NVARCHAR(100),
	@LayoutId INT,
	@StartDate DATETIME,
	@EndDate DATETIME
AS
BEGIN
	UPDATE Event SET [Name] = @Name, [Description] = @Descr, LayoutId = @LayoutId, StartDate = @StartDate, EndDate = @EndDate
	WHERE Id = @Id
END;