using System.Net.NetworkInformation;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace Lab_10
{
    public class Program
    {
        static Goods[] CreateRandomArrayGoods()
        {
            int size = Menu.ReadInt("Введите размер массива", "Размер массива должен быть натуральным числом", "+");
            Goods[] goods = new Goods[size];
            for (int i = 0; i < size; i++)
            {
                Random rndNum = new Random();
                int NumClass = rndNum.Next(1, 5);
                switch(NumClass)
                {
                    case 1:
                        goods[i] = new Goods();
                        goods[i].RandomInit();
                        break;
                    case 2:
                        goods[i] = new Product();
                        goods[i].RandomInit();
                        break;
                    case 3:
                        goods[i] = new MilkProduct();
                        goods[i].RandomInit();
                        break;
                    case 4:
                        goods[i] = new Toy();
                        goods[i].RandomInit();
                        break;
                }
            }
            return goods;
        }

        static Goods[] CreateManualArrayGoods()
        {
            int size = Menu.ReadInt("Введите размер массива", "Размер массива должен быть натуральным числом", "+");
            Goods[] goods = new Goods[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Добавление элемента в массив {i+1}/{size}\nДоступные типы данных");
                Console.WriteLine("1.Товар\n2.Продукт\n3.Молочный продукт\n4.Игрушка");
                int NumClass = Menu.ReadInt("Введите номер типа добавляемого элемента", "Неверный номер типа", "->", 1, 4);
                switch (NumClass)
                {
                    case 1:
                        goods[i] = new Goods();
                        goods[i].Init();
                        break;
                    case 2:
                        goods[i] = new Product();
                        goods[i].Init();
                        break;
                    case 3:
                        goods[i] = new MilkProduct();
                        goods[i].Init();
                        break;
                    case 4:
                        goods[i] = new Toy();
                        goods[i].Init();
                        break;
                }
            }
            return goods;
        }

        static void ShowGoodsArrayVirtual(Goods[] arr)
        {
            foreach(var item in arr)
            {
                item.Show();
                Console.WriteLine();
            }
        }

        static void ShowGoodsArrayNoVirtual(Goods[] arr)
        {
            foreach(var item in arr)
            {
                item.GoodsShow();
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string choice;
            Goods[] goodsArray = null;
            do
            {
                Console.WriteLine("----- 1 часть --------");
                Console.WriteLine("1.Сгенерировать массив (рандомно)");
                Console.WriteLine("2.Сгенерировать массив (вручную)");
                Console.WriteLine("3.Просмотреть массив (виртуальный метод)");
                Console.WriteLine("4.Просмотреть массив (не виртульный метод)");
                Console.WriteLine("------ 2 часть -------");
                Console.WriteLine("5.Запрос: Количество товара заданного наименования");
                Console.WriteLine("6.Запрос: Количество просроченных продуктов");
                Console.WriteLine("7.Запрос: Суммарная стоимость товара заданного наименования");
                Console.WriteLine("------- 3 часть --------");
                Console.WriteLine("8.Демонтрация работы IInit");
                Console.WriteLine("9.Демонстрация сортировки, используя IComparable (по названию)");
                Console.WriteLine("10.Демонстрация сортировки, используя ICompare (по весу)");
                Console.WriteLine("11. Демонстрация клонирования");
                Console.WriteLine("0.Завершить работу");
                Console.Write("Выберите задание: ");
                choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        goodsArray = CreateRandomArrayGoods();
                        Console.WriteLine("Массив сгенерирован, для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        goodsArray = CreateManualArrayGoods();
                        Console.WriteLine("Массив сгенерирован, для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        ShowGoodsArrayVirtual(goodsArray);
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case "4":
                        ShowGoodsArrayNoVirtual(goodsArray);
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Write("Введите наименование товара: ");
                        string goodsName = Console.ReadLine();
                        Console.Write($"Количество товара с наименованием {goodsName}: "); 
                        Console.WriteLine(Requests.GetCountGoods(goodsArray, goodsName));
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case "6":
                        int today = Menu.ReadInt("Введите сегодняшнее число", "Число должно быть от 1 до 31", "->", 1, 31);
                        DateOnly day = new DateOnly(2023,12, today);
                        Console.Write("Количество просроченных продуктов: ");
                        Console.WriteLine(Requests.GetCountOverdueProduct(goodsArray, day));
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Write("Введите наименование товара: ");
                        goodsName = Console.ReadLine();
                        Console.Write($"Суммарная стоимость товара с наименованием {goodsName}: ");
                        Console.WriteLine(Requests.GetTotalPriceOfGoods(goodsArray, goodsName));
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case "8":
                        Console.WriteLine("\tИнтерфейс IInit: ");
                        IInit[] objects = new IInit[]
                        {
                            new Goods(),
                            new Product(),
                            new MilkProduct(),
                            new Toy(),
                            new NotHierarchyClass()
                        };

                        Console.WriteLine("IInit[5] objects = new IInit[5] - состоит из объектов Goods, " +
                            "Product, MilkProduct, Toy, NotHierarchyClass");
                        int count = 1;
                        foreach (var item in objects)
                        {
                            Console.WriteLine($"Создается объект под номером {count++}: {item.GetType()}");
                            item.RandomInit();
                            item.Show();
                            Console.WriteLine();
                        }
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case "9":
                        if (goodsArray != null)
                        {
                            Array.Sort(goodsArray);
                            Console.WriteLine("Отсортированный массив: ");
                            ShowGoodsArrayVirtual(goodsArray);
                            Console.WriteLine("Для продолжения нажмите любую клавишу...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка, массив пуст, для продолжения нажмите любую клавишу...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case "10":
                        if (goodsArray != null)
                        {
                            Array.Sort(goodsArray, new SortByWeight());
                            Console.WriteLine("Отсортированный массив по весу: ");
                            ShowGoodsArrayVirtual(goodsArray);
                            Console.WriteLine("Для продолжения нажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Ошибка, массив пуст, для продолжения нажмите любую клавишу...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "11":
                        //Product originalProduct = new();
                        //originalProduct.RandomInit();
                        ////Product cloneProduct = (Product)originalProduct.Clone();

                        //Console.WriteLine("Объекты до изменения:");
                        //Console.WriteLine();
                        //Console.WriteLine("Первоначальный объект");
                        //originalProduct.Show();
                        //Console.WriteLine();
                        //Console.WriteLine("Склонированный объект");
                        //((Product)originalProduct.Clone()).Show();
                        ////cloneProduct.Show();
                        //Console.WriteLine();
                        //Console.WriteLine("Скопироавнный объект");
                        //originalProduct.ShallowCopy().Show();
                        //Console.WriteLine();
                        //originalProduct.Price = 999999;
                        //Console.WriteLine("Объекты после изменения цены в первоначальном:");
                        //Console.WriteLine();
                        //Console.WriteLine("Первоначальный объект");
                        //originalProduct.Show();
                        //Console.WriteLine();
                        //Console.WriteLine("Склонированный объект");
                        //((Product)originalProduct.Clone()).Show();
                        ////cloneProduct.Show();
                        //Console.WriteLine();
                        //Console.WriteLine("Скопироавнный объект");
                        //originalProduct.ShallowCopy().Show();
                        //Console.WriteLine();


                        var originalProduct = new Goods();
                        originalProduct.RandomInit();
                        originalProduct.Tags = new List<string> { "1", "2", "3" };
                        var clonedProduct = (Goods)originalProduct.Clone();

                        Console.WriteLine("До изменения полное копирование:");
                        clonedProduct.Show();
                        Console.Write("Тег: ");
                        foreach (var item in clonedProduct.Tags)
                            Console.Write(item + " ");
                        Console.WriteLine();
                        Console.WriteLine();

                        originalProduct.Tags.Add("999");

                        Console.WriteLine("После изменеия полное копирование:");
                        clonedProduct.Show();
                        Console.Write("Тег: ");
                        foreach (var item in clonedProduct.Tags)
                            Console.Write(item + " ");
                        Console.WriteLine();
                        Console.WriteLine();

                        originalProduct.RandomInit();
                        originalProduct.Tags = new List<string> { "1", "2", "3" };
                        var shallowCopyProduct = originalProduct.ShallowCopy();

                        Console.WriteLine("До изменения неполное копирование:");
                        shallowCopyProduct.Show();
                        Console.Write("Тег: ");
                        foreach (var item in shallowCopyProduct.Tags)
                            Console.Write(item + " ");
                        Console.WriteLine();
                        Console.WriteLine();

                        originalProduct.Tags.Add("999");

                        Console.WriteLine("После изменения неполное копирование:");
                        shallowCopyProduct.Show();
                        Console.Write("Тег: ");
                        foreach (var item in shallowCopyProduct.Tags)
                            Console.Write(item + " ");
                        Console.WriteLine();
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;

                }
            } while (choice != "0");

        }   
    }
}