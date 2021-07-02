using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoutObject : MonoBehaviour
{
    [SerializeField]
    public Transform targetObject;

    [SerializeField]
    public LayerMask wallMask;

    private Camera mainCamera;

    private List<GameObject> wallsHit = new List<GameObject>();

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        float characterDistance = Vector3.Distance(transform.position, targetObject.position);

        RaycastHit[] hits = Physics.RaycastAll(transform.position, targetObject.position - transform.position, characterDistance, wallMask);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                wallsHit.Add(hit.transform.gameObject);

                Material[] materials = hit.transform.GetComponent<Renderer>().materials;

                for (int m = 0; m < materials.Length; m++)
                {
                    materials[m].SetFloat("_Opacity", 3.0f);
                    materials[m].SetInt("_AllowEmission", 1);
                }
            }
        }
        else
        {
            if (wallsHit != null)
            {
                foreach (GameObject wall in wallsHit)
                {
                    Material[] materials = wall.GetComponent<Renderer>().materials;

                    for (int m = 0; m < materials.Length; m++)
                    {
                        materials[m].SetFloat("_Opacity", 100.0f);
                        materials[m].SetInt("_AllowEmission", 0);
                    }
                }

                wallsHit = new List<GameObject>();
            }
        }
    }
}
