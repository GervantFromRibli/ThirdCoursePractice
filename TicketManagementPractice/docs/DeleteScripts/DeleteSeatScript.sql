USE TicketManagementPractice;
GO
CREATE PROCEDURE DeleteSeat
	@Id INT
AS
BEGIN
	DELETE FROM Seat WHERE Id = @Id
END;