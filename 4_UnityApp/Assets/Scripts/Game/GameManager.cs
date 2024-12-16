using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Antlr4.Runtime;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Language;
using TMPro;
using Newtonsoft.Json;
using Assets.Language;

public class GameManager : MonoBehaviour
{
    public static List<PlayerObject> players = new List<PlayerObject>();
    public static List<GameElement> gameElements = new List<GameElement>();

    public static Dictionary<string, string> assets = new Dictionary<string, string>();

    public GameObject PlayerWon;

    public static int current;
    public static PlayerObject currentPlayer;

    public static Visitor visitor = new Visitor();

    public static string PieceKey = null;
    public static string TileKey = null;
    public static string PlayerKey = null;

    public static int maxX = 0, minX = 0, maxY = 0, minY = 0;

    public static bool waiting;
    public static object clicked;
    public static object selectable;
    public static string pressable = string.Empty;

    public static bool simulating = false;

    public static bool cancel = false;

    static List<IEnumerator> stepCoroutines = new List<IEnumerator>();

    public static bool debugMode = false;

    private void Update()
    {
        if(currentPlayer != null)
        {
            GameObject.Find("Info").GetComponent<TMP_Text>().text = currentPlayer.player.name;
        }

        if (waiting && pressable != string.Empty && Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    string keyName = keyCode.ToString();
                    if (keyName.Contains(pressable) || (keyName == "Return" && pressable == "Enter"))
                    {
                        pressable = string.Empty;
                    }
                }
            }
        }
    }

    private void Start()
    {

    }

    public GameObject DebugUI;

    void OnEnable()
    {
        GameObject.Find("CreatedContent").GetComponent<SkinManager>().ReSkin();

        if (debugMode)
        {
            DebugUI.SetActive(true);
            GameObject.Find("MenuButton").SetActive(false);
        }
        ClearBoard();
        GetComponent<SetupGame>().Setup();
        if(AppManager.visitorBackUp != null)
        RollBack();
        if (visitor.Variables.ContainsKey("CurrentPlayer"))
        {
            for (int i = 0; i < players.Count; i++)
                if (players[i].player == visitor.Variables["CurrentPlayer"])
                    current = i;
        }
        currentPlayer = players[current];
        visitor.Variables["CurrentPlayer"] = currentPlayer.player;

        StartCoroutine(StateMachine(GetComponent<GameElement>()));
    }

    public static void ClearBoard()
    {
        foreach (GameElement g in gameElements)
        {
            g.gameObject.SetActive(false);
        }
        gameElements.Clear();
        players.Clear();
        visitor = new Visitor();
        current = 0; ;
        currentPlayer = null;
        PieceKey = null;
        TileKey = null;
        PlayerKey = null;
        waiting=false;
        clicked=null;
        selectable=null;
        simulating = false;
        cancel = false;
    }

    public bool SimulateTurn(string caller, object[] o)
    {
        return GetComponent<Simulator>().SimulateTurn(caller, o);
    }

    public IEnumerator StateMachine(GameElement caller)
    {
        if(waiting)
        {
            if (caller.VariableObject is Tile T && caller.transform.childCount > 6)
            {
                caller = caller.transform.GetChild(6).gameObject.GetComponent<PieceObject>();
            }

            if (selectable is ComplexList o)
            {
                switch (o.collection)
                {
                    case Collection.ANY:
                        if (caller.VariableObject is Piece p && o.list.Contains(p))
                        {
                            clicked = visitor.Variables[caller.VariableKey];
                        }
                        break;
                }
            }
            yield break;
        }

        if (caller.VariableObject is Piece P && currentPlayer.player.stages[currentPlayer.player.currentStage] == (int)TurnStages.SelectTile)
        {
            caller = caller.transform.parent.gameObject.GetComponent<TileObject>();
        }
        else if (caller.VariableObject is Tile T && caller.transform.childCount > 6 && currentPlayer.player.stages[currentPlayer.player.currentStage] == (int)TurnStages.SelectPiece)
        {
            
            caller = caller.transform.GetChild(6).gameObject.GetComponent<PieceObject>();
        }
        switch (currentPlayer.player.stages[currentPlayer.player.currentStage])
        {
            case (int)TurnStages.SelectTile:
                if (caller.VariableObject is Tile t)
                {
                    TileKey = caller.VariableKey;
                    currentPlayer.player.currentStage++;
                }
                break;
            case (int)TurnStages.SelectPiece:
                if (caller.VariableObject is Piece p && currentPlayer.player.pieces.Contains(p))
                {
                    PieceKey = caller.VariableKey;
                    caller.transform.parent.GetComponent<MeshRenderer>().material.color = AppManager.settings.selectionColor;
                    currentPlayer.player.currentStage++;
                }
                break;
        }
        if (currentPlayer.player.stages[currentPlayer.player.currentStage] == (int)TurnStages.RollDice)
        {
            RolltheDice(visitor.Variables.FirstOrDefault(x => x.Value == currentPlayer.player.dice).Key);
            yield return new WaitUntil(() => GameObject.Find("DiceImage").GetComponent<Image>().enabled == true);
            currentPlayer.player.currentStage++;
        }
        if (currentPlayer.player.stages[currentPlayer.player.currentStage] == (int)TurnStages.CheckRule)
        {
            PlayerKey = visitor.Variables.FirstOrDefault(x => x.Value == currentPlayer.player).Key;
            if (CheckRule())
            {
                currentPlayer.player.currentStage++;
            }
            else
            {
                currentPlayer.player.currentStage = 0;
                while (currentPlayer.player.stages[currentPlayer.player.currentStage] != (int)TurnStages.SelectTile &&
                    currentPlayer.player.stages[currentPlayer.player.currentStage] != (int)TurnStages.SelectPiece)
                    currentPlayer.player.currentStage++;
                ResetKeys();
            }
        }
        if(stepCoroutines.Count>0)
        {
            for (int i = 0; i < stepCoroutines.Count; i++)
            {
                yield return StartCoroutine(stepCoroutines[i]);
                yield return null;
            }
            stepCoroutines.Clear();
            UpdateElements();
        }
        if (currentPlayer.player.stages[currentPlayer.player.currentStage] == (int)TurnStages.CustomFuncs)
        {
            List<CustomFunction> temp = new List<CustomFunction>();
            foreach (var item in currentPlayer.player.funcs)
                temp.Add(item);

            foreach (CustomFunction cf in temp)
            {
                string subjectKey = "";
                if (cf.args[0] != null)
                {
                    if (cf.args[0] is IList list)
                    {
                        waiting = true;
                        switch ((string)list[0])
                        {
                            case "Click":
                                selectable = list[1];
                                yield return new WaitUntil(() => clicked != null);
                                object subject = clicked;
                                clicked = null;
                                subjectKey = visitor.Variables.FirstOrDefault(x => x.Value == subject).Key;
                                break;
                            case "Press":
                                pressable = (string)list[1];
                                yield return new WaitUntil(() => pressable == string.Empty);
                                subjectKey = "";
                                clicked = null;
                                break;
                        }
                    }
                    else
                    {
                        subjectKey = visitor.Variables.FirstOrDefault(x => x.Value == cf.args[0]).Key;
                    }
                }
                string callerPlayer = currentPlayer.VariableKey;
                if (CheckCustom(currentPlayer.player.funcs[currentPlayer.player.customFuncsIndex], subjectKey))
                {
                    if (currentPlayer.VariableKey != callerPlayer)
                        yield break;
                    if (!cancel)
                    {
                        currentPlayer.player.customFuncsIndex++;
                        currentPlayer.player.currentStage++;
                    }
                    else
                        StartCoroutine(StateMachine(caller));
                    cancel = false;
                }
                else
                {
                    if (currentPlayer.VariableKey != callerPlayer)
                        yield break;

                    if (!cancel)
                    {
                        currentPlayer.player.currentStage = 0;
                        ResetKeys();
                    }
                    else
                        StartCoroutine(StateMachine(caller));
                    cancel = false;
                }

                waiting = false;
            }
        }
        if (currentPlayer.player.stages[currentPlayer.player.currentStage] == (int)TurnStages.CheckWin)
        {
            CheckWinner();
        }
        yield break;
    }

    public static bool CheckRule()
    {
        ResetSelected();

        if (!simulating)
            SaveState();

        if (PieceKey == null)
        {
            visitor.Variables["return"] = false;
            Script(PlayerKey + ".Rule(" + TileKey + ");", true);
            if ((bool)visitor.Variables["return"])
            {
                return true;
            }
            return false;
        }
        else if(TileKey == null)
        {
            visitor.Variables["return"] = false;
            Script(PieceKey + ".Rule();", true);
            if ((bool)visitor.Variables["return"])
            {
                return true;
            }
        }
        else
        {
            visitor.Variables["return"] = false;
            Script(PieceKey + ".Rule(" + TileKey + ");", true);

            if ((bool)visitor.Variables["return"])
            {
                if(visitor.Variables[PieceKey] is Piece p && visitor.Variables[TileKey] is Tile t)
                {
                    p.posX = t.posX;
                    p.posY = t.posY;
                }

                return true;
            }
        }
        return false;
    }
    public static bool CheckCustom(CustomFunction cf, string arg)
    {
        visitor.Variables["return"] = false;
        Script(cf.name + "(" + arg + ");", true);

        if (!(bool)visitor.Variables["return"])
        {
            RollBack();
            return false;
        }
        else
            return true;
    }
    public static void SaveState()
    {
        AppManager.visitorBackUp = JsonConvert.SerializeObject(visitor.Variables, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
    }

    public static void RollBack()
    {
        visitor.Variables = JsonConvert.DeserializeObject<Dictionary<string, object>>(AppManager.visitorBackUp, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        List<GameElement> removables = new List<GameElement>();
        foreach (GameElement gameElement in gameElements)
        {
            if (visitor.Variables.ContainsKey(gameElement.VariableKey))
                gameElement.VariableObject = visitor.Variables[gameElement.VariableKey];
            else
            {
                removables.Add(gameElement);
            }
        }
        foreach (GameElement gameElement in removables)
        {
            gameElements.Remove(gameElement);
            Destroy(gameElement.gameObject);
        }
        if (!simulating)
            UpdateElements();
    }

    public static void UpdateElements()
    {
        foreach (var item in visitor.Variables)
        {
            if (item.Value is Piece pi)
            {
                bool exist = false;
                foreach (GameElement GE in gameElements)
                    if (GE.VariableObject == pi)
                        exist = true;
                if (!exist && !simulating)
                {
                    GameObject temp = Instantiate(GameObject.Find("Piece"));
                    temp.GetComponent<PieceObject>().enabled = true;
                    temp.GetComponent<PieceObject>().CreateElement(new object[] { pi, item.Key });
                    gameElements.Add(temp.GetComponent<PieceObject>());
                }
            }
        }

        foreach (GameElement gameElement in gameElements)
        {
            if(visitor.Variables[gameElement.VariableKey] == null)
                gameElement.gameObject.SetActive(false);
            else if(!gameElement.gameObject.activeSelf)
            {
                gameElement.gameObject.SetActive(true);
                gameElement.UpdateElement();
            }
            else
                gameElement.UpdateElement();
        }
        if (debugMode)
            GameObject.Find("Variables").GetComponent<Variables>().SetVariables();
    }

    public static void DisplayLog(string message, bool error, int line)
    {
        if (debugMode)
            GameObject.Find("Console").GetComponent<Console>().DisplayLog(message, error, line);
    }

    public static void RolltheDice(string diceName)
    {
        GameObject.Find(diceName).transform.localPosition = Vector3.zero;
        GameObject.Find(diceName).GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GameObject.Find(diceName).transform.localRotation = Quaternion.Euler(new Vector3(45, 45, 0));

        GameObject.Find("DiceImage").GetComponent<Image>().enabled = false;
    }

    public void CheckWinner()
    {
        visitor.Variables["return"] = false;
        Script(PlayerKey + ".WinCondition();", true);
        if ((bool)visitor.Variables["return"])
        {
            PlayerWon.SetActive(true);
            PlayerWon.transform.GetChild(0).GetComponent<Animator>().speed = 1.0f;
            GameObject.Find("WinnerName").GetComponent<TMP_Text>().text = currentPlayer.player.name + " Won!";
            return;
        }

        if (visitor.hasDraw)
            CheckDraw();

        EndTurn();
    }

    public void CheckDraw()
    {
        visitor.Variables["return"] = false;
        Script(PlayerKey + ".DrawCondition();", true);
        if ((bool)visitor.Variables["return"])
        {
            /*PlayerWon.SetActive(true);
            PlayerWon.transform.GetChild(0).GetComponent<Animator>().speed = 1.0f;
            GameObject.Find("WinnerName").GetComponent<TMP_Text>().text = currentPlayer.player.name + " Won!";*/
            Debug.Log("Draw!");
            return;
        }
    }

    public void EndTurn()
    {
        waiting = false;

        ResetSelected();

        ResetKeys();

        currentPlayer.player.currentStage = 0;

        if (current == players.Count - 1)
            current = 0;
        else
            current++;
        currentPlayer = players[current];
        currentPlayer.player.currentStage = 0;

        currentPlayer.player.customFuncsIndex = 0;
        currentPlayer.player.currentStage = 0;

        PlayerKey = visitor.Variables.FirstOrDefault(x => x.Value == currentPlayer.player).Key;

        visitor.Variables["CurrentPlayer"] = currentPlayer.player;

        SaveState();

        StartCoroutine(StateMachine(GetComponent<GameElement>()));
    }

    public static void ResetKeys()
    {
        PieceKey = null;
        TileKey = null;
        PlayerKey = null;
    }
    public static void ResetSelected()
    {
        foreach (GameElement po in gameElements)
        {
            if (po.VariableKey == PieceKey)
            {
                po.transform.parent.GetComponent<MeshRenderer>().material.color = po.transform.parent.GetComponent<TileObject>().color;
            }
        }
    }

    public void ReturnToEditor()
    {
        ClearBoard();
        AppManager.visitorBackUp = null;
        AppManager.ChangeScene("BoardEditor");
    }

    public void ExitGame()
    {
        ClearBoard();
        AppManager.visitorBackUp = null;
        AppManager.ChangeScene("StartScene");
    }

    public void RestartGame()
    {
        ClearBoard();
        AppManager.visitorBackUp = null;
        AppManager.ChangeScene("GameScene");
    }

    public void ButtonHandler(ButtonObject button)
    {
        if(!PlayerWon.activeInHierarchy)
        {
            visitor.Variables["return"] = false;
            Script(button.ClickHandler, true);
        }
    }

    public void PieceMove(Piece pieceObject, List<Tile> tiles, MoveType type)
    {
        if(!simulating)
        {
            switch(type)
            {
                case MoveType.Step:
                    stepCoroutines.Add(GetComponent<MovePiece>().PieceStep(pieceObject, tiles));
                    break;
                case MoveType.Slide:
                    stepCoroutines.Add(GetComponent<MovePiece>().PieceSlide(pieceObject, tiles));
                    break;
                case MoveType.Jump:
                    //stepCoroutines.Add(StartCoroutine(GetComponent<MovePiece>().PieceStep(pieceObject, tiles)));
                    break;
            }
        }
    }

    public static int GetMaxX()
    {
        return maxX;
    }
    public static int GetMaxY()
    {
        return maxY;
    }
    public static int GetMinX()
    {
        return minX;
    }
    public static int GetMinY()
    {
        return minY;
    }

    public static void Script(string s, bool updateNeeded)
    {
        var lexer = new Combined1Lexer(new AntlrInputStream(s));
        var tokens = new CommonTokenStream(lexer);
        var parser = new Combined1Parser(tokens);
        var tree = parser.program();
        visitor.Visit(tree);

        if (!simulating && updateNeeded && stepCoroutines.Count==0)
            UpdateElements();
    }

    public GameObject SButton;
    public GameObject LButton;
    public void Menu()
    {
        SButton.SetActive(true);
        LButton.SetActive(true);
    }
}

public enum TurnStages
{
    SelectTile = 0,
    SelectPiece = 1,
    RollDice = 2,
    CheckRule = 3,
    CustomFuncs = 4,
    CheckWin = 5
}

public enum MoveType
{
    Step = 0,
    Slide = 1,
    Jump = 2
}