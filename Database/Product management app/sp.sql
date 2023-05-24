use Product_management_app;

CREATE PROCEDURE sp_DeleteProduct
    @product_id int
AS
BEGIN
    BEGIN TRANSACTION;
	
    -- Check if product exists
    IF NOT EXISTS (SELECT * FROM product WHERE product_id = @product_id)
    BEGIN
        ROLLBACK;
        RAISERROR ('Product does not exist.', 16, 1);
        RETURN;
    END;

    -- Delete from products table
    DELETE p FROM product p
    WHERE p.product_id = @product_id;

	  -- Delete from food_category table
    DELETE fc FROM food_category fc
    WHERE fc.product_id = @product_id;

    -- Delete from cloth_category table
    DELETE cc FROM cloth_category cc
    WHERE cc.product_id = @product_id;
   
    COMMIT;
END;

exec sp_DeleteProduct 2;



CREATE PROCEDURE sp_findproduct
(
	@product_id INT
)
AS
BEGIN
	BEGIN TRY
		DECLARE @rowCount INT;

		-- Check if the product ID exists
		SELECT @rowCount = COUNT(*)
		FROM AllProductsWithCategoryDetails
		WHERE product_id = @product_id;

		IF @rowCount = 0
		BEGIN
			-- Raise an error if the product ID does not exist
			RAISERROR('Product does not exist.', 16, 1);
			RETURN;
		END;

		-- Product ID exists, select the product
		SELECT *
		FROM AllProductsWithCategoryDetails
		WHERE product_id = @product_id;
	END TRY
	BEGIN CATCH
		-- Handle the error
		THROW;
	END CATCH;
END;

exec sp_findproduct 33 ; 

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

exec sp_GetProductByCategory 1;


-- add product in the view which contains all the necessary fields of the product
CREATE PROCEDURE sp_InsertProduct
    @product_name VARCHAR(50),
    @price DECIMAL(10, 2),
	@category_id int,
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
 BEGIN TRANSACTION;
    -- Insert into products table
    DECLARE @product_id INT;
    
    -- Check if category id and category name are valid
    IF NOT EXISTS (SELECT * FROM category WHERE category_id = @category_id AND c_name = @category_name)
    BEGIN
	rollback;
       RAISERROR('Category ID and category name should be 1 and cloth or 2 and food', 16, 1);
       RETURN;
    END;
 
    -- Insert into additional details table based on category

    IF (@category_name = 'Food' and @category_id = 2)
    BEGIN
	    INSERT INTO product (p_name, price, category_id)
        VALUES (@product_name, @price, @category_id);
		SET @product_id = SCOPE_IDENTITY();

        INSERT INTO food_category (manufacture_date, expiry_date, quantity,product_id)
        VALUES (@manufacture_date, @expiry_date, @quantity,@product_id);
    END
    ELSE IF (@category_name = 'Cloth' and @category_id = 1)
    BEGIN
		INSERT INTO product (p_name, price, category_id)
        VALUES (@product_name, @price, @category_id);
		SET @product_id = SCOPE_IDENTITY();

        INSERT INTO cloth_category (gender, size, color, material,product_id)
        VALUES (@gender, @size, @color, @material,@product_id);	
    END
	commit;
END;

--if we give the all value then it will only store the product by category vise
exec sp_InsertProduct 'shirt', 33.33 ,1, 'Cloth' , '2022-01-01 00:00:00.000','2023-01-01 00:00:00.000',100,'Female','Xl','Black','Corten';
exec sp_InsertProduct 'mango',12.12, 2,'Food', '2022-01-01 00:00:00.000','2023-01-01 00:00:00.000' 
--update the view of all products and its details

CREATE PROCEDURE sp_UpdateProduct
    @product_id INT,
    @product_name VARCHAR(25),
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
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check if the product exists
        IF NOT EXISTS (SELECT * FROM product WHERE product_id = @product_id)
        BEGIN
            ROLLBACK;
            RAISERROR('Product does not exist.', 16, 1);
            RETURN;
        END;

        -- Get the current category ID
        DECLARE @currentCategoryId INT;
        SELECT @currentCategoryId = category_id
        FROM product
        WHERE product_id = @product_id;

        -- Update product details based on category
        IF @currentCategoryId = @category_id -- No change in category
        BEGIN
            UPDATE product
            SET p_name = @product_name,
                price = @price
            WHERE product_id = @product_id;

			update food_category 
			set manufacture_date = @manufacture_date,
			    expiry_date = @expiry_date,
				quantity = @quantity
			where product_id = @product_id;

			update cloth_category
			set
			   gender = @gender,
			   size = @size,
			   color = @color,
			   material = @material
		    where product_id = @product_id;
        END;
        ELSE IF @currentCategoryId = 1 AND @category_id = 2 -- Food to Cloth
        BEGIN
            UPDATE product
            SET p_name = @product_name,
                price = @price,
                category_id = @category_id
            WHERE product_id = @product_id;

            -- Delete the product from the food category table
             DELETE cc FROM cloth_category cc
            WHERE cc.product_id = @product_id;

            -- Insert the product into the cloth category table
            

			INSERT INTO food_category (manufacture_date, expiry_date, quantity, product_id)
            VALUES (@manufacture_date, @expiry_date, @quantity, @product_id);
			END;
        ELSE IF @currentCategoryId = 2 AND @category_id = 1 -- Cloth to Food
        BEGIN
            UPDATE product
            SET p_name = @product_name,
                price = @price,
                category_id = @category_id
            WHERE product_id = @product_id;

            -- Delete the product from the food category table
           
			DELETE fc FROM  food_category fc
            WHERE fc.product_id = @product_id;
            -- Insert the product into the cloth category table
           INSERT INTO cloth_category (gender, size, color, material, product_id)
            VALUES (@gender, @size, @color, @material, @product_id);
        END;
        ELSE
        BEGIN
            ROLLBACK;
            RAISERROR('Invalid category.', 16, 1);
            RETURN;
        END;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK;
        THROW;
    END CATCH;
END;



EXEC sp_UpdateProduct  2,'updated product', 19.99, 1, '2023-05-01',  '2023-12-31',  2008, 'Male', 'XL','Green', 'silk';
 
select * from category;
select * from product;
select * from food_category;
select * from cloth_category;
select * from AllProductsWithCategoryDetails;