using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPools
{
    public interface IPoolObject
    {
        void Deactivate();
        void Activate();
    }
}