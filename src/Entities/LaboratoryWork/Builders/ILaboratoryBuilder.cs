using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork.Builders;

public interface ILaboratoryBuilder
{
    ILaboratoryBuilder SetName(string name);

    ILaboratoryBuilder SetDescription(string description);

    ILaboratoryBuilder SetCriteria(string criteria);

    ILaboratoryBuilder SetPoints(int points);

    ILaboratoryBuilder SetAuthor(User author);

    ILaboratoryBuilder SetBaseLab(Laboratory baseLab);

    Laboratory Build();
}