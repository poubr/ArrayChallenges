using System.Linq;
using System.Text;

/*
Challenge 1. Given a jagged array of integers (two dimensions).
Find the common elements in the nested arrays.
Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
*/

int[] CommonItems(int[][] jaggedArray)
{   
    List<int> arr1 = jaggedArray[0].ToList();
    List<int> arr2 = jaggedArray[1].ToList();
    List<int> commonItems = arr1.Intersect(arr2).ToList();
    return commonItems.ToArray();
    
    /*
    I'm using Lists and LINQ as it is faster both in code and performance,
    but for strictly array methods I would use the following:

    int[] commonArrays = new int[0];
    int shortestArrLength = int.MaxValue;
    int shortestIdx = 0;
    int longerIdx;
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        if (jaggedArray[i].Length < shortestArrLength)
        {
            shortestArrLength = jaggedArray[i].Length;
            shortestIdx = i;
        }
    }
    if (shortestIdx == 0)
    {
        longerIdx = 1;
    } 
    else
    {
        longerIdx = 0;
    }
    for (int j = 0; j < jaggedArray[shortestIdx].Length; j++)
    {
        int currentElement = jaggedArray[shortestIdx][j];
    if (jaggedArray[longerIdx].Contains(currentElement))
    {
        Array.Resize(ref commonArrays, commonArrays.Length + 1);
        commonArrays[commonArrays.Length - 1] = currentElement;
    }
    }
    return commonArrays;
    */

}
int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
int[] arr1Common = CommonItems(arr1);
/* write method to print arr1Common */
Console.WriteLine(string.Join(", ", arr1Common));

/* 
Challenge 2. Inverse the elements of a jagged array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
*/
void InverseJagged(int[][] jaggedArray)
{
    List<List<int>> jaggedList = new List<List<int>>();
    // Since I wouldn't know how how many arrays inside the jagged array
    for (int i=0; i < jaggedArray.Length; i++)
    {
        jaggedList.Add(new List<int>());
    }

    for (int x=0; x < jaggedArray.Length; x++)
    {
        for (int y=jaggedArray[x].Length-1; y >=0; y--)
        {
            jaggedList[x].Add(jaggedArray[x][y]);
        }
    }
    int[][] reverseArray = jaggedList.Select(list => list.ToArray()).ToArray();
    for (int i = 0; i < reverseArray.Length; i++)
    {
        Console.Write("[");
        Console.Write(string.Join(", ", reverseArray[i]));
        Console.Write("]");
    }
}
int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
InverseJagged(arr2);
/* write method to print arr2 */
// have not written a method to print since the function is void, so I print inside of it

// empty line as previous print doesn't include it
Console.WriteLine();

/* 
Challenge 3.Find the difference between 2 consecutive elements of an array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
 */
void CalculateDiff(int[][] jaggedArray)
{
    List<List<int>> jaggedList = new List<List<int>>();
    // Since I wouldn't know how how many arrays inside the jagged array
    for (int i=0; i < jaggedArray.Length; i++)
    {
        jaggedList.Add(new List<int>());
    }
    for (int x=0; x < jaggedArray.Length; x++) {
        for (int y=0; y < jaggedArray[x].Length - 1; y++)
            {
                jaggedList[x].Add(jaggedArray[x][y] - jaggedArray[x][y + 1]);
            }
    }
    int[][] differenceArray = jaggedList.Select(list => list.ToArray()).ToArray();
    for (int i = 0; i < differenceArray.Length; i++)
    {
        Console.Write("[");
        Console.Write(string.Join(", ", differenceArray[i]));
        Console.Write("]");
    }
}
int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
CalculateDiff(arr3);
/* write method to print arr3 */
// have not written a method to print since the function is void, so I print inside of it

// empty line as previous print doesn't include it
Console.WriteLine();
/* 
Challenge 4. Inverse column/row of a rectangular array.
For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
Expected result: {{1,4},{2,5},{3,6}}
 */
int[,] InverseRec(int[,] recArray)
{
    List<List<int>> recList = new List<List<int>>();
    int rowCount = recArray.GetLength(0);
    int colCount = recArray.GetLength(1);
    for (int i = 0; i < rowCount; i++)
    {
        recList.Add(new List<int>());
        for (int j = 0; j < colCount; j++)
        {
            recList[i].Add(recArray[i, j]);
        }
    }
    int[,] reverseColArray = new int[colCount, rowCount];
    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < colCount; j++)
        {
            reverseColArray[j, i] = recList[i][j];
        }
    }
    return reverseColArray;
}
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);
/* write method to print arr4Inverse */
void PrintInverseColArray (int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($" {arr[i, j]} ");
        }
        Console.Write("]");
    }
}
PrintInverseColArray(arr4Inverse);


Console.WriteLine();

/* 
Challenge 5. Write a function that accepts a variable number of params of any of these types: 
string, number. 
- For strings, join them in a sentence. 
- For numbers then sum them up. 
- Finally print everything out. 
Example: Demo("hello", 1, 2, "world") 
Expected result: hello world; 3 */
void Demo(params object[] values)
{
    int result = 0;
    StringBuilder sb = new StringBuilder();
    foreach (var value in values)
    {
        if (value is int number)
        {
            result += number;
        }
        else if (value is string token)
        {
            sb.Append(token);
            sb.Append(" ");
        }
    }
    if (sb.Length > 0 && sb[sb.Length -1] == ' ')
    {
        sb.Remove(sb.Length -1, 1);
    }
    Console.WriteLine($"{sb}; {result}");
}
Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"


/* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
and if they’re string, lengths have to be more than 5. 
If they’re numbers, they have to be more than 18. */
void SwapTwo(ref object obj1, ref object obj2)
{
    if (obj1 != null && obj2 != null && obj1.GetType() == obj2.GetType())
    {
        Console.WriteLine($"Object 1 {obj1.ToString()}");
        Console.WriteLine($"Object 2 {obj2.ToString()}");
        if (obj1.GetType() == typeof(string))
        {
            string? token1 =  obj1.ToString();
            string? token2 =  obj2.ToString();
            if (token1?.Length > 5 && token2?.Length > 5)
            {
                obj1 = token2;
                obj2 = token1;
                Console.WriteLine("Switched:");
                Console.WriteLine($"Object 1 {obj1.ToString()}");
                Console.WriteLine($"Object 2 {obj2.ToString()}");
            }
            else
            {
                Console.WriteLine("Objects are too short; cannot switch");
            }
        }
        else if (obj1.GetType() == typeof(int))
        {
            int num1 = Convert.ToInt32(obj1);
            int num2 = Convert.ToInt32(obj2);
            if (num1 > 18 && num2 > 18)
            {
                obj1 = num2;
                obj2 = num1;
                Console.WriteLine("Switched:");
                Console.WriteLine($"Object 1 {obj1.ToString()}");
                Console.WriteLine($"Object 2 {obj2.ToString()}");
            }
            else
            {
                Console.WriteLine("Objects are too small; cannot switch.");
            }
        } 
        else
        {
            object aux = obj1;
            obj1 = obj2;
            obj2 = aux;
            Console.WriteLine("Switched:");
            Console.WriteLine($"Object 1 {obj1.ToString()}");
            Console.WriteLine($"Object 2 {obj2.ToString()}");
        }
    }
    else
    {
        Console.WriteLine("Objects are not the same type.");
    }
}
// Different types
object obj1 = "hello";
object obj2 = 10;
SwapTwo(ref obj1, ref obj2);

// Same types but not int or string
obj1 = true;
obj2 = true;
SwapTwo(ref obj1, ref obj2);

// Strings but too short
obj1 = "test";
obj2 = "abc";
SwapTwo(ref obj1, ref obj2);

// Strings with right length
obj1 = "banana";
obj2 = "watermelon";
SwapTwo(ref obj1, ref obj2);

// Ints too small
obj1 = 10;
obj2 = 5;
SwapTwo(ref obj1, ref obj2);

// Ints right size
obj1 = 20;
obj2 = 30;
SwapTwo(ref obj1, ref obj2);


/* Challenge 7. Write a function that does the guessing game. 
The function will think of a random integer number (lets say within 100) 
and ask the user to input a guess. 
It’ll repeat the asking until the user puts the correct answer. */
void GuessingGame()
{
    Random random = new Random();
    int randomNumber = random.Next(1, 101);
    string? input;
    int number;
    do
    {
        Console.WriteLine("Guess a number from 1 to 100 (or 'exit' to quit)");
        input = Console.ReadLine();
        if (input != null && input.Equals("exit"))
        {
            break;
        }
        bool success = int.TryParse(input, out number);
        if (success)
        {
            if (number == randomNumber)
            {
                Console.WriteLine("You guessed the number! Congratulations!");
                break;
            }
            else if (number < randomNumber)
            {
                Console.WriteLine("Too small!");
            }
            else
            {
                Console.WriteLine("Too large!");
            }
        }
        else
        {
            Console.WriteLine("Please enter a number.");
        }
    }
    while (true);
    Console.WriteLine("Thank you for playing! Goodbye!");
}
GuessingGame();

/* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
Complete the required features in OrderItem and Cart, so that the test codes are error-free */

var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);

var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

Console.WriteLine(orderItem1);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

//get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1, 3];
Console.WriteLine(subCart);
Console.WriteLine(cart);

// get index of item in a cart
int index = cart.Index(orderItem2);

// Display the result
Console.WriteLine($"Index of Order Item 2 in cart: {index}");

class Product
{
    public int Id { get; set; }
    public int Price { get; set; }
    public Product(int id, int price)
    {
        this.Id = id;
        this.Price = price;
    }
}

class OrderItem : Product
{
    public int Quantity { get; set; }
    public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
    {
        this.Quantity = quantity;
    }
    /* Override ToString() method so the item can be printed out conveniently with Id, Price, and Quantity */
    public override string ToString()
    {
        return $"Item ID: {Id}\n Price: {Price}\n Amount: {Quantity}";
    }
}

class Cart
{
    private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

    /* Write indexer property to get nth item from _cart */
    public OrderItem this[int index]
    {
        get
        {
            return _cart[index];
        }
    }
    /* Write indexer property to get items of a range from _cart */
    public Cart this[int startIdx, int endIdx]
    {
        get
        {
            Cart subcart = new Cart();
            for (int i = startIdx; i <= endIdx; i++)
            {
                subcart.AddToCart(_cart[i]);
            }
            return subcart;
        }
    }

    public void AddToCart(params OrderItem[] items)
    {
        /* this method should check if each item exists --> increase value / or else, add item to cart */
        foreach (OrderItem item in items)
        {
            var itemToProcess = _cart.FirstOrDefault(cartItem => cartItem.Id == item.Id);
            if (itemToProcess != null)
            {
                itemToProcess.Quantity += item.Quantity;
            }
            else
            {
                _cart.Add(item);
            }
        }
    }
    /* Write another method called Index */
    public int Index (OrderItem item)
    {
        int idx = _cart.FindIndex(foundItem => foundItem.Id == item.Id);
        return idx;
    }

    /* Write another method called GetCartInfo(), which out put 2 values: 
    total price, total products in cart*/
    public void GetCartInfo(out int totalPrice, out int totalQuantity)
    {
        totalPrice = 0;
        totalQuantity = 0;
        if (_cart.Any())
        {
            foreach (OrderItem item in _cart)
            {
                totalQuantity += item.Quantity;
                totalPrice += (item.Quantity * item.Price);
            }
        }
    } 
    /* Override ToString() method so Console.WriteLine(cart) can print
    id, unit price, unit quantity of each item*/
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (_cart.Any())
        {
            foreach (OrderItem item in _cart)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        else
        {
            return "No items in the cart.";
        }
    }
}