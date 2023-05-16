create table employee2(
  id int identity(1,1) primary key,
  name varchar(50)not null,
  department_id int not null,
  salary decimal(10, 2) not null,
);

create table department2(
	id int identity(1,1) primary key,
	name varchar(50) not null

);

insert into employee2 (name, department_id, salary) VALUES
('Jay', 1, 100000),
('Rahul', 2, 80000),
('Prit', 3, 60000);

INSERT INTO department2 (name) VALUES
('Sales'),
('Marketing'),
('Development');

alter proc spGetemployeeWithHighestSalary (@department_id int)
as begin 
	declare @highest_salary decimal (10,2);
	declare @employee_id int ;
	declare @employee_name varchar(50);

	---highest salary
	select @highest_salary = max(salary) from employee2 where department_id = @department_id 
	--employee id ,name
	select @employee_id = id,
		   @employee_name = name
			from employee2
			where department_id = @department_id
			and salary = @highest_salary;
			select @employee_id,
			@employee_name;
	return;
	end;

	
	exec spGetemployeeWithHighestSalary 1;
	


create proc spGetEmployeeBySalaryRange (@minsalary money, @maxsalary money)
as begin
	;with cteEmployee as
  (select id,name,salary,department_id from employee2 where salary between @maxsalary and @minsalary)
  select id,name,salary,department_id from cteEmployee
  end 

  exec spGetEmployeeBySalaryRange 5000,10000;