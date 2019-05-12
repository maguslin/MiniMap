using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapItem : MonoBehaviour {

    public string iconName;
    public Sprite icon;
    private GameObject go;
    private GameObject player;

    // Use this for initialization
    void Start () {
        go = MiniMap.Instance.AddIcon(iconName, icon);
        player = GameObject.FindGameObjectWithTag("Player");
        
	}

    private void FixedUpdate()
    {
        if (this.name == "Cube")
        {
            //Debug.Log(player.transform.localPosition);
            Vector3 offset = transform.position - player.transform.position;
            Debug.Log(go.transform.localPosition);
            go.transform.localPosition = new Vector3(offset.x-50f, offset.z-50f, 0f);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnDestroy()
    {
        Destroy(go);
    }
}
