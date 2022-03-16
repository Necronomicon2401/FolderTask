using System;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class StreamingAssetsController : MonoBehaviour
{
    public GameObject obj;

    public void ChangeHairTexture(string hair)
    {
        var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        print($"Streaming assets path: {Application.streamingAssetsPath}");
        var allFiles = directoryInfo.GetFiles("*.*");

        foreach (var file in allFiles)
        {
            print($"File name {file.Name}");

            if (file.Name.Contains("meta"))
            {
                continue;
            }
            
            var modelMaterials = obj.GetComponent<ModelMaterials>();

            if (!file.Name.Contains(modelMaterials.gender))
            {
                continue;
            }

            if (!file.Name.Contains(hair))
            {
                continue;
            }

            //var imageData = Instantiate(baseIcon, baseIcon.transform.parent);

            var bytes = File.ReadAllBytes(file.FullName);
            var texture2D = new Texture2D(1, 1);
                
            texture2D.LoadImage(bytes);

            modelMaterials.hair.material.mainTexture = texture2D;
            return;
        }
    }
    
    public void ChangeClothTexture(string cloth)
    {
        var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        print($"Streaming assets path: {Application.streamingAssetsPath}");
        var allFiles = directoryInfo.GetFiles("*.*");

        foreach (var file in allFiles)
        {
            print($"File name {file.Name}");

            if (file.Name.Contains("meta"))
            {
                continue;
            }
            
            var modelMaterials = obj.GetComponent<ModelMaterials>();

            if (!file.Name.Contains(modelMaterials.gender))
            {
                continue;
            }

            if (!file.Name.Contains(cloth))
            {
                continue;
            }

            //var imageData = Instantiate(baseIcon, baseIcon.transform.parent);

            var bytes = File.ReadAllBytes(file.FullName);
            var texture2D = new Texture2D(1, 1);
                
            texture2D.LoadImage(bytes);

            modelMaterials.cloth.material.mainTexture = texture2D;
            return;
        }
    }

    public void ChangeHairColor(string color)
    {
        if (color.Equals("red"))
        {
            obj.GetComponent<ModelMaterials>().hair.material.color = Color.red;
        }
        
        if (color.Equals("blue"))
        {
            obj.GetComponent<ModelMaterials>().hair.material.color = Color.blue;
        }
    }
    
    public void ChangeClothColor(string color)
    {
        if (color.Equals("white"))
        {
            obj.GetComponent<ModelMaterials>().cloth.material.color = Color.white;
        }
        
        if (color.Equals("yellow"))
        {
            obj.GetComponent<ModelMaterials>().cloth.material.color = Color.yellow;
        }
    }
}