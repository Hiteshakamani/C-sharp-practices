create table student(
  id int identity(1,1) primary key,
  name varchar(50)not null,
  age int not null
);

insert into student (name, age) values
('John Doe', 21),
('Jane Doe', 22),
('Mary Smith', 23),
('Peter Jones', 24),
('Susan Brown', 25),
('David Green', 26),
('Emily White', 27),
('Michael Black', 28),
('Sarah Gray', 29),
('William Red', 30),
('Alice Blue', 31),
('Thomas Orange', 32),
('Jennifer Yellow', 33),
('Robert Purple', 34);


create function student_count()
returns int 
as
begin 
	declare @total_count int;
	select @total_count = count(*) from student ;
	return @total_count;
end ;

create function student_filter_by_age(@min_age int,@max_age int)
returns table (id int, name varchar(50), age int)
as
begin 
	
		select id ,name, age from student where age >= @min_age and age <= @max_age;
end;


SELECT *
FROM student_filter_by_age(25, 30);
