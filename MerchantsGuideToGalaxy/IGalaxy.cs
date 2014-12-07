using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public interface IGalaxy
    {
        void AddCurrency(string localCurrency, string romanValue);

        void AddProductsValue(string productName, float productValue);

        string GetRomanValue(string localCurrency);

        float GetProductsValue(string productName);
    }
}
