using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Xunit;

namespace Lab2.Tests;

public class TestScenario1
{
    [Fact]
    public void Check_ChangeOfEntityIsNotByTheAuthor()
    {
        // Arrange
        var user = new User("Emir");
        Laboratory laboratory = new LaboratoryBuilder()
            .SetName("Test")
            .SetCriteria("WithoutMistakes")
            .SetDescription("The first")
            .SetAuthor(user)
            .SetPoints(10)
            .Build();

        var newUser = new User("Ivan");

        // Act
        UnauthorizedAccessException exception = Assert.Throws<UnauthorizedAccessException>(() =>
            laboratory.Modify(author: newUser, name: "New Title", description: "New Description", criteria: "New Content"));

        // Assert
        Assert.Equal("You are not authorized to modify this laboratory.", exception.Message);
    }
}