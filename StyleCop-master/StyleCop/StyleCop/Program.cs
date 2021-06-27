using System;

if (int.TryParse(Console.ReadLine(), out var length))
{
    var sourceArray = GetRandomArray(length, 1, 26);
    var evenArray = new int[EvenOddCount(sourceArray, Parity.Even)];
    var oddArray = new int[EvenOddCount(sourceArray, Parity.Odd)];
    var evenCounter = 0;
    var oddCounter = 0;

    foreach (var item in sourceArray)
    {
        if (item % 2 == 0)
        {
            evenArray[evenCounter] = item;
            evenCounter++;
        }
        else
        {
            oddArray[oddCounter] = item;
            oddCounter++;
        }
    }

    var evenLettersArray = ToLettersArray(evenArray);
    var oddLettersArray = ToLettersArray(oddArray);

    ToUpperCase(evenLettersArray, out var evenUpperCounter);
    ToUpperCase(oddLettersArray, out var oddUpperCounter);

    if (evenUpperCounter > oddUpperCounter)
    {
        Console.WriteLine("Even array has more uppercase letters");
    }
    else if (evenUpperCounter < oddUpperCounter)
    {
        Console.WriteLine("Odd array has more uppercase letters");
    }
    else
    {
        Console.WriteLine("Arrrays have the same quantity of uppercase letters");
    }

    Console.WriteLine($"Even array: {string.Join(' ', evenLettersArray)}");
    Console.WriteLine($"Odd  array: {string.Join(' ', oddLettersArray)}");
}

int[] GetRandomArray(int lenght, int minValue, int maxValue)
{
    var resultArray = new int[lenght];
    for (var i = 0; i < length; i++)
    {
        resultArray[i] = new Random().Next(minValue, maxValue + 1);
    }

    return resultArray;
}

int EvenOddCount(int[] array, Parity parity)
{
    var counter = 0;

    foreach (var item in array)
    {
        if (item % 2 == 0)
        {
            counter++;
        }
    }

    if (parity == Parity.Even)
    {
        return counter;
    }
    else
    {
        return array.Length - counter;
    }
}

string[] ToLettersArray(int[] array)
{
    var lettersArray = new string[array.Length];

    for (var i = 0; i < array.Length; i++)
    {
       lettersArray[i] = ((Alphabeth)array[i]).ToString().ToLower();
    }

    return lettersArray;
}

void ToUpperCase(string[] lettersArray, out int upperCounter)
{
    var upperLetters = "aeidhj";
    upperCounter = 0;
    for (var i = 0; i < lettersArray.Length; i++)
    {
        for (var j = 0; j < upperLetters.Length; j++)
        {
            if (string.Equals(lettersArray[i], upperLetters[j].ToString(), StringComparison.OrdinalIgnoreCase))
            {
               lettersArray[i] = lettersArray[i].ToUpper();
               upperCounter++;
               break;
            }
        }
    }
}