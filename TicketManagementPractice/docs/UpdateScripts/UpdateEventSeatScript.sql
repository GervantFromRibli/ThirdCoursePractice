USE TicketManagementPractice;
GO
CREATE PROCEDURE UpdateEventSeat
	@Id INT,
	@EventAreaId INT,
	@Row INT,
	@Number INT,
	@State NVARCHAR(10)
AS
BEGIN
	UPDATE EventSeat SET EventAreaId = @EventAreaId, [Row] = @Row, Number = @Number, [State] = @State
	WHERE Id = @Id
END;