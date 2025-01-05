## Часть A

- В Postgres нет режима Read Uncommited.

```SQL
BEGIN;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
SELECT * FROM my_table;

-------------------------------------------

SELECT * FROM my_table;


COMMIT;
```


```SQL
BEGIN;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

UPDATE my_table SET value = 'ASDASDASDASDAS' WHERE id = 1;

COMMIT;
```


Чуть поменяем для проверки на фантомность, на REPEATABLE READ его не будет:
```SQL
BEGIN;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
SELECT COUNT(*) FROM my_table;


SELECT COUNT(*) FROM my_table;
COMMIT;
```

```SQL
BEGIN;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
INSERT INTO my_table(id, value) VALUES (2, 'TATATATAWKEKAEA');
COMMIT;
```