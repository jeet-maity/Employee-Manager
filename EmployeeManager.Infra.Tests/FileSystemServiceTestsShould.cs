using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Moq;
using Xunit;

namespace EmployeeManager.Infra.Tests
{
    public class FileSystemServiceTestsShould
    {
        [Fact]
        public void HandleEmptyEnumerableWithoutException()
        {
            // Arrange
            var emptyExportableList = new List<Exportable>();
            var sut = new FileSystemService();

            // Act
            var location = sut.Save(emptyExportableList, "Test");

            // Assert
            Assert.IsAssignableFrom<string>(location);
        }

        [Fact]
        public void SaveAnEnumerableAndReturnThePathLocation()
        {
            // Arrange
            var randomExportableList = new List<ExportableString>
            {
                new ExportableString("SampleData 1"),
                new ExportableString("SampleData 2")
            };
            var sut = new FileSystemService();

            // Act
            var location = sut.Save(randomExportableList, "Test");

            // Assert
            Assert.True(File.Exists(location));
        }
    }
}
