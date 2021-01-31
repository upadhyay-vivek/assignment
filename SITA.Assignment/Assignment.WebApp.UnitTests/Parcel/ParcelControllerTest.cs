using Assignment.WebApp.Controllers.api;
using Assignment.WebApp.DTOs;
using Assignment.WebApp.Services;
using Assignment.WebApp.Utils;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Assignment.WebApp.UnitTests.Parcel
{
    [TestFixture]
    public class ParcelControllerTest
    {
        private ParcelController _controller;
        private Mock<IParcelService> _parcelServiceWithMock;
        private ParcelService parcelServiceWithoutMock;
        private Mock<IMapper> _mapper;
        [SetUp]
        public void SetUp()
        {
            var xmlData = string.Empty;
            _parcelServiceWithMock = new Mock<IParcelService>(MockBehavior.Strict);
            _mapper = new Mock<IMapper>();
            _controller = new ParcelController(_parcelServiceWithMock.Object);
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            parcelServiceWithoutMock = new ParcelService(
               mapper);
            _parcelServiceWithMock.Setup(p => p.PostXmlData(It.IsAny<HttpPostedFileBase>())).Returns(xmlData);
            _parcelServiceWithMock.Setup(p => p.ProcessData(It.IsAny<string>())).Returns(new List<ParcelOutputDto>());
        }


        [Test]
        public void Find_should_return_department_as_mail() 
        {
            var xmlParcelData = "<?xml version=\"1.0\"?><Container xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Id>68465468</Id><ShippingDate>2016-07-22T00:00:00+02:00</ShippingDate><parcels><Parcel><Sender><Name>Klaas</Name><Address><Street>Uranusstraat</Street><HouseNumber>22</HouseNumber><PostalCode>2402AE</PostalCode><City>Alphen a/d Rijn</City></Address></Sender><Receipient><Name>Piet</Name><Address><Street>Schenklaan</Street><HouseNumber>22</HouseNumber><PostalCode>2497AV</PostalCode><City>Den Haag</City></Address></Receipient><Weight>0.99</Weight><Value>0.0</Value></Parcel></parcels></Container>";
            
            var result = parcelServiceWithoutMock.ProcessData(xmlParcelData);
            Assert.That(result[0].DepartmentName, Is.EqualTo(DepartmentConstants.MAIL));
           // _parcelServiceWithMock.Verify(p => p.ProcessData(xmlParcelData));
        }

        [Test]
        public void Find_should_return_department_as_regular()
        {
            var xmlParcelData = "<?xml version=\"1.0\"?><Container xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Id>68465468</Id><ShippingDate>2016-07-22T00:00:00+02:00</ShippingDate><parcels><Parcel><Sender><Name>Klaas</Name><Address><Street>Uranusstraat</Street><HouseNumber>22</HouseNumber><PostalCode>2402AE</PostalCode><City>Alphen a/d Rijn</City></Address></Sender><Receipient><Name>Piet</Name><Address><Street>Schenklaan</Street><HouseNumber>22</HouseNumber><PostalCode>2497AV</PostalCode><City>Den Haag</City></Address></Receipient><Weight>5.2</Weight><Value>0.0</Value></Parcel></parcels></Container>";

            var result = parcelServiceWithoutMock.ProcessData(xmlParcelData);
            Assert.That(result[0].DepartmentName, Is.EqualTo(DepartmentConstants.REGULAR));
        }

        [Test]
        public void Find_should_return_department_as_heavy()
        {
            var xmlParcelData = "<?xml version=\"1.0\"?><Container xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Id>68465468</Id><ShippingDate>2016-07-22T00:00:00+02:00</ShippingDate><parcels><Parcel><Sender><Name>Klaas</Name><Address><Street>Uranusstraat</Street><HouseNumber>22</HouseNumber><PostalCode>2402AE</PostalCode><City>Alphen a/d Rijn</City></Address></Sender><Receipient><Name>Piet</Name><Address><Street>Schenklaan</Street><HouseNumber>22</HouseNumber><PostalCode>2497AV</PostalCode><City>Den Haag</City></Address></Receipient><Weight>20.0</Weight><Value>750.0</Value></Parcel></parcels></Container>";

            var result = parcelServiceWithoutMock.ProcessData(xmlParcelData);
            Assert.That(result[0].DepartmentName, Is.EqualTo(DepartmentConstants.HEAVY));
        }

        [Test]
        public void Find_should_return_department_as_insurance()
        {
            var xmlParcelData = "<?xml version=\"1.0\"?><Container xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Id>68465468</Id><ShippingDate>2016-07-22T00:00:00+02:00</ShippingDate><parcels><Parcel><Sender><Name>Klaas</Name><Address><Street>Uranusstraat</Street><HouseNumber>22</HouseNumber><PostalCode>2402AE</PostalCode><City>Alphen a/d Rijn</City></Address></Sender><Receipient><Name>Piet</Name><Address><Street>Schenklaan</Street><HouseNumber>22</HouseNumber><PostalCode>2497AV</PostalCode><City>Den Haag</City></Address></Receipient><Weight>0.02</Weight><Value>1001.0</Value></Parcel></parcels></Container>";

            var result = parcelServiceWithoutMock.ProcessData(xmlParcelData);
            Assert.That(result[0].DepartmentName, Is.EqualTo(DepartmentConstants.INSURANCE));
        }

    }
}
