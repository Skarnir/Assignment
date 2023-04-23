using UnityEngine;

public class doorController : MonoBehaviour
{
    public GameObject leftDoorPanel;
    public GameObject rightDoorPanel;
    public float doorSpeed = 1.0f;
    public float doorOpenDistance = 2.0f;

    private Vector3 leftDoorClosedPosition;
    private Vector3 rightDoorClosedPosition;
    private Vector3 leftDoorOpenPosition;
    private Vector3 rightDoorOpenPosition;
    private bool doorIsOpen;

    private void Start()
    {
        leftDoorClosedPosition = leftDoorPanel.transform.position;
        rightDoorClosedPosition = rightDoorPanel.transform.position;
        leftDoorOpenPosition = leftDoorClosedPosition - new Vector3(doorOpenDistance, 0, 0);
        rightDoorOpenPosition = rightDoorClosedPosition + new Vector3(doorOpenDistance, 0, 0);
        doorIsOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorIsOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorIsOpen = false;
        }
    }

    private void Update()
    {
        if (doorIsOpen)
        {
            leftDoorPanel.transform.position = Vector3.Lerp(leftDoorPanel.transform.position, leftDoorOpenPosition, doorSpeed * Time.deltaTime);
            rightDoorPanel.transform.position = Vector3.Lerp(rightDoorPanel.transform.position, rightDoorOpenPosition, doorSpeed * Time.deltaTime);
        }
        else
        {
            leftDoorPanel.transform.position = Vector3.Lerp(leftDoorPanel.transform.position, leftDoorClosedPosition, doorSpeed * Time.deltaTime);
            rightDoorPanel.transform.position = Vector3.Lerp(rightDoorPanel.transform.position, rightDoorClosedPosition, doorSpeed * Time.deltaTime);
        }
    }
}
