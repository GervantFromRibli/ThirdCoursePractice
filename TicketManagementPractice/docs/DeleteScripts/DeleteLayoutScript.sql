USE TicketManagementPractice;
GO
CREATE PROCEDURE DeleteLayout
	@Id INT
AS
BEGIN
	DELETE FROM Layout WHERE Id = @Id
END;