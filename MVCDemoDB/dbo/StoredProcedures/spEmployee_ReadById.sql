CREATE PROCEDURE [dbo].[spEmployee_ReadById]
	@Id int
AS
begin
	select [Id], [EmployeeId], [FirstName], [LastName], [EmailAddress]
	from dbo.[Employee]
	where Id = @Id;
end