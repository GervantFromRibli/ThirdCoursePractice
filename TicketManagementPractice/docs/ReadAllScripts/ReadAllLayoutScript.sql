USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadAllLayout
AS
BEGIN
	SELECT Id, VenueId, [Description]
	FROM Layout
END;