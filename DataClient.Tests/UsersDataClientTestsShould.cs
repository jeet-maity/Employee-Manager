using System;
using System.Linq;
using Xunit;

namespace DataClient.Tests
{
    public class UsersDataClientTestsShould
    {
        [Fact]
        public void ReturnAtLeastOneUserWhenSearchedByName()
        {
            //Arrange
            var client = new UsersDataClient();
            var name = "Mr";

            //Act
            var list = client.SearchUsersByName(name);

            //Assert
            Assert.True(list.Any());
        }

        [Fact]
        public void ReturnAtLeastOneUserWhenGettingAll()
        {
            //Arrange
            var client = new UsersDataClient();

            //Act
            var list = client.GetAllUsers();

            //Assert
            Assert.True(list.Any());
        }
    }
}
