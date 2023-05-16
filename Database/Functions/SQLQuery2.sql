use Sql_practice;
create table products (
  product_id int primary key,
  product_name varchar(50) NOT NULL,
  cost_price decimal(10, 2) NOT NULL
);

insert into products (product_id, product_name, cost_price)
values
  (1, 'Product A', 10.00),
  (2, 'Product B', 20.00),
  (3, 'Product C', 30.00),
  (4, 'Product D', 40.00);

create table sales (
  sale_id int primary key,
  product_id int NOT NULL,
  quantity int NOT NULL,
  sale_amount decimal(10, 2) NOT NULL,
  sale_date date NOT NULL
);

insert into sales (sale_id, product_id, quantity, sale_amount, sale_date)
values
  (1, 1, 10, 150.00, '2022-01-01'),
  (2, 1, 5, 75.00, '2022-02-01'),
  (3, 2, 8, 300.00, '2022-02-15'),
  (4, 3, 12, 600.00, '2022-03-01'),
  (5, 4, 3, 150.00, '2022-03-15'),
  (6, 2, 6, 240.00, '2022-04-01');

  create function get_profit_margin(@product_id int)
  returns  decimal(5,5)
  as
  begin 
	declare @sale_amount decimal(10, 2);
	declare @quantity int;
	declare @cost_price decimal(10, 2);
	--declare @product_id int;
	declare @margin decimal (5,5);

	--getting cost price 
	select @cost_price = cost_price 
	from products where product_id = @product_id;

	--getting total sale amount 
	select @sale_amount = sum(sale_amount * quantity), @quantity = sum(quantity)
	from sales 
	where product_id = @product_id;

	--profit 
	if @quantity>0
	begin 
	set @margin = ((@sale_amount- (@quantity* @cost_price))/@sale_amount)*100;
	end
	else 
	begin 
	set @margin = 0 ;
	end

	return @margin;
	end;
	 

	select * from products;
	select * from sales;
    select p.product_name,s.quantity,s.sale_amount,get_profit_margin(1) as profit_margin
	from sales s
	join products p on s.product_id = p.product_id;


	create function get_total_sales_amount(
	@start_date date,
	@end_date date
	)
	returns decimal(10,2)
	as
	begin 
	    declare @total_sales decimal(10,2);

		begin try 
		 select @total_sales = sum(sale_amount)
		 from sales 
		 where sale_date between @start_date and @end_date;
		 if @total_sales is null
		 begin 
		 set @total_sales = 0 ;
		 end;
		 end try
		 begin catch 
		 declare @error nvarchar(200);
		 set @error = 'An error while calculating the total sales amount for the date range:'
		 + convert(nvarchar(10),@start_date,120) + 'to'+convert(nvarchar(10),@end_date,120);
		 throw 5100,@error , 1;
		 end catch;
		 return @total_sales;
	end;

	declare @start_date date = '2022-02-01';
	declare @end_date date  = '2022-12-31';

	begin try 
	select get_total_sales_amount(@start_date,@end_date) as total_sales_amount;
	end try
	begin catch
	select ERROR_NUMBER() as error_number , ERROR_MESSAGE() as 	error_message;
	end catch;