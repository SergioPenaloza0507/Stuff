using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStore
{
    public class StoreItem
    {
        int itemID;
        string itemName;
        float[] price;

        /// <summary>
        /// Initializes the Item with specific ID
        /// </summary>
        /// <param name="ID">number to use as item id</param>
        /// <param name="_currencyPrices">each currency price(note that this store only supports 2 currencies so only the first 2 will affect)</param>
        public StoreItem(int ID, string _itemname, params float[] _currencyPrices)
        {
            itemID = ID;
            itemName = _itemname;
            price = new float[2];
            if (_currencyPrices.Length > 0)
            {
                for (int i = 0; i < _currencyPrices.Length; i++)
                {
                    price[i] = _currencyPrices[i];
                }
            }
        }

        /// <summary>
        /// Initialize StoreItem with name and prices
        /// </summary>
        /// <param name="_itemname"></param>
        /// <param name="_currencyPrices"></param>
        public StoreItem(string _itemname, params float[] _currencyPrices)
        {
            itemName = _itemname;
            price = new float[2];
            if (_currencyPrices.Length > 0)
            {
                for (int i = 0; i < _currencyPrices.Length; i++)
                {
                    price[i] = _currencyPrices[i];
                }
            }
        }

        /// <summary>
        /// Initializes the Item
        /// </summary>
        /// <param name="_currencyPrices">each currency price(note that this store only supports 2 currencies so only the first 2 will affect)</param>
        public StoreItem(params float[] _currencyPrices)
        {
            price = new float[2];
            if (_currencyPrices.Length > 0)
            {
                for (int i = 0; i < _currencyPrices.Length; i++)
                {
                    price[i] = _currencyPrices[i];
                }
            }
        }

        public int ItemID { get => itemID; set => itemID = value; }
        public float[] Price { get => price; }
        public string ItemName { get => itemName;}
    }
}
