//================================================================================================================================
//
//  Copyright (c) 2015-2020 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
//  EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
//  and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//================================================================================================================================

using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpatialMap_SparseSpatialMap
{
    public class PropCellController : MonoBehaviour
    {
        public Image Icon;
        public Sprite WordSprite;

        public event Action PointerDown;
        public event Action PointerUp;
        public event Action ShowConstomizeWordProp;

        public PropCollection.ObjectGetMethod NowMethod { get;private set; }

        public PropCollection.Templet Templet { get; private set; }

        public void SetData(PropCollection.Templet templet)
        {
            NowMethod = PropCollection.ObjectGetMethod.NormalModel;
            Templet = templet;
            Icon.sprite = templet.Icon;
        }

        public void OnPointerDown()
        {
            Icon.color = Color.gray;
            if (PointerDown != null)
            {
                if (Templet.method == PropCollection.ObjectGetMethod.ContomizeWord)
                {
                    return;
                }
                PointerDown();
            }
        }

        public void OnPointerUp()
        {
            Icon.color = Color.white;
            if (PointerUp != null)
            {
                if (Templet.method == PropCollection.ObjectGetMethod.ContomizeWord)
                {
                    NowMethod = PropCollection.ObjectGetMethod.ContomizeWord;
                    Templet.method = PropCollection.ObjectGetMethod.NormalModel;
                    if (ShowConstomizeWordProp != null)
                        ShowConstomizeWordProp();
                    return;
                }
                if (NowMethod == PropCollection.ObjectGetMethod.ContomizeWord)
                {
                    ChangeWordSprite();
                    NowMethod = PropCollection.ObjectGetMethod.NormalModel;
                    Templet.method = PropCollection.ObjectGetMethod.ContomizeWord;
                }
                PointerUp();
            }
        }

        public void ChangeWordSprite()
        {
            Sprite temp = Icon.sprite;
            Icon.sprite = WordSprite;
            WordSprite = temp;
        }
    }
}
