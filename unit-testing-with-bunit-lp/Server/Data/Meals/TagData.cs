using System.Collections.Generic;

namespace BellyBox.Data
{
    public class TagData
    {
        public TagData()
        {

        }
        public TagData(int id, string text)
        {
            TagId = id;
            Text = text;
        }
        public int TagId { get; set; }
        public string Text { get; set; } = "";
        public ICollection<MealTag> MealTags { get; set; } = null!;
    }

}