using AutoMapper;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Data.Interfaces;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mera.Quiz.Domain.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<TestModel> CreateTestAsync(TestModel testModel)
        {
            var newTestEntity = _mapper.Map<TestModel, Test>(testModel);
            var createdTestEntity = await _testRepository.CreateTestAsync(newTestEntity);

            var createdTestModel = _mapper.Map<Test, TestModel>(createdTestEntity);
            return createdTestModel;
        }
		

		public async Task<int> CreateTestScoreAsync(TestScoreModel testScoreModel)
        {
            var newTestScoreEntity = _mapper.Map<TestScoreModel, TestScore>(testScoreModel);
            var createdTestScoreEntity = await _testRepository.CreateTestScoreAsync(newTestScoreEntity);

            return createdTestScoreEntity.ID;
        }

        public async Task<bool> DeleteTestAsync(int testId)
        {
            bool isDeleted = await _testRepository.DeleteTestAsync(testId);
            return isDeleted;
        }

		public async Task<MemoryStream> DownloadTestScore(int testScoreId)
		{
			var testScoreEntity = await _testRepository.GetFullTestScoreAsync(testScoreId);
			var testScore = _mapper.Map<TestScore, TestScoreModel>(testScoreEntity);
			// Create a new PDF document
			PdfDocument document = new PdfDocument();
			document.Info.Title = "Test Result - " + testScore.Test.TestName;

			// Add a new page to the document
			PdfPage page = document.AddPage();
			XGraphics gfx = XGraphics.FromPdfPage(page);
			XFont testFont = new XFont("Arial", 20, XFontStyle.Regular);
			XFont questionFont = new XFont("Arial", 16, XFontStyle.Regular);
			XFont answerFont = new XFont("Arial", 12, XFontStyle.Regular);
			XFont correctAnswerFont = new XFont("Arial", 12, XFontStyle.Bold);

			var testName = testScore.Test.TestName;
			var userName = testScore.User.UserName;
			// Title
			gfx.DrawString("Test Result - " + testName, testFont, XBrushes.Black,
				new XRect(0, 40, page.Width, page.Height), XStringFormats.TopCenter);

			// Student Name
			gfx.DrawString("User Name: " + userName, testFont, XBrushes.Black,
				new XRect(50, 70, page.Width - 100, page.Height), XStringFormats.TopLeft);

			// Questions and Answers
			int yOffset = 100;

			for (int q = 0; q < testScore.UserAnswers.Count; q++)
			{
				var userAnswer = testScore.UserAnswers[q];
				var question = userAnswer.Question;
				var chosenAnswer = userAnswer.ChosenAnswer;

				int remainingSpace = (int)(page.Height.Point - yOffset);
				int questionLines = (int)gfx.MeasureString(question.QuestionText, questionFont).Height;
				int answerLines = (int)gfx.MeasureString(question.AnswerList.First().AnswerText, answerFont).Height * question.AnswerList.Count;

				if (questionLines + answerLines > remainingSpace)
				{
					// Add a new page if the question and answer cannot fit on the current page
					page = document.AddPage();
					gfx = XGraphics.FromPdfPage(page);
					yOffset = 40; // Reset the y-offset for the new page

					// Title (same for each page)
					gfx.DrawString("Test Result - " + testName, testFont, XBrushes.Black,
						new XRect(0, 40, page.Width, page.Height), XStringFormats.TopCenter);

					// Student Name (same for each page)
					gfx.DrawString("Student Name: " + userName, testFont, XBrushes.Black,
						new XRect(50, 70, page.Width - 100, page.Height), XStringFormats.TopLeft);
				}
				gfx.DrawString((q + 1) + ". " + question.QuestionText, questionFont, XBrushes.Black,
						new XRect(50, yOffset, page.Width - 100, page.Height), XStringFormats.TopLeft);
				yOffset += questionLines;


				for (int a = 0; a < question.AnswerList.Count; a++)
				{
					var answer = question.AnswerList[a];
					answerLines = (int)gfx.MeasureString(answer.AnswerText, answerFont).Height * question.AnswerList.Count;

					if (question.CorrectAnswer.AnswerText == answer.AnswerText)
					{
						var answerDisplayText = $"{a + 1}. {answer.AnswerText} - (Correct) ";
						if (answer.AnswerText == chosenAnswer.AnswerText)
						{
							gfx.DrawString(answerDisplayText, correctAnswerFont, XBrushes.Green,
							new XRect(60, yOffset, page.Width - 100, page.Height), XStringFormats.TopLeft);
						}
						else
						{
							gfx.DrawString(answerDisplayText, answerFont, XBrushes.Green,
							new XRect(60, yOffset, page.Width - 100, page.Height), XStringFormats.TopLeft);
						}

						yOffset += answerLines; // Adding some extra space between questions

					}
					else if (answer.AnswerText == chosenAnswer.AnswerText)
					{
						var answerDisplayText = $"{a + 1}. " + answer.AnswerText;
						gfx.DrawString(answerDisplayText, correctAnswerFont, XBrushes.Red,
							new XRect(60, yOffset, page.Width - 100, page.Height), XStringFormats.TopLeft);
						yOffset += answerLines; // Adding some extra space between questions
					}
					else
					{
						var answerDisplayText = $"{a + 1}. " + answer.AnswerText;
						gfx.DrawString(answerDisplayText, answerFont, XBrushes.Black,
							new XRect(60, yOffset, page.Width - 100, page.Height), XStringFormats.TopLeft);
						yOffset += answerLines; // Adding some extra space between questions
					}


				}

			}

			// Save the document to a memory stream
			using (MemoryStream stream = new MemoryStream())
			{
				try
				{
					document.Save(stream, false);
					return stream;
				}
				catch (Exception)
				{
					Console.WriteLine("Couldn't save file to stream");
					throw;
				}


			}
		}

		public async Task<List<TestModel>> GetAllTestsAsync()
        {
            var testEntities = await _testRepository.GetAllTestsAsync();
            var testModels = _mapper.Map<List<Test>, List<TestModel>>(testEntities);

            return testModels;

        }

		public async Task<List<TestScoreModel>> GetAllTestScoresByUserAsync(int userId)
		{
			List<TestScore> testScoreEntities = await _testRepository.GetAllTestScoresByUserAsync(userId);
            List<TestScoreModel> testScoreModels = _mapper.Map<List<TestScore>, List<TestScoreModel>>(testScoreEntities);
            return testScoreModels;
		}

		public async Task<TestScoreModel> GetTestScoreAsync(int testScoreId)
		{
            var testScoreEntity = await _testRepository.GetTestScoreAsync(testScoreId);
            var testScoreModel = _mapper.Map<TestScore, TestScoreModel>(testScoreEntity);
            return testScoreModel;
        }

		public async Task<TestModel> UpdateTestAsync(TestModel testModel)
        {
            var newTestEntity = _mapper.Map<TestModel, Test>(testModel);
            var updatedTestEntity = await _testRepository.UpdateTestAsync(newTestEntity);

            var updatedTestModel = _mapper.Map<Test, TestModel>(updatedTestEntity);
            return updatedTestModel;
        }
    }
}
