using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR18
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            // Задание 1: Очередь в магазине (Queue)
            Console.WriteLine("=== Задание 1: Очередь в магазине ===");
            Queue<string> customers = new Queue<string>();

            customers.Enqueue("Анна");
            customers.Enqueue("Петр");
            customers.Enqueue("Ольга");
            customers.Enqueue("Иван");
            customers.Enqueue("Мария");

            Console.Write("Очередь: ");
            Console.WriteLine(string.Join(", ", customers));

            while (customers.Count > 0)
            {
                string customer = customers.Dequeue();
                Console.WriteLine($"Обслуживаем: {customer}");
            }
            Console.WriteLine("Очередь пуста\n");

            // Задание 2: Отмена действий (Stack)
            Console.WriteLine("=== Задание 2: Отмена действий ===");
            Stack<string> actions = new Stack<string>();

            Console.WriteLine("Вводите строки (пустая строка - конец):");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                actions.Push(input);
            }

            Console.WriteLine("Отмена действий в обратном порядке:");
            while (actions.Count > 0)
            {
                Console.WriteLine(actions.Pop());
            }
            Console.WriteLine();

            // Задание 3: Уникальные имена (HashSet)
            Console.WriteLine("=== Задание 3: Уникальные имена ===");
            HashSet<string> uniqueNames = new HashSet<string>();

            Console.WriteLine("Вводите имена (пустая строка - конец):");
            while (true)
            {
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    break;
                uniqueNames.Add(name);
            }

            List<string> sortedNames = new List<string>(uniqueNames);
            sortedNames.Sort();

            Console.WriteLine("Уникальные имена по алфавиту:");
            Console.WriteLine(string.Join(", ", sortedNames));
            Console.WriteLine();

            // Задание 4: История браузера — только назад (LinkedList)
            Console.WriteLine("=== Задание 4: История браузера ===");
            LinkedList<string> history = new LinkedList<string>();
            LinkedListNode<string> currentPage = null;

            void AddToHistory(string url)
            {
                history.AddLast(url);
                currentPage = history.Last;
                Console.WriteLine($"Перешли на: {url}");
            }

            void GoBack()
            {
                if (currentPage?.Previous != null)
                {
                    currentPage = currentPage.Previous;
                    Console.WriteLine($"Текущая страница: {currentPage.Value}");
                }
                else
                {
                    Console.WriteLine("Невозможно перейти назад");
                }
            }

            Console.WriteLine("Симуляция истории браузера:");
            AddToHistory("google.com");
            AddToHistory("youtube.com");
            AddToHistory("github.com");

            Console.WriteLine("Команда: back");
            GoBack();
            Console.WriteLine("Команда: back");
            GoBack();
            Console.WriteLine();

            // Задание 5: Простой кэш на 3 элемента (Dictionary + Queue)
            Console.WriteLine("=== Задание 5: Простой кэш ===");
            Dictionary<string, bool> cache = new Dictionary<string, bool>();
            Queue<string> cacheOrder = new Queue<string>();
            const int CACHE_SIZE = 3;

            void AddToCache(string url)
            {
                if (cacheOrder.Count >= CACHE_SIZE)
                {
                    string oldest = cacheOrder.Dequeue();
                    cache.Remove(oldest);
                    Console.WriteLine($"Удалена из кэша: {oldest}");
                }

                cacheOrder.Enqueue(url);
                cache[url] = true;
                Console.WriteLine($"Добавлена в кэш: {url}");

                Console.WriteLine($"Текущий кэш: {string.Join(", ", cacheOrder.ToArray())}");
            }

            Console.WriteLine("Симуляция кэша (максимум 3 элемента):");
            AddToCache("google.com");
            AddToCache("youtube.com");
            AddToCache("github.com");
            AddToCache("vk.com"); 

            Console.WriteLine("\nДля выхода нажмите Enter...");
            Console.ReadLine();
        }
    }
}
