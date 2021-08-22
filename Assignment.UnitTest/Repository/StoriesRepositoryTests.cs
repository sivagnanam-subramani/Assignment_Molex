using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using Moq;
using Assignment.Services.Interfaces;
using Assignment.Repository;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Assignment.UnitTest.Repository
{
    public class StoriesRepositoryTests
    {
        #region Mock Properties 
        public Mock<IRestService> _restService;
        #endregion End of Mock Properties

        [SetUp]
        public void Setup()
        {
            _restService = new Mock<IRestService>();
        }

        //*=========================StoriesRepositoryTests-GetStories============================*//

        [TestFixture]
        public class GetStories : StoriesRepositoryTests
        {
            [TestCase]
            public async Task Given_GetStories_Called_Return_Data()
            {
                // Arrange
                HttpContent content = new StringContent("[28262122,28260194,28262711,28238317,28254378,28260875,28259104,28258189,28255896,28262825,28260568,28256326,28262820,28255467,28258515,28257352,28261658,28255718,28254571,28262402,28257666,28256051,28255313,28250076,28253460,28258945,28261718,28260328,28258744,28254793,28255911,28255788,28254630,28257933,28254080,28259271,28255803,28249977,28260020,28262194,28260313,28257947,28257243,28262498,28260361,28259592,28255116,28261824,28257860,28260673,28261760,28259977,28257098,28260300,28258480,28244246,28258545,28245277,28253692,28262180,28262539,28260393,28261997,28261144,28261074,28261940,28257197,28256643,28258421,28262022,28260415,28256686,28230977,28256116,28260074,28261624,28261733,28255634,28258072,28256256,28261948,28260290,28247379,28261768,28262343,28243636,28255189,28240279,28259103,28256728,28261726,28252165,28248498,28256429,28257116,28253245,28261921,28252049,28233916,28261563,28257958,28256965,28260450,28244744,28255880,28256220,28255830,28246899,28253993,28253050,28262605,28259153,28248488,28259263,28259474,28252908,28255319,28232645,28253293,28261232,28259644,28232369,28231811,28260717,28260715,28255294,28261131,28251801,28230704,28231187,28242678,28240533,28230789,28247432,28236102,28255781,28242770,28251700,28232602,28250340,28245129,28258855,28241255,28261792,28253110,28247034,28254252,28231747,28244511,28237274,28251396,28231981,28260923,28260915,28259687,28256858,28246636,28246063,28262210,28257917,28238760,28254495,28250225,28246286,28234057,28231581,28257515,28249468,28259037,28238977,28248945,28260428,28232469,28245221,28235529,28240552,28258194,28234122,28238762,28245634,28258039,28251591,28246054,28234460,28254614,28243648,28232373,28241018,28254525,28236486,28246850,28239410,28254493,28245049,28242024,28234629,28241758,28259031,28257026,28246151,28255349,28250489,28246709,28232660,28241033,28230482,28246265,28262309,28259695,28242564,28257956,28241589,28237556,28239113,28244249,28250282,28239692,28254519,28233077,28241398,28248719,28242300,28259360,28249177,28242675,28228987,28251001,28230829,28230092,28243937,28239856,28236217,28252550,28233525,28254129,28231507,28247392,28253915,28254120,28232039,28254688,28237443,28230641,28246237,28234990,28235555,28256499,28250149,28236762,28251384,28232627,28257498,28243781,28233735,28261865,28246837,28258190,28241753,28254872,28241439,28245478,28232165,28249216,28255622,28238124,28242476,28253424,28229525,28257733,28233819,28254294,28235115,28235449,28233118,28239203,28250513,28251960,28238163,28234779,28229175,28250103,28249236,28232922,28233208,28231194,28257386,28258786,28249566,28242637,28251737,28234937,28248527,28248536,28235936,28252554,28252600,28247196,28257009,28230305,28252004,28240810,28256016,28251711,28256494,28229494,28240748,28258209,28252667,28238698,28233592,28238376,28255374,28229291,28250106,28235002,28244059,28232139,28237031,28235469,28244499,28252727,28247585,28230470,28240461,28242062,28231422,28229838,28232343,28253917,28250823,28239900,28236005,28238186,28239355,28254780,28256789,28259207,28261462,28246652,28251085,28255376,28250413,28257055,28246078,28250212,28247304,28247021,28243370,28230415,28248301,28256283,28230089,28233743,28253727,28234915,28252729,28237776,28256021,28239958,28237532,28250452,28244216,28254770,28248354,28255207,28240838,28235673,28252511,28230248,28235250,28260067,28253461,28243920,28250862,28253928,28252087,28236472,28238457,28239424,28258104,28237899,28248772,28230224,28231239,28244132,28246044,28255113,28229127,28231147,28236062,28239689,28253602,28253081,28231160,28238848,28234704,28241884,28233963,28238178,28253234,28233583,28246124,28241779,28251411,28254529,28240503,28239764,28242053,28231851,28254279,28241801,28246620,28232975,28247759,28231417,28259734,28251993,28239855,28237479,28234323,28242869,28241636,28251339,28251293,28232708,28235797,28243739,28255865,28253514,28229128,28246920,28234698,28244670,28231550,28230773,28231320,28261147,28253165,28247264,28249766,28237535,28246932,28252871,28237018,28252679,28252674,28233683,28244890,28241646,28230184,28260395,28244592,28234303,28230051,28251978,28241121,28229496,28231050,28241886,28240550,28243731,28230267,28255686,28230186,28239907,28252688,28256374,28235033,28230593,28236006,28235627,28243904,28238462,28242334,28239910,28239828,28239637,28248500,28241851,28248200,28248010,28236560,28229576,28234383,28242317,28233461,28234609,28251408,28237377,28231586,28253588,28237166,28255372,28236656,28245946,28242922,28239731,28240878,28245434,28243256]");
                HttpResponseMessage response = new HttpResponseMessage
                { StatusCode = HttpStatusCode.OK, Content = content };
                _restService.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(response));
                var _storiesRepository = new StoriesRepository(_restService.Object);

                // Act
                var resp = await _storiesRepository.GetStories();

                // Assert
                Assert.IsNotNull(resp);
                Assert.Greater(resp.Count, 0);
            }

            [TestCase]
            public async Task Given_GetStories_Called_Return_Empty_List()
            {
                // Arrange
                HttpContent content = new StringContent("");
                HttpResponseMessage response = new HttpResponseMessage
                { StatusCode = HttpStatusCode.OK, Content = content };
                _restService.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(response));
                var _storiesRepository = new StoriesRepository(_restService.Object);

                // Act
                var resp = await _storiesRepository.GetStories();

                // Assert
                Assert.IsNotNull(resp);
                Assert.AreEqual(resp.Count, 0);
            }

        }

        //*=========================StoriesRepositoryTests-GetStoryDetails============================*//

        [TestFixture]
        public class GetStoryDetails : StoriesRepositoryTests
        {
            [TestCase]
            public async Task Given_GetStoryDetails_Called_Return_Data()
            {
                // Arrange
                HttpContent content = new StringContent("{\"by\":\"based2\",\"descendants\":103,\"id\":22512196,\"kids\":[22512529,22512762,22513538,22514324,22513444,22513905,22516491,22516786,22515683,22513072,22518716,22512738,22512362,22513618,22517367,22516646,22513876,22514434,22513423],\"score\":425,\"time\":1583596975,\"title\":\"Firecracker: Secure and fast microVMs for serverless computing\",\"type\":\"story\",\"url\":\"https://firecracker-microvm.github.io/\"}");
                HttpResponseMessage response = new HttpResponseMessage
                { StatusCode = HttpStatusCode.OK, Content = content };
                _restService.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(response));
                var _storiesRepository = new StoriesRepository(_restService.Object);
                var parameterList = new List<string>() { "22512196" };

                // Act
                var resp = await _storiesRepository.GetStoryDetails(parameterList);

                // Assert
                Assert.IsNotNull(resp);
                Assert.Greater(resp.Count, 0);
                Assert.AreEqual(resp[0].Id, 22512196);
                Assert.AreEqual(resp[0].Title, "Firecracker: Secure and fast microVMs for serverless computing");
            }

            [TestCase]
            public async Task Given_GetStoryDetails_Called_Return_Empty_Data()
            {
                // Arrange
                HttpContent content = new StringContent("");
                HttpResponseMessage response = new HttpResponseMessage
                { StatusCode = HttpStatusCode.OK, Content = content };
                _restService.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(response));
                var _storiesRepository = new StoriesRepository(_restService.Object);
                var parameterList = new List<string>() { "22512196" };

                // Act
                var resp = await _storiesRepository.GetStoryDetails(parameterList);

                // Assert
                Assert.IsNotNull(resp);
                Assert.AreEqual(resp.Count, 0);
            }

            [TestCase]
            public async Task Given_GetStoryDetails_When_Parameter_List_Is_Empty_Called_Return_Empty_Data()
            {
                // Arrange
                HttpContent content = new StringContent("");
                HttpResponseMessage response = new HttpResponseMessage
                { StatusCode = HttpStatusCode.OK, Content = content };
                _restService.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(response));
                var _storiesRepository = new StoriesRepository(_restService.Object);
                var parameterList = new List<string>();

                // Act
                var resp = await _storiesRepository.GetStoryDetails(parameterList);

                // Assert
                Assert.IsNotNull(resp);
                Assert.AreEqual(resp.Count, 0);
            }

        }
    }
}
