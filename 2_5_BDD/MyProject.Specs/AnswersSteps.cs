using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MyProject.Specs
{


    [Binding]
    public class AnswersSteps
    {
        private readonly QuestionsPage questionspage;

        public AnswersSteps(QuestionsPage questionsPage)
        {
            this.questionspage = questionsPage;
        }


        [Given(@"there is a question with ""(.*)"" with the answers")]
        public void GivenThereIsAQuestionWithWithTheAnswers(string p0, Table table)
        {
            questionspage.Question = p0;
            foreach (var row in table.Rows)
            {
                questionspage.AddVote(row[0], int.Parse(row[1]));
            }

        }

        [When(@"you upvote answer ""(.*)""")]
        public void WhenYouUpvoteAnswer(string p0)
        {
            questionspage.VoteUpAnswer(p0);
        }

        [Then(@"the answer ""(.*)"" should be on top")]
        public void ThenTheAnswerShouldBeOnTop(string p0)
        {
            Assert.AreEqual(p0, questionspage.TopAnswer);
        }

        [Given(@"there is no questions")]
        public void GivenThereIsNoQuestions()
        {
            questionspage.Question = null;
        }

        [Then(@"an exception should be thrown")]
        public void ThenAnExceptionShouldBeThrown()
        {
            Assert.AreEqual("", questionspage.TopAnswer);
        }

    }
}
