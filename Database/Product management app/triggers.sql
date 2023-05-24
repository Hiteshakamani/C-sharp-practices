use Product_management_app;


CREATE TRIGGER trigger_delete_product
ON AllProductsWithCategoryDetails
INSTEAD OF DELETE
AS
BEGIN
    -- Check if there are any deleted rows
    IF @@ROWCOUNT > 0
    BEGIN
        -- Delete corresponding records from product table
		delete p 
		from deleted d
		inner join product p on p.product_id = d.product_id;
        -- Delete corresponding records from food_category table
        delete fc
        from deleted d
        INNER JOIN food_category fc ON fc.product_id = d.product_id;

        -- Delete corresponding records from cloth_category table
        delete cc
        from deleted d
        INNER JOIN cloth_category cc ON cc.product_id = d.product_id;
    END
END;


CREATE TRIGGER tr_InsertProduct_insteadofinsert
ON AllProductsWithCategoryDetails
INSTEAD OF INSERT
AS
BEGIN
    -- Insert into category table
    INSERT INTO category (c_name)
    SELECT c_name
    FROM inserted;

    DECLARE @category_id INT;
    SET @category_id = SCOPE_IDENTITY();

    -- Insert into products table
    INSERT INTO product (p_name, price, category_id)
    SELECT p_name, price, @category_id
    FROM inserted;

    DECLARE @product_id INT;
    SET @product_id = SCOPE_IDENTITY();

    -- Insert into additional details table based on category
    INSERT INTO food_category (product_id, manufacture_date, expiry_date, quantity)
    SELECT @product_id, manufacture_date, expiry_date, quantity
    FROM inserted
    WHERE c_name = 'Food';

    INSERT INTO cloth_category (product_id, gender, size, color, material)
    SELECT @product_id, gender, size, color, material
    FROM inserted
    WHERE c_name = 'Cloth';
END;


CREATE TRIGGER tr_UpdateProduct_insteadofupdate
ON AllProductsWithCategoryDetails
INSTEAD OF UPDATE
AS
BEGIN
    -- Update product details
    UPDATE product
    SET p_name = i.p_name,
        price = i.price,
        category_id = i.category_id
    FROM product p
    INNER JOIN inserted i ON p.product_id = i.product_id;

    -- Update additional details based on category
    UPDATE food_category
    SET manufacture_date = i.manufacture_date,
        expiry_date = i.expiry_date,
        quantity = i.quantity
    FROM food_category fc
    INNER JOIN inserted i ON fc.product_id = i.product_id
    WHERE EXISTS (SELECT 1 FROM category WHERE category_id = i.category_id AND c_name = 'Food');

    UPDATE cloth_category
    SET gender = i.gender,
        size = i.size,
        color = i.color,
        material = i.material
    FROM cloth_category cc
    INNER JOIN inserted i ON cc.product_id = i.product_id
    WHERE EXISTS (SELECT 1 FROM category WHERE category_id = i.category_id AND c_name = 'Cloth');
END;
