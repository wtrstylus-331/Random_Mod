using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace rand_mod.Items.Weapons
{
    public class SwitchBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = DamageClass.Melee;
            Item.width = 16;
            Item.height = 16;
            Item.useTime = 15;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe(1);
            recipe1.AddRecipeGroup(RecipeGroupID.Wood, 1);
            recipe1.AddIngredient(ItemID.CopperBar, 1);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddRecipeGroup(RecipeGroupID.Wood, 1);
            recipe2.AddIngredient(ItemID.TinBar, 1);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.Register();
        }
    }
}
