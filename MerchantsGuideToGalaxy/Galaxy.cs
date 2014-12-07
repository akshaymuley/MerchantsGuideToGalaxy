using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class Galaxy
    {
        private Dictionary<string, long> CurrencyMapper = new Dictionary<string, long>();

        private Dictionary<string, long> ProductsValue = new Dictionary<string,long>();

        public void AddCurrency(string localCurrency, char romanValue)
        {
            try
            {
                //var value = RomanValueConverter.GetValue(romanValue.ToString());
                long value;
                if (CurrencyMapper.TryGetValue(localCurrency, out value))
                    return;
                value = RomanValueConverter.GetValue(romanValue.ToString());
                CurrencyMapper.Add(localCurrency, value);
            }
            catch (Exception)
            {
            }
        }

        public void AddProductsValue(string productName, long productValue)
        {
            try
            {
                long value;
                if (ProductsValue.TryGetValue(productName, out value))
                    return;
                ProductsValue.Add(productName, productValue);
            }
            catch (Exception)
            {
            }
        }
        
    }
}
