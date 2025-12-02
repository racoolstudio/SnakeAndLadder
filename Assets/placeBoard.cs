using UnityEngine;
using Meta.XR.MRUtilityKit;
using System.Collections;

public class BoardAnchorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boardPrefab;

       private void Start()
    {
        StartCoroutine(PlaceBoardAfterFrame());
    }
     private IEnumerator PlaceBoardAfterFrame()
    {
        // Wait until the end of the frame so that all initialization is done
        yield return new WaitForEndOfFrame();
        PlaceBoardOnLargestTable();
    }

    private void PlaceBoardOnLargestTable()
    {
        // Get the current room
        var room = MRUK.Instance?.GetCurrentRoom();
        if (room == null)
        {
            Debug.LogWarning("No MRUK room found");
            return;
        }

        // Find the largest table surface - this method already exists
        var largestTable = room.FindLargestSurface(MRUKAnchor.SceneLabels.TABLE);
        
        if (largestTable != null)
        {
            // Place the board at the table's position and rotation
            Instantiate(boardPrefab, largestTable.transform.position, largestTable.transform.rotation);
            Debug.Log("Board placed on largest table surface");
        }
        else
        {
            Debug.LogWarning("No table surface found in the scene");
        }
    }

    // Simple method to refresh placement if needed
    [ContextMenu("Refresh Board Placement")]
    public void RefreshBoardPlacement()
    {
        PlaceBoardOnLargestTable();
    }
}