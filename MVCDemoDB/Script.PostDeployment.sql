if not exists (select 1 from [dbo].[Employee])
begin
	insert into dbo.[Employee]
	(EmployeeId, FirstName, LastName, EmailAddress)
	values
	(123450, 'Ramin', 'Anvar', 'ra@gmail.com'),
	(123451, 'Afshin', 'Anvar', 'ga@gmail.com'),
	(123452, 'David', 'Tehrani', 'dt@gmail.com'),
	(123453, 'Hassan', 'Ranjbar', 'hr@gmail.com');
end
