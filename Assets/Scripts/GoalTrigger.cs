using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject endPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (endPanel != null)
            {
                endPanel.SetActive(true);

                CarController car = other.GetComponent<CarController>();
                if (car != null)
                {
                    car.canDrive = false;
                }
            }
        }
    }
}