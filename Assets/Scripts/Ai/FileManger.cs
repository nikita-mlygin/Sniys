using System.Collections;
using UnityEngine;

using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
//using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Newtonsoft.Json;
using System.Collections.Generic;

public class FileManger : MonoBehaviour
{
    public RawImage image;
    private string path;
    private string filename;

    public void OpenExplorer()
    {
        path = UnityEditor.EditorUtility.OpenFilePanel("Image", "", "png,jpg");
        if (!string.IsNullOrEmpty(path))
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            Texture2D downloadedTexture = new Texture2D(512, 512);
            downloadedTexture.LoadImage(imageBytes);
            image.texture = downloadedTexture;
            string base64Image = Convert.ToBase64String(imageBytes);
            System.Random rnd = new System.Random();
            int generateseed = rnd.Next(500, 999999999);

            var data = new
            {
                prompt = "(masterpiece:1.2), (best quality), (ultra detailed), (8k, 4k, intricate), (highly detailed:1.2),(detailed face:1.2), (detailed background),detailed landscape, (dynamic pose:1.2), 1boy, solo, looking at viewer, short hair, bangs, blonde hair, shirt, hair ornament, closed mouth, green eyes, upper body, braid, pointy ears, hairclip, cape, from side, parted bangs, blue shirt, portrait, forehead, black cape, crown braid moonlight, medieval city, on the street, glass, <lora:pixel:0.9>((pixelart)), pixelart, pixelated style",
                negative_prompt = "(low quality:1.4), (worst quality:1.4), (monochrome:1.1),(bad_prompt_version2:0.8), (bad-hands-5:1.1), lowres,(Bored pose), static pose, busty bad hands, lowers, long body, disfigured, ugly, cross eyed, squinting, grain, Deformed, blurry, bad anatomy, poorly drawn face, mutation, mutated, extra limb, ugly, poorly drawn hands, missing limb, floating limbs, disconnected limbs, malformed hands, blur, out of focus, long neck, disgusting, poorly drawn, mutilated, ((text)), ((centered shot)), ((symetric pose)), ((symetric)), multiple views, multiple panels, blurry, multiple panels, blurry, watermark, letterbox, text, EasyNegative,",
                seed = generateseed,
                sampler_name = "DPM++ 2M Karras",
                batch_size = 1,
                n_iter = 1,
                steps = 20,
                cfg_scale = 7,
                width = 512,
                height = 512,
                denoising_strength = 0.75,
                init_images = new[] { base64Image },
                resize_mode = 0,
                send_images = true,
                save_images = false
            };

            string jsonRequest = JsonConvert.SerializeObject(data);
            // Define the server URL
            string serverURL = "http://127.0.0.1:7861/sdapi/v1/img2img";

            // Create a UnityWebRequest and set the request method to POST
            UnityWebRequest www = UnityWebRequest.PostWwwForm(serverURL, "POST");

            // Set the JSON data as the request body
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonRequest);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.SetRequestHeader("Content-Type", "application/json");

            // Send the request
            StartCoroutine(SendRequest(www));
        }

        IEnumerator SendRequest(UnityWebRequest www)
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseBase64 = www.downloadHandler.text;
                //print(responseBase64);
                ImageData imageData = JsonConvert.DeserializeObject<ImageData>(responseBase64);
                byte[] responseBytes = Convert.FromBase64String(imageData.images[0]);

                Texture2D downloadedTexture = new Texture2D(512, 512);
                downloadedTexture.LoadImage(responseBytes);
                image.texture = downloadedTexture;
            }
            else
            {
                // Request failed, handle the error here
                Debug.LogError("Request failed: " + www.error);
            }
        }


    }  
    
}
public class ImageData
{
    public List<string> images;
}


