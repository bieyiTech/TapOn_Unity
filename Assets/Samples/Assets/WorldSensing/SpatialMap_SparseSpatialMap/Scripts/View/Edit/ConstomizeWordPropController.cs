using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpatialMap_SparseSpatialMap
{
    public class ConstomizeWordPropController : MonoBehaviour
    {
        
        public GameObject textMesh;
        public Text text;
        public Text text1;
        public GameObject ConstomizeWordProp;

        private PropCellController cellController;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void setController(PropCellController controller)
        {
            cellController = controller;
        }

        public void setText()
        {

            TextMesh t = textMesh.GetComponentInChildren<TextMesh>();
            if (t != null)
            {               
                t.text = text.text;
            }
            ConstomizeWordProp.SetActive(false);
            cellController.ChangeWordSprite();
        }
    }
}
