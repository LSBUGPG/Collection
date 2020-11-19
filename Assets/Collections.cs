using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public Sprite image;
    public bool collected;
}

[System.Serializable]
public class Collection
{
    public string title;
    public Sprite image;
    public List<Item> contents;
}

public class Collections : MonoBehaviour
{
    public List<Collection> collections;
    public Content content;

    public void OpenCollection(int collection)
    {
        Collection data = collections[collection];
        for (int i = 0; i < 6; i++)
        {
            if (i < data.contents.Count && data.contents[i].collected)
            {
                content.images[i].sprite = data.contents[i].image;
                content.images[i].enabled = true;
            }
            else
            {
                content.images[i].sprite = null;
                content.images[i].enabled = false;
            }
        }

        content.gameObject.SetActive(true);
    }

    public void CloseCollection()
    {
        content.gameObject.SetActive(false);
    }

    public void Collect(string title, int index)
    {
        Collection collection = 
            collections.Find((entry) => entry.title == title);

        if (collection != null && index < collection.contents.Count)
        {
            collection.contents[index].collected = true;
            Debug.LogFormat("{0} {1} collected", title, index);
        }
        else
        {
            Debug.LogWarningFormat(
                "Item {0} {1} does not exist",
                title,
                index);
        }
    }
}
