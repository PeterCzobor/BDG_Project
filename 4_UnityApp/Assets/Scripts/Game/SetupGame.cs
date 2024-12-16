using Language;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup()
    {
        for (int i = 0; i < AppManager.saved.tiles.Count; i++)
        {
            GameObject temp = Instantiate(GameObject.Find("Tile"));
            temp.GetComponent<TileObject>().enabled = true;
            temp.GetComponent<TileObject>().tileKey = "tile" + i;
            SaveLoad.LoadTile(temp.GetComponent<TileObject>(), AppManager.saved.tiles[i]);
            temp.GetComponent<TileObject>().CopyElement(temp.GetComponent<TileObject>());
            if (temp.GetComponent<TileObject>().fake)
            {
                temp.GetComponent<TileObject>().enabled = false;
            }
            else
            {
                temp.name = "Tile" + AppManager.saved.tiles[i].positionX + "_" + AppManager.saved.tiles[i].positionY;
                GameManager.gameElements.Add(temp.GetComponent<TileObject>());
                GameManager.visitor.Variables["tile" + i] = temp.GetComponent<TileObject>().tile;
            }
        }
        for (int i = 0; i < AppManager.saved.buttons.Count; i++)
        {
            GameObject temp = Instantiate(GameObject.Find("ButtonTemplate"), GameObject.Find("Canvas").transform);
            temp.transform.SetAsFirstSibling();
            temp.AddComponent<Button>();
            temp.GetComponent<Button>().onClick.AddListener(() => { GetComponent<GameManager>().ButtonHandler(temp.GetComponent<ButtonObject>()); });
            SaveLoad.LoadButton(temp.GetComponent<ButtonObject>(), AppManager.saved.buttons[i]);
            temp.GetComponent<ButtonObject>().CopyElement(temp.GetComponent<ButtonObject>());
            GameManager.gameElements.Add(temp.GetComponent<ButtonObject>());
            GameManager.visitor.Variables[temp.GetComponent<ButtonObject>().buttonKey] = temp.GetComponent<ButtonObject>().buttonvar;
        }
        for (int i = 0; i < AppManager.saved.labels.Count; i++)
        {
            GameObject temp = Instantiate(GameObject.Find("LabelTemplate"), GameObject.Find("Canvas").transform);
            temp.transform.SetAsFirstSibling();
            SaveLoad.LoadLabel(temp.GetComponent<LabelObject>(), AppManager.saved.labels[i]);
            temp.GetComponent<LabelObject>().CopyElement(temp.GetComponent<LabelObject>());
            GameManager.gameElements.Add(temp.GetComponent<LabelObject>());
            GameManager.visitor.Variables[temp.GetComponent<LabelObject>().labelKey] = temp.GetComponent<LabelObject>().labelVar;
        }
        for (int i = 0; i < AppManager.saved.images.Count; i++)
        {
            GameObject temp = Instantiate(GameObject.Find("ImageTemplate"));
            SaveLoad.LoadImage(temp.GetComponent<ImageObject>(), AppManager.saved.images[i]);
            temp.GetComponent<ImageObject>().CopyElement(temp.GetComponent<ImageObject>());
        }
        foreach (AssetJSON asset in AppManager.saved.assets)
        {
            GameManager.visitor.Variables[asset.ID] = asset.path;
            GameManager.assets[asset.path] = asset.image;
        }

        GameManager.visitor.circX = AppManager.settings.xCirc;
        GameManager.visitor.circY = AppManager.settings.yCirc;

        GetBoardSize();
        GameManager.simulating = true;
        GameManager.Script(AppManager.saved.script, false);
        GameManager.simulating = false;

        GameManager.visitor.Variables["return"] = false;
        GameManager.visitor.Variables["FUNC"] = null;

        foreach (var item in GameManager.visitor.Variables)
        {
            if (item.Value is Player pl && item.Key != "CurrentPlayer")
            {
                GameObject temp = Instantiate(GameObject.Find("Player"));
                temp.GetComponent<PlayerObject>().enabled = true;
                temp.GetComponent<PlayerObject>().CreateElement(new object[] { pl, item.Key });
                GameManager.gameElements.Add(temp.GetComponent<PlayerObject>());
                GameManager.players.Add(temp.GetComponent<PlayerObject>());
            }
            if (item.Value is Piece pi)
            {
                GameObject temp = Instantiate(GameObject.Find("Piece"));
                temp.GetComponent<PieceObject>().enabled = true;
                temp.GetComponent<PieceObject>().CreateElement(new object[] { pi, item.Key });
                GameManager.gameElements.Add(temp.GetComponent<PieceObject>());
            }
            if (item.Value is Dice di)
            {
                GameObject temp = Instantiate(GameObject.Find("Dice"), GameObject.Find("Dice").transform.parent);
                temp.gameObject.name = item.Key;
                temp.GetComponent<DiceObject>().enabled = true;
                temp.GetComponent<DiceObject>().CreateElement(new object[] { di, item.Key });
                GameManager.gameElements.Add(temp.GetComponent<DiceObject>());
            }
        }
        GameManager.UpdateElements();
    }


    void GetBoardSize()
    {
        GameManager.minX = int.Parse(AppManager.saved.tiles[0].positionX);
        GameManager.maxX = int.Parse(AppManager.saved.tiles[0].positionX);
        GameManager.minY = int.Parse(AppManager.saved.tiles[0].positionY);
        GameManager.maxY = int.Parse(AppManager.saved.tiles[0].positionY);
        for (int i = 0; i < AppManager.saved.tiles.Count; i++)
        {
            if (AppManager.saved.tiles[i].fake != "True")
            {
                if (int.Parse(AppManager.saved.tiles[i].positionX) < GameManager.minX)
                {
                    GameManager.minX = int.Parse(AppManager.saved.tiles[i].positionX);
                }
                if (int.Parse(AppManager.saved.tiles[i].positionX) > GameManager.maxX)
                {
                    GameManager.maxX = int.Parse(AppManager.saved.tiles[i].positionX);
                }
                if (int.Parse(AppManager.saved.tiles[i].positionY) < GameManager.minY)
                {
                    GameManager.minY = int.Parse(AppManager.saved.tiles[i].positionY);
                }
                if (int.Parse(AppManager.saved.tiles[i].positionY) > GameManager.maxY)
                {
                    GameManager.maxY = int.Parse(AppManager.saved.tiles[i].positionY);
                }
            }
        }
        Debug.Log(GameManager.minX + " " + GameManager.maxX + " " + GameManager.minY + " " + GameManager.maxY);
    }
}
