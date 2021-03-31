using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using DBZMOD;
using System;

namespace kiweaponsaddons.Items
{
    public class SpiritualEnergy : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The purest form of ki. You have 2x your weapons damage as armor penetration, your ki attacks charge 40% faster.");
            DisplayName.SetDefault("True Ki");
        }
        
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = 140000;
            item.rare = 5;
            item.accessory = true;
            item.defense = 0;
        }
        
        public int weaponpenetration;
        public float weaponpenetration2;
        public int weaponpenetration3;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {

                weaponpenetration = player.HeldItem.damage;
                weaponpenetration2 = MyPlayer.ModPlayer(player).kiDamage + 1;
                weaponpenetration2 = weaponpenetration * weaponpenetration2;
                weaponpenetration3 = (int)weaponpenetration2;
                weaponpenetration3 = weaponpenetration3 / 5;
                    player.armorPenetration += weaponpenetration3;
                MyPlayer.ModPlayer(player).kiSpeedAddition += 0.4f;
                   
                
            }
        }


        public override void AddRecipes()
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            ModRecipe recipe = new ModRecipe(mod);


            if (DBZMod != null)
            { 
                recipe.AddIngredient(DBZMod.GetItem("PureKiCrystal"), 10);
           
            recipe.AddTile(DBZMod.TileType("ZTable"));
        }
            else
            {
                recipe.AddIngredient(ItemID.DirtBlock, 1);
            }
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}