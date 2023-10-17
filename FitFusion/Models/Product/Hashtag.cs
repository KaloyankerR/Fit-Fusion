using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Product
{
    public class Hashtag
    {
        protected int id;
        public int Id { get { return id; } protected set { id = value; } }
        protected string tag;
        public string Tag { get { return tag; } protected set { tag = value; } }

        public Hashtag() { }

        public Hashtag(int id, string tag)
        {
            this.id = id;
            this.tag = tag;
        }

        public override string ToString()
        {
            return $"{Tag}";
        }
    }
}
