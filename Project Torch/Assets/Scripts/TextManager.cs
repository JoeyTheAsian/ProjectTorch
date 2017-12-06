﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script exists for the sole purpose of holding the game's dialogue lines
/// </summary>
public class TextManager : MonoBehaviour {

    #region Enums
    public enum InteractiveNPCNames
    {
        NONE,
        KingOfMan,
        KingOfDark,
        CaptainOfTheGuard,
        Altar,
        BattlefieldGrave1,
        ST1Grave1,
        ST1Grave2,
        ST2Grave1,
        HT1Grave1,
        HT1Grave2,
        HT2Grave1,
        HT2Grave2,
        TH1Grave1,
        TH1Grave2,
        WZ1Grave1,
        WZ2Grave1,
        WZ2Grave2,
        ST1Human1,
        ST2Shadow1,
        HT1Human1,
        HT1Human2,
        HT2Human1,
        TH1Human1,
        TH1Human2,
        WZ1Shadow1,
        WZ1Human1,
    }
    #endregion

    #region Private Fields
    // A huge batch of every set of dialogue lines in the game
    private Dictionary<string, string[]> lines;
    // Array of NPCs that can be interacted with
    private Entity[] interactiveNPCs;
#endregion

    #region Properties
    public Dictionary<string, string[]> Lines { get { return lines; } }
    public Entity[] InteractiveNPCs { get { return interactiveNPCs; } }
    #endregion

    #region Unity Defaults
    void Awake () {
        //Grab all entities in the scene
        Entity[] entities = GameObject.FindObjectsOfType(typeof(Entity)) as Entity[];
        //Keep hold of ones that are interactive
        int numInteractiveNPCs = 0;
        List<Entity> entitiesToKeep = new List<Entity>();
        for (int i = 0; i < entities.Length; ++i)
        {
            if (entities[i].npcID != InteractiveNPCNames.NONE) 
            {
                ++numInteractiveNPCs;
                entitiesToKeep.Add(entities[i]);
            }
        }
        interactiveNPCs = new Entity[numInteractiveNPCs];
        for (int i = 0; i < numInteractiveNPCs; ++i)
            interactiveNPCs[i] = entitiesToKeep[i];

        //Instantiate the lines dictionary
        lines = new Dictionary<string, string[]>();
        //Here we will add all possible lines of dialogue in the game to the dictionary

        //The first lines the Altar says
        lines.Add("Altar - Default",
            new string[]
            {
                "Altar:\nThe cold stone calls back to a time buried in death.",
                "Altar:\nThe time of your birth, when fire devoured fire."
            });

        //The basic lines the King will say to you with no other triggers
        lines.Add("King of Man - Default",
            new string[]
            {
                "King of Man:\nGood traveler, I know not of your origin, be it the Serpent’s Earth or Dragon’s sky, but I beg of you to aid us in our time of need.",
                "King of Man:\nAid us as we repel the invaders from the shadows so that we may retake our place in this world!",
                "King of Man:\nTheir King’s fortress lies to the west.",
                "King of Man:\nLead the charge as I fulfill the last wish of the Serpents."
            });

        //The lines the King of the Dark says when he's at his last 15% of health and can't move
        lines.Add("King of the Dark - Downed",
            new string[]
            {
                "King of the Dark:\nGive her back… You monsters.",
                "King of the Dark:\nMy daughter is more than a means to your ends.",
                "King of the Dark:\nShe is more than your kindling.",
                "King of the Dark:\nPlease... Do not let your King murder my daughter..."
            });

        //The Captain of the Guard's text when he meets the player in the village after they've protected it
        lines.Add("Captain of the Gaurd - Village",
            new string[]
            {
                "Captain of the Gaurd:\nWell met stranger.",
                "Captain of the Gaurd:\nWe’ve heard word of a foreign warrior defending this village against the oncoming hoards.",
                "Captain of the Gaurd:\nGather your strength friend, for today we retake our birthright.",
                "Captain of the Gaurd:\nWe will seize the opportunity you’ve opened here and charge into the heart of the enemy!"
            });

        //The Captain of the Guard's text when he reaches the Sentinels
        lines.Add("Captain of the Gaurd - Sentinels",
            new string[]
            {
                "Captain of the Gaurd:\nThe strength of man shall not falter here.",
                "Captain of the Gaurd:\nWhile we can force the way open, their reinforcements shall not sit idly.",
                "Captain of the Gaurd:\nWhen the gate opens, you, the strongest of us all, should bring a close to this war.",
                "Captain of the Gaurd:\nWe will hold the line here as you battle their King.",
                "Captain of the Gaurd:\nHerald us all to the Serpents’ Promised Flame!"
            });
        //TEMP - The dude escorting the princess
        lines.Add("Princess Escort - Enter",
            new string[]
            {
                "Captain Guard:\nMake haste men, for the path to our birthright lies ahead.",
                "Captain Guard:\nSlay any who come near, we cannot afford to lose their princess now."
            });
        //TEMP - The princess when she's saved
        lines.Add("Princess - Saved",
            new string[]
            {
                "Princess:\nI thank you stranger",
                "Princess:\nFrom within you, I sense you are like me.",
                "Princess:\nThe flames we bear and the duties we carry are burdensome all the same.",
                "Princess:\nThough grateful I am, I must return to my father's side.",
                "Princess:\nFarewell and luck to your journey!"
            });
        //Battlefield Brazier
        lines.Add("Brazier - Battlefield",
            new string[]
            {
                "Brazier:\nThe path ahead. Illuminated by dragon’s fire,",
                "Brazier:\ncradled in a serpent’s pyre. How rare."
            });
        //HumanTerritoryStage1 Brazier
        lines.Add("Brazier - HumanTerritoryStage1",
            new string[]
            {
                "Brazier:\nLeft behind to wallow in the waters, the serpents gazed at the sky.",
                "Brazier:\nLooking on as the Dragons forged their domain: The Sky."
            });
        //HumanTerritoryStage2 Brazier
        lines.Add("Brazier - HumanTerritoryStage2",
            new string[]
            {
                "Brazier:\nEver watching, the World Serpent lay in wait.",
                "Brazier:\nA day came where a dragon drew near to the world below.",
                "Brazier:\nAnd he was devoured by the World Serpent.",
                "Brazier:\nThe first murder."
            });
        //ShadowTerritoryStage1 Brazier
        lines.Add("Brazier - ShadowTerritoryStage1",
            new string[]
            {
                "Brazier:\nIn the beginning, where the depths housed the world, there were only two kinds to speak of.",
                "Brazier:\nThose with wings; those without. Dragons and serpents."
            });
        //WarZone Brazier
        lines.Add("Brazier - WarZone",
            new string[]
            {
                "Brazier:\nBorn from nothing, the soul of a dragon took the shape of man.",
                "Brazier:\nIn disgust, it was cast out in a Dragon's Exile.",
                "Brazier:\nAn impossible creature, tasked with an impossibility."
            });
        //WarZoneStage2 Brazier
        lines.Add("Brazier - WarZoneStage2",
            new string[]
            {
                "Brazier:\nA title, bestowed only upon those exiled from the Sky, is a brand of binding duty.",
                "Brazier:\nTo wear this mark of shame, one eternally seeks to carry out their sacred task.",
                "Brazier:\nWoe to the bearer of the dragons’ last title, cursed to wander unabsolved by those long dead,",
                "Brazier:\nThe Adjudicator."
            });
        //TrueHumanStage1 Brazier
        lines.Add("Brazier - TrueHumanStage1",
            new string[]
            {
                "Brazier:\nThe Dragons descended, burning the World Serpent to ash.",
                "Brazier:\nBegot from fire, born from ash,",
                "Brazier:\nhumanity emerged from the embers of the True Flame."
            });
        //No Torch Brazier
        lines.Add("Brazier - NoTorch",
            new string[]
            {
                "Brazier:\nAs the embers shed from your withered torch, you feel lighter,",
                "Brazier:\nyet dazed; confused.",
                "Brazier:\nA gnawing pit can be felt in the depths of your stomach.",
                "Brazier:\nYou have lost a part of yourself this day."
            });
        //Battlefield Grave1
        lines.Add("BattlefieldGrave1 - Default",
            new string[]
            {
                "Unmarked Grave:\nThe first age, ruled by the Divine Beasts, the known world was forged atop the ocean depths.",
                "Unmarked Grave:\nIn the second age, man inherited the world.",
                "Unmarked Grave:\nIn the third age came the vengeful Shadow."
            });
        //ShadowTerritoryStage1 Grave1
        lines.Add("ST1Grave1 - Default",
            new string[]
            {
                "Makeshift Grave:\nThe cry of a princess, drowned by the will of man.",
                "Makeshift Grave:\nTheir King’s decree and prophet’s suggestion, so is the power in words.",
                "Makeshift Grave:\nWords which weigh heavier than my life."
            });
        //ShadowTerritoryStage1 Grave2
        lines.Add("ST1Grave2 - Default",
            new string[]
            {
                "Makeshift Grave:\nWhen the plague spread over us, it took with it our pride.",
                "Makeshift Grave:\nThe pride of man was broken.",
                "Makeshift Grave:\nPerhaps, it is the great serpents calling for us to join them in death?"
            });
        //ShadowTerritoryStage2 Grave1
        lines.Add("ST2Grave1 - Default",
            new string[]
            {
                "Makeshift Grave:\nIt seeped from below the ground, a creeping death.",
                "Makeshift Grave:\nThe plague reduced our loved ones and prosperous land to a mere memory."
            });
        //HumanTerritoryStage1 Grave1
        lines.Add("HT1Grave1 - Default",
            new string[]
            {
                "Makeshift Grave:\nAs our Queen lay buried with her son, the King’s once fiery spirit drowned in mournful tears.",
                "Makeshift Grave:\nThat is when the Prophet came."
            });
        //HumanTerritoryStage1 Grave2
        lines.Add("HT1Grave2 - Default",
            new string[]
            {
                "Makeshift Grave:\nA tear, an ocean, a vessel for the emotions that bind us to this world.",
                "Makeshift Grave:\nThe Prophet’s whispers brought with them a solace to the King.",
                "Makeshift Grave:\nIt brought a way forward to a new future, a way out from the crumbling world of man."
            });
        //HumanTerritoryStage2 Grave1
        lines.Add("HT2Grave1 - Default",
            new string[]
            {
                "Makeshift Grave:\nThe Shadow, those who lived receded from our gaze, bore no dead from the plague.",
                "Makeshift Grave:\nThey stood strong and unconcerned with the plight of the dying."
            });
        //HumanTerritoryStage2 Grave2
        lines.Add("HT2Grave2 - Default",
            new string[]
            {
                "Makeshift Grave:\nThe Princess of the Shadow held within her a flame.",
                "Makeshift Grave:\nA true flame, one unclaimed and untainted.",
                "Makeshift Grave:\nTo reclaim our right to the world, we would take this flame."
            });
        //TrueHumanStage1 Grave1
        lines.Add("TH1Grave1 - Default",
            new string[]
            {
                "Unmarked Grave:\nThe Serpents blessed us with their knowledge, gathered in their observance of the Dragon’s flame,",
                "Unmarked Grave:\nthe True Flame: the Sun.",
                "Unmarked Grave:\nFrom this, we birthed the False Flame and from that, we forged the world below the Sky."
            });
        //TrueHumanStage1 Grave2
        lines.Add("TH1Grave2 - Default",
            new string[]
            {
                "Unmarked Grave:\nTo merely look upon the Dragon’s Domain proved not enough and the Serpent’s asked of man to champion their cause.",
                "Unmarked Grave:\nThey asked of us to construct towers to bridge Earth and Sky itself."
            });
        //WarZoneStage1 Grave1
        lines.Add("WZ1Grave1 - Default",
            new string[]
            {
                "Unmarked Grave:\nWar descended upon the world as it writhed under the slaughter of Dragon and Serpent.",
                "Unmarked Grave:\nIt seemed the Serpents at last would have the True Flame.",
                "Unmarked Grave:\nFraught with fear, the Dragons devoured the Sun to bear the Flame within themselves."
            });
        //WarZoneStage2 Grave1
        lines.Add("WZ2Grave1 - Default",
            new string[]
            {
                "Unmarked Grave:\nAs Serpent ash fell from the Sky, man rose to complete their duty.",
                "Unmarked Grave:\nKindling the False Flame under ancient corpses, they set ablaze the once proud Dragons.",
                "Unmarked Grave:\nBy war’s end, only man was left to inherit the world."
            });
        //WarZoneStage2 Grave2
        lines.Add("WZ2Grave2 - Default",
            new string[]
            {
                "Unmarked Grave:\nWith the Dragon ash left behind by the False Flame,",
                "Unmarked Grave:\nthe world’s balance, thrown off by murder and death, sought to correct itself as it breathed new life.",
                "Unmarked Grave:\nAs the True Flame faded, darkness befell the ashes and from them grew out The Shadow itself."
            });
        //ShadowTerritoryStage1 Dialogue1
        lines.Add("ST1Human1 - Default",
            new string[]
            {
                "Human:\nOutsider, you have come at a grave time.",
                "Human:\nOur war with The Shadow is on the verge of reaching its bloody end.",
                "Human:\nNot all are as kind as I am. There will be those who will tear you apart without a word.",
                "Human:\nIf you are not here to aid us, then it's best you leave and quickly."
            });
        //ShadowTerritoryStage2 Dialogue1
        lines.Add("ST2Shadow1 - Default",
            new string[]
            {
                "Shadow:\nListen Outsider and listen well, the humans have wronged us.",
                "Shadow:\nThey have taken our princess and spilt our blood upon our own land.",
                "Shadow:\nForge ahead with our plight in mind and heed this last warning:",
                "Shadow:\nBe wary of what lies ahead, the Fortress Guards slay all who come near."
            });
        //HumanTerritoryStage1 Dialogue1
        lines.Add("HT1Human1 - Default",
            new string[]
            {
                "Human:\nWe’ve lost my family, my friends and my future.",
                "Human:\nThe plague took much from us.",
                "Human:\nWe were lost, drowning in grief, yearning for a tomorrow.",
                "Human:\nWe have found that tomorrow, Stranger, we must now merely fight for it."
            });
        //HumanTerritoryStage1 Dialogue2
        lines.Add("HT1Human2 - Default",
            new string[]
            {
                "Human:\nTheir princess holds within her a great, slumbering power.",
                "Human:\nIn our hands, we can rebuild our world and reforge what we have lost.",
                "Human:\nI implore you Wanderer, do not think ill of us, for we war to better the lives of our people."
            });
        //HumanTerritoryStage2 Dialogue1
        lines.Add("HT2Human1 - Default",
            new string[]
            {
                "Human:\nWell, look at that, a traveler.",
                "Human:\nTake some advice and ready your sword. The Castle Guards up ahead give no quarter.",
                "Human:\nWhen your eyes meet their own, they will be upon you.",
                "Human:\nI’ll be over here, enjoying the view.",
                "Human:\nDie tastefully now."
            });
        //TrueHumanStage1 Dialogue1
        lines.Add("TH1Human1 - Default",
            new string[]
            {
                "Human:\nThis land, this world, is our birthright.",
                "Human:\nFrom the sacrifice of the Serpents and the downfall of the Dragons, we earned our place.",
                "Human:\nWe will not stand idly by, watching ourselves waste away!"
            });
        //TrueHumanStage1 Dialogue2
        lines.Add("TH1Human2 - Default",
            new string[]
            {
                "Human:\nThe princess must die for us to live.",
                "Human:\nOnce we harness the reincarnation of the True Flame, we will reign forever.",
                "Human:\nNot since the Dragons discovered and devoured the Sun have we seen the True Flame and yet it lies within her.",
                "Human:\nThe Serpent's ancient ambition will be fulfilled through us!"
            });
        //WarZoneStage1 Dialogue1
        lines.Add("WZ1Shadow1 - Default",
            new string[]
            {
                "Shadow:\nThey are irredeemable!",
                "Shadow:\nHumanity must be purged from this world to prevent these atrocities from ever occurring again!",
                "Shadow:\nThey care nothing of our people, of the world.",
                "Shadow:\nThey would sooner sacrifice it all than be humbled!"
            });
        //WarZoneStage1 Dialogue2
        lines.Add("WZ1Human1 - Default",
            new string[]
            {
                "Human:\nOur cause is noble!",
                "Human:\nOur people died in droves and thousands starve, lost in purpose or lie dead in the many graves.",
                "Human:\nWe will, with all our might, push on to create a brighter future for our people!"
            });
        //King of Man's Final Speech
        lines.Add("King of Man - Default",
            new string[]
            {
                "King of Man:\nWanderer, this was not your fight.",
                "King of Man:\nIt saddens me to see to your death. Squandering your life for a war you do not understand.",
                "King of Man:\nDo not resent me for fighting for me people. A King's duty is to light the way forward!",
                "King of Man:\nI truly hope, in death, where you sleep with the Serpents, you will know peace."
            });
        //King of the Dark's Final Speech
        lines.Add("King of the Dark - Default",
            new string[]
            {
                "King of the Dark:\nYou’re all the same! So keen to fight for a cause that you leave unquestioned!",
                "King of the Dark:\nYou will be as your morals are: Dead and forgotten.",
                "King of the Dark:\nI would rip apart the Serpent's Earth and the Dragon's Sky before I would let her be sacrificed!",
                "King of the Dark:\nMy daughter is more than your kindling, yet you refuse to understand.",
                "King of the Dark:\nSo die you wretch!"
            });
    }
#endregion
}
