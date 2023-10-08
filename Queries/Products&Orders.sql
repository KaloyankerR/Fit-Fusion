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

ALTER TABLE [Order]
ADD OrderDate DATE;

CREATE TABLE [Order] (
    Id INT PRIMARY KEY,
    Address VARCHAR(255) NOT NULL,
	OrderDate DATE NOT NULL,
    Note VARCHAR(155),
    ProductId INT,
    UserId INT,
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (UserId) REFERENCES Customer(Id)
);

CREATE TABLE Hashtag (
    Id INT PRIMARY KEY,
    Tag VARCHAR(50) NOT NULL
);

CREATE TABLE ProductHashtag (
    ProductId INT,
    HashtagId INT,
    PRIMARY KEY (ProductId, HashtagId),
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (HashtagId) REFERENCES Hashtag(Id)
);



drop table [Order]

CREATE TABLE [Order] (
    Id INT PRIMARY KEY,
    Address VARCHAR(255) NOT NULL,
    OrderDate DATE NOT NULL,
    Note VARCHAR(155),
    UserId INT,
    FOREIGN KEY (UserId) REFERENCES Customer(Id)
);

CREATE TABLE OrderLine (
    Id INT PRIMARY KEY,
    OrderId INT,
    ProductId INT,
    Quantity INT,
    FOREIGN KEY (OrderId) REFERENCES [Order](Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
