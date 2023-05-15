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
	 declare @audit_data varchar(150)
	 declare cur_deleted cursor for select id from deleted
	 open cur_deleted
	 fetch next from cur_deleted into @id
	 while @@fetch_status = 0 
	 begin 
	  set @audit_data = 'Employee with ID = ' + cast(@id as nvarchar(10)) + ' is deleted at ' + cast(Getdate() as nvarchar(20))
	 insert into Audit(audit_data) values (@audit_data)
	 fetch next from cur_deleted into @id
	 end
	 close cur_deleted
	 deallocate cur_deleted
end
delete from Employee where id in( 4,6);
select * from Employee;
select * from Audit;

