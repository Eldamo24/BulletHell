using UnityEngine;

public class IsOcuppied : MonoBehaviour
{
    public bool isOcuppied;

    private void Start()
    {
        isOcuppied = false;
    }

    public void IsTheSpawnerOcuppied()
    {
        isOcuppied = !isOcuppied;
    }
}
