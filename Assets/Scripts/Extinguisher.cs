using UnityEngine;
using UnityEngine.SceneManagement;

internal class Extinguisher : MonoBehaviour
{
    private int timeInFireSight = 0;
    [SerializeField] GameObject fire = null;
    [SerializeField] GameObject extinquisher = null;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if(ObjectClicker.CanUseExtinquisher == true)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                extinquisher.SetActive(true);
                if (Physics.Raycast(ray, out hit, 200.0f))
                {
                    if (hit.transform != null)
                    {

                        Rigidbody rb;

                        if (rb = hit.transform.GetComponent<Rigidbody>())
                        {
                            if (rb.transform.root.CompareTag("Fire"))
                            {
                                timeInFireSight += 1;
                            }
                        }
                    }
                }
                if (timeInFireSight == 300)
                {
                    Destroy(fire.gameObject);
                    SceneManager.LoadScene("EndScreen");
                    Debug.Log("loaded scenes");
                    GameManager.audioSource.Stop();
                    Cursor.lockState = CursorLockMode.None;
                }
                Debug.Log(timeInFireSight);
            }
        }
        else
        {
            timeInFireSight = 0;
            extinquisher.SetActive(false);
        }
    }
}