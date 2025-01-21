## Практика 1:
- 1
```SQL
SELECT
    o.id AS order_id,
    o.order_date,
    c.customer_name,
    c.email,
    p.product_name,
    p.price,
    od.quantity
FROM
    orders o
JOIN
    customers c ON o.customer_id = c.id
JOIN
    order_details od ON o.id = od.order_id
JOIN
    products p ON od.product_id = p.id;
```
- 2
```SQL
SELECT
    c.id AS customer_id,
    c.customer_name,
    c.email,
    o.id AS order_id,
    o.order_date
FROM
    customers c
LEFT JOIN
    orders o ON c.id = o.customer_id;
```
- 3
```SQL
SELECT
    p.id AS product_id,
    p.product_name,
    p.price,
    od.order_id,
    od.quantity
FROM
    products p
LEFT JOIN
    order_details od ON p.id = od.product_id;
```
- 4 Немного не понял, что именно выбрать то нужно...
```SQL
SELECT
    c.id AS customer_id,
    c.customer_name,
    c.email,
    p.id AS product_id,
    p.product_name,
    p.price
FROM
    customers c
CROSS JOIN
    products p;
```
или это:
```SQL
SELECT
    c.customer_name,
    c.email,
    p.product_name,
    p.price,
    od.quantity
FROM
    orders o
JOIN
    customers c ON o.customer_id = c.id
JOIN
    order_details od ON o.id = od.order_id
JOIN
    products p ON od.product_id = p.id;
```

## Практика 2:
- 1 
```SQL
SELECT
    p1.product_name AS product1,
    p1.price AS price1,
    p2.product_name AS product2,
    p2.price AS price2
FROM
    products p1
JOIN
    products p2 ON p1.category_id = p2.category_id AND p1.price != p2.price
WHERE
    p1.id < p2.id;
```
-  2
```SQL
SELECT
	c.customer_name,
	SUM(p.price * od.quantity) AS total
FROM 
	orders o
JOIN 
	customers c ON o.customer_id = c.id
JOIN
	order_details od ON o.id = od.order_id
JOIN
	products p ON od.product_id = p.id
GROUP BY 
	c.customer_name
HAVING SUM(p.price * od.quantity) > 100
```
- 3
```SQL
SELECT
    c.id AS customer_id,
    c.customer_name,
    c.email
FROM
    customers c
LEFT JOIN
    orders o ON c.id = o.customer_id
WHERE
    o.id IS NULL;
```

## Практика 3
- 1
```SQL
SELECT 
	p.id AS product_id,
	p.product_name,
	p.price
FROM
	products p
LEFT JOIN
	order_details od ON od.product_id = p.id
WHERE od.id IS NULL
```
- 2
```SQL
SELECT
    c.id AS customer_id,
    c.customer_name,
    c.email,
    p.id AS product_id,
    p.product_name,
    p.price
FROM
    customers c
FULL OUTER JOIN
    orders o ON c.id = o.customer_id
FULL OUTER JOIN
    order_details od ON o.id = od.order_id
FULL OUTER JOIN
    products p ON od.product_id = p.id;
```
- 3
```SQL
SELECT
    p1.product_name AS product1,
    p1.price AS price1,
    p2.product_name AS product2,
    p2.price AS price2
FROM
    products p1
CROSS JOIN
    products p2
WHERE
    p1.category_id != 1 AND p2.category_id != 1;
```

P.S: у меня эта практика была сделана еще с Димой, правда там чуть больше было, он давал еще задание. Оно все в папке Lesson24 есть