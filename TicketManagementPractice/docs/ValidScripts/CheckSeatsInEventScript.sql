USE TicketManagementPractice;
GO
CREATE PROCEDURE CheckSeatsInEvent
	@LayoutId INT,
	@Result INT OUTPUT
AS
	SELECT @Result = SUM(Id) FROM Seat WHERE AreaId IN (SELECT Id FROM Area WHERE LayoutId = @LayoutId)
RETURN 0