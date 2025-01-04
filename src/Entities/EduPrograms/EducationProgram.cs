using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EduPrograms;

public class EducationProgram : IEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Dictionary<int, List<Subject>> SemesterAndSubjects { get; private set; }

    public User Author { get; private set; }

    public EducationProgram(
        string name,
        Dictionary<int, List<Subject>> semesterAndSubjects,
        User author)
    {
        Id = Guid.NewGuid();
        Name = name;
        SemesterAndSubjects = semesterAndSubjects;
        Author = author;
    }
}