using Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Subjects.Builders;

public interface ISubjectBuilder
{
    ISubjectBuilder SetName(string name);

    ISubjectBuilder AddLaboratoryWork(Laboratory laboratory);

    ISubjectBuilder AddLectureMaterial(LectureMaterial material);

    ISubjectBuilder SetAuthor(User author);

    ISubjectBuilder SetFormat(string format);

    ISubjectBuilder SetPointsForExam(int points);

    ISubjectBuilder SetBaseSubject(Subject baseSubject);

    Subject Build();
}