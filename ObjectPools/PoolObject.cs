using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPools
{
    public class PoolObject : MonoBehaviour
    {
        bool active;
        public static void AddToObject(GameObject g)
        {
            if (g.GetComponent<PoolObject>() == null)
            {
                g.AddComponent(typeof(PoolObject));
            }
        }

        public void Deactivate()
        {
            active = false;
            ReturnToOriginalPos();
        }

        public void Activate()
        {
            if (GetComponent<IPoolObject>() != null)
            {
                GetComponent<IPoolObject>().Activate();
            }
            active = true;
        }

        void ReturnToOriginalPos()
        {
            transform.position = new Vector3(1000, -1000, 1000);
            print(transform.position);
        }

        public bool Active { get => active; set => active = value; }
    }
}
