## Практика A

```SQL
CREATE TABLE Teachers (
    id INT PRIMARY KEY,
    name TEXT,
    subject TEXT
);

CREATE TABLE Classes (
    id INT PRIMARY KEY,
    name TEXT
);

CREATE TABLE Students (
    id INT PRIMARY KEY,
    name TEXT,
    class_id INT,
    FOREIGN KEY (class_id) REFERENCES Classes(id)
);

CREATE TABLE Subjects (
    id INT PRIMARY KEY,
    name TEXT
);

CREATE TABLE Schedule (
    id INT PRIMARY KEY,
    class_id INT,
    subject_id INT,
    teacher_id INT,
    day_of_week TEXT,
    start_time TIME,
    end_time TIME,
    FOREIGN KEY (class_id) REFERENCES Classes(id),
    FOREIGN KEY (subject_id) REFERENCES Subjects(id),
    FOREIGN KEY (teacher_id) REFERENCES Teachers(id)
);
```

```SQL
INSERT INTO Teachers (id, name, subject) VALUES
(1, 'Teacher M', 'Mathematics'),
(2, 'Teacher E', 'English'),
(3, 'Teacher S', 'Science'),
(4, 'Teacher H', 'History'),
(5, 'Teacher G', 'Geography');

INSERT INTO Classes (id, name) VALUES
(1, 'Class 1'),
(2, 'Class 2'),
(3, 'Class 3'),
(4, 'Class 4'),
(5, 'Class 5');

INSERT INTO Students (id, name, class_id) VALUES
(1, 'Student A', 1),
(2, 'Student B', 2),
(3, 'Student C', 3),
(4, 'Student D', 4),
(5, 'Student E', 5);

INSERT INTO Subjects (id, name) VALUES
(1, 'Mathematics'),
(2, 'English'),
(3, 'Science'),
(4, 'History'),
(5, 'Geography');

INSERT INTO Schedule (id ,class_id, subject_id, teacher_id, day_of_week, start_time, end_time) VALUES
(1, 1, 1, 1, 'Monday', '08:00:00', '09:00:00'),
(2, 2, 2, 2, 'Tuesday', '09:00:00', '10:00:00'),
(3, 3, 3, 3, 'Wednesday', '10:00:00', '11:00:00'),
(4, 4, 4, 4, 'Thursday', '11:00:00', '12:00:00'),
(5, 5, 5, 5, 'Friday', '12:00:00', '13:00:00');
```

## Практика B
```SQL
UPDATE Teachers
SET name = 'Teacher L', subject = 'Literature'
WHERE id = 2;
```

```SQL
UPDATE Schedule
SET teacher_id = (
    SELECT id
    FROM Teachers
    WHERE subject = 'Mathematics'
    AND id NOT IN (
        SELECT teacher_id
        FROM Schedule
        WHERE subject_id = (SELECT id FROM Subjects WHERE name = 'Mathematics')
          AND day_of_week = 'Monday'
          AND (
              (start_time BETWEEN '14:00:00' AND '15:00:00')
              OR (end_time BETWEEN '14:00:00' AND '15:00:00')
              OR (start_time < '14:00:00' AND end_time > '15:00:00')
          )
    )
    LIMIT 1
),
day_of_week = 'Monday',
start_time = '14:00:00',
end_time = '15:00:00',
subject_id = (SELECT id FROM Subjects WHERE name = 'Mathematics')
WHERE class_id = 4
```

```SQL
DELETE FROM Students
WHERE id = 3;
```

```SQL
DELETE FROM Schedule
WHERE class_id = 2
AND subject_id = 2;
```

```SQL
UPDATE Students
SET class_id = 3
WHERE id = 5;
```

## ДЗ (?)

```SQL
SELECT S.name AS student_name, C.name AS class_name
FROM Students S
JOIN Classes C ON S.class_id = C.id;
```

```SQL
SELECT S.day_of_week, Su.name AS subject_name, T.name AS teacher_name, S.start_time, S.end_time
FROM Schedule S
JOIN Subjects Su ON S.subject_id = Su.id
JOIN Teachers T ON S.teacher_id = T.id
WHERE S.class_id = 4;
```


Немного не понял, что подразумевается под классами. Уроки?
```SQL
SELECT S.name AS student_name, COUNT(DISTINCT Sc.subject_id) AS subject_count
FROM Students S
JOIN Schedule Sc ON S.class_id = Sc.class_id
GROUP BY S.id, S.name;
```