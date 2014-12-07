using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public interface IGalaxy
    {
        void AddCurrency(string localCurrency, char romanValue);

        void AddProductsValue(string productName, long productValue);
    }
}
