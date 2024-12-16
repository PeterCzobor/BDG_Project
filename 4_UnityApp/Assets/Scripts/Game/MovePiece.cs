using Language;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PieceStep(Piece pieceObject, List<Tile> tiles)
    {
        PieceObject PO = null;
        List<TileObject> TOs = new List<TileObject>();
        foreach (GameElement ge in GameManager.gameElements)
        {
            if (ge.VariableObject == pieceObject)
                PO = ge.GetComponent<PieceObject>();
        }
        foreach (Tile t in tiles)
        {
            foreach (GameElement ge in GameManager.gameElements)
            {
                if (ge.VariableObject == t)
                    TOs.Add(ge.GetComponent<TileObject>());
            }
        }
        for (int i = 0; i < TOs.Count; i++)
        {
            yield return StartCoroutine(StepToTile(PO, TOs[i], 0.25f));
            yield return null;
            if (i < TOs.Count - 1)
                yield return new WaitForSeconds(0.25f);
        }
        yield break;
    }
    public IEnumerator PieceSlide(Piece pieceObject, List<Tile> tiles)
    {
        PieceObject PO = null;
        TileObject TO = null;
        foreach (GameElement ge in GameManager.gameElements)
        {
            if (ge.VariableObject == pieceObject)
                PO = ge.GetComponent<PieceObject>();
            if (ge.VariableObject == tiles[0])
                TO = ge.GetComponent<TileObject>();
        }
        yield return StartCoroutine(StepToTile(PO, TO, 0.5f));
        yield return null;
        yield break;
    }

    public IEnumerator StepToTile(PieceObject pieceObject, TileObject tileObject, float time)
    {
        Vector3 startPosition = pieceObject.gameObject.transform.position;

        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            pieceObject.gameObject.transform.position = Vector3.Lerp(startPosition, new Vector3(tileObject.gameObject.transform.position.x,
                0.35f, tileObject.gameObject.transform.position.z), Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
