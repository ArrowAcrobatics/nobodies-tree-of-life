using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatableMaterial : MonoBehaviour
{
    public Renderer[] rends;
    private Material mat;
    [Range(0,1)]
    public float alpha = 1.0f;
    public string targetColor = "_BaseColor";
    public int rendcount = 0;

    //public enum TargetColor {
    //    BaseMap, 
    //    BaseColor, 
    //    Color
    //}
    //public TargetColor targetColor = TargetColor.BaseMap;

    private void Start()
    {
        //rend = GetComponent<Renderer>();
        rends = GetComponentsInChildren<Renderer>(true);
        rendcount = rends.Length;
    }

    void Update()
    {
        foreach (Renderer rend in rends)
        {
            if (rend != null)
            {
                mat = rend.material;
            }

            if (mat == null)
            {
                return;
            }

            string colorName = ColorName();
            Color c = mat.GetColor(colorName);
            c.a = Mathf.Clamp01(alpha);
            //mat.SetColor(colorName, c);

            if (rend != null)
            {
                Debug.Log(gameObject.name  + " rend.material.SetColor(" +colorName + "," + c.ToString() + ")");
                rend.material.SetColor(colorName, c);
            }
        }
    }

    string ColorName()
    {
        return targetColor;

        //switch(targetColor)
        //{
        //    case TargetColor.BaseMap: return "_BaseMap";
        //    case TargetColor.BaseColor: return "_BaseColor";
        //    case TargetColor.Color: return "_Color";
        //}

        //return "";
    }
}
