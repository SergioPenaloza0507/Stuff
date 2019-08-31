using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace ObjectPools
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] GameObject[] prefabs;

        [SerializeField] int maxCount;

        List<List<GameObject>> objects;

        bool ready = false;


        private void Awake()
        {
            StartCoroutine(InitializeObjects());
        }


        IEnumerator InitializeObjects()
        {
            objects = new List<List<GameObject>>();
            GameObject[] clones = new GameObject[prefabs.Length];

            for (int i = 0; i < clones.Length; i++)
            {
                objects.Add(new List<GameObject>());
                GameObject clone = Instantiate(prefabs[i], new Vector3(1000, -1000, 1000), Quaternion.identity);
                clones[i] = clone;
                PoolObject.AddToObject(clone);
                objects[i].Add(clone);
                for (int j = 0; j < maxCount - 1; j++)
                {
                    objects[i].Add(Instantiate(clones[i], new Vector3(1000, -1000, 1000), Quaternion.identity));
                }
            }

            ready = true;
            yield return null;
        }

        public GameObject GetActiveGameObject(int index)
        {
            if (ready)
            {
                try
                {
                    GameObject c = objects[index].First(x => !x.GetComponent<PoolObject>().Active);
                    PoolObject p = c.GetComponent<PoolObject>();
                    p.Activate();
                    return c;
                }
                catch (Exception error)
                {
                    GameObject c = Instantiate(prefabs[index], new Vector3(1000, -1000, 1000), Quaternion.identity);
                    PoolObject.AddToObject(c);
                    c.GetComponent<PoolObject>().Activate();
                    return c;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
