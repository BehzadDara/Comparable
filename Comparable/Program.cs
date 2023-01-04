List<int> myList = new() { 10, 5, 20 };
myList.OrderBy(x => x).Print();

// in .net 7 we can use Order and it will sort it without telling the field
List<int> myList2 = new() { 10, 5, 20 };
myList2.Order().Print();

// for using .Order in classes, we must implement IComparable ( classes are complex with different fields )
// .Order and .OrderDescending use CompareTo method for sort in Classes
// without IComparable it's a run time error
List<MyClass> myList3 = new()
{
    new MyClass { MyProperty1 = 5, MyProperty2 = 2 },
    new MyClass { MyProperty1 = 3, MyProperty2 = 4 },
    new MyClass { MyProperty1 = 4, MyProperty2 = 1 }
};
//Console.WriteLine(myList2.First().CompareTo(myList2.Last()));
myList3.Order().Print();

public class MyClass : IComparable<MyClass>
{
    public int MyProperty1 { get; set; }
    public int MyProperty2 { get; set; }

    public int CompareTo(MyClass? other)
    {
        if (other == null) return 1;
        if (other == this) return 0;
        if (other.MyProperty1 < MyProperty1) return 1;
        if (other.MyProperty1 == MyProperty1) return 0;
        else return -1;
    }
}

public static class ExtensionMethod
{
    public static void Print(this IEnumerable<int> myList)
    {
        foreach (var item in myList)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
    }

    public static void Print(this IEnumerable<MyClass> myList)
    {
        foreach (var item in myList)
        {
            Console.Write($"{item.MyProperty1}&{item.MyProperty2}, ");
        }
        Console.WriteLine();
    }
}
