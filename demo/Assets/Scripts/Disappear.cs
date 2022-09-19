using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public GameObject model;
    private List<Material> materials = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetMeterials()
    {
        Material[] materals;
        Renderer[] meshRendererer = model.GetComponentsInChildren<Renderer>();
        foreach (var item in meshRendererer)
        {
            materals = item.materials;
            foreach (Material m in materals)
            {
                if (!materials.Contains(m))
                {
                    materials.Add(m);
                }
            }
        }
        for (int i = 0; i < materials.Count; i++)
        {
            Material m = materials[i];
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            m.SetInt("_ZWrite", 0);
            m.DisableKeyword("_ALPHATEST_ON");
            m.EnableKeyword("_ALPHABLEND_ON");
            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            m.renderQueue = 3000;
        }
    }

    //消失
    public void FadeOut(float disTime)
    {
        GetMeterials();
        for (int i = 0; i < materials.Count; i++)
        {
            Material m = materials[i];
            Color color = m.color;
            m.DOColor(new Color(color.r, color.g, color.b, 0), disTime);
        }
    }

    //出现
    public void FadeIn(float disTime)
    {
        GetMeterials();
        for (int i = 0; i < materials.Count; i++)
        {
            Material m = materials[i];
            Color color = m.color;
            m.DOColor(new Color(color.r, color.g, color.b, 1), disTime);
        }
    }
}
