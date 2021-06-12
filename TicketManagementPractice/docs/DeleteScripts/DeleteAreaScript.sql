USE TicketManagementPractice;
GO
CREATE PROCEDURE DeleteArea
	@Id INT
AS
BEGIN
	DELETE FROM Area WHERE Id = @Id
END;