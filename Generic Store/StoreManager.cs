using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStore
{
    /// <summary>
    /// Item purchase handler class
    /// </summary>
    public class StoreManager
    {
        /// <summary>
        /// purchase Event Handler
        /// </summary>
        public delegate void PurchaseResultDelegate();

        /// <summary>
        /// Event called When Purchase is succesful
        /// </summary>
        public event PurchaseResultDelegate OnPurchaseSuccess;

        /// <summary>
        /// Event called when purchase is unsuccesful
        /// </summary>
        public event PurchaseResultDelegate OnPurchaseFailed;
        Wallet buyerWallet;

        Dictionary<int, StoreItem> items;

        /// <summary>
        /// Constructor, Initializes store with given items
        /// </summary>
        /// <param name="_items"></param>
        public StoreManager(params StoreItem[] _items)
        {
            buyerWallet = new Wallet();
            items = new Dictionary<int, StoreItem>(0);
            if (_items.Length > 0)
            {
                for (int i = 0; i < _items.Length; i++)
                {
                    _items[i].ItemID = i;
                    items.Add(_items[i].ItemID, _items[i]);
                }
            }
        }

        /// <summary>
        /// Constructor, Initializes Store Data
        /// </summary>
        public StoreManager()
        {
            buyerWallet = new Wallet();
            items = new Dictionary<int, StoreItem>(0);
        }

        /// <summary>
        /// Method to determine if item can ve purchased
        /// </summary>
        /// <param name="item">Item in question</param>
        /// <returns>True if item can be purchased</returns>
        public bool CanPurchaseItem(StoreItem item)
        {
            buyerWallet = new Wallet();
            bool ret = true;
            for (int i = 0; i < buyerWallet.Cash.Length; i++)
            {
                if(buyerWallet.Cash[i] < item.Price[i])
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Buys a given item
        /// </summary>
        /// <param name="item"></param>
        public void BuyItem(StoreItem item)
        {
            if (CanPurchaseItem(item))
            {
                buyerWallet.Substract(item);
                OnPurchaseSuccess?.Invoke();
            }
            else
            {
                OnPurchaseFailed.Invoke();
                return;
            }
        }


        /// <summary>
        /// Buys an item based on its name
        /// </summary>
        /// <param name="name"></param>
        public void BuyItem(string name)
        {
            StoreItem item = items.First(x => x.Value.ItemName == name).Value;
            if(item != null)
            {
                if (CanPurchaseItem(item))
                {
                    buyerWallet.Substract(item);
                    OnPurchaseSuccess?.Invoke();
                }
                else
                {
                    OnPurchaseFailed.Invoke();
                    return;
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Buys an Item based on ID
        /// </summary>
        /// <param name="ID"></param>
        public void BuyItem(int ID)
        {
            StoreItem item = items.First(x => x.Value.ItemID == ID).Value;
            if (item != null)
            {
                if (CanPurchaseItem(item))
                {
                    buyerWallet.Substract(item);
                    OnPurchaseSuccess?.Invoke();
                }
                else
                {
                    OnPurchaseFailed.Invoke();
                    return;
                }
            }
            else
            {
                return;
            }
        }
        public Wallet BuyerWallet { get => buyerWallet; set => buyerWallet = value; }
        public Dictionary<int, StoreItem> Items { get => items; }
    }
}
