USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadVenue
	@Id INT
AS
BEGIN
	SELECT Id, [Description], [Address], Phone
	FROM Venue WHERE Id = @Id
END;