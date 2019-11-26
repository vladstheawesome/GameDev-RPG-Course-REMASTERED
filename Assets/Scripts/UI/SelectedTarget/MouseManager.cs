using UnityEngine;
using System.Collections;
using RPG.Combat;

public class MouseManager : MonoBehaviour
{

    public GameObject selectedObject;
    Fighter fighter;

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo) && fighter.GetTarget() != null)
            {
                GameObject hitObject = hitInfo.transform.gameObject;

                SelectObject(hitObject);
            }
            else
            {
                ClearSelection();
            }
        }
    }

    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)
                return;

            ClearSelection();
        }

        selectedObject = obj;

        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.red;
            r.material = m;
        }
    }

    void ClearSelection()
    {
        if (selectedObject == null)
            return;

        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }

        selectedObject = null;
    }
}
