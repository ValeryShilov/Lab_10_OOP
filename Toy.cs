using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Toy: Goods, IInit, ICloneable, IComparable
    {
        private int recommendedAge;

        public int RecommendedAge
        {
            get => recommendedAge;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка, возраст не может быть меньше 0");
                }
                else
                    recommendedAge = value;
            }
        }

        public Toy() :base()
        {
            recommendedAge = 0;
        }

        public Toy(string name, double price, double weight, int recommendedAge) :base(name,price,weight)
        {
            RecommendedAge = recommendedAge;
        }

        public Toy(Toy toy)
        {
            toy.Name = this.Name;
            toy.Price = this.Price;
            toy.Weight = this.Weight;
            toy.RecommendedAge = this.RecommendedAge;
        }

        public override string GetString()
        {
            return base.GetString() + $"\nРекомендуемый возраст: {RecommendedAge}";
        }

        public override void Show()
        {
            Console.WriteLine(GetString());
        }

        public void ToyShow()
        {
            Console.WriteLine("Название товара: " + Name);
            Console.WriteLine("Цена товара: " + Price);
            Console.WriteLine("Вес товара: " + Weight);
            Console.WriteLine("Рекомендуемый возраст: " + RecommendedAge);
        }

        public override void Init()
        {
            base.Init();
            RecommendedAge = Menu.ReadInt("Введите рекомендуемый возраст", "Возраст должен быть неотрицательным числом", "0");
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            RecommendedAge = rnd.Next(0, 18);
        }

        public override object Clone()
        {
            var newToy = (Toy)MemberwiseClone();
            return newToy;
        }
        public override Toy ShallowCopy()
        {
            return (Toy)MemberwiseClone();
        }
    }
}
