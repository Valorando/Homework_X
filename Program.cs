/*Разработайте приложение для учета студентов в университете. 
 * Ваша задача - создать класс "Student" для представления студента и класс "StudentManager", который будет 
 * отвечать за управление списком студентов.

Класс "Student" должен содержать следующие поля:

Имя (Name) - строковое поле.
Фамилия (Surname) - строковое поле.
Возраст (Age) - целочисленное поле.
Курс (Year) - целочисленное поле.
Класс "Student" должен также иметь конструктор, который принимает значения для всех полей и метод "ToString()", который 
возвращает строковое представление объекта студента.

Класс "StudentManager" должен содержать список (List) студентов и иметь следующие методы:

AddStudent(Student student): добавляет студента в список.
RemoveStudent(Student student): удаляет студента из списка.
GetStudentsByYear(int year): возвращает список студентов, находящихся на указанном курсе.
GetOldestStudent(): возвращает самого старшего студента из списка.
Создайте консольное приложение, которое будет взаимодействовать с пользователем. 
Пользователь должен иметь возможность добавлять студентов, удалять студентов, просматривать список студентов на 
определенном курсе и получать информацию о самом старшем студенте.

Приложение должно работать до тех пор, пока пользователь не введет команду для выхода.*/



StudentManager studentmanager = new StudentManager();

Console.WriteLine("\t\t\t<Система учёта студентов>");
while (true)
{
    Console.WriteLine();
    Console.WriteLine("\t\t\t   <Меню управления>");
    Console.WriteLine("\t\t\t1 - Добавить студента.");
    Console.WriteLine("\t\t\t2 - Удалить студента.");
    Console.WriteLine("\t\t\t3 - Список студентов курса.");
    Console.WriteLine("\t\t\t4 - Список всех студентов.");
    Console.WriteLine("\t\t\t5 - Самый старший студент.");
    Console.WriteLine("\t\t\t6 - Выход.");
    Console.WriteLine();

    int key;
    Console.Write("\t\t\tВведите номер действия: ");
    while (!int.TryParse(Console.ReadLine(), out key))
    {
        Console.WriteLine();
        Console.WriteLine("\t\t\t   <Меню управления>");
        Console.WriteLine("\t\t\t1 - Добавить студента.");
        Console.WriteLine("\t\t\t2 - Удалить студента.");
        Console.WriteLine("\t\t\t3 - Список студентов курса.");
        Console.WriteLine("\t\t\t4 - Список всех студентов.");
        Console.WriteLine("\t\t\t5 - Самый старший студент.");
        Console.WriteLine("\t\t\t6 - Выход.");
        Console.WriteLine();
        Console.Write("\t\t\tВведите номер действия: ");
    }


    if (key == 1)
    {
        studentmanager.AddStudent();
    }

    if (key == 2)
    {
        studentmanager.RemoveStudent();
    }

    if (key == 3)
    {
        int year;
        Console.WriteLine();
        Console.Write("\t\t\tВведите курс: ");
        year = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"\t\t\tСписок студентов {year} курса.");
        Console.WriteLine();
        List<Student> students = studentmanager.GetStudentsByYear(year);
        foreach (Student student in students)
        {
            Console.WriteLine($"{student}\n");
        }
        Console.WriteLine();
       
    }

    if (key == 4)
    {
        Console.WriteLine();
        Console.WriteLine("\t\t\tСписок всех студентов: ");
        Console.WriteLine();
        foreach (Student student in studentmanager.student_list)
        {
          Console.WriteLine($"{student}\n");
        }
        Console.WriteLine();
      
    }

    if (key == 5)
    {
        Student oldest_student = studentmanager.GetOldestStudent();
        Console.WriteLine("\t\t\tСамым старшим студентом является: ");
        Console.WriteLine();
        Console.WriteLine($"{oldest_student}\n");
    }

    if (key == 6)
    {
        Console.WriteLine();
        Console.WriteLine("\t\t\tВыполняется выход...");
        return 0;
    }

}



class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public int Year { get; set; }

    public Student(string name, string surname, int age, int year)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Year = year;
    }

    public override string ToString()
    {
        return $"\t\t\tИмя: {Name}.\n\t\t\tФамилия: {Surname}.\n\t\t\tВозраст: {Age}.\n\t\t\tКурс: {Year}.";
    }
}



class StudentManager
{
    public List<Student> student_list = new List<Student>();

    public void AddStudent()
    {
        string name_for_input;
        string surname_for_input;
        int age_for_input;
        int year_for_input;

        Console.WriteLine();
        Console.Write("\t\t\tВведите имя: ");
        name_for_input = Console.ReadLine();
        Console.Write("\t\t\tВведите фамилию: ");
        surname_for_input = Console.ReadLine();
        Console.Write("\t\t\tВведите возраст: ");
        age_for_input = Convert.ToInt32(Console.ReadLine());
        Console.Write("\t\t\tВведите курс: ");
        year_for_input = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Student student = new Student(name_for_input, surname_for_input, age_for_input, year_for_input);
        student_list.Add(student);
        Console.WriteLine("\t\t\tСтудент успешно добавлен.");
    }

    public void RemoveStudent()
    {
        string name_for_delete;
        string surname_for_delete;
        int age_for_delete;
        int year_for_delete;

        Console.WriteLine();
        Console.Write("\t\t\tВведите имя: ");
        name_for_delete = Console.ReadLine();
        Console.Write("\t\t\tВведите фамилию: ");
        surname_for_delete = Console.ReadLine();
        Console.Write("\t\t\tВведите возраст: ");
        age_for_delete = Convert.ToInt32(Console.ReadLine());
        Console.Write("\t\t\tВведите курс: ");
        year_for_delete = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        student_list.RemoveAll(p => p.Name == name_for_delete);
        student_list.RemoveAll(p => p.Surname == surname_for_delete);
        student_list.RemoveAll(p => p.Age == age_for_delete);
        student_list.RemoveAll(p => p.Year == year_for_delete);
        Console.WriteLine("\t\t\tСтудент успешно удалён.");
    }

    public List<Student> GetStudentsByYear(int year)
    {
        List<Student> students_by_year = new List<Student>();
        foreach (Student student in student_list)
        {
            if (student.Year == year)
            {
                students_by_year.Add(student);
            }
        }
        return students_by_year;

    }

    public Student GetOldestStudent()
    {
        Student oldest_student = student_list[0];
        foreach (Student student in student_list)
        {
            if (student.Age > oldest_student.Age)
            {
                oldest_student = student;
            }
        }
        return oldest_student;

    }
}