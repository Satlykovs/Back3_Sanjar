## Практика А

```SQL
SELECT * FROM employees WHERE salary > 70000;

SELECT * FROM employees WHERE position = 'Разработчик';


SELECT * FROM employees 
JOIN departments d ON department_id = d.id
WHERE d.department_name = 'Разработка'
ORDER BY name;
```

## Практика B

```SQL
SELECT * FROM employees WHERE salary = 72000 ORDER BY name DESC;


SELECT * FROM employees WHERE salary BETWEEN 60000 AND 80000;


SELECT * FROM employees
JOIN departments d ON department_id = d.id
WHERE department_name = 'Маркетинг'
ORDER BY salary;
```

## Практика C

```SQL
SELECT position, COUNT(*) FROM employees
JOIN departments d ON department_id = d.id
WHERE d.department_name = 'HR'
GROUP BY position;


SELECT position, SUM(salary) FROM employees
JOIN departments d ON department_id = d.id
WHERE d.department_name = 'Разработка'
GROUP BY position;


SELECT position, MAX(salary), MIN(salary) FROM employees 
JOIN departments d ON department_id = d.id
WHERE d.department_name = 'Разработка'
GROUP BY position;


SELECT * FROM employees
JOIN departments d ON department_id = d.id
WHERE d.department_name IN ('Разработка', 'Маркетинг')
ORDER BY salary DESC, position ASC;

```