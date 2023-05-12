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
   
create trigger tr_Employee_afterUpdate 
on Employee
after update
as begin
	 declare @id int 
	 declare @audit_data varchar(255)
	 declare @emp_name varchar(50)
	 declare @salary decimal(10,2)
	 declare @gender char(1)
	 declare @departmentid int
	 
	 declare cur_updated cursor for select id from inserted
	 open cur_updated
	 fetch next from cur_updated into @id
	 while @@fetch_status = 0 
	 begin 
	  select @emp_name = i.emp_name, @salary = i.salary, @gender = i.gender, @departmentid = i.departmentid from inserted i where i.id = @id
	  select @audit_data = 'Employee with ID = ' + cast(@id as nvarchar(10)) 
	  if update(emp_name) 
	  	set @audit_data = @audit_data + ', Emp Name changed from ' + (select d.emp_name from deleted d where d.id = @id) + ' to ' + @emp_name
	  if update(salary) 
	  	set @audit_data = @audit_data + ', Salary changed from ' + cast((select d.salary from deleted d where d.id = @id) as varchar(10)) + ' to ' + cast(@salary as varchar(10))
	  if update(gender) 
	  	set @audit_data = @audit_data + ', Gender changed from ' + (select d.gender from deleted d where d.id = @id) + ' to ' + @gender
	  if update(departmentid) 
	  	set @audit_data = @audit_data + ', Department ID changed from ' + cast((select d.departmentid from deleted d where d.id = @id) as varchar(10)) + ' to ' + cast(@departmentid as varchar(10))
	  
	  set @audit_data = @audit_data + ' at ' + cast(Getdate() as nvarchar(20))
	  
	  insert into Audit(audit_data) values (@audit_data)
	  fetch next from cur_updated into @id
	 end
	 close cur_updated
	 deallocate cur_updated
end

update Employee set salary = 70000 where id in (2,4,3);
select * from Employee;
select * from Audit;

