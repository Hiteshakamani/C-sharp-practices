use sql_practice;

create table worker(
id int primary key,
worker_name varchar(10) not null,
gender varchar(5) not null,
department_id int not null
);

create table department (
id int primary key,
name varchar(100) not null
);

insert into worker(id, worker_name, gender, department_id)
values (1, 'harsh', 'm', 1);
insert into worker(id, worker_name, gender, department_id)
values (2, 'hitesha', 'f', 2);
insert into worker(id, worker_name, gender, department_id)
values (3, 'jay', 'm', 3);
insert into worker(id, worker_name, gender, department_id)
values (4, 'roma', 'f', 1);
insert into worker(id, worker_name, gender, department_id)
values (5, 'isha', 'f', 4);

insert into department(id, name)
values (1, 'hr');
insert into department(id, name)
values (2, 'software developer');
insert into department(id, name)
values (3, 'qa');
insert into department(id, name)
values (4, 'manager');


create view worker_department_view as 
select w.id, w.worker_name, w.gender, d.name as department_name, w.department_id
from worker w
join department d
on w.department_id = d.id;

create trigger tr_worker_department_view_insteadofDelete
on worker_department_view 
instead of delete 
as begin 
	delete worker from worker
	join deleted 
	on worker.id = deleted.id
	 
	 --subquery
	 --delete worker where id in(select id from deleted)

	end

	delete from worker_department_view where id = 2;
	select * from worker_department_view;
	select * from worker;
	select * from department;