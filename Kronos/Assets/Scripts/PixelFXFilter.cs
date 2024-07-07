using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelFXFilter : MonoBehaviour
{
    public enum PixelatedScreenMode { resize, scale }

    [System.Serializable]
    public struct ScreenSize
    {
        //stores screen size information
        public int width;
        public int height;
    }

    public static PixelFXFilter main;

    private Camera renderCamera;
    private RenderTexture renderTexture;
    private int screenWidth, screenHeight;

    [Header("Screen scaling settings")]
    public PixelatedScreenMode mode;
    public ScreenSize targetScreenSize = new ScreenSize { width = 256, height = 144 }; //only used with PixelatedScreenMode.Resize
    public uint screenScaleFactor = 1; //only used with PixelatedScreenMode.Scale

    [Header("Display")]
    public RawImage display;

    private void Start()
    {
        //initializes the system
        Init();
    }

    public void Update()
    {
        //reinitializes system if game screen has been resized
        if (CheckScreenResize()) Init();
    }

    public bool CheckScreenResize()
    {
        //checks if game screen has been resized
        return Screen.width != screenWidth || Screen.height != screenHeight;
    }

    public void Init()
    {
        //initializes the camera & gets screen size values
        if (!renderCamera) renderCamera = GetComponent<Camera>();
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        //prevents resolution problems
        if (screenScaleFactor < 1) screenScaleFactor = 1;
        if (targetScreenSize.width < 1) targetScreenSize.width = 1;
        if (targetScreenSize.height < 1) targetScreenSize.height = 1;

        //calculates render texture size
        int width = mode == PixelatedScreenMode.resize ? (int)targetScreenSize.width : screenWidth / (int)screenScaleFactor;
        int height = mode == PixelatedScreenMode.resize ? (int)targetScreenSize.height : screenHeight / (int)screenScaleFactor;
        
        //initializes render texture
        renderTexture = new RenderTexture(width, height, 24)
        {
            filterMode = FilterMode.Point,
            antiAliasing = 1
        };

        //sets render texture as camera's output
        renderCamera.targetTexture = renderTexture;
        //attaches texture to the display UI RawImage
        display.texture = renderTexture;
    }
}
