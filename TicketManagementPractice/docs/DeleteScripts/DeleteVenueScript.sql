USE TicketManagementPractice;
GO
CREATE PROCEDURE DeleteVenue
	@Id INT
AS
BEGIN
	DELETE FROM Venue WHERE Id = @Id
END;