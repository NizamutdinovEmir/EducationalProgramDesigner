using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects;

public class Subject : ICloneable<Subject>, IEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public IReadOnlyCollection<Laboratory> LaboratoryWorks { get; private set; }

    public IReadOnlyCollection<LectureMaterial> LectureMaterials { get; private set; }

    public User Author { get; private set; }

    public string Format { get; private set; }

    public int PointsLab { get; private set; }

    public int PointsForExam { get; private set; }

    public int MaxPoints { get; } = 100;

    public Guid? BaseSubjectId { get; internal set; }

    public Subject(
        string name,
        IReadOnlyCollection<Laboratory> laboratoryWorks,
        IReadOnlyCollection<LectureMaterial> lectureMaterials,
        string format,
        int pointsLab,
        int points,
        User author)
    {
        if (points + pointsLab != MaxPoints)
        {
            throw new ArgumentException("The number of points should be 100.");
        }

        Name = name;
        LaboratoryWorks = laboratoryWorks;
        LectureMaterials = lectureMaterials;
        Format = format;
        PointsLab = pointsLab;
        PointsForExam = points;
        Author = author;
    }

    public Subject Clone()
    {
        return new Subject(Name, LaboratoryWorks, LectureMaterials, Format, PointsLab, PointsForExam, Author)
        {
            BaseSubjectId = this.Id,
        };
    }

    public void Modify(User author, string? name = null, IReadOnlyCollection<LectureMaterial>? lectureMaterials = null, string? format = null)
    {
        if (Author.Id != author.Id)
        {
            throw new UnauthorizedAccessException("You are not authorized to modify this laboratory.");
        }

        if (!string.IsNullOrEmpty(name))
        {
            Name = name;
        }

        if (lectureMaterials != null && lectureMaterials.Count != 0)
        {
            LectureMaterials = lectureMaterials;
        }

        if (!string.IsNullOrEmpty(format))
        {
            Format = format;
        }
    }
}