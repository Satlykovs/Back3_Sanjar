using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }
}

public class Enrollment
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}

public class Program
{
    public static void Main()
    {
        // 1. Объединение данных с использованием Join
        var students = new List<Student>
        {
            new Student { StudentId = 1, Name = "Alice" },
            new Student { StudentId = 2, Name = "Bob" }
        };

        var courses = new List<Course>
        {
            new Course { CourseId = 1, Title = "Math" },
            new Course { CourseId = 2, Title = "Science" }
        };

        var enrollments = new List<Enrollment>
        {
            new Enrollment { StudentId = 1, CourseId = 1 },
            new Enrollment { StudentId = 1, CourseId = 2 },
            new Enrollment { StudentId = 2, CourseId = 1 }
        };

        var result = students.Join(enrollments,
                                    s => s.StudentId,
                                    e => e.StudentId,
                                    (s, e) => new { s.Name, e.CourseId })
                             .Join(courses,
                                   se => se.CourseId,
                                   c => c.CourseId,
                                   (se, c) => $"{se.Name} - {c.Title}");

        Console.WriteLine("1. Объединение данных:");
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        var studentCourses = new[]
        {
            new { StudentName = "Alice", CourseTitle = "Math" },
            new { StudentName = "Alice", CourseTitle = "Science" },
            new { StudentName = "Bob", CourseTitle = "Math" }
        };

        var groupedByCourse = studentCourses
            .GroupBy(sc => sc.CourseTitle)
            .Select(g => new
            {
                CourseTitle = g.Key,
                Students = g.Select(s => s.StudentName).ToList()
            });

        Console.WriteLine("2. Группировка данных по курсам:");
        foreach (var group in groupedByCourse)
        {
            Console.WriteLine($"{group.CourseTitle}: {string.Join(", ", group.Students)}");
        }
        Console.WriteLine();

        // 3. Агрегация данных с использованием Sum
        var grades = new List<int> { 85, 90, 78, 88, 92 };
        int totalSum = grades.Sum();

        Console.WriteLine($"3. Общая сумма оценок: {totalSum}");
        Console.WriteLine();

        // 4. Агрегирование данных с использованием Average
        double average = grades.Average();

        Console.WriteLine($"4. Средняя оценка: {average}");
        Console.WriteLine();

        // 5. Использование Distinct для удаления дубликатов
        var courseList = new List<string> { "Math", "Science", "Math", "History", "Science" };
        var distinctCourses = courseList.Distinct();

        Console.WriteLine("5. Уникальные курсы:");
        foreach (var course in distinctCourses)
        {
            Console.WriteLine(course);
        }
    }
}