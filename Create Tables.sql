CREATE TABLE Dealer (
    id INT PRIMARY KEY IDENTITY(1,1),
    owner_name NVARCHAR(100),
    company_name NVARCHAR(100),
    company_address NVARCHAR(255),
    mobile_no NVARCHAR(20),
    email NVARCHAR(100),
    joiningDate DATE
);
CREATE TABLE Warehouse (
    warehouse_id INT PRIMARY KEY IDENTITY(1,1),
    dealer_id INT, -- Foreign Key to 
    CONSTRAINT FK_Warehouse_Dealer FOREIGN KEY (dealer_id) REFERENCES Dealer(id) ON DELETE CASCADE
);
CREATE TABLE Buyer (
    id INT PRIMARY KEY IDENTITY(1,1),
    buyer_name NVARCHAR(100),
    pharmacy_name NVARCHAR(100),
    pharmacy_address NVARCHAR(255),
    mobile_no NVARCHAR(20),
    email NVARCHAR(100),
    joiningDate DATE
);
CREATE TABLE ProductCategory (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100)
);
CREATE TABLE Product (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    category_id INT, -- Foreign Key to ProductCategory
    name NVARCHAR(100),
    price DECIMAL(10, 2),
    description NVARCHAR(255),
    CONSTRAINT FK_Product_ProductCategory FOREIGN KEY (category_id) REFERENCES ProductCategory(category_id) ON DELETE SET NULL
);
CREATE TABLE MedicineWarehouse (
    warehouse_id INT, -- Foreign Key to Warehouse
    product_id INT, -- Foreign Key to Product
    quantity INT,
    custom_price DECIMAL(10, 2),
    PRIMARY KEY (warehouse_id, product_id),
    CONSTRAINT FK_MedicineWarehouse_Warehouse FOREIGN KEY (warehouse_id) REFERENCES Warehouse(warehouse_id) ON DELETE CASCADE,
    CONSTRAINT FK_MedicineWarehouse_Product FOREIGN KEY (product_id) REFERENCES Product(product_id) ON DELETE CASCADE
);
CREATE TABLE PurchaseOrder (
    purchase_id INT PRIMARY KEY IDENTITY(1,1),
    dealer_id INT, -- Foreign Key to Dealer
    buyer_id INT, -- Foreign Key to Buyer
    amount DECIMAL(10, 2),
    product_id INT, -- Foreign Key to Product
    quantity INT,
    date DATE,
    CONSTRAINT FK_PurchaseOrder_Dealer FOREIGN KEY (dealer_id) REFERENCES Dealer(id) ON DELETE CASCADE,
    CONSTRAINT FK_PurchaseOrder_Buyer FOREIGN KEY (buyer_id) REFERENCES Buyer(id) ON DELETE CASCADE,
    CONSTRAINT FK_PurchaseOrder_Product FOREIGN KEY (product_id) REFERENCES Product(product_id) ON DELETE SET NULL
);
