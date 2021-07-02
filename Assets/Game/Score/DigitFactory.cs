using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public abstract class DigitFactory
{
    // digit prefab with DigitView component on it
    private static UnityEngine.Object digitPrefab = Resources.Load("digit");

    // digit width needs dynamic calc per resolution
    private static float spriteWidth = 0.3f;

    // sprites for all digits 0 to 9
    private static Dictionary<int, Sprite> sprites = null;

    // adds score as sprites in parent object, needs improving dosent feel like mvc
    public static void createDigits(int score,Transform parent)
    {
        if(sprites == null)
        {
            InstantiateSprites();
        }
        if (score != 0)
        {
            int totalDigits = (int)Mathf.Floor(Mathf.Log10(score) + 1);
            foreach (int digit in GetDigits(score))
            {
                GameObject preFab = GameObject.Instantiate((GameObject)digitPrefab, parent);
                preFab.GetComponent<DigitView>().Controller.Init(digit, sprites[digit], spriteWidth * (totalDigits - 4.0f));
                totalDigits--;
            }
        }
        else
        {
            GameObject preFab = GameObject.Instantiate((GameObject)digitPrefab, parent);
            preFab.GetComponent<DigitView>().Controller.Init(0, sprites[0],-spriteWidth);
        }
    }

    // return digits of score in reverse order
    private static IEnumerable<int> GetDigits(int score)
    {
        while (score > 0)
        {
            var digit = score % 10;
            score /= 10;
            yield return digit;
        }
    }

    // loads digit sprites to dictionary for quick access
    private static void InstantiateSprites()
    {
        sprites = new Dictionary<int, Sprite>();
        Sprite[] allSprites = Resources.LoadAll<Sprite>("atlas");
        if (allSprites == null || allSprites.Length <= 0)
        {
            Debug.LogError("The Provided Base-Atlas Sprite `atlas` does not exist!");
            return;
        }

        for (int i = 0; i < allSprites.Length; i++)
        {
            if (allSprites[i].name.Contains("sc_"))
            {
                try {
                    int digit = Int32.Parse(allSprites[i].name.Split(new[] { "sc_" }, StringSplitOptions.None)[1].Trim());
                    sprites.Add(digit, allSprites[i]);
                }
                catch(FormatException e)
                {
                    Debug.Log(e);
                    // its not digit sprite
                }
                
            }
            if(sprites.Count == 10)
            {
                break; // all found
            }
        }
    }
}
