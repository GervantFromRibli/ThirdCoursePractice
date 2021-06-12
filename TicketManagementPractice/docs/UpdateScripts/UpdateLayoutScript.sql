USE TicketManagementPractice;
GO
CREATE PROCEDURE UpdateLayout
	@Id INT,
	@VenueId INT,
	@Descr NVARCHAR(100)
AS
BEGIN
	UPDATE Layout SET VenueId = @VenueId, [Description] = @Descr
	WHERE Id = @Id
END;