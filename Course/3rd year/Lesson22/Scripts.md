## Часть А

```SQL
CREATE TABLE Users (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    age INTEGER
);

CREATE TABLE Orders (
    id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users(id),
    amount INTEGER NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users (id)
);
```

## Часть B
Почему так сложно просто за if - ать :(
```SQL
BEGIN;

DO $$
DECLARE
    user_exists BOOLEAN;
BEGIN
	INSERT INTO users (name, age) VALUES ('Alice', 25);
    SELECT EXISTS (SELECT 1 FROM users WHERE name = 'Alice') INTO user_exists;

    IF user_exists THEN
        RAISE EXCEPTION 'User with name Alice already exists';
    ELSE
        INSERT INTO users (name, age) VALUES ('Alice', 25);

        INSERT INTO orders (user_id, amount)
        VALUES ((SELECT id FROM users WHERE name = 'Alice'), 150);
    END IF;
END $$;

COMMIT;
```

## Часть C

Мне кажется, что это нужно как-то по-другому делать.

```SQL
BEGIN;

DO $$
DECLARE
    user_exists BOOLEAN;
    order_amount INT := 1500;
BEGIN
    SELECT EXISTS (SELECT 1 FROM users WHERE name = 'Alice') INTO user_exists;

    IF user_exists THEN
        RAISE EXCEPTION 'User with name Alice already exists';
    ELSE
        INSERT INTO users (name, age) VALUES ('Alice', 25);

        IF order_amount > 1000 THEN
            RAISE EXCEPTION 'Order amount exceeds 1000';
        ELSE
            INSERT INTO orders (user_id, amount)
            VALUES ((SELECT id FROM users WHERE name = 'Alice'), order_amount);
        END IF;
    END IF;
END $$;

COMMIT;
```