using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;



public class TemplateCreator : MonoBehaviour 
{
    public TextAsset JsonFile;
    public Template[] template;

    [System.Serializable]
    class Wrapper
    {
        public Template[] items;
    }

    void GenerateObjects(string jsonString)
    {
        Wrapper wrapper = JsonUtility.FromJson<Wrapper>("{\"items\":" + jsonString + "}");

        template = wrapper.items;
      

        foreach (var item in template)
        {
            GameObject uiimage = new GameObject(item.objectName);
            uiimage.transform.SetParent(this.transform);
            RectTransform rectTransform = uiimage.AddComponent<RectTransform>();

            //set position
            rectTransform.anchoredPosition = item.position;
            //set size
            rectTransform.sizeDelta = item.size;

            //add image component
            Image imageComponent = uiimage.AddComponent<Image>();

            //add color to image component
            imageComponent.color = item.objectColor;

            //add canvas component
            Canvas canvas = uiimage.AddComponent<Canvas>();
            canvas.sortingOrder = item.sortingOrder;


            CanvasScaler canvasscalar = uiimage.AddComponent<CanvasScaler>();
            GraphicRaycaster graph = uiimage.AddComponent<GraphicRaycaster>();

            //add ur desired component below 

        }


    }

    void Start()
    {
        if (JsonFile != null)
        {
            string jsonString = JsonFile.text;
            GenerateObjects(jsonString);
        }
        else
        {
            Debug.LogError("JSON file not assigned!");
        }
    }
} 

