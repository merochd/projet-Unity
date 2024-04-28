using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private int _nbBoxes = 9;
    [SerializeField] private List<Item> _prefabBoxes;
    [SerializeField] private List<Collider> _spawnAreas;
    [SerializeField] private HUD _hud;
	[SerializeField] public GameObject timer;
    private Timer targetScript;
    
    
    private List<Item> _items = new List<Item>();
    public string RemaingItemsCount; 
    
    void Start()
    {
        Spawn();
        _hud.SetEnnemiesLabel("00 / 00");
        _hud.HideEndGame();
        targetScript = timer.GetComponent<Timer>();
    }

    void Update()
    {

        if (_items.Count <= 0)
        {
            _hud.ShowEndGame();
            targetScript.StopTimer();
			// si il n'y a plus de boites, on affiche l'HUD de fin de jeu et on arrete le timer
        }
        
        _hud.SetEnnemiesLabel(_items.Count + " / " + _nbBoxes);
        // on met a jour le compteur d'Item
    }

    public void Spawn()
    {
        for (int i = 0; i < _nbBoxes; i++)
        {
            Collider spawnArea = _spawnAreas[Random.Range(0, _spawnAreas.Count)];
			// on choisis un collider au hasard ou faire spawn notre boite
            Vector3 position;
            Vector3 closestPoint;
            do
            {
                position = new Vector3(
                    Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                    0,
                    Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
					// on choisis des coordonés au hasard ou faire spawn la boite
                );

                closestPoint = spawnArea.ClosestPoint(position);

            } while (Vector3.Distance(closestPoint, position) > 0f);
            
            Item instance = Instantiate<Item>(_prefabBoxes[Random.Range(0, _prefabBoxes.Count)], position, Quaternion.identity, this.transform);
            // on cree une boite plasser dans un endroit aléatoir d'un des collider

            instance.IsTouched += ItemTouched;
            _items.Add(instance);
			// on rajoute cette boite dans la liste des Item

        }
        
    }

    public void ItemTouched(Item item)
    {
        if (_items.Contains(item))
        {
            Debug.Log("Item touched");
            _items.Remove(item);
			//on retire la boite touché de la liste (voir item.cs)
        }
    }
    
}
