USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadAllVenue
AS
BEGIN
	SELECT Id, [Description], [Address], Phone
	FROM Venue
END;