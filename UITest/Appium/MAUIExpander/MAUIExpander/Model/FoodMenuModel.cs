using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIExpander
{
	public class FoodMenuModel : INotifyPropertyChanged
	{
		#region Field        

		private string foodName;
		private bool isSelected;

		#endregion

		#region Properties

		public string FoodName
		{
			get
			{
				return foodName;
			}
			set
			{
				foodName = value;
				RaisedOnPropertyChanged("FoodName");
			}
		}

		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				isSelected = value;
				RaisedOnPropertyChanged("IsSelected");
			}
		}

		#endregion

		public FoodMenuModel()
		{

		}

		#region Interface Member

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisedOnPropertyChanged(string _PropertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
			}
		}

		#endregion
	}
}
