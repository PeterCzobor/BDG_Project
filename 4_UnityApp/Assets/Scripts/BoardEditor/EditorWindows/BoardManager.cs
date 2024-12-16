using System.Collections;
using System.Collections.Generic;
using Language;
using TMPro;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject AddWindow;
    public TMP_InputField TileX;
    public TMP_InputField TileY;

    public GameObject HighLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        AddWindow.SetActive(false);

        HighLight.SetActive(true);
    }

    public void AddTile(int TilesX, int TilesY)
    {
        foreach (TileObject to in EditorManager.tileObjects)
        {
            if (to.tile.posX == TilesX && to.tile.posY == TilesY)
                return;
        }

        object[] list = { TilesX, TilesY };
        Tile t = new Tile(list);

        GameObject temp = Instantiate(GameObject.Find("Tile"));
        temp.GetComponent<TileObject>().CreateElement(new object[] { t, Color.white, new Vector2(TilesX, TilesY), false, null, null });
        EditorManager.tileObjects.Add(temp.GetComponent<TileObject>());

        GameObject.Find("Manager").GetComponent<EditorManager>().EnableButtons(false);

        Camera.main.GetComponent<CameraManager>().enabled = false;
        Camera.main.GetComponent<CameraManager>().enabled = true;
    }

    private void OnDisable()
    {
        HighLight.SetActive(false);
    }

    public void AddTile()
    {
        AddWindow.SetActive(true);
        GameObject.Find("TileX").GetComponent<TMP_InputField>().text = "0";
        GameObject.Find("TileY").GetComponent<TMP_InputField>().text = "0";
    }

    public void Add()
    {
        AddTile(int.Parse(TileX.text), int.Parse(TileY.text));
        GameObject.Find("Manager").GetComponent<EditorManager>().WindowHandler(gameObject);
    }
}
