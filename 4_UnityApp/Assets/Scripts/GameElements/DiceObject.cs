using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Language;

public class DiceObject : GameElement
{
    public int Result;
    public Dice dice;
    public string diceKey;
    public List<Texture2D> sideTextures;

    public override string VariableKey { get => diceKey; set => diceKey = value; }
    public override object VariableObject { get => dice; set => dice = (Dice)value; }

    public override void CreateElement(object[] args)
    {
        if (args[0] is Dice dice_)
            dice = dice_;
        if (args[1] is string diceKey_)
            diceKey = diceKey_;
    }

    void Roll()
    {
        transform.localPosition = Vector3.zero;

        GetComponent<Collider>().enabled = false;
        float forceX = (Random.Range(0, 2) * 2 - 1) * Random.Range(20, 50);
        float forceY = (Random.Range(0, 2) * 2 - 1) * Random.Range(20, 50);
        float forceZ = (Random.Range(0, 2) * 2 - 1) * Random.Range(20, 50);
        GetComponent<Rigidbody>().AddTorque(forceX, forceY, forceZ, ForceMode.Impulse);
        StartCoroutine("RollResult");
    }
    IEnumerator RollResult()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Result = Random.Range(1, 7);
        switch(Result)
        {
            case 1:
                transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                break;
            case 2:
                transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 90));
                break;
            case 3:
                transform.localRotation = Quaternion.Euler(new Vector3(-90, 0, -90));
                break;
            case 4:
                transform.localRotation = Quaternion.Euler(new Vector3(-90, -90, 180));
                break;
            case 5:
                transform.localRotation = Quaternion.Euler(new Vector3(-90, 180, 0));
                break;
            case 6:
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
        }
        dice.value = Result;
        GetComponent<Collider>().enabled = true;

        yield return new WaitForSeconds(0.5f);

        GameObject.Find("DiceImage").GetComponent<Image>().enabled = true;
        GameObject.Find("DiceImage").GetComponent<Image>().sprite = Sprite.Create(sideTextures[Result - 1], new Rect(0, 0, sideTextures[Result - 1].width, sideTextures[Result - 1].height), Vector2.zero);
        transform.localPosition = new Vector3(0, 0, -10000);

        yield break;
    }

    void OnMouseDown()
    {
        Roll();
    }
}
