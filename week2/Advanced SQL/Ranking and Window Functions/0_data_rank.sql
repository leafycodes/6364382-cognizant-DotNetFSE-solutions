CREATE DATABASE IF NOT EXISTS ProductRankingDB;

USE ProductRankingDB;

DROP TABLE IF EXISTS Products;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

INSERT INTO
    Products
VALUES (
        1,
        'Laptop',
        'Electronics',
        1200.00
    ),
    (
        2,
        'Smartphone',
        'Electronics',
        800.00
    ),
    (
        3,
        'Tablet',
        'Electronics',
        500.00
    ),
    (
        4,
        'Monitor',
        'Electronics',
        300.00
    ),
    (
        5,
        'Keyboard',
        'Electronics',
        100.00
    ),
    (
        6,
        'Sofa',
        'Furniture',
        800.00
    ),
    (
        7,
        'Dining Table',
        'Furniture',
        600.00
    ),
    (
        8,
        'Chair',
        'Furniture',
        150.00
    ),
    (
        9,
        'Coffee Table',
        'Furniture',
        150.00
    ),
    (
        10,
        'Bookshelf',
        'Furniture',
        120.00
    );

SELECT *
FROM (
        SELECT
            Category, ProductName, Price, ROW_NUMBER() OVER (
                PARTITION BY
                    Category
                ORDER BY Price DESC
            ) AS RowNum
        FROM Products
    ) AS RankedProducts
WHERE
    RowNum <= 3;

SELECT *
FROM (
        SELECT
            Category, ProductName, Price, RANK() OVER (
                PARTITION BY
                    Category
                ORDER BY Price DESC
            ) AS `Rank`
        FROM Products
    ) AS RankedProducts
WHERE
    `Rank` <= 3;

SELECT *
FROM (
        SELECT
            Category, ProductName, Price, DENSE_RANK() OVER (
                PARTITION BY
                    Category
                ORDER BY Price DESC
            ) AS DenseRank
        FROM Products
    ) AS RankedProducts
WHERE
    DenseRank <= 3;

SELECT p.Category, p.ProductName, p.Price, (
        SELECT COUNT(*)
        FROM Products p2
        WHERE
            p2.Category = p.Category
            AND p2.Price > p.Price
    ) + 1 AS 'Rank', (
        SELECT COUNT(DISTINCT p2.Price)
        FROM Products p2
        WHERE
            p2.Category = p.Category
            AND p2.Price > p.Price
    ) + 1 AS 'DenseRank'
FROM Products p
HAVING
    `Rank` <= 3
ORDER BY p.Category, p.Price DESC;