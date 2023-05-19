use Sql_practice2;
create table products(
product_id int primary key identity(1,1),
product_name nvarchar(15),
quantity_stock int ,
unit_price decimal(10,2)
);

insert into products (product_name,quantity_stock,unit_price)
values ( 'Product A', 10, 10.99),
    ( 'Product B', 5, 15.99),
    ( 'Product C', 0, 8.99),
    ( 'Product D', 20, 5.99);

create table customers(
customer_id int primary key identity(1,1),
f_name nvarchar(15) ,
l_name nvarchar(15),
email nvarchar(20)
);

insert into customers(f_name,l_name,email)
values( 'John', 'Doe', 'john@example.com'),
    ( 'Jane', 'Smith', 'jane@example.com'),
    ( 'Michael', 'Johnson', 'michael@example.com');

create table orders(
order_id int primary key identity(1,1),
order_date date,
customer_id int ,
total_amount decimal(10,2),
foreign key (customer_id) references customers(customer_id) 
);

insert into orders (order_date,customer_id,total_amount)
values( '2022-01-01', 1, 0),
    ( '2022-02-01', 2, 0),
    ( '2022-03-01', 3, 0);

create table orderItem(
orderItem_id int primary key identity(1,1),
order_id int,
product_id int,
quantity int,
subtotal decimal(10,2),
foreign key (order_id) references orders(order_id),
foreign key (product_id) references products(product_id)
);

insert into orderItem(order_id,product_id,quantity,subtotal)
values ( 1, 1, 2, 0),
    ( 1, 2, 1, 0),
    ( 2, 3, 4, 0),
    ( 3, 4, 3, 0);


--Whenever a new order is placed, the TotalAmount in the Orders table should be calculated as the sum of the Subtotal of all related OrderItems.

--function will calculate the total
create function calculate_total(@product_id int , @quantity_stock  int)
returns decimal(10,2)
as
begin
declare @unit_price decimal(10,2);
select @unit_price = unit_price 
from products 
where product_id = @product_id;
return(@unit_price * @quantity_stock);
end;

--following trigger will update the total amount in the orderitem table
create trigger tr_updateTotalAmount_afterInsert  
on orderItem 
after insert
as begin 
	declare @order_id int;
	set @order_id = (select order_id from inserted);

	update orders
	set total_amount =(
	select sum(subtotal) 
	from orderItem 
	where order_id = @order_id
	)
	where order_id = @order_id;
end;

create trigger tr_preventoOutOfStockOrder_beforInsert 
on orders
before insert 
as begin 
	if exists(
			select 1
			from orderItem oi
			inner join products p on p.product_id = oi.product_id
			where oi.order_id in (select orderid from inserted)
			and p.quantity_stock = 0
			)
	begin
			raiserror('order contains out of stock products. please remove or replace them',16,1);
			end;
			end;

			
create proc sp_placeOrder
	@customer_id int,
	@order_date date,
	@order_item as dbo.orderItem readonly 
as
begin
	begin transaction ;
	declare @order_id int;
	declare @total_amount decimal(10,2);
	insert into orders (order_date,customer_id,total_amount)
	values (@order_date,@customer_id,0);
	set @order_id = SCOPE_IDENTITY();

	update products
	set quantity_stock = quantity_stock - oi.quantity
	from @order_item oi
	where products.product_id = oi.product_id;

	update orderItems 
	set subtotal = dbo.calculate_total(product_id,quantity)
	where order_id = @order_id;

	update  orders
	set total_amount = (
				select sum(subtotal)
				from orderItem 
				where order_id = @order_id
				)
				where order_id=@order_id;
				commit;
				end;

exec sp_placeOrder 1, '2023-05-16', @order_item;
SELECT * FROM orders;
SELECT * FROM orderItem;

