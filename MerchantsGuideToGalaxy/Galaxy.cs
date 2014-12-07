using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class Galaxy : IGalaxy
    {
        private Dictionary<string, string> CurrencyMapper = new Dictionary<string, string>();

        private Dictionary<string, float> ProductsValue = new Dictionary<string,float>();

        public void AddCurrency(string localCurrency, string romanValue)
        {
            try
            {
                string existingValue;
                if (CurrencyMapper.TryGetValue(localCurrency, out existingValue))
                    return;
                CurrencyMapper.Add(localCurrency, romanValue);
            }
            catch (Exception)
            {
            }
        }

        public void AddProductsValue(string productName, float productValue)
        {
            try
            {
                float value;
                if (ProductsValue.TryGetValue(productName, out value))
                    return;
                ProductsValue.Add(productName, productValue);
            }
            catch (Exception)
            {
            }
        }
        
        public string GetRomanValue(string localCurrency)
        {
            string romanValue = string.Empty;

            CurrencyMapper.TryGetValue(localCurrency, out romanValue);

            return romanValue;
        }

        public float GetProductsValue(string productName)
        {
            float productValue;

            ProductsValue.TryGetValue(productName, out productValue);

            return productValue;
        }
    }
}
