USE [Product_management_app]
GO
/****** Object:  Trigger [dbo].[trigger_delete_product]    Script Date: 5/19/2023 6:29:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trigger_delete_product]
ON [dbo].[AllProductsWithCategoryDetails]
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