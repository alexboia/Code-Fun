using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosettaCode.RankingMethods
{
    public class Item : IEquatable<Item>
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public bool Equals(Item other)
        {
            if (other == null)
                return false;
            return string.Equals(other.Name, Name);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        public override int GetHashCode()
        {
            return (Name ?? string.Empty).GetHashCode();
        }
    }
}
