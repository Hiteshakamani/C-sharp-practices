use Product_management_app;

create function fn_GetTotalQuantity
    (@product_id int)
returns int
as
begin
    declare @total_quantity int;

    if exists (select 1 from food_category where product_id = @product_id)
    begin
        select @total_quantity = sum(quantity)
        from food_category
        where product_id = @product_id;
    end
    else if exists (select 1 from cloth_category where product_id = @product_id)
    begin
        select @total_quantity = sum(quantity)
        from food_category
        where product_id = @product_id;
    end

    return isnull(@total_quantity, 0);
end;
