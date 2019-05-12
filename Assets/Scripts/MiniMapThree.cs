using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapThree : MonoBehaviour {

    public Vector2 WorldRealSize;
    public RectTransform Minimap;
    public RectTransform PlayerIndicator;
    public bool FixedPlayer;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Minimap!=null&&PlayerIndicator!=null)
        {
            if (FixedPlayer)
            {
                Minimap.anchoredPosition = WorldPositionToMiniMap(new Vector2(-Minimap.rect.width,-Minimap.rect.height), player.transform.position);
                PlayerIndicator.anchoredPosition = Vector2.zero;
            }
            else{
                PlayerIndicator.anchoredPosition = WorldPositionToMiniMap(new Vector2(Minimap.rect.width, Minimap.rect.height), player.transform.position);
            }
            Quaternion quaternion = PlayerIndicator.rotation;
            quaternion.eulerAngles = new Vector3(quaternion.eulerAngles.x, quaternion.eulerAngles.y, -player.transform.rotation.eulerAngles.y);
            PlayerIndicator.rotation = quaternion;
        }
	}

    private Vector2 WorldPositionToMiniMap(Vector2 minimap,Vector3 realPosition)
    {
        Vector2 res = Vector2.zero;
        float scaleX = ScaleMapAndWorld(minimap.x, WorldRealSize.x);
        float scaleY = ScaleMapAndWorld(minimap.y, WorldRealSize.y);
        res= new Vector2(scaleX * realPosition.x, scaleY * realPosition.z);

        return res;
    }

    private float ScaleMapAndWorld(float minimap,float realSize)
    {
        return minimap / realSize;
    }

    public float MapScale = 1;
    public void Zoom(float zoom)
    {
        if (Minimap == null)
            return;
        MapScale += zoom;
        if (MapScale < 1)
        {
            Minimap.anchoredPosition = Vector2.zero;
            MapScale = 1;
        }

        Minimap.localScale = Vector3.one * MapScale;
    }


}
