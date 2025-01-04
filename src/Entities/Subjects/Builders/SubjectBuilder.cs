using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Builders;

public class SubjectBuilder : ISubjectBuilder
{
    private readonly List<LectureMaterial> _lectureMaterials = [];
    private readonly List<Laboratory> _laboratoryWorks = [];
    private string? _name;
    private User? _author;
    private string? _format;
    private int? _pointsForExam;
    private int _pointsLab;
    private Subject? _baseSubject;
    private Guid? _baseSubjectId;

    public ISubjectBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ISubjectBuilder AddLaboratoryWork(Laboratory laboratory)
    {
        _laboratoryWorks.Add(laboratory);
        _pointsLab += laboratory.Points;
        return this;
    }

    public ISubjectBuilder AddLectureMaterial(LectureMaterial material)
    {
        _lectureMaterials.Add(material);
        return this;
    }

    public ISubjectBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public ISubjectBuilder SetFormat(string format)
    {
        _format = format;
        return this;
    }

    public ISubjectBuilder SetPointsForExam(int points)
    {
        _pointsForExam = points;
        return this;
    }

    public ISubjectBuilder SetBaseSubject(Subject baseSubject)
    {
        _baseSubject = baseSubject.Clone();
        _baseSubjectId = baseSubject.Id;
        return this;
    }

    public Subject Build()
    {
        if (_baseSubject != null)
        {
            return new Subject(
                _baseSubject.Name ?? throw new ArgumentNullException(nameof(_baseSubject.Name)),
                _baseSubject.LaboratoryWorks,
                _baseSubject.LectureMaterials,
                _baseSubject.Format ?? throw new ArgumentNullException(nameof(_baseSubject.Format)),
                _baseSubject.PointsLab,
                _baseSubject.PointsForExam,
                _baseSubject.Author ?? throw new ArgumentNullException(nameof(_baseSubject.Author)))
            {
                BaseSubjectId = _baseSubjectId ?? throw new ArgumentNullException(nameof(_baseSubjectId)),
            };
        }

        return new Subject(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _laboratoryWorks.ToArray(),
            _lectureMaterials.ToArray(),
            _format ?? throw new ArgumentNullException(nameof(_format)),
            _pointsLab,
            _pointsForExam ?? throw new ArgumentNullException(nameof(_pointsForExam)),
            _author ?? throw new ArgumentNullException(nameof(_author)));
    }
}