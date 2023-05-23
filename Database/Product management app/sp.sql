use Product_management_app;

CREATE PROCEDURE sp_DeleteProduct
    @product_id int
AS
BEGIN
    BEGIN TRANSACTION;

    -- Delete from products table
    DELETE p FROM product p
    WHERE p.product_id = @product_id;

    -- Delete from food_category table
    DELETE	fc FROM food_category fc
    WHERE fc.product_id = @product_id;

    -- Delete from cloth_category table
    DELETE cc FROM cloth_category cc
    WHERE cc.product_id = @product_id;

    COMMIT;
END;

exec sp_DeleteProduct 7;

select * from category;
select * from product;
select * from food_category;
select * from cloth_category;
select * from AllProductsWithCategoryDetails;

create proc sp_findproduct
(
	@product_id int
)
as 
begin 
	select * from AllProductsWithCategoryDetails
	where product_id = @product_id;
end ;

exec sp_findproduct 3 ; 

create proc sp_GetAllProduct
 as 
 begin 
	select * from AllProductsWithCategoryDetails;
end;

exec sp_GetAllProduct;

create proc sp_GetProductByCategory(
@category_id int
)
as 
begin 
begin try
	if (@category_id = 1)
	begin
		select * from AllProductsWithClothCategoryDetails;
	end
	if (@category_id = 2)
	begin
		select * from AllProductsWithFoodCategoryDetails;
	end
end try
begin catch
	raiserror ('only food and cloth caterogries are available',16,1);
end catch;
end;

exec sp_GetProductByCategory 3;


-- add product in the view which contains all the necessary fields of the product
CREATE PROCEDURE sp_InsertProduct
    @product_name VARCHAR(50),
    @price DECIMAL(10, 2),
    @category_name VARCHAR(20),
    @manufacture_date DATETIME = NULL,
    @expiry_date DATETIME = NULL,
    @quantity INT = NULL,
    @gender VARCHAR(10) = NULL,
    @size VARCHAR(5) = NULL,
    @color VARCHAR(10) = NULL,
    @material VARCHAR(10) = NULL
AS
BEGIN
    -- Insert into category table
    DECLARE @category_id INT;
     INSERT INTO AllProductsWithCategoryDetails(c_name)
    VALUES (@category_name);

    -- Insert into products table
    DECLARE @product_id INT;
    INSERT INTO product (p_name, price, category_id)
    VALUES (@product_name, @price, @category_id);
    SET @product_id = SCOPE_IDENTITY();

    -- Insert into additional details table based on category
    IF (@category_name = 'Food')
    BEGIN
        INSERT INTO food_category (product_id, manufacture_date, expiry_date, quantity)
        VALUES (@product_id, @manufacture_date, @expiry_date, @quantity);
    END
    ELSE IF (@category_name = 'Cloth')
    BEGIN
        INSERT INTO cloth_category (product_id, gender, size, color, material)
        VALUES (@product_id, @gender, @size, @color, @material);
    END
END;



--if we give the all value then it will only store the product by category vise
exec sp_InsertProduct 'sari', 33.33 , 'Cloth' , '2022-01-01 00:00:00.000','2023-01-01 00:00:00.000',100,'Female','Xl','Black','Corten';
--update the view of all products and its details
CREATE PROCEDURE sp_UpdateProduct
    @product_id int ,
    @product_name VARCHAR(15),
    @price DECIMAL(10,2),
    @category_id INT,
    @manufacture_date DATETIME = NULL,
    @expiry_date DATETIME = NULL,
    @quantity INT = NULL,
    @gender VARCHAR(10) = NULL,
    @size VARCHAR(5) = NULL,
    @color VARCHAR(10) = NULL,
    @material VARCHAR(10) = NULL
AS
BEGIN
    
    -- Update product details
    UPDATE product
    SET p_name = @product_name,
        price = @price,
        category_id = @category_id
    WHERE product_id = @product_id;

    -- Update additional details based on category
    IF EXISTS (SELECT 1 FROM category WHERE category_id = @category_id AND c_name = 'Food')
    BEGIN
        UPDATE food_category
        SET manufacture_date = @manufacture_date,
            expiry_date = @expiry_date,
            quantity = @quantity
        WHERE product_id = @product_id;
    END;
    ELSE IF EXISTS (SELECT 1 FROM category WHERE category_id = @category_id AND c_name = 'Cloth')
    BEGIN
        UPDATE cloth_category
        SET gender = @gender,
            size = @size,
            color = @color,
            material = @material
        WHERE product_id = @product_id;
    END;

END;

EXEC sp_UpdateProduct 13, 'Updated Product',19.99, 1,'2023-05-01', '2023-12-31', 100,'Male','XL', 'Blue','Cotton';

 DELETE	fc FROM category fc
    WHERE fc.category_id in(4,5,6,7,8);
