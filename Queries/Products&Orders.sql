CREATE TABLE Product (
    Id INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description VARCHAR(255),
    Category VARCHAR(35) NOT NULL,
    ImageUrl VARCHAR(255)
);

CREATE TABLE [Order] (
    Id INT PRIMARY KEY,
    Address VARCHAR(255) NOT NULL,
    Note VARCHAR(155),
    ProductId INT,
    UserId INT,
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (UserId) REFERENCES Customer(Id)
);

select * from [Order]