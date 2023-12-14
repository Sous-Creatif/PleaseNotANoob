using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Id;
    public Sprite Icon;
    public Sprite Rank;
    public Sprite Spe;
    public string Name;
    public string Lvl;

    public GameObject Detail;
    public GameObject ObjectDetail;

    void Start()
    {
        Show_item(Icon);
    }

    public void Show_item(Sprite TmpIcon)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = TmpIcon;
    }

    void OnMouseEnter()
    {
        ObjectDetail = Instantiate(Detail, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 1), Quaternion.identity);
        ItemDetail ODS = ObjectDetail.GetComponent<ItemDetail>();
        ODS.Show_item_detail(Icon, Rank, Spe, Name, Lvl);
    }
    
    void OnMouseExit()
    {
        Destroy(ObjectDetail);
    }

}
