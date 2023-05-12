create database Sql_practice;
use Sql_practice;

create table Employee (
  id int NOT NULL primary key,
  emp_name varchar(50) not null,
  salary decimal(10, 2) not null,
  gender char(1) not null,
  departmentid int not null
);

create table Audit (
  id INT not null PRIMARY KEY identity(1,1),
  audit_data VARCHAR(255) not null
);

insert into Employee (id, emp_name, salary, gender, departmentid)
values (1, 'Hiren', 50000.00, 'M', 1),
       (2, 'Hitesha', 60000.00, 'F', 2),
	   (3, 'Jenish', 55000.00, 'M', 1),
       (4, 'Hitanshi', 65000.00, 'F', 3),
       (5, 'Mihir', 70000.00, 'M', 2),
       (6, 'Mona', 75000.00, 'F', 3);
   
create trigger tr_Employee_forDelete 
on Employee
for delete
as begin
	 declare @id int 
	 declare @name varchar(20) 
	 declare @audit_data varchar(150)

	 select @id = id , @name = emp_name from deleted
	  
	  set @audit_data = 'Employee with ID = ' + cast(@id as nvarchar(10)) + ' is deleted at ' + cast(Getdate() as nvarchar(20))
	 insert into Audit(audit_data) values (@audit_data)
end
delete from Employee where id = 4;
select * from Employee;
select * from Audit;

