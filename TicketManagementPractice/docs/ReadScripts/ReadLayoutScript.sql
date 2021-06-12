USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadLayout
	@Id INT
AS
BEGIN
	SELECT Id, VenueId, [Description]
	FROM Layout WHERE Id = @Id
END;