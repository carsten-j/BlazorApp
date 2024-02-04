using System.Collections.Generic;

namespace BellyBox.Shared
{
	public class Box
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public IEnumerable<int> Meals { get; set; }
        public double Price { get; set; } 
    }
}
