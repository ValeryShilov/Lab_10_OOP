using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Product: Goods, IInit, ICloneable, IComparable
    {
        private DateOnly expirationDate;


        public DateOnly ExpirationDate { get; set; }

        public Product() : base()
        {
            ExpirationDate = new DateOnly();
        }

        public Product(string name, double price, double weight, DateOnly expirationDate) : base(name, price, weight)
        {
            ExpirationDate = expirationDate;
        }

        public Product(Product product)
        {
            product.Name = this.Name;
            product.Price = this.Price;
            product.Weight = this.Weight;
            product.ExpirationDate = this.ExpirationDate;
        }

        public override string GetString()
        {
            return base.GetString() +  $"\nГоден до {ExpirationDate}";
        }

        public override void Show()
        {
            Console.WriteLine(GetString());
        }

        public void ProductShow()
        {
            Console.WriteLine("Название товара: " + Name);
            Console.WriteLine("Цена товара: " + Price);
            Console.WriteLine("Вес товара: " + Weight);
            Console.WriteLine($"Годен до {ExpirationDate}");
        }

        public override void Init()
        {
            base.Init();
            bool isRead;
            do
            {
                isRead = true;
                Console.WriteLine("Введите дату окончания срока годности");
                int year = Menu.ReadInt("Введите год ", "Год должен быть не меньше текущего", "->", 2023, 3000);
                int month = Menu.ReadInt("Введите номер месяца", "Номер месяца должен быть от 1 до 12", "->", 1, 12);
                int day = Menu.ReadInt("Введите число", "Число должно быть от 1 до 31", "->", 1, 31);
                try
                {
                    ExpirationDate = new DateOnly(year, month, day);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    isRead = false;
                }
            } while (!isRead);
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            ExpirationDate = new DateOnly(2023, 12, rnd.Next(1, 31));
        }

        public override object Clone()
        {
            var newProduct = (Product)this.MemberwiseClone();
            return newProduct;
        }

        public override Product ShallowCopy()
        {
            return (Product)MemberwiseClone();
        }
    }
}
