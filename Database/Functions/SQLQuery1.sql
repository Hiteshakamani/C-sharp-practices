create table professor(
id int primary key identity(1,1),
f_name varchar(10) not null,
l_name varchar(15) not null,
salary money not null,
department_id int not null
);

insert into professor values 
( 'John', 'Doe', 50000, 1),
( 'Jane', 'Smith', 60000, 2),
( 'Bob', 'Jones', 55000, 1),
( 'Sally', 'Johnson', 65000, 2),
( 'Tom', 'Williams', 45000, 1);

create table dep(
id int primary key identity(1,1),
name varchar(15) not null
);

insert into dep values ('IT' ),
('EC');

create function get_avg_salary(@dep_id int)
returns money 
as
begin 
declare @avg_salary money;
select @avg_salary = avg(salary)
from professor
where department_id = @dep_id;
return @avg_salary;
end;

declare @dep_id int = 2; 

select  name,get_avg_salary(@dep_id) as avg_salary from dep;