USE TicketManagementPractice;
GO
CREATE PROCEDURE UpdateVenue
	@Id INT,
	@Descr NVARCHAR(100),
	@Addr NVARCHAR(60),
	@Phone NVARCHAR(15)
AS
BEGIN
	UPDATE Venue SET [Description] = @Descr, [Address] = @Addr, Phone = @Phone
	WHERE Id = @Id
END;