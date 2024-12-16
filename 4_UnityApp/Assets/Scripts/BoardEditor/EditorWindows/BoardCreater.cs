using Language;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BoardCreater : MonoBehaviour
{
    public List<GameObject> templates = new List<GameObject>();
    public TMP_InputField boardX;
    public TMP_InputField boardY;
    public GameObject PlayerCountObject;
    public TMP_InputField playerCount;
    public TMP_InputField projectName;
    public GameObject CreateButton;
    public TMP_Text Title;
    public TMP_Text Detail;
    string template;

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
        template = "";
        foreach (GameObject template in templates)
        {
            Color color = template.GetComponent<Image>().color;
            template.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1.0f);
            color = template.transform.GetChild(0).GetComponent<TMP_Text>().color;
            template.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(color.r, color.g, color.b, 1.0f);
        }
        Title.text = "";
        Detail.text = "";
        PlayerCountObject.SetActive(true);
        boardX.text = "0";
        boardY.text = "0";
        playerCount.text = "2";
        projectName.text = AppManager.settings.projectName;
        PlayerCountObject.SetActive(false);
        CreateButton.SetActive(false);
    }

    string getScriptByTemplate(string template, int numOfPlayer)
    {
        string newText = "";
        switch (template)
        {
            case "Blank":
                break;
            case "Abstract Strategy":
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "Player player" + i + "(\"Player" + i + "\");\n\n";
                    newText += "Piece piece" + i + "(player" + i + ", 0, 0);\n\n";
                    newText += "player" + i + ".Turn(<SelectPiece(piece)>, <SelectTile(tile)>, <piece.Rule(tile)>);\n\n";
                    newText += "\n";
                }
                newText += "\n\n";
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "piece" + i + ".Rule(Tile t)\n{\n\tRESULT = false;\n}\n\n";
                }
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "player" + i + ".WinCondition()\n{\n\tRESULT = false;\n}\n\n";
                }
                break;
            case "Worker Placement":
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "Player player" + i + "(\"Player" + i + "\");\n\n";
                    newText += "player" + i + ".Turn(<SelectTile(tile)>, <player.Rule(tile)>);\n\n";
                    newText += "\n";
                }
                newText += "\n\n";
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "player" + i + ".Rule(Tile t)\n{\n\tRESULT = false;\n}\n\n";
                }
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "player" + i + ".WinCondition()\n{\n\tRESULT = false;\n}\n\n";
                }
                break;
            case "Roll and Move":
                newText += "Dice dice(1, 2, 3, 4, 5, 6);\n\n";
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "Player player" + i + "(\"Player" + i + "\");\n\n";
                    newText += "Piece piece" + i + "(player" + i + ", 0, 0);\n\n";
                    newText += "piece" + i + ".Route = [(0,0), (0,1), (0,2)];\n\n";
                    newText += "player" + i + ".Turn(<dice.Roll()>, <SelectPiece(piece)>, <piece.Rule()>);\n\n";
                    newText += "\n";
                }
                newText += "\n\n";
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "piece" + i + ".Rule()\n{\n\tRESULT = false;\n}\n\n";
                }
                for (int i = 1; i <= numOfPlayer; i++)
                {
                    newText += "player" + i + ".WinCondition()\n{\n\tRESULT = false;\n}\n\n";
                }
                break;
        }
        return newText;
    }

    public void ChooseTemplate(GameObject selected)
    {
        CreateButton.SetActive(true);
        template = selected.transform.GetChild(0).GetComponent<TMP_Text>().text;
        if(template == "Blank")
            PlayerCountObject.SetActive(false);
        else
            PlayerCountObject.SetActive(true);
        SetTextByTemplate(template);

        foreach (GameObject template in templates)
        {
            if(selected != template)
            {
                Color color = template.GetComponent<Image>().color;
                template.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
                color = template.transform.GetChild(0).GetComponent<TMP_Text>().color;
                template.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(color.r, color.g, color.b, 0.5f);
            }
            else
            {
                Color color = template.GetComponent<Image>().color;
                template.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1.0f);
                color = template.transform.GetChild(0).GetComponent<TMP_Text>().color;
                template.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(color.r, color.g, color.b, 1.0f);
            }
        }
    }

    void SetTextByTemplate(string template)
    {
        switch (template)
        {
            case "Blank":
                Title.text = "";
                Detail.text = "";
                break;
            case "Abstract Strategy":
                Title.text = "Abstract Strategy Games:";
                Detail.text = "These games involve a series of deterministic steps, where players  move pieces on a board in a set sequence.";
                break;
            case "Worker Placement":
                Title.text = "Worker Placement Games:";
                Detail.text = "In these games, players take turns placing tokens on various locations on the board to take specific actions.";
                break;
            case "Roll and Move":
                Title.text = "Roll-and-Move Games:";
                Detail.text = "These games involve rolling dice and moving pieces around a board based on the outcome of the dice roll.";
                break;
        }
    }

    public void CreateProject()
    {
        string filePath = Path.Combine(AppManager.globalPath + "/Scripts", projectName.text + ".bdg");

        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(getScriptByTemplate(template, int.Parse(playerCount.text)));
                writer.Close();
            }
        }
        AppManager.settings.projectName = projectName.text;
        CreateBoard(int.Parse(boardX.text), int.Parse(boardY.text));
    }
    void CreateBoard(int TilesX, int TilesY)
    {
        if (!(TilesX > 0 && TilesY > 0 && (EditorManager.BoardX != TilesX || EditorManager.BoardY != TilesY)))
        {
            return;
        }

        EditorManager.BoardX = TilesX;
        EditorManager.BoardY = TilesY;

        GameObject.Find("Manager").GetComponent<EditorManager>().ClearBoard();

        for (int i = 0; i < TilesY; i++)
        {
            for (int j = 0; j < TilesX; j++)
            {
                object[] list = { j, i };
                Tile t = new Tile(list);

                GameObject temp = Instantiate(GameObject.Find("Tile"));
                temp.GetComponent<TileObject>().CreateElement(new object[] { t, Color.white, new Vector2(j, i), false, null, null }); ;
                EditorManager.tileObjects.Add(temp.GetComponent<TileObject>());
            }
        }

        GameObject.Find("Manager").GetComponent<EditorManager>().EnableButtons(true);

        Camera.main.GetComponent<CameraManager>().enabled = false;
        Camera.main.GetComponent<CameraManager>().enabled = true;
        GameObject.Find("Manager").GetComponent<EditorManager>().WindowHandler(gameObject);
    }
}
