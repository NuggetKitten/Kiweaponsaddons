using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace kiweaponsaddons
{
    // This file shows the very basics of using ModPlayer classes since ExamplePlayer can be a bit overwhelming.
    // ModPlayer classes provide a way to attach data to Players and act on that data. 
    // This example will hopefully provide you with an understanding of the basic building blocks of how ModPlayer works. 
    // This example will teach the most commonly sought after effect: "How to do X if the player has Y?"
    // X in this example will be "Apply a debuff to enemies."
    // Y in this example will be "Wearing an accessory."
    // After studying this example, you can change X to other effects by changing the "hook" you use or the code within the hook you use. For example, you could use OnHitByNPC and call Projectile.NewProjectile within that hook to change X to "When the player is hit by NPC, spawn Projectiles".
    // We can change Y to other conditions as well. For example, you could give the player the effect by having a "potion" ModItem give a ModBuff that sets the ModPlayer variable in ModBuff.Update
    // Another example would be an armor set effect. Simply use the ModItem.UpdateArmorSet hook 

    // Below you will see the ModPlayer class, and below that will be another class called SimpleAccessory for the accessory both in the same file for your reading convenience. This accessory will give our effect to our ModPlayer. 

    // This is the ModPlayer class. Make note of the classname, which is SimpleModPlayer, since we will be using this in the accessory item below.
    public class DmodPlayer : ModPlayer
    {
        // Here we declare the frostBurnSummon variable which will represent whether this player has the effect or not.
        public bool NikiMlem;

        // ResetEffects is used to reset effects back to their default value. Terraria resets all effects every frame back to defaults so we will follow this design. (You might think to set a variable when an item is equipped and unassign the value when the item in unequipped, but Terraria is not designed that way.)
        public override void ResetEffects()
        {
            NikiMlem = false;
        }

        // Here we use a "hook" to actually let our frostBurnSummon status take effect. This hook is called anytime a player owned projectile hits an enemy. 


        // As a recap. Make a class variable, reset that variable in ResetEffects, and use that variable in the logic of whatever hooks you use.
    }

    // Below is SimpleAccessory, the ModItem that gives the player the frostBurnSummon effect when worn as an accessory.

    // Note that since this namespace is nested within the outer namespace of "ExampleMod", the full namespace is ExampleMod.Items.Armor. This is important because textures are loaded from the namespace and classname. Even though this class is in a .cs file in the root folder of the mod, the namespace decides where to find item and animation textures.

    
}