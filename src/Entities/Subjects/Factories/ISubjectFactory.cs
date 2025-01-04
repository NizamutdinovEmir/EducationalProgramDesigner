using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Factories;

public interface ISubjectFactory
{
    ISubjectBuilder Create();
}