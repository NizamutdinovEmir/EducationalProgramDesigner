using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Factories;

public class ExamSubjectFactory : ISubjectFactory
{
    public ISubjectBuilder Create()
    {
        return new SubjectBuilder().SetFormat("Exam");
    }
}