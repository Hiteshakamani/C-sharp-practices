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

