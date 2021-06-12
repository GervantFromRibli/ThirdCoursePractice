USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadArea
	@Id INT
AS
BEGIN
	SELECT Id, LayoutId, [Description], StartCoordX, StartCoordY, 
	EndCoordX, EndCoordY FROM Area WHERE Id = @Id
END;