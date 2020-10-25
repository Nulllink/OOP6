using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP6
{
    class Program
    {
        static StreamWriter csw = new StreamWriter("document6.txt");
        static string path; //путь к файлу
        static void Main(string[] args)
        {
            //получение название файла
            dwr("Введите имя файла данных: ");
            if ((path = drl()) != "")
            {
                while (true)
                {
                    dwr("Для записи введите W, для чтения R");
                    string s = drl();
                    //если пользователь выбрал запись файла
                    if (s.ToUpper() == "W")
                    {
                        dwr("Введите количество работников: ");
                        int n;
                        //если пользователь ввел верное количество элементов
                        if (int.TryParse(drl(), out n))
                        {
                            StreamWriter sw = new StreamWriter(path);
                            //создание массива объектов класса сотрудник
                            Person[] p = new Person[n];
                            //заполнение массива сотрудников и запись в файл
                            for (int i = 0; i < n; i++)
                            {
                                p[i] = new Person();
                                dwr($"Введите имя сотрудника {i}");
                                p[i].name = drl();
                                dwr($"Введите год рождения сотрудника {i}");
                                int.TryParse(drl(), out p[i].birth);
                                dwr($"Введите стаж работы сотрудника {i}");
                                int.TryParse(drl(), out p[i].exp);
                                dwr($"Введите должность сотрудника {i}");
                                p[i].job = drl();
                                dwr($"Введите оклад сотрудника {i}");
                                int.TryParse(drl(), out p[i].salary);
                                sw.WriteLine($"{p[i].name} {p[i].birth} {p[i].exp} {p[i].job} {p[i].salary}");
                            }
                            sw.Close();
                            break;
                        }
                        else
                        {
                            dwr("Неправильный ввод");
                        }
                    }
                    //если пользователь выбрал чтение из файла
                    else if (s.ToUpper() == "R")
                    {
                        List<Person> p = reading();
                        if (p.Count > 0)
                        {
                            //выполнение подзадач задания
                            dwr("Выполнение 1 задачи");
                            e1(p);
                            dwr("Выполнение 2 задачи");
                            e2(p);
                            dwr("Выполнение 3 задачи");
                            e3(p);
                            dwr("Выполнение 4 задачи");
                            e4(p);
                            dwr("Выполнение 5 задачи");
                            e5(p);
                            dwr("Выполнение 6 задачи");
                            e6(p);
                            dwr("Выполнение 7 задачи");
                            e7();
                        }
                        else
                        {
                            dwr("В файле нет данных");
                        }
                        break;
                    }
                    else
                    {
                        dwr("Вы ничего не выбрали, повторите выбор");
                    }
                }
            }
            else
            {
                dwr("Введено пустое имя файла");
            }
            //завершение программы
            csw.Close();
            Console.ReadKey();
        }
        /// <summary>
        /// Чтение файла, занесение данных в список
        /// </summary>
        static List<Person> reading()
        {
            List<Person> p = new List<Person>();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string text;
                //чтение из файла и заполнение списка
                while ((text = sr.ReadLine()) != null)
                {
                    p.Add(new Person());
                    string[] sp = text.Split();
                    p[p.Count - 1].name = sp[0];
                    p[p.Count - 1].birth = int.Parse(sp[1]);
                    p[p.Count - 1].exp = int.Parse(sp[2]);
                    p[p.Count - 1].job = sp[3];
                    p[p.Count - 1].salary = int.Parse(sp[4]);
                }
                sr.Close();
            }
            return p;
        }
        /// <summary>
        /// Вывод фамилии и стажа
        /// </summary>
        static void e1(List<Person> p)
        {
            for (int i = 0; i < p.Count; i++)
            {
                dwr($"{p[i].name} {p[i].exp}");
            }
        }
        /// <summary>
        /// Вывод среднего стажа работы
        /// </summary>
        static void e2(List<Person> p)
        {
            int sum = 0;
            for (int i = 0; i < p.Count; i++)
            {
                sum += p[i].exp;
            }
            sum /= p.Count;
            dwr($"Средний стаж работы равен: {sum}");
        }
        /// <summary>
        /// Вывод фамилии тех, кто инженер
        /// </summary>
        static void e3(List<Person> p)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].job == "инженер")
                {
                    dwr(p[i].name);
                }
            }
        }
        /// <summary>
        /// Вывод фамилии с заданой пользователем буквы
        /// </summary>
        static void e4(List<Person> p)
        {
            dwr("Введите букву");
            char w = drl()[0];
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].name[0] == w)
                {
                    dwr(p[i].name);
                }
            }
        }
        /// <summary>
        /// Вывод фамилии, у которых оклад больше заданного
        /// </summary>
        static void e5(List<Person> p)
        {
            int num;
            dwr("Введите зарплату");
            if (int.TryParse(drl(), out num))
            {
                for (int i = 0; i < p.Count; i++)
                {
                    if (num < p[i].salary)
                    {
                        dwr(p[i].name);
                    }
                }
            }
            else
            {
                dwr("Введено неверное значение");
            }
        }
        /// <summary>
        /// Смена фамилии у заданного сотрудника
        /// </summary>
        static void e6(List<Person> p)
        {
            dwr("Введите номер сотрудника у кого заменить фамилию");
            int ind;
            if(int.TryParse(drl(), out ind))
            {
                if(ind < p.Count && ind > 0)
                {
                    dwr("Введите новую фамилию");
                    p[ind-1].name = drl();
                    StreamWriter sw = new StreamWriter(path);
                    //запись в файл новых данных
                    for(int i = 0;i < p.Count; i++)
                    {
                        sw.WriteLine($"{p[i].name} {p[i].birth} {p[i].exp} {p[i].job} {p[i].salary}");
                    }
                    sw.Close();
                }
                else
                {
                    dwr("Такого номера сотрудника нет");
                }
            }
            else
            {
                dwr("Введено неверное значение");
            }
        }
        /// <summary>
        /// Вывод всех сотрудников на экран
        /// </summary>
        static void e7()
        {
            List<Person> p = reading();
            for (int i = 0; i < p.Count; i++)
            {
                dwr($"{p[i].name} {p[i].birth} {p[i].exp} {p[i].job} {p[i].salary}");
            }
        }
        /// <summary>
        /// Совместный вывод в текстовый файл и консоль
        /// </summary>
        static void dwr(string text)
        {
            Console.WriteLine(text);
            csw.WriteLine(text);
        }
        /// <summary>
        /// Чтение из консоли с пометкой в логах
        /// </summary>
        static string drl()
        {
            string t = Console.ReadLine();
            csw.WriteLine(t);
            return t;
        }
    }
    /// <summary>
    /// Класс сотрудник
    /// </summary>
    class Person
    {
        public string name;
        public int birth;
        public int exp;
        public string job;
        public int salary;
    }
}