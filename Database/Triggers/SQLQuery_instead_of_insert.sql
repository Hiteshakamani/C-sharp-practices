use Sql_practice;

create table Worker(
id int primary key,
worker_name varchar(10) not null,
gender varchar(5) not null,
department_id int not null
);

create table department (
id int primary key identity,
name varchar(10) not null
);

create view worker_department_view as 
select w.id as worker_id, w.worker_name, w.gender, d.name as department_name, d.id as department_id from Worker w
join department d on w.department_id = d.id;

create trigger tr_worker_department_insert 
on worker_department_view 
instead of insert 
as begin

insert into department(name)
select i.department_name 
from inserted i 
where i.department_name is not null

insert into worker (id,worker_name,gender,department_id)
select i.worker_id,i.worker_name,i.gender,d.id from inserted i 
join department d  on i.department_name = d.name
where i.worker_id is not null and i.worker_name is not null and i.gender is not null
end;



insert into worker_department_view(worker_id, worker_name, gender, department_name)
values (1, 'Harsh', 'M', 'Intern');
insert into worker_department_view(worker_id, worker_name, gender, department_name)
values (2, 'Hitesha', 'M', 'Employee');
insert into worker_department_view(worker_id, worker_name, gender, department_name)
values (3, 'Jay', 'M', 'Hr');
insert into worker_department_view(worker_id, worker_name, gender, department_name)
values (4, 'Roma', 'M', 'Intern');
insert into worker_department_view(worker_id, worker_name, gender, department_name)
values (5, 'Isha', 'M', 'Employee');
select * from Worker;
select * from department;
select * from worker_department_view;
