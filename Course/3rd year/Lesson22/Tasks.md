## Часть A:
 
Создайте две таблицы: 
users с колонками id (INTEGER, PRIMARY KEY), name (TEXT), age (INTEGER). 
 
orders с колонками id (INTEGER, PRIMARY KEY), user_id (INTEGER), amount (INTEGER). 
 
Напишите транзакцию, которая: 
Добавляет пользователя с именем "Alice" и возрастом 25. 
Добавляет для неё заказ на сумму 150. 
Фиксирует изменения. 
 
## Часть B: 
 
Модифицируйте задание из части A. 
Если пользователь с именем "Alice" уже существует в таблице users, транзакция должна откатываться (используйте ROLLBACK). 
 
## Часть C: 
 
Добавьте проверку: если сумма заказа больше 1000, транзакция должна откатиться. 
В противном случае добавьте заказ. 
В конце зафиксируйте изменения.