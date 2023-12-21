using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class NotHierarchyClass : IInit
    {
        public string? Id { get; private set; }

        public void Init()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void RandomInit()
        {
            Id = $"Random_{new Random().Next(1, 100)}";
        }

        public void Show()
        {
            Console.WriteLine(Id);
        }
    }
}
