using System.Collections.ObjectModel;

namespace MAUIExpander
{
    public class RecipeInfoRepository
    {
        #region Constructor

        public RecipeInfoRepository()
        {

        }

        #endregion

        #region Properties

        internal ObservableCollection<ListViewRecipeInfo> GetRecipeInfo()
        {
            var recipeInfo = new ObservableCollection<ListViewRecipeInfo>();
            for (int i = 0; i < RecipeNames.Length; i++)
            {
                var info = new ListViewRecipeInfo()
                {
                    RecipeName = RecipeNames[i],
                    RecipeDescription = RecipeDescriptions[i],
                    RecipeImage = RecipeImages[i],
                    RecipeTime = RecipeTime[i],
                };
                recipeInfo.Add(info);
            }
            return recipeInfo;
        }

        #endregion

        #region RecipeInfo

        readonly string[] RecipeNames = new string[]
        {"Pasta varieties", "Egg varieties", "Pizzas"};
        readonly string[] RecipeImages = new string[]
        {
            "pasta.png",
            "egg.png",
            "pizza.png",
        };
        readonly string[] RecipeDescriptions = new string[]
        {
            "Order pasta varieties such as white sauce, cream cheese, and more…",
            "Taste egg omelets, rolls, rice, curries, gravy, and more…",
            "Order veg and non-veg pizzas such as neapolitan, pepperoni & more…",        
        };

        readonly string[] RecipeTime = new string[]
        {
            "5 min",
            "6 min",
            "3 min",
        };
        #endregion
    }
}
