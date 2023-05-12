create database Sql_practice;
use Sql_practice;

create table Employee (
  id int NOT NULL primary key,
  name varchar(50) not null,
  salary decimal(10, 2) not null,
  gender char(1) not null,
  departmentid int not null
);

create table Audit (
  id INT not null PRIMARY KEY identity(1,1),
  audit_data VARCHAR(255) not null
);

insert into Employee (id, name, salary, gender, departmentid)
values (1, 'Hiren', 50000.00, 'M', 1),
       (2, 'Hitesha', 60000.00, 'F', 2);
   
create trigger tr_Employee_forInsert 
on Employee
for insert
as begin
	 declare @id int 
	 select @id = id from inserted
	  
	 insert into Audit(audit_data)
	 values ('New employee with ID = ' + cast(@id as nvarchar(10)) + ' is added at ' + cast(Getdate() as nvarchar(20)))
end
insert into Employee (id, name, salary, gender, departmentid)
values (3, 'Jenish', 55000.00, 'M', 1),
       (4, 'Hitanshi', 65000.00, 'F', 3),
       (5, 'Mihir', 70000.00, 'M', 2),
       (6, 'Mona', 75000.00, 'F', 3);
select * from Employee;
select * from Audit;

