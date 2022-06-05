using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IDeserializable<T>
    {
        public T DeserializarFromXML(string path);

        public T DeserializarFromJson(string path);
    }
}
