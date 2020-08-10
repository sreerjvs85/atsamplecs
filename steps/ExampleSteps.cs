using System.Reflection;
using atsamplecs.src;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace atsamplecs.steps
{
    [Binding]
    public class ExampleSteps
    {
        private Calculator calculator = new Calculator();
        private int result;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number){
            calculator.FirstNumber = number;
        }

        [Given ("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number){
            calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]

        public void WhenTheTwoNumbersAreAdded(){
            result = calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int number){
            Assert.AreEqual(result, number);
        }

    }
}