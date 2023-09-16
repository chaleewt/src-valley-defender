using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WCBuildingManager : MonoBehaviour
{
    //.. Tower Recruite Resources
    [SerializeField]
    private int gold = 100;

    [SerializeField]
    private int diamond = 0;

    [SerializeField]
    private int redDiamond = 0;

    [SerializeField] private Text goldText;
    [SerializeField] private Text diamondText;
    [SerializeField] private Text redDiamondText;
    [SerializeField] private GameObject archerTowerButtonFilter;
    [SerializeField] private GameObject cannonTowerButtonFilter;
    [SerializeField] private GameObject debuffTowerButtonFilter;

    //.. Tower Cost
    [SerializeField]
    private int archerTowerGoldCost = 25;
    [SerializeField]
    private int archerTowerDiamondCost = 1;

    [SerializeField]
    private int cannonTowerGoldCost = 50;
    [SerializeField]
    private int cannonTowerDiamondCost = 5;

    [SerializeField]
    private int debuffTowerGoldCost = 100;
    [SerializeField]
    private int debuffTowerRedDiamondCost = 5;


    [Header("Setup")]
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask unplaceableLayer;
    [SerializeField] LayerMask placeableLayer;

    [SerializeField] GameObject ghostCannonTowerPrefab;
    [SerializeField] GameObject ghostArcherTowerPrefab;
    [SerializeField] GameObject ghostDebuffTowerPrefab;

    [SerializeField] GameObject cannonTowerPrefab;
    [SerializeField] GameObject archerTowerPrefab;
    [SerializeField] GameObject debuffTowerPrefab;

    [SerializeField]
    private GameObject buildingParent;

    private GameObject buildingCursor;
    private Vector3 mousePosition;

    bool isCanPlace = false;
    bool isBuilding = false;
    bool isCannonTower = false;
    bool isArcherTower = false;
    bool isDebuffTower = false;

    //.. Temp Class
    private WCGhostTower ghostTowerComp;

    void Awake()
    {
        //.. Display resources on UI
        goldText.text = gold.ToString();
        diamondText.text = diamond.ToString();
        redDiamondText.text = redDiamond.ToString();

        //.. Init Tower Button Filter
        if (gold >= archerTowerGoldCost && diamond >= archerTowerDiamondCost)
        {
            archerTowerButtonFilter.SetActive(false);
        }
        else
        {
            archerTowerButtonFilter.SetActive(true);
        }

        if (gold >= cannonTowerGoldCost && diamond >= cannonTowerDiamondCost)
        {
            cannonTowerButtonFilter.SetActive(false);
        }
        else
        {
            cannonTowerButtonFilter.SetActive(true);
        }

        if (gold >= debuffTowerGoldCost && redDiamond >= debuffTowerRedDiamondCost)
        {
            debuffTowerButtonFilter.SetActive(false);
        }
        else
        {
            debuffTowerButtonFilter.SetActive(true);
        }
    }

    void Update()
    {
        //.. Make GhostPrefab follow Mouse Cursor
        if (isBuilding)
        {
            buildingCursor.transform.position = mousePosition;
        }

        GetMousePosition();

        PlaceCannonTower();
        PlaceArcherTower();
        PlaceDebuffTower();


        //.. Cancel Placement With Mouse
        if (Input.GetMouseButtonDown(1))
        {
            CancelBuildingPlacement();
        }

        //.. Cancel Placement If resource not enough ///////////////////////////
        if (isBuilding && isArcherTower)
        {
            if (gold < archerTowerGoldCost || diamond < archerTowerDiamondCost)
            {
                CancelBuildingPlacement();
            }
        }

        if (isBuilding && isCannonTower)
        {
            if (gold < cannonTowerGoldCost || diamond < cannonTowerDiamondCost)
            {
                CancelBuildingPlacement();
            }
        }

        if (isBuilding && isDebuffTower)
        {
            if (gold < debuffTowerGoldCost || redDiamond < debuffTowerRedDiamondCost)
            {
                CancelBuildingPlacement();
            }
        }

        ////////////////////////////////////////////////////////////////////////
        if (gold < archerTowerGoldCost || diamond < archerTowerDiamondCost)
        {
            archerTowerButtonFilter.SetActive(true);
        }
        else
        {
            archerTowerButtonFilter.SetActive(false);
        }

        if (gold < cannonTowerGoldCost || diamond < cannonTowerDiamondCost)
        {
            cannonTowerButtonFilter.SetActive(true);
        }
        else
        {
            cannonTowerButtonFilter.SetActive(false);
        }

        if (gold < debuffTowerGoldCost || redDiamond < debuffTowerRedDiamondCost)
        {
            debuffTowerButtonFilter.SetActive(true);
        }
        else
        {
            debuffTowerButtonFilter.SetActive(false);
        }
        ///////////////////////////////////////////////////////////////////////

    }

    private void GetMousePosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, float.MaxValue, unplaceableLayer))
        {
            isCanPlace = false;
            mousePosition = raycastHit.point;
        }

        if (Physics.Raycast(ray, out raycastHit, float.MaxValue, placeableLayer))
        {
            isCanPlace = true;
            mousePosition = raycastHit.point;
        }
    }

    public void SpawnGhostArcherTower()
    {
        if (gold >= archerTowerGoldCost && diamond >= archerTowerDiamondCost)
        {
            isBuilding = true;
            isArcherTower = true;

            GameObject prefab = Instantiate(ghostArcherTowerPrefab, mousePosition, Quaternion.identity);
            buildingCursor = prefab;
            buildingCursor.SetActive(true);
            ghostTowerComp = buildingCursor.GetComponent<WCGhostTower>();
        }
    }

    public void SpawnGhostCannonTower()
    {
        if (gold >= cannonTowerGoldCost && diamond >= cannonTowerDiamondCost)
        {
            isBuilding = true;
            isCannonTower = true;

            GameObject prefab = Instantiate(ghostCannonTowerPrefab, mousePosition, Quaternion.identity);
            buildingCursor = prefab;
            buildingCursor.SetActive(true);
            ghostTowerComp = buildingCursor.GetComponent<WCGhostTower>();
        }
    }

    public void SpawnGhostDebuffTower()
    {
        if (gold >= debuffTowerGoldCost && redDiamond >= debuffTowerRedDiamondCost)
        {
            isBuilding = true;
            isDebuffTower = true;

            GameObject prefab = Instantiate(ghostDebuffTowerPrefab, mousePosition, Quaternion.identity);
            buildingCursor = prefab;
            buildingCursor.SetActive(true);
            ghostTowerComp = buildingCursor.GetComponent<WCGhostTower>();
        }
    }


    private void PlaceArcherTower()
    {
        if (isBuilding && Input.GetMouseButtonDown(0) && isArcherTower && isCanPlace)
        {
            TowerPayment(archerTowerGoldCost, archerTowerDiamondCost, 0);
            GameObject tower = Instantiate(archerTowerPrefab, ghostTowerComp.placePosition, Quaternion.identity, buildingParent.transform);
            tower.GetComponent<WCTower>().SetTowerType("ArcherTower");

            WCSoundManager sm = FindObjectOfType<WCSoundManager>();
            sm.PlaySound("ArcherTowerPlaceSound");
            sm.PlaySound("TowerBuildSound");
        }
    }

    private void PlaceCannonTower()
    {
        if (isBuilding && Input.GetMouseButtonDown(0) && isCannonTower && isCanPlace)
        {
            TowerPayment(cannonTowerGoldCost, cannonTowerDiamondCost, 0);
            GameObject tower = Instantiate(cannonTowerPrefab, ghostTowerComp.placePosition, Quaternion.identity, buildingParent.transform);
            tower.GetComponent<WCTower>().SetTowerType("CannonTower");

            WCSoundManager sm = FindObjectOfType<WCSoundManager>();
            sm.PlaySound("CannonTowerPlaceSound");
            sm.PlaySound("TowerBuildSound");
        }
    }

    private void PlaceDebuffTower()
    {
        if (isBuilding && Input.GetMouseButtonDown(0) && isDebuffTower && isCanPlace)
        {
            TowerPayment(debuffTowerGoldCost, 0, debuffTowerRedDiamondCost);
            GameObject tower = Instantiate(debuffTowerPrefab, ghostTowerComp.placePosition, Quaternion.identity, buildingParent.transform);

            WCSoundManager sm = FindObjectOfType<WCSoundManager>();
            sm.PlaySound("DebuffTowerPlaceSound");
            sm.PlaySound("TowerBuildSound");
        }
    }

    private void CancelBuildingPlacement()
    {
        isBuilding = false;
        isCannonTower = false;
        isArcherTower = false;
        isDebuffTower = false;

        if (buildingCursor != null)
        {
            buildingCursor.SetActive(false);
            ghostTowerComp = null;
        }

        if (ghostCannonTowerPrefab != null)
        {
            ghostCannonTowerPrefab.SetActive(false);
        }

        if (ghostArcherTowerPrefab != null)
        {
            ghostArcherTowerPrefab.SetActive(false);
        }

        if (ghostDebuffTowerPrefab != null)
        {
            ghostDebuffTowerPrefab.SetActive(false);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void TowerPayment(int goldCost, int diamondCost, int redDiamondCost)
    {
        gold -= goldCost;
        diamond -= diamondCost;
        redDiamond -= redDiamondCost;

        goldText.text = gold.ToString();
        diamondText.text = diamond.ToString();
        redDiamondText.text = redDiamond.ToString();
    }

    public void GainGold(int amount)
    {
        gold += amount;
        goldText.text = gold.ToString();
    }

    public void GainDiamond(int amount)
    {
        diamond += amount;
        diamondText.text = diamond.ToString();
    }

    public void GainRedDiamond(int amount)
    {
        redDiamond += amount;
        redDiamondText.text = redDiamond.ToString();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
