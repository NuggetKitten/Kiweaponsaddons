using Terraria;
using Terraria.ModLoader;
using DBZMOD;

namespace kiweaponsaddons.Buffs
{
    public class twokidbuff : ModBuff
    {
        

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ki");
            Description.SetDefault("kek.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex) =>
            player.GetModPlayer<MyPlayer>().AddKi(-1.8f, false, false);
    }
}
