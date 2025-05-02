using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CupheadModdingTemplate;

public class VeggiesOnion
{
    public void Init()
    {
        On.VeggiesLevelOnion.Start += Start;
    }

    private void Start(On.VeggiesLevelOnion.orig_Start orig, VeggiesLevelOnion self)
    {
        //Original code
        if (self.properties == null)
        {
            UnityEngine.Object.Destroy(self.gameObject);
            return;
        }
        self.noSecret = true;
        self.circleCollider = self.GetComponent<CircleCollider2D>();
        //Removed from original code to prevent onion from activating secret phase
        //this.state = VeggiesLevelOnion.State.Idle;
        //base.StartCoroutine(this.happyTimer_cr());
        self.state = VeggiesLevelOnion.State.Crying;
        self.animator.SetTrigger("SadStart");
        self.HappyLeave = true;
        self.SfxGround();
    }
}
