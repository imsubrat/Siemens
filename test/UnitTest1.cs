using System;
using Xunit;
using Moq;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateDiscountForNormalUser()
        {
            Siemens.Model.PriceModel normalUser=new Siemens.Model.PriceModel
            {
                pricePerGm=10,
                weight=10,
                userType=Siemens.Entity.UserType.Normal,
                total=0
            };

            Siemens.Model.PriceModel normalUserExpected=new Siemens.Model.PriceModel
            {
                pricePerGm=10,
                weight=10,
                userType=Siemens.Entity.UserType.Normal,
                total=100
            };
            var service=new Mock<Siemens.Service.IDiscountService>();
            service.Setup(x=>x.Calculate(normalUser)).Returns(normalUserExpected);
            Assert.Equal(normalUserExpected,service.Object.Calculate(normalUser));
        }

        [Fact]
        public void CalculateDiscountForPriviledgeUser()
        {
            Siemens.Model.PriceModel priviledgeUser=new Siemens.Model.PriceModel
            {
                pricePerGm=10,
                weight=10,
                userType=Siemens.Entity.UserType.Normal,
                total=0
            };

            Siemens.Model.PriceModel priviledgeUserExpected=new Siemens.Model.PriceModel
            {
                pricePerGm=10,
                weight=10,
                userType=Siemens.Entity.UserType.Normal,
                total=98
            };
            var service=new Mock<Siemens.Service.IDiscountService>();
            service.Setup(x=>x.Calculate(priviledgeUser)).Returns(priviledgeUserExpected);
            Assert.Equal(priviledgeUserExpected,service.Object.Calculate(priviledgeUser));
        }
    }
}
