CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(55) NOT NULL,
    Description VARCHAR(255),
    Category VARCHAR(35) NOT NULL,
    ImageUrl VARCHAR(255)
);

CREATE TABLE [Order] (
    Id INT PRIMARY KEY IDENTITY(1, 1),
	UserId INT NOT NULL,
    OrderDate DATE NOT NULL,
    Note VARCHAR(155),
    FOREIGN KEY (UserId) REFERENCES Customer(Id)
);

CREATE TABLE OrderLine (
    -- Id INT PRIMARY KEY IDENTITY(1, 1),
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
	TotalPrice INT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES [Order](Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

CREATE TABLE Hashtag (
    Id INT PRIMARY KEY,
    Tag VARCHAR(50) NOT NULL
);

CREATE TABLE ProductHashtag (
    ProductId INT NOT NULL,
    HashtagId INT NOT NULL,
    PRIMARY KEY (ProductId, HashtagId),
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (HashtagId) REFERENCES Hashtag(Id)
);


