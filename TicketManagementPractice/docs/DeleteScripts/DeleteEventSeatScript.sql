USE TicketManagementPractice;
GO
CREATE PROCEDURE DeleteEventSeat
	@Id INT
AS
BEGIN
	DELETE FROM EventSeat WHERE Id = @Id
END;