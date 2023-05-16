use Sql_practice;
create table customer(
id int primary key identity(1,1),
first_name varchar(15) not null,
last_name varchar(15) not null,
email nvarchar(30) not null
);

insert into customer (first_name,last_name,email)
values ('hitesha','kamani','hitesha123@gmail.com'),
		('hiren','khunt','hiren123@gmail.com'),
		('hitanshi','shah','hitanshi123@gmail.com');

create proc update_customer (
	@id int,
	@first_name varchar(15),
	@last_name varchar(15) ,
    @email nvarchar(30)
)
as 
begin
  
    --update the customer 
	update customer 
	set id = @id,
		first_name = @first_name,
		last_name = @last_name,
		email = @email
	where id = @id;

	-- Return the number of rows updated.
    if @@ROWCOUNT = 0 then
        RAISE_APPLICATION_ERROR (-20000, 'No rows were updated.');
    END IF;

	 -- Return the customer record.
	 select id,first_name,last_name,email  from customer
	 where id = @id;

	 end ;
	 update_customer(1,'abc','def','abc@gmail.com')
