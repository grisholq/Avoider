﻿using System;
using UnityEngine;

namespace MyGame
{
    [Serializable]
    public class Prefabs
    {
        [SerializeField] private PrefabObjectStorage[] prefabObjects;

        public Transform GetPrefab(PrefabObject type)
        {
            for (int i = 0; i < prefabObjects.Length; i++)
            {
                if (prefabObjects[i].Type == type)
                {
                    return prefabObjects[i].Prefab;
                }
            }
            return null;
        }
    }
}
