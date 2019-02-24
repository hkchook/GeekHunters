using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using GeekHunters.Entities;
using GeekHunters.Repositories.Interfaces;
using GeekHunters.Services.Interfaces;
using GeekHunters.Services;

namespace GeekHuntersTests
{
    [TestFixture]
    public class GeekHuntersTests
    {
        private ICandidateService _candidateService;
        private Mock<ICandidateRepository> _candidateRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _candidateService = new CandidateService(_candidateRepositoryMock.Object);
        }

        [TestCase(1, "ABC123")]
        [TestCase(2, "DEF456")]
        [TestCase(3, "GHI789")]
        public void GetCandidate_ReturnCandidate_GivenId(int Id, string result)
        {
            var inputcandidates = new List<Candidate>()
                {
                    new Candidate
                    {
                        FirstName = "ABC123",
                        Id = 1
                    },
                    new Candidate
                    {
                        FirstName = "DEF456",
                        Id = 2
                    }
                    ,
                    new Candidate
                    {
                        FirstName = "GHI789",
                        Id = 3
                    }
                };

            Candidate returnCandidates = new Candidate();

            //arrange
            _candidateRepositoryMock.Setup(x => x.GetCandidate(It.IsAny<int>()))
                .Callback((int id) => { returnCandidates = inputcandidates.Where(x => x.Id == id).FirstOrDefault(); });

            //act
            _candidateService.GetCandidate(Id);

            //assert
            Assert.That(returnCandidates.FirstName, Is.EqualTo(result));
        }

        [Test]
        public void GetCandidates_ReturnCandidates()
        {
            //arrange
            _candidateRepositoryMock.Setup(x => x.GetCandidates())
                .ReturnsAsync(new List<Candidate>()
                {
                    new Candidate
                    {
                        FirstName = "ABC123"
                    },
                    new Candidate
                    {
                        FirstName = "DEF456"
                    }
                });

            //act
            var candidates = _candidateService.GetCandidates();

            //assert
            Assert.That(candidates.Result.ToList()[0].FirstName, Is.EqualTo("ABC123"));
            Assert.That(candidates.Result.ToList()[1].FirstName, Is.EqualTo("DEF456"));
        }

        [TestCase(1, "ABC123")]
        [TestCase(2, "DEF456")]
        [TestCase(3, "GHI789")]
        public void GetCandidatesBySkillId_ReturnCandidatesOfThatSkillId(int skillid, string result)
        {
            var inputcandidates = new List<Candidate>()
                {
                    new Candidate
                    {
                        FirstName = "ABC123",
                        SkillId = 1
                    },
                    new Candidate
                    {
                        FirstName = "DEF456",
                        SkillId = 2
                        
                    }
                    ,
                    new Candidate
                    {
                        FirstName = "GHI789",
                        SkillId = 3
                    }
                };

            List<Candidate> returnCandidates = new List<Candidate>();

            //arrange
            _candidateRepositoryMock.Setup(x => x.GetCandidatesBySkillId(It.IsAny<int>()))
                .Callback((int id) => { returnCandidates = inputcandidates.Where(x => x.SkillId == id).ToList(); });

            //act
            _candidateService.GetCandidatesBySkillId(skillid);

            //assert
            Assert.That(returnCandidates[0].FirstName, Is.EqualTo(result));
        }

        [Test]
        public void CreateCandidate_ReturnTrue_GivenCandidate()
        {
            Candidate returnCandidate = new Candidate();

            //arrange
            _candidateRepositoryMock.Setup(x => x.AddCandidate(It.IsAny<Candidate>()))
                .Callback((Candidate m) => { returnCandidate = m; });

            //act
            _candidateService.AddCandidate(new Candidate { FirstName = "Me" });

            //assert
            Assert.That(returnCandidate.FirstName, Is.EqualTo("Me"));
        }

        [Test]
        public void UpdateCandidate_ReturnTrue_GivenCandidate()
        {
            //arrange
            _candidateRepositoryMock.Setup(x => x.UpdateCandidate(It.IsAny<Candidate>()))
                .ReturnsAsync(true);

            //act
            var isUpdated = _candidateService.UpdateCandidate(new Candidate());

            //assert
            Assert.That(isUpdated.Result, Is.EqualTo(true));
        }

        [Test]
        public void DeleteCandidate_ReturnTrue_GivenCandidate()
        {
            bool result = false;
            //arrange
            _candidateRepositoryMock.Setup(x => x.DeleteCandidate(It.IsAny<int>()))
                .Callback((int id) => { result = id == 1 ? true : false; });

            //act
            _candidateService.DeleteCandidate(1);

            //assert
            Assert.That(result, Is.EqualTo(true));
        }
    }
}