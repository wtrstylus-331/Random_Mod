using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace rand_mod.Items.Ammo
{
    public class NTWAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 16;

            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 20f;
            Item.value = Item.sellPrice(0,1,0,0);
            Item.rare = ItemRarityID.Yellow;
            Item.shoot = ProjectileID.BulletHighVelocity;
            Item.crit = 8;

            Item.ammo = Item.type;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(99);

            recipe.AddIngredient(ItemID.EmptyBullet, 99);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 1);
            recipe.AddIngredient(ItemID.CrystalShard, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
