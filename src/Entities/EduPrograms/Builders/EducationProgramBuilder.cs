using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EduPrograms.Builders;

public class EducationProgramBuilder : IEducationProgramBuilder
{
    private readonly Dictionary<int, List<Subject>> _subjects = [];
    private string? _name;
    private User? _author;

    public IEducationProgramBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public IEducationProgramBuilder AddSemesterAndSubjects(int semester, Subject subject)
    {
        if (_subjects.ContainsKey(semester))
        {
            _subjects[semester].Add(subject);
        }
        else
        {
            _subjects[semester] = new List<Subject> { subject };
        }

        return this;
    }

    public IEducationProgramBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public EducationProgram Build()
    {
        return new EducationProgram(
         _name ?? throw new ArgumentNullException(nameof(_name)),
         _subjects ?? throw new ArgumentNullException(nameof(_subjects)),
         _author ?? throw new ArgumentNullException(nameof(_author)));
    }
}