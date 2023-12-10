using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_module_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Type type = typeof(Console);
            MethodInfo[] methods = type.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }

            // Task 2 
            MyClass myObject = new MyClass
            {
                Name = "John",
                Age = 30,
                Salary = 50000.0
            };

            Type type1 = myObject.GetType();
            PropertyInfo[] properties = type1.GetProperties();

            foreach (var prop in properties)
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(myObject)}");
            }

            // Task 3
            string originalString = "Hello, World!";
            int length = 5;

            MethodInfo method1 = typeof(string).GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
            if (method1 != null)
            {
                object[] parameters = { 0, length };
                string result = (string)method1.Invoke(originalString, parameters);
                Console.WriteLine($"Substring of length {length}: {result}");
            }

            // Task 4
            Type type2 = typeof(List<>);
            Type[] typeArgs = { typeof(int) }; // Замените тип T на нужный тип

            Type genericType = type2.MakeGenericType(typeArgs);
            ConstructorInfo[] constructors = genericType.GetConstructors();

            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }


            Console.ReadLine();
        }
    }
}
class MyClass
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }
}
