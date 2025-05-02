using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CupheadModdingTemplate;

public class VeggiesPotato
{
    public void Init()
    {
        On.VeggiesLevelPotato.Start += Start;
        On.VeggiesLevelPotato.Shoot += Shoot;
    }

    private void Start(On.VeggiesLevelPotato.orig_Start orig, VeggiesLevelPotato self)
    {
        orig(self); //Run all original code
        self.transform.AddPosition(100f, 0f);//new
        //Add position to move potato right
        //I always use "new", "new start" and "new end" to recognize my code among original one
    }

    private void Shoot(On.VeggiesLevelPotato.orig_Shoot orig, VeggiesLevelPotato self)
    {
        //Sotimes you'll just have to copy the whole code.
        //You can find it here: https://github.com/UserNotFoundXEption/OriginalCupheadCode
        if (!self.projectileParryFlag)
        {
            AudioManager.Play("levels_veggies_potato_spit");
        }
        else
        {
            AudioManager.Play("level_veggies_potato_spit_worm");
        }
        self.didShoot = true;
        //Throw out some of original code
        /*BasicProjectile basicProjectile = self.projectilePrefab.Create(self.gunRoot.position, self.gunRoot.eulerAngles.z, self.properties.bulletSpeed);
        basicProjectile.SetParryable(self.projectileParryFlag);
        self.spitEffect.Create(self.gunRoot.position);*/

        //Rewrite it to make it more clear
        Vector2 position = self.gunRoot.position;//new start
        float rotation = self.gunRoot.eulerAngles.z;
        float speed = self.properties.bulletSpeed;
        BasicProjectile projectile1 = self.projectilePrefab.Create(position, rotation, speed);
        //Original projectile is never parryable
        projectile1.SetParryable(false);
        self.spitEffect.Create(position);

        //Spawn another projectile, a bit higher
        Vector2 position2 = position + new Vector2(0f, 150f);
        BasicProjectile projectile2 = self.projectilePrefab.Create(position2, rotation, speed);
        //Second projectile is always parryable
        projectile2.SetParryable(true);
        self.spitEffect.Create(position2);//new end

        //Result - Potato shoots 2 projectiles at once. 
    }
}
