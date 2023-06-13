using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderPuzzle : MonoBehaviour
{
   [SerializeField] private int puzzleSize;
   [SerializeField] private GameObject tilePrefab;
   [SerializeField] private float moveDuration = 0.3f;
   [SerializeField] private List<Sprite> puzzleSprites;
   [SerializeField] private List<Tile> tileList = new List<Tile>();
   [SerializeField] private int[] puzzleArray = new int[] { 4, 7, 3, 6, 5, 2, 0, 1, 8 };
   private float backgroundSize;
   private Tile emptyTile;
   private bool isMoving;

   private void Start()
   {
      backgroundSize = GetComponent<Image>().rectTransform.rect.width;
      
      SpawnPuzzle();
   }
   
   private void SpawnPuzzle()
   {
      float tileSize = backgroundSize / puzzleSize;
      List<int> puzzlePos = new List<int>();
      for (int i = 0; i < puzzleSize * puzzleSize; i++)
      {
         puzzlePos.Add(i);
      }
      
      ShuffleList(puzzlePos);

      for (int i = 0; i < puzzleSize; i++)
      {
         for (int j = 0; j < puzzleSize; j++)
         {
            var newTile = Instantiate(tilePrefab, transform);
            RectTransform rectTransform = newTile.GetComponent<RectTransform>();
            
            rectTransform.sizeDelta = new Vector2(tileSize, tileSize);
            
            float xPos = (j - (puzzleSize - 1) / 2f) * tileSize;
            float yPos = ((puzzleSize - 1) / 2f - i) * tileSize;
            
            rectTransform.anchoredPosition = new Vector2(xPos, yPos);
            
            newTile.GetComponent<Image>().sprite = puzzleSprites[puzzlePos[i * puzzleSize + j]];
            newTile.name = puzzlePos[i * puzzleSize + j].ToString();
            
            Tile tile = newTile.GetComponent<Tile>();
            tile.SetValues(puzzlePos[i * puzzleSize + j], i * puzzleSize + j);
            tileList.Add(tile);
            
            newTile.GetComponent<Button>().onClick.AddListener(() => OnTileClick(tile));
         }
      }

      // int emptyTileIndex = Random.Range(0, puzzleSize);
      int emptyTileIndex = 8;
      tileList[emptyTileIndex].gameObject.SetActive(false);
      emptyTile = tileList[emptyTileIndex];
   }

   private void OnTileClick(Tile tile)
   {
      int index = tile.currentIndex;

      if (index == emptyTile.currentIndex || isMoving)
      {
         return;
      }

      int row = Mathf.FloorToInt(index / puzzleSize);
      int col = index % puzzleSize;

      int emptyRow = Mathf.FloorToInt(emptyTile.currentIndex / puzzleSize);
      int emptyCol = emptyTile.currentIndex % puzzleSize;

      if ((row == emptyRow && Mathf.Abs(col - emptyCol) == 1) || 
          (col == emptyCol && Mathf.Abs(row - emptyRow) == 1))
      {
         MoveTile(tile);
      }
   }

   private void ShuffleList(List<int> list)
   {
      int n = list.Count;
      // while (n > 1)
      // {
      //    // n--;
      //    // int k = Random.Range(0, n + 1);
      //    // (list[k], list[n]) = (list[n], list[k]);
      //    list[n] = numbers[n];
      // }

      for (int i = 0; i < n; i++)
      {
         list[i] = puzzleArray[i];
      }
   }
   
   private void MoveTile(Tile tile)
   {
      isMoving = true;
      Vector2 tempPos = emptyTile.rectTransform.anchoredPosition;
      Vector2 tileAnchoredPos = tile.rectTransform.anchoredPosition;
      
      emptyTile.rectTransform.anchoredPosition = tileAnchoredPos;
      (emptyTile.currentIndex, tile.currentIndex) = (tile.currentIndex, emptyTile.currentIndex);
      
      StartCoroutine(MoveCoroutine(tile, tempPos));
      
      CheckWin();
   }
   
   private void CheckWin()
   {
      for (int i = 0; i < tileList.Count; i++)
      {
         if (tileList[i].currentIndex != tileList[i].originalIndex)
         {
            return;
         }
      }
      
      Debug.Log("You win!");
      StartCoroutine(WaitGameFinish(emptyTile.gameObject));
   }

   IEnumerator MoveCoroutine(Tile tile, Vector2 emptyPos)
   {
      Vector2 startPosition = tile.rectTransform.anchoredPosition;
      float startTime = Time.time;

      while (Time.time < startTime + moveDuration)
      {
         float t = (Time.time - startTime) / moveDuration;
         tile.rectTransform.anchoredPosition = Vector2.Lerp(startPosition, emptyPos, t);
         yield return null;
      }

      tile.rectTransform.anchoredPosition = emptyPos;

      isMoving = false;
   }
   
   IEnumerator WaitGameFinish(GameObject obj)
   {
      yield return new WaitForSeconds(moveDuration);
      obj.SetActive(true);
      foreach (var prefab in tileList)
      {
         prefab.GetComponent<Button>().enabled = false;
      }
      Destroy(this);
   }
}
