using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveGrid : MonoBehaviour
{
    public bool horizontal = false;//yatay;
    public bool vertical = true;

    public void Start()
    {
        if (vertical)
        {
            CalculateVertical();
        }
        else
        {
            CalculateHorizontal();
        }
    }

    public void OnRectTransformDimensionsChange()
    {
        if (vertical)
        {
            CalculateVertical();
        }
        else
        {
            CalculateHorizontal();
        }
    }

    private void CalculateVertical()
    {
        Transform _thisobj = this.transform;
        int childCount = _thisobj.childCount;

        float perHeight = Screen.height;
        float perWidth = Screen.width / childCount;
        perWidth = 665f;

        foreach (Transform children in _thisobj)
        {
            RectTransform rect = children.GetComponent<RectTransform>();
            rect.rect.Set(0f, 0f, perWidth, perHeight);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, perWidth);

        }
    }

    private float GetScale(int width, int height, Vector2 scalerReferenceResolution, float scalerMatchWidthOrHeight)
    {
        return Mathf.Pow(width / scalerReferenceResolution.x, 1f - scalerMatchWidthOrHeight) *
               Mathf.Pow(height / scalerReferenceResolution.y, scalerMatchWidthOrHeight);
    }
    private void CalculateHorizontal()
    {
        Transform _thisobj = this.transform;
        int childCount = _thisobj.childCount;

        float perHeight = Screen.height / childCount;
        float perWidth = Screen.width;

        foreach (Transform children in _thisobj)
        {
            RectTransform rect = children.GetComponent<RectTransform>();
            rect.rect.Set(0f, 0f, perWidth, perHeight);
        }
    }
}
