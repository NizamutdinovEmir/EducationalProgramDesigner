using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EduPrograms.Builders;

public interface IEducationProgramBuilder
{
    IEducationProgramBuilder SetName(string name);

    IEducationProgramBuilder AddSemesterAndSubjects(int semester, Subject subject);

    IEducationProgramBuilder SetAuthor(User author);

    EducationProgram Build();
}