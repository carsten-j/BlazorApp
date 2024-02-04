using Bunit;
using BellyBox.Client.Services;
using Telerik.JustMock;
using Xunit;
using System;
using BellyBox.Client.Pages;
using Microsoft.Extensions.DependencyInjection;
using AutoFixture.Xunit2;
using BellyBox.Shared;
using BellyBox.Tests.Fakes;
using System.Threading.Tasks;
using FluentAssertions;
using BellyBox.Client.Components;
using System.Linq;

namespace BellyBox.Tests.Pages
{
    public class MealList_Tests : TestContext
    {
        private IBellyBoxDataService _service;

        public MealList_Tests()
        {
            _service = Mock.Create<IBellyBoxDataService>();
            Mock.Arrange(() => _service.GetMeals()).Returns(Task.FromResult(MealViewData.GetFakeMeals(4).ToArray()));
            Mock.Arrange(() => _service.GetTags()).Returns(Task.FromResult(MealViewData.GetFakeTags(1, 5).ToArray()));
            Services.AddSingleton(_service);
            Services.AddScoped<MealsListState>();
        }

        [Fact]
        public void MealList_Data_Tests()
        {
            var cut = RenderComponent<MealsList>();

            var tagsFilter = cut.FindComponent<TagsFilter>();
            tagsFilter.Instance.Tags.Count().Should().Be(5);

            var mealListView = cut.FindComponent<MealListView>();
            mealListView.Instance.Data.Count().Should().Be(4);

            var input = cut.Find(@"input[id=""2""]");
            input.Change(new Microsoft.AspNetCore.Components.ChangeEventArgs());

            mealListView.Instance.Data.Count().Should().Be(4);

            Mock.Assert(() => _service.GetMeals(), Occurs.Once());
            Mock.Assert(() => _service.GetTags(), Occurs.Once());
        }
    }
}
