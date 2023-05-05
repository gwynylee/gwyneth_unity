using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfPlayer : BasePlayer
{
    public override void ReceiveCard(int card)
    {
        base.ReceiveCard(card);

        Debug.Log($"Receive:{card % 13 + 1}");
        var game = Game.Instance;
        //var cardObj = Instantiate(game.CardPrefab.transform);
        var cardObj = Instantiate(game.CardPrefab);
        //cardObj.sprite = game.Sprites[card];
        cardObj.GetComponent<SpriteRenderer>().sprite = game.Sprites[card];
        //cardObj.sortingOrder = _drawnCardObjs.Count;
        cardObj.GetComponent<SpriteRenderer>().sortingOrder = _drawnCardObjs.Count;

        _drawnCardObjs.Add(cardObj);

        var interval = 5f / (_drawnCardObjs.Count + 1);
        var xPos = -2.5f;
        foreach (var drawnCardObj in _drawnCardObjs)
        {
            xPos += interval;
            drawnCardObj.transform.localPosition = new Vector3(xPos, -1.5f, 0);
        }
    }
}
