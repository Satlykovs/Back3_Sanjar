## Практика А

```SQL
EXPLAIN ANALYZE
SELECT * FROM Orders
WHERE UserID = 1;

EXPLAIN ANALYZE
SELECT * FROM Products
WHERE Category = 'Electronics';


EXPLAIN ANALYZE
SELECT * FROM Orders
WHERE ProductID = 1;

```

Индекс можно создать для каждой таблицы. При большом объеме данных, это ускорит запросы.


## Практика B

```SQL
CREATE INDEX idx_orders_userid ON Orders(UserID);

CREATE INDEX idx_products_category ON Products(Category);

CREATE INDEX idx_orders_productid ON Orders(ProductID);
```


## Практика C

Для Orders лучше сделать составной индекс, потому что основными полями для фильтрации зачастую будут как раз UsedID и ProductID. Ну и для товаров тоже можно.
```SQL

CREATE INDEX idx_orders_userid_productid ON Orders(UserID, ProductID);

CREATE INDEX idx_products_category_price ON Products(Category, Price);
```