USE TicketManagementPractice;
GO
CREATE PROCEDURE CheckExistEvent
	@LayoutId INT,
	@StartDate DATETIME,
	@EndDate DATETIME,
	@Result INT OUTPUT
AS
	SELECT @Result = SUM(Id) FROM [Event] WHERE LayoutId = @LayoutId AND NOT (@StartDate > EndDate OR @EndDate < StartDate)
RETURN 0