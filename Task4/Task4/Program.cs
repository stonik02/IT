using System;

// Определение класса 1-го уровня
class Exam
{
    // Поля класса
    string discipline;
    int num_students;
    int duration;

    // Конструктор, который инициализирует поля объекта
    public Exam(string discipline, int num_students, int duration)
    {
        this.discipline = discipline;
        this.num_students = num_students;
        this.duration = duration; // Продолжительность
    }

    // Функция, которая определяет качество экзамена по формуле Q
    public double Q()
    {
        return (double)num_students / duration;
    }

    // Функция, которая выводит информацию об объекте
    public void info()
    {
        Console.WriteLine($"Экзамен по: {discipline}\nКолличество студентов: {num_students}\nПродолжительность: {duration}\nQ: {Q()}");
    }
}

// Определение класса 2-го уровня, который наследуется от класса Exam
class ExamP : Exam
{
    // Дополнительное поле класса
    int P;

    // Конструктор, который добавляет дополнительное поле P
    public ExamP(string discipline, int num_students, int duration, int P) : base(discipline, num_students, duration)
    {
        this.P = P;
    }

    // Функция, которая определяет качество экзамена класса ExamP по формуле Qp
    public double Qp()
    {
        return Q() * (100 - P) / 100.0;
    }

    // Функция, которая выводит информацию об объекте класса ExamP
    public new void info()
    {
        base.info();
        Console.WriteLine($"P: {P}\nQp: {Qp()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объекта класса Exam
        Exam exam1 = new Exam("Математика", 20, 2);
        Exam exam2 = new Exam("Физика", 30, 2);

        ExamP exam3 = new ExamP("Математика", 20, 2, 20);
        ExamP exam4 = new ExamP("Физика", 30, 2, 40);

        // Создание объекта класса ExamP



        exam1.info();      
        exam2.info();
        exam3.info();
        exam4.info();
    }
}
