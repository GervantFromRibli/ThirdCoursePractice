USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadAllArea
AS
BEGIN
	SELECT Id, LayoutId, [Description], StartCoordX, StartCoordY, 
	EndCoordX, EndCoordY FROM Area
END;