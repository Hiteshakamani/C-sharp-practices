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


create trigger tr_worker_department_insteadofupdate
on worker_department_view
instead of update
as
begin

  -- worker id is updated
  if (update(id))
  begin
    raiserror('it cannot be changed', 16, 1);
    return;
  end;

  -- if deptname is updated
  if (update(department_name))
  begin
    declare @dep_id int;
    select @dep_id = department.id
      from department
      join inserted
      on inserted.department_name = department.name;

    if (@dep_id is null)
    begin
      raiserror('invalid department name', 16, 1);
      return;
    end;

    update worker
      set department_id = @dep_id
      from inserted
      join worker
      on worker.id = inserted.id;
  end;

  -- if gender is updated
  if (update(gender))
  begin
    update worker
      set gender = inserted.gender
      from inserted
      join worker
      on worker.id = inserted.id;
  end;

  -- if name is updated
  if (update(worker_name))
  begin
    update worker 
      set worker_name = inserted.worker_name
      from inserted
      join worker
      on worker.id = inserted.id;
  end;

end;

--update one table
update worker_department_view set department_name = 'manager' where  id = 1;

--update all tables
  