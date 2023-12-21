using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Requests
    {
        // Количество товара заданного наименования
        public static int GetCountGoods(Goods[] goods, string? goodsName)
        {
            return goods.Count(g => g.Name == goodsName);
        }

        //Количество просроченных продуктов
        public static int GetCountOverdueProduct(Goods[] goods, DateOnly? today)
        {
            if (goods is null || goods.Length == 0)
            {
                Console.WriteLine("Массив товаров пуст");
                return 0;
            }

            return goods
            .OfType<Product>() // Выбор только объектов типа Product
            .Where(product => product.ExpirationDate < today).Count();
        }

        //Суммарная стоимость товара заданного наименования
        public static double GetTotalPriceOfGoods(Goods[] goods, string? goodsName)
        {
            return goods.Where(g => g.Name == goodsName).Sum(g => g.Price);
        }

        public static Goods? BinarySearchByName(List<Goods> goodsList, string? target)
        {
            if (target is null) return null;
            int min = 0;
            int max = goodsList.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                int comparison = goodsList[mid].Name.CompareTo(target);

                if (comparison == 0)
                {
                    return goodsList[mid];
                }

                if (comparison < 0)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            return null;
        }
    }
}
