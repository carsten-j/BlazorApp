using Bunit;
using BellyBox.Client.Services;
using Telerik.JustMock;
using Xunit;
using System;
using BellyBox.Client.Pages;
using Microsoft.Extensions.DependencyInjection;
using AutoFixture.Xunit2;
using BellyBox.Shared;

namespace BellyBox.Tests.Pages
{
    public class MealDetail_Tests : TestContext
    {
        private IBellyBoxDataService _service;

        public MealDetail_Tests()
        {
            _service = Mock.Create<IBellyBoxDataService>();
            Services.AddSingleton(_service);
        }

        [Fact]  
        public void MealDetail__NotFound_Test()
        {
            Mock.Arrange(() => _service.GetMealById(Arg.AnyInt)).Throws<Exception>();

            var cut = RenderComponent<MealDetail>(par => par.Add(p => p.Id, 777));

            cut.MarkupMatches(@"<div >
                              <div class=""danger"" >
                                <p >The product you're looking for could not be retreived.</p>
                              </div>
                            </div>");
        }

        [Theory, AutoData]
        public void MealDetail_Test(System.Threading.Tasks.Task<Meal> meal)
        {
            Mock.Arrange(() => _service.GetMealById(Arg.AnyInt)).Returns(meal);

            var m = meal.Result;

            var cut = RenderComponent<MealDetail>(par => par.Add(p => p.Id, 777));

            cut.MarkupMatches($@"<div >
  <article >
    <img src=""{m.ImageUrl}"" >
    <div >
      <h2 >{m.Name}</h2>
      <p class=""description"" >{m.Description}</p>
      <h2 >Ingredients</h2>
      <ul diff:ignoreChildren>
      </ul>
      <h3 >Nutrition per serving</h3>
      <p class=""calories"" diff:ignoreChildren>
      </p>
      <p class=""servings"" diff:ignoreChildren>
      </p>
      <h4 >Sensitivities</h4>
      <div class=""sensitivities"" diff:ignoreChildren>
      </div>
    </div>
  </article>
</div>");
        }
    }
}
