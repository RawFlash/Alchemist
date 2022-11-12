using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    //Мой объект фонаря в руках
    public GameObject MyFonar;

    //тру когда кристал в зоне действия
    bool TriggerCrystal;

    //тру когда фонарь в зоне действия
    bool TriggerFonar;

    //выбранный кристал, чтоб когда 2 кристала в зоне, выбрать ближайший
    GameObject SelectedCrystal;


    //выбранный фонарь для его удаления
    GameObject SelectedFonar;

    new Camera camera;

    public GameObject Fonar;

    public GameObject InteractionText;
    
    //последний пересекаемый взгядом объект
    RaycastHit hit;

    //Дистанция взаимодействия
    public float DistanceInteraction;

    void Start()
    {
        camera = GetComponent<Camera>();

    }

    void Update()
    {
        //ХЕРня с выпуском луча и поиском точки
        Ray ray = camera.ScreenPointToRay(new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2));
        if(Physics.Raycast(ray, maxDistance: DistanceInteraction))
        {
            RaycastHit newhit;
            Physics.Raycast(ray, maxDistance:DistanceInteraction, hitInfo: out newhit);
            if (hit.collider!=null && hit.collider.gameObject!=newhit.collider.gameObject)
            {
                OnTriggerExit(hit.collider);
            }
            Physics.Raycast(ray, maxDistance: DistanceInteraction, hitInfo: out hit);
            OnTriggerEnter(hit.collider);
        }
        else
        {
            if(hit.collider!=null)
                OnTriggerExit(hit.collider);
            Physics.Raycast(ray, maxDistance: DistanceInteraction);
        }
        Debug.DrawRay(ray.origin, ray.direction * DistanceInteraction, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (TriggerCrystal)
            {
                SelectedCrystal.GetComponent<Crystal>().Collection();
                OnTriggerExit(SelectedCrystal.GetComponent<Collider>());
                SelectedCrystal = null;
                GetComponent<Inventory>().AddInInventory(InventoryObjects.NewCrystal());
            }

            //БЕРУ ФОНАРЬ
            if (TriggerFonar && MyFonar.activeSelf==false)
            {
                MyFonar.SetActive(true);
                OnTriggerExit(SelectedFonar.GetComponent<Collider>());
                Destroy(SelectedFonar);
                SelectedFonar = null;
            }
            else
            {
                if (MyFonar.activeSelf)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Vector3 objectHit = hit.point;
                        if ((gameObject.transform.position - objectHit).magnitude < 4)
                        {

                            GameObject newF = Instantiate(Fonar, new Vector3(objectHit.x, objectHit.y + 0.2f, objectHit.z), new Quaternion());
                            newF.SetActive(true);
                            newF.name = "Fonar";
                            Debug.Log("Фонарь поставлен");

                            MyFonar.SetActive(false);
                        }

                    }
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("В зону попал объект");
        if (other.gameObject.name == "Crystal")
        {
            if (SelectedCrystal == null)
            {
                //случай, если выбранного кристалла пока нет
                SelectedCrystal = other.gameObject;
            }
            else
            {
                //случай, если у нас уже есть выбранный кристалл
                if ((other.gameObject.transform.position - gameObject.transform.parent.position).magnitude <
                    (SelectedCrystal.transform.position - gameObject.transform.parent.position).magnitude)
                {
                    SelectedCrystal = other.gameObject;
                }
            }
            TriggerCrystal = true;
            InteractionText.SetActive(true);
        }
        if (other.gameObject.name.Contains("Fonar"))
        {
            Debug.Log("В зону попал фонарь");
            SelectedFonar = other.gameObject;
            InteractionText.SetActive(true);
            TriggerFonar = true;

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Crystal")
        {
            TriggerCrystal = false;
            InteractionText.SetActive(false);
        }
        if (other.gameObject.name == "Fonar")
        {
            InteractionText.SetActive(false);
            TriggerFonar = false;

        }
    }



    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.name == "Crystal")

        //other.gameObject.GetComponent<Crystal>().Collection();
    }
}
