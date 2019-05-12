using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {

    public static MiniMap Instance;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject AddIcon(string iconName,Sprite icon)
    {
        GameObject go = new GameObject(iconName);
        go.AddComponent<Image>().sprite = icon;
        go.transform.SetParent(this.transform);
        go.GetComponent<RectTransform>().sizeDelta = new Vector2(20f, 20f);
        go.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        return go;
    }
}
