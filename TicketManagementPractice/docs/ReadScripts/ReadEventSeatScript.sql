USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadEventSeat
	@Id INT
AS
BEGIN
	SELECT Id, EventAreaId, [Row], Number, [State]
	FROM EventSeat WHERE Id = @Id
END;