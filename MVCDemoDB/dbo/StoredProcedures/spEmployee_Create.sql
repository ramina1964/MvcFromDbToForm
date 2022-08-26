CREATE PROCEDURE [dbo].[spEmployee_Create]
	@EmployeeId int,
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@EmailAddress nvarchar(100)
AS
begin
	insert
	into dbo.[Employee]
	(EmployeeId, FirstName, LastName, EmailAddress)
	values
	(@EmployeeId, @FirstName, @LastName, @EmailAddress);
end
