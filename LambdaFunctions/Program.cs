

// Aufgabe 1
Func<int, int, int> lambdaSum = (int a, int b) => a + b;
int summe = lambdaSum(1, 13); // 14
Console.WriteLine($"Summe: {summe}");


// Aufgabe 2
Func<int, int> lambdaNumMultipliedBy2 = (int number) => number * 2;
int value = lambdaNumMultipliedBy2(13); // 26
Console.WriteLine($"Value: {value}");


// Aufgabe 3
List<int> intList = new List<int>();
intList.Add(13);
intList.Add(12);
intList.Add(11);
Func<List<int>, int> lambdaSumme = (List<int> a) => a.Sum();
int sum = lambdaSumme(intList);
Console.WriteLine($"Summe: {summe}");


// Aufgabe 4
Func<List<int>, List<int>> lambdaBigger10 = (List<int> a) => a.FindAll(a => a > 10);
List<int> intBigger10 = lambdaBigger10(intList);

foreach (int a in intBigger10)
{
    Console.Write($"{a}, ");
}
Console.WriteLine();


// Aufgabe 5
List<string> searchedList = new List<string>();
List<string> strings = new List<string>();
strings.Add("Andreas");
strings.Add("Florian");
strings.Add("Alex");

Func<List<string>, List<string>> myStringLambda = (List<string> a) => a.FindAll(a => a[0] == 'A');
searchedList = myStringLambda(strings);

foreach (string x in searchedList)
{
    Console.Write($"{x}, ");
}
Console.WriteLine();


// Aufgabe 6
// Die Lambda Function gibt den größten Integer Wert einer List<int> zurück


// Aufgabe 7
Func<List<string>, string> myStringLabda2 = (List<string> a) => a.OrderByDescending(x => x.Length).First();
string myLongestString = myStringLabda2(strings);
Console.WriteLine($"Longest string: {myLongestString}");


// Aufgabe 8
List<int> age = new List<int>();
age.Add(18);
age.Add(2);
age.Add(30);
age.Add(4);

Func<List<int>, List<int>> myIntListLambda = (List<int> a) => a.FindAll(a => a >= 18);
List<int> over18 = new List<int>();

over18 = myIntListLambda(age);

foreach (int x in over18)
{
    Console.WriteLine($"Over 18: {x}");
}
Console.WriteLine();


// Aufgabe 9
List<bool> versendet = new List<bool>();
List<bool> alleUnversendeten = new List<bool>();
versendet.Add(true);
versendet.Add(false);
versendet.Add(true);
versendet.Add(false);

Func<List<bool>, List<bool>> myBoolLambdaFunc = (List<bool> a) => a.FindAll(x => x == false);
alleUnversendeten = myBoolLambdaFunc(versendet);

foreach (bool x in alleUnversendeten)
{
    Console.WriteLine($"Versendet: {x}");
}


