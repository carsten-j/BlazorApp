using BellyBox.Shared;

namespace BellyBox.Client.Services
{
	public class MealListState
	{
		public List<Meal> Meals { get; set; }
		public List<Tag> Tags { get; set; }
		public List<Tag> SelectedTags { get; set; }
	}
}

