
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DBZMOD;
using kiweaponsaddons.Buffs;
using Terraria.Utilities;

namespace kiweaponsaddons.Items
{

    public class infinitybullet : KiItem
    {

        public override void UpdateInventory(Player player)
        {
            if (MyPlayer.ModPlayer(player).IsKiDepleted())
            {
                player.channel = false;
            }
            else
            {
  
                if (player.channel)
                {
                    player.AddBuff(item.buffType, 2);
                }
            }

        }
        public override bool ReforgePrice(ref int reforgePrice, ref bool canApplyDiscount)
        {
            return true;
        }

        public override void SetDefaults()
        {
            item.channel = true;
            item.shoot = ModContent.ProjectileType<Projectiles.kibullet>();
            item.shootSpeed = 20f;
            item.damage = 100;
            item.knockBack = 1f;
            item.useStyle = 5;
            item.UseSound = SoundID.Item12;
            item.useAnimation = 20;
            item.useTime = 9;
            item.width = 5;
            item.noUseGraphic = true;
            item.height = 5;
            item.autoReuse = true;
            item.value = 10500;
            item.rare = 3;
            kiDrain = 100;
            item.buffType = ModContent.BuffType<Buffs.twokidbuff>();

           
        }


        
        public float dkidrain = 0.8f;
        public override int ChoosePrefix(Terraria.Utilities.UnifiedRandom rand)
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            var prefixChooser = new WeightedRandom<int>();
            prefixChooser.Add(DBZMod.PrefixType("BalancedPrefix"), 3); // 3 times as likely
            prefixChooser.Add(DBZMod.PrefixType("CondensedPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("MystifyingPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("UnstablePrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("FlawedPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("BoostedPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("NegatedPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("OutrageousPrefix"), 3);
            prefixChooser.Add(DBZMod.PrefixType("PoweredPrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("FlashyPrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("InfusedPrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("DistractingPrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("DestructivePrefix"), 2);
            prefixChooser.Add(DBZMod.PrefixType("MasteredPrefix"), 1);
            prefixChooser.Add(DBZMod.PrefixType("TranscendedPrefix"), 1);
            int choice = prefixChooser;
            if ((item.damage > 0) && item.maxStack == 1)
            {
                return choice;
            }
            return -1;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It's android 18's");
            DisplayName.SetDefault("Infinity Bullet");



        }
        public override void AddRecipes()
        {
            Mod DBZMod = ModLoader.GetMod("DBZMOD");
            ModRecipe recipe = new ModRecipe(mod);
            if (DBZMod != null)
            {
                recipe.AddTile(DBZMod.TileType("ZTable"));
                recipe.AddIngredient(DBZMod.GetItem("StableKiCrystal"), 100);
            }
            else
            {
                recipe.AddIngredient(ItemID.DirtBlock, 1);
            }
            
           
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
          
            int numberProjectiles = 4 + Main.rand.Next(10); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(50)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }


        // Help, my gun isn't being held at the handle! Adjust these 2 numbers until it looks right.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 0);
        }






    }
}