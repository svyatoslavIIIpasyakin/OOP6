using System;

// 1. Создайте класс
public class MyClass
{
    // Свойства класса
    public string PropertyString { get; set; }
    public int PropertyInt { get; set; }
    public double PropertyDouble { get; set; }
    public string NullableString { get; set; }
    public int? NullableInt { get; set; }
    public double? NullableDouble { get; set; }

    // 2. Метод для вывода информации о классе
    public void PrintInfo()
    {
        Console.WriteLine("PropertyString: " + (PropertyString ?? "Data is absent"));
        Console.WriteLine("PropertyInt: " + (PropertyInt == 0 ? "Data is absent" : PropertyInt.ToString()));
        Console.WriteLine("PropertyDouble: " + (PropertyDouble == 0.0 ? "Data is absent" : PropertyDouble.ToString()));
        Console.WriteLine("NullableString: " + (NullableString ?? "Data is absent"));
        Console.WriteLine("NullableInt: " + (NullableInt.HasValue ? NullableInt.Value.ToString() : "Data is absent"));
        Console.WriteLine("NullableDouble: " + (NullableDouble.HasValue ? NullableDouble.Value.ToString() : "Data is absent"));
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 3. Создание экземпляров класса
        MyClass obj1 = new MyClass
        {
            PropertyString = "Hello",
            PropertyInt = 10,
            PropertyDouble = 3.14,
            NullableString = null,
            NullableInt = null,
            NullableDouble = 5.6
        };

        MyClass obj2 = new MyClass
        {
            PropertyString = "World",
            PropertyInt = 20,
            PropertyDouble = 6.28,
            NullableString = "Nullable String",
            NullableInt = 30,
            NullableDouble = null
        };

        // 4. Вызов метода для каждого экземпляра
        obj1.PrintInfo();
        Console.WriteLine("\n----------------------\n");
        obj2.PrintInfo();

        // 5. Попытка присвоения null свойству, которое не может принимать null
        // obj1.PropertyString = null; // Нельзя присвоить null

        // 6. Попытка присвоения null свойству, которое не может принимать null
        // obj1.PropertyInt = null; // Нельзя присвоить null
        // obj1.PropertyDouble = null; // Нельзя присвоить null

        // 7. Объяснение:
        // Компилятор выдаст ошибку, так как свойства, не допускающие null,
        // не могут быть присвоены значению null напрямую.

        // Создание переменной типа int и присвоение ей длины строки первого свойства
        int stringLength = obj1.PropertyString.Length;

        // 8. Функция для присваивания nullable свойству значения, если null
        Action<MyClass, string> assignIfNull = (obj, value) => obj.NullableString ??= value;

        // 9. Функция для возврата значения некоторого свойства с обработкой null
        Func<MyClass?, string> getPropertyOrDefault = obj => obj?.PropertyString ?? "Default Value";

        // 10. Функция для возврата nullable значения свойства с обработкой null
        Func<MyClass, string?> getNullablePropertyOrDefault = obj => obj.NullableString ?? "Default Value";

        // 11. Подавление предупреждения компилятора
#pragma warning disable CS8625
        obj1.PropertyString = null; // Подавление предупреждения компилятора
#pragma warning restore CS8625
    }
}
