Скрипт для бд(не забудьте поменять конекш стринг)

CREATE TABLE Users (
    UserId SERIAL PRIMARY KEY,
    Login VARCHAR(50) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(100) NOT NULL
);
CREATE TABLE RequestTypes (
    RequestTypeId SERIAL PRIMARY KEY,
    TypeName VARCHAR(50) NOT NULL
);
CREATE TABLE Requests (
    RequestId SERIAL PRIMARY KEY,
    PhoneNumber VARCHAR(20) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    RequestTypeId INT NOT NULL,
    UserId INT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (RequestTypeId) REFERENCES RequestTypes(RequestTypeId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

INSERT INTO RequestTypes (TypeName) VALUES
('Продажа'),
('Покупка'),
('Аукцион');
