## Практика А

1. Создание таблиц:
    ```SQL
    CREATE TABLE Users (
        id INT PRIMARY KEY,
        name VARCHAR(255),
        email VARCHAR(255),
        email_verified TIMESTAMP,
        password VARCHAR(255),
        phone_number VARCHAR(20)
    );

    CREATE TABLE Rooms (
        id INT PRIMARY KEY,
        home_type VARCHAR(255),
        address VARCHAR(255),
        has_tv BOOLEAN,
        has_internet BOOLEAN,
        has_kitchen BOOLEAN,
        has_air_con BOOLEAN,
        price INT,
        owner_id INT,
        latitude FLOAT,
        longitude FLOAT,
        FOREIGN KEY (owner_id) REFERENCES Users(id)
    );

    CREATE TABLE Reservations (
        id INT PRIMARY KEY,
        user_id INT,
        room_id INT,
        start_date TIMESTAMP,
        end_date TIMESTAMP,
        price INT,
        total INT,
        FOREIGN KEY (user_id) REFERENCES Users(id),
        FOREIGN KEY (room_id) REFERENCES Rooms(id)
    );

    CREATE TABLE Reviews (
        id INT PRIMARY KEY,
        reservation_id INT,
        rating INT,
        FOREIGN KEY (reservation_id) REFERENCES Reservations(id)
    );

    ```

2. Заполнение таблиц:

    ```SQL
    INSERT INTO Users (id, name, email, email_verified, password, phone_number)     VALUES
    (1, 'John Doe', 'john.doe@example.com', NULL, 'password1', '1234567890'),
    (2, 'Jane Smith', 'jane.smith@example.com', '2023-01-02 11:00:00',  'password2', '0987654321'),
    (3, 'Alice Johnson', 'alice.johnson@example.com', '2023-01-03 12:00:00',    'password3', '1122334455'),
    (4, 'Bob Brown', 'bob.brown@example.com', '2023-01-04 13:00:00',    'password4', '5566778899'),
    (5, 'Charlie Green', 'charlie.green@example.com', '2023-01-05 14:00:00',    'password5', '9988776655'),
    (6, 'Diana White', 'diana.white@example.com', '2023-01-06 15:00:00',    'password6', '4455667788'),
    (7, 'Eve Black', 'eve.black@example.com', '2023-01-07 16:00:00',    'password7', '7788990011'),
    (8, 'Frank Blue', 'frank.blue@example.com', NULL, 'password8', '2233445566'),
    (9, 'Grace Pink', 'grace.pink@example.com', '2023-01-09 18:00:00',  'password9', '6677889900'),
    (10, 'Hank Yellow', 'hank.yellow@example.com', '2023-01-10 19:00:00',   'password10', '1133557799');

    INSERT INTO Rooms (id, home_type, address, has_tv, has_internet,    has_kitchen, has_air_con, price, owner_id, latitude, longitude) VALUES
    (1, 'Apartment', '123 Elm St', TRUE, TRUE, TRUE, FALSE, 100, 1, 40.7128, -74.   0060),
    (2, 'Apartment', '456 Oak St', FALSE, TRUE, TRUE, TRUE, 150, 2, 34.0522,    -118.2437),
    (3, 'Villa', '789 Pine St', TRUE, TRUE, FALSE, TRUE, 200, 3, 41.8781, -87.  6298),
    (4, 'Villa', '101 Maple St', TRUE, FALSE, TRUE, FALSE, 120, 4, 37.7749, -122.   4194),
    (5, 'Cottage', '202 Cedar St', FALSE, TRUE, FALSE, TRUE, 130, 5, 47.6062,   -122.3321),
    (6, 'Cottage', '303 Birch St', TRUE, TRUE, TRUE, FALSE, 140, 6, 33.4484,    -112.0740),
    (7, 'Townhouse', '404 Willow St', TRUE, TRUE, TRUE, TRUE, 300, 7, 25.7617,  -80.1918),
    (8, 'Townhouse', '505 Spruce St', FALSE, TRUE, FALSE, FALSE, 160, 8, 42.    3601, -71.0589),
    (9, 'Penthouse', '606 Fir St', TRUE, FALSE, TRUE, TRUE, 170, 9, 39.0997, -94.   5783),
    (10, 'Penthouse', '707 Hemlock St', TRUE, TRUE, TRUE, TRUE, 400, 10, 36.    1699, -115.1398);

    INSERT INTO Reservations (id, user_id, room_id, start_date, end_date, price,    total) VALUES
    (1, 1, 1, '2023-02-01 08:00:00', '2023-02-05 12:00:00', 100, 400),
    (2, 2, 2, '2023-02-10 09:00:00', '2023-02-15 13:00:00', 150, 750),
    (3, 3, 3, '2023-03-01 10:00:00', '2023-03-05 14:00:00', 200, 1000),
    (4, 4, 4, '2023-04-01 11:00:00', '2 023-04-05 15:00:00', 120, 600),
    (5, 5, 5, '2023-05-01 12:00:00', '2023-05-05 16:00:00', 130, 650),
    (6, 6, 6, '2023-06-01 13:00:00', '2023-06-05 17:00:00', 140, 700),
    (7, 7, 7, '2023-07-01 14:00:00', '2023-07-05 18:00:00', 300, 1500),
    (8, 8, 8, '2023-08-01 15:00:00', '2023-08-05 19:00:00', 160, 800),
    (9, 9, 9, '2023-09-01 16:00:00', '2023-09-05 20:00:00', 170, 850),
    (10, 10, 10, '2023-10-01 17:00:00', '2023-10-05 21:00:00', 400, 2000);

    INSERT INTO Reviews (id, reservation_id, rating) VALUES
    (1, 1, 5),
    (2, 2, 4),
    (3, 3, 5),
    (4, 4, 3),
    (5, 5, 4),
    (6, 6, 5),
    (7, 7, 5),
    (8, 8, 4),
    (9, 9, 3),
    (10, 10, 5);

    ```

## Практика B

1. Есть телевизор и интернет:
    ```SQL
    SELECT * FROM Rooms
    WHERE has_tv = TRUE AND has_internet = TRUE;
    ```
2. Бронирования `id = 1`:
    ```SQL
    SELECT * FROM Reservations
    WHERE user_id = 1;
    ```
3. Пользователи, которые не подтвердили почту:
    ```SQL
    SELECT * FROM Users
    WHERE email_verified IS NULL;
    ```
4.  Комнаты, доступные для бронирования:
    ```SQL
    SELECT * FROM Rooms
    WHERE id NOT IN (
    SELECT room_id FROM Reservations
    WHERE (start_date BETWEEN '2023-02-15' AND '2023-02-20')
    OR (end_date BETWEEN '2023-02-15' AND '2023-02-20')
    OR (start_date <= '2023-02-15' AND end_date >= '2023-02-20')
    );
    ```
5. Средняя цена по всем комнатам:
    ```SQL
    SELECT AVG(price) AS average_price FROM Rooms;
    ```

## Практика C

1. Общая сумма от бронирования:
    ```SQL
    SELECT SUM(total) AS total_revenue FROM Reservations
    WHERE start_date BETWEEN '2023-01-01' AND '2023-12-31';
    ```
2. Комнаты в определенном диапазоне цен:
    ```SQL
    SELECT * FROM Rooms
    WHERE price BETWEEN 100 AND 200;
    ```
3. Кол-во отзывов и средняя оценка:
    ```SQL
    SELECT R.room_id, COUNT(Re.id) AS review_count, AVG(Re.rating) AS average_rating
    FROM Reservations R
    JOIN Reviews Re ON R.id = Re.reservation_id
    GROUP BY R.room_id;
    ```
4. Самые дорогие комнаты в каждой категории:
    ```SQL
    SELECT r.id, r.home_type, r.price
    FROM Rooms r
    WHERE r.price = (SELECT MAX(price) FROM Rooms WHERE home_type = r home_type);
    ```


