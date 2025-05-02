using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CupheadModdingTemplate;

public class Properties
{
    public void Init()
    {
        On.LevelProperties.Veggies.GetMode += VeggiesGetMode;
    }

    //Yeah, this thing is always pretty big. Let's mod standard difficulty
    public static LevelProperties.Veggies VeggiesGetMode(On.LevelProperties.Veggies.orig_GetMode orig, Level.Mode mode)
    {
        int hp = 0;
        Level.GoalTimes goalTimes = null;
        List<LevelProperties.Veggies.State> list = new List<LevelProperties.Veggies.State>();
        if (mode != Level.Mode.Easy)
        {
            if (mode != Level.Mode.Normal)
            {
                if (mode == Level.Mode.Hard)
                {
                    //Properties for expert difficulty
                    hp = 100;
                    goalTimes = new Level.GoalTimes(120f, 120f, 120f);
                    list.Add(new LevelProperties.Veggies.State(10f, new LevelProperties.Veggies.Pattern[][]
                    {
                            new LevelProperties.Veggies.Pattern[0]
                    }, LevelProperties.Veggies.States.Main, new LevelProperties.Veggies.Potato(400, 2.5f, 3, 1f, 4, new MinMax(0.1f, 0.4f), -1000f), new LevelProperties.Veggies.Onion(425, 6f, new MinMax(38f, 38f), new string[]
                    {
                            "280,500,330,630,280,400,350,550,280,630,300",
                            "630,280,400,500,320,450,280,630,505,330,630",
                            "280,630,350,550,405,460,280,635,535,280,600",
                            "330,480,630,280,520,630,280,350,450,280,570",
                            "450,630,350,280,400,560,460,325,630,280,420",
                            "630,450,280,330,550,415,630,580,280,500,330",
                            "330,280,505,630,450,630,280,580,330,400,550"
                    }, 0.1f, 0.005f, 0.9f, new MinMax(5f, 7f), 775f, 915f, 2f, 260), new LevelProperties.Veggies.Beet(0, 0f, new string[0], 0f, 0, 0f, 0f, 0f, new MinMax(0f, 1f)), new LevelProperties.Veggies.Peas(0), new LevelProperties.Veggies.Carrot(475, 1.5f, new MinMax(5f, 6f), 2, 1.5f, 850f, 1f, 260f, 2.3f, 4, 0.8f, new MinMax(0f, 0f), 550f, new MinMax(5f, 7f))));
                }
            }
            else
            {
                //Properties for standard difficulty
                //I always rewrite original code like this to make it more clear
                hp = 1000;
                goalTimes = new Level.GoalTimes(120f, 120f, 120f);

                int potatoHp = 360;
                float potatoIdleTime = 3f;
                int potatoSeriesCount = 3;
                float potatoSeriesDelay = 1f;
                int potatoBulletCount = 4;
                MinMax potatoBulletDelay = new MinMax(0.2f, 0.6f);
                float potatoBulletSpeed = -700f;

                int onionHp = 400;
                float onionHappyTime = 6f;
                MinMax onionCryLoops = new MinMax(38f, 38f);
                string[] onionTearPatterns = new string[]
                {
                        "280,630,400,500,335,450,280,635,535,280,525",
                        "450,280,350,630,280,560,460,335,630,510,360",
                        "630,280,470,550,320,400,280,630,505,360,280",
                        "450,550,350,630,280,400,300,500,280,630,315",
                        "330,630,415,280,520,630,280,450,500,280,570",
                        "450,630,400,280,330,570,450,350,280,630,500",
                        "630,400,280,550,630,350,280,450,500,280,400"
                };
                float onionTearAnticipate = 0.2f;
                //Let's just give the onion more tears and shorter falling time
                float onionTearCommaDelay = 0.05f;//0.2f
                float onionTearTime = 0.7f;//1.1
                // ^ It means "originally it was 1.1 but I changed it to 0.7"
                MinMax onionPinkTearRange = new MinMax(4f, 6f);
                //Sometimes properties have unused stuff
                float onionHeartMaxSpeed = 750f;
                float onionHeartAcceleration = 850f;
                float onionHeartBounceRatio = 2.5f;
                int onionHeartHP = 230;

                int carrotHp = 475;
                float carrotStartIdleTime = 0f;
                MinMax carrotIdleRange = new MinMax(6.8f, 8f);
                int carrotBulletCount = 3;
                float carrotBulletDelay = 1.5f;
                float carrotBulletSpeed = 800f;
                float carrotHomingInitDelay = 1f;
                float carrotHomingSpeed = 250f;
                float carrotHomingRotation = 2.3f;
                int carrotHomingHP = 4;
                float carrotHomingDelay = 1.2f;
                MinMax carrotHomingDuration = new MinMax(0f, 0f);
                float carrotHomingBgSpeed = 550f;
                MinMax carrotHomingNumOfCarrots = new MinMax(4f, 6f);

                LevelProperties.Veggies.Potato potato = new(potatoHp, potatoIdleTime, potatoSeriesCount, potatoSeriesDelay, potatoBulletCount, potatoBulletDelay, potatoBulletSpeed);
                LevelProperties.Veggies.Onion onion = new(onionHp, onionHappyTime, onionCryLoops, onionTearPatterns, onionTearAnticipate, onionTearCommaDelay, onionTearTime, onionPinkTearRange, onionHeartMaxSpeed, onionHeartAcceleration, onionHeartBounceRatio, onionHeartHP);
                //We won't use these 2 anyway
                LevelProperties.Veggies.Beet beet = new(0, 0f, [], 0f, 0, 0f, 0f, 0f, new MinMax(0f, 0f));
                LevelProperties.Veggies.Peas pees = new(0);
                LevelProperties.Veggies.Carrot carrot = new(carrotHp, carrotStartIdleTime, carrotIdleRange, carrotBulletCount, carrotBulletDelay, carrotBulletSpeed, carrotHomingInitDelay, carrotHomingSpeed, carrotHomingRotation, carrotHomingHP, carrotHomingDelay, carrotHomingDuration, carrotHomingBgSpeed, carrotHomingNumOfCarrots);

                //Each list.Add is a new phase.
                //In most cases you'd phase 1 properties in all other phases and vice versa.
                //Welcome to Studio MDHR writing a great code.
                list.Add(new LevelProperties.Veggies.State(10f, new LevelProperties.Veggies.Pattern[][]
                {
                        new LevelProperties.Veggies.Pattern[]
                        {
                            LevelProperties.Veggies.Pattern.Potato,
                            LevelProperties.Veggies.Pattern.Onion,
                            LevelProperties.Veggies.Pattern.Carrot
                        }
                }, LevelProperties.Veggies.States.Main,
                potato, onion, beet, pees, carrot));
            }
        }
        else
        {
            //Properties for simple difficulty
            hp = 100;
            goalTimes = new Level.GoalTimes(120f, 120f, 120f);
            list.Add(new LevelProperties.Veggies.State(10f, new LevelProperties.Veggies.Pattern[][]
            {
                    new LevelProperties.Veggies.Pattern[0]
            }, LevelProperties.Veggies.States.Main, new LevelProperties.Veggies.Potato(450, 3f, 3, 1.2f, 3, new MinMax(0.4f, 0.7f), -600f), new LevelProperties.Veggies.Onion(0, 0f, new MinMax(0f, 1f), new string[0], 0f, 0f, 0f, new MinMax(0f, 1f), 0f, 0f, 0f, 0), new LevelProperties.Veggies.Beet(0, 0f, new string[0], 0f, 0, 0f, 0f, 0f, new MinMax(0f, 1f)), new LevelProperties.Veggies.Peas(0), new LevelProperties.Veggies.Carrot(450, 0f, new MinMax(6f, 7f), 2, 2f, 700f, 1f, 200f, 2.2f, 4, 1.5f, new MinMax(0f, 0f), 550f, new MinMax(3f, 5f))));
        }
        return new LevelProperties.Veggies(hp, goalTimes, list.ToArray());
    }
}
