USE TicketManagementPractice;
GO
CREATE PROCEDURE AddVenue
	@Descr NVARCHAR(100),
	@Addr NVARCHAR(60),
	@Phone NVARCHAR(15)
AS
BEGIN
	DECLARE @Id INT = (SELECT MAX(Id) FROM Venue) + 1;
	INSERT INTO Venue(Id, [Description], [Address], Phone)
	VALUES (@Id, @Descr, @Addr, @Phone)
END;