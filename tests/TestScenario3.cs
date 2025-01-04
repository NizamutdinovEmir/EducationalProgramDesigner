using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Xunit;

namespace Lab2.Tests;

public class TestScenario3
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
            .SetPoints(30)
            .Build();

        Laboratory newLaboratory = new LaboratoryBuilder()
            .SetBaseLab(laboratory)
            .SetPoints(45)
            .SetAuthor(user)
            .Build();

        var examFactory = new ExamSubjectFactory();
        ISubjectBuilder builder = examFactory.Create();
        ISubjectBuilder subjectOOP = builder
            .SetName("OOP")
            .AddLaboratoryWork(newLaboratory)
            .AddLaboratoryWork(laboratory)
            .SetAuthor(user)
            .SetPointsForExam(10);

        // Act
        ArgumentException exception = Assert.Throws<ArgumentException>(() => subjectOOP.Build());

        // Assert
        Assert.Equal("The number of points should be 100.", exception.Message);
    }
}