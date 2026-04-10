using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MAUIExpander
{
    public class LinearLayoutViewModel
    {
        #region Fields

        private ObservableCollection<ListViewRecipeInfo>? recipeInfo;

        #endregion

        #region Constructor

        public LinearLayoutViewModel()
        {
            GenerateSource();
			GenerateFoodMenu();
        }

		#endregion

		#region Properties
		public ICommand SelectCommand { get; set; }

		public ObservableCollection<FoodMenuModel> BreakfastMenu { get; set; }

		public ObservableCollection<ListViewRecipeInfo>? RecipeInfo
        {
            get { return recipeInfo; }
            set { this.recipeInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            RecipeInfoRepository recipeinfo = new();
            recipeInfo = recipeinfo.GetRecipeInfo();
        }
        private void GenerateFoodMenu()
		{
			SelectCommand = new Command(Selection);

			BreakfastMenu = new ObservableCollection<FoodMenuModel>();

            for (int i = 0; i < BreakfastMenuList.Length; i++)
            {
                var item = new FoodMenuModel();
                item.FoodName = BreakfastMenuList[i];
                item.IsSelected = false;
                BreakfastMenu.Add(item);
                item = null;
            }
        }
		private void Selection(object item)
		{
			var food = item as FoodMenuModel;
			if (food.IsSelected)
			{
				food.IsSelected = false;
			}
			else
			{
				food.IsSelected = true;
			}
		}
		private string[] BreakfastMenuList = new string[]
        {
			"Chicken and waffles",
			"French toast",
			"Home fries",
			"Buttermilk pancakes",
			"Breakfast wrap",
			"Breakfast sandwich",
        };
		#endregion
	}
}
