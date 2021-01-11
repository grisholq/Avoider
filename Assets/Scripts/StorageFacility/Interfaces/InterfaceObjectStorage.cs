﻿using System;
using UnityEngine;

namespace MyGame
{
    [Serializable]
    public class InterfaceObjectStorage
    {
        [SerializeField] private InterfaceObject type;
        [SerializeField] private RectTransform rect;

        public InterfaceObject Type
        {
            get
            {
                return type;
            }
        }

        public RectTransform Rect
        {
            get
            {
                return rect;
            }
        }
    }
}
