using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Goods : IInit, ICloneable, IComparable
    {
        private string name;
        private double price;
        private double weight;
        public List<string> Tags { get; set; } // для показа различия между поверх и полным копированием
        public string Name { get; set; }

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка, цена не может быть меньше 0");
                }
                else
                    price = value;
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0)
                    throw new Exception("Ошибка, вес не может быть меньше 0");
                else
                    weight = value;
            }
        }

        public Goods(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public Goods()
        {
            Name = " ";
            Price = 0;
            Weight = 0;
        }

        public Goods(Goods goods)
        {
            goods.Name = this.Name;
            goods.Price = this.Price;
            goods.Weight = this.Weight;
        }

        public void GoodsShow()
        {
            Console.WriteLine(GetString());
        }

        public virtual void Show()
        {
            Console.WriteLine("Название товара: " + Name);
            Console.WriteLine("Цена товара: " + Price);
            Console.WriteLine("Вес товара: " + Weight);
        }

        public virtual string GetString()
        {
            var row = $"Название товара: {Name}\nЦена товара: {Price}\nВес товара: {Weight}";
            return row;
        }

        public void GoodsInit()
        {
            Console.Write("Введите название товара: ");
            Name = Console.ReadLine();
            Price = Menu.ReadDouble("Введите цену товара", "Цена должна быть вещественным неотрицательным числом", "0");
            Weight = Menu.ReadDouble("Введите вес товара", "Вес товара должн быть вещественным неотрицательным числом", "0");
        }

        public virtual void Init()
        {
            Console.Write("Введите название товара: ");
            Name = Console.ReadLine();
            Price = Menu.ReadDouble("Введите цену товара", "Цена должна быть вещественным неотрицательным числом", "0");
            Weight = Menu.ReadDouble("Введите вес товара", "Вес товара должн быть вещественным неотрицательным числом", "0");
        }

        public virtual void RandomInit()
        {
            Random rnd = new Random();
            Name = "Товар_" + rnd.Next(1, 10);
            Price = Math.Round(rnd.NextDouble() * 10000, 2);
            Weight = Math.Round(rnd.NextDouble() * 100, 2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Goods goods)
            {
                return Name == goods.Name && Price == goods.Price && Weight == goods.Weight;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, Weight);
        }

        public virtual object Clone()
        { 
            return new Goods() { Name = Name, Price = Price, Weight = Weight, Tags = new List<string>(Tags) };
        }
        public virtual Goods ShallowCopy()
        {
            return (Goods)this.MemberwiseClone();
        }

        public int CompareTo(object? obj)
        {
            if (obj is null)
                return 1;
            else
            {
                var tempGoods = (Goods)obj;
                if (String.Compare(Name, tempGoods.Name) > 0)
                    return 1;
                else if (String.Compare(Name, tempGoods.Name) < 0)
                    return -1;
                if (Price > tempGoods.Price)
                    return 1;
                else if (Price < tempGoods.Price)
                    return -1;
                if (Weight > tempGoods.Weight)
                    return 1;
                if (Weight < tempGoods.Weight)
                    return -1;
                return 0;
            }
        }
    }
}
