use [Sql_practice 3];

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    Email VARCHAR(50)
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create OrderItems table
CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Subtotal DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

-- Create function to calculate TotalAmount
CREATE FUNCTION CalculateTotalAmount (@orderID INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @totalAmount DECIMAL(10, 2);

    SELECT @totalAmount = SUM(Subtotal)
    FROM OrderItems
    WHERE OrderID = @orderID;

    RETURN @totalAmount;
END;

-- Create trigger to update TotalAmount on OrderItems insert or update
CREATE TRIGGER UpdateTotalAmount
ON OrderItems
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @orderID INT;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        SELECT @orderID = OrderID FROM inserted;

        UPDATE Orders
        SET TotalAmount = dbo.CalculateTotalAmount(@orderID)
        WHERE OrderID = @orderID;
    END;
END;

-- Create stored procedure to insert a new order with order items
CREATE PROCEDURE InsertOrderWithItems
    @customerID INT,
    @orderDate DATE,
    @orderItems AS dbo.OrderItemsType READONLY
AS
BEGIN
    DECLARE @orderID INT;

    -- Insert into Orders table
    INSERT INTO Orders (CustomerID, OrderDate, TotalAmount)
    VALUES (@customerID, @orderDate, 0);

    SET @orderID = SCOPE_IDENTITY();

    -- Insert into OrderItems table
    INSERT INTO OrderItems (OrderID, ProductID, Quantity, Subtotal)
    SELECT @orderID, ProductID, Quantity, (Quantity * UnitPrice)
    FROM @orderItems;

    -- Update TotalAmount using the trigger

    -- Return the inserted OrderID
    SELECT @orderID AS OrderID;
END;
