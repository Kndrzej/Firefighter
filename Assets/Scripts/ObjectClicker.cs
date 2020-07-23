using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField] private AudioSource error = null;
    [SerializeField] private GameObject errorMessage = null;
    private int correctOrderNumber = 0;

    public static bool CanUseExtinquisher = false;

    [SerializeField] private GameObject helmet = null;
    [SerializeField] private Sprite helmetCorrect = null;
    private Image helmetImage;

    [SerializeField] private GameObject jacket = null;
    [SerializeField] private Sprite jacketCorrect = null;
    private Image jacketImage;

    [SerializeField] private GameObject extingiusher = null;
    [SerializeField] private Sprite extingiusherCorrect = null;
    private Image extingiusherImage;


    private void Start()
    {
        jacketImage = jacket.GetComponent<Image>();
        helmetImage = helmet.GetComponent<Image>();
        extingiusherImage = extingiusher.GetComponent<Image>(); 
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    Rigidbody rb;
                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {
                        if (rb.CompareTag("Helmet") && correctOrderNumber == 1)
                        {
                            helmetImage.sprite = helmetCorrect;
                            correctOrderNumber += 1;
                            Destroy(rb.transform.gameObject);
                        }
                        else if (rb.CompareTag("Jacket") && correctOrderNumber == 0)
                        {
                            jacketImage.sprite = jacketCorrect;
                            correctOrderNumber += 1;
                            Destroy(rb.transform.gameObject);
                        }
                        else if (rb.CompareTag("Extinguisher") && correctOrderNumber == 2)
                        {
                            extingiusherImage.sprite = extingiusherCorrect;
                            Destroy(rb.transform.gameObject);
                            CanUseExtinquisher = true;
                        }
                        else if (rb.CompareTag("Fire")){}
                        else
                        {
                            Debug.Log("else");
                            error.Play();
                            StartCoroutine(ErrorMessage());
                        }
                    }
                }
            }
        }
    }

    public IEnumerator ErrorMessage()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(1f);
        errorMessage.SetActive(false);
    }

}
