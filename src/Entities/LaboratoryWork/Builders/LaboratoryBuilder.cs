using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork.Builders;

public class LaboratoryBuilder : ILaboratoryBuilder
{
    private string? _name;
    private string? _description;
    private string? _criteria;
    private int? _points;
    private User? _author;
    private Guid? _baseLabId;
    private Laboratory? _baseLab;

    public ILaboratoryBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ILaboratoryBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public ILaboratoryBuilder SetCriteria(string criteria)
    {
        _criteria = criteria;
        return this;
    }

    public ILaboratoryBuilder SetPoints(int points)
    {
        _points = points;
        return this;
    }

    public ILaboratoryBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public ILaboratoryBuilder SetBaseLab(Laboratory baseLab)
    {
        _baseLab = baseLab.Clone();
        _baseLabId = baseLab.Id;
        return this;
    }

    public Laboratory Build()
    {
        if (_baseLab != null)
        {
            return new Laboratory(
                _baseLab.Name ?? throw new ArgumentNullException(nameof(_baseLab.Name)),
                _baseLab.Description ?? throw new ArgumentNullException(nameof(_baseLab.Description)),
                _baseLab.Criteria ?? throw new ArgumentNullException(nameof(_baseLab.Criteria)),
                _baseLab.Points,
                _baseLab.Author ?? throw new ArgumentNullException(nameof(_baseLab.Author)))
            {
                BaseLabId = _baseLabId ?? throw new ArgumentNullException(nameof(_baseLabId)),
            };
        }

        return new Laboratory(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _description ?? throw new ArgumentNullException(nameof(_description)),
            _criteria ?? throw new ArgumentNullException(nameof(_criteria)),
            _points ?? throw new ArgumentNullException(nameof(_points)),
            _author ?? throw new ArgumentNullException(nameof(_author)));
    }
}