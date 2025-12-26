using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите путь к папке для поиска: ");
            string folderPath = Console.ReadLine()?.Trim('"').Trim();
            
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                Console.WriteLine("Путь не может быть пустым.");
                return;
            }
            
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Папка '{folderPath}' не существует или недоступна.");
                return;
            }
            
            Console.Write("Введите регулярное выражение для поиска файлов: ");
            string pattern = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(pattern))
            {
                Console.WriteLine("Регулярное выражение не может быть пустым.");
                return;
            }

            try
            {
                var testRegex = new Regex(pattern);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка в регулярном выражении: {ex.Message}");
                return;
            }
            
            Console.WriteLine("\nНачинаю поиск файлов...");
            
            int foundCount = 0;
            SearchFiles(folderPath, pattern, ref foundCount);

            if (foundCount == 0)
            {
                Console.WriteLine("Файлы, соответствующие регулярному выражению, не найдены.");
            }
            else
            {
                Console.WriteLine($"Найдено файлов: {foundCount}");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Ошибка: нет доступа к одной из папок.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Ошибка: путь слишком длинный.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
        }
        
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
    
    static void SearchFiles(string folderPath, string regexPattern, ref int foundCount)
    {
        try
        {
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            
            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                string fileName = Path.GetFileName(filePath);
                
                if (regex.IsMatch(fileName))
                {
                    Console.WriteLine(filePath);
                    foundCount++;
                }
            }

            foreach (string subdirectory in Directory.GetDirectories(folderPath))
            {
                SearchFiles(subdirectory, regexPattern, ref foundCount);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Нет доступа к папке: {folderPath}");
        }
    }
}