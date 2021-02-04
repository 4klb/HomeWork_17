using System;
using System.Collections.Generic;
using System.Reflection;

namespace HomeWork_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к сборке");
            string incomingString = Console.ReadLine();
            Assembly path = Assembly.LoadFile($@"{incomingString}");

            var tupleList = new List<Tuple<bool, string>>()
            {
                Tuple.Create(true,"true"),
                Tuple.Create(false,"false"),
            };

            var boolTrue = tupleList[0].Item1;
            var boolFalse = tupleList[1].Item2;

            var dictionaryOne = new Dictionary<string, string>();
            dictionaryOne.Add("string", "nvarchar");
            dictionaryOne.Add("double", "float");
            dictionaryOne.Add("DateTime", "datetime");
            dictionaryOne.Add("int", "int");

            string stringValue = dictionaryOne["string"];
            string doubleValue = dictionaryOne["double"];
            string dateTimeValue = dictionaryOne["DateTime"];
            string intValue = dictionaryOne["int"];

            foreach (Type type in path.GetTypes())
            {
                if (type.IsClass)
                {
                    Console.WriteLine($"Create table {type.Name}(");
                    Console.WriteLine("id int primary key identity,");
                    foreach (var member in type.GetMembers())
                    {
                        if (member is PropertyInfo)
                        {
                            var propertyInfo = member as PropertyInfo;

                            if (propertyInfo.PropertyType == typeof(string))
                            {
                                Console.WriteLine($"{propertyInfo.Name} {stringValue}(max) null,");
                            }
                            else if (propertyInfo.PropertyType == typeof(double))
                            {
                                Console.WriteLine($"{propertyInfo.Name} {doubleValue} not null,");
                            }
                            else if (propertyInfo.PropertyType == typeof(DateTime))
                            {
                                Console.WriteLine($"{propertyInfo.Name} {dateTimeValue} null,");
                            }
                            else if (propertyInfo.PropertyType == typeof(int))
                            {
                                Console.WriteLine($"{propertyInfo.Name} {intValue} not null,");
                            }
                            //else if (propertyInfo.PropertyType == typeof(bool) == true)
                            //{
                            //    Console.WriteLine($"{propertyInfo.Name} {boolTrue} null,");
                            //}
                            //else if (propertyInfo.PropertyType == typeof(bool) == false)
                            //{
                            //    Console.WriteLine($"{propertyInfo.Name} {boolFalse} null,");
                            //}
                        }
                    }
                    Console.WriteLine(");");
                }
            }
        }
    }
}
