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
       (2, 'Hitesha', 60000.00, 'F', 2);
   
create trigger tr_Employee_forInsert 
on Employee
after insert
as begin
	 declare @id int 
	 declare @audit_data varchar(255)
	 declare @name varchar(20)
	 declare cur_inserted cursor for select id, emp_name from inserted
    open cur_inserted
	fetch next from cur_inserted into @id , @name 
	while @@FETCH_STATUS = 0 
	begin
	set @audit_data = 'New employee with id = ' + cast(@id as nvarchar(5)) + ' and Name = ' + @name + ' is added at ' + cast(getdate() as nvarchar(10))
	 insert into Audit(audit_data) values (@audit_data)
	 fetch next from cur_inserted into @id, @name
	 end
	 close cur_inserted
	 deallocate cur_inserted
end


insert into Employee (id, emp_name, salary, gender, departmentid)
values (3, 'Jenish', 55000.00, 'M', 1),
       (4, 'Hitanshi', 65000.00, 'F', 3),
       (5, 'Mihir', 70000.00, 'M', 2),
       (6, 'Mona', 75000.00, 'F', 3);
       
select * from Employee;
select * from Audit;

