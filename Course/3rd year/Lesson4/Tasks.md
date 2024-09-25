Пратика к уроку У4 М2 К3

---
#Практика A:
Задача 1: Объединение данных с использованием Join
Описание: У вас есть два списка: один содержит информацию о студентах, а другой – информацию о курсах, на которые они записаны. Ваша задача – использовать операцию Join, чтобы объединить эти два списка и вывести результат в формате "Имя студента - Название курса". Это позволяет работать с данными, которые хранятся в разных коллекциях и связаны по какому-то ключу (например, StudentId).

Задача 2: Группировка данных с использованием GroupBy
Описание: У вас есть список студентов и курсов, которые они посещают. Необходимо сгруппировать студентов по курсам с использованием GroupBy. Это позволит вам видеть, какие студенты учатся на каждом курсе, а также применить группировку для других целей (например, для получения статистики по группам данных).

Задача 3: Агрегация данных с использованием Sum
Описание: Дан список оценок студентов. Задача состоит в том, чтобы с помощью метода Sum вычислить общую сумму всех оценок. Это стандартная операция агрегации, которая помогает обрабатывать числовые данные, будь то оценки студентов или любые другие числовые значения в вашей системе.

Задача 4: Агрегирование данных с использованием Average
Описание: У вас есть список оценок, и вы хотите вычислить среднее арифметическое этих оценок, используя метод Average. Это пример работы с агрегатными функциями, которые позволяют выполнять статистическую обработку данных.

Задача 5: Использование Distinct для удаления дубликатов
Описание: В данном списке курсов некоторые названия повторяются. Ваша задача – удалить дубликаты с помощью метода Distinct. Это полезно, когда вам нужно получить уникальные значения из набора данных, например, список уникальных курсов, на которые записаны студенты.
---
#Практика B:
Задача 6: Использование Union для объединения двух коллекций
Описание: У вас есть два списка студентов, и вам нужно объединить их в один список, при этом убрав дубликаты. Используйте метод Union, который объединяет два набора данных и удаляет повторяющиеся элементы. Это важно, когда необходимо объединить несколько источников данных в один.

Задача 7: Использование Intersect для нахождения общих элементов
Описание: В этой задаче вам нужно найти студентов, которые записаны на оба курса, используя метод Intersect. Этот метод возвращает общие элементы двух коллекций. Это полезно, если вы хотите найти пересечения данных в разных наборах.

Задача 8: Использование Except для нахождения разницы между двумя коллекциями
Описание: У вас есть два списка студентов, и нужно найти тех, кто записан только на один из курсов. Используйте метод Except, который возвращает элементы, присутствующие в первой коллекции, но отсутствующие во второй. Эта операция часто используется для нахождения различий между наборами данных.
---
#Практика C:
Задача 9: Создание метода расширения для фильтрации данных
Описание: Напишите метод расширения, который будет фильтровать студентов по первой букве их имени. Методы расширения позволяют вам добавлять функциональность к существующим типам данных. В данном случае метод поможет легко фильтровать список студентов в зависимости от нужных вам критериев, таких как первая буква имени.

Задача 10: Оптимизация запроса с помощью ленивого выполнения
Описание: В LINQ запросы могут выполняться лениво, то есть они не выполняются, пока к результату не обратятся. Создайте запрос с ленивым выполнением, который будет фильтровать числа, большие 3, и выполните его только при вызове метода ToList. Это поможет вам понять, как работает оптимизация запросов, и как вы можете отложить выполнение, улучшив производительность.