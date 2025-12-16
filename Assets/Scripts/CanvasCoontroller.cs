using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCoontroller : MonoBehaviour
{
    [SerializeField] Image imageSelector;

    public void ChangePickableColor(bool isSelect)
    {
        if (isSelect)
        {
            imageSelector.color = Color.green;
        }
        else
        {
            imageSelector.color = Color.white;
        }
    }

    public void OcultarCursor(bool ocultar)
    {
        imageSelector.enabled = !ocultar;
    }
}
