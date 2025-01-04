using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Xunit;

namespace Lab2.Tests;

public class TestScenario2
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

        Laboratory newLaboratory = new LaboratoryBuilder()
            .SetBaseLab(laboratory)
            .SetPoints(15)
            .SetAuthor(user)
            .Build();

        // Act

        // Assert
        Assert.Equal(laboratory.Id, newLaboratory.BaseLabId);
    }
}