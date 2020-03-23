using UnityEngine;
using UnityEngine.UI;

public class SkyboxChanger : MonoBehaviour
{
    #region Singleton
    public static SkyboxChanger instance;
    public SkyboxChanger()
    {
        instance = this;
    }
    #endregion

    public Material[] Skyboxes;

    public int ActiveSkyBoxIndex = 0;

    public void Update()
    {
        ChangeSkybox(ActiveSkyBoxIndex);
    }

    public void ChangeSkybox(int index)
    {
        RenderSettings.skybox = Skyboxes[index];
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }
}