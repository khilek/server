-- Active: 1715613927110@@127.0.0.1@3306@patient_sorceress_6d50d1_db
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE IF NOT EXISTS recipes (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    title VARCHAR(255) NOT NULL,
    instructions VARCHAR(5000) NOT NULL,
    img VARCHAR(1000) NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    category ENUM(
        "breakfast",
        "lunch",
        "dinner",
        "snack",
        "dessert"
    ),
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

DROP TABLE recipes;

CREATE TABLE IF NOT EXISTS ingredients (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    quantity VARCHAR(255) NOT NULL,
    recipeId INT NOT NULL,
    FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE
);

DROP TABLE ingredients;