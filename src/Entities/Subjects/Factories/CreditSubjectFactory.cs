using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Factories;

public class CreditSubjectFactory : ISubjectFactory
{
    public ISubjectBuilder Create()
    {
        return new SubjectBuilder().SetFormat("Credit");
    }
}