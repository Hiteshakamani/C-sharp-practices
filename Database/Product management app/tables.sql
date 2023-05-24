use Product_management_app;

create table category(
category_id int primary key identity(1,1),
c_name varchar(15) not null
);

create table product (
product_id int primary key identity (1,1),
p_name varchar(15) not null,
price decimal(10,2) not null,
category_id int ,
foreign key (category_id) references category(category_id) ON DELETE CASCADE

);

create table food_category (
f_id int primary key identity(1,1),
manufacture_date datetime ,
expiry_date datetime,
quantity int ,
product_id int ,
foreign key (product_id) references product(product_id) ON DELETE CASCADE
);

create table cloth_category(
c_id int primary key identity(1,1),
gender varchar(10),
size varchar (5),
color varchar(10),
material varchar (10),
product_id int,
foreign key (product_id) references product(product_id)ON DELETE CASCADE
);

create table other_category(
id int primary key identity(1,1),
product_id int,
foreign key (product_id) references product(product_id)ON DELETE CASCADE
);

-- Insert data into the category table
INSERT INTO category (c_name)
VALUES ('Cloth'), ('Food'),('Other');

-- Insert data into the product table
INSERT INTO product (p_name, price, category_id)
VALUES ('T-Shirt', 29.99, 1),
       ('Jeans', 49.99, 1),
       ('Chocolate', 2.99, 2),
       ('Bread', 1.99, 2);

-- Insert data into the food_category table
INSERT INTO food_category (manufacture_date, expiry_date, quantity,product_id)
VALUES ('2022-01-01', '2023-01-01', 100,3),
       ('2022-02-01', '2023-02-01', 200,4);

-- Insert data into the cloth_category table
INSERT INTO cloth_category (gender, size, color, material,product_id)
VALUES ('Male', 'M', 'Blue', 'Cotton',1),
       ('Female', 'S', 'Red', 'Polyester',2);
      
select * from category;
select * from product;
select * from food_category;
select * from cloth_category;

create view product_by_category as 
select p.product_id , p.p_name ,p.price, p.category_id,c.c_name
from product p 
inner join  category c 
on p.category_id = c.category_id;

select * from product_by_category;

CREATE VIEW AllProductsWithCategoryDetails
AS
SELECT
  p.product_id,
  p.p_name,
  p.price,
  c.category_id,
  c.c_name,
  fc.manufacture_date,
  fc.expiry_date,
  fc.quantity,
  cc.gender,
  cc.size,
  cc.color,
  cc.material
FROM product p
LEFT JOIN category c ON p.category_id = c.category_id
LEFT JOIN food_category fc ON p.product_id = fc.product_id
LEFT JOIN cloth_category cc ON p.product_id = cc.product_id;

select * from AllProductsWithCategoryDetails;

CREATE VIEW AllProductsWithFoodCategoryDetails
AS
SELECT
  p.product_id,
  p.p_name,
  p.price,
  c.c_name,
  fc.manufacture_date,
  fc.expiry_date,
  fc.quantity
FROM product p
INNER JOIN category c ON p.category_id = c.category_id
INNER JOIN food_category fc ON p.product_id = fc.product_id;

select * from AllProductsWithFoodCategoryDetails;

CREATE VIEW AllProductsWithClothCategoryDetails
AS
SELECT
  p.product_id,
  p.p_name,
  p.price,
  c.c_name,
  cc.gender,
  cc.size,
  cc.color,
  cc.material
FROM product p
INNER JOIN category c ON p.category_id = c.category_id
INNER JOIN cloth_category cc ON p.product_id = cc.product_id;

select * from AllProductsWithClothCategoryDetails;