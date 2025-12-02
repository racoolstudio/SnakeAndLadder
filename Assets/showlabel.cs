using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;

public class showlabel : MonoBehaviour
{
    public Transform rayStartPoint;
    public float rayLength = 5;
    public MRUKAnchor.SceneLabels labelFilter;
    public TextMeshPro debugText;

    void Update()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();

        // Correct: Included() is static
        LabelFilter filter = LabelFilter.Included(labelFilter);

        bool hasHit = room.Raycast(
            ray,
            rayLength,
            filter,
            out RaycastHit hit,
            out MRUKAnchor anchor
        );

        if (hasHit)
        {
            Vector3 hitPoint = hit.point;
            Vector3 hitNormal = hit.normal;

            // Convert enum to string
            string label = anchor.Label.ToString();

            debugText.transform.position = hitPoint;
            debugText.transform.rotation = Quaternion.LookRotation(-hitNormal);
            debugText.text = "HERE is " + label;
        }
    }
}
