using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ИСРПО2.Models;

namespace ИСРПО2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult TaskFirst()
    {
        return View();

    }

    [HttpPost]
    public IActionResult TaskFirst(string number)
    {

        if (int.TryParse(number, out int parsedNumber))
        {

            if (parsedNumber % 7 == 0)
            {
                ViewBag.IsDivisibleBySeven = "да";
            }
            else
            {
                ViewBag.IsDivisibleBySeven = "нет не";
            }
        }
        return View();

    }

    public IActionResult TaskSecond()
    {
        return View();
    }

    [HttpPost]
    public IActionResult TaskSecond(string sentence)
    {
        if (!string.IsNullOrEmpty(sentence))
        {
            char[] charArray = sentence.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == 'c' || charArray[i] == 'C' || charArray[i] == 'С' || charArray[i] == 'с')
                {
                    for (int j = i; j < charArray.Length - 1; j++)
                    {
                        charArray[j] = charArray[j + 1];
                    }

                    charArray[charArray.Length - 1] = '_';

                    i--;
                }
            }

            string result = new string(charArray);

            ViewBag.ModifiedSentence = result;
        }
        else
        {
            ViewBag.ErrorMessage = "Введите предложение для обработки.";
        }

        return View();
    }

    public IActionResult TaskThird()
    {
        return View();
    }

    [HttpPost]
    public IActionResult TaskThird(string numbers)
    {

        if (!string.IsNullOrEmpty(numbers))
        {
            int[] numberArray = numbers.Split(' ').Select(int.Parse).ToArray();

            if (numberArray.Length % 2 == 0)
            {
                int sumOfSquares = 0;
                int sumOfCubes = 0;

                for (int i = 0; i < numberArray.Length; i += 2)
                {
                    int square = numberArray[i] * numberArray[i];
                    int cube = numberArray[i] * numberArray[i] * numberArray[i];

                    sumOfSquares += square;
                    sumOfCubes += cube;
                }

                ViewBag.SumOfSquares = sumOfSquares;
                ViewBag.SumOfCubes = sumOfCubes;
            }
            else
            {
                ViewBag.ErrorMessage = "Введите корректный массив из 2n чисел.";
            }
        }
        else
        {
            ViewBag.ErrorMessage = "Введите массив чисел.";
        }

        return View();
    }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

