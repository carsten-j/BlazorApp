using BellyBox.Shared;

namespace BellyBox.Client.Services
{
	public class MealsListState
	{
		public Meal[] Meals { get; set; } = Array.Empty<Meal>();
		public Tag[] Tags { get; set; } = Array.Empty<Tag>();
		public List<Tag> SelectedTags { get; set; } = new();
	}
}
