USE TicketManagementPractice;
GO
CREATE PROCEDURE AddLayout
	@VenueId INT,
	@Descr NVARCHAR(100)
AS
BEGIN
	DECLARE @Id INT = (SELECT MAX(Id) FROM Layout) + 1;
	INSERT INTO Layout(Id, VenueId, [Description])
	VALUES (@Id, @VenueId, @Descr)
END;