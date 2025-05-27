using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBomb : BombAction
{
    public Coroutine portal;
    public bool isFirst;
    
    private void Install()
    {
        if (isFirst)
        {
            StartFirstPortal();
            
        }
        else
        {
            int count = 0;
            int first = 0;
            var bombs = FindObjectsOfType<PortalBomb>();

            for (int i = 0; i < bombs.Length; i++)
            {
                if (bombs[i]._data.bombType == BombType.Portal)
                {
                    count++;
                    
                    if (count == 1)
                    {
                        Debug.Log("첫번째 찾았다");
                        first = i;
                    }
                }
            }
            
            bombs[first].StopFirstPortal();
        }
    }
    
    
    private IEnumerator FirstPortal()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
    
    public void StartFirstPortal()
    {
        portal = StartCoroutine(FirstPortal());
    }

    public void StopFirstPortal()
    {
        if (portal != null)
        {
            StopCoroutine(portal);
            portal = null;
        }
    }
}
